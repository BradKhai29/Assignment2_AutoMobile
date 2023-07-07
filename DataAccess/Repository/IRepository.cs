using DataAccess.Database;
using MyStoreWinApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        DatabaseResponse<T> Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        
        IList<T> GetListByCondition(Func<T, bool> condition);
        T GetByCondition(Func<T, bool> condition) => default;
    }
}
