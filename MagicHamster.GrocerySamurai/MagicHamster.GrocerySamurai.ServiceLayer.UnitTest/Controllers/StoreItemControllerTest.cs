namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    using Common;
    using Model.Entities;
    using NUnit.Framework;
    using ServiceLayer.Controllers;

    [TestFixture]
    public class StoreItemControllerTest : BaseControllerTest<StoreItem>
    {
        public StoreItemControllerTest()
        {
            controller = new StoreItemController(null);
        }

        [Test]
        public System.Threading.Tasks.Task Get_StoreItemController_TestAsync()
        {
            return getTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Null_StoreItemController_TestAsync()
        {
            return getNullTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Exception_StoreItemController_TestAsync()
        {
            return getExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Defaults_StoreItemController_TestAsync()
        {
            return getAllDefaultsTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_PageSize_StoreItemController_TestAsync()
        {
            return getAllPageSizeTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Exception_StoreItemController_TestAsync()
        {
            return getAllExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_StoreItemController_TestAsync()
        {
            return addTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_NotInserted_StoreItemController_TestAsync()
        {
            return addNotInsertedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_Exception_StoreItemController_TestAsync()
        {
            return addExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_StoreItemController_TestAsync()
        {
            return updateTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_NotUpdated_StoreItemController_TestAsync()
        {
            return updateNotUpdatedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_Exception_StoreItemController_TestAsync()
        {
            return updateExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_StoreItemController_TestAsync()
        {
            return deleteTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_NotDeleted_StoreItemController_TestAsync()
        {
            return deleteNotDeletedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_Exception_StoreItemController_TestAsync()
        {
            return deleteExceptionTestHelper();
        }
    }
}
