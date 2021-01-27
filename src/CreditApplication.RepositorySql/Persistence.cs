using CreditApplication.Domain.Contracts;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CreditApplication.RepositorySql
{
    public class Persistence : SqlServerDatabase, IPersistence
    {
        public Persistence(ICreditSqlServerSettings settings) : base(settings)
        {
        }

        public void Log(IProposal proposal)
        {
            var insertLog = @"INSERT INTO [CREDIT].[dbo].[LOG_PROPOSAL]([RequestedAmount],[Portion],[FirstPayment],[CreditType])
                        VALUES(@RequestedAmount, @Portion, @FirstPayment, @CreditType) ";

            using var connection = Connection;
            connection.Open();
            connection.Execute(insertLog, new { proposal.RequestedAmount, proposal.Portion, proposal.FirstPayment, proposal.CreditType });
        }

        public string Save(IProposal proposal, ICredit credit)
        {
            try
            {
                using var connection = Connection;
                connection.Open();
                using var transaction = connection.BeginTransaction();

                var idProposal = Save(proposal, connection, transaction);

                var idCredit = Save(credit, connection, transaction, idProposal);

                if (!credit.Aproved)
                {
                    Save(credit.Notifications, connection, transaction, idCredit);
                }

                transaction.Commit();

                return idCredit.ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private int Save(ICredit credit, SqlConnection connection, SqlTransaction transaction, int idProposal)
        {
            var insertCredit = @"INSERT INTO [CREDIT].[dbo].[TB_CREDIT]([Amount],[Interest],[idProposal])
                            OUTPUT INSERTED.Id
                             VALUES( @Amount, @Interest , @IdProposal)
";
            var idCredit = connection.QuerySingle<int>(insertCredit, new { credit.Amount, credit.Interest, idProposal }, transaction);
            return idCredit;
        }

        private int Save(IProposal proposal, SqlConnection connection, SqlTransaction transaction)
        {
            var insertProposal = @"INSERT INTO [CREDIT].[dbo].[TB_PROPOSAL]([RequestedAmount], [Portion], [FirstPayment], [CreditType])
                                OUTPUT INSERTED.Id
                                VALUES(@RequestedAmount, @Portion, @FirstPayment, @CreditType) ";
            var idProposal = connection.QuerySingle<int>(insertProposal, proposal, transaction);
            return idProposal;
        }

        private void Save(IEnumerable<string> notificatios, SqlConnection connection, SqlTransaction transaction, int idCredit)
        {
            var insertNotification = @"INSERT INTO [CREDIT].[dbo].[TB_NOTIFICATION]([Message],[idCredit])
                                VALUES(@message, @idCredit) ";

            foreach (var message in notificatios)
            {
                _ = connection.Execute(insertNotification, new { message, idCredit }, transaction);
            }
        }
    }
}