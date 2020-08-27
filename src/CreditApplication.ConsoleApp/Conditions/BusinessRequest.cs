﻿using CreditApplication.Domain;
using System;

namespace CreditApplication.ConsoleApp.Conditions
{
    public class BusinessRequest : ConditionRequest
    {
        public BusinessRequest(decimal requestedAmount, int portion, DateTime firstPayment) : base(requestedAmount, portion, firstPayment)
        {
        }

        public override CreditType CreditType
            => CreditType.Business;
    }
}