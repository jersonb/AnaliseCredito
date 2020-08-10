using CreditApplication.Domain;
using System;

namespace CreditApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] _)
        {
            var conditions = new Conditions();

            var credit = conditions.GetCredit();

            Console.WriteLine($"{credit.Amount} , {credit.Interest}, {credit.IsAproved}");
        }
    }
}
