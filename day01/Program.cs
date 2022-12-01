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
Console.WriteLine(max);