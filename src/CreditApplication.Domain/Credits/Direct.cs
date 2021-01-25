using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Property;

namespace CreditApplication.Domain.Credits
{
    internal sealed class Direct : Credit
    {
        public Direct(IProposal proposal) : base(proposal)
        {
        }

        protected override Tax Tax => 0.02M;
    }
}