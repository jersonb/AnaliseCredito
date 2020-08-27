using CreditApplication.Domain;
using CreditApplication.Domain.Contracts;
using System;

namespace CreditApplication.Test.Conditions
{
    public class Condition : ICondition
    {
        public Condition(decimal requestedAmount, int portion, DateTime firstPayment, CreditType creditType)
        {
            RequestedAmount = requestedAmount;
            Portion = portion;
            FirstPayment = firstPayment;
            CreditType = creditType;
        }

        public decimal RequestedAmount { get; }

        public int Portion { get; }

        public DateTime FirstPayment { get; }

        public CreditType CreditType { get; }
    }
}