using TextFilter.Filters;

namespace TextFilterTests;

public class MidVowelFilterTests
{
    private readonly MidVowelFilter Filter;

    public MidVowelFilterTests() => Filter = new MidVowelFilter();

    [Theory]
    [InlineData("clean")]
    [InlineData("what")]
    [InlineData("currently")]
    public void AssertPassing(string word)
    {
        var result = Filter.ShouldFilterOut(word);
        Assert.True(result);
    }

    [Theory]
    [InlineData("the")]
    [InlineData("rather")]
    public void AssertFailing(string word)
    {
        var result = Filter.ShouldFilterOut(word);
        Assert.False(result);
    }
}