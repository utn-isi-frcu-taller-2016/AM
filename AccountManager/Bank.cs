using AccountManager.DAL.EntityFramework;
using AccountManager.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager
{
    /// <summary>
    /// Clase controladora de fachada del sistema
    /// </summary>
    class Bank
    {
        /// <summary>
        /// Obtiene las cuentas de un cliente
        /// </summary>
        /// <param name="pClientId">Id del cliente</param>
        /// <returns>Cuentas del cliente</returns>
        public IEnumerable<AccountDTO> GetClientAccounts(int pClientId)
        {
            List<AccountDTO> mAccounts = new List<AccountDTO>();

            using (var bUnitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                // Se obtiene el usuario
                var mClient = bUnitOfWork.ClientRepository.Get(pClientId);

                // Se iteran por cada cuenta del usuario
                foreach (var bAccount in mClient.Accounts)
                {
                    // Se genera el objecto DTO en base al objeto de Dominio
                    mAccounts.Add(new AccountDTO
                    {
                        Balance = bAccount.GetBalance(),
                        Id = bAccount.Id,
                        Name = bAccount.Name,
                        OverDraftLimit = bAccount.OverdraftLimit
                    });
                }

                bUnitOfWork.Complete();
            }

            // Se devuelven las cuentas
            return mAccounts;

      
                
        }

        /// <summary>
        /// Obtiene los movimientos de la cuenta
        /// </summary>
        /// <param name="pAccountId">Id del movimiento de la cuenta</param>
        /// <returns>Movimientos de la cuenta</returns>
        public IEnumerable<AccountMovementDTO> GetAccountMovements(int pAccountId)
        {
            List<AccountMovementDTO> mAccountMovements = new List<AccountMovementDTO>();

            using (var bUnitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                // Se obtiene el usuario
                var mAccount = bUnitOfWork.AccountRepository.Get(pAccountId);

                // Se iteran por cada movimiento de la cuenta
                foreach (var bAccount in mAccount.Movements)
                {
                    // Se genera el objecto DTO en base al objeto de Dominio
                    mAccountMovements.Add(new AccountMovementDTO
                    {
                        Amount = bAccount.Amount,
                        Id = bAccount.Id,
                        Date = bAccount.Date,
                        Description = bAccount.Description
                    });
                }

                bUnitOfWork.Complete();
            }

            // Se devuelven los movimentos de cuentas
            return mAccountMovements;
        }


    }
}
