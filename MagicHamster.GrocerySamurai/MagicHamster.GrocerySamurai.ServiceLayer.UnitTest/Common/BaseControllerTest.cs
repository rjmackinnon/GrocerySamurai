using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common
{
    [TestFixture]
    public abstract class BaseControllerTest<T>
        where T : Entity, new()
    {
        protected BaseController<T> controller;
        protected Mock<IBaseProcess<T>> baseProcessMock;
        protected List<T> data;
        private T _newRecord;
        private T _modifiedRecord;

        [SetUp]
        public virtual void Setup()
        {
            setupData();
            baseProcessMock = new Mock<IBaseProcess<T>>();
            baseProcessMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(data));
            controller.BusinessProcess = baseProcessMock.Object;
        }

        protected async Task getTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(Task.FromResult(data.FirstOrDefault(x => x.Id == id)));

            var results = await controller.Get(id);

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
        }

        protected async Task getNullTestHelper()
        {
            var id = 2001;
            baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(Task.FromResult(data.FirstOrDefault(x => x.Id == id)));

            var results = await controller.Get(id);

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
            Assert.IsNull(resultData.Value);
        }

        protected async Task getExceptionTestHelper()
        {
            var id = 2001;
            baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Throws(new Exception("Test Exception"));

            var results = await controller.Get(id);
            var resultData = results as ObjectResult;

            baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected virtual async Task getAllDefaultsTestHelper()
        {
            var results = await controller.GetAll();

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected virtual async Task getAllPageSizeTestHelper()
        {
            const int pageSize = 2;
            var results = controller.GetAll(null, pageSize);

            var resultData = await results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected virtual async Task getAllExceptionTestHelper()
        {
            baseProcessMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Throws(new Exception("Test Exception"));

            var results = await controller.GetAll();
            var resultData = results as ObjectResult;

            baseProcessMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task addTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(1));

            var results = await controller.Add(_newRecord);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully inserted.", resultData.Value);
        }

        protected async Task addNotInsertedTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(0));

            var results = await controller.Add(_newRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was inserted.", resultData.Value);
        }

        protected async Task addExceptionTestHelper()
        {
            baseProcessMock.Setup(x => x.AddRecord(_newRecord)).Throws(new Exception(@"Test Exception"));

            var results = await controller.Add(_newRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task updateTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(1));

            var results = await controller.Update(_modifiedRecord);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully updated.", resultData.Value);
        }

        protected async Task updateNotUpdatedTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(0));

            var results = await controller.Update(_modifiedRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was updated.", resultData.Value);
        }

        protected async Task updateExceptionTestHelper()
        {
            baseProcessMock.Setup(x => x.UpdateRecord(_modifiedRecord)).Throws(new Exception(@"Test Exception"));

            var results = await controller.Update(_modifiedRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task deleteTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(1));

            var results = await controller.Delete(id);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully deleted.", resultData.Value);
        }

        protected async Task deleteNotDeletedTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(0));

            var results = await controller.Delete(id);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was deleted.", resultData.Value);
        }

        protected async Task deleteExceptionTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.DeleteRecord(id)).Throws(new Exception(@"Test Exception"));

            var results = await controller.Delete(id);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        private void setupData()
        {
            data = new List<T>
            {
                new T
                {
                    Id = 1001,
                },
                new T
                {
                    Id = 1002,
                },
                new T
                {
                    Id = 1003,
                },
                new T
                {
                    Id = 1004,
                },
                new T
                {
                    Id = 1005,
                }
            };


            _newRecord = new T
            {
                Id = 5001,
            };

            _modifiedRecord = new T
            {
                Id = 1001,
            };
        }
    }
}
