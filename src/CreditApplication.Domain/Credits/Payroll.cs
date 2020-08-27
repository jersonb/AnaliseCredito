using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Payroll : Credit
    {
        protected override Tax Tax => 0.01M;
    }
}