using BLL.Interfaces;
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

namespace PL.Controllers
{
    public class BargainingController : ApiController
    {

        IBargainingService service;

        public BargainingController(IBargainingService service)
        {
            this.service = service;
        }
        [Route("api/bargaining/bet")]
        [HttpPost]
        [BargainingExceptionFilter, ValidationExceptionFilter]
        public IHttpActionResult PlaceBet(BetModel betModel)
        {
          var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BetModel, BetDTO>()).CreateMapper();
          var bet = mapper.Map<BetModel, BetDTO>(betModel);
          service.PlaceBet(bet);
          return Ok();
        }

        [Route("api/bargaining/buy")]
        [HttpPost]
        [BargainingExceptionFilter,  ValidationExceptionFilter]
        public IHttpActionResult BuyNow(BuyNowModel model)
        {
            service.BuyNow(model.LotId);
            return Ok();
        }
    }
}