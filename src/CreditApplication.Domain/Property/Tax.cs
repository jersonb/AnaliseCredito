namespace CreditApplication.Domain.Property
{
    public struct Tax
    {
        private Tax(decimal value)
        {
            Value = value;
            IsValid = Value > 0;
        }

        public static implicit operator Tax(decimal value)
            => new Tax(value);

        public decimal Value { get; }
        public bool IsValid { get; }
    }
}