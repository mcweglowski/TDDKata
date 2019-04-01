using NSubstitute;
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
            IWebservice webservice = Substitute.For<IWebservice>();
            ILogger logger = Substitute.For<ILogger>();
            logger.When(x => x.Write(Arg.Any<int>())).Do(x => { throw new Exception("Logger error"); });

            StringCalculator stringBuilder = new StringCalculator(logger, webservice);
            stringBuilder.Add("1,2,3");

            webservice.Received().Notify();
        }

    }
}
