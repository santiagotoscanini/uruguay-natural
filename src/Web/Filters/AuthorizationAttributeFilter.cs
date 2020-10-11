using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;
using System;
using System.Net;

namespace Web.Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        private readonly ISessionService _sessions;

        public AuthorizationAttributeFilter(ISessionService sessionLogic)
        {
            _sessions = sessionLogic;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];

            if(string.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult
                {
                    StatusCode = (int) HttpStatusCode.Unauthorized,
                    Content = "Send a token",
                };
            }
            else
            {
                if (!_sessions.IsCorrectToken(token))
                {
                    context.Result = new ContentResult
                    {
                        StatusCode = (int) HttpStatusCode.Forbidden,
                        Content = "Not enough permissions",
                    };
                }
            }
        }
    }
}
