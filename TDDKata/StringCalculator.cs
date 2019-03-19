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
        private string[] Delimiters = new string[] { ",", "\n" };
        private const string CustomDelimitersSection = "//";

        public int Add(string addends)
        {
            if (String.Empty == addends)
            {
                return 0;
            }

            IList<int> addendsList = ParseInput(addends);
            VerifyIfAnyNegatives(addendsList);
            return Sum(addendsList);
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

        private int Sum(IList<int> addendsList)
        {
            int sum = 0;

            foreach (int addend in addendsList.Where(x => x < 1001))
            {
                sum = sum + addend;
            }

            return sum;
        }

        private IList<int> ParseInput(string addends)
        {
            if (false == IsHeaderInInput(addends))
            {
                return ConvertInputToIistInt(addends);
            }

            StringReader stringReader = new StringReader(addends);
            string header = stringReader.ReadLine();
            Delimiters = ReadDelimiter(header);
            addends = stringReader.ReadLine();

            return ConvertInputToIistInt(addends);
        }

        private IList<int> ConvertInputToIistInt(string addends)
        {
            return addends.Split(Delimiters, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToList();
        }

        private bool IsShorterThanTwo(string addends)
        {
            return 2 > addends.Length;
        }

        private bool HasDelimiterSection(string addends)
        {
            return addends.Substring(0, CustomDelimitersSection.Length).Equals("//");
        }

        private string[] ReadDelimiter(string header)
        {
            string delimiter = header.Substring(CustomDelimitersSection.Length, header.Length - CustomDelimitersSection.Length);            
            return new string[] { delimiter.Substring(1, delimiter.Length - 2 ) };
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
