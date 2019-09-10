using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System;
using BLL.Infrastructure.Exceptions;

namespace BLL.Services
{
    public class SearchService : ISearchService
    {
        IUnitOfWork Database { get; set; }

        public SearchService(IUnitOfWork uow)
        {
            Database = uow;
           
        }


        #region Services without using
        public IEnumerable<LotDTO> GetAll()
        {
           var mapper =  new MapperConfiguration(cfg =>

              cfg.CreateMap<Lot, LotDTO>().ForMember("CategoryName", opt => opt.MapFrom(lot => lot.Category.Name)));
            return mapper.CreateMapper().Map<IEnumerable<Lot>, List<LotDTO>>(Database.Lots.GetAll());
        }

        public LotDTO Get(int? id)
        {
            var mapper = new MapperConfiguration(cfg =>

              cfg.CreateMap<Lot, LotDTO>().ForMember("CategoryName", opt => opt.MapFrom(lots => lots.Category.Name))

         );
            if (id == null)
                throw new ValidationException("Не установлено id лота");
            var lot = Database.Lots.Get(id.Value);
            if (lot == null)
                throw new ItemNotFoundException("Лот не найден");
            return mapper.CreateMapper().Map<Lot, LotDTO>(lot);
        }

        public IEnumerable<LotDTO> FindByWord(string word)
        {
            var mapper =  new MapperConfiguration(cfg =>

              cfg.CreateMap<Lot, LotDTO>().ForMember("CategoryName", opt => opt.MapFrom(lot => lot.Category.Name))

         );
            var foundLots = Database.Lots.Find(x => x.Name.Contains(word));
            return mapper.CreateMapper().Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(foundLots);
        }

        public IEnumerable<LotDTO> FindByCategory(int category)
        {
            var mapper =  new MapperConfiguration(cfg =>
            
                cfg.CreateMap<Lot, LotDTO>().ForMember("CategoryName", opt=> opt.MapFrom(lot=>lot.Category.Name))

            );
            var foundLots = RecursFind(category).ToList();
            return mapper.CreateMapper().Map<List<Lot>,List<LotDTO>>(foundLots);
        }

        private IEnumerable<Lot> RecursFind(int id)
        {
            Category category = Database.Categories.Get(id);
            List<Lot> res = new List<Lot>();
            IEnumerable<Lot> lots = Database.Lots.Find(x => x.CategoryId == id);

            if (lots != null)
            {
                res.AddRange(lots);
            }
            for (int i = 0; i < category.Categories.Count; i++)
            {
                IEnumerable<Lot> lotsRecurs = RecursFind(category.Categories[i].Id);
                res.AddRange(lotsRecurs);
            }

            return res;
        }

        public IEnumerable<LotDTO> FindByPrice(decimal price)
        {

            var mapper =  new MapperConfiguration(cfg =>

              cfg.CreateMap<Lot, LotDTO>().ForMember("CategoryName", opt => opt.MapFrom(lot => lot.Category.Name))

         );
            var lots = Database.Lots.Find(x => x.CurrPrice <= price);

            return mapper.CreateMapper().Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(lots);
        }
        #endregion
    }
}
