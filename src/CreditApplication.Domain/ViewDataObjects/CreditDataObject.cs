using CreditApplication.Domain.Contracts;
using System.Collections.Generic;

namespace CreditApplication
{
    public class CreditDataObject : ICredit
    {
        public CreditDataObject(ICredit credit)
        {
            Amount = credit.Amount;
            Interest = credit.Interest;
            Aproved = credit.Aproved;
            Notifications = credit.Notifications;
        }

        public decimal Amount { get; set; }

        public decimal Interest { get; set; }

        public bool Aproved { get; set; }

        public IEnumerable<string> Notifications { get; set; }
    }
}