using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class GroceryListItemControllerTest : BaseControllerTest<GroceryListItem>
    {
        public GroceryListItemControllerTest()
        {
            controller = new GroceryListItemController(null);
        }

        [Test]
        public async System.Threading.Tasks.Task Get_GroceryListItemController_TestAsync()
        {
            await getTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Null_GroceryListItemController_TestAsync()
        {
            await getNullTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Exception_GroceryListItemController_TestAsync()
        {
            await getExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Defaults_GroceryListItemController_TestAsync()
        {
            await getAllDefaultsTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_PageSize_GroceryListItemController_TestAsync()
        {
            await getAllPageSizeTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Exception_GroceryListItemController_TestAsync()
        {
            await getAllExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_GroceryListItemController_TestAsync()
        {
            await addTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_NotInserted_GroceryListItemController_TestAsync()
        {
            await addNotInsertedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_Exception_GroceryListItemController_TestAsync()
        {
            await addExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_GroceryListItemController_TestAsync()
        {
            await updateTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_NotUpdated_GroceryListItemController_TestAsync()
        {
            await updateNotUpdatedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_Exception_GroceryListItemController_TestAsync()
        {
            await updateExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_GroceryListItemController_TestAsync()
        {
            await deleteTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_NotDeleted_GroceryListItemController_TestAsync()
        {
            await deleteNotDeletedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_Exception_GroceryListItemController_TestAsync()
        {
            await deleteExceptionTestHelper();
        }
    }
}
