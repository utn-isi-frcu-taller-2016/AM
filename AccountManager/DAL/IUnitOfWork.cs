using System;

namespace AccountManager.DAL
{
    interface IUnitOfWork : IDisposable
    {

        IAccountRepository AccountRepository { get; }

        IClientRepository ClientRepository { get; }

        void Complete();

    }
}
