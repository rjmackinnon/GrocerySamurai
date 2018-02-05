namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using NUnit.Framework;

    public class GroceryListRepositoryTest : EntityRepositoryTest<GroceryList>
    {
        public GroceryListRepositoryTest()
        {
            updateAction = u => u.Description = "Test";
        }

        [Test]
        public Task GetById_GroceryListRepository_Test()
        {
            return get_ById_TestHelper();
        }

        [Test]
        public Task GetByCriteria_All_GroceryListRepository_Test()
        {
            return get_ByCriteria_All_TestHelper();
        }

        [Test]
        public Task GetByCriteria_Single_GroceryListRepository_Test()
        {
            return get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public Task Add_ByEntity_GroceryListRepository_Test()
        {
            return add_ByEntity_TestHelper();
        }

        [Test]
        public Task Add_ByEntities_GroceryListRepository_Test()
        {
            return add_ByEntities_TestHelper();
        }

        [Test]
        public Task Update_ByEntity_GroceryListRepository_Test()
        {
            return update_ByEntity_TestHelper();
        }

        [Test]
        public Task Update_ById_GroceryListRepository_Test()
        {
            return update_ById_TestHelper();
        }

        [Test]
        public Task Update_ByEntities_GroceryListRepository_Test()
        {
            return update_ByEntities_TestHelper();
        }

        [Test]
        public Task Update_ByCriteria_GroceryListRepository_Test()
        {
            return update_ByCriteria_TestHelper();
        }

        [Test]
        public Task Delete_ByEntity_GroceryListRepository_Test()
        {
            return delete_ByEntity_TestHelperAsync();
        }

        [Test]
        public Task Delete_ById_GroceryListRepository_Test()
        {
            return delete_ById_TestHelper();
        }

        [Test]
        public Task Delete_ByEntities_GroceryListRepository_Test()
        {
            return delete_ByEntities_TestHelper();
        }

        [Test]
        public Task Delete_ByCriteria_GroceryListRepository_Test()
        {
            return delete_ByCriteria_TestHelper();
        }
    }
}
