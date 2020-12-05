using CreditApplication.Domain.Contracts;
using Flunt.Validations;

namespace CreditApplication.Domain.Property
{
    internal struct Portion:IProperty<int>
    {
        private const int PORTION_MAX = 72;
        private const int PORTION_MIN = 5;
        private readonly static string _message = $"A quantidade de parcelas máximas é de {PORTION_MAX}x e a mínima é de {PORTION_MIN}x";

        private Portion(int value)
        {
            Contract = new Contract().IsBetween(value, PORTION_MIN,PORTION_MAX,nameof(Portion),_message);
            Value = value;
        }

        public static implicit operator Portion(int value)
            => new Portion(value);

        public int Value { get; }
        public Contract Contract { get; }
    }
}