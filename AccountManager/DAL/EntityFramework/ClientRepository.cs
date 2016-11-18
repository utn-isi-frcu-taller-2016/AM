using AccountManager.Domain;

namespace AccountManager.DAL.EntityFramework
{
    class ClientRepository : EFRepository<Client, AccountManagerDbContext>, IClientRepository
    {
        public ClientRepository(AccountManagerDbContext pContext) : base(pContext)
        {
        }
    }
}
