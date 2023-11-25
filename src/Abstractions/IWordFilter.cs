namespace TextFilter.Abstractions;

public interface IWordFilter<T> where T : IWordFilterOptions
{
    T Options { get; }
    /// <summary>
    /// Tests if a word matches a filter
    /// </summary>
    /// <param name="word">word to test</param>
    /// <returns>Returns true if the word passes the filter</returns>
    bool TestWord(string word);
}
