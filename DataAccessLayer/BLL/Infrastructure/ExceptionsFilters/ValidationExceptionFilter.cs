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
   public class ValidationExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if(context.Exception is ValidationException)
            {
               var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
               {
                   Content = new StringContent(context.Exception.Message),
                   ReasonPhrase = "InputedDataNotValid"
               };
               throw new HttpResponseException(resp);
            }
        }
    }
}
