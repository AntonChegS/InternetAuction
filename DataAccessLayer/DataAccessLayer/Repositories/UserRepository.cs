using DataAccessLayer.Identity;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IRepository<ApplicationUser>
    {
        private ApplicationDbContext db;
        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(ApplicationUser item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.Users;
        }

        public void Update(ApplicationUser item)
        {
            throw new NotImplementedException();
        }
    }
}
