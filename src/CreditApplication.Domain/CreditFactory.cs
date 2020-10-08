using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Credits;
using CreditApplication.Domain.Property;

namespace CreditApplication.Domain
{
    public static class CreditFactory
    {
        public static ICredit GetCredit(this IProposal conditions)
        => conditions.CreditType switch
        {
            CreditType.Direct => conditions.GetCredit<Direct>(),
            CreditType.Business => conditions.GetCredit<Business>(),
            CreditType.Payroll => conditions.GetCredit<Payroll>(),
            CreditType.Personal => conditions.GetCredit<Personal>(),
            CreditType.RealEstate => conditions.GetCredit<RealEstate>(),
            _ => null
        };

        private static ICredit GetCredit<T>(this IProposal condition) where T : Credit, new()
            => Credit.GetInstance<T>(Proposal.GetProposal(condition));
    }
}