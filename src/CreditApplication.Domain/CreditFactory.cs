using CreditApplication.Domain.Contracts;
using CreditApplication.Domain.Credits;
using CreditApplication.Domain.Property;

namespace CreditApplication.Domain
{
    public static class CreditFactory
    {
        public static ICredit GetCredit(this ICondition conditions)
        {
            var proposal = Proposal.GetProposal(conditions.RequestedAmount, conditions.Portion, conditions.FirstPayment);

            return conditions.CreditType switch
            {
                CreditType.Direct => Credit.GetInstance<Direct>(proposal),
                CreditType.Business => Credit.GetInstance<Business>(proposal),
                CreditType.Payroll => Credit.GetInstance<Payroll>(proposal),
                CreditType.Personal => Credit.GetInstance<Personal>(proposal),
                CreditType.RealEstate => Credit.GetInstance<RealEstate>(proposal),
                _ => null
            };
        }
    }
}