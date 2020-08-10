using System;

namespace CreditApplication.Domain
{
    public class Conditions
    {
        public decimal RequestedAmount { get; set; }
        public int Portion { get; set; }
        public DateTime FirstPayment { get; set; }
        public CreditType CreditType { get; set; }
    }
}
