using TextFilter.Filters;

namespace TextFilterTests;

public class CharExclusionFilterTests
{
    [Theory]
    [InlineData('a', "add")]
    [InlineData('t', "cat")]
    [InlineData('r', "diner")]
    [InlineData('o', "bool")]
    [InlineData('e', "code")]
    [InlineData('s', "testing")]
    public void AssertPassing(char c, string word)
    {
        var options = new CharExclusionFilterOptions(c);
        var filter = new CharExclusionFilter(options);
        var result = filter.ShouldFilterOut(word);
        Assert.True(result);
    }
}