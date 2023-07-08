using BusinessObject;
using DataAccess.Database;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using MyStoreWinApp.Database;

namespace DataAccess
{
    public class MemberDAO : AbstractDAO<Member>, IAuthService<Member>
    {
        public static Member Admin { get; set; }

        public MemberDAO(AppDbContext dbContext) : base(dbContext)
        {
        }

        public bool CheckExistEmail(string email)
        {
            bool isExist = dbContext.Members.Any(m => m.Email == email);
            return isExist;
        }

        public override void Delete(int id)
        {
            var member = dbContext.Members.FirstOrDefault(m => m.MemberId == id);
            if (member != null)
            {
                bool haveOrders = dbContext.Orders.AsNoTracking().Any(order => order.MemberId == id);
                if (haveOrders)
                {
                    throw new ArgumentException("Cannot delete because some orders is belonged to this Member");
                }

                dbContext.Members.Remove(member);
                dbContext.SaveChanges();
            }
        }

        public override IList<Member> GetAll() => dbContext.Members.AsNoTracking().ToList();

        public override Member GetByCondition(Func<Member, bool> condition)
        {
            return dbContext.Members.AsNoTracking()
                                    .FirstOrDefault(condition);
        }

        public override IList<Member> GetListByCondition(Func<Member, bool> condition)
        {
            return dbContext.Members.AsNoTracking().Where(condition).ToList();
        }

        public override Member GetById(int id)
            => dbContext.Members.AsNoTracking().FirstOrDefault(member => member.MemberId == id);

        public override DatabaseResponse<Member> Insert(Member entity)
        {
            var entry = dbContext.Members.Add(entity);
            dbContext.SaveChanges();
            return new DatabaseResponse<Member>
            {
                IsSuccess = true,
                Message = DatabaseResponse<object>.InsertSuccess,
                Response = entry.Entity
            };
        }

        public DatabaseResponse<Member> ValidateLogin(string email, string password)
        {
            if (Admin.Email == email && Admin.Password == password)
            {
                return new DatabaseResponse<Member>
                {
                    IsSuccess = true,
                    Message = "Login Success",
                    Response = Admin
                };
            }

            var account = GetByCondition(member => member.Email == email);
            if (account != null)
            {
                bool isValid = account.Password == password;
                return new DatabaseResponse<Member>
                {
                    IsSuccess = isValid,
                    Message = isValid ? "Login Success" : "Email or Password is not correct",
                    Response = isValid ? account : null
                };
            }
            else return new DatabaseResponse<Member>
            {
                IsSuccess = false,
                Message = "Email or Password is not correct",
                Response = null
            };
        }

        public override void Update(Member entity)
        {
            var member = dbContext.Members.First(m => m.MemberId == entity.MemberId);
            if (member != null)
            {
                member.Email = entity.Email;
                member.Password = entity.Password;
                member.City = entity.City;
                member.Country = entity.Country;
                member.CompanyName = entity.CompanyName;

                dbContext.SaveChanges();
            }
        }
    }
}
