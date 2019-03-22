using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDKata;

namespace StringBuilderTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void shouldLogMessage()
        {
            Logger logger = new Logger();
            logger.Write(4);

            Assert.IsNotNull(logger.Log.ElementAt(0));
            Assert.AreEqual("4", logger.Log.ElementAt(0));
        }
    }
}
