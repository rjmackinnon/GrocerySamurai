using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class GroceryListControllerTest : BaseControllerTest<GroceryList>
    {
        public GroceryListControllerTest()
        {
            controller = new GroceryListController(null);
        }

        [Test]
        public async System.Threading.Tasks.Task Get_GroceryListController_TestAsync()
        {
            await getTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Null_GroceryListController_TestAsync()
        {
            await getNullTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Get_Exception_GroceryListController_TestAsync()
        {
            await getExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Defaults_GroceryListController_TestAsync()
        {
            await getAllDefaultsTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_PageSize_GroceryListController_TestAsync()
        {
            await getAllPageSizeTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll_Exception_GroceryListController_TestAsync()
        {
            await getAllExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_GroceryListController_TestAsync()
        {
            await addTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_NotInserted_GroceryListController_TestAsync()
        {
            await addNotInsertedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Add_Exception_GroceryListController_TestAsync()
        {
            await addExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_GroceryListController_TestAsync()
        {
            await updateTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_NotUpdated_GroceryListController_TestAsync()
        {
            await updateNotUpdatedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Update_Exception_GroceryListController_TestAsync()
        {
            await updateExceptionTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_GroceryListController_TestAsync()
        {
            await deleteTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_NotDeleted_GroceryListController_TestAsync()
        {
            await deleteNotDeletedTestHelper();
        }

        [Test]
        public async System.Threading.Tasks.Task Delete_Exception_GroceryListController_TestAsync()
        {
            await deleteExceptionTestHelper();
        }
    }
}
