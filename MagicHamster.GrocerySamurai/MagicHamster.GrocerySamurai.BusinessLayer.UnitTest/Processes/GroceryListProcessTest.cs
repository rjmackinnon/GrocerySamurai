using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    [TestFixture]
    public class GroceryListProcessTest : BaseProcessTest<GroceryList>
    {
        [Test]
        public void GetById_GroceryListProcess_Test()
        {
            getById_TestHelper();
        }

        [Test]
        public void GetAll_Defaults_GroceryListProcess_Test()
        {
            getAll_Defaults_TestHelper();
        }

        [Test]
        public void GetAll_PageSize_GroceryListProcess_Test()
        {
            getAll_PageSize_TestHelper();
        }

        [Test]
        public void AddRecord_GroceryListProcess_Test()
        {
            addRecord_TestHelper();
        }

        [Test]
        public void UpdateRecord_GroceryListProcess_Test()
        {
            updateRecord_TestHelper();
        }

        [Test]
        public void DeleteRecord_GroceryListProcess_Test()
        {
            deleteRecord_TestHelper();
        }
    }
}
