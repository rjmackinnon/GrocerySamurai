namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class GroceryListItemProcessTest : BaseProcessTest<GroceryListItem>
    {
        [Test]
        public Task GetById_GroceryListItemProcess_Test()
        {
            return getById_TestHelper();
        }

        [Test]
        public Task GetAll_Defaults_GroceryListItemProcess_Test()
        {
            return getAll_Defaults_TestHelper();
        }

        [Test]
        public Task GetAll_PageSize_GroceryListItemProcess_Test()
        {
            return getAll_PageSize_TestHelper();
        }

        [Test]
        public Task AddRecord_GroceryListItemProcess_Test()
        {
            return addRecord_TestHelper();
        }

        [Test]
        public Task UpdateRecord_GroceryListItemProcess_Test()
        {
            return updateRecord_TestHelper();
        }

        [Test]
        public Task DeleteRecord_GroceryListItemProcess_Test()
        {
            return deleteRecord_TestHelper();
        }
    }
}
