using TextFilter.Filters;

namespace TextFilterTests;

public class MidVowelFilterTests
{
    private readonly MidVowelFilter Filter;

    public MidVowelFilterTests()
    {
        var options = new MidVowelFilterOptions();
        Filter = new MidVowelFilter(options);
    }

    [Theory]
    [InlineData("clean")]
    [InlineData("what")]
    [InlineData("currently")]
    public void AssertPassing(string word)
    {
        var result = Filter.TestWord(word);
        Assert.False(result);
    }

    [Theory]
    [InlineData("the")]
    [InlineData("rather")]
    public void AssertFailing(string word)
    {
        var result = Filter.TestWord(word);
        Assert.True(result);
    }
}