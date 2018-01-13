using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class ItemProcessTest : BaseUserFilterProcessTest<Item>
    {
        [Test]
        public void GetById_ItemProcess_Test()
        {
            getById_TestHelper();
        }

        [Test]
        public void GetAll_Defaults_ItemProcess_Test()
        {
            getAll_Defaults_TestHelper();
        }

        [Test]
        public void GetAll_PageSize_ItemProcess_Test()
        {
            getAll_PageSize_TestHelper();
        }

        [Test]
        public void GetAllByUser_Defaults_ItemProcess_Test()
        {
            getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public void GetAllByUser_PageSize_ItemProcess_Test()
        {
            getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_ItemProcess_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_ItemProcess_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_ItemProcess_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
