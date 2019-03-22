using StringBuilderTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDKata
{
    public class Logger : ILogger
    {
        private IList<string> log = new List<string>();
        public IList<string> Log { get => log; }

        public void Write(int number)
        {
            log.Add(number.ToString());
        }
    }
}
