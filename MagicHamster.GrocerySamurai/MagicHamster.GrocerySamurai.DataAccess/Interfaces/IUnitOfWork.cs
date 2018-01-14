using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MagicHamster.GrocerySamurai.DataAccess.Interfaces
{
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