using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderTests
{
    public interface ILogger
    {
        void Log(int number);
        int LastLogValue();
    }
}
