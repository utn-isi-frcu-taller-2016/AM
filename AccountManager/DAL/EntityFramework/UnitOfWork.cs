using System;

namespace AccountManager.DAL.EntityFramework
{
    /// <summary>
    /// Implementación del patrón Unidad de Trabajo
    /// </summary>
    class UnitOfWork : IUnitOfWork
    {

        private readonly AccountManagerDbContext iDbContext;

        public UnitOfWork(AccountManagerDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }

            this.iDbContext = pContext;
            this.ClientRepository = new ClientRepository(this.iDbContext);
            this.AccountRepository = new AccountRepository(this.iDbContext);
        }

        /// <summary>
        /// Repositorio de cuentas
        /// </summary>
        public IAccountRepository AccountRepository
        {
            get; private set;
        }

        /// <summary>
        /// Repositorio de Clientes
        /// </summary>
        public IClientRepository ClientRepository
        {
            get; private set;
        }

        /// <summary>
        /// Persiste los cambios
        /// </summary>
        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }

        /// <summary>
        /// Elimina los recursos tomados
        /// </summary>
        public void Dispose()
        {
            this.iDbContext.Dispose();
        }
    }
}
