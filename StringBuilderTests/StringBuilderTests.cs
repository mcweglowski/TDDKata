using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
