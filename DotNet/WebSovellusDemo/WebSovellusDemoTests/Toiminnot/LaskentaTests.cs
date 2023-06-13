using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSovellusDemo.Toiminnot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSovellusDemo.Toiminnot.Tests
{
    [TestClass()]
    public class LaskentaTests
    {
        [TestMethod()]
        public void SummaTest()
        {
            int a = 1;
            int b = 2;

            Laskenta laskenta = new();
            int summa = laskenta.Summa(a, b);

            Assert.AreEqual(a + b, summa);
        }
    }
}