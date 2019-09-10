using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System.Web.Http;
using BLL.DTO;
using PL.Models;

namespace PL.Controllers
{
    public class AllowDeclineController : ApiController
    {
        IAllowDeclineService service;

        public AllowDeclineController(IAllowDeclineService service)
        {
                this.service = service;
        }

        [Route("api/bargaining/allow")]
        [HttpPut]
        public string AllowLot(LotView lot)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotView, LotDTO>()).CreateMapper();
            LotDTO lotDTO = mapper.Map<LotView, LotDTO>(lot);
            return service.AllowLot(lotDTO);
        }

        [Route("api/bargaining/decline")]
        [HttpPut]
        public string DeclineLot(LotView lot)
        {
           var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LotView, LotDTO>()).CreateMapper();
           LotDTO lotDTO = mapper.Map<LotView, LotDTO>(lot);
           return service.DeclineLot(lotDTO);
        }
    }
}