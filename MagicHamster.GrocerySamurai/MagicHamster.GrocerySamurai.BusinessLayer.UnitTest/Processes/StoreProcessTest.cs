using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class StoreProcessTest : BaseProcessTest<Store>
    {
        [Test]
        public void GetRecordById_Store_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_Store_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_Store_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_Store_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_Store_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_Store_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_Store_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_Store_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
