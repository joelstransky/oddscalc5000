using System;
using System.Text.RegularExpressions;

namespace BreakEvenCalculator
{
    // Parses strings into American Odds and converts to other formats.
    public class AmericanOdds
    {
        private const string rx_string = @"^([\+-])(\d\d\d+)$";
        private readonly int odds;
        private readonly bool favorite;

        private readonly float oddsValue;

        public static bool IsValid(string am_odds)
        {
            return Regex.IsMatch(am_odds, rx_string);
        }

        public AmericanOdds(string am_odds)
        {
            var valid = false;
            var rx = new Regex(rx_string, RegexOptions.Compiled);

            MatchCollection matches = rx.Matches(am_odds);
            if (matches.Count < 1)
            {
                valid = false;
            }
            else
            {
                GroupCollection groups = matches[0].Groups;
                if (groups[1].Value == "+")
                {
                    favorite = false;
                    valid = true;
                }
                else if (groups[1].Value == "-")
                {
                    favorite = true;
                    valid = true;
                }
                else
                {
                    valid = false;
                }
                if (int.TryParse(groups[2].Value, out odds))
                {
                    oddsValue = Int32.Parse(groups[2].Value) * (favorite ? -1 : 1);
                }
                else
                {
                    valid = false;
                }
            }
            if (!valid)
            {
                throw new ArgumentException("Invalid odds format");
            }
        }

        public double GetBreakEvenPercentage()
        {
            if (oddsValue > 0)
            {
                return 100 / (100 + oddsValue);

            }
            else
            {
                return -oddsValue / (100 + oddsValue * -1);
            }
        }
    }
}