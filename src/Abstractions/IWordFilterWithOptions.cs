namespace TextFilter.Abstractions;

public interface IWordFilterWithOptions<T> : IWordFilter where T : IWordFilterOptions
{
    T Options { get; }
    /// <summary>
    /// Tests if a word matches a filter
    /// </summary>
    /// <param name="word">word to test</param>
    /// <returns>true if the word passes the filter, false if it should be filtered out</returns>
}
