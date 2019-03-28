
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebApi.Models;

namespace WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new ErrorModel(context.Exception));
        }

    }
}
