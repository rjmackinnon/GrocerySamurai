using MagicHamster.GrocerySamurai.Model.Entities;
using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    [TestFixture]
    public class AisleControllerTest : BaseUserFilterControllerTest<Aisle>
    {
        public AisleControllerTest()
        {
            controller = new AisleController(null);
        }

        [Test]
        public void Get_AisleController_Test()
        {
            getTestHelper();
        }

        [Test]
        public void Get_Null_AisleController_Test()
        {
            getNullTestHelper();
        }

        [Test]
        public void Get_Exception_AisleController_Test()
        {
            getExceptionTestHelper();
        }

        [Test]
        public void GetAll_Defaults_AisleController_Test()
        {
            getAllDefaultsTestHelper();
        }

        [Test]
        public void GetAll_PageSize_AisleController_Test()
        {
            getAllPageSizeTestHelper();
        }

        [Test]
        public void GetAll_Exception_AisleController_Test()
        {
            getAllExceptionTestHelper();
        }

        [Test]
        public void GetAll_NullUser_AisleController_Test()
        {
            getAllNoUserTestHelper();
        }

        [Test]
        public void Add_AisleController_Test()
        {
            addTestHelper();
        }

        [Test]
        public void Add_NotInserted_AisleController_Test()
        {
            addNotInsertedTestHelper();
        }

        [Test]
        public void Add_Exception_AisleController_Test()
        {
            addExceptionTestHelper();
        }

        [Test]
        public void Update_AisleController_Test()
        {
            updateTestHelper();
        }

        [Test]
        public void Update_NotUpdated_AisleController_Test()
        {
            updateNotUpdatedTestHelper();
        }

        [Test]
        public void Update_Exception_AisleController_Test()
        {
            updateExceptionTestHelper();
        }

        [Test]
        public void Delete_AisleController_Test()
        {
            deleteTestHelper();
        }

        [Test]
        public void Delete_NotDeleted_AisleController_Test()
        {
            deleteNotDeletedTestHelper();
        }

        [Test]
        public void Delete_Exception_AisleController_Test()
        {
            deleteExceptionTestHelper();
        }
    }
}
