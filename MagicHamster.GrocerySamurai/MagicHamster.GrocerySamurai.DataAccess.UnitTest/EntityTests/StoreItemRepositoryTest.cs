namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    using System.Threading.Tasks;
    using Common;
    using Model.Entities;
    using NUnit.Framework;

    public class StoreItemRepositoryTest : EntityRepositoryTest<StoreItem>
    {
        public StoreItemRepositoryTest()
        {
            updateAction = u => u.AisleId = 1;
        }

        [Test]
        public Task GetById_StoreItemRepository_Test()
        {
            return get_ById_TestHelper();
        }

        [Test]
        public Task GetByCriteria_All_StoreItemRepository_Test()
        {
            return get_ByCriteria_All_TestHelper();
        }

        [Test]
        public Task GetByCriteria_Single_StoreItemRepository_Test()
        {
            return get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public Task Add_ByEntity_StoreItemRepository_Test()
        {
            return add_ByEntity_TestHelper();
        }

        [Test]
        public Task Add_ByEntities_StoreItemRepository_Test()
        {
            return add_ByEntities_TestHelper();
        }

        [Test]
        public Task Update_ByEntity_StoreItemRepository_Test()
        {
            return update_ByEntity_TestHelper();
        }

        [Test]
        public Task Update_ById_StoreItemRepository_Test()
        {
            return update_ById_TestHelper();
        }

        [Test]
        public Task Update_ByEntities_StoreItemRepository_Test()
        {
            return update_ByEntities_TestHelper();
        }

        [Test]
        public Task Update_ByCriteria_StoreItemRepository_Test()
        {
            return update_ByCriteria_TestHelper();
        }

        [Test]
        public Task Delete_ByEntity_StoreItemRepository_Test()
        {
            return delete_ByEntity_TestHelperAsync();
        }

        [Test]
        public Task Delete_ById_StoreItemRepository_Test()
        {
            return delete_ById_TestHelper();
        }

        [Test]
        public Task Delete_ByEntities_StoreItemRepository_Test()
        {
            return delete_ByEntities_TestHelper();
        }

        [Test]
        public Task Delete_ByCriteria_StoreItemRepository_Test()
        {
            return delete_ByCriteria_TestHelper();
        }
    }
}
