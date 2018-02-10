namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    using System.Threading.Tasks;
    using Common;
    using Model.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class ItemProcessTest : BaseUserFilterProcessTest<Item>
    {
        [Test]
        public Task GetById_ItemProcess_Test()
        {
            return getById_TestHelper();
        }

        [Test]
        public Task GetAll_Defaults_ItemProcess_Test()
        {
            return getAll_Defaults_TestHelper();
        }

        [Test]
        public Task GetAll_PageSize_ItemProcess_Test()
        {
            return getAll_PageSize_TestHelper();
        }

        [Test]
        public Task GetAllByUser_Defaults_ItemProcess_Test()
        {
            return getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public Task GetAllByUser_PageSize_ItemProcess_Test()
        {
            return getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public Task AddRecord_ItemProcess_Test()
        {
            return addRecord_TestHelper();
        }

        [Test]
        public Task UpdateRecord_ItemProcess_Test()
        {
            return updateRecord_TestHelper();
        }

        [Test]
        public Task DeleteRecord_ItemProcess_Test()
        {
            return deleteRecord_TestHelper();
        }
    }
}
