using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class GroceryListProcessTest : BaseProcessTest<GroceryList>
    {
        [Test]
        public void GetRecordById_GroceryList_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_GroceryList_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_GroceryList_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_GroceryList_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_GroceryList_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_GroceryList_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_GroceryList_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_GroceryList_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
