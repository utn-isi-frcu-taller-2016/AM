using System;
using System.Collections.Generic;

namespace AccountManager.Domain
{
    public class Account
    {

        public int Id { get; set; }

        public String Name { get; set; }

        public double OverdraftLimit { get; set; }

        public virtual Client Client { get; set; }

        public virtual IList<AccountMovement> Movements { get; set; }

    }
}
