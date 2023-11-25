namespace TextFilter.Abstractions;

public interface IWordFilterWithOptions<T> : IWordFilter where T : IWordFilterOptions
{
    T Options { get; }
}
