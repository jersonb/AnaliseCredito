using CreditApplication.Domain.Contracts;
using Flunt.Validations;

namespace CreditApplication.Domain.Property
{
    internal struct Tax : IProperty<decimal>
    {
        private readonly static string _message = "Taxa Inválida";
        private Tax(decimal value)
        {
            Contract = new Contract().IsGreaterThan(value, 0, nameof(Tax), _message);
            Value = value;
        }

        public static implicit operator Tax(decimal value)
            => new Tax(value);

        public decimal Value { get; }
        public Contract Contract { get; }
    }
}