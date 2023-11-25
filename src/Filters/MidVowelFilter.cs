using TextFilter.Abstractions;

namespace TextFilter.Filters;

/// <summary>
/// Filters out words that have a vowel in the middle
/// </summary>
public class MidVowelFilter : IWordFilter
{
    private static readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];

    /// <summary>
    /// Filters out words that have a vowel in the middle
    /// </summary>
    /// <returns>True if the word should be filtered out</returns>
    public bool ShouldFilterOut(string word)
    {
        var oddNumberOfChars = word.Length % 2 != 0;
        // not exact, but helps with offsetting the array indexing
        var middle = word.Length / 2;

        if (oddNumberOfChars)
            return vowels.Contains(word[middle]);
        else
            return vowels.Contains(word[middle - 1]) || vowels.Contains(word[middle]);
    }
}