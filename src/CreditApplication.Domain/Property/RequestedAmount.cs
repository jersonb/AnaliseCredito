using CreditApplication.Domain.Contracts;
using Flunt.Validations;

namespace CreditApplication.Domain.Property
{
    internal struct RequestedAmount : IProperty<decimal>
    {
        private const int REQUEST_MAX = 1_000_000;
        private const int REQUEST_MIN = 1;
        private readonly static string _message = $"Valor solicitado não pode ser maior que {REQUEST_MAX:C2} nem menor que {REQUEST_MIN:C2}";
        private RequestedAmount(decimal value)
        {
            Contract = new Contract().IsBetween(value, REQUEST_MIN, REQUEST_MAX, nameof(RequestedAmount), _message);
            Value = value;
        }

        public static implicit operator RequestedAmount(decimal value)
            => new RequestedAmount(value);

        public Contract Contract { get; }
        public decimal Value { get; }
    }
}