using TextFilter.Abstractions;

namespace TextFilter.Filters;

public class CharExclusionFilter(CharExclusionFilterOptions options) : IWordFilter<CharExclusionFilterOptions>
{
    public CharExclusionFilterOptions Options { get; init; } = options;

    public bool TestWord(string word)
    {
        throw new NotImplementedException();
    }
}