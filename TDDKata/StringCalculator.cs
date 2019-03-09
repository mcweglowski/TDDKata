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

            return Sum(addends);
        }

        private int Sum(string addends)
        {
            int sum = 0;

            foreach (string addend in addends.Split(new char[] { ',' , '\n'} ))
            {
                sum = sum + int.Parse(addend);
            }

            return sum;
        }
    }
}
