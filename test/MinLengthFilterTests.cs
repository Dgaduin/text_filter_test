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
        var result = filter.ShouldFilterOut(word);
        Assert.False(result);
        Assert.False(minLength > word.Length);
    }
}