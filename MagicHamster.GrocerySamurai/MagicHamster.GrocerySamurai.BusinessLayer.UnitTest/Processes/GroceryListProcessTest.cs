using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class GroceryListProcessTest : BaseProcessTest<GroceryList>
    {
        [Test]
        public async Task GetById_GroceryListProcess_Test()
        {
            await getById_TestHelper();
        }

        [Test]
        public async Task GetAll_Defaults_GroceryListProcess_Test()
        {
            await getAll_Defaults_TestHelper();
        }

        [Test]
        public async Task GetAll_PageSize_GroceryListProcess_Test()
        {
            await getAll_PageSize_TestHelper();
        }

        [Test]
        public async Task AddRecord_GroceryListProcess_Test()
        {
            await addRecord_TestHelper();
        }

        [Test]
        public async Task UpdateRecord_GroceryListProcess_Test()
        {
            await updateRecord_TestHelper();
        }

        [Test]
        public async Task DeleteRecord_GroceryListProcess_Test()
        {
            await deleteRecord_TestHelper();
        }
    }
}
