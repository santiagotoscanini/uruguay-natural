using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SessionInterface;
using System;
using System.Net;

namespace Web.Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        private readonly ISessionService _sessions;

        private const string ContentTypeJson = "application/json";
        private const string UnautorizedTitleResponse = "The requested resource requires authentication";
        private const string UnautorizedDescriptionResponse = "Send a token";
        private const string ForbiddenTitleResponse = "The requested resource is forbidden";
        private const string ForbiddenDescriptionResponse = "Not enough permissions";

        public AuthorizationAttributeFilter(ISessionService sessionLogic)
        {
            _sessions = sessionLogic;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];

            if(string.IsNullOrEmpty(token))
            {
                var statusCode = (int)HttpStatusCode.Unauthorized;
                var errorResponse = new ErrorResponse
                {
                    Status = statusCode,
                    Title = UnautorizedTitleResponse,
                    Description = UnautorizedDescriptionResponse,
                };
                context.Result = new ContentResult
                {
                    StatusCode = statusCode,
                    ContentType = ContentTypeJson,
                    Content = JsonConvert.SerializeObject(errorResponse),
                };
            }
            else
            {
                if (!_sessions.IsCorrectToken(token))
                {
                    var statusCode = (int)HttpStatusCode.Forbidden;
                    var errorResponse = new ErrorResponse
                    {
                        Status = statusCode,
                        Title = ForbiddenTitleResponse,
                        Description = ForbiddenDescriptionResponse,
                    };
                    context.Result = new ContentResult
                    {
                        StatusCode = statusCode,
                        ContentType = ContentTypeJson,
                        Content = JsonConvert.SerializeObject(errorResponse),
                    };
                }
            }
        }
    }
}
