using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Session;
using Web.Filters;
using System.Collections.Generic;
using System.Net;
using System;

namespace tests.UnitTests.Web.Filters
{
    [TestClass]
    public class AuthorizationAttributeFilterTest
    {
        [TestMethod]
        public void UnauthorizedTest()
        {
            IHeaderDictionary headers = new HeaderDictionary { { "Authorization", "" } };
            Mock<HttpRequest> mockHttpRequest = new Mock<HttpRequest>();
            mockHttpRequest.Setup(r => r.Headers).Returns(headers);

            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(h => h.Request).Returns(mockHttpRequest.Object);

            var actionContext = new ActionContext
            {
                HttpContext = mockHttpContext.Object,
                RouteData = new Mock<RouteData>().Object,
                ActionDescriptor = new Mock<ActionDescriptor>().Object,
            };
            var context = new AuthorizationFilterContext(actionContext, new Mock<IList<IFilterMetadata>>().Object);
            var authFilter = new AuthorizationAttributeFilter(new Session.SessionService());


            authFilter.OnAuthorization(context);
            var contentResult = context.Result as ContentResult;


            Assert.AreEqual((int)HttpStatusCode.Unauthorized, contentResult.StatusCode);
        }

        [TestMethod]
        public void AuthorizedTest()
        {
            IDictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("userId", 1);

            IHeaderDictionary headers = new HeaderDictionary { { "Authorization", Guid.NewGuid().ToString() } };
            Mock<HttpRequest> mockHttpRequest = new Mock<HttpRequest>();
            mockHttpRequest.Setup(r => r.Headers).Returns(headers);

            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(h => h.Request).Returns(mockHttpRequest.Object);

            var actionContext = new ActionContext
            {
                HttpContext = mockHttpContext.Object,
                RouteData = new Mock<RouteData>().Object,
                ActionDescriptor = new Mock<ActionDescriptor>().Object,
            };
            ActionExecutingContext actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new Mock<IList<IFilterMetadata>>().Object,
                arguments,
                new Mock<object>().Object
            );

            var context = new AuthorizationFilterContext(actionExecutingContext, new Mock<IList<IFilterMetadata>>().Object);

            var authFilter = new AuthorizationAttributeFilter(new SessionService());
            
            
            authFilter.OnAuthorization(context);
            var contentResult = context.Result as ContentResult;


            Assert.IsNull(contentResult);
        }
    }
}
