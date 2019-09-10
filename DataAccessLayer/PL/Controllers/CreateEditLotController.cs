using BLL.Interfaces;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PL.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure.ExceptionsFilters;
using BLL.Infrastructure.Exceptions;


namespace PL.Controllers
{
    public class CreateEditLotController : ApiController
    {

        ICreateEditService service;
        public CreateEditLotController(ICreateEditService service)
        {
             this.service = service;

        }
        [Route("api/createlot/create")]
        [HttpPost]
        [ValidationExceptionFilter,ItemNotFoundExceptionfilterAttribute]
        public IHttpActionResult CreateLot(LotCreatingModel lotModel)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Model non valid");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotCreatingModel, LotDTO>()
                                                  .ForMember("CurrPrice",x=>x.MapFrom(field=>field.StartPrice))).CreateMapper();
            var lot = mapper.Map<LotCreatingModel, LotDTO>(lotModel);
            lot.IsOpen = false;
            lot.IsAllowed = false;
            lot.CategoryName = "Other";
            service.CreateLot(lot);
            return Ok();
        }
        //TODO Lot editing
        [Route("api/editlot/edit")]
        [HttpPut]
        [ValidationExceptionFilter,ItemNotFoundExceptionfilterAttribute]
        public IHttpActionResult EditLot(LotView lotView)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Model non valid");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotView, LotDTO>()).CreateMapper();
            var lot = mapper.Map<LotView, LotDTO>(lotView);
            service.EditLot(lot);
            return Ok();
        }
    }
}