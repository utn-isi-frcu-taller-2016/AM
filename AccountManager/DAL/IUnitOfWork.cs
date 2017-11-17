using System;

namespace AccountManager.DAL
{
    interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Repositorio de cuentas
        /// </summary>
        IAccountRepository AccountRepository { get; }

        /// <summary>
        /// Repositorio de Clientes
        /// </summary>
        IClientRepository ClientRepository { get; }

        /// <summary>
        /// Persiste los cambios
        /// </summary>
        void Complete();

    }
}
