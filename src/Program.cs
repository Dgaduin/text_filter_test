using TextFilter.Engine;
using TextFilter.Filters;

var newPath = "";
if (args.Length > 0)
    newPath = args[0];
var path = string.IsNullOrEmpty(newPath) ? "test_text.txt" : newPath;
var text = File.ReadAllText(path);

var midVowelFilter = new MidVowelFilter();

var minLenOptions = new MinLengthFilterOptions(3);
var minLenFilter = new MinLengthFilter(minLenOptions);

var charFilterOptions = new CharExclusionFilterOptions('t');
var charFilter = new CharExclusionFilter(charFilterOptions);

var engine = new FilterEngine() { midVowelFilter, minLenFilter, charFilter };
var filteredText = engine.FilterText(text);

Console.WriteLine(filteredText);