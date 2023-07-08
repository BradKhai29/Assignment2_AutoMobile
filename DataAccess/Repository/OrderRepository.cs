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
    public class OrderRepository : IOrderRepository
    {
        public AbstractDAO<Order> DAO { get; }

        public OrderRepository(AppDbContext dbContext) 
            => DAO = new OrderDAO(dbContext);

        public void Delete(int id) => DAO.Delete(id);

        public IList<Order> GetAll() => DAO.GetAll();

        public Order GetByCondition(Func<Order, bool> condition) 
            => DAO.GetByCondition(condition);

        public Order GetById(int id) => DAO.GetById(id);

        public DatabaseResponse<Order> Insert(Order entity) => DAO.Insert(entity);

        public void Update(Order entity) => DAO.Update(entity);

        public IList<Order> GetListByCondition(Func<Order, bool> condition) 
            => DAO.GetListByCondition(condition);
    }
}
