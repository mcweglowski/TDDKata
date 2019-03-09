using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDKata
{
    public class StringCalculator
    {
        private char[] DefaultDelimiters = new char[] { ',', '\n' };

        public int Add(string addends)
        {
            if (String.Empty == addends)
            {
                return 0;
            }

            return Sum(addends);
        }

        private int Sum(string addends)
        {
            if (1 < addends.Length)
            {
                if ("//" == addends.Substring(0, 2))
                {
                    StringReader stringReader = new StringReader(addends);
                    string header = stringReader.ReadLine();
                    DefaultDelimiters = header.Substring(2, 1).ToCharArray();
                    addends = stringReader.ReadLine();
                }
            }

            int sum = 0;

            foreach (string addend in addends.Split(DefaultDelimiters))
            {
                sum = sum + int.Parse(addend);
            }

            return sum;
        }
    }
}
