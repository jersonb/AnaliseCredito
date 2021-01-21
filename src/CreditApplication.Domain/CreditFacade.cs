using CreditApplication.Domain.Contracts;
using System;
using System.Diagnostics;
using System.Linq;

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

                var type = typeof(Credit).Assembly
                                    .GetTypes()
                                    .FirstOrDefault(t => t.IsSubclassOf(typeof(Credit))
                                                         && t.IsNotPublic
                                                         && !t.IsAbstract
                                                         && conditions.CreditType
                                                                     .ToString()
                                                                     .Equals(t.Name));

                if (type is null)
                {
                    throw new ArgumentException($"{nameof(conditions.CreditType)} não é compativel com uma classe de mesmo nome que herda de Credit!");
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

        internal static Credit GetCredit(CreditType creditType)
        {
            var type = typeof(Credit).Assembly
                                    .GetTypes()
                                    .FirstOrDefault(t =>
                                        t.IsSubclassOf(typeof(Credit))
                                        && t.IsNotPublic
                                        && !t.IsAbstract
                                        && creditType.ToString().Equals(t.Name));

            return (Credit)Activator.CreateInstance(type);
        }
    }
}