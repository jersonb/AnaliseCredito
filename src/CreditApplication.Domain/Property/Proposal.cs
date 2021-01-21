﻿using CreditApplication.Domain.Contracts;
using Flunt.Notifications;

namespace CreditApplication.Domain.Property
{
    internal class Proposal : Notifiable
    {
        public RequestedAmount RequestedAmount { get; }
        public Portion Portion { get; }
        public FirstPayment FirstPayment { get; }

        private Proposal(IProposal proposal)
        {
            RequestedAmount = proposal.RequestedAmount;
            Portion = proposal.Portion;
            FirstPayment = proposal.FirstPayment;
            Validate();
        }

        internal static Proposal GetProposal(IProposal proposal)
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