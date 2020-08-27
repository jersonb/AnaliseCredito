using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class RealEstate : Credit
    {
        private const RateTax RATE_TAX = RateTax.Year;

        protected override Tax Tax => 0.09M;

        protected override void SetInterest(RateTax rateTax)
            => base.SetInterest(RATE_TAX);
    }
}