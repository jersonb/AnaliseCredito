using CreditApplication.Domain;
using CreditApplication.Domain.Credits;
using CreditApplication.Domain.Property;
using System;
using Xunit;

namespace CreditApplication.Test
{
    public class CreditsTest
    {
        [Theory]
        [InlineData(20000)]
        public void DirectIsValidTest(decimal requestAmount)
        {
            try
            {
                var direct = CreditBase.GetInstance<Direct>(Proposal.GetProposal(requestAmount, 10, DateTime.Now.AddDays(15)));
                Assert.True(direct.Aproved);
                Assert.True(requestAmount < direct.Amount);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Theory]
        [InlineData(15000)]
        public void BusinessIsValidTest(decimal requestAmount)
        {
            var business = CreditBase.GetInstance<Business>(Proposal.GetProposal(requestAmount, 10, DateTime.Now.AddDays(15)));
            Assert.True(requestAmount < business.Amount);
            Assert.False(business.Aproved);
            Assert.Contains("Valor solicitado não pode ser menor que R$ 15.000,00", business.Notifications);
        } 
        
        [Theory]
        [InlineData(15000)]
        public void RealEstateIsValidTest(decimal requestAmount)
        {
            var business = CreditBase.GetInstance<Direct>(Proposal.GetProposal(requestAmount, 10, DateTime.Now.AddDays(15)));
            Assert.True(requestAmount < business.Amount);
            Assert.True(business.Aproved);
        }
    }
}
