using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Payroll : Credit
    {
        public Payroll(IProposal proposal) : base(proposal)
        {
        }

        protected override Tax Tax => 0.01M;
    }
}