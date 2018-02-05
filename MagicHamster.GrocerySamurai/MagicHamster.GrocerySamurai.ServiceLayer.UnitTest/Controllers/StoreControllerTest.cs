namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
    using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
    using NUnit.Framework;

    [TestFixture]
    public class StoreControllerTest : BaseUserFilterControllerTest<Store>
    {
        public StoreControllerTest()
        {
            controller = new StoreController(null);
        }

        [Test]
        public Task Get_StoreController_TestAsync()
        {
            return getTestHelper();
        }

        [Test]
        public Task Get_Null_StoreController_TestAsync()
        {
            return getNullTestHelper();
        }

        [Test]
        public Task Get_Exception_StoreController_TestAsync()
        {
            return getExceptionTestHelper();
        }

        [Test]
        public Task GetAll_Defaults_StoreController_TestAsync()
        {
            return getAllDefaultsTestHelper();
        }

        [Test]
        public Task GetAll_PageSize_StoreController_TestAsync()
        {
            return getAllPageSizeTestHelper();
        }

        [Test]
        public Task GetAll_Exception_StoreController_TestAsync()
        {
            return getAllExceptionTestHelper();
        }

        [Test]
        public Task GetAll_NullUser_StoreController_TestAsync()
        {
            return getAllNoUserTestHelper();
        }

        [Test]
        public Task Add_StoreController_TestAsync()
        {
            return addTestHelper();
        }

        [Test]
        public Task Add_NotInserted_StoreController_TestAsync()
        {
            return addNotInsertedTestHelper();
        }

        [Test]
        public Task Add_Exception_StoreController_TestAsync()
        {
            return addExceptionTestHelper();
        }

        [Test]
        public Task Update_StoreController_TestAsync()
        {
            return updateTestHelper();
        }

        [Test]
        public Task Update_NotUpdated_StoreController_TestAsync()
        {
            return updateNotUpdatedTestHelper();
        }

        [Test]
        public Task Update_Exception_StoreController_TestAsync()
        {
            return updateExceptionTestHelper();
        }

        [Test]
        public Task Delete_StoreController_TestAsync()
        {
            return deleteTestHelper();
        }

        [Test]
        public Task Delete_NotDeleted_StoreController_TestAsync()
        {
            return deleteNotDeletedTestHelper();
        }

        [Test]
        public Task Delete_Exception_StoreController_Test()
        {
            return deleteExceptionTestHelper();
        }
    }
}
