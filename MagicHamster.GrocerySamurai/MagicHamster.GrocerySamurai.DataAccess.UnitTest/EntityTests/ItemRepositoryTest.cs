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
        public void GetById_ItemRepository_Test()
        {
            get_ById_TestHelper();
        }

        [Test]
        public void GetByCriteria_All_ItemRepository_Test()
        {
            get_ByCriteria_All_TestHelper();
        }

        [Test]
        public void GetByCriteria_Single_ItemRepository_Test()
        {
            get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public void Add_ByEntity_ItemRepository_Test()
        {
            add_ByEntity_TestHelper();
        }

        [Test]
        public void Add_ByEntities_ItemRepository_Test()
        {
            add_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByEntity_ItemRepository_Test()
        {
            update_ByEntity_TestHelper();
        }

        [Test]
        public void Update_ById_ItemRepository_Test()
        {
            update_ById_TestHelper();
        }

        [Test]
        public void Update_ByEntities_ItemRepository_Test()
        {
            update_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByCriteria_ItemRepository_Test()
        {
            update_ByCriteria_TestHelper();
        }

        [Test]
        public void Delete_ByEntity_ItemRepository_Test()
        {
            delete_ByEntity_TestHelper();
        }

        [Test]
        public void Delete_ById_ItemRepository_Test()
        {
            delete_ById_TestHelper();
        }

        [Test]
        public void Delete_ByEntities_ItemRepository_Test()
        {
            delete_ByEntities_TestHelper();
        }

        [Test]
        public void Delete_ByCriteria_ItemRepository_Test()
        {
            delete_ByCriteria_TestHelper();
        }
    }
}
