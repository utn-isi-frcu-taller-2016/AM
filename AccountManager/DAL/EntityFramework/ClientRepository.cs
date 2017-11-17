using AccountManager.Domain;

namespace AccountManager.DAL.EntityFramework
{
    /// <summary>
    /// Repositorio de entidad cliente
    /// </summary>
    class ClientRepository : Repository<Client, AccountManagerDbContext>, IClientRepository
    {
        public ClientRepository(AccountManagerDbContext pContext) : base(pContext)
        {
        }
    }
}
