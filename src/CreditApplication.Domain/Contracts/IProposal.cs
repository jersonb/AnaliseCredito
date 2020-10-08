using System;

namespace CreditApplication.Domain.Contracts
{
    public interface IProposal
    {
        public decimal RequestedAmount { get; }
        public int Portion { get;  }
        public DateTime FirstPayment { get; }
        public CreditType CreditType { get;  }
    }
}