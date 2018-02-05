namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    using Common;
    using Model.Entities;
    using NUnit.Framework;
    using ServiceLayer.Controllers;

    [TestFixture]
    public class GroceryListControllerTest : BaseControllerTest<GroceryList>
    {
        public GroceryListControllerTest()
        {
            controller = new GroceryListController(null);
        }

        [Test]
        public System.Threading.Tasks.Task Get_GroceryListController_TestAsync()
        {
            return getTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Null_GroceryListController_TestAsync()
        {
            return getNullTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Exception_GroceryListController_TestAsync()
        {
            return getExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Defaults_GroceryListController_TestAsync()
        {
            return getAllDefaultsTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_PageSize_GroceryListController_TestAsync()
        {
            return getAllPageSizeTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Exception_GroceryListController_TestAsync()
        {
            return getAllExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_GroceryListController_TestAsync()
        {
            return addTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_NotInserted_GroceryListController_TestAsync()
        {
            return addNotInsertedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_Exception_GroceryListController_TestAsync()
        {
            return addExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_GroceryListController_TestAsync()
        {
            return updateTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_NotUpdated_GroceryListController_TestAsync()
        {
            return updateNotUpdatedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_Exception_GroceryListController_TestAsync()
        {
            return updateExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_GroceryListController_TestAsync()
        {
            return deleteTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_NotDeleted_GroceryListController_TestAsync()
        {
            return deleteNotDeletedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_Exception_GroceryListController_TestAsync()
        {
            return deleteExceptionTestHelper();
        }
    }
}
