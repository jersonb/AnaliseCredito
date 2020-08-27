namespace CreditApplication.Domain.Property
{
    internal struct Portion
    {
        private const int PORTION_MAX = 72;
        private const int PORTION_MIN = 5;

        private Portion(int value)
        {
            Value = value;
            IsValid = Value <= PORTION_MAX && Value >= PORTION_MIN;
        }

        public static implicit operator Portion(int value)
            => new Portion(value);

        public int Value { get; }
        public bool IsValid { get; }
    }
}