using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class GroceryListItemProcessTest : BaseProcessTest<GroceryListItem>
    {
        [Test]
        public void GetById_GroceryListItemProcess_Test()
        {
            getById_TestHelper();
        }

        [Test]
        public void GetAll_Defaults_GroceryListItemProcess_Test()
        {
            getAll_Defaults_TestHelper();
        }

        [Test]
        public void GetAll_PageSize_GroceryListItemProcess_Test()
        {
            getAll_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_GroceryListItemProcess_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_GroceryListItemProcess_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_GroceryListItemProcess_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
