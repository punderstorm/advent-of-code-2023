using System.Linq;
using System.Text.RegularExpressions;

public static class day1
{
    public static void Run()
    {
        var calibrations = System.IO.File.ReadAllLines(@$"day1/input.txt").ToList();
        Part1(calibrations);
        Part2(calibrations);
    }

    private static void Part1(List<string> calibrations)
    {
        // final solution
        Console.WriteLine(calibrations.Select(calibrationLine => {
            var calibrationNumbers = Regex.Matches(calibrationLine, @"\d");
            return int.Parse($"{calibrationNumbers.First()}{calibrationNumbers.Last()}");
        }).Sum());
    }

    private static void Part2(List<string> calibrations)
    {
        // final solution
        Console.WriteLine(calibrations.Select(calibrationLine => {
            var calibrationNumbers = Regex.Matches(calibrationLine, @"(?<=(one|two|three|four|five|six|seven|eight|nine|\d))")
                .Select(c => Helpers.GetNumberFromWord(c.Groups[1].Value));
            return int.Parse($"{calibrationNumbers.First()}{calibrationNumbers.Last()}");
        }).Sum());
    }
}