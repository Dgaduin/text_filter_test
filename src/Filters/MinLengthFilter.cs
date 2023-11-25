using TextFilter.Abstractions;

namespace TextFilter.Filters;

public class MinLengthFilter(MinLengthFilterOptions options) : IWordFilterWithOptions<MinLengthFilterOptions>
{
    public MinLengthFilterOptions Options { get; init; } = options;

    public bool TestWord(string word) => word.Length >= Options.MinLength;
}