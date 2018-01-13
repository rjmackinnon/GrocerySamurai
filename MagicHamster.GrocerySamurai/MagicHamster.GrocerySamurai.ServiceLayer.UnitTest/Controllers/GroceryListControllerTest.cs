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
        public void Get_GroceryListController_Test()
        {
            getTestHelper();
        }

        [Test]
        public void Get_Null_GroceryListController_Test()
        {
            getNullTestHelper();
        }

        [Test]
        public void Get_Exception_GroceryListController_Test()
        {
            getExceptionTestHelper();
        }

        [Test]
        public void GetAll_Defaults_GroceryListController_Test()
        {
            getAllDefaultsTestHelper();
        }

        [Test]
        public void GetAll_PageSize_GroceryListController_Test()
        {
            getAllPageSizeTestHelper();
        }

        [Test]
        public void GetAll_Exception_GroceryListController_Test()
        {
            getAllExceptionTestHelper();
        }

        [Test]
        public void Add_GroceryListController_Test()
        {
            addTestHelper();
        }

        [Test]
        public void Add_NotInserted_GroceryListController_Test()
        {
            addNotInsertedTestHelper();
        }

        [Test]
        public void Add_Exception_GroceryListController_Test()
        {
            addExceptionTestHelper();
        }

        [Test]
        public void Update_GroceryListController_Test()
        {
            updateTestHelper();
        }

        [Test]
        public void Update_NotUpdated_GroceryListController_Test()
        {
            updateNotUpdatedTestHelper();
        }

        [Test]
        public void Update_Exception_GroceryListController_Test()
        {
            updateExceptionTestHelper();
        }

        [Test]
        public void Delete_GroceryListController_Test()
        {
            deleteTestHelper();
        }

        [Test]
        public void Delete_NotDeleted_GroceryListController_Test()
        {
            deleteNotDeletedTestHelper();
        }

        [Test]
        public void Delete_Exception_GroceryListController_Test()
        {
            deleteExceptionTestHelper();
        }
    }
}
