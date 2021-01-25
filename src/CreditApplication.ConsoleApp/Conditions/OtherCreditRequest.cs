using CreditApplication.Domain.Contracts;
using System;

namespace CreditApplication.ConsoleApp.Conditions
{
    public class OtherCreditRequest : ConditionRequest
    {
        public OtherCreditRequest(decimal requestedAmount, int portion, DateTime firstPayment, int creditType) : base(requestedAmount, portion, firstPayment)
        {
            CreditType = IProposal.GetOptionsCredit(creditType);
        }

        public override string CreditType { get; }
    }
}