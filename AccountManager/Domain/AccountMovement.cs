using System;

namespace AccountManager.Domain
{
    public class AccountMovement
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public String Description { get; set; }

        public double Amount { get; set; }

    }
}
