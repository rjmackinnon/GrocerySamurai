using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class AisleProcessTest : BaseUserFilterProcessTest<Aisle>
    {
        [Test]
        public void GetById_AisleProcess_Test()
        {
            getById_TestHelper();
        }

        [Test]
        public void GetAll_Defaults_AisleProcess_Test()
        {
            getAll_Defaults_TestHelper();
        }

        [Test]
        public void GetAll_PageSize_AisleProcess_Test()
        {
            getAll_PageSize_TestHelper();
        }

        [Test]
        public void GetAllByUser_Defaults_AisleProcess_Test()
        {
            getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public void GetAllByUser_PageSize_AisleProcess_Test()
        {
            getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_AisleProcess_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_AisleProcess_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_AisleProcess_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
