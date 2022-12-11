using day11;
using System.Numerics;

//CreateExampleMonkeys();
CreatePart1Monkeys();


for (int i = 1; i <= 10000; i++)
{
    //Console.WriteLine($"After round {i}:");
    Monkey.CompleteRound();
    //Monkey.PrintAll();
    //Console.WriteLine();
}

Monkey.PrintMonkeyBusinessLevel();



void CreateExampleMonkeys()
{
    Monkey m;

    m = new Monkey();
    m.Items = new List<long> { 79, 98 };
    m.Operation = (long old) => old * 19;
    m.Test = (long x) => (x % 23 == 0) ? 2 : 3;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 54, 65, 75, 74 };
    m.Operation = (long old) => old + 6;
    m.Test = (long x) => (x % 19 == 0) ? 2 : 0;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 79, 60, 97 };
    m.Operation = (long old) => old * old;
    m.Test = (long x) => (x % 13 == 0) ? 1 : 3;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 74 };
    m.Operation = (long old) => old + 3;
    m.Test = (long x) => (x % 17 == 0) ? 0 : 1;
    Monkey.All.Add(m);
}

void CreatePart1Monkeys()
{
    Monkey m;

    m = new Monkey();
    m.Items = new List<long> { 66, 79 };
    m.Operation = (long old) => old * 11;
    m.Test = (long x) => (x % 7 == 0) ? 6 : 7;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 84, 94, 94, 81, 98, 75 };
    m.Operation = (long old) => old * 17;
    m.Test = (long x) => (x % 13 == 0) ? 5 : 2;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 85, 79, 59, 64, 79, 95, 67 };
    m.Operation = (long old) => old + 8;
    m.Test = (long x) => (x % 5 == 0) ? 4 : 5;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 70 };
    m.Operation = (long old) => old + 3;
    m.Test = (long x) => (x % 19 == 0) ? 6 : 0;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 57, 69, 78, 78 };
    m.Operation = (long old) => old + 4;
    m.Test = (long x) => (x % 2 == 0) ? 0 : 3;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 65, 92, 60, 74, 72 };
    m.Operation = (long old) => old + 7;
    m.Test = (long x) => (x % 11 == 0) ? 3 : 4;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 77, 91, 91 };
    m.Operation = (long old) => old * old;
    m.Test = (long x) => (x % 17 == 0) ? 1 : 7;
    Monkey.All.Add(m);

    m = new Monkey();
    m.Items = new List<long> { 76, 58, 57, 55, 67, 77, 54, 99 };
    m.Operation = (long old) => old + 6;
    m.Test = (long x) => (x % 3 == 0) ? 2 : 1;
    Monkey.All.Add(m);
}