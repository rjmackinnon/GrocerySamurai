using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    public class ItemRepositoryTest : EntityRepositoryTest<Item>
    {
        public ItemRepositoryTest()
        {
            updateAction = u => u.Description = "Test";
        }

        [Test]
        public async Task GetById_ItemRepository_Test()
        {
            await get_ById_TestHelper();
        }

        [Test]
        public async Task GetByCriteria_All_ItemRepository_Test()
        {
            await get_ByCriteria_All_TestHelper();
        }

        [Test]
        public async Task GetByCriteria_Single_ItemRepository_Test()
        {
            await get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public async Task Add_ByEntity_ItemRepository_Test()
        {
            await add_ByEntity_TestHelper();
        }

        [Test]
        public async Task Add_ByEntities_ItemRepository_Test()
        {
            await add_ByEntities_TestHelper();
        }

        [Test]
        public async Task Update_ByEntity_ItemRepository_Test()
        {
            await update_ByEntity_TestHelper();
        }

        [Test]
        public async Task Update_ById_ItemRepository_Test()
        {
            await update_ById_TestHelper();
        }

        [Test]
        public async Task Update_ByEntities_ItemRepository_Test()
        {
            await update_ByEntities_TestHelper();
        }

        [Test]
        public async Task Update_ByCriteria_ItemRepository_Test()
        {
            await update_ByCriteria_TestHelper();
        }

        [Test]
        public async Task Delete_ByEntity_ItemRepository_Test()
        {
            await delete_ByEntity_TestHelperAsync();
        }

        [Test]
        public async Task Delete_ById_ItemRepository_Test()
        {
            await delete_ById_TestHelper();
        }

        [Test]
        public async Task Delete_ByEntities_ItemRepository_Test()
        {
            await delete_ByEntities_TestHelper();
        }

        [Test]
        public async Task Delete_ByCriteria_ItemRepository_Test()
        {
            await delete_ByCriteria_TestHelper();
        }
    }
}
