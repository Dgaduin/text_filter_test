using TextFilter.Abstractions;

namespace TextFilter.Filters;

/// <summary>
/// Filters out words that contain the letter defined in the options
/// </summary>
public class CharExclusionFilter(CharExclusionFilterOptions options) : IWordFilterWithOptions<CharExclusionFilterOptions>
{
    public CharExclusionFilterOptions Options { get; init; } = options;

    /// <summary>
    /// Filters out words that contain the letter defined in the options
    /// </summary>
    /// <returns>True if the word should be filtered out</returns>
    public bool ShouldFilterOut(string word) => word.Contains(Options.Char);
}