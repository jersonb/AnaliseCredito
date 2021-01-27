using CreditApplication.Domain.Contracts;
using Dapper.Contrib.Extensions;

namespace CreditApplication.RepositorySql
{
    public class DataObject
    {
        public DataObject(IProposal proposal, ICredit credit = null)
        {
            Proposal = proposal.ToViewObject();
            Credit = credit?.ToViewObject();
        }

        [Key]
        public int Id { get; set; }

        public ProposalDataObject Proposal { get; set; }
        public CreditDataObject Credit { get; set; }
    }
}