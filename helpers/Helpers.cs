using System.Text.RegularExpressions;

public static class Helpers
{
    public static bool IsNumeric(string value)
    {
        return value.All(char.IsNumber);
    }

    public static string GetNumberFromWord(string word)
    {
        if (word.All(char.IsNumber)) { return word; }
        var numbersAsWords = new Dictionary<string, string> {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
        var compiledRegex = new Regex(@"\w+", RegexOptions.Compiled);
        return compiledRegex.Replace(word, match => numbersAsWords[match.Value]);
    }
}