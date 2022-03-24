using System.Text.RegularExpressions;

namespace MarsRoverChallenge
{
    public class Helper
    {
        private static readonly Regex whiteSpace = new Regex(@"\s+");
        public static string ReplaceWhitespace(string input, string replacement)
        {
            return whiteSpace.Replace(input, replacement);
        }
    }
}
