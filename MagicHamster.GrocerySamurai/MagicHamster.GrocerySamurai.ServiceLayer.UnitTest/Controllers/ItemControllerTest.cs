using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class ItemControllerTest : BaseUserFilterControllerTest<Item>
    {
        public ItemControllerTest()
        {
            controller = new ItemController(null);
        }

        [Test]
        public async System.Threading.Tasks.Task Get_ItemController_TestAsync()
        {
            await getTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Null_ItemController_TestAsync()
        {
            await getNullTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Exception_ItemController_TestAsync()
        {
            await getExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Defaults_ItemController_TestAsync()
        {
            await getAllDefaultsTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_PageSize_ItemController_TestAsync()
        {
            await getAllPageSizeTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Exception_ItemController_TestAsync()
        {
            await getAllExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_NullUser_ItemController_TestAsync()
        {
            await getAllNoUserTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_ItemController_TestAsync()
        {
            await addTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_NotInserted_ItemController_TestAsync()
        {
            await addNotInsertedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_Exception_ItemController_TestAsync()
        {
            await addExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_ItemController_TestAsync()
        {
            await updateTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_NotUpdated_ItemController_TestAsync()
        {
            await updateNotUpdatedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_Exception_ItemController_TestAsync()
        {
            await updateExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_ItemController_TestAsync()
        {
            await deleteTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_NotDeleted_ItemController_TestAsync()
        {
            await deleteNotDeletedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_Exception_ItemController_TestAsync()
        {
            await deleteExceptionTestHelper();
        }
    }
}
