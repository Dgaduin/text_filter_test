namespace TextFilter.Abstractions;

public interface IWordFilter<T> where T : IFilterOptions
{
    T Options { get; }
    bool TestWord(string word);
}
