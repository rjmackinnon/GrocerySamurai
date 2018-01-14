using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common
{
    public abstract class BaseUserFilterControllerTest<T> : BaseControllerTest<T>
        where T : UserFilter, new()
    {
        protected Mock<IBaseUserFilterProcess<T>> baseUserFilterProcessMock;

        public override void Setup()
        {
            base.Setup();
            baseUserFilterProcessMock = new Mock<IBaseUserFilterProcess<T>>();
            baseUserFilterProcessMock.Setup(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(data));
        }

        protected override async Task getAllDefaultsTestHelper()
        {
            controller.BusinessProcess = baseUserFilterProcessMock.Object;
            var results = await controller.GetAll("test");

            var resultData = results as OkObjectResult;

            baseUserFilterProcessMock.Verify(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected override async Task getAllPageSizeTestHelper()
        {
            controller.BusinessProcess = baseUserFilterProcessMock.Object;
            const int pageSize = 2;
            var results = await controller.GetAll("test", pageSize);

            var resultData = results as OkObjectResult;

            baseUserFilterProcessMock.Verify(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected override async Task getAllExceptionTestHelper()
        {
            controller.BusinessProcess = baseUserFilterProcessMock.Object;
            baseUserFilterProcessMock.Setup(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Throws(new Exception("Test Exception"));

            var results = await controller.GetAll("test");
            var resultData = results as ObjectResult;

            baseUserFilterProcessMock.Verify(x => x.GetAllByUser(It.IsAny<string>(), It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task getAllNoUserTestHelper()
        {
            controller.BusinessProcess = baseUserFilterProcessMock.Object;
            var results = await controller.GetAll();

            var resultData = results as BadRequestObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual("Please include a valid userId.", resultData.Value);
        }
    }
}
