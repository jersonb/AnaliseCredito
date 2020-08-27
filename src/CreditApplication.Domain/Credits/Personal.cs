using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Personal : Credit
    {
        protected override Tax Tax => 0.03M;
    }
}