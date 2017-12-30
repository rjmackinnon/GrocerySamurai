using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class StoreItemControllerTest : BaseControllerTest<StoreItem>
    {
        public StoreItemControllerTest()
        {
            controller = new StoreItemController(null);
        }

        [Test]
        public void Get_StoreItemController_Test()
        {
            getTestHelper();
        }

        [Test]
        public void Get_Null_StoreItemController_Test()
        {
            getNullTestHelper();
        }

        [Test]
        public void Get_Exception_StoreItemController_Test()
        {
            getExceptionTestHelper();
        }

        [Test]
        public void GetAll_Defaults_StoreItemController_Test()
        {
            getAllDefaultsTestHelper();
        }

        [Test]
        public void GetAll_PageSize_StoreItemController_Test()
        {
            getAllPageSizeTestHelper();
        }

        [Test]
        public void GetAll_Exception_StoreItemController_Test()
        {
            getAllExceptionTestHelper();
        }

        [Test]
        public void Add_StoreItemController_Test()
        {
            addTestHelper();
        }

        [Test]
        public void Add_NotInserted_StoreItemController_Test()
        {
            addNotInsertedTestHelper();
        }

        [Test]
        public void Add_Exception_StoreItemController_Test()
        {
            addExceptionTestHelper();
        }

        [Test]
        public void Update_StoreItemController_Test()
        {
            updateTestHelper();
        }

        [Test]
        public void Update_NotUpdated_StoreItemController_Test()
        {
            updateNotUpdatedTestHelper();
        }

        [Test]
        public void Update_Exception_StoreItemController_Test()
        {
            updateExceptionTestHelper();
        }

        [Test]
        public void Delete_StoreItemController_Test()
        {
            deleteTestHelper();
        }

        [Test]
        public void Delete_NotDeleted_StoreItemController_Test()
        {
            deleteNotDeletedTestHelper();
        }

        [Test]
        public void Delete_Exception_StoreItemController_Test()
        {
            deleteExceptionTestHelper();
        }
    }
}
