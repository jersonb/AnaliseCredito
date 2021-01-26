using System.Collections.Generic;

namespace CreditApplication.Domain.Contracts
{
    public interface IRead
    {
        IEnumerable<string> GetAllId();

        IEnumerable<string> GetIdAproved();

        IEnumerable<string> GetIdReproved();

        ICredit GetCredit(string id);
    }
}