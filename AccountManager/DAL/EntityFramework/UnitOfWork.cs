using System;

namespace AccountManager.DAL.EntityFramework
{
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

        public IAccountRepository AccountRepository
        {
            get; private set;
        }

        public IClientRepository ClientRepository
        {
            get; private set;
        }

        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.iDbContext.Dispose();
        }
    }
}
