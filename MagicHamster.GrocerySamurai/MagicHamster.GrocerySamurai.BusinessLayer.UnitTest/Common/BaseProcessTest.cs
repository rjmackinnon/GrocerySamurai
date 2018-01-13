using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Processes;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Moq;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common
{
    [TestFixture]
    public abstract class BaseProcessTest<T>
        where T : Entity, new()
    {
        protected BaseProcess<T> process;
        protected Mock<IRepository<T>> repositoryMock;
        protected Mock<IUnitOfWork> unitOfWorkMock;
        protected List<T> testData;

        [SetUp]
        public virtual void Init()
        {
            testData = Enumerable.Range(1, 4).Select(e => new T { Id = e }).ToList(); 

            repositoryMock = new Mock<IRepository<T>>();

            repositoryMock.Setup(r => r.Get(It.IsAny<Func<T, bool>>(), It.IsAny<List<string>>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(testData.AsQueryable()));
            repositoryMock.Setup(r => r.Get(It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(Task.FromResult(testData[0]));

            unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.GetRepository<T>()).Returns(Task.FromResult(repositoryMock.Object));
            unitOfWorkMock.Setup(u => u.Save()).Returns(Task.FromResult(1));
            process = new BaseProcess<T>(unitOfWorkMock.Object);
        }

        protected async Task getById_TestHelper()
        {
            var result = await process.GetById(1);

            Assert.AreEqual(1, result.Id);
        }

        protected async Task getAll_Defaults_TestHelper()
        {
            var result = await process.GetAll();

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
            Assert.AreEqual(4, result[3].Id);
        }

        protected async Task getAll_PageSize_TestHelper()
        {
            const int pageSize = 2;

            var result = await process.GetAll(null, null, pageSize);

            Assert.Greater(result.Count, 0);
            Assert.LessOrEqual(pageSize, result.Count);
        }

        protected async Task addRecord_TestHelper()
        {
            var newRecord = new T();
            await process.AddRecord(newRecord);
            var result = await process.Save();

            Assert.AreEqual(1, result);
        }

        protected async Task updateRecord_TestHelper()
        {
            var entity = (await process.GetAll(pageSize: 1)).First();
            await process.UpdateRecord(entity);
            var result = await process.Save();

            Assert.AreEqual(1, result);
        }

        protected async Task deleteRecord_TestHelper()
        {
            var entity = (await process.GetAll(pageSize: 1)).First();
            await process.DeleteRecord(entity.Id);
            var result = await process.Save();

            Assert.AreEqual(1, result);
        }
    }
}
