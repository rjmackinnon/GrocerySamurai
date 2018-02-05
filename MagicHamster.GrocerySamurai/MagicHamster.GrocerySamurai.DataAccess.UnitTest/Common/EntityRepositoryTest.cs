namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Model.Common;
    using NUnit.Framework;
    using UnitsOfWork;

    [TestFixture]
    public abstract class EntityRepositoryTest<T>
        where T : Entity, new()
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<T> _repository;
        private DbContextOptions<GroceryContext> _options;

        protected Action<T> updateAction { get; set; }

        [SetUp]
        public async Task InitAsync()
        {
            _options = new DbContextOptionsBuilder<GroceryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new GroceryContext(_options);
            _unitOfWork = new UnitOfWork(context);
            _repository = await _unitOfWork.GetRepository<T>().ConfigureAwait(false);

            var testData = Enumerable.Range(1, 4).Select(e => new T { Id = e }).ToList();

            testData.ForEach(t => context.Set<T>().AddAsync(t));

            await context.SaveChangesAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            using (var context = new GroceryContext(_options))
            {
                await context.Database.EnsureDeletedAsync().ConfigureAwait(false);
            }
        }

        protected async Task get_ById_TestHelper()
        {
            var result = await _repository.Get(1).ConfigureAwait(false);

            Assert.AreEqual(1, result.Id);
        }

        protected async Task get_ByCriteria_All_TestHelper()
        {
            var result = await _repository.Get(r => true).ConfigureAwait(false);

            Assert.AreEqual(4, result.ToList().Count);
            Assert.AreEqual(1, result.ToList()[0].Id);
            Assert.AreEqual(2, result.ToList()[1].Id);
            Assert.AreEqual(3, result.ToList()[2].Id);
            Assert.AreEqual(4, result.ToList()[3].Id);
        }

        protected async Task get_ByCriteria_Single_TestHelper()
        {
            var result = (await _repository.Get(r => r.Id == 1).ConfigureAwait(false)).FirstOrDefault();

            Assert.AreEqual(1, result?.Id);
        }

        protected async Task add_ByEntity_TestHelper()
        {
            var maxId = (await _repository.Get().ConfigureAwait(false)).Max(r => r.Id);
            var newRecord = new T { Id = ++maxId };

            await _repository.Add(newRecord).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            Assert.AreEqual(1, result);
        }

        protected async Task add_ByEntities_TestHelper()
        {
            var maxId = (await _repository.Get().ConfigureAwait(false)).Max(r => r.Id);
            var newEntities = Enumerable.Range(1, 10).Select(e => new T { Id = ++maxId }).ToList();

            await _repository.Add(newEntities).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            Assert.AreEqual(10, result);
        }

        protected async Task update_ByEntity_TestHelper()
        {
            var entity = (await _repository.Get().ConfigureAwait(false)).First();

            updateAction(entity);

            await _repository.Update(entity).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(entity.Id).ConfigureAwait(false);

            Assert.AreEqual(entity, check);
            Assert.AreEqual(1, result);
        }

        protected async Task update_ById_TestHelper()
        {
            var entity = (await _repository.Get().ConfigureAwait(false)).First();

            updateAction(entity);

            await _repository.Update(entity.Id).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(entity.Id).ConfigureAwait(false);

            Assert.AreEqual(entity, check);
            Assert.AreEqual(1, result);
        }

        protected async Task update_ByEntities_TestHelper()
        {
            var entities = await _repository.Get(r => r.Id == (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            entities.ToList().ForEach(updateAction);

            await _repository.Update(entities).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(r => r.Id == (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            Assert.IsTrue(entities.All(e => e == check.FirstOrDefault(c => c.Id == e.Id)));
            Assert.AreEqual(result, check.ToList().Count);
        }

        protected async Task update_ByCriteria_TestHelper()
        {
            var entities = await _repository.Get(r => r.Id != (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            entities.ToList().ForEach(updateAction);

            await _repository.Update(r => r.Id != (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(r => r.Id != (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            Assert.IsTrue(entities.All(e => e == check.FirstOrDefault(c => c.Id == e.Id)));
            Assert.AreEqual(result, check.ToList().Count);
        }

        protected async Task delete_ByEntity_TestHelperAsync()
        {
            var entity = (await _repository.Get().ConfigureAwait(false)).First();

            await _repository.Delete(entity).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(entity.Id).ConfigureAwait(false);

            Assert.AreEqual(1, result);
            Assert.IsNull(check);
        }

        protected async Task delete_ById_TestHelper()
        {
            var id = (await _repository.Get().ConfigureAwait(false)).First().Id;

            await _repository.Delete(id).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(id).ConfigureAwait(false);

            Assert.AreEqual(1, result);
            Assert.IsNull(check);
        }

        protected async Task delete_ByEntities_TestHelper()
        {
            var entities = await _repository.Get(r => r.Id == (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            await _repository.Delete(entities).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(r => r.Id == (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            Assert.AreEqual(result, entities.ToList().Count);
            Assert.IsEmpty(check);
        }

        protected async Task delete_ByCriteria_TestHelper()
        {
            var entities = (await _repository.Get(r => r.Id != (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false)).ToList();
            var numRecords = entities.Count;

            await _repository.Delete(r => r.Id != (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            var result = await _unitOfWork.Save().ConfigureAwait(false);

            var check = await _repository.Get(r => r.Id != (int)Math.Floor(r.Id / 2.0)).ConfigureAwait(false);

            Assert.AreEqual(result, numRecords);
            Assert.IsEmpty(check);
        }
    }
}
