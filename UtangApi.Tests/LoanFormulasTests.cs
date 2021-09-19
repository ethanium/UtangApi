using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pera.UtangApi.Formulas.Tests
{
    [TestClass()]
    public class LoanFormulasTests
    {
        [TestMethod()]
        public void CalcTotalFinanceChargeTest()
        {
            decimal actual = LoanFormulas.CalcTotalFinanceCharge(20000, 0.08M, 2);
            decimal expected = 23200;
            Assert.AreEqual(expected, actual);
        }
    }
}