namespace TextFilter.Abstractions;

public interface IWordFilter
{
    bool TestWord(string word);
}
