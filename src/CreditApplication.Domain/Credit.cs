using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Property;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace CreditApplication.Domain
{
    internal abstract class Credit : Notifiable, ICredit
    {
        private const RateTax RATE_TAX_DEFAULT = RateTax.Month;

        protected abstract Tax Tax { get; }

        internal Proposal Proposal { get; private set; }

        public decimal Amount { get; private set; }

        public decimal Interest { get; private set; }

        public bool Aproved => !Notifications.Any();

        public List<string> Notifications { get; private set; }

        internal static T GetInstance<T>(Proposal proposal) where T : Credit, new()
        {
            var credit = new T
            {
                Proposal = proposal
            };

            credit.Validate();
            credit.SetInterest(RATE_TAX_DEFAULT);
            credit.SetAmount();

            return credit;
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

        //protected void AddNotification(Notification notification)
        //  => Notifications.Add(notification.Message);

        protected virtual void Validate()
        {
            Notifications = new List<string>();

            if (Proposal.RequestedAmount.Contract.Invalid)
                foreach (var notification in Proposal.RequestedAmount.Contract.Notifications)
                    AddNotification(notification);

            if (Proposal.Portion.Contract.Invalid)
                foreach (var notification in Proposal.Portion.Contract.Notifications)
                    AddNotification(notification);

            if (Proposal.FirstPayment.Contract.Invalid)
                foreach(var notification in Proposal.FirstPayment.Contract.Notifications)
                    AddNotification(notification);

            if (Tax.Contract.Invalid)
                foreach (var notification in Tax.Contract.Notifications)
                    AddNotification(notification);
        }
    }
}