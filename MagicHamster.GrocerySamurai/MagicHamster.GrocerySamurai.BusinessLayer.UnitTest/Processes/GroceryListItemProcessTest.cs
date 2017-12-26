using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class GroceryListItemProcessTest : BaseProcessTest<GroceryListItem>
    {
        [Test]
        public void GetRecordById_GroceryListItem_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_GroceryListItem_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_GroceryListItem_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_GroceryListItem_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_GroceryListItem_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_GroceryListItem_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_GroceryListItem_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_GroceryListItem_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
