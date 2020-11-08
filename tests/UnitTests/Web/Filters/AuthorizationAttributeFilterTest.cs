using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Filters;
using System.Collections.Generic;
using System.Net;
using SessionInterface;
using System;

namespace UnitTests.Web.Filters
{
    [TestClass]
    public class AuthorizationAttributeFilterTest
    {
        [TestMethod]
        public void NoTokenTest()
        {
            IHeaderDictionary headers = new HeaderDictionary { { "Authorization", "" } };
            Mock<HttpRequest> mockHttpRequest = new Mock<HttpRequest>();
            mockHttpRequest.Setup(r => r.Headers).Returns(headers);

            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(h => h.Request).Returns(mockHttpRequest.Object);

            Mock<ISessionService> mockSessionService = new Mock<ISessionService>();

            var actionContext = new ActionContext
            {
                HttpContext = mockHttpContext.Object,
                RouteData = new Mock<RouteData>().Object,
                ActionDescriptor = new Mock<ActionDescriptor>().Object,
            };
            var context = new AuthorizationFilterContext(actionContext, new Mock<IList<IFilterMetadata>>().Object);
            var authFilter = new AuthorizationAttributeFilter(mockSessionService.Object);


            authFilter.OnAuthorization(context);
            var contentResult = context.Result as ContentResult;

            mockHttpRequest.VerifyAll();
            mockHttpContext.VerifyAll();
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, contentResult.StatusCode);
        }

        [TestMethod]
        public void AuthorizedTest()
        {
            var token = Guid.NewGuid().ToString();

            IHeaderDictionary headers = new HeaderDictionary { { "Authorization", token } };
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

            Mock<ISessionService> mockSessionService = new Mock<ISessionService>();
            mockSessionService.Setup(s => s.IsCorrectToken(token)).Returns(true);

            var authFilter = new AuthorizationAttributeFilter(mockSessionService.Object);
            authFilter.OnAuthorization(context);
            var contentResult = context.Result as ContentResult;

            mockHttpRequest.VerifyAll();
            mockHttpContext.VerifyAll();
            mockSessionService.VerifyAll();
            Assert.IsNull(contentResult);
        }

        [TestMethod]
        public void NotAuthorizedTest()
        {
            var token = Guid.NewGuid().ToString();

            IHeaderDictionary headers = new HeaderDictionary { { "Authorization", token } };
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

            Mock<ISessionService> mockSessionService = new Mock<ISessionService>();
            mockSessionService.Setup(s => s.IsCorrectToken(token)).Returns(false);

            var authFilter = new AuthorizationAttributeFilter(mockSessionService.Object);
            authFilter.OnAuthorization(context);
            var contentResult = context.Result as ContentResult;


            mockHttpRequest.VerifyAll();
            mockHttpContext.VerifyAll();
            mockSessionService.VerifyAll();
            Assert.AreEqual((int) HttpStatusCode.Forbidden, contentResult.StatusCode);
        }
    }
}
