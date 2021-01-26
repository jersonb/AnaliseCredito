using CreditApplication.Domain.Contracts;

namespace CreditApplication.Repository
{
    public class Persistence : MongoDatabase, IPersistence
    {
        public Persistence(ICreditMongoSettings settings) : base(settings)
        {
        }

        public void Log(IProposal proposal)
        {
            var toSave = new DataObject(proposal);
            _collectionLog.InsertOne(toSave);
        }

        public string Save(IProposal proposal, ICredit credit)
        {
            var toSave = new DataObject(proposal, credit);
            _collection.InsertOne(toSave);

            return toSave.Id;
        }
    }
}