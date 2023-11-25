using TextFilter.Abstractions;

namespace TextFilter.Filters;

public class CharExclusionFilter(CharExclusionFilterOptions options) : IWordFilterWithOptions<CharExclusionFilterOptions>
{
    public CharExclusionFilterOptions Options { get; init; } = options;

    public bool ShouldFilterOut(string word) => word.Contains(Options.Char);
}