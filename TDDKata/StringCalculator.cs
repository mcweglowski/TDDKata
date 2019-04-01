using StringBuilderTests;
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

        public ILogger Logger {get; set; }
        public IWebservice Webservice { get; private set; }

        public StringCalculator()
        {

        }

        public StringCalculator(ILogger logger, IWebservice webservice)
        {
            Logger = logger;
            Webservice = webservice;
        }

        public int Add(string addends)
        {
            if (String.Empty == addends)
            {
                return 0;
            }

            IList<int> addendsList = ParseInput(addends);
            VerifyIfAnyNegatives(addendsList);
            int sum = Sum(addendsList);

            try
            {
                Logger.Write(sum);
            }
            catch (Exception exception)
            {
                Webservice.Notify(exception.Message);
            }

            return sum;
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
            Delimiters = ExtractDelimitersFromHeader(header);
            addends = stringReader.ReadLine();

            return ConvertInputToIistInt(addends);
        }

        private IList<int> ConvertInputToIistInt(string addends)
        {
            return addends.Split(Delimiters, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToList();
        }

        private bool IsShorterThanDelimiterSectionMarkWithSingleCharDelimiter(string addends)
        {
            return addends.Length <= CustomDelimitersSection.Length;
        }

        private bool HasDelimiterSection(string addends)
        {
            return addends.Substring(0, CustomDelimitersSection.Length).Equals("//");
        }

        private string RemoveUpmostBracketsInDelimiters(string delimiter)
        {
            if (true == IsDelimiterInBrackets(delimiter))
            {
                int BracketsCount = 2;
                return delimiter.Substring(1, delimiter.Length - BracketsCount);
            }

            return delimiter;
        }

        private bool IsDelimiterInBrackets(string delimiter)
        {
            char OpeningBracket = '[';
            char ClosingBracket = ']';
            return OpeningBracket == delimiter.ElementAt(0) && ClosingBracket == delimiter.ElementAt(delimiter.Length - 1);
        }

        private string[] ExtractDelimitersFromHeader(string header)
        {
            string delimiters = header.Substring(CustomDelimitersSection.Length, header.Length - CustomDelimitersSection.Length);
            delimiters = RemoveUpmostBracketsInDelimiters(delimiters);

            return delimiters.Split(new string[] { "][" }, StringSplitOptions.None);
        }

        private bool IsHeaderInInput(string addends)
        {
            if (true == IsShorterThanDelimiterSectionMarkWithSingleCharDelimiter(addends))
            {
                return false;
            }

            return HasDelimiterSection(addends);
        }
    }
}
