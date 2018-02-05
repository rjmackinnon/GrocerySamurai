namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class StoreItemProcessTest : BaseProcessTest<StoreItem>
    {
        [Test]
        public Task GetById_StoreItemProcess_Test()
        {
            return getById_TestHelper();
        }

        [Test]
        public Task GetAll_Defaults_StoreItemProcess_Test()
        {
            return getAll_Defaults_TestHelper();
        }

        [Test]
        public Task GetAll_PageSize_StoreItemProcess_Test()
        {
            return getAll_PageSize_TestHelper();
        }

        [Test]
        public Task AddRecord_StoreItemProcess_Test()
        {
            return addRecord_TestHelper();
        }

        [Test]
        public Task UpdateRecord_StoreItemProcess_Test()
        {
            return updateRecord_TestHelper();
        }

        [Test]
        public Task DeleteRecord_StoreItemProcess_Test()
        {
            return deleteRecord_TestHelper();
        }
    }
}
