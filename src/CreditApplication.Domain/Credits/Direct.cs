using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Direct : Credit
    {
        protected override Tax Tax => 0.02M;
    }
}