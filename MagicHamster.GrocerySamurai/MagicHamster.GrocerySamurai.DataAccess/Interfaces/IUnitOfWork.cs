namespace MagicHamster.GrocerySamurai.DataAccess.Interfaces
{
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using Model.Common;

    public interface IUnitOfWork
    {
        [UsedImplicitly]
        DbContext Context { get; }

        [UsedImplicitly]
        bool AutoCommit { get; set; }

        Task<IRepository<T>> GetRepository<T>()
            where T : Entity;

        [UsedImplicitly]
        Task Commit();

        [UsedImplicitly]
        Task Rollback();

        [UsedImplicitly]
        Task CommitAll();

        [UsedImplicitly]
        Task RollbackAll();

        Task<int> Save();
    }
}