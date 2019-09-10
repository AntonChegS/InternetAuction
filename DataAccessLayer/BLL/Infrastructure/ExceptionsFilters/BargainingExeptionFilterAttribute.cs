using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using BLL.Infrastructure.Exceptions;

namespace BLL.Infrastructure.ExceptionsFilters
{
    public class BargainingExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is BargainingException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "WrongPriceInputed"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
