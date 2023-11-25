﻿namespace TextFilter.Abstractions;

public interface IWordFilter
{
    /// <summary>
    /// Tests if a word matches a filter
    /// </summary>
    /// <param name="word">word to test</param>
    /// <returns>true if the word passes the filter, false if it should be filtered out</returns>
    bool TestWord(string word);
}
