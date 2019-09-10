using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Entities;
using BLL.Services;
using BLL.DTO;
using System.Linq;
using BLL.Infrastructure.Exceptions;

namespace UnitTests
{
    [TestClass]
    public class AllowDeclineServiceTests
    {
        [TestMethod]
        public void AllowLotTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            AllowDeclineService service = new AllowDeclineService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test AllowLot",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            service.AllowLot(lot.Id);

            lot = uow.Lots.Get(lot.Id);

            Assert.IsTrue(lot.IsAllowed);
            Assert.IsTrue(lot.IsOpen);
        }

        [TestMethod]
        public void AllowLotTestException1()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            AllowDeclineService service = new AllowDeclineService(uow);

            int id = uow.Lots.GetAll().Count() + 1;

            Assert.ThrowsException<ItemNotFoundException>(() => service.AllowLot(id));
        }

        [TestMethod]
        public void DeclineLotTest()
        {
            StubUnitOfWork uow = new StubUnitOfWork();
            AllowDeclineService service = new AllowDeclineService(uow);

            Category category = uow.Categories.GetAll().FirstOrDefault();

            Lot lot = new Lot()
            {
                Id = uow.Lots.GetAll().Count() + 1,
                Name = "Test AllowLot",
                StartPrice = 322,
                CurrPrice = 322,
                BuyNowPrice = 1337,
                IsAllowed = false,
                IsOpen = false,
                CategoryId = category.Id,
                Category = category,
                Description = "zxc"
            };

            uow.Lots.Create(lot);

            service.DeclineLot(lot.Id);

            lot = uow.Lots.Get(lot.Id);

            Assert.IsNull(lot);
        }
    }
}
