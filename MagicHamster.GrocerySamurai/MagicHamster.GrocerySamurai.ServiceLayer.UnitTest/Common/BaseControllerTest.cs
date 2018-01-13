using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private T newRecord;
        private T modifiedRecord;

        [SetUp]
        public virtual void Setup()
        {
            setupData();
            baseProcessMock = new Mock<IBaseProcess<T>>();
            baseProcessMock.Setup(x => x.GetAll(It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Returns(data);
            //var request = new Mock<HttpRequestMessage>();
            //var configuration = new Mock<HttpConfiguration>();
            //request.Object.SetConfiguration(configuration.Object);
            controller.BusinessProcess = baseProcessMock.Object;
            //controller.Request = request.Object;
        }

        protected void getTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(data.FirstOrDefault(x => x.Id == id));

            var results = controller.Get(id);

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
        }

        protected void getNullTestHelper()
        {
            var id = 2001;
            baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(data.FirstOrDefault(x => x.Id == id));

            var results = controller.Get(id);

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
            Assert.IsNull(resultData.Value);
        }

        protected void getExceptionTestHelper()
        {
            var id = 2001;
            baseProcessMock.Setup(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>())).Throws(new Exception("Test Exception"));

            var results = controller.Get(id);
            var resultData = results as ObjectResult;

            baseProcessMock.Verify(x => x.GetById(id, It.IsAny<List<string>>(), It.IsAny<bool>()));

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected virtual void getAllDefaultsTestHelper()
        {
            var results = controller.GetAll();

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetAll(It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected virtual void getAllPageSizeTestHelper()
        {
            const int pageSize = 2;
            var results = controller.GetAll(null, pageSize);

            var resultData = results as OkObjectResult;

            baseProcessMock.Verify(x => x.GetAll(It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
        }

        protected virtual void getAllExceptionTestHelper()
        {
            baseProcessMock.Setup(x => x.GetAll(It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Throws(new Exception("Test Exception"));

            var results = controller.GetAll();
            var resultData = results as ObjectResult;

            baseProcessMock.Verify(x => x.GetAll(It.IsAny<Func<T, object>>(), It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected void addTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(1);

            var results = controller.Add(newRecord);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully inserted.", resultData.Value);
        }

        protected void addNotInsertedTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(0);

            var results = controller.Add(newRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was inserted.", resultData.Value);
        }

        protected void addExceptionTestHelper()
        {
            baseProcessMock.Setup(x => x.AddRecord(newRecord)).Throws(new Exception(@"Test Exception"));

            var results = controller.Add(newRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected void updateTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(1);

            var results = controller.Update(modifiedRecord);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully updated.", resultData.Value);
        }

        protected void updateNotUpdatedTestHelper()
        {
            baseProcessMock.Setup(x => x.Save()).Returns(0);

            var results = controller.Update(modifiedRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was updated.", resultData.Value);
        }

        protected void updateExceptionTestHelper()
        {
            baseProcessMock.Setup(x => x.UpdateRecord(modifiedRecord)).Throws(new Exception(@"Test Exception"));

            var results = controller.Update(modifiedRecord);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, resultData.StatusCode);
            Assert.AreEqual("Test Exception", resultData.Value);
        }

        protected void deleteTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.Save()).Returns(1);

            var results = controller.Delete(id);
            var resultData = results as OkObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual($"{typeof(T).Name} was successfully deleted.", resultData.Value);
        }

        protected void deleteNotDeletedTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.Save()).Returns(0);

            var results = controller.Delete(id);
            var resultData = results as ObjectResult;

            Assert.IsNotNull(resultData);
            Assert.AreEqual((int)HttpStatusCode.NotModified, resultData.StatusCode);
            Assert.AreEqual($"No {typeof(T).Name} data was deleted.", resultData.Value);
        }

        protected void deleteExceptionTestHelper()
        {
            var id = 1001;
            baseProcessMock.Setup(x => x.DeleteRecord(id)).Throws(new Exception(@"Test Exception"));

            var results = controller.Delete(id);
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


            newRecord = new T
            {
                Id = 5001,
            };

            modifiedRecord = new T
            {
                Id = 1001,
            };
        }
    }
}
