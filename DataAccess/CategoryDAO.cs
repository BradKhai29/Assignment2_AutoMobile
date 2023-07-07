using BusinessObject;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using MyStoreWinApp.Database;

namespace DataAccess
{
    public class CategoryDAO : AbstractDAO<Category>
    {
        public CategoryDAO(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(int id)
        {
            var category = dbContext.Categories
                            .FirstOrDefault(category => category.CategoryId == id);

            if (category != null)
            {
                bool existProduct = dbContext.Products.AsNoTracking().Any(p => p.CategoryId == id);
                if (existProduct)
                {
                    throw new ArgumentException("Cannot delete because some products belong to this Category");
                }

                dbContext.Remove(category);
                dbContext.SaveChanges();
            }
            else throw new Exception($"Category with Id = {id} is not existed");
        }

        public override IList<Category> GetAll() => dbContext.Categories.AsNoTracking().ToList();

        public override Category GetByCondition(Func<Category, bool> condition)
        {
            var category = dbContext.Categories
                            .AsNoTracking()
                            .FirstOrDefault(condition);
            return category;
        }

        public override IList<Category> GetListByCondition(Func<Category, bool> condition)
        {
            return dbContext.Categories
                            .AsNoTracking()
                            .Where(condition).ToList();
        }

        public override Category GetById(int id)
        {
            if(id == 0) return dbContext.Categories
                                .AsNoTracking()
                                .FirstOrDefault();

            var category = dbContext.Categories
                            .AsNoTracking()
                            .FirstOrDefault(category => category.CategoryId == id);
            return category;
        }

        public override DatabaseResponse<Category> Insert(Category entity)
        {
            var entry = dbContext.Categories.Add(entity);
            dbContext.SaveChanges();
            return new DatabaseResponse<Category>
            {
                IsSuccess = true,
                Message = DatabaseResponse<object>.InsertSuccess,
                Response = entry.Entity
            };
        }

        public override void Update(Category entity)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.CategoryId == entity.CategoryId);
            if(category != null)
            {
                category.CategoryName = entity.CategoryName;
                dbContext.SaveChanges();
            }
        }
    }
}
