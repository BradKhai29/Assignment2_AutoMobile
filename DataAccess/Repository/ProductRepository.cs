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
    public class ProductRepository : IProductRepository
    {
        public AbstractDAO<Product> DAO { get; }

        public ProductRepository(AppDbContext dbContext)
            => DAO = new ProductDAO(dbContext);

        public void Delete(int id) => DAO.Delete(id);

        public IList<Product> GetAll() => DAO.GetAll();

        public Product GetByCondition(Func<Product, bool> condition) 
            => DAO.GetByCondition(condition);

        public Product GetById(int id) => DAO.GetById(id);

        public DatabaseResponse<Product> Insert(Product entity) 
            => DAO.Insert(entity);

        public void Update(Product entity) => DAO.Update(entity);

        public IList<Product> GetListByCondition(Func<Product, bool> condition) 
            => DAO.GetListByCondition(condition);
    }
}
