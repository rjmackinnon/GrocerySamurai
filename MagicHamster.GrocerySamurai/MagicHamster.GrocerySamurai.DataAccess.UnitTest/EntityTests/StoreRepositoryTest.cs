using MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    public class StoreRepositoryTest : EntityRepositoryTest<Store>
    {
        public StoreRepositoryTest()
        {
            updateAction = u => u.Description = "Test";
        }

        [Test]
        public void GetById_Store_Test()
        {
            get_ById_TestHelper();
        }

        [Test]
        public void GetByCriteria_All_Store_Test()
        {
            get_ByCriteria_All_TestHelper();
        }

        [Test]
        public void GetByCriteria_Single_Store_Test()
        {
            get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public void Add_ByEntity_Store_Test()
        {
            add_ByEntity_TestHelper();
        }

        [Test]
        public void Add_ByEntities_Store_Test()
        {
            add_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByEntity_Store_Test()
        {
            update_ByEntity_TestHelper();
        }

        [Test]
        public void Update_ById_Store_Test()
        {
            update_ById_TestHelper();
        }

        [Test]
        public void Update_ByEntities_Store_Test()
        {
            update_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByCriteria_Store_Test()
        {
            update_ByCriteria_TestHelper();
        }

        [Test]
        public void Delete_ByEntity_Store_Test()
        {
            delete_ByEntity_TestHelper();
        }

        [Test]
        public void Delete_ById_Store_Test()
        {
            delete_ById_TestHelper();
        }

        [Test]
        public void Delete_ByEntities_Store_Test()
        {
            delete_ByEntities_TestHelper();
        }

        [Test]
        public void Delete_ByCriteria_Store_Test()
        {
            delete_ByCriteria_TestHelper();
        }
    }
}
