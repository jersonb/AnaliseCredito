using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Property;
using Flunt.Notifications;

namespace CreditApplication.Domain
{
    internal sealed class Proposal : Notifiable
    {
        public RequestedAmount RequestedAmount { get; }
        public Portion Portion { get; }
        public FirstPayment FirstPayment { get; }
        public CreditType CreditType { get; }

        private Proposal(IProposal proposal)
        {
            RequestedAmount = proposal.RequestedAmount;
            Portion = proposal.Portion;
            FirstPayment = proposal.FirstPayment;
            CreditType = proposal.CreditType;

            Validate();
        }

        internal static Proposal SetProposal(IProposal proposal)
            => new Proposal(proposal);

        private void Validate()
        {
            foreach (var notification in RequestedAmount.Contract.Notifications)
                AddNotification(notification);

            foreach (var notification in Portion.Contract.Notifications)
                AddNotification(notification);

            foreach (var notification in FirstPayment.Contract.Notifications)
                AddNotification(notification);
        }
    }
}