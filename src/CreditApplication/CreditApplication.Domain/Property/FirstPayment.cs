using System;

namespace CreditApplication.Domain.Property
{
    public struct FirstPayment
    {
        private const int QUANTITY_DAYS_MIN = 15;
        private const int QUANTITY_DAYS_MAX = 40;
       
        private FirstPayment(DateTime value)
        {
            Value = value;
            IsValid = Value > DateTime.Now.AddDays(QUANTITY_DAYS_MIN) || Value < DateTime.Now.AddDays(QUANTITY_DAYS_MAX);
        }

        public static implicit operator FirstPayment(DateTime value)
            => new FirstPayment(value);

        public DateTime Value { get; }
        public bool IsValid { get; }
    }
}
