using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace UnitTests
{
    public class StubRepository<T> : IRepository<T> where T : class
    {
        private List<T> list;

        public StubRepository()
        {
            list = new List<T>();
        }

        public StubRepository(List<T> list)
        {
            this.list = new List<T>(list);
        }

        public void Create(T item)
        {
            list.Add(item);
        }

        public void Delete(int id)
        {
            if (id - 1 >= 0 && id - 1 < list.Count)
            {
                list.Remove(list[id - 1]);
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return list.Where(predicate);
        }

        public T Get(int id)
        {
            if (id - 1 >= 0 && id - 1 < list.Count)
            {
                return list[id - 1];
            }
            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return list;
        }

        public void Update(T item)
        {
            //int id = list.IndexOf(item.);
            //if (id >= 0 && id < list.Count)
            //    list[id] = item;
            Lot lot = item as Lot;
            if (lot != null)
            {
                list[lot.Id - 1] = item;
            }
            else
            {
                Category category = item as Category;
                if (category != null)
                {
                    list[category.Id - 1] = item;
                }
            }
        }
    }
}
