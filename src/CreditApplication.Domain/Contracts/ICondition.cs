using System;

namespace CreditApplication.Domain.Contracts
{
    public interface ICondition
    {
        public decimal RequestedAmount { get; }
        public int Portion { get;  }
        public DateTime FirstPayment { get; }
        public CreditType CreditType { get;  }
    }
}