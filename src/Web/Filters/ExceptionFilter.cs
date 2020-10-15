using Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Web.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        private const string AlreadyExistTitleResponse = "Request conflict with current state of the target resource";
        private const string NotFoundTitleResponse = "The requested object was not found";
        private const string InvalidAttributeValuesTitleResponse = "Server is unable to process the request";
        private const string ServerErrorResponse = "Internal Server Error";

        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (ObjectAlreadyExistException exception)
            {
                context.Result = ContentResultForErrorsHelper.GetContentResultByStatus(HttpStatusCode.BadRequest, AlreadyExistTitleResponse, exception.Message);
            }
            catch (NotFoundException exception)
            {
                context.Result = ContentResultForErrorsHelper.GetContentResultByStatus(HttpStatusCode.NotFound, NotFoundTitleResponse, exception.Message);
            }
            catch (InvalidAttributeValuesException exception)
            {
                context.Result = ContentResultForErrorsHelper.GetContentResultByStatus(HttpStatusCode.BadRequest, InvalidAttributeValuesTitleResponse, exception.Message);
            }
            catch (Exception)
            {
                context.Result = ContentResultForErrorsHelper.GetContentResultByStatus(HttpStatusCode.InternalServerError, ServerErrorResponse, ServerErrorResponse);
            }
        }
    }
}
