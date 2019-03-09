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

        [TestMethod]
        public void shouldReturnSumOfTwoCommaSeparatedNumbers()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("1,2");

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void shouldReturnSixWhenNEWLINEUsedToSeparate()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("1\n2,3");

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void shouldAllowToSpecifyDelimiterOptionalInFirstLine()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, actual);
        }
    }
}
