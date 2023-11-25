using TextFilter.Filters;

namespace TextFilterTests;

public class MinLengthFilterTests
{
    [Theory]
    [InlineData(3, "add")]
    [InlineData(2, "cat")]
    [InlineData(4, "diner")]
    [InlineData(1, "bool")]
    [InlineData(3, "code")]
    [InlineData(7, "testing")]
    public void AssertPassing(uint minLength, string word)
    {
        var options = new MinLengthFilterOptions(minLength);
        var filter = new MinLengthFilter(options);
        var result = filter.TestWord(word);
        Assert.True(result);
        Assert.True(minLength <= word.Length);
    }
}