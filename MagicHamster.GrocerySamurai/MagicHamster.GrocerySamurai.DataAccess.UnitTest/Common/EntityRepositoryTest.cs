using System;
using System.Linq;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.UnitsOfWork;
using MagicHamster.GrocerySamurai.Model;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common
{
    [TestFixture]
    public abstract class EntityRepositoryTest<T>
        where T : Entity, new()
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<T> _repository;
        private DbContextOptions<GroceryContext> _options;

        protected Action<T> updateAction;

        [SetUp]
        public async Task InitAsync()
        {
            _options = new DbContextOptionsBuilder<GroceryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new GroceryContext(_options);
            _unitOfWork = new UnitOfWork(context);
            _repository = await _unitOfWork.GetRepository<T>();

            var testData = Enumerable.Range(1, 4).Select(e => new T {Id = e}).ToList();

            testData.ForEach(t => context.Set<T>().Add(t));

            context.SaveChanges();
        }

        [TearDown]
        public async Task TearDown()
        {
            using (var context = new GroceryContext(_options))
            {
                await context.Database.EnsureDeletedAsync();
            }
        }

        protected async Task get_ById_TestHelper()
        {
            var result = await _repository.Get(1);

            Assert.AreEqual(1, result.Id);
        }

        protected async Task get_ByCriteria_All_TestHelper()
        {
            var result = await _repository.GetAsync(r => true);

            Assert.AreEqual(4, result.ToList().Count);
            Assert.AreEqual(1, result.ToList()[0].Id);
            Assert.AreEqual(2, result.ToList()[1].Id);
            Assert.AreEqual(3, result.ToList()[2].Id);
            Assert.AreEqual(4, result.ToList()[3].Id);
        }

        protected async Task get_ByCriteria_Single_TestHelper()
        {
            var result = (await _repository.GetAsync(r => r.Id == 1)).FirstOrDefault();

            Assert.AreEqual(1, result?.Id);
        }

        protected async Task add_ByEntity_TestHelper()
        {
            var maxId = (await _repository.GetAsync()).Max(r => r.Id);
            var newRecord = new T{ Id = ++maxId};

            await _repository.Add(newRecord);

            var result = await _unitOfWork.Save();

            Assert.AreEqual(1, result);
        }

        protected async Task add_ByEntities_TestHelper()
        {
            var maxId = (await _repository.GetAsync()).Max(r => r.Id);
            var newEntities = Enumerable.Range(1, 10).Select(e => new T{Id = ++maxId}).ToList();

            await _repository.Add(newEntities);

            var result = await _unitOfWork.Save();

            Assert.AreEqual(10, result);
        }

        protected async Task update_ByEntity_TestHelper()
        {
            var entity = (await _repository.GetAsync()).First();

            updateAction(entity);

            await _repository.Update(entity);

            var result = await _unitOfWork.Save();

            var check = await _repository.Get(entity.Id);

            Assert.AreEqual(entity, check);
            Assert.AreEqual(1, result);
        }

        protected async Task update_ById_TestHelper()
        {
            var entity = (await _repository.GetAsync()).First();

            updateAction(entity);

            await _repository.Update(entity.Id);

            var result = await _unitOfWork.Save();

            var check = await _repository.Get(entity.Id);

            Assert.AreEqual(entity, check);
            Assert.AreEqual(1, result);
        }

        protected async Task update_ByEntities_TestHelper()
        {
            bool criteria(T record) => record.Id == (int)Math.Floor(record.Id / 2.0);

            var entities = await _repository.GetAsync(criteria);

            entities.ToList().ForEach(updateAction);

            await _repository.Update(entities);

            var result = await _unitOfWork.Save();

            var check = await _repository.GetAsync(criteria);

            Assert.IsTrue(entities.All(e => e == check.FirstOrDefault(c => c.Id == e.Id)));
            Assert.AreEqual(result, check.ToList().Count);
        }

        protected async Task update_ByCriteria_TestHelper()
        {
            bool criteria(T record) => record.Id != (int)Math.Floor(record.Id / 2.0);
            var entities = await _repository.GetAsync(criteria);

            entities.ToList().ForEach(updateAction);

            await _repository.Update(criteria);

            var result = await _unitOfWork.Save();

            var check = await _repository.GetAsync(criteria);

            Assert.IsTrue(entities.All(e => e == check.FirstOrDefault(c => c.Id == e.Id)));
            Assert.AreEqual(result, check.ToList().Count);
        }

        protected async Task delete_ByEntity_TestHelperAsync()
        {
            var entity = (await _repository.GetAsync()).First();

            await _repository.Delete(entity);

            var result = await _unitOfWork.Save();

            var check = await _repository.Get(entity.Id);

            Assert.AreEqual(1, result);
            Assert.IsNull(check);
        }

        protected async Task delete_ById_TestHelper()
        {
            var id = (await _repository.GetAsync()).First().Id;

            await _repository.Delete(id);

            var result = await _unitOfWork.Save();

            var check = await _repository.Get(id);

            Assert.AreEqual(1, result);
            Assert.IsNull(check);
        }

        protected async Task delete_ByEntities_TestHelper()
        {
            bool criteria(T record) => record.Id == (int)Math.Floor(record.Id / 2.0);

            var entities = await _repository.GetAsync(criteria);

            await _repository.Delete(entities);

            var result = await _unitOfWork.Save();

            var check = await _repository.GetAsync(criteria);

            Assert.AreEqual(result, entities.ToList().Count);
            Assert.IsEmpty(check);
        }

        protected async Task delete_ByCriteria_TestHelper()
        {
            bool criteria(T record) => record.Id != (int)Math.Floor(record.Id / 2.0);

            var entities = (await _repository.GetAsync(criteria)).ToList();
            var numRecords = entities.Count;

            await _repository.Delete(criteria);

            var result = await _unitOfWork.Save();

            var check = await _repository.GetAsync(criteria);

            Assert.AreEqual(result, numRecords);
            Assert.IsEmpty(check);
        }
    }
}
