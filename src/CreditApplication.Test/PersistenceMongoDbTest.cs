using CreditApplication.Domain.Contracts;
using CreditApplication.Repository;
using System;
using System.Linq;
using Xunit;

namespace CreditApplication.Test
{
    public class PersistenceMongoDbTest
    {
        private readonly IPersistence _persistence;
        private readonly IRead _read;

        public PersistenceMongoDbTest()
        {
            var settings = new CreditMongoSettings
            {
                ConnectionString = "mongodb://jersonb:MongoDB2019@localhost:27017/?authSource=admin&readPreference=primary&ssl=false",
                NameCollectionLog = "logs",
                NameDatabaseCredit = "Credit",
                NameCollectionCredit = "credits"
            };
            _persistence = new Persistence(settings);
            _read = new ReadDataBase(settings);
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

                var proposal = condition.ToViewObject();

                var credit = proposal.GetCredit().ToViewObject();

                var id = _persistence.Save(proposal, credit);
                Assert.NotNull(id);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Fact]
        public void ReadDataBaseTest()
        {
            try
            {
               
                var all = _read.GetAllId();
                var allIdAproved = _read.GetIdAproved();
                var allIdReproved = _read.GetIdReproved();
                var aproved = _read.GetCredit(allIdAproved.ElementAt(0));
                var reproved = _read.GetCredit(allIdReproved.ElementAt(0));

                Assert.NotEmpty(all);
                Assert.NotEmpty(allIdAproved);
                Assert.NotEmpty(allIdReproved);
                Assert.NotNull(aproved);
                Assert.NotNull(reproved);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }
    }
}