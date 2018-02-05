namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    using Common;
    using Model.Entities;
    using NUnit.Framework;
    using ServiceLayer.Controllers;

    [TestFixture]
    public class GroceryListItemControllerTest : BaseControllerTest<GroceryListItem>
    {
        public GroceryListItemControllerTest()
        {
            controller = new GroceryListItemController(null);
        }

        [Test]
        public System.Threading.Tasks.Task Get_GroceryListItemController_TestAsync()
        {
            return getTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Null_GroceryListItemController_TestAsync()
        {
            return getNullTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Exception_GroceryListItemController_TestAsync()
        {
            return getExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Defaults_GroceryListItemController_TestAsync()
        {
            return getAllDefaultsTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_PageSize_GroceryListItemController_TestAsync()
        {
            return getAllPageSizeTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Exception_GroceryListItemController_TestAsync()
        {
            return getAllExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_GroceryListItemController_TestAsync()
        {
            return addTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_NotInserted_GroceryListItemController_TestAsync()
        {
            return addNotInsertedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_Exception_GroceryListItemController_TestAsync()
        {
            return addExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_GroceryListItemController_TestAsync()
        {
            return updateTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_NotUpdated_GroceryListItemController_TestAsync()
        {
            return updateNotUpdatedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_Exception_GroceryListItemController_TestAsync()
        {
            return updateExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_GroceryListItemController_TestAsync()
        {
            return deleteTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_NotDeleted_GroceryListItemController_TestAsync()
        {
            return deleteNotDeletedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_Exception_GroceryListItemController_TestAsync()
        {
            return deleteExceptionTestHelper();
        }
    }
}
