using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class AisleProcessTest : BaseUserFilterProcessTest<Aisle>
    {
        [Test]
        public async Task GetById_AisleProcess_Test()
        {
            await getById_TestHelper();
        }

        [Test]
        public async Task GetAll_Defaults_AisleProcess_Test()
        {
            await getAll_Defaults_TestHelper();
        }

        [Test]
        public async Task GetAll_PageSize_AisleProcess_Test()
        {
            await getAll_PageSize_TestHelper();
        }

        [Test]
        public async Task GetAllByUser_Defaults_AisleProcess_Test()
        {
            await getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public async Task GetAllByUser_PageSize_AisleProcess_Test()
        {
            await getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public async Task AddRecord_AisleProcess_Test()
        {
            await addRecord_TestHelper();
        }

        [Test]
        public async Task UpdateRecord_AisleProcess_Test()
        {
            await updateRecord_TestHelper();
        }

        [Test]
        public async Task DeleteRecord_AisleProcess_Test()
        {
            await deleteRecord_TestHelper();
        }
    }
}
