# Text Filter Test
An modular solution to allow for ordering multiple filters to apply to a single instance of a text to in-place replace words that don't pass certain filters.

The core design is based around the `IWordFilter` interface which exposes a single method called `ShouldFilterOut`, which shows if a word should be removed or kept.

The implementation of the FilterEngine is just a simple extension of `List` with a `ShouldFilterOut` method of its own calling the list of filters, and a `FilterText` which handles the in place replacement.

## Instructions
### Testing
Run `dotnet test` in the root directory
### Running
Run `dotnet run` in the `src` directory
If you want to test with the file with no line breaks run `dotnet run test_text_no_lbs.txt`. This also supports pointing to any file, but there is no validation on it, so there might be errors related to file access and similar.

## Notes
### Input
Give the text was given in a PDF I was not sure to keep or to remove the line breaks - the code would work for both.
### `FilterEngine`
For a real implementation an approach that is backed by a sortable and re-orderable structure would be a better approach, but for this task `List` gives us a lot of nice methods to initiliase and expand the structure instead of having to proxy all of them ourselves (including parameter validation).
In a bigger solution with more features it would be useful to abstract the interface for it.
Also the outputs of this feature can end up containing a lot of whitespace that might need trimming - there is an optional trim flag that can be passed to the call by amending this line:
```csharp
var filteredText = engine.FilterText(text); -> var filteredText = engine.FilterText(text,true);
```
### `IWordFilter`
This could have been done with a delegate type, but classes gives us some more tools to work with, especially around the type system.
### Main program
All parameter casting can b