using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace MagicHamster.GrocerySamurai.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        bool AutoCommit { get; set; }

        IRepository<T> GetRepository<T>()
            where T : Entity;

        void Commit();
        void Rollback();
        void CommitAll();
        void RollbackAll();
        int Save();
    }
}