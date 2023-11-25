using TextFilter.Abstractions;

namespace TextFilter.Filters;

/// <summary>
/// Filters out words that are shorter than the defined length in the options
/// </summary>
public class MinLengthFilter(MinLengthFilterOptions options) : IWordFilterWithOptions<MinLengthFilterOptions>
{
    public MinLengthFilterOptions Options { get; init; } = options;

    /// <summary>
    /// Filters out words that are shorter than the defined length in the options
    /// </summary>
    /// <returns>True if the word should be filtered out</returns>
    public bool ShouldFilterOut(string word) => word.Length < Options.MinLength;
}