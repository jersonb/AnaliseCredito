using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreditApplication.Repository
{
    [BsonIgnoreExtraElements]
    public class DataObject
    {
        public DataObject(ProposalDataObject proposal, CreditDataObject credit = null)
        {
            Proposal = proposal;
            Credit = credit;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public ProposalDataObject Proposal { get; set; }
        public CreditDataObject Credit { get; set; }
    }
}