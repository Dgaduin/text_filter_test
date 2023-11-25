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
}