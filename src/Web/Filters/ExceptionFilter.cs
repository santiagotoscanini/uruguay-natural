using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch(Exception)
            {
                context.Result = new ContentResult
                {
                    StatusCode = (int) HttpStatusCode.InternalServerError,
                    Content = "Internal server error."
                };
            }
        }
    }
}
