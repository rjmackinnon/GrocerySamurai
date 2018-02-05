namespace MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Controllers
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using MagicHamster.GrocerySamurai.ServiceLayer.Controllers;
    using MagicHamster.GrocerySamurai.ServiceLayer.UnitTest.Common;
    using NUnit.Framework;

    [TestFixture]
    public class AisleControllerTest : BaseUserFilterControllerTest<Aisle>
    {
        public AisleControllerTest()
        {
            controller = new AisleController(null);
        }

        [Test]
        public Task Get_AisleController_Test()
        {
            return getTestHelper();
        }

        [Test]
        public Task Get_Null_AisleController_Test()
        {
            return getNullTestHelper();
        }

        [Test]
        public Task Get_Exception_AisleController_Test()
        {
            return getExceptionTestHelper();
        }

        [Test]
        public Task GetAll_Defaults_AisleController_Test()
        {
            return getAllDefaultsTestHelper();
        }

        [Test]
        public Task GetAll_PageSize_AisleController_Test()
        {
            return getAllPageSizeTestHelper();
        }

        [Test]
        public Task GetAll_Exception_AisleController_Test()
        {
            return getAllExceptionTestHelper();
        }

        [Test]
        public Task GetAll_NullUser_AisleController_Test()
        {
            return getAllNoUserTestHelper();
        }

        [Test]
        public Task Add_AisleController_Test()
        {
            return addTestHelper();
        }

        [Test]
        public Task Add_NotInserted_AisleController_TestAsync()
        {
            return addNotInsertedTestHelper();
        }

        [Test]
        public Task Add_Exception_AisleController_TestAsync()
        {
            return addExceptionTestHelper();
        }

        [Test]
        public Task Update_AisleController_TestAsync()
        {
            return updateTestHelper();
        }

        [Test]
        public Task Update_NotUpdated_AisleController_TestAsync()
        {
            return updateNotUpdatedTestHelper();
        }

        [Test]
        public Task Update_Exception_AisleController_TestAsync()
        {
            return updateExceptionTestHelper();
        }

        [Test]
        public Task Delete_AisleController_TestAsync()
        {
            return deleteTestHelper();
        }

        [Test]
        public Task Delete_NotDeleted_AisleController_TestAsync()
        {
            return deleteNotDeletedTestHelper();
        }

        [Test]
        public Task Delete_Exception_AisleController_TestAsync()
        {
            return deleteExceptionTestHelper();
        }
    }
}
