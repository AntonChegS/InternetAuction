using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure.Exceptions;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BLL.Services
{
   public  class CreateEditService : ICreateEditService
    {
        IUnitOfWork Database { get; set; }
       
        public CreateEditService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateLot(LotDTO lot) {

            using (Database)
            {
                if (lot.StartPrice > lot.BuyNowPrice)
                {
                    throw new ValidationException("Start price cant be higher than buy now price");
                }

                Category categoryField = Database.Categories.Find(x => x.Name == lot.CategoryName).FirstOrDefault();
                if (categoryField == null)
                {
                    throw new ItemNotFoundException("Category doesnt exist");
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, Lot>());
                Lot tmpLot = mapper.CreateMapper().Map<LotDTO, Lot>(lot);

                tmpLot.CategoryId = categoryField.Id;
                tmpLot.Category = categoryField;

                Database.Lots.Create(tmpLot);
                Database.Save();
            }
        }
        //TODO

        public void EditLot(LotDTO lot)
        {

            using (Database)
            {

                Category categoryField = Database.Categories.Find(x => x.Name == lot.CategoryName).FirstOrDefault();

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, Lot>());

                Lot tmpLot = mapper.CreateMapper().Map<LotDTO, Lot>(lot);

                tmpLot.Category = categoryField;

                Database.Lots.Update(tmpLot);
                Database.Save();
            }

        }

    }
}
