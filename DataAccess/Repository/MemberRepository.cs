using BusinessObject;
using DataAccess.Database;
using MyStoreWinApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public AbstractDAO<Member> DAO { get; }

        public MemberRepository(AppDbContext dbContext) 
            => DAO = new MemberDAO(dbContext);

        public void Delete(int id) => DAO.Delete(id);

        public IList<Member> GetAll() => DAO.GetAll();

        public Member GetByCondition(Func<Member, bool> condition) 
            => DAO.GetByCondition(condition);

        public Member GetById(int id) => DAO.GetById(id);

        public DatabaseResponse<Member> Insert(Member entity) 
            => DAO.Insert(entity);

        public void Update(Member entity) => DAO.Update(entity);

        public IList<Member> GetListByCondition(Func<Member, bool> condition) 
            => DAO.GetListByCondition(condition);
    }
}
