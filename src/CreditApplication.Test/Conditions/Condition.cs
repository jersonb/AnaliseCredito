using CreditApplication.Domain.Contracts;
using System;

namespace CreditApplication.Test.Conditions
{
    public class Condition : IProposal
    {
        public Condition(decimal requestedAmount, int portion, DateTime firstPayment, string creditType)
        {
            RequestedAmount = requestedAmount;
            Portion = portion;
            FirstPayment = firstPayment;
            CreditType = creditType;
        }

        public decimal RequestedAmount { get; }

        public int Portion { get; }

        public DateTime FirstPayment { get; }

        public string CreditType { get; }
    }
}