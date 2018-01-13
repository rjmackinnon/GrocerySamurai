using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class StoreControllerTest : BaseUserFilterControllerTest<Store>
    {
        public StoreControllerTest()
        {
            controller = new StoreController(null);
        }

        [Test]
        public void Get_StoreController_Test()
        {
            getTestHelper();
        }

        [Test]
        public void Get_Null_StoreController_Test()
        {
            getNullTestHelper();
        }

        [Test]
        public void Get_Exception_StoreController_Test()
        {
            getExceptionTestHelper();
        }

        [Test]
        public void GetAll_Defaults_StoreController_Test()
        {
            getAllDefaultsTestHelper();
        }

        [Test]
        public void GetAll_PageSize_StoreController_Test()
        {
            getAllPageSizeTestHelper();
        }

        [Test]
        public void GetAll_Exception_StoreController_Test()
        {
            getAllExceptionTestHelper();
        }

        [Test]
        public void GetAll_NullUser_StoreController_Test()
        {
            getAllNoUserTestHelper();
        }

        [Test]
        public void Add_StoreController_Test()
        {
            addTestHelper();
        }

        [Test]
        public void Add_NotInserted_StoreController_Test()
        {
            addNotInsertedTestHelper();
        }

        [Test]
        public void Add_Exception_StoreController_Test()
        {
            addExceptionTestHelper();
        }

        [Test]
        public void Update_StoreController_Test()
        {
            updateTestHelper();
        }

        [Test]
        public void Update_NotUpdated_StoreController_Test()
        {
            updateNotUpdatedTestHelper();
        }

        [Test]
        public void Update_Exception_StoreController_Test()
        {
            updateExceptionTestHelper();
        }

        [Test]
        public void Delete_StoreController_Test()
        {
            deleteTestHelper();
        }

        [Test]
        public void Delete_NotDeleted_StoreController_Test()
        {
            deleteNotDeletedTestHelper();
        }

        [Test]
        public void Delete_Exception_StoreController_Test()
        {
            deleteExceptionTestHelper();
        }
    }
}
