using System;

namespace CreditApplication.Test
{
    public class Condition : ConditionRequest
    {
        public Condition(decimal requestedAmount, int portion, DateTime firstPayment, string creditType)
        {
            RequestedAmount = requestedAmount;
            Portion = portion;
            FirstPayment = firstPayment;
            CreditType = creditType;
        }

        public override string CreditType { get; }
    }
}