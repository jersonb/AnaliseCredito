using CreditApplication.Domain;
using System;

namespace CreditApplication.ConsoleApp.Conditions
{
    public class DirectRequest : ConditionRequest
    {
        public DirectRequest(decimal requestedAmount, int portion, DateTime firstPayment) : base(requestedAmount, portion, firstPayment)
        {
        }

        public override CreditType CreditType => CreditType.Direct;
    }
}
