using TextFilter.Engine;
using TextFilter.Filters;

namespace TextFilterTests;

public class FilterEngineTests
{
    private readonly FilterEngine Engine;
    public FilterEngineTests()
    {
        var charFilterOptions = new CharExclusionFilterOptions('t');
        var charFilter = new CharExclusionFilter(charFilterOptions);

        var minLenOptions = new MinLengthFilterOptions(3);
        var minLenFilter = new MinLengthFilter(minLenOptions);

        Engine = [charFilter, minLenFilter];
        // or equivalently
        // Engine.Add(charFilter);
        // Engine.Add(minLenFilter);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    [InlineData("\r")]
    [InlineData("\n")]
    [InlineData("   \n")]
    [InlineData("\n\r   \n\r")]
    [InlineData("abc    ")]
    [InlineData("     abc")]
    [InlineData("a  bc")]
    public void AssertWhitespaceCheckOnShould(string word)
    {
        Assert.ThrowsAny<Exception>(() => Engine.ShouldFilterOut(word));
    }

    [Theory]
    [InlineData("bar")]
    [InlineData("bone")]
    [InlineData("spade")]
    [InlineData("gone")]
    [InlineData("clearly")]
    [InlineData("council")]
    public void AssertPassingWordsOnShould(string word)
    {
        var result = Engine.ShouldFilterOut(word);
        Assert.False(result);
    }

    [Theory]
    [InlineData("tone")]
    [InlineData("be")]
    [InlineData("a")]
    [InlineData("train")]
    [InlineData("court")]
    [InlineData("bartering")]
    public void AssertFailingWordsOnShould(string word)
    {
        var result = Engine.ShouldFilterOut(word);
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    [InlineData("\r")]
    [InlineData("\n")]
    [InlineData("   \n")]
    [InlineData("\n\r   \n\r")]
    public void AssertWhitespaceCheckOnFilter(string word)
    {
        Assert.ThrowsAny<Exception>(() => Engine.FilterText(word));
    }

    //We expect to remove words with <3 letters and containing 't'
    [Theory]
    [InlineData("At the table", "  ")]
    [InlineData("How are you doing?", "How are you doing?")]
    [InlineData("Where is the cat?", "Where   ?")]
    [InlineData("Good night!", "Good !")]
    [InlineData("{{!test}}", "{{!}}")]
    [InlineData("drama;cost;up;dog;cats;))told you((", "drama;;;dog;;)) you((")]
    public void AssertFilterOut(string input, string expected)
    {
        var result = Engine.FilterText(input);
        Assert.Equal(expected, result);
    }
}