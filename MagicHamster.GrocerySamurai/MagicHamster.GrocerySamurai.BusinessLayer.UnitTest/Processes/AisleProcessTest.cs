using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class AisleProcessTest : BaseProcessTest<Aisle>
    {
        [Test]
        public void GetRecordById_Aisle_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_Aisle_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_Aisle_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_Aisle_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_Aisle_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_Aisle_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_Aisle_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_Aisle_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
