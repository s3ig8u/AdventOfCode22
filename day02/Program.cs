var lines = File.ReadAllLines("input.txt");
var gameList = new List<(string, string)>();
var part1Answer = 0;
var part2Answer = 0;
var dic = new Dictionary<string, int>
{
    { "X",1 },
    { "Y",2 },
    { "Z",3 }
};
var winner = new Dictionary<string, string>
{
    { "A", "Y" },
    { "B", "Z"},
    { "C", "X" }
};
var loser = new Dictionary<string, string>
{
    { "A", "Z" },
    { "B", "X"},
    { "C", "Y" }
};
var draw = new Dictionary<string, string>
{
    { "A", "X" },
    { "B", "Y"},
    { "C", "Z" }
};
var indexes = new Dictionary<string, int>
{
    { "X",0 },
    { "Y",1 },
    { "Z",2 },
    { "A",0 },
    { "B",1 },
    { "C",2 }
};
var winningMatrix = new int[3][]{
    new int[]{ 3,6,0 },
    new int[]{ 0,3,6 },
    new int[]{ 6,0,3 },
};
foreach (var line in lines)
{
    var game = line.Split(' ');
    gameList.Add((game[0], game[1]));

    var selection = string.Empty;
    selection = FindMove(game);
    var (opponent, me) = (indexes[game[0]], indexes[game[1]]);
    var (opponent2, me2) = (indexes[game[0]], indexes[selection]);

    part1Answer += dic[game[1]] + winningMatrix[opponent][me];
    part2Answer += dic[selection] + winningMatrix[opponent2][me2];
}

Console.WriteLine(part1Answer);
Console.WriteLine(part2Answer);

string FindMove(string[] game)
{
    string selection = game[1];
    switch (game[1])
    {
        case "X":
            selection = loser[game[0]];
            break;
        case "Y":
            selection = draw[game[0]];
            break;
        case "Z":
            selection = winner[game[0]];
            break;
        default:
            selection = game[1];
            break;
    }
    return selection;
}