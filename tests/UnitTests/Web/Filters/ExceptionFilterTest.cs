using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Web.Filters;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Net;

namespace tests.UnitTests.Web.Filters
{
    [TestClass]
    public class ExceptionFilterTest
    {
        [TestMethod]
        public void ThrowException()
        {
            var actionContext = new ActionContext
            {
                HttpContext = new Mock<HttpContext>().Object,
                RouteData = new Mock<RouteData>().Object,
                ActionDescriptor = new Mock<ActionDescriptor>().Object,
            };
            var filters = new Mock<IList<IFilterMetadata>>(MockBehavior.Strict);
            var exceptionContext = new ExceptionContext(actionContext, filters.Object)
            {
                Exception = new NotImplementedException()
            };

            var exceptionFilter= new ExceptionFilter();
            exceptionFilter.OnException(exceptionContext);

            var contentResult = exceptionContext.Result as ContentResult;
            Assert.AreEqual((int) HttpStatusCode.InternalServerError, contentResult.StatusCode);
        }
    } 
}
