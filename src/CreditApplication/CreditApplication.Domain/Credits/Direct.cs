using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    public sealed class Direct : CreditBase
    {
        protected override Tax Tax => 0.02M;
    }
}
