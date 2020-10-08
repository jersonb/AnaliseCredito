using CreditApplication.Domain.Contracts;

namespace CreditApplication.Domain.Property
{
    internal struct Proposal
    {
        public RequestedAmount RequestedAmount { get; }
        public Portion Portion { get; }
        public FirstPayment FirstPayment { get; }

        private Proposal(IProposal proposal)
        {
            RequestedAmount = proposal.RequestedAmount;
            Portion = proposal.Portion;
            FirstPayment = proposal.FirstPayment;
        }

        internal static Proposal GetProposal(IProposal proposal)
            => new Proposal(proposal);
    }
}