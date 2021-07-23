using System;

namespace Paschoalotto.Devedor.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        void BeginTransaction();
        void BeginCommit();
        void BeginRollback();
    }
}
