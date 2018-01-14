using System.Threading.Tasks;
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
        public async Task Get_AisleController_Test()
        {
            await getTestHelper();
        }

        [Test]
        public async Task Get_Null_AisleController_Test()
        {
            await getNullTestHelper();
        }

        [Test]
        public async Task Get_Exception_AisleController_Test()
        {
            await getExceptionTestHelper();
        }

        [Test]
        public async Task GetAll_Defaults_AisleController_Test()
        {
            await getAllDefaultsTestHelper();
        }

        [Test]
        public async Task GetAll_PageSize_AisleController_Test()
        {
            await getAllPageSizeTestHelper();
        }

        [Test]
        public async Task GetAll_Exception_AisleController_Test()
        {
            await getAllExceptionTestHelper();
        }

        [Test]
        public async Task GetAll_NullUser_AisleController_Test()
        {
            await getAllNoUserTestHelper();
        }

        [Test]
        public async Task Add_AisleController_Test()
        {
            await addTestHelper();
        }

        [Test]
        public async Task Add_NotInserted_AisleController_TestAsync()
        {
            await addNotInsertedTestHelper();
        }

        [Test]
        public async Task Add_Exception_AisleController_TestAsync()
        {
            await addExceptionTestHelper();
        }

        [Test]
        public async Task Update_AisleController_TestAsync()
        {
            await updateTestHelper();
        }

        [Test]
        public async Task Update_NotUpdated_AisleController_TestAsync()
        {
            await updateNotUpdatedTestHelper();
        }

        [Test]
        public async Task Update_Exception_AisleController_TestAsync()
        {
            await updateExceptionTestHelper();
        }

        [Test]
        public async Task Delete_AisleController_TestAsync()
        {
            await deleteTestHelper();
        }

        [Test]
        public async Task Delete_NotDeleted_AisleController_TestAsync()
        {
            await deleteNotDeletedTestHelper();
        }

        [Test]
        public async Task Delete_Exception_AisleController_TestAsync()
        {
            await deleteExceptionTestHelper();
        }
    }
}
