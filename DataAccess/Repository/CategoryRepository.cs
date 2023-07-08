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
    public class CategoryRepository : ICategoryRepository
    {
        public AbstractDAO<Category> DAO { get; }

        public CategoryRepository(AppDbContext dbContext) 
            => DAO = new CategoryDAO(dbContext);

        public void Delete(int id) => DAO.Delete(id);

        public IList<Category> GetAll() => DAO.GetAll();

        public Category GetByCondition(Func<Category, bool> condition) => DAO.GetByCondition(condition);

        public Category GetById(int id) => DAO.GetById(id);

        public DatabaseResponse<Category> Insert(Category entity) => DAO.Insert(entity);

        public void Update(Category entity) => DAO.Update(entity);

        public IList<Category> GetListByCondition(Func<Category, bool> condition)
            => DAO.GetListByCondition(condition);
    }
}
