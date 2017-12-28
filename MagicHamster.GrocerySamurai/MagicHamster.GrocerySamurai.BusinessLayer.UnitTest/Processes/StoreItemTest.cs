using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class StoreItemProcessTest : BaseProcessTest<StoreItem>
    {
        [Test]
        public void GetRecordById_StoreItem_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_StoreItem_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_StoreItem_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_StoreItem_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_StoreItem_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_StoreItem_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_StoreItem_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_StoreItem_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
