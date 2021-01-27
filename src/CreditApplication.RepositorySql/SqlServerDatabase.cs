using System.Data.SqlClient;

namespace CreditApplication.RepositorySql
{
    public abstract class SqlServerDatabase
    {
        protected SqlServerDatabase(ICreditSqlServerSettings settings)
        {
            Connection = new SqlConnection(settings.ConnectionString);
        }

        public SqlConnection Connection { get; }
    }

    public interface ICreditSqlServerSettings
    {
        public string ConnectionString { get; }
    }

    public class CreditSqlServerSettings : ICreditSqlServerSettings
    {
        public string ConnectionString { get; set; }
    }
}