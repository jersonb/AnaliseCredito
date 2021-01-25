using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditApplication.Domain.Contracts
{
    public interface IProposal
    {
        public decimal RequestedAmount { get; }
        public int Portion { get; }
        public DateTime FirstPayment { get; }
        public string CreditType { get; }

        public static string GetOptionsCredit(int index) => OptionsCredit.ElementAtOrDefault(index);

        public static IEnumerable<string> OptionsCredit
          => TypesCredit.Select(t => t.Name);

        internal static IEnumerable<Type> TypesCredit => typeof(Credit).Assembly
                                          .GetTypes()
                                          .Where(t =>
                                              t.IsSubclassOf(typeof(Credit))
                                              && t.IsNotPublic
                                              && !t.IsAbstract);

        public static ICredit GetCredit(IProposal conditions)
        {
            var type = TypesCredit.FirstOrDefault(c => c.Name.Equals(conditions.CreditType));

            _ = type ?? throw new ArgumentException($"{conditions.CreditType} não é compativel com uma classe de mesmo nome que herda de Credit!");

            return (ICredit)Activator.CreateInstance(type, conditions);
        }
    }
}