using AccountManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManager.DAL.EntityFramework
{
    class AccountRepository : Repository<Account, AccountManagerDbContext>, IAccountRepository
    {
        public AccountRepository(AccountManagerDbContext pContext) : base(pContext)
        {
        }

        public IEnumerable<Account> GetOverdrawnAccounts()
        {
            return from account in this.iDbContext.Set<Account>()
                   select new { Account = account, Balance = account.Movements.Sum(pMovement => pMovement.Amount) } into accountWithBalance
                   where accountWithBalance.Balance < 0 && Math.Abs(accountWithBalance.Balance) > accountWithBalance.Account.OverdraftLimit
                   select accountWithBalance.Account;
        }
    }
}
