using Common;

var input = Parsing.ParseSingleLine("input.txt");
var totalPerElf = input.ChunkBy(String.IsNullOrEmpty).Select(chunk => chunk.Aggregate(0, (total, next) => total + int.Parse(next!)));
var part1 = totalPerElf.Max();
Console.WriteLine(part1!);

