using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace Web.Filters
{
    public static class ContentResultForErrorsHelper
    {
        public static ContentResult GetContentResultByStatus(HttpStatusCode httpStatus, string title, string description)
        {
            int statusCode = (int)httpStatus;

            ErrorResponse errorResponse = GetErrorResponseFromStatusTitleAndDescription(statusCode, title, description);

            return new ContentResult
            {
                StatusCode = statusCode,
                ContentType = MediaTypeNames.Application.Json,
                Content = JsonConvert.SerializeObject(errorResponse),
            };
        }

        private static ErrorResponse GetErrorResponseFromStatusTitleAndDescription(int statusCode, string title, string description)
        {
            return new ErrorResponse()
            {
                Status = statusCode,
                Title = title,
                Description = description,
            };
        }
    }
}
