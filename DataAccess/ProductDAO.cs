using BusinessObject;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using MyStoreWinApp.Database;

namespace DataAccess
{
    public class ProductDAO : AbstractDAO<Product>
    {
        public ProductDAO(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(int id)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                product.IsAvailable = false;
                dbContext.SaveChanges();
            }
        }

        public override IList<Product> GetAll() => dbContext.Products.Include(p => p.Category).AsNoTracking().ToList();

        public override Product GetByCondition(Func<Product, bool> condition)
        {
            return dbContext.Products.AsNoTracking().FirstOrDefault(condition);
        }

        public override IList<Product> GetListByCondition(Func<Product, bool> condition)
        {
            return dbContext.Products.Include(p => p.Category).AsNoTracking().Where(condition).ToList();
        }

        public override Product GetById(int id)
            => dbContext.Products.Include(p => p.Category).AsNoTracking().FirstOrDefault(product => product.ProductId == id);

        public override DatabaseResponse<Product> Insert(Product entity)
        {
            var entry = dbContext.Products.Add(entity);
            dbContext.SaveChanges();
            return new DatabaseResponse<Product>
            {
                IsSuccess = true,
                Message = DatabaseResponse<object>.InsertSuccess,
                Response = entry.Entity
            };
        }

        public override void Update(Product entity)
        {
            var product = dbContext.Products.First(p => p.ProductId == entity.ProductId);
            if (product != null)
            {
                product.CategoryId = entity.CategoryId;
                product.ProductName = entity.ProductName;
                product.UnitPrice = entity.UnitPrice;
                product.UnitsInStock = entity.UnitsInStock;
                product.Weight = entity.Weight;
                product.IsAvailable = entity.IsAvailable;

                dbContext.SaveChanges();
            }
        }
    }
}
