using TextFilter.Abstractions;

namespace TextFilter.Filters;

public class MidVowelFilter(MidVowelFilterOptions options) : IWordFilter<MidVowelFilterOptions>
{
    public MidVowelFilterOptions Options { get; init; } = options;

    public bool TestWord(string word)
    {
        throw new NotImplementedException();
    }
}