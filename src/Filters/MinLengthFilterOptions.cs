using TextFilter.Abstractions;

namespace TextFilter.Filters;

public record MinLengthFilterOptions(uint MinLength) : IWordFilterOptions { }
