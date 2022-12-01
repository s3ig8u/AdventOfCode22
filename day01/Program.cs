var lines = File.ReadAllLines("input.txt");
var elves = new Dictionary<int, int>();
var index = 0;
(int index,int amount) max = (0,0);

foreach(var line in lines)
{
    if(line == string.Empty)
    {
        if (elves[index] > max.amount)
        {
            max = (index, elves[index]);
        }
        index++;
        continue;
    }
    if(!elves.ContainsKey(index))
    {
        elves.Add(index, 0);
    }
    elves[index] += Convert.ToInt32(line);
}
// find the top three elves
var part2Total = elves
    .ToList()
    .OrderByDescending(p => p.Value)
    .Take(3)
    .Sum(p=>p.Value);

Console.WriteLine($"first: {max.amount}");
Console.WriteLine($"second: {part2Total}");