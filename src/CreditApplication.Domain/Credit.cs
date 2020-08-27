using CreditApplication.Domain.Credits;
using CreditApplication.Domain.Property;

namespace CreditApplication.Domain
{
    public static class Credit
    {
        public static ICredit GetCredit(this Conditions conditions)
        {
            var proposal = Proposal.GetProposal(conditions.RequestedAmount, conditions.Portion, conditions.FirstPayment);

            return conditions.CreditType switch
            {
                CreditType.Direct => CreditBase.GetInstance<Direct>(proposal),
                CreditType.Business => CreditBase.GetInstance<Business>(proposal),
                CreditType.Payroll => CreditBase.GetInstance<Payroll>(proposal),
                CreditType.Personal => CreditBase.GetInstance<Personal>(proposal),
                CreditType.RealEstate => CreditBase.GetInstance<RealEstate>(proposal),
                _ => null
            };
        }
    }
}
