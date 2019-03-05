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

            int sum = 0;
            foreach (string addend in addends.Split(','))
            {
                sum = sum + int.Parse(addend);
            }

            return sum;
        }
    }
}
