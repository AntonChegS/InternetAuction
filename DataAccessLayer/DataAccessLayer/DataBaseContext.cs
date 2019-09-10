using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataBaseContext:DbContext

    {
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Category> Categories { get; set; }
       

        static DataBaseContext()
        {
            Database.SetInitializer(new Init());
        }
        public DataBaseContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
