using CreditApplication.Domain.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CreditApplication.Repository
{
    public class ReadDataBase : MongoDatabase, IRead
    {
        public ReadDataBase(ICreditMongoSettings settings) : base(settings)
        {
        }

        public ICredit GetCredit(string id)
        {
            var data = _collection.AsQueryable().FirstOrDefault(c => c.Id.Equals(id));
            return data?.Credit;
        }

        public IEnumerable<string> GetAllId()
        {
            var ids = _collection.AsQueryable().Select(c => c.Id).ToArray();

            return ids;
        }

        public IEnumerable<string> GetIdAproved()
        {
            var ids = _collection.AsQueryable().Where(c => c.Credit.Aproved).Select(c => c.Id).ToArray();

            return ids;
        }

        public IEnumerable<string> GetIdReproved()
        {
            var ids = _collection.AsQueryable().Where(c => !c.Credit.Aproved).Select(c => c.Id).ToArray();

            return ids;
        }
    }
}