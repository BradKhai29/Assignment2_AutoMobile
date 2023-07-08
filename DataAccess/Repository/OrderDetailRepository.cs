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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public AbstractDAO<OrderDetail> DAO { get; }

        public OrderDetailRepository(AppDbContext dbContext) 
            => DAO = new OrderDetailDAO(dbContext);

        public void Delete(int id) => DAO.Delete(id);

        public IList<OrderDetail> GetAll() => DAO.GetAll();

        public OrderDetail GetByCondition(Func<OrderDetail, bool> condition) 
            => DAO.GetByCondition(condition);

        public OrderDetail GetById(int id) => DAO.GetById(id);

        public DatabaseResponse<OrderDetail> Insert(OrderDetail entity) 
            => DAO.Insert(entity);

        public void Update(OrderDetail entity) => DAO.Update(entity);

        public IList<OrderDetail> GetListByCondition(Func<OrderDetail, bool> condition) 
            => DAO.GetListByCondition(condition);
    }
}
