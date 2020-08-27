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
        [InlineData(1, 5, 15)]
        [InlineData(1_000_000, 72, 40)]
        [InlineData(0, 10, 15, "Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1")]
        [InlineData(1_000_001, 10, 15, "Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1")]
        [InlineData(1_000, 4, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(1_000, 73, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(1_000, 10, 14, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        [InlineData(1_000, 10, 41, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        public void DirectIsValidTest(decimal requestAmount, int portion, int quantityDays, string message = null)
        {
            var direct = CreditBase.GetInstance<Direct>(Proposal.GetProposal(requestAmount, portion, DateTime.Now.AddDays(quantityDays)));

            if (direct.Aproved)
            {
                Assert.True(requestAmount < direct.Amount);
                Assert.Empty(direct.Notifications);
            }
            else
            {
                Assert.Contains(message, direct.Notifications);
            }
        }

        [Theory]
        [InlineData(15_000, 5, 15)]
        [InlineData(1_000_000, 72, 40)]
        [InlineData(14_999, 5, 15, "Valor solicitado não pode ser menor que R$ 15.000,00")]
        [InlineData(1_000_001, 10, 15, "Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1")]
        [InlineData(20_000, 4, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(20_000, 73, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(20_000, 10, 14, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        [InlineData(20_000, 10, 41, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        public void BusinessIsValidTest(decimal requestAmount, int portion, int quantityDays, string message = null)
        {
            var business = CreditBase.GetInstance<Business>(Proposal.GetProposal(requestAmount, portion, DateTime.Now.AddDays(quantityDays)));

            if (business.Aproved)
            {
                Assert.True(requestAmount < business.Amount);
                Assert.Empty(business.Notifications);
            }
            else
            {
                Assert.Contains(message, business.Notifications);
            }
        }


        [Theory]
        [InlineData(15_000)]
        public void RealEstateIsValidTest(decimal requestAmount)
        {
            var payroll = CreditBase.GetInstance<Payroll>(Proposal.GetProposal(requestAmount, 72, DateTime.Now.AddDays(15)));
            var realEstate = CreditBase.GetInstance<RealEstate>(Proposal.GetProposal(requestAmount, 72, DateTime.Now.AddDays(15)));
            Assert.True(payroll.Amount > realEstate.Amount);
        }
    }
}
