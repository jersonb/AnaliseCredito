using CreditApplication.Domain.Contracts;
using System;

namespace CreditApplication
{
    public abstract class ConditionRequest : IProposal
    {
        public decimal RequestedAmount { get; set; }

        public int Portion { get; set; }

        public DateTime FirstPayment { get; set; }

        abstract public string CreditType { get; }
    }
}