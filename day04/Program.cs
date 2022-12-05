string[] pairs = File.ReadAllLines("input.txt");
int overlapPairs = 0;
int allDigitsOverlap = 0;
for (var index = 0; index < pairs.Length; index++)
{
    //7 - 7,8 - 42
    var parts = pairs[index].Split(',');
    var pair1 = parts[0].Split("-");
    var pair2 = parts[1].Split("-");
    (int start1, int end1) = (int.Parse(pair1[0]), int.Parse(pair1[1]));
    (int start2, int end2) = (int.Parse(pair2[0]), int.Parse(pair2[1]));
    if (start2 >= start1 && end2 <= end1 || start1 >= start2 && end1 <= end2)
    {
        overlapPairs++;
    }
    if (start2 >= start1 && end1 >= start2 || start1 >= start2 && end2 >= start1)
    {
        allDigitsOverlap++;
    }
}
Console.WriteLine(overlapPairs);
Console.WriteLine(allDigitsOverlap);

// A HashSet to store the ranges
HashSet<(int, int)> ranges = new HashSet<(int, int)>();

// A counter to keep track of the number of pairs where one
// range fully contains the other
int counter = 0;

// Loop over the pairs and split each pair on the hyphen character
// to get the start and end of the range. Convert the start and end
// of each range to integers, and store the range in the HashSet.
foreach (string pair in pairs)
{
    string[] parts = pair.Split("-");
    int start = int.Parse(parts[0]);
    int end = int.Parse(parts[1]);
    var range = (start, end);

    // If the range is already in the HashSet, increment the counter.
    // Otherwise, add the range to the HashSet.
    if (ranges.Contains(range))
    {
        counter++;
    }
    else
    {
        ranges.Add(range);
    }
}

// Print the result
Console.WriteLine(counter);