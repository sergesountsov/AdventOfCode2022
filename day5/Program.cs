using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

var layout = input.TakeWhile(line => line.StartsWith("[")).Reverse();
var stackCount = Convert.ToInt32(input.First(line => line.StartsWith(" 1")).Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

var stacks = ParseLayout(layout, stackCount);

//DisplayStacks(stacks);

var program = input.SkipWhile(line => !line.StartsWith("move"));

var reg = new Regex(@"move (\d+) from (\d+) to (\d+)");
foreach (string command in program )
{
    var match = reg.Match(command);
    int count = Convert.ToInt32(match.Groups[1].Value);
    int from = Convert.ToInt32(match.Groups[2].Value) - 1;
    int to = Convert.ToInt32(match.Groups[3].Value) - 1;

    for (int i =0; i < count; i++)
    {
        stacks[to].Add(stacks[from][stacks[from].Count-1]);
        stacks[from].RemoveAt(stacks[from].Count - 1);
    }
}

foreach (var stack in stacks)
{
    Console.Write(stack.Last());
}

Console.WriteLine();

static List<List<char>> ParseLayout(IEnumerable<string> layout, int stackCount)
{
    List<List<char>> stacks = new(stackCount);
    for (int i = 0; i < stackCount; i++)
    {
        stacks.Add(new List<char>());
    }

    foreach (var line in layout)
    {
        for (int stackIdx = 0; stackIdx < stackCount; stackIdx++)
        {
            int pos = stackIdx * 4 + 1;
            if (line[pos] != ' ')
            {
                stacks[stackIdx].Add(line[pos]);
            }
        }
    }

    return stacks;
}

static void DisplayStacks(List<Stack<char>> stacks)
{
    foreach (var stack in stacks)
    {
        foreach (char c in stack)
        {
            Console.Write(c);
        }
        Console.WriteLine();
    }
}