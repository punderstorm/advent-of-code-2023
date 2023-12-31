using System.Text.RegularExpressions;

public static class day2
{
    public static void Run()
    {
        var cubeGames = System.IO.File.ReadAllLines(@$"day2/input.txt").ToList();

        var allCubeGameData = GetAllCubeGameData(cubeGames);

        Part1(allCubeGameData);
        Part2(allCubeGameData);
    }

    private static List<GameData> GetAllCubeGameData(List<string> cubeGames)
    {
        return cubeGames.Select(g => {
            var split = g.Split(":");
            var gameID = int.Parse(split[0].Replace("Game ", ""));
            
            var cubeData = Regex.Matches(split[1], @"(\d+) (red|green|blue)")
                .Select(m => {
                    var numCubes = int.Parse(m.Groups[1].Value);
                    var cubeColor = m.Groups[2].Value;
                    return new KeyValuePair<string, int> (cubeColor, numCubes);
                })
                .GroupBy(m => m.Key)
                .Select(g => new CubeData { CubeColor = g.Key, CubeAmount = g.Aggregate((agg, next) => next.Value > agg.Value ? next : agg).Value })
                .ToList();

            return new GameData { GameID = gameID, CubeData = cubeData };
        }).ToList();
    }

    private static void Part1(List<GameData> allCubeGameData)
    {
        var cubeComparison = new Dictionary<string, int>{
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        // final solution
        Console.WriteLine(allCubeGameData
            .Where(g => g.CubeData.Where(c => c.CubeAmount <= cubeComparison[c.CubeColor]).Count() == 3)
            .Sum(g => g.GameID)
        );
    }

    private static void Part2(List<GameData> allCubeGameData)
    {
        // final solution
        Console.WriteLine(allCubeGameData
            .Sum(g => g.CubeData.Select(c => c.CubeAmount).Aggregate((agg, next) => agg * next))
        );
    }

    private class CubeData
    {
        public string CubeColor { get; set; } = "";
        public int CubeAmount { get; set; }
    }

    private class GameData
    {
        public int GameID { get; set; }
        public List<CubeData> CubeData { get; set; } = new List<CubeData>();
    }
}