var input = File.ReadAllLines("input.txt");
var ranges = input.Select(s => 
{
    var parts = s.Split(",");
    return (new Range(parts[0]), new Range(parts[1]));
});

var part1 = ranges.Aggregate(0, (total, next) => 
    total + ((next.Item1.Contains(next.Item2) || next.Item2.Contains(next.Item1)) ? 1 : 0)
);

Console.WriteLine("Part 1 result: {0}", part1);

record Range(int Start, int End) 
{
    public Range(string rangeStr) : this(0,0)
    {
        string[] parts = rangeStr.Split("-");
        Start = int.Parse(parts[0]);
        End = int.Parse(parts[1]);
    }

    public bool Contains(Range other) =>    
        other.Start >= this.Start && other.End <= this.End;
}