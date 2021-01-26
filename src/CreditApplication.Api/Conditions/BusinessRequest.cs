using System;

namespace CreditApplication.Api.Conditions
{
    public class BusinessRequest : ConditionRequest
    {
       

        public override string CreditType => "Business";
    }
}