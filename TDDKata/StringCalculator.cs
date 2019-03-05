using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDKata
{
    public class StringCalculator
    {
        public int Add(string addends)
        {
            if (string.Empty == addends)
            {
                return 0;
            }

            return Int32.Parse(addends);
        }
    }
}
