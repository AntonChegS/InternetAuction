using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Identity;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataBaseContext db;
        private ApplicationDbContext adb;
        private Repository<Lot> lotRepository;
        private Repository<Category> categoryRepository;
        private UserRepository UserRepository;
     

        public UnitOfWork(string connectionString)
        {
            db = new DataBaseContext(connectionString);
            adb = new ApplicationDbContext();
            
        }

        public IRepository<Lot> Lots
        {
            get
            {
                if (lotRepository == null)
                    lotRepository = new Repository<Lot>(db);
                return lotRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new Repository<Category>(db);
                return categoryRepository;
            }
        }
        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepository(adb);
                return UserRepository;
            }
        }

   
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
