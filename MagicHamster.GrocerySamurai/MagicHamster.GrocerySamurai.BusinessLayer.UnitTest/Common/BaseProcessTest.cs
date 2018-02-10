namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using BusinessLayer.Processes;
    using DataAccess.Interfaces;
    using Model.Common;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public abstract class BaseProcessTest<T>
        where T : Entity, new()
    {
        protected Mock<IUnitOfWork> unitOfWorkMock { get; private set; }

        private BaseProcess<T> process { get; set; }

        private Mock<IRepository<T>> repositoryMock { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        private List<T> testData { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        [SetUp]
        public virtual void Init()
        {
            testData = Enumerable.Range(1, 4).Select(e => new T { Id = e }).ToList();

            repositoryMock = new Mock<IRepository<T>>();

            repositoryMock.Setup(r => r.Get(It.IsAny<Expression<Func<T, bool>>>(), It.IsAny<List<string>>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(testData.AsQueryable()));
            repositoryMock.Setup(r => r.Get(It.IsAny<int>(), It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(Task.FromResult(testData[0]));

            unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.GetRepository<T>()).Returns(Task.FromResult(repositoryMock.Object));
            unitOfWorkMock.Setup(u => u.Save()).Returns(Task.FromResult(1));
            process = new BaseProcess<T>(unitOfWorkMock.Object);
        }

        protected async Task getById_TestHelper()
        {
            var result = await process.GetById(1)
                .ConfigureAwait(false);

            Assert.AreEqual(1, result.Id);
        }

        protected async Task getAll_Defaults_TestHelper()
        {
            var result = await process.GetAll()
                .ConfigureAwait(false);

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
            Assert.AreEqual(4, result[3].Id);
        }

        protected async Task getAll_PageSize_TestHelper()
        {
            const int pageSize = 2;

            var result = await process.GetAll(null, null, pageSize)
                .ConfigureAwait(false);

            Assert.Greater(result.Count, 0);
            Assert.LessOrEqual(pageSize, result.Count);
        }

        protected async Task addRecord_TestHelper()
        {
            var newRecord = new T();
            await process.AddRecord(newRecord)
                .ConfigureAwait(false);
            var result = await process.Save()
                .ConfigureAwait(false);

            Assert.AreEqual(1, result);
        }

        protected async Task updateRecord_TestHelper()
        {
            var entity = (await process.GetAll(pageSize: 1).ConfigureAwait(false)).First();
            await process.UpdateRecord(entity).ConfigureAwait(false);
            var result = await process.Save().ConfigureAwait(false);

            Assert.AreEqual(1, result);
        }

        protected async Task deleteRecord_TestHelper()
        {
            var entity = (await process.GetAll(pageSize: 1).ConfigureAwait(false)).First();
            await process.DeleteRecord(entity.Id).ConfigureAwait(false);
            var result = await process.Save().ConfigureAwait(false);

            Assert.AreEqual(1, result);
        }
    }
}
