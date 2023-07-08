using DataAccess.Database;
using MyStoreWinApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class AbstractDAO<T> where T : class
    {
        private protected AppDbContext dbContext { get; set; }
        protected AbstractDAO(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public abstract IList<T> GetAll();
        public abstract T GetById(int id);
        public abstract DatabaseResponse<T> Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(int id);

        public virtual T GetByCondition(Func<T, bool> condition) => default;
        public virtual IList<T> GetListByCondition(Func<T, bool> condition) => null;
    }
}
