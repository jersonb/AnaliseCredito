﻿using System;

namespace CreditApplication.Domain.Property
{
    internal struct Proposal
    {
        private Proposal(RequestedAmount requestedAmount, Portion portion, FirstPayment firstPayment)
        {
            RequestedAmount = requestedAmount;
            Portion = portion;
            FirstPayment = firstPayment;
        }

        internal static Proposal GetProposal(decimal requestedAmount, int portion, DateTime firstPayment)
            => new Proposal(requestedAmount, portion, firstPayment);

        public RequestedAmount RequestedAmount { get; }
        public Portion Portion { get; }
        public FirstPayment FirstPayment { get; }
    }
}