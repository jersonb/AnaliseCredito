using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    public class RealEstate : CreditBase
    {
        protected override Tax Tax => 0.09M;
    }
}
