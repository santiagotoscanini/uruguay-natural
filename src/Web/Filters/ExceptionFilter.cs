using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mime;

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
                var statusCode = (int)HttpStatusCode.Conflict;
                var errorResponse = new ErrorResponse
                {
                    Status = statusCode,
                    Title = AlreadyExistTitleResponse,
                    Description = exception.Message,
                };

                context.Result = new ContentResult()
                {
                    StatusCode = statusCode,
                    ContentType = MediaTypeNames.Application.Json,
                    Content = JsonConvert.SerializeObject(errorResponse),
                };
            }
            catch (NotFoundException exception)
            {
                var statusCode = (int) HttpStatusCode.NotFound;
                var errorResponse = new ErrorResponse
                {
                    Status = statusCode,
                    Title = NotFoundTitleResponse,
                    Description = exception.Message,
                };

                context.Result = new ContentResult()
                {
                    StatusCode = statusCode,
                    ContentType = MediaTypeNames.Application.Json,
                    Content = JsonConvert.SerializeObject(errorResponse),
                };
            }
            catch (InvalidAttributeValuesException exception)
            {
                var statusCode = (int) HttpStatusCode.BadRequest;
                var errorResponse = new ErrorResponse
                {
                    Status = statusCode,
                    Title = InvalidAttributeValuesTitleResponse,
                    Description = exception.Message,
                };

                context.Result = new ContentResult()
                {
                    StatusCode = statusCode,
                    ContentType = MediaTypeNames.Application.Json,
                    Content = JsonConvert.SerializeObject(errorResponse),
                };
            }
            catch (Exception)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var errorResponse = new ErrorResponse
                {
                    Status = statusCode,
                    Title = ServerErrorResponse,
                    Description = ServerErrorResponse,
                };
                context.Result = new ContentResult()
                {
                    StatusCode = statusCode,
                    ContentType = MediaTypeNames.Application.Json,
                    Content = JsonConvert.SerializeObject(errorResponse),
                };
            }
        }
    }
}
