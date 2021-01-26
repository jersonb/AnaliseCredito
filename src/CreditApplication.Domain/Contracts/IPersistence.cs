namespace CreditApplication.Domain.Contracts
{
    public interface IPersistence
    {
        void Log(IProposal proposal);

        string Save(IProposal proposal, ICredit credit);
    }
}