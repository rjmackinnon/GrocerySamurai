using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class AppUserProcessTest : BaseProcessTest<AppUser>
    {
        [Test]
        public void GetRecordById_AppUser_Test()
        {
            getRecordById_TestHelper();
        }

        [Test]
        public void GetAllRecords_Defaults_AppUser_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetAllRecords_PageSize_AppUser_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void GetActiveRecords_Defaults_AppUser_Test()
        {
            getAllRecords_Defaults_TestHelper();
        }

        [Test]
        public void GetActiveRecords_PageSize_AppUser_Test()
        {
            getAllRecords_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_AppUser_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_AppUser_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_AppUser_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
