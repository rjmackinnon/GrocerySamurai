namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Model.Common;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Controllers;

    [TestFixture]
    public abstract class BaseControllerTest<T>
        where T : Entity, new()
    {
        private Mock<IBaseProcess<T>> _baseProcessMock;
        private T _newRecord;
        private T _modifiedRecord;

        protected BaseController<T> controller { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        protected List<T> data { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        [SetUp]
        public virtual void Setup()
        {
            setupData();
            _baseProcessMock = new Mock<IBaseProcess<T>>();
            _baseProcessMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(data));
            controller.BusinessProcess = _baseProcessMock.Object;
        }

        protected async Task getTestHelper()
        {
            const int id = 1001;
            _baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(Task.FromResult(data.FirstOrDefault(x => x.Id == id)));

            var results = await controller.Get(id).ConfigureAwait(false);

            var resultData = results as OkObjectResult;

            _baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
        }

        protected async Task getNullTestHelper()
        {
            const int id = 2001;
            _baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(Task.FromResult(data.FirstOrDefault(x => x.Id == id)));

            var results = await controller.Get(id).ConfigureAwait(false);

            var resultData = results as OkObjectResult;

            _baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
            Assert.IsNull(resultData.Value);
        }

        protected async Task getExceptionTestHelper()
        {
            const int id = 2001;
            _baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Throws(new Exception("Test Exception"));

            var results = await controller.Get(id).ConfigureAwait(false);
            var resultData = results as ObjectResult;

            _baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected virtual async Task getAllDefaultsTestHelper()
        {
            var results = await controller.GetAll().ConfigureAwait(false);

            var resultData = results as OkObjectResult;

            _baseProcessMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected virtual async Task getAllPageSizeTestHelper()
        {
            const int pageSize = 2;
            var results = controller.GetAll(null, pageSize);

            var resultData = await results.ConfigureAwait(false) as OkObjectResult;

            _baseProcessMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected virtual async Task getAllExceptionTestHelper()
        {
            _baseProcessMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Throws(new Exception("Test Exception"));

            var results = await controller.GetAll().ConfigureAwait(false);
            var resultData = results as ObjectResult;

            _baseProcessMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<T, object>>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task addTestHelper()
        {
            _baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(1));

            var results = await controller.Add(_newRecord).ConfigureAwait(false);
            var resultData = results as CreatedAtRouteResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual(_newRecord, resultData.Value);
        }

        protected async Task addNotInsertedTestHelper()
        {
            _baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(0));

            var results = await controller.Add(_newRecord).ConfigureAwait(false);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was inserted.", resultData.Value);
        }

        protected async Task addExceptionTestHelper()
        {
            _baseProcessMock.Setup(x => x.AddRecord(_newRecord)).Throws(new Exception(@"Test Exception"));

            var results = await controller.Add(_newRecord).ConfigureAwait(false);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task updateTestHelper()
        {
            _baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(1));

            var results = await controller.Update(_modifiedRecord).ConfigureAwait(false);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully updated.", resultData.Value);
        }

        protected async Task updateNotUpdatedTestHelper()
        {
            _baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(0));

            var results = await controller.Update(_modifiedRecord).ConfigureAwait(false);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was updated.", resultData.Value);
        }

        protected async Task updateExceptionTestHelper()
        {
            _baseProcessMock.Setup(x => x.UpdateRecord(_modifiedRecord)).Throws(new Exception(@"Test Exception"));

            var results = await controller.Update(_modifiedRecord).ConfigureAwait(false);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected async Task deleteTestHelper()
        {
            const int id = 1001;
            _baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(1));

            var results = await controller.Delete(id).ConfigureAwait(false);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully deleted.", resultData.Value);
        }

        protected async Task deleteNotDeletedTestHelper()
        {
            const int id = 1001;
            _baseProcessMock.Setup(x => x.Save()).Returns(Task.FromResult(0));

            var results = await controller.Delete(id).ConfigureAwait(false);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was deleted.", resultData.Value);
        }

        protected async Task deleteExceptionTestHelper()
        {
            const int id = 1001;
            _baseProcessMock.Setup(x => x.DeleteRecord(id)).Throws(new Exception(@"Test Exception"));

            var results = await controller.Delete(id).ConfigureAwait(false);
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
                    Id = 1001
                },
                new T
                {
                    Id = 1002
                },
                new T
                {
                    Id = 1003
                },
                new T
                {
                    Id = 1004
                },
                new T
                {
                    Id = 1005
                }
            };

            _newRecord = new T
            {
                Id = 5001
            };

            _modifiedRecord = new T
            {
                Id = 1001
            };
        }
    }
}
