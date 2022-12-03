using Common;

var input = Parsing.ParseSingleLine("input.txt");
int part1 = input.Aggregate(0, (total, next) => total + Priority(FindDupe(next!))); 
Console.WriteLine ("Part 1 result: {0}", part1);
// Tests();

int Priority(char c) => c switch {
    >='a' and <='z' => Convert.ToInt32(c) - Convert.ToInt32('a') + 1,
    >='A' and <='Z' => Convert.ToInt32(c) - Convert.ToInt32('A') + 27,
    _ => throw new ArgumentException ($"Priority is not defined for {c}")
};

char FindDupe (string backpack) =>
    backpack.Take(backpack.Length/2).Intersect(backpack.TakeLast(backpack.Length/2)).First();

void Tests() {
    Console.WriteLine (FindDupe("bhcdec"));
    Console.WriteLine($"QLFdFCdlLcVqdvFLnFLSSShZwptfHHhfZZZpSwfmHp => {FindDupe("QLFdFCdlLcVqdvFLnFLSSShZwptfHHhfZZZpSwfmHp")}");
}