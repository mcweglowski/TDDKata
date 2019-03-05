using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKata;

namespace StringBuilderTests
{
    [TestClass]
    public class StringBuilderTests
    {
        [TestMethod]
        public void shouldReturnZeroForEmptyInputString()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("");

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void shouldReturnValueEqualProvidedSingleNumber()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("4");

            Assert.AreEqual(4, actual);
        }
    }
}
