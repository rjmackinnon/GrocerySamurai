using MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    public class StoreItemRepositoryTest : EntityRepositoryTest<StoreItem>
    {
        public StoreItemRepositoryTest()
        {
            updateAction = u => u.AisleId = 1;
        }

        [Test]
        public void GetById_StoreItemRepository_Test()
        {
            get_ById_TestHelper();
        }

        [Test]
        public void GetByCriteria_All_StoreItemRepository_Test()
        {
            get_ByCriteria_All_TestHelper();
        }

        [Test]
        public void GetByCriteria_Single_StoreItemRepository_Test()
        {
            get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public void Add_ByEntity_StoreItemRepository_Test()
        {
            add_ByEntity_TestHelper();
        }

        [Test]
        public void Add_ByEntities_StoreItemRepository_Test()
        {
            add_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByEntity_StoreItemRepository_Test()
        {
            update_ByEntity_TestHelper();
        }

        [Test]
        public void Update_ById_StoreItemRepository_Test()
        {
            update_ById_TestHelper();
        }

        [Test]
        public void Update_ByEntities_StoreItemRepository_Test()
        {
            update_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByCriteria_StoreItemRepository_Test()
        {
            update_ByCriteria_TestHelper();
        }

        [Test]
        public void Delete_ByEntity_StoreItemRepository_Test()
        {
            delete_ByEntity_TestHelper();
        }

        [Test]
        public void Delete_ById_StoreItemRepository_Test()
        {
            delete_ById_TestHelper();
        }

        [Test]
        public void Delete_ByEntities_StoreItemRepository_Test()
        {
            delete_ByEntities_TestHelper();
        }

        [Test]
        public void Delete_ByCriteria_StoreItemRepository_Test()
        {
            delete_ByCriteria_TestHelper();
        }
    }
}
