using CreditApplication.Domain.Contracts;
using CreditApplication.RepositorySql;
using System;
using Xunit;

namespace CreditApplication.Test
{
    public class PersistenceMsSqlTest
    {
        private readonly IPersistence _persistence;
        private readonly IRead _read;

        public PersistenceMsSqlTest()
        {
            var settings = new CreditSqlServerSettings
            {
                ConnectionString = "Server=localhost,1433;Database=Credit;User Id=sa;Password=MsSql2019;"
            };
            _persistence = new Persistence(settings);
        }

        [Fact]
        public void LogTest()
        {
            try
            {
                var condition = new Condition(1, 5, DateTime.Now.AddDays(15), "Direct");

                _persistence.Log(condition);
                Assert.NotNull(condition);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Theory]
        [InlineData(1_000_000, 72, 40)]
        [InlineData(14_999, 5, 15)]
        public void PersistenceCreditTest(decimal requestAmount, int portion, int quantityDays)
        {
            try
            {
                var condition = new Condition(requestAmount, portion, DateTime.Now.AddDays(quantityDays), "Business");
                
                var credit = condition.GetCredit();

                var id = _persistence.Save(condition, credit);
                Assert.NotNull(id);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }
    }
}