using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    public sealed class RealEstate : CreditBase
    {
        private const RateTax RATE_TAX = RateTax.Year;

        protected override Tax Tax => 0.09M;

        protected override void SetInterest(RateTax rateTax)
            => base.SetInterest(RATE_TAX);

    }
}
