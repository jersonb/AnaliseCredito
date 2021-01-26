using CreditApplication.Domain.Contracts;
using System;

namespace CreditApplication
{
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