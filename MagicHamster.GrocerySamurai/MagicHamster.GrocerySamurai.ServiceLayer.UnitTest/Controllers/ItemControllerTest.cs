namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    using MagicHamster.GrocerySamurai.Model.Entities;
    using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
    using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ItemControllerTest : BaseUserFilterControllerTest<Item>
    {
        public ItemControllerTest()
        {
            controller = new ItemController(null);
        }

        [Test]
        public System.Threading.Tasks.Task Get_ItemController_TestAsync()
        {
            return getTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Null_ItemController_TestAsync()
        {
            return getNullTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Get_Exception_ItemController_TestAsync()
        {
            return getExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Defaults_ItemController_TestAsync()
        {
            return getAllDefaultsTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_PageSize_ItemController_TestAsync()
        {
            return getAllPageSizeTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_Exception_ItemController_TestAsync()
        {
            return getAllExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task GetAll_NullUser_ItemController_TestAsync()
        {
            return getAllNoUserTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_ItemController_TestAsync()
        {
            return addTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_NotInserted_ItemController_TestAsync()
        {
            return addNotInsertedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Add_Exception_ItemController_TestAsync()
        {
            return addExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_ItemController_TestAsync()
        {
            return updateTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_NotUpdated_ItemController_TestAsync()
        {
            return updateNotUpdatedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Update_Exception_ItemController_TestAsync()
        {
            return updateExceptionTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_ItemController_TestAsync()
        {
            return deleteTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_NotDeleted_ItemController_TestAsync()
        {
            return deleteNotDeletedTestHelper();
        }

        [Test]
        public System.Threading.Tasks.Task Delete_Exception_ItemController_TestAsync()
        {
            return deleteExceptionTestHelper();
        }
    }
}
