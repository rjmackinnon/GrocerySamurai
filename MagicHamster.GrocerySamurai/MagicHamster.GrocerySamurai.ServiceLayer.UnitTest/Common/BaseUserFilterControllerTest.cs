namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Common;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;

    public abstract class BaseUserFilterControllerTest<T> : BaseControllerTest<T>
        where T : UserFilter, new()
    {
        private Mock<IBaseUserFilterProcess<T>> _baseUserFilterProcessMock;

        public override void Setup()
        {
            base.Setup();
            _baseUserFilterProcessMock = new Mock<IBaseUserFilterProcess<T>>();
            _baseUserFilterProcessMock.Setup(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(data));
        }

        protected override async Task getAllDefaultsTestHelper()
        {
            controller.BusinessProcess = _baseUserFilterProcessMock.Object;
            var results = await controller.GetAll("test").ConfigureAwait(false);

            var resultData = results as OkObjectResult;

            _baseUserFilterProcessMock.Verify(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected override async Task getAllPageSizeTestHelper()
        {
            controller.BusinessProcess = _baseUserFilterProcessMock.Object;
            const int pageSize = 2;
            var results = await controller.GetAll("test", pageSize).ConfigureAwait(false);

            var resultData = results as OkObjectResult;

            _baseUserFilterProcessMock.Verify(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected override async Task getAllExceptionTestHelper()
        {
            controller.BusinessProcess = _baseUserFilterProcessMock.Object;
            _baseUserFilterProcessMock.Setup(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Throws(new Exception("Test Exception"));

            var results = await controller.GetAll("test").ConfigureAwait(false);
            var resultData = results as ObjectResult;

            _baseUserFilterProcessMock.Verify(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task getAllNoUserTestHelper()
        {
            controller.BusinessProcess = _baseUserFilterProcessMock.Object;
            var results = await controller.GetAll().ConfigureAwait(false);

            var resultData = results as BadRequestObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual("Please include a valid userId.", resultData.Value);
        }
    }
}
