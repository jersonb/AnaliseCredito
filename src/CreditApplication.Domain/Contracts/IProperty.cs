using Flunt.Validations;

namespace CreditApplication.Domain.Contracts
{
    public interface IProperty<T>
    {
         T Value { get; }
         Contract Contract { get; }
    }
}