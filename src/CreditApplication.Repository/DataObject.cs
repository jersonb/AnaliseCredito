using CreditApplication.Domain.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreditApplication.Repository
{
    [BsonIgnoreExtraElements]
    public class DataObject
    {
        public DataObject(IProposal proposal, ICredit credit = null)
        {
            Proposal = proposal.ToViewObject();
            Credit = credit?.ToViewObject();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public ProposalDataObject Proposal { get; set; }
        public CreditDataObject Credit { get; set; }
    }
}