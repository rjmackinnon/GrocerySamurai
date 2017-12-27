using MagicHamster.GrocerySamurai.DataAccess.UnitTest.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using NUnit.Framework;

namespace MagicHamster.GrocerySamurai.DataAccess.UnitTest.EntityTests
{
    public class AppUserRepositoryTest : EntityRepositoryTest<AppUser>
    {
        public AppUserRepositoryTest()
        {
            updateAction = u => u.LastName = "Test";
        }

        [Test]
        public void GetById_AppUser_Test()
        {
            get_ById_TestHelper();
        }

        [Test]
        public void GetByCriteria_All_AppUser_Test()
        {
            get_ByCriteria_All_TestHelper();
        }

        [Test]
        public void GetByCriteria_Single_AppUser_Test()
        {
            get_ByCriteria_Single_TestHelper();
        }

        [Test]
        public void Add_ByEntity_AppUser_Test()
        {
            add_ByEntity_TestHelper();
        }

        [Test]
        public void Add_ByEntities_AppUser_Test()
        {
            add_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByEntity_AppUser_Test()
        {
            update_ByEntity_TestHelper();
        }

        [Test]
        public void Update_ById_AppUser_Test()
        {
            update_ById_TestHelper();
        }

        [Test]
        public void Update_ByEntities_AppUser_Test()
        {
            update_ByEntities_TestHelper();
        }

        [Test]
        public void Update_ByCriteria_AppUser_Test()
        {
            update_ByCriteria_TestHelper();
        }

        [Test]
        public void Delete_ByEntity_AppUser_Test()
        {
            delete_ByEntity_TestHelper();
        }

        [Test]
        public void Delete_ById_AppUser_Test()
        {
            delete_ById_TestHelper();
        }

        [Test]
        public void Delete_ByEntities_AppUser_Test()
        {
            delete_ByEntities_TestHelper();
        }

        [Test]
        public void Delete_ByCriteria_AppUser_Test()
        {
            delete_ByCriteria_TestHelper();
        }
    }
}
