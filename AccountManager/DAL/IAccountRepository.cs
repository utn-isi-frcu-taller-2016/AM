using AccountManager.Domain;
using System.Collections.Generic;

namespace AccountManager.DAL
{
    /// <summary>
    /// Interfaz de repositorio de cuentas
    /// </summary>
    interface IAccountRepository : IRepository<Account>
    {
        /// <summary>
        /// Obtencion de cuentas en rojo
        /// </summary>
        /// <returns>Cuentas</returns>
        IEnumerable<Account> GetOverdrawnAccounts();
    }
}
