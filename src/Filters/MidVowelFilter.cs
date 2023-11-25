using TextFilter.Abstractions;

namespace TextFilter.Filters;

public class MidVowelFilter(MidVowelFilterOptions options) : IWordFilter<MidVowelFilterOptions>
{
    private static readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];
    public MidVowelFilterOptions Options { get; init; } = options;

    public bool TestWord(string word)
    {
        var oddNumberOfChars = word.Length % 2 != 0;
        // not exact, but helps with offsetting the array indexing
        var middle = word.Length / 2;

        if (oddNumberOfChars)
            return !vowels.Contains(word[middle]);
        else
            return !(vowels.Contains(word[middle - 1]) || vowels.Contains(word[middle]));
    }
}