namespace CreditApplication.Domain
{
    public interface ICredit
    {
         decimal Amount { get; }
         decimal Interest { get;  }
         bool Aproved { get;  }
    }
}
