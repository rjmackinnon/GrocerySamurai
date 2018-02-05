namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Processes
{
    using System.Threading.Tasks;
    using Common;
    using Model.Entities;
    using NUnit.Framework;

    [TestFixture]
    public class AisleProcessTest : BaseUserFilterProcessTest<Aisle>
    {
        [Test]
        public Task GetById_AisleProcess_Test()
        {
            return getById_TestHelper();
        }

        [Test]
        public Task GetAll_Defaults_AisleProcess_Test()
        {
            return getAll_Defaults_TestHelper();
        }

        [Test]
        public Task GetAll_PageSize_AisleProcess_Test()
        {
            return getAll_PageSize_TestHelper();
        }

        [Test]
        public Task GetAllByUser_Defaults_AisleProcess_Test()
        {
            return getAllByUser_Defaults_TestHelper();
        }

        [Test]
        public Task GetAllByUser_PageSize_AisleProcess_Test()
        {
            return getAllByUser_PageSize_TestHelper();
        }

        [Test]
        public Task AddRecord_AisleProcess_Test()
        {
            return addRecord_TestHelper();
        }

        [Test]
        public Task UpdateRecord_AisleProcess_Test()
        {
            return updateRecord_TestHelper();
        }

        [Test]
        public Task DeleteRecord_AisleProcess_Test()
        {
            return deleteRecord_TestHelper();
        }
    }
}
