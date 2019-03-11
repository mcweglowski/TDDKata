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
        private char[] Delimiters = new char[] { ',', '\n' };

        public int Add(string addends)
        {
            if (String.Empty == addends)
            {
                return 0;
            }

            addends = ParseInput(addends);

            IList<int> addendsList = addends.Split(Delimiters).Select(x => Int32.Parse(x)).ToList();
            VerifyIfAnyNegatives(addendsList);

            return Sum(addends);
        }

        private void VerifyIfAnyNegatives(IList<int> addendsList)
        {
            bool bAddends = addendsList.Any(x => x < 0);

            if (true == bAddends)
            {
                string negatives = string.Join(",", addendsList.Where(x => x < 0).ToArray());

                string message = "Negatives not allowed: " + negatives;
                throw new Exception(message);
            }
        }

        private int Sum(string addends)
        {
            int sum = 0;

            foreach (string addend in addends.Split(Delimiters))
            {
                sum = sum + int.Parse(addend);
            }

            return sum;
        }

        private string ParseInput(string addends)
        {
            if (false == IsHeaderInInput(addends))
            {
                return addends;
            }

            StringReader stringReader = new StringReader(addends);
            string header = stringReader.ReadLine();
            Delimiters = ReadDelimiter(header);
            addends = stringReader.ReadLine();

            return addends;
        }

        private bool IsShorterThanTwo(string addends)
        {
            return 2 > addends.Length;
        }

        private bool HasDelimiterSection(string addends)
        {
            return addends.Substring(0, 2).Equals("//");
        }

        private char[] ReadDelimiter(string header)
        {
            return header.Substring(2, 1).ToCharArray();
        }

        private bool IsHeaderInInput(string addends)
        {
            if (true == IsShorterThanTwo(addends))
            {
                return false;
            }

            return HasDelimiterSection(addends);
        }
    }
}
