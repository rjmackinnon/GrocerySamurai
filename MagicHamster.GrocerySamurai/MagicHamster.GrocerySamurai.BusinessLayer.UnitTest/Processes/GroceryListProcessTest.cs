namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    using System.Threading.Tasks;
    using Common;
    using Model.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class GroceryListProcessTest : BaseProcessTest<GroceryList>
    {
        [Test]
        public Task GetById_GroceryListProcess_Test()
        {
            return getById_TestHelper();
        }

        [Test]
        public Task GetAll_Defaults_GroceryListProcess_Test()
        {
            return getAll_Defaults_TestHelper();
        }

        [Test]
        public Task GetAll_PageSize_GroceryListProcess_Test()
        {
            return getAll_PageSize_TestHelper();
        }

        [Test]
        public Task AddRecord_GroceryListProcess_Test()
        {
            return addRecord_TestHelper();
        }

        [Test]
        public Task UpdateRecord_GroceryListProcess_Test()
        {
            return updateRecord_TestHelper();
        }

        [Test]
        public Task DeleteRecord_GroceryListProcess_Test()
        {
            return deleteRecord_TestHelper();
        }
    }
}
