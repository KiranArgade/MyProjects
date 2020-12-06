using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Inventory.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            HttpResponseMessage httpResponseMessage
                = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception);

            actionExecutedContext.Response = httpResponseMessage;

            //TODO : add logging logic to log exception to log file
        }
    }
}