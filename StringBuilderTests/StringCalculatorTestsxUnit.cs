using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDKata;
using Xunit;

namespace StringBuilderTests
{
    public class StringCalculatorTestsxUnit
    {
        [Fact]
        public void shouldNotifyWebServiceAboutFailedLogging()
        {
            IWebservice webservice = new WebserviceMock(); => Check if Notify called
            ILogger = new LoggerMock() = > throw Exception when called Add;

            StringCalculator stringBuilder = new StringCalculator(logger, webservice);

            Assert.WasCalledOnce(webservice.Notify);
        }

    }
}
