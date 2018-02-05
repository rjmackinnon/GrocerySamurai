namespace MagicHamster.GrocerySamurai.BusinessLayer.UnitTest.Common
{
    using System.Threading.Tasks;
    using BusinessLayer.Processes;
    using Model.Common;
    using NUnit.Framework;

    [TestFixture]
    public abstract class BaseUserFilterProcessTest<T> : BaseProcessTest<T>
        where T : UserFilter, new()
    {
        protected BaseUserFilterProcess<T> userFilterProcess { get; set; }

        public override void Init()
        {
            base.Init();
            userFilterProcess = new BaseUserFilterProcess<T>(unitOfWorkMock.Object);
        }

        protected async Task getAllByUser_Defaults_TestHelper()
        {
            var result = await userFilterProcess.GetAllByUser("test").ConfigureAwait(false);

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
            Assert.AreEqual(4, result[3].Id);
        }

        protected async Task getAllByUser_PageSize_TestHelper()
        {
            const int pageSize = 2;

            var result = await userFilterProcess.GetAllByUser("test", null, null, pageSize).ConfigureAwait(false);

            Assert.Greater(result.Count, 0);
            Assert.LessOrEqual(pageSize, result.Count);
        }
    }
}
