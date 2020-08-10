using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    public class Payroll : CreditBase
    {
        protected override Tax Tax => 0.01M;
    }
}
