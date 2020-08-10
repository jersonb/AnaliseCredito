using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    public sealed class Personal : CreditBase
    {
        protected override Tax Tax => 0.03M;
    }
}
