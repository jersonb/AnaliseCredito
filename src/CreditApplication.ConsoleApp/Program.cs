using CreditApplication.ConsoleApp.Conditions;
using CreditApplication.Domain;
using CreditApplication.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace CreditApplication.ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] _)
        {
            var conditions = new List<ICondition>
            {
                new BusinessRequest(15_000, 10, new DateTime(2020, 09, 10)),
                new BusinessRequest(13_000, 10, new DateTime(2020, 09, 10)),
                new DirectRequest(10_000, 10, new DateTime(2020, 09, 10)),
                new DirectRequest(0, 4, DateTime.Now),
            };

            conditions.ForEach(condition =>
            {
                var credit = condition.GetCredit();
                Console.WriteLine("Situação: {0}", credit.Aproved ? "Aprovado" : "Reprovado");
                Console.WriteLine($"Total a pagar: {credit.Amount:C2}, Total dos Juros: {credit.Interest}");
                Console.WriteLine("Notificações");
                credit.Notifications.ForEach(notification =>
                {
                    Console.WriteLine(notification);
                });
                Console.WriteLine("\n");
            });
        }
    }
}