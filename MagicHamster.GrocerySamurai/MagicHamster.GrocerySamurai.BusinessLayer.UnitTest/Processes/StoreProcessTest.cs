using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class StoreProcessTest : BaseUserFilterProcessTest<Store>
    {
        [Test]
        public void GetById_StoreProcess_Test()
        {
            getById_TestHelper();
        }

        [Test]
        public void GetAll_Defaults_StoreProcess_Test()
        {
            getAll_Defaults_TestHelper();
        }

        [Test]
        public void GetAll_PageSize_StoreProcess_Test()
        {
            getAll_PageSize_TestHelper();
        }

        [Test]
        public void GetAllByUser_Defaults_StoreProcess_Test()
        {
            getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public void GetAllByUser_PageSize_StoreProcess_Test()
        {
            getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_StoreProcess_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_StoreProcess_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_StoreProcess_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
