namespace CreditApplication.Domain.Contracts
{
    public interface IPersistence
    {
        void Log(ProposalDataObject proposal);

        string Save(ProposalDataObject proposal, CreditDataObject credit);
    }
}