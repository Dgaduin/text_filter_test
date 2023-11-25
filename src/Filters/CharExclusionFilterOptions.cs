using TextFilter.Abstractions;

namespace TextFilter.Filters;

public record CharExclusionFilterOptions(char Char) : IFilterOptions { }
