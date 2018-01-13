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
        public void Get_ItemController_Test()
        {
            getTestHelper();
        }

        [Test]
        public void Get_Null_ItemController_Test()
        {
            getNullTestHelper();
        }

        [Test]
        public void Get_Exception_ItemController_Test()
        {
            getExceptionTestHelper();
        }

        [Test]
        public void GetAll_Defaults_ItemController_Test()
        {
            getAllDefaultsTestHelper();
        }

        [Test]
        public void GetAll_PageSize_ItemController_Test()
        {
            getAllPageSizeTestHelper();
        }

        [Test]
        public void GetAll_Exception_ItemController_Test()
        {
            getAllExceptionTestHelper();
        }

        [Test]
        public void GetAll_NullUser_ItemController_Test()
        {
            getAllNoUserTestHelper();
        }

        [Test]
        public void Add_ItemController_Test()
        {
            addTestHelper();
        }

        [Test]
        public void Add_NotInserted_ItemController_Test()
        {
            addNotInsertedTestHelper();
        }

        [Test]
        public void Add_Exception_ItemController_Test()
        {
            addExceptionTestHelper();
        }

        [Test]
        public void Update_ItemController_Test()
        {
            updateTestHelper();
        }

        [Test]
        public void Update_NotUpdated_ItemController_Test()
        {
            updateNotUpdatedTestHelper();
        }

        [Test]
        public void Update_Exception_ItemController_Test()
        {
            updateExceptionTestHelper();
        }

        [Test]
        public void Delete_ItemController_Test()
        {
            deleteTestHelper();
        }

        [Test]
        public void Delete_NotDeleted_ItemController_Test()
        {
            deleteNotDeletedTestHelper();
        }

        [Test]
        public void Delete_Exception_ItemController_Test()
        {
            deleteExceptionTestHelper();
        }
    }
}
