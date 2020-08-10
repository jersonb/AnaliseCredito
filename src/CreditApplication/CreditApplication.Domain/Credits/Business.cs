using CreditApplication.Domain.Property;
using System;

namespace CreditApplication.Domain.Credits
{
    public class Business : CreditBase
    {
        protected override Tax Tax => 0.05M;
        private const int REQUEST_MIN = 15_000;
        protected override void Validate()
        {
            base.Validate();
            if (Proposal.RequestedAmount.Value <= REQUEST_MIN)
                throw new ArgumentException($"Valor solicitado não pode ser menor que {REQUEST_MIN:C2}");
        }
    }
}
