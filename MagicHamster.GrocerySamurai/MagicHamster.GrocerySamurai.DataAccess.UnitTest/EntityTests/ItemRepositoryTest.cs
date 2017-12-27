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
        public void GetById_Item_Test()
        {
            get_ById_TestHelper();
        }

        [Test]
        public void GetByCriteria_All_Item_Test()
        {
            get_ByCriteria_All_TestHelper();
        }

        [Test]
        public void GetByCriteria_Single_Item_Test()
        {
            get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public void Add_ByEntity_Item_Test()
        {
            add_ByEntity_TestHelper();
        }

        [Test]
        public void Add_ByEntities_Item_Test()
        {
            add_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByEntity_Item_Test()
        {
            update_ByEntity_TestHelper();
        }

        [Test]
        public void Update_ById_Item_Test()
        {
            update_ById_TestHelper();
        }

        [Test]
        public void Update_ByEntities_Item_Test()
        {
            update_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByCriteria_Item_Test()
        {
            update_ByCriteria_TestHelper();
        }

        [Test]
        public void Delete_ByEntity_Item_Test()
        {
            delete_ByEntity_TestHelper();
        }

        [Test]
        public void Delete_ById_Item_Test()
        {
            delete_ById_TestHelper();
        }

        [Test]
        public void Delete_ByEntities_Item_Test()
        {
            delete_ByEntities_TestHelper();
        }

        [Test]
        public void Delete_ByCriteria_Item_Test()
        {
            delete_ByCriteria_TestHelper();
        }
    }
}
