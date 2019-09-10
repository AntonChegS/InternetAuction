using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Interfaces;
 

namespace DataAccessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataBaseContext context;
        private DbSet<T> dbSet;

        public Repository(DataBaseContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T temp = dbSet.Find(id);
            if (temp != null)
                dbSet.Remove(temp);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
