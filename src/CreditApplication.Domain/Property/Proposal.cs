using CreditApplication.Domain.Contracts;
using Flunt.Validations;

namespace CreditApplication.Domain.Property
{
    internal struct Proposal
    {
        public RequestedAmount RequestedAmount { get; }
        public Portion Portion { get; }
        public FirstPayment FirstPayment { get; }

        public Contract Contract {get;}

        private Proposal(IProposal proposal)
        {
            RequestedAmount = proposal.RequestedAmount;
            Portion = proposal.Portion;
            FirstPayment = proposal.FirstPayment;
            Contract = RequestedAmount.Contract;

        }

        internal static Proposal GetProposal(IProposal proposal)
            => new Proposal(proposal);
    }
}