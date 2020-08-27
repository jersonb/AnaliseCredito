using CreditApplication.Domain;
using System;
using System.Collections.Generic;

namespace CreditApplication.ConsoleApp
{
    static class Program
    {
        static void Main(string[] _)
        {
            var conditions = new List<Conditions>
            {
                new Conditions
                {
                    CreditType = CreditType.Business,
                    RequestedAmount = 15_000,
                    Portion = 10,
                    FirstPayment = new DateTime(2020, 09, 10)
                },
                new Conditions
                {
                    CreditType = CreditType.Business,
                    RequestedAmount = 13_000,
                    Portion = 10,
                    FirstPayment = new DateTime(2020, 09, 10)
                }, 
                new Conditions
                {
                    CreditType = CreditType.Direct,
                    RequestedAmount = 10_000,
                    Portion = 10,
                    FirstPayment = new DateTime(2020, 09, 10)
                },  
                new Conditions
                {
                    CreditType = CreditType.Direct,
                    RequestedAmount = 0,
                    Portion = 4,
                    FirstPayment =  DateTime.Now
                },

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
