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
using Exceptions;

namespace tests.UnitTests.Web.Filters
{
    [TestClass]
    public class ExceptionFilterTest
    {
        private string _errorMessage = "error";

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

        [TestMethod]
        public void ThrowInvalidAttributeValuesException()
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
                Exception = new InvalidAttributeValuesException(_errorMessage),
            };

            var exceptionFilter = new ExceptionFilter();
            exceptionFilter.OnException(exceptionContext);

            var contentResult = exceptionContext.Result as ContentResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }


        [TestMethod]
        public void ThrowNotFoundException()
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
                Exception = new NotFoundException(_errorMessage),
            };

            var exceptionFilter = new ExceptionFilter();
            exceptionFilter.OnException(exceptionContext);

            var contentResult = exceptionContext.Result as ContentResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, contentResult.StatusCode);
        }

        [TestMethod]
        public void ThrowObjectAlreadyExistException()
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
                Exception = new ObjectAlreadyExistException(_errorMessage),
            };

            var exceptionFilter = new ExceptionFilter();
            exceptionFilter.OnException(exceptionContext);

            var contentResult = exceptionContext.Result as ContentResult;

            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }
    }
}
