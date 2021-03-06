﻿using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Property;
using System.Collections.Generic;
using System.Linq;

namespace CreditApplication.Domain
{
    internal abstract class Credit : ICredit
    {
        protected Credit(IProposal proposal)
        {
            Proposal = Proposal.SetProposal(proposal);
            Factory();
        }

        private const RateTax RATE_TAX_DEFAULT = RateTax.Month;

        protected abstract Tax Tax { get; }

        internal Proposal Proposal { get; private set; }

        public decimal Amount { get; private set; }

        public decimal Interest { get; private set; }

        public bool Aproved => !Notifications.Any();

        public IEnumerable<string> Notifications { get; private set; } = new List<string>();

        private void Factory()
        {
            Validate();
            SetInterest(RATE_TAX_DEFAULT);
            SetAmount();
        }

        private void SetAmount()
            => Amount = Proposal.RequestedAmount.Value + Interest;

        protected virtual void SetInterest(RateTax rateTax)
        {
            Interest = rateTax switch
            {
                RateTax.Year => Proposal.RequestedAmount.Value * Tax.Value * (Proposal.Portion.Value / 12),//verificar regra
                _ => Proposal.RequestedAmount.Value * Tax.Value * Proposal.Portion.Value
            };
        }

        protected virtual void AddNotification(string notification)
        {
            Notifications = Notifications.Append(notification);
        }

        protected virtual void Validate()
        {
            Notifications = Notifications.Concat(Proposal.Notifications.Select(n => n.Message));
        }
    }
}