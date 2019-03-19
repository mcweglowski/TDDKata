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

        [TestMethod]
        public void shouldThrowExceptionWithAllNegativesInInput()
        {
            try
            {
                StringCalculator stringCalculator = new StringCalculator();
                stringCalculator.Add("1,2,5,-2,8,-33,5,1");

                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Negatives not allowed: -2,-33", exception.Message);
            }
        }

        [TestMethod]
        public void shouldIgnoreNumbersGreaterThat1000()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("1,2,10000,1001,20");

            Assert.AreEqual(23, actual);
        }

        [TestMethod]
        public void shouldAcceptDelimitersOfAnyLength()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("//[***]\n1***2***3");

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void shouldAcceptMultipleCustomDelimiters()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("//[*][%]\n1*2%3");

            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void shouldAcceptMultipleCustomDelimitersWhoHaveDifferentLength()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add("//[*][%%][&&&]\n1*2%%3&&&4");

            Assert.AreEqual(10, actual);
        }
    }
}
