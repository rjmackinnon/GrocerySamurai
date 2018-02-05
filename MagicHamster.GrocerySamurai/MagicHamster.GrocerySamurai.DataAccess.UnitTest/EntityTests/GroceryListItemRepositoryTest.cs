namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    using System.Threading.Tasks;
    using Common;
    using Model.Entities;
    using NUnit.Framework;

    public class GroceryListItemRepositoryTest : EntityRepositoryTest<GroceryListItem>
    {
        public GroceryListItemRepositoryTest()
        {
            updateAction = u => u.PackageType = "Test";
        }

        [Test]
        public Task GetById_GroceryListItemRepository_Test()
        {
            return get_ById_TestHelper();
        }

        [Test]
        public Task GetByCriteria_All_GroceryListItemRepository_Test()
        {
            return get_ByCriteria_All_TestHelper();
        }

        [Test]
        public Task GetByCriteria_Single_GroceryListItemRepository_Test()
        {
            return get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public Task Add_ByEntity_GroceryListItemRepository_Test()
        {
            return add_ByEntity_TestHelper();
        }

        [Test]
        public Task Add_ByEntities_GroceryListItemRepository_Test()
        {
            return add_ByEntities_TestHelper();
        }

        [Test]
        public Task Update_ByEntity_GroceryListItemRepository_Test()
        {
            return update_ByEntity_TestHelper();
        }

        [Test]
        public Task Update_ById_GroceryListItemRepository_Test()
        {
            return update_ById_TestHelper();
        }

        [Test]
        public Task Update_ByEntities_GroceryListItemRepository_Test()
        {
            return update_ByEntities_TestHelper();
        }

        [Test]
        public Task Update_ByCriteria_GroceryListItemRepository_Test()
        {
            return update_ByCriteria_TestHelper();
        }

        [Test]
        public Task Delete_ByEntity_GroceryListItemRepository_Test()
        {
            return delete_ByEntity_TestHelperAsync();
        }

        [Test]
        public Task Delete_ById_GroceryListItemRepository_Test()
        {
            return delete_ById_TestHelper();
        }

        [Test]
        public Task Delete_ByEntities_GroceryListItemRepository_Test()
        {
            return delete_ByEntities_TestHelper();
        }

        [Test]
        public Task Delete_ByCriteria_GroceryListItemRepository_Test()
        {
            return delete_ByCriteria_TestHelper();
        }
    }
}
