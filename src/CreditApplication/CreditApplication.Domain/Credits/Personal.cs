using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    public class Personal : CreditBase
    {
        protected override Tax Tax => 0.03M;
    }
}
