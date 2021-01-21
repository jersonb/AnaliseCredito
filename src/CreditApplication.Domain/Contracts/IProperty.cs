using Flunt.Validations;

namespace CreditApplication.Domain.Contracts
{
    internal interface IProperty<out T>
    {
        T Value { get; }
        Contract Contract { get; }
    }
}