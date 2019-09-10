using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace UnitTests
{
    public class StubUnitOfWork : IUnitOfWork
    {
        private StubRepository<Lot> lots;
        private StubRepository<Category> categories;

        public IRepository<Lot> Lots
        {
            get
            {
                if (lots == null)
                {
                    lots = new StubRepository<Lot>();
                    Category tempCategory = Categories.Get(1);
                    Lot tempLot = new Lot()
                    {
                        Id = lots.GetAll().Count() + 1,
                        Name = "Dog",
                        StartPrice = 150,
                        CurrPrice = 150,
                        BuyNowPrice = 1500,
                        IsAllowed = false,
                        IsOpen = false,
                        CategoryId = tempCategory.Id,
                        Category = tempCategory,
                        Description = "qwe"
                    };
                    lots.Create(tempLot);
                    tempLot = new Lot()
                    {
                        Id = lots.GetAll().Count() + 1,
                        Name = "Cat",
                        StartPrice = 228,
                        CurrPrice = 228,
                        BuyNowPrice = 1337,
                        IsAllowed = false,
                        IsOpen = false,
                        CategoryId = tempCategory.Id,
                        Category = tempCategory,
                        Description = "asd"
                    };
                    lots.Create(tempLot);
                    tempLot = new Lot()
                    {
                        Id = lots.GetAll().Count() + 1,
                        Name = "Test Search key word",
                        StartPrice = 322,
                        CurrPrice = 322,
                        BuyNowPrice = 1337,
                        IsAllowed = false,
                        IsOpen = false,
                        CategoryId = tempCategory.Id,
                        Category = tempCategory,
                        Description = "zxc"
                    };
                    lots.Create(tempLot);
                }
                return lots;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    categories = new StubRepository<Category>();
                    Category category = new Category()
                    {
                        Id = 1,
                        Name = "Hammers",
                        Categories = new List<Category>()
                    };
                    categories.Create(category);
                }
                return categories;
            }
        }

        public void Save()
        {
            
        }
    }
}
