using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using BLL.Services;
using BLL.DTO;
using System.Linq;
using BLL.Infrastructure.Exceptions;

namespace UnitTests
{
    [TestClass]
    public class BargainingServiceTests
    {
        [TestMethod]
        public void BuyNowTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test Bargaining",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = true,
                IsOpen = true,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            service.BuyNow(lot.Id);

            lot = uow.Lots.Get(lot.Id);

            Assert.AreEqual(lot.IsOpen, false);
            Assert.AreEqual(lot.CurrPrice, lot.BuyNowPrice);
        }

        [TestMethod]
        public void BuyNowTestException1()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            int id = uow.Lots.GetAll().Count() + 1;

            Assert.ThrowsException<ItemNotFoundException>(() => service.BuyNow(id));
        }

        [TestMethod]
        public void BuyNowTestException2()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test Bargaining",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = true,
                IsOpen = false,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            Assert.ThrowsException<ValidationException>(() => service.BuyNow(lot.Id));
        }

        [TestMethod]
        public void PlaceBetTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test Bargaining",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = true,
                IsOpen = true,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            BetDTO bet = new BetDTO()
            {
                LotId = lot.Id,
                Price = uow.Lots.Get(lot.Id).CurrPrice + 100
            };

            service.PlaceBet(bet);

            Lot tempLot = uow.Lots.Get(lot.Id);

            Assert.AreEqual(tempLot.CurrPrice, bet.Price);
        }

        [TestMethod]
        public void PlaceBetTestException1()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            int lotId = uow.Lots.GetAll().Count() + 1;

            BetDTO bet = new BetDTO()
            {
                LotId = lotId,
                Price = 100
            };

            Assert.ThrowsException<ItemNotFoundException>(() => service.PlaceBet(bet));
        }

        [TestMethod]
        public void PlaceBetTestException2()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test Bargaining",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = false,
                IsOpen = true,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            BetDTO bet = new BetDTO()
            {
                LotId = lot.Id,
                Price = uow.Lots.Get(lot.Id).CurrPrice + 10
            };

            Assert.ThrowsException<ValidationException>(() => service.PlaceBet(bet));
        }

        [TestMethod]
        public void PlaceBetTestException3()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            BargainingService service = new BargainingService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test Bargaining",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = true,
                IsOpen = true,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            BetDTO bet = new BetDTO()
            {
                LotId = lot.Id,
                Price = uow.Lots.Get(lot.Id).CurrPrice - 10
            };

            Assert.ThrowsException<BargainingException>(() => service.PlaceBet(bet));
        }
    }
}
