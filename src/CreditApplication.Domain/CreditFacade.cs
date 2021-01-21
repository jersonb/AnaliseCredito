using CreditApplication.Domain.Contracts;
using System;
using System.Diagnostics;

namespace CreditApplication.Domain
{
    public static class CreditFacade
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
            try
            {
                if (!Enum.IsDefined(conditions.CreditType))
                {
                    throw new ArgumentException($"{nameof(conditions.CreditType)} não é válido!");
                }

                return Credit.GetInstance(Proposal.SetProposal(conditions));
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}