using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class StoreItemProcessTest : BaseProcessTest<StoreItem>
    {
        [Test]
        public void GetById_StoreItemProcess_Test()
        {
            getById_TestHelper();
        }

        [Test]
        public void GetAll_Defaults_StoreItemProcess_Test()
        {
            getAll_Defaults_TestHelper();
        }

        [Test]
        public void GetAll_PageSize_StoreItemProcess_Test()
        {
            getAll_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_StoreItemProcess_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_StoreItemProcess_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_StoreItemProcess_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
