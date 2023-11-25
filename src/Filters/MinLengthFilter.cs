using TextFilter.Abstractions;

namespace TextFilter.Filters;

public class MinLengthFilter(MinLengthFilterOptions options) : IWordFilter<MinLengthFilterOptions>
{
    public MinLengthFilterOptions Options { get; private set; } = options;

    public bool TestWord(string word) => word.Length >= options.MinLength;
}