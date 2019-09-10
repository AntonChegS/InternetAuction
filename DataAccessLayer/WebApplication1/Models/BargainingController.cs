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
        [HttpPut]
        [BargainingExceptionFilter]
        [ValidationExceptionFilter]
        public string PlaceBet(BetModel betModel)
        {
          var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BetModel, BetDTO>()).CreateMapper();
          var bet = Mapper.Map<BetModel, BetDTO>(betModel);
          return service.PlaceBet(bet);
        }

        [Route("api/bargaining/buy")]
        [HttpPut]
        [BargainingExceptionFilter]
        [ValidationExceptionFilter]
        public string BuyNow(int lotID)
        {
             return service.BuyNow(lotID);
        }
    }
}