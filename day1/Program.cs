using Common;

var input = Parsing.ParseSingleLine("input.txt");
var totalPerElf = input.SplitBy(String.IsNullOrEmpty).Select(chunk => chunk.Aggregate(0, (total, next) => total + int.Parse(next!)));
var part1 = totalPerElf.Max();
Console.WriteLine($"Part 1 result = {part1!}");
var part2 = totalPerElf.Order().TakeLast(3).Aggregate(0, (total, next) => total + next);
Console.WriteLine($"Part 2 result = {part2!}");

