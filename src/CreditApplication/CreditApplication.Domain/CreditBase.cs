using CreditApplication.Domain.Property;
using System;

namespace CreditApplication.Domain
{
    internal abstract class CreditBase : ICredit
    {
        internal Proposal Proposal { get; private set; }

        public decimal Amount { get; private set; }
        public decimal Interest { get; private set; }
        public bool IsAproved { get; private set; }

        protected abstract Tax Tax { get; }
       
        internal static T GetInstance<T>(Proposal proposal) where T : CreditBase, new()
        {
            var credit = new T
            {
                Proposal = proposal
            };

            credit.Validate();
           
            credit.Interest = (credit.Tax.Value * credit.Proposal.Portion.Value);
            credit.Amount = credit.Proposal.RequestedAmount.Value + credit.Interest;
            credit.IsAproved = true;
            return credit;
        }


        protected virtual void Validate()
        {
            if (!Proposal.RequestedAmount.IsValid)
                throw new ArgumentException("Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1");

            if (!Proposal.Portion.IsValid)
                throw new ArgumentException("A quantidade de parcelas máximas é de 72x e a mínima é de 5x");

            if (!Proposal.FirstPayment.IsValid)
                throw new ArgumentException("A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)");

            if (!Tax.IsValid)
                throw new ArgumentException("Taxa Inválida");
        }
    }
}
