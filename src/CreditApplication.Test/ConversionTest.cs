using System;
using Xunit;

namespace CreditApplication.Test
{
    public class ConversionTest
    {
        [Fact]
        public void CreditToViewTest()
        {
            try
            {
                var condition = new Condition(1, 5, DateTime.Now.AddDays(15), "Direct");

                var (credit, proposal) = condition.ToViewObject();

                Assert.NotNull(credit);
                Assert.NotNull(proposal);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }
    }
}