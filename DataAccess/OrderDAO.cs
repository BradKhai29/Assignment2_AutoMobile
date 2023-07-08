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
    public class OrderDAO : AbstractDAO<Order>
    {
        public OrderDAO(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(int id)
        {
            var order = dbContext.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                dbContext.Orders.Remove(order);
                dbContext.SaveChanges();
            }
        }

        public override IList<Order> GetAll() => dbContext.Orders.Include(o => o.Member).AsNoTracking().ToList();

        public override IList<Order> GetListByCondition(Func<Order, bool> condition)
        {
            return dbContext.Orders.Include(nameof(Order.Member)).AsNoTracking().Where(condition).ToList();
        }

        public override Order GetById(int id) 
            => dbContext.Orders.AsNoTracking().FirstOrDefault(o => o.OrderId == id);

        public override DatabaseResponse<Order> Insert(Order entity)
        {
            var entry = dbContext.Orders.Add(entity);
            dbContext.SaveChanges();
            return new DatabaseResponse<Order>
            {
                IsSuccess = true,
                Message = DatabaseResponse<object>.InsertSuccess,
                Response = entry.Entity
            };
        }

        public override void Update(Order entity)
        {
            var order = dbContext.Orders.First(o => o.OrderId == entity.OrderId);
            if(order != null)
            {
                order.RequiredDate = entity.RequiredDate;
                order.ShippedDate = entity.ShippedDate;
                order.Freight = entity.Freight;

                dbContext.SaveChanges();
            }
        }
    }
}
