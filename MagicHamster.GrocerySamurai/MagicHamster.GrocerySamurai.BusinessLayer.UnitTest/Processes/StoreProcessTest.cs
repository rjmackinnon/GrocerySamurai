using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class StoreProcessTest : BaseUserFilterProcessTest<Store>
    {
        [Test]
        public async Task GetById_StoreProcess_Test()
        {
            await getById_TestHelper();
        }

        [Test]
        public async Task GetAll_Defaults_StoreProcess_Test()
        {
            await getAll_Defaults_TestHelper();
        }

        [Test]
        public async Task GetAll_PageSize_StoreProcess_Test()
        {
            await getAll_PageSize_TestHelper();
        }

        [Test]
        public async Task GetAllByUser_Defaults_StoreProcess_Test()
        {
            await getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public async Task GetAllByUser_PageSize_StoreProcess_Test()
        {
            await getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public async Task AddRecord_StoreProcess_Test()
        {
            await addRecord_TestHelper();
        }

        [Test]
        public async Task UpdateRecord_StoreProcess_Test()
        {
            await updateRecord_TestHelper();
        }

        [Test]
        public async Task DeleteRecord_StoreProcess_Test()
        {
            await deleteRecord_TestHelper();
        }
    }
}
