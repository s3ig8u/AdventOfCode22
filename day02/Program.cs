var lines = File.ReadAllLines("input.txt");

var gameList = new List<(string, string)>();
var index = 0;
(int index, int amount) max = (0, 0);
var answer = 0;
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
    { "Y",1},
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
    switch (game[0])
    {
        case "A":
            if (selection == "X")
            {
                answer += dic[selection] + 3;
            }
            if (selection == "Y")
            {
                answer += dic[selection] + 6;
            }
            if (selection == "Z")
            {
                answer += dic[selection] + 0;
            }
            break;
        case "B":
            if (selection == "X")
            {
                answer += dic[selection] + 0;
            }
            if (selection == "Y")
            {
                answer += dic[selection] + 3;
            }
            if (selection == "Z")
            {
                answer += dic[selection] + 6;
            }
            break;
        case "C":
            if (selection == "X")
            {
                answer += dic[selection] + 6;
            }
            if (selection == "Y")
            {
                answer += dic[selection] + 0;
            }
            if (selection == "Z")
            {
                answer += dic[selection] + 3;
            }
            break;
        default:
            break;
    }
}
Console.WriteLine(answer);