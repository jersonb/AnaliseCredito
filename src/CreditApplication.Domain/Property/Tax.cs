namespace CreditApplication.Domain.Property
{
    internal struct Tax
    {
        private Tax(decimal value)
        {
            Value = value;
        }

        public static implicit operator Tax(decimal value)
            => new Tax(value);

        public decimal Value { get; }
    }
}