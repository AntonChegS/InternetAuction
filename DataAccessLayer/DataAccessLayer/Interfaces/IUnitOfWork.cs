using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IRepository<Lot> Lots { get; }
         IRepository<Category> Categories { get; }
         

        void Save();
    }
}
