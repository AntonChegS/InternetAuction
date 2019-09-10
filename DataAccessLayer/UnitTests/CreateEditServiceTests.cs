using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BLL.Services;
using BLL.DTO;
using System.Linq;
using BLL.Infrastructure.Exceptions;

namespace UnitTests
{
    [TestClass]
    public class CreateEditServiceTests
    {
        [TestMethod]
        public void CreateLotTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            CreateEditService createEditService = new CreateEditService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            LotDTO tempLot = new LotDTO()
            {
                Name = "Test Ozimay",
                StartPrice = 100,
                CurrPrice = 100,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryName = category.Name,
                Description = "qwe",
            };

            createEditService.CreateLot(tempLot);

            Lot lot = uow.Lots.Get(uow.Lots.GetAll().Count());

            Assert.IsTrue(lot.Name == tempLot.Name);
            Assert.IsTrue(lot.StartPrice == tempLot.StartPrice);
            Assert.IsTrue(lot.CurrPrice == tempLot.CurrPrice);
            Assert.IsTrue(lot.BuyNowPrice == tempLot.BuyNowPrice);
            Assert.IsTrue(lot.IsAllowed == tempLot.IsAllowed);
            Assert.IsTrue(lot.IsOpen == tempLot.IsOpen);
            Assert.IsTrue(lot.Description == tempLot.Description);
            Assert.IsTrue(lot.CategoryId == category.Id);
        }

        [TestMethod]
        public void CreateLotTestException1()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            CreateEditService createEditService = new CreateEditService(uow);

            LotDTO tempLot = new LotDTO()
            {
                Name = "Test Ozimay",
                StartPrice = 1000,
                CurrPrice = 100,
                BuyNowPrice = 100,
                IsAllowed = false,
                IsOpen = false,
                CategoryName = "wqqwd",
                Description = "qwe",
            };

            Assert.ThrowsException<ValidationException>(() => createEditService.CreateLot(tempLot));
        }

        [TestMethod]
        public void CreateLotTestException2()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            CreateEditService createEditService = new CreateEditService(uow);

            LotDTO tempLot = new LotDTO()
            {
                Name = "Test Ozimay",
                StartPrice = 100,
                CurrPrice = 100,
                BuyNowPrice = 1000,
                IsAllowed = false,
                IsOpen = false,
                CategoryName = "wqqwd",
                Description = "qwe",
            };

            Assert.ThrowsException<ItemNotFoundException>(() => createEditService.CreateLot(tempLot));
        }

        [TestMethod]
        public void EditLotTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();

            CreateEditService createEditService = new CreateEditService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();
            Lot lot = uow.Lots.GetAll().FirstOrDefault();

            LotDTO tempLot = new LotDTO()
            {
                Id = lot.Id,
                Name = "Test Update",
                StartPrice = 333,
                CurrPrice = 333,
                BuyNowPrice = 3333,
                IsAllowed = false,
                IsOpen = false,
                CategoryName = category.Name,
                Description = "qwe",
            };

            createEditService.EditLot(tempLot);

            lot = uow.Lots.Get(lot.Id);

            Assert.IsTrue(lot.Name == tempLot.Name);
            Assert.IsTrue(lot.StartPrice == tempLot.StartPrice);
            Assert.IsTrue(lot.CurrPrice == tempLot.CurrPrice);
            Assert.IsTrue(lot.BuyNowPrice == tempLot.BuyNowPrice);
            Assert.IsTrue(lot.IsAllowed == tempLot.IsAllowed);
            Assert.IsTrue(lot.IsOpen == tempLot.IsOpen);
            Assert.IsTrue(lot.Description == tempLot.Description);
            Assert.IsTrue(lot.Category.Name == tempLot.CategoryName);
        }
    }
}
