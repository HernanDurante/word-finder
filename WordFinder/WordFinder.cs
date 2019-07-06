using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordFinder
{
    public class WordFinder
    {
        private string _rowsString;
        private string _columnsString;
        const int MAXRESULTSNBR = 10;

        public WordFinder(IEnumerable<string> matrix)
        {
            _rowsString = string.Join(",", matrix);
            _columnsString = GenerateColumnsString(matrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Dictionary<string, int> matches = new Dictionary<string, int>();
            List<string> result = new List<string>();
            int wordStreamLength = wordstream.Count();

            for (int i = 0; i < wordStreamLength; i++)
            {
                string wordToSearch = wordstream.ElementAt<string>(i);

                int matchCount = Regex.Matches(_rowsString, wordToSearch, RegexOptions.IgnoreCase).Count; // Get all matches in rows
                matchCount += Regex.Matches(_columnsString, wordToSearch, RegexOptions.IgnoreCase).Count; // Get all matches in columns

                if (matchCount > 0)
                {
                    matches.Add(wordToSearch, matchCount);
                }
            }

            if (matches.Count > 0)
            {
                result = matches.OrderByDescending(m => m.Value).Select(m => m.Key).Take(MAXRESULTSNBR).ToList();
            }

            return result;
        }

        /// <summary>
        /// Cycles through the matrix by column and builds a single string separating each column by comma
        /// </summary>
        /// <param name="matrix">List of strings representing a character matrix</param>
        /// <returns>
        /// A string built from matrix's columns from left to rigth
        /// </returns>
        private string GenerateColumnsString(IEnumerable<string> matrix)
        {
            StringBuilder strBuilder = new StringBuilder();
            int hLength = matrix.FirstOrDefault().Length;
            int vLength = matrix.Count();

            for (int i = 0; i < hLength; i++)
            {
                for (int j = 0; j < vLength; j++)
                {
                    strBuilder.Append(matrix.ElementAt<string>(j)[i]);
                }
                strBuilder.Append(',');
            }

            return strBuilder.ToString();
        }

    }
}
