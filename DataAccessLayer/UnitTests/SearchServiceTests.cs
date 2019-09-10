using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BLL.Services;
using BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using BLL.Infrastructure.Exceptions;

namespace UnitTests
{
    [TestClass]
    public class SearchServiceTests
    {
        [TestMethod]
        public void GetAllTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            SearchService searchService = new SearchService(uow);

            List<Lot> tempLots = uow.Lots.GetAll().ToList();

            List<LotDTO> lots = searchService.GetAll().ToList();

            Assert.AreEqual(tempLots.Count, lots.Count);

            for (int i = 0; i < lots.Count; i++)
            {
                Assert.IsTrue(lots[i].Name == tempLots[i].Name);
                Assert.IsTrue(lots[i].StartPrice == tempLots[i].StartPrice);
                Assert.IsTrue(lots[i].CurrPrice == tempLots[i].CurrPrice);
                Assert.IsTrue(lots[i].BuyNowPrice == tempLots[i].BuyNowPrice);
                Assert.IsTrue(lots[i].IsAllowed == tempLots[i].IsAllowed);
                Assert.IsTrue(lots[i].IsOpen == tempLots[i].IsOpen);
                Assert.IsTrue(lots[i].Description == tempLots[i].Description);
                Assert.IsTrue(lots[i].CategoryName == tempLots[i].Category.Name);
            }
        }

        [TestMethod]
        public void GetTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            SearchService searchService = new SearchService(uow);

            Lot tempLot = uow.Lots.Get(1);

            LotDTO lot = searchService.Get(1);

            Assert.IsTrue(lot.Name == tempLot.Name);
            Assert.IsTrue(lot.StartPrice == tempLot.StartPrice);
            Assert.IsTrue(lot.CurrPrice == tempLot.CurrPrice);
            Assert.IsTrue(lot.BuyNowPrice == tempLot.BuyNowPrice);
            Assert.IsTrue(lot.IsAllowed == tempLot.IsAllowed);
            Assert.IsTrue(lot.IsOpen == tempLot.IsOpen);
            Assert.IsTrue(lot.Description == tempLot.Description);
            Assert.IsTrue(lot.CategoryName == tempLot.Category.Name);
        }

        [TestMethod]
        public void GetTestException1()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            SearchService searchService = new SearchService(uow);

            Assert.ThrowsException<ValidationException>(() => searchService.Get(null));
        }

        [TestMethod]
        public void GetTestException2()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            SearchService searchService = new SearchService(uow);

            Assert.ThrowsException<ItemNotFoundException>(() => searchService.Get(uow.Lots.GetAll().Count() + 1));
        }

        [TestMethod]
        public void FindByWordTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            SearchService searchService = new SearchService(uow);

            string keyWord = "word";

            Lot tempLot = uow.Lots.Find(x => x.Name.Contains(keyWord)).FirstOrDefault();

            LotDTO lot = searchService.FindByWord(keyWord).FirstOrDefault();

            Assert.IsTrue(lot.Name == tempLot.Name);
            Assert.IsTrue(lot.StartPrice == tempLot.StartPrice);
            Assert.IsTrue(lot.CurrPrice == tempLot.CurrPrice);
            Assert.IsTrue(lot.BuyNowPrice == tempLot.BuyNowPrice);
            Assert.IsTrue(lot.IsAllowed == tempLot.IsAllowed);
            Assert.IsTrue(lot.IsOpen == tempLot.IsOpen);
            Assert.IsTrue(lot.Description == tempLot.Description);
            Assert.IsTrue(lot.CategoryName == tempLot.Category.Name);
        }

        [TestMethod]
        public void FindByCategoryTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            SearchService service = new SearchService(uow);

            List<Lot> tempLots = new List<Lot>();

            Category parrentCategory = new Category()
            {
                Id = uow.Categories.GetAll().Count() + 1,
                Name = "Equipment",
                Categories = new List<Category>()
            };

            Category category1 = new Category()
            {
                Id = uow.Categories.GetAll().Count() + 2,
                Name = "Things",
                ParrentCategory = parrentCategory,
                ParrentCategoryId = parrentCategory.Id,
                Categories = new List<Category>()
            };

            
            Category category2 = new Category()
            {
                Id = uow.Categories.GetAll().Count() + 3,
                Name = "Ozimayi",
                ParrentCategory = parrentCategory,
                ParrentCategoryId = parrentCategory.Id,
                Categories = new List<Category>()
            };

            parrentCategory.Categories.Add(category1);
            parrentCategory.Categories.Add(category2);

            uow.Categories.Create(parrentCategory);
            uow.Categories.Create(category1);
            uow.Categories.Create(category2);

            
            Lot lot = new Lot()
            {
                Name = "Test Ozimay",
                StartPrice = 100,
                CurrPrice = 100,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = category1.Id,
                Category = category1
            };
            uow.Lots.Create(lot);
            tempLots.Add(lot);

            lot = new Lot()
            {
                Name = "Test Hammers",
                StartPrice = 100,
                CurrPrice = 100,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = category2.Id,
                Category = category2
            };
            uow.Lots.Create(lot);
            tempLots.Add(lot);

            List<LotDTO> lots = service.FindByCategory(parrentCategory.Id).ToList();

            for (int i = 0; i < lots.Count; i++)
            {
                Assert.IsTrue(lots[i].Name == tempLots[i].Name);
                Assert.IsTrue(lots[i].StartPrice == tempLots[i].StartPrice);
                Assert.IsTrue(lots[i].CurrPrice == tempLots[i].CurrPrice);
                Assert.IsTrue(lots[i].BuyNowPrice == tempLots[i].BuyNowPrice);
                Assert.IsTrue(lots[i].IsAllowed == tempLots[i].IsAllowed);
                Assert.IsTrue(lots[i].IsOpen == tempLots[i].IsOpen);
                Assert.IsTrue(lots[i].Description == tempLots[i].Description);
                Assert.IsTrue(lots[i].CategoryName == tempLots[i].Category.Name);
            }
        }

        [TestMethod]
        public void SearchServiceTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            SearchService service = new SearchService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();
            List<Lot> tempLots = new List<Lot>();

            Lot tempLot = new Lot()
            {
                Name = "Test Ozimay",
                StartPrice = 4,
                CurrPrice = 4,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = category.Id,
                Category = category
            };
            tempLots.Add(tempLot);
            uow.Lots.Create(tempLot);

            tempLot = new Lot()
            {
                Name = "Test Ozimay",
                StartPrice = 10,
                CurrPrice = 10,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = category.Id,
                Category = category
            };
            tempLots.Add(tempLot);
            uow.Lots.Create(tempLot);


            List<LotDTO> lots = service.FindByPrice(tempLot.CurrPrice).ToList();

            for (int i = 0; i < lots.Count; i++)
            {
                Assert.IsTrue(lots[i].Name == tempLots[i].Name);
                Assert.IsTrue(lots[i].StartPrice == tempLots[i].StartPrice);
                Assert.IsTrue(lots[i].CurrPrice == tempLots[i].CurrPrice);
                Assert.IsTrue(lots[i].BuyNowPrice == tempLots[i].BuyNowPrice);
                Assert.IsTrue(lots[i].IsAllowed == tempLots[i].IsAllowed);
                Assert.IsTrue(lots[i].IsOpen == tempLots[i].IsOpen);
                Assert.IsTrue(lots[i].Description == tempLots[i].Description);
                Assert.IsTrue(lots[i].CategoryName == tempLots[i].Category.Name);
            }
        }
    }
}
