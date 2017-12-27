using MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    public class GroceryListRepositoryTest : EntityRepositoryTest<GroceryList>
    {
        public GroceryListRepositoryTest()
        {
            updateAction = u => u.Description = "Test";
        }

        [Test]
        public void GetById_GroceryList_Test()
        {
            get_ById_TestHelper();
        }

        [Test]
        public void GetByCriteria_All_GroceryList_Test()
        {
            get_ByCriteria_All_TestHelper();
        }

        [Test]
        public void GetByCriteria_Single_GroceryList_Test()
        {
            get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public void Add_ByEntity_GroceryList_Test()
        {
            add_ByEntity_TestHelper();
        }

        [Test]
        public void Add_ByEntities_GroceryList_Test()
        {
            add_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByEntity_GroceryList_Test()
        {
            update_ByEntity_TestHelper();
        }

        [Test]
        public void Update_ById_GroceryList_Test()
        {
            update_ById_TestHelper();
        }

        [Test]
        public void Update_ByEntities_GroceryList_Test()
        {
            update_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByCriteria_GroceryList_Test()
        {
            update_ByCriteria_TestHelper();
        }

        [Test]
        public void Delete_ByEntity_GroceryList_Test()
        {
            delete_ByEntity_TestHelper();
        }

        [Test]
        public void Delete_ById_GroceryList_Test()
        {
            delete_ById_TestHelper();
        }

        [Test]
        public void Delete_ByEntities_GroceryList_Test()
        {
            delete_ByEntities_TestHelper();
        }

        [Test]
        public void Delete_ByCriteria_GroceryList_Test()
        {
            delete_ByCriteria_TestHelper();
        }
    }
}
