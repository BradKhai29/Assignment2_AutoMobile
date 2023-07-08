using BusinessObject;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using MyStoreWinApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : AbstractDAO<OrderDetail>
    {
        public OrderDetailDAO(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(int id)
        {
        }

        public override IList<OrderDetail> GetAll() => dbContext.OrderDetails.AsNoTracking().ToList();

        public override OrderDetail GetByCondition(Func<OrderDetail, bool> condition)
        {
            return dbContext.OrderDetails.AsNoTracking().FirstOrDefault(condition);
        }

        public override IList<OrderDetail> GetListByCondition(Func<OrderDetail, bool> condition)
        {
            return dbContext.OrderDetails.AsNoTracking().Where(condition).ToList();
        }

        public override OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override DatabaseResponse<OrderDetail> Insert(OrderDetail entity)
        {
            var entry = dbContext.OrderDetails.Add(entity);
            dbContext.SaveChanges();
            return new DatabaseResponse<OrderDetail>
            {
                IsSuccess = true,
                Message = DatabaseResponse<object>.InsertSuccess,
                Response = entry.Entity
            };
        }

        public override void Update(OrderDetail entity)
        {
            var condition = (OrderDetail o) =>
            {
                return o.OrderId == entity.OrderId 
                    && o.ProductId == entity.ProductId;
            };

            var detail = dbContext.OrderDetails.First(condition);
            if(detail != null)
            {
                detail.UnitPrice = entity.UnitPrice;
                detail.Quantity = entity.Quantity;
                detail.Discount = entity.Discount;

                dbContext.SaveChanges();
            }
        }
    }
}
