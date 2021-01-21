using System;
using CreditApplication.Domain.Contracts;
using Flunt.Validations;

namespace CreditApplication.Domain.Property
{
    internal struct FirstPayment : IProperty<DateTime>
    {
        private const int QUANTITY_DAYS_MIN = 15;
        private const int QUANTITY_DAYS_MAX = 40;
        private readonly static string _message = $"A data do primeiro vencimento sempre será no mínimo D+{QUANTITY_DAYS_MIN} (Dia atual + {QUANTITY_DAYS_MIN} dias), e no máximo, D+{QUANTITY_DAYS_MAX} (Dia atual + {QUANTITY_DAYS_MAX} dias)";

        private FirstPayment(DateTime value)
        {
            Value = value;
            Contract = new Contract()
                            .IsBetween(value.Date
                                    , DateTime.Now.AddDays(QUANTITY_DAYS_MIN).Date
                                    , DateTime.Now.AddDays(QUANTITY_DAYS_MAX).Date
                                    , nameof(FirstPayment)
                                    ,_message)
            ;
                    
        }

        public static implicit operator FirstPayment(DateTime value)
            => new FirstPayment(value);

        public DateTime Value { get; }
        public Contract Contract { get; }
    }
}