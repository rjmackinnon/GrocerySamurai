namespace MagicHamster.GrocerySamurai.DataAccess.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Model.Common;

    public interface IUnitOfWork
    {
        DbContext Context { get; }

        bool AutoCommit { get; set; }

        Task<IRepository<T>> GetRepository<T>()
            where T : Entity;

        Task Commit();

        Task Rollback();

        Task CommitAll();

        Task RollbackAll();

        Task<int> Save();
    }
}