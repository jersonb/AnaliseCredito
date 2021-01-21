using CreditApplication.Domain.Property;
using Flunt.Validations;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Business : Credit
    {
        protected override Tax Tax => 0.05M;
        private const int REQUEST_MIN = 15_000;

        protected override void Validate()
        {
            base.Validate();
            
            var contract = new Contract()
                            .IsGreaterOrEqualsThan(Proposal.RequestedAmount.Value 
                            , REQUEST_MIN
                            , nameof(Business)
                            , $"Valor solicitado não pode ser menor que {REQUEST_MIN:C2}");
         
            if (contract.Invalid)
                foreach(var notification in contract.Notifications)
                    AddNotification(notification);
        }
    }
}