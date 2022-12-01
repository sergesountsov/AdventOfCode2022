using Common;

var input = Parsing.ParseSingleLine("input.txt");
var part1 = input.ChunkBy(String.IsNullOrEmpty).Max(chunk => chunk.Aggregate(0, (total, next) => total + int.Parse(next)));
Console.WriteLine(part1!);

