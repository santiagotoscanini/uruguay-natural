using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;
using System;
using System.Net;

namespace Web.Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        private readonly ISessionService _sessions;
        
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
                context.Result = ContentResultForErrorsHelper.GetContentResultByStatus(HttpStatusCode.Unauthorized, UnautorizedTitleResponse, UnautorizedDescriptionResponse);
            }
            else
            {
                if (!_sessions.IsCorrectToken(token))
                {
                    context.Result = ContentResultForErrorsHelper.GetContentResultByStatus(HttpStatusCode.Forbidden, ForbiddenTitleResponse, ForbiddenDescriptionResponse);
                }
            }
        }
    }
}
