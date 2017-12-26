using System;
using System.Linq;
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
        protected IUnitOfWork unitOfWork;

        protected IRepository<T> repository;

        private DbContextOptions<GroceryContext> options;

        [SetUp]
        public virtual void Init()
        {
            options = new DbContextOptionsBuilder<GroceryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new GroceryContext(options);
            unitOfWork = new UnitOfWork(context);
            repository = unitOfWork.GetRepository<T>();

            var testData = Enumerable.Range(1, 4).Select(e => new T {Id = e}).ToList();

            testData.ForEach(t => context.Set<T>().Add(t));

            context.SaveChanges();
        }

        [TearDown]
        public virtual void TearDown()
        {
            using (var context = new GroceryContext(options))
            {
                context.Database.EnsureDeleted();
            }
        }

        protected void get_ById_TestHelper()
        {
            var result = repository.Get(1);

            Assert.AreEqual(1, result.Id);
        }

        protected void get_ByCriteria_All_TestHelper()
        {
            var result = repository.Get(r => true, null);

            Assert.AreEqual(4, result.ToList().Count);
            Assert.AreEqual(1, result.ToList()[0].Id);
            Assert.AreEqual(2, result.ToList()[1].Id);
            Assert.AreEqual(3, result.ToList()[2].Id);
            Assert.AreEqual(4, result.ToList()[3].Id);
        }

        protected void get_ByCriteria_Single_TestHelper()
        {
            var result = repository.Get(r => r.Id == 1).FirstOrDefault();

            Assert.AreEqual(1, result?.Id);
        }

        protected void add_ByEntity_TestHelper()
        {
            var maxId = repository.Get().Max(r => r.Id);
            var newRecord = new T{ Id = ++maxId};

            repository.Add(newRecord);

            var result = unitOfWork.Save();

            Assert.AreEqual(1, result);
        }

        protected void add_ByEntities_TestHelper()
        {
            var maxId = repository.Get().Max(r => r.Id);
            var newEntities = Enumerable.Range(1, 10).Select(e => new T{Id = ++maxId}).ToList();

            repository.Add(newEntities);

            var result = unitOfWork.Save();

            Assert.AreEqual(10, result);
        }

        protected void update_ByEntity_TestHelper(Action<T> action)
        {
            var entity = repository.Get().First();

            action(entity);

            repository.Update(entity);

            var result = unitOfWork.Save();

            var check = repository.Get(entity.Id);

            Assert.AreEqual(entity, check);
            Assert.AreEqual(1, result);
        }

        protected void update_ById_TestHelper(Action<T> action)
        {
            var entity = repository.Get().First();

            action(entity);

            repository.Update(entity.Id);

            var result = unitOfWork.Save();

            var check = repository.Get(entity.Id);

            Assert.AreEqual(entity, check);
            Assert.AreEqual(1, result);
        }

        protected void update_ByEntities_TestHelper(Action<T> action)
        {
            bool criteria(T record) => record.Id == (int)Math.Floor(record.Id / 2.0);

            var entities = repository.Get(criteria);

            entities.ToList().ForEach(action);

            repository.Update(entities);

            var result = unitOfWork.Save();

            var check = repository.Get(criteria);

            Assert.IsTrue(entities.All(e => e == check.FirstOrDefault(c => c.Id == e.Id)));
            Assert.AreEqual(result, check.ToList().Count);
        }

        protected void update_ByCriteria_TestHelper(Action<T> action)
        {
            bool criteria(T record) => record.Id != (int)Math.Floor(record.Id / 2.0);
            var entities = repository.Get(criteria);

            entities.ToList().ForEach(action);

            repository.Update(criteria);

            var result = unitOfWork.Save();

            var check = repository.Get(criteria);

            Assert.IsTrue(entities.All(e => e == check.FirstOrDefault(c => c.Id == e.Id)));
            Assert.AreEqual(result, check.ToList().Count);
        }

        protected void delete_ByEntity_TestHelper()
        {
            var entity = repository.Get().First();

            repository.Delete(entity);

            var result = unitOfWork.Save();

            var check = repository.Get(entity.Id);

            Assert.AreEqual(1, result);
            Assert.IsNull(check);
        }

        protected void delete_ById_TestHelper()
        {
            var id = repository.Get().First().Id;

            repository.Delete(id);

            var result = unitOfWork.Save();

            var check = repository.Get(id);

            Assert.AreEqual(1, result);
            Assert.IsNull(check);
        }

        protected void delete_ByEntities_TestHelper()
        {
            bool criteria(T record) => record.Id == (int)Math.Floor(record.Id / 2.0);

            var entities = repository.Get(criteria);

            repository.Delete(entities);

            var result = unitOfWork.Save();

            var check = repository.Get(criteria);

            Assert.AreEqual(result, entities.ToList().Count);
            Assert.IsEmpty(check);
        }

        protected void delete_ByCriteria_TestHelper()
        {
            bool criteria(T record) => record.Id != (int)Math.Floor(record.Id / 2.0);

            var entities = repository.Get(criteria).ToList();
            var numRecords = entities.Count;

            repository.Delete(criteria);

            var result = unitOfWork.Save();

            var check = repository.Get(criteria);

            Assert.AreEqual(result, numRecords);
            Assert.IsEmpty(check);
        }
    }
}
