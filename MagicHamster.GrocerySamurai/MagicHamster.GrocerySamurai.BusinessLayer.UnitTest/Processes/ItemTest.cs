using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class ItemProcessTest : BaseProcessTest<Item>
    {
        [Test]
        public void GetRecordById_Item_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_Item_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_Item_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_Item_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_Item_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_Item_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_Item_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_Item_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
