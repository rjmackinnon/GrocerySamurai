using System.Threading.Tasks;
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
        public async Task Get_StoreController_TestAsync()
        {
            await getTestHelper();
        }

        [Test]
        public async Task Get_Null_StoreController_TestAsync()
        {
            await getNullTestHelper();
        }

        [Test]
        public async Task Get_Exception_StoreController_TestAsync()
        {
            await getExceptionTestHelper();
        }

        [Test]
        public async Task GetAll_Defaults_StoreController_TestAsync()
        {
            await getAllDefaultsTestHelper();
        }

        [Test]
        public async Task GetAll_PageSize_StoreController_TestAsync()
        {
            await getAllPageSizeTestHelper();
        }

        [Test]
        public async Task GetAll_Exception_StoreController_TestAsync()
        {
            await getAllExceptionTestHelper();
        }

        [Test]
        public async Task GetAll_NullUser_StoreController_TestAsync()
        {
            await getAllNoUserTestHelper();
        }

        [Test]
        public async Task Add_StoreController_TestAsync()
        {
            await addTestHelper();
        }

        [Test]
        public async Task Add_NotInserted_StoreController_TestAsync()
        {
            await addNotInsertedTestHelper();
        }

        [Test]
        public async Task Add_Exception_StoreController_TestAsync()
        {
            await addExceptionTestHelper();
        }

        [Test]
        public async Task Update_StoreController_TestAsync()
        {
            await updateTestHelper();
        }

        [Test]
        public async Task Update_NotUpdated_StoreController_TestAsync()
        {
            await updateNotUpdatedTestHelper();
        }

        [Test]
        public async Task Update_Exception_StoreController_TestAsync()
        {
            await updateExceptionTestHelper();
        }

        [Test]
        public async Task Delete_StoreController_TestAsync()
        {
            await deleteTestHelper();
        }

        [Test]
        public async Task Delete_NotDeleted_StoreController_TestAsync()
        {
            await deleteNotDeletedTestHelper();
        }

        [Test]
        public async Task Delete_Exception_StoreController_Test()
        {
            await deleteExceptionTestHelper();
        }
    }
}
