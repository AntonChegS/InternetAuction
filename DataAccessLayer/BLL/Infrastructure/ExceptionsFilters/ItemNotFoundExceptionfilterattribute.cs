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
    public class ItemNotFoundExceptionfilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ItemNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ItemNotFound"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
