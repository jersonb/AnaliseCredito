namespace CreditApplication.Domain.Property
{
    public struct RequestedAmount
    {
        private const int REQUEST_MAX = 1_000_000;
        private const int REQUEST_MIN = 1;

        private RequestedAmount(decimal value)
        {
            Value = value;
            IsValid = Value <= REQUEST_MAX && Value >= REQUEST_MIN;
        }

        public static implicit operator RequestedAmount(decimal value)
            => new RequestedAmount(value);

        public decimal Value { get; }
        public bool IsValid { get; }
    }
}
