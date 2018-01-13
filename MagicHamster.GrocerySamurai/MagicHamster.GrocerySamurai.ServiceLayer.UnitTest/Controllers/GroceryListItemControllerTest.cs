using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class GroceryListItemControllerTest : BaseControllerTest<GroceryListItem>
    {
        public GroceryListItemControllerTest()
        {
            controller = new GroceryListItemController(null);
        }

        [Test]
        public void Get_GroceryListItemController_Test()
        {
            getTestHelper();
        }

        [Test]
        public void Get_Null_GroceryListItemController_Test()
        {
            getNullTestHelper();
        }

        [Test]
        public void Get_Exception_GroceryListItemController_Test()
        {
            getExceptionTestHelper();
        }

        [Test]
        public void GetAll_Defaults_GroceryListItemController_Test()
        {
            getAllDefaultsTestHelper();
        }

        [Test]
        public void GetAll_PageSize_GroceryListItemController_Test()
        {
            getAllPageSizeTestHelper();
        }

        [Test]
        public void GetAll_Exception_GroceryListItemController_Test()
        {
            getAllExceptionTestHelper();
        }

        [Test]
        public void Add_GroceryListItemController_Test()
        {
            addTestHelper();
        }

        [Test]
        public void Add_NotInserted_GroceryListItemController_Test()
        {
            addNotInsertedTestHelper();
        }

        [Test]
        public void Add_Exception_GroceryListItemController_Test()
        {
            addExceptionTestHelper();
        }

        [Test]
        public void Update_GroceryListItemController_Test()
        {
            updateTestHelper();
        }

        [Test]
        public void Update_NotUpdated_GroceryListItemController_Test()
        {
            updateNotUpdatedTestHelper();
        }

        [Test]
        public void Update_Exception_GroceryListItemController_Test()
        {
            updateExceptionTestHelper();
        }

        [Test]
        public void Delete_GroceryListItemController_Test()
        {
            deleteTestHelper();
        }

        [Test]
        public void Delete_NotDeleted_GroceryListItemController_Test()
        {
            deleteNotDeletedTestHelper();
        }

        [Test]
        public void Delete_Exception_GroceryListItemController_Test()
        {
            deleteExceptionTestHelper();
        }
    }
}
