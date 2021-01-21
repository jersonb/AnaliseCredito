using Flunt.Validations;

namespace CreditApplication.Domain.Contracts
{
    public interface IProperty<out T>
    {
        T Value { get; }
        Contract Contract { get; }
    }
}