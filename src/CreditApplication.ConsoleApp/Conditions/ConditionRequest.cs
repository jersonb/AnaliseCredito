﻿using CreditApplication.Domain.Contracts;
using System;

namespace CreditApplication.ConsoleApp.Conditions
{
    public abstract class ConditionRequest : IProposal
    {
        protected ConditionRequest(decimal requestedAmount, int portion, DateTime firstPayment)
        {
            RequestedAmount = requestedAmount;
            Portion = portion;
            FirstPayment = firstPayment;
        }

        public decimal RequestedAmount { get; }

        public int Portion { get; }

        public DateTime FirstPayment { get; }

        abstract public string CreditType { get; }
    }
}