using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PL.Models;
using BLL.DTO;
using AutoMapper;
using BLL.Services;
using DataAccessLayer.Repositories;

namespace PL.Controllers
{
    public class SearchLotController : ApiController
    {
        ISearchService service;

     
        public SearchLotController(ISearchService service)
        {
            this.service = service;
          
        }

        [Route("api/searchlot/lotsByWord")]
        [HttpGet]
        public IEnumerable<LotView> FindByWord(string word)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, LotView>()).CreateMapper();
                IEnumerable<LotDTO> lots = service.FindByWord(word);
                return mapper.Map<IEnumerable<LotDTO>, IEnumerable<LotView>>(lots);
            }
            catch(Exception)
            {
                return null;
            }

        }
        [Route("api/searchlot/lotsByCategory")]
        [HttpGet]
        public IEnumerable<LotView> FindByCategory(CategoryView category)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<LotDTO, LotView>();
                    cfg.CreateMap<CategoryView, CategoryDTO>(); }).CreateMapper();
                CategoryDTO categoryDTO = mapper.Map<CategoryView, CategoryDTO>(category);
                IEnumerable<LotDTO> lots = service.FindByCategory(categoryDTO.Id);
                return mapper.Map<IEnumerable<LotDTO>, IEnumerable<LotView>>(lots);
            }
             catch(Exception)
            {
                return null;
            }
}
        [Route("api/searchlot/lot")]
        [HttpGet]
        public LotView Get(int id)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, LotView>()).CreateMapper();
                LotView lotView = mapper.Map<LotDTO, LotView>(service.Get(id));
                return lotView;
            }
             catch(Exception)
            {
                return null;
            }
}
        // GET api/SearchLot
        [Route("api/searchlot/lots")]
       [HttpGet]
        public IEnumerable<LotView> Get()
        {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, LotView>()).CreateMapper();


            return mapper.Map<IEnumerable<LotDTO>, IEnumerable<LotView>>(service.GetAll());
           
            
           
        }
        [Route("api/searchlot/lotsByPrice")]
        [HttpGet]
        public IEnumerable<LotView> FindByPrice(decimal price)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotDTO, LotView>()).CreateMapper();
                IEnumerable<LotView> lots = mapper.Map<IEnumerable<LotDTO>, IEnumerable<LotView>>(service.FindByPrice(price));
                return lots;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}