var lines = File.ReadAllLines("input.txt");
var part1Answer = 0;
var part2Answer = 0;

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

    var selection = FindMove(game);
    var (opponent, me, me2) = (indexes[game[0]], indexes[game[1]], indexes[selection]);
    // +1 because of your move index in indexes dictionary starts from 0
    // so I need to +1 to get actual result of game.
    part1Answer += 1 + indexes[game[1]] + winningMatrix[opponent][me];
    part2Answer += 1 + indexes[selection] + winningMatrix[opponent][me2];
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