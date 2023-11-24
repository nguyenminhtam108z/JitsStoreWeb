using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JitsDataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filler);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filler = null);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
