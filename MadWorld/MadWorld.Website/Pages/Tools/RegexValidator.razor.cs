using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MadWorld.Website.Models.Tools;

namespace MadWorld.Website.Pages.Tools
{
    public partial class RegexValidator
    {
        private bool ShowError { get; set; }
        private bool ShowResult { get; set; }
        private bool Succeed { get; set; }
        private string Expression { get; set; } = string.Empty;
        private string InputToMatch { get; set; } = string.Empty;
        private int TotalMatches { get; set; }
        private List<RegexPart> RegexParts { get; set; } = new();

        public void TryMathExpression()
        {
            Reset();

            try
            {
                MathExpression();
            }
            catch (Exception)
            {
                ShowError = true;
            }
        }

        private void MathExpression()
        {
            Regex regex = new(Expression);
            Succeed = regex.IsMatch(InputToMatch);
            MatchCollection collection = regex.Matches(InputToMatch);
            TotalMatches = collection.Count;
            AddMatchToPage(collection, InputToMatch);
            ShowResult = true;
        }

        private void AddMatchToPage(MatchCollection collection, string source)
        {
            if (collection.Count < 1)
            {
                return;
            }

            int currentIndex = 0;

            foreach (Match match in collection)
            {
                // If the match begins after our current index, we need to add the
                // portion of the source string between the last match and the 
                // current match.
                if (match.Index > currentIndex)
                {
                    RegexParts.Add(new RegexPart
                    {
                        Valid = false,
                        Value = source.Substring(currentIndex, match.Index - currentIndex)
                    });
                }

                // Add the matched value, of course, to make the split inclusive.
                RegexParts.Add(new RegexPart
                {
                    Valid = true,
                    Value = match.Value
                });

                // Update the current index so we know if the next match has an
                // unmatched substring before it.
                currentIndex = match.Index + match.Length;
            }

            // Finally, check is there is a bit of unmatched string at the end of the 
            // source string.
            if (currentIndex < source.Length)
            {
                RegexParts.Add(new RegexPart
                {
                    Valid = false,
                    Value = source.Substring(currentIndex)
                });
            }
        }

        private void Reset()
        {
            RegexParts = new();
            ShowError = false;
        }
    }
}
