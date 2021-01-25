using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Personal : Credit
    {
        public Personal(IProposal proposal) : base(proposal)
        {
        }

        protected override Tax Tax => 0.03M;
    }
}