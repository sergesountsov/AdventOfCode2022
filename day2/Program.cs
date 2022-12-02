using Common;

Dictionary<string,int> theirCode = new(){
    {"A", 1}, // ROCK
    {"B", 2}, // PAPER
    {"C", 3}  // SCISSORS
};

Dictionary<string,int> ourCode = new() {
    {"X", 1}, // ROCK 
    {"Y", 2}, // PAPER 
    {"Z", 3}  // SCISSORS
};

Dictionary<string, int> outcomeCode = new() {
    {"X", 0},
    {"Y", 3},
    {"Z", 6}
};

int ScoreRound((int theirs, int yours) roundChoice) => roundChoice
    switch {
        (1,1) => 3,
        (1,2) => 6,
        (1,3) => 0,
        (2,1) => 0,
        (2,2) => 3,
        (2,3) => 6,
        (3,1) => 6,
        (3,2) => 0,
        (3,3) => 3,
        (_,_) => throw new ArgumentException($"Unexpected input ${roundChoice})")
    };

int ChooseOurs((int theirs, int outcome) outcome) => outcome switch  {
    (1,0) => 3, // ROCK WINS SCISSORS
    (1,3) => 1, // ROCK DRAW
    (1,6) => 2, // ROCK LOSES to PAPER
    (2,0) => 1, // PAPER WINS ROCK
    (2,3) => 2, // PAPER DRAW
    (2,6) => 3, // PAPER LOSES to SCISSORS
    (3,0) => 2, // SCISSORS WIN PAPER
    (3,3) => 3, // SCISSORS DRAW
    (3,6) => 1, // SCISSORS LOSE to ROCK
    (_,_) => throw new ArgumentException($"Unexpected input ${outcome})")
};

var input1 = Parsing.ParseSingleLine("input.txt")
    .Select(str => {
        var res = str!.Split(" ");
        return (theirCode[res[0]], ourCode[res[1]]);
        });
int part1 = input1.Aggregate(0, (total, next) =>
    total + next.Item2 + ScoreRound(next) 
);
Console.WriteLine("Part 1 result: {0}", part1);

var input2 = Parsing.ParseSingleLine("input.txt")
    .Select(str => {
        var res = str!.Split(" ");
        return (theirCode[res[0]], outcomeCode[res[1]]);
        });
int part2 = input2.Aggregate(0, (total,next) => total + ChooseOurs(next) + next.Item2 );
Console.WriteLine("Part 2 result {0}", part2);