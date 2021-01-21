﻿using CreditApplication.Domain.Contracts;
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
            => Credit.GetInstance(Proposal.SetProposal(conditions), GetCredit(conditions.CreditType));

        private static Credit GetCredit(CreditType creditType)
        {
            try
            {
                if (!Enum.IsDefined(creditType))
                {
                    throw new ArgumentException($"{nameof(creditType)} não é válido!");
                }

                var type = typeof(Credit).Assembly
                                        .GetTypes()
                                        .FirstOrDefault(t =>
                                            t.IsSubclassOf(typeof(Credit))
                                            && t.IsNotPublic
                                            && !t.IsAbstract
                                            && creditType.ToString().Equals(t.Name));

                if (type is null)
                {
                    throw new ArgumentException($"{nameof(creditType)} não é compativel com uma classe de mesmo nome que herda de Credit!");
                }

                return (Credit)Activator.CreateInstance(type);
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