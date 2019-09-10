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
        [ValidationExceptionFilter]
        public IHttpActionResult CreateLot(LotView lotView)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Model non valid");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotView, LotDTO>()).CreateMapper();
            var lot = mapper.Map<LotView, LotDTO>(lotView);
            service.CreateLot(lot);
            return Ok();
        }

        [Route("api/editlot/edit")]
        [HttpPut]
        [ValidationExceptionFilter]
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