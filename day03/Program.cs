// Define a mapping from letters to priorities
Dictionary<char, int> priorities = new Dictionary<char, int>();
for (int i = 0; i < 26; i++)
{
    priorities.Add((char)('a' + i), i + 1);
    priorities.Add((char)('A' + i), i + 27);
}

// Read the input
string[] rucksacks = File.ReadAllLines("input.txt");

// Go through each rucksack
int priority_sum = 0;
foreach (string rucksack in rucksacks)
{
    // Split the rucksack into two compartments
    string compartment1 = rucksack.Substring(0, rucksack.Length / 2);
    string compartment2 = rucksack.Substring(rucksack.Length / 2);

    // Create sets of the items in each compartment
    HashSet<char> items1 = new HashSet<char>(compartment1);
    HashSet<char> items2 = new HashSet<char>(compartment2);

    // Find the items that appear in both compartments
    HashSet<char> common_items = new HashSet<char>(items1);
    common_items.IntersectWith(items2);

    // Add the priorities of the common items to the sum
    foreach (char item in common_items)
    {
        priority_sum += priorities[item];
    }
}

// Print the sum of the priorities
Console.WriteLine($"part1:{priority_sum}");
// first part completely solved BY AI CHAT 
// OMG !! 

// Go through each group of rucksacks
priority_sum = 0;
for (int i = 0; i < rucksacks.Length; i += 3)
{
    HashSet<char> common_items = new HashSet<char>(rucksacks[i]);
    common_items.IntersectWith(rucksacks[i+1]);
    common_items.IntersectWith(rucksacks[i+2]);

    // Add the priorities of the common items to the sum
    foreach (char item in common_items)
    {
        priority_sum += priorities[item];
    }
}
Console.WriteLine($"part2:{priority_sum}");