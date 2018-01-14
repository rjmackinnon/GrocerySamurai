using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class StoreItemProcessTest : BaseProcessTest<StoreItem>
    {
        [Test]
        public async Task GetById_StoreItemProcess_Test()
        {
            await getById_TestHelper();
        }

        [Test]
        public async Task GetAll_Defaults_StoreItemProcess_Test()
        {
            await getAll_Defaults_TestHelper();
        }

        [Test]
        public async Task GetAll_PageSize_StoreItemProcess_Test()
        {
            await getAll_PageSize_TestHelper();
        }

        [Test]
        public async Task AddRecord_StoreItemProcess_Test()
        {
            await addRecord_TestHelper();
        }

        [Test]
        public async Task UpdateRecord_StoreItemProcess_Test()
        {
            await updateRecord_TestHelper();
        }

        [Test]
        public async Task DeleteRecord_StoreItemProcess_Test()
        {
            await deleteRecord_TestHelper();
        }
    }
}
