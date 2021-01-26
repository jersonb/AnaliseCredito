using CreditApplication.Domain.Contracts;
using System;
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

    public class ProposalDataObject : IProposal
    {
        public ProposalDataObject(IProposal proposal)
        {
            RequestedAmount = proposal.RequestedAmount;
            Portion = proposal.Portion;
            FirstPayment = proposal.FirstPayment;
            CreditType = proposal.CreditType;
        }

        public decimal RequestedAmount { get; set; }

        public int Portion { get; set; }

        public DateTime FirstPayment { get; set; }

        public string CreditType { get; set; }
    }
}