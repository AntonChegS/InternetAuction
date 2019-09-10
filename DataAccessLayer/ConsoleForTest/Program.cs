using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using BLL.DTO;

namespace ConsoleForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork u = new UnitOfWork("DBConnection");
          
            var lots = u.Lots.GetAll();
            var cat = u.Categories.GetAll();
            Console.WriteLine();
                foreach (var l in lots)
                {
                    Console.WriteLine($"Id - {l.Id} Name - {l.Name}  BuyNow price - {l.BuyNowPrice}  StartPrice - {l.CurrPrice} Category - {l.Category.Name}");
                }

            Console.WriteLine();
            foreach (var ca in cat)
            {
                Console.WriteLine($"Id {ca.Id}  Name - {ca.Name}");
             
                if (ca.Categories!=null&&ca.Categories?.Count() != 0) {
                    var list = ca.Categories;
                    foreach (var sub in list)
                    {
                        Console.WriteLine($"Id {sub.Id}  Name - {sub.Name} ParrentCategoryName -   {sub.ParrentCategory.Name}");
                    }

                }
            }

            Console.WriteLine(new string('_', 20));

            ISearchService searchService = new SearchService(u);
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Id = 2,
                Name = "Equipment"
            };

            
            
            Console.ReadLine();
        }
    }
}
