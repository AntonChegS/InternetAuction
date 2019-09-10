using System.Data.Entity;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class Init : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            context.Categories.Add(new Category { Name = "Household products" });
            context.Categories.Add(new Category { Name = "Equipment" });
            context.Categories.Add(new Category { Name = "Other" });
            context.Categories.Add(new Category { Name = "Goods for kids" });

            context.Categories.Add(new Category { Name = "Hammers", ParrentCategoryId = 2 });
            context.Categories.Add(new Category { Name = "Things", ParrentCategoryId = 2 });
            context.Categories.Add(new Category { Name = "Ozimayi", ParrentCategoryId = 2 });

            context.Lots.Add(new Lot { Name = "Stroller", StartPrice = 100, CurrPrice = 100, BuyNowPrice = 1000, IsAllowed = false, IsOpen = false, CategoryId = 3});
         
            context.Lots.Add(new Lot { Name = "Smartphone", StartPrice = 500, CurrPrice = 500, BuyNowPrice = 2000, IsAllowed = false, IsOpen = false, CategoryId = 2 });
           
            context.Lots.Add(new Lot { Name = "Hammer", StartPrice = 50, CurrPrice = 50, BuyNowPrice = 300, IsAllowed = false, IsOpen = false, CategoryId = 1 });
        
            context.Lots.Add(new Lot { Name = "Baby clothes", StartPrice = 80, CurrPrice = 80, BuyNowPrice = 400, IsAllowed = false, IsOpen = false, CategoryId = 3 });

            context.Lots.Add(new Lot
            {
                Name = "Test Ozimay",
                StartPrice = 100,
                CurrPrice = 100,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = 6
            });

            context.Lots.Add(new Lot
            {
                Name = "Test Hammers",
                StartPrice = 100,
                CurrPrice = 100,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = 4
            });

            context.SaveChanges();


        }
    }
}
