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
        public async System.Threading.Tasks.Task Get_StoreItemController_TestAsync()
        {
            await getTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Null_StoreItemController_TestAsync()
        {
            await getNullTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Exception_StoreItemController_TestAsync()
        {
            await getExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Defaults_StoreItemController_TestAsync()
        {
            await getAllDefaultsTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_PageSize_StoreItemController_TestAsync()
        {
            await getAllPageSizeTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Exception_StoreItemController_TestAsync()
        {
            await getAllExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_StoreItemController_TestAsync()
        {
            await addTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_NotInserted_StoreItemController_TestAsync()
        {
            await addNotInsertedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_Exception_StoreItemController_TestAsync()
        {
            await addExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_StoreItemController_TestAsync()
        {
            await updateTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_NotUpdated_StoreItemController_TestAsync()
        {
            await updateNotUpdatedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_Exception_StoreItemController_TestAsync()
        {
            await updateExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_StoreItemController_TestAsync()
        {
            await deleteTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_NotDeleted_StoreItemController_TestAsync()
        {
            await deleteNotDeletedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_Exception_StoreItemController_TestAsync()
        {
            await deleteExceptionTestHelper();
        }
    }
}
