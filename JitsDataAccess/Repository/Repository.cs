using JitsDataAccess.Data;
using JitsDataAccess.Repository.IRepository;
using JitsModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JitsDataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly JitsStoreContext _dbcontext;

        internal DbSet<T> dbSet;
        public Repository(JitsStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
            this.dbSet = dbcontext.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filler = null)
        {
            IQueryable<T> query = dbSet;
            if (filler != null)
            {
                query = query.Where(filler);
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filler)
        {
            IQueryable<T> query = dbSet;
            if (filler != null)
            {
                query = query.Where(filler);
            }

            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }
    }
}
