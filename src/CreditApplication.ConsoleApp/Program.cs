using CreditApplication.ConsoleApp.Conditions;
using CreditApplication.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace CreditApplication.ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] _)
        {
            int i = 0;
            Console.WriteLine("Insira o número do tipo de crédito que deseja");

            foreach (var item in IProposal.OptionsCredit)
            {
                Console.WriteLine($"{i++} - {item}");
            }
            var selectedCredit = Console.ReadLine();

            var date = DateTime.Now.AddDays(30);

            var conditions = new List<IProposal>
            {   new OtherCreditRequest(15_000, 10, date, int.Parse(selectedCredit)),
                new BusinessRequest(15_000, 10, date),
                new BusinessRequest(13_000, 10, date),
                new DirectRequest(10_000, 10, date),
                new DirectRequest(0, 4, DateTime.Now),
            };

            conditions.ForEach(condition =>
            {
                var credit = IProposal.GetCredit(condition);
                Console.WriteLine("Situação: {0}", credit.Aproved ? "Aprovado" : "Reprovado");
                Console.WriteLine($"Total a pagar: {credit.Amount:C2}, Total dos Juros: {credit.Interest}");
                Console.WriteLine("Notificações");

                foreach (var message in credit.Notifications)
                {
                    Console.WriteLine(message);
                }

                Console.WriteLine("\n");
            });
        }
    }
}