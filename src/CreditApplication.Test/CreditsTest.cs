using CreditApplication.Domain;
using CreditApplication.Test.Conditions;
using System;
using Xunit;

namespace CreditApplication.Test
{
    public class CreditsTest
    {
        [Theory]
        [InlineData(1, 5, 15)]
        [InlineData(1_000_000, 72, 39)]
        [InlineData(1_000_000, 72, 40)]
        [InlineData(1_000, 10, 41, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        [InlineData(0, 10, 15, "Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1,00")]
        [InlineData(1_000_001, 10, 15, "Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1,00")]
        [InlineData(1_000, 4, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(1_000, 73, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(1_000, 10, 14, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        public void DirectIsValidTest(decimal requestAmount, int portion, int quantityDays, string message = null)
        {
            var condition = new Condition(requestAmount, portion, DateTime.Now.AddDays(quantityDays), CreditType.Direct);
            var direct = condition.GetCredit();

            if (direct.Aproved)
            {
                Assert.True(requestAmount < direct.Amount);
                Assert.Empty(direct.Notifications);
                Assert.Null(message);
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
        [InlineData(1_000_001, 10, 15, "Valor solicitado não pode ser maior que R$ 1.000.000,00 nem menor que R$ 1,00")]
        [InlineData(20_000, 4, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(20_000, 73, 15, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x")]
        [InlineData(20_000, 10, 14, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        [InlineData(20_000, 10, 41, "A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D+40 (Dia atual + 40 dias)")]
        public void BusinessIsValidTest(decimal requestAmount, int portion, int quantityDays, string message = null)
        {
            var condition = new Condition(requestAmount, portion, DateTime.Now.AddDays(quantityDays), CreditType.Business);
            var business = condition.GetCredit();
            if (business.Aproved)
            {
                Assert.True(requestAmount < business.Amount);
                Assert.Empty(business.Notifications);
                Assert.Null(message);
            }
            else
            {
                Assert.Contains(message, business.Notifications);
            }
        }

        [Theory]
        [InlineData(15_000, 72)]
        public void RealEstateIsValidTest(decimal requestAmount, int portion)
        {
            var date = DateTime.Now.AddDays(15);
            var payroll = new Condition(requestAmount, portion, date, CreditType.Payroll).GetCredit();
            var realEstate = new Condition(requestAmount, portion, date, CreditType.RealEstate).GetCredit();
            Assert.True(payroll.Amount > realEstate.Amount);
        }
    }
}