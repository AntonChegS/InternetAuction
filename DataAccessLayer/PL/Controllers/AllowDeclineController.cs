using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System.Web.Http;
using BLL.Infrastructure.ExceptionsFilters;
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
        [HttpPost]
        [ItemNotFoundExceptionfilterAttribute]
        public IHttpActionResult AllowLot(AllowModel allow)
            {
            service.AllowLot(allow.LotId);
            return Ok();
        }

        [Route("api/bargaining/decline")]
        [HttpPut]
        [ItemNotFoundExceptionfilterAttribute]
        public IHttpActionResult DeclineLot(int lotId)
        {
           service.DeclineLot(lotId);
           return Ok();
        }
    }
}