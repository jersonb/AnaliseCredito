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
            IsValid = Value.Date >= DateTime.Now.AddDays(QUANTITY_DAYS_MIN).Date && Value.Date <= DateTime.Now.AddDays(QUANTITY_DAYS_MAX).Date;
        }

        public static implicit operator FirstPayment(DateTime value)
            => new FirstPayment(value);

        public DateTime Value { get; }
        public bool IsValid { get; }
    }
}