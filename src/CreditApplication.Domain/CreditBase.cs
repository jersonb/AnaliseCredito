using CreditApplication.Domain.Property;
using System.Collections.Generic;
using System.Linq;

namespace CreditApplication.Domain
{
    public abstract class CreditBase : ICredit
    {
        private const RateTax RATE_TAX_DEFAULT = RateTax.Month;

        protected abstract Tax Tax { get; }

        internal Proposal Proposal { get; private set; }

        public decimal Amount { get; private set; }

        public decimal Interest { get; private set; }

        public bool Aproved => !Notifications.Any();

        public List<string> Notifications { get; private set; }

        public static T GetInstance<T>(Proposal proposal) where T : CreditBase, new()
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

        protected void AddNotification(string message)
          => Notifications.Add(message);

        protected virtual void Validate()
        {
            Notifications = new List<string>();

            if (!Proposal.RequestedAmount.IsValid)
                AddNotification("Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1");

            if (!Proposal.Portion.IsValid)
                AddNotification("A quantidade de parcelas máximas é de 72x e a mínima é de 5x");

            if (!Proposal.FirstPayment.IsValid)
                AddNotification("A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)");

            if (!Tax.IsValid)
                AddNotification("Taxa Inválida");
        }
    }
}
