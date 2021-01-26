using CreditApplication.Domain.Contracts;
using System;
using System.Linq;

namespace CreditApplication
{
    public static class Extencion
    {
        /// <summary>
        /// Utilize este método para obter um crédito
        /// </summary>
        /// <param name="conditions"> Contrato</param>
        /// <returns>ICredit</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static ICredit GetCredit(this IProposal conditions)
        {
            var type = IProposal.TypesCredit.FirstOrDefault(c => c.Name.Equals(conditions.CreditType));

            _ = type ?? throw new ArgumentException($"{conditions.CreditType} não é compativel com uma classe de mesmo nome que herda de Credit!");

            return (ICredit)Activator.CreateInstance(type, conditions);
        }

        public static CreditDataObject ToViewObject(this ICredit credit)
        {
            return (CreditDataObject)Activator.CreateInstance(typeof(CreditDataObject), credit);
        }

        public static (CreditDataObject credit, ProposalDataObject proposal) ToViewObject(this IProposal proposal)
        {
            var vProposal = (ProposalDataObject)Activator.CreateInstance(typeof(ProposalDataObject), proposal);

            return (vProposal.GetCredit().ToViewObject(), vProposal);
        }
    }
}