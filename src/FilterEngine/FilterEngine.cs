using System.Text;
using System.Text.RegularExpressions;
using TextFilter.Abstractions;

namespace TextFilter.Engine;

/// <summary>
/// A simplified list of filters to be executed in order
/// </summary>
public class FilterEngine : List<IWordFilter>
{
    /// <summary>
    /// Checks if the filter should pass the filters
    /// </summary>
    /// <param name="word">The word to check</param>
    /// <returns>true if the word would be filtered out by any of the filters</returns>
    /// <exception cref="ArgumentException"></exception>
    public bool ShouldFilterOut(string word)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(word);
        if (word.Any(char.IsWhiteSpace)) throw new ArgumentException("Single word checks should not include whitespace");

        var flag = false;
        foreach (var filter in this)
        {
            flag = flag || filter.ShouldFilterOut(word);
        }
        return flag;
    }


    public string FilterText(string text, bool trim = false)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);

        var resultBuffer = new StringBuilder();
        var wordBuffer = new StringBuilder();
        foreach (var c in text)
        {
            if (Char.IsLetter(c))
                wordBuffer.Append(c);
            else
            {
                if (wordBuffer.Length > 0)
                {
                    var word = wordBuffer.ToString();
                    wordBuffer.Clear();

                    var isFilteredOut = ShouldFilterOut(word);
                    if (!isFilteredOut) resultBuffer.Append(word);
                }
                resultBuffer.Append(c);
            }
        }
        var result = resultBuffer.ToString();
        return trim ?
            Regex.Replace(result, @"\s+", " ") :
            result;
    }
}