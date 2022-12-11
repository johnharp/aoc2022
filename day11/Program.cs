using day11;
using System.Numerics;

//PrimePolyTerm t = new PrimePolyTerm(66);
//t.MultiplyByPrime(11);
//t.MultiplyByPrime(11);
//Console.WriteLine(t);
//t = t.Mult(t);
//Console.WriteLine(t);

//PrimePoly p = new PrimePoly(66);
//p.DoChecks = true;

//Console.WriteLine(p);
//p.MultiplyByPrime(11);
//Console.WriteLine(p);
//p.AddNumber(6);
//Console.WriteLine(p);


//p.AddNumber(3);
//Console.WriteLine(p);

//p.Square();
//Console.WriteLine(p);


//Console.WriteLine($"Divisible by 79 => {p.IsDivisibleBy(79)}");
//Console.WriteLine("Adding 3");
//p.AddNumber(3);
//Console.WriteLine(p);
//Console.WriteLine($"Divisible by 79 => {p.IsDivisibleBy(79)}");
//Console.WriteLine("Squaring");
//p.Square();
//Console.WriteLine(p);

//Console.WriteLine("Multiplying by 19");
//p.MultiplyByPrime(19);
//Console.WriteLine(p);

//Console.WriteLine($"Divisible by 19 => {p.IsDivisibleBy(19)}");


CreateExampleMonkeys();
//CreatePart1Monkeys();

Monkey.PrintAll();

for (int i = 1; i <= 20; i++)
{
    Monkey.CompleteRound();
    Console.WriteLine($"After round {i}:");
    Monkey.PrintAll();
    Console.WriteLine();
}

Monkey.PrintMonkeyBusinessLevel();



void CreateExampleMonkeys()
{
    Monkey m;

    m = new Monkey(79, 98);
    m.Operation = (PrimePoly p) => p.MultiplyByPrime(19);
    m.Test = (PrimePoly p) => p.IsDivisibleBy(23) ? 2 : 3;
    Monkey.All.Add(m);

    m = new Monkey(54, 65, 75, 74);
    m.Operation = (PrimePoly p) => p.AddNumber(6);
    m.Test = (PrimePoly p) => p.IsDivisibleBy(19) ? 2 : 0;
    Monkey.All.Add(m);

    m = new Monkey(79, 60, 97);
    m.Operation = (PrimePoly p) => p.Square();
    m.Test = (PrimePoly p) => p.IsDivisibleBy(13) ? 1 : 3;
    Monkey.All.Add(m);

    m = new Monkey(74);
    m.Operation = (PrimePoly p) => p.AddNumber(3);
    m.Test = (PrimePoly p) => p.IsDivisibleBy(17) ? 0 : 1;
    Monkey.All.Add(m);
}

//void CreatePart1Monkeys()
//{
//    Monkey m;

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 66, 79 };
//    m.Operation = (long old) => old * 11;
//    m.Test = (long x) => (x % 7 == 0) ? 6 : 7;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 84, 94, 94, 81, 98, 75 };
//    m.Operation = (long old) => old * 17;
//    m.Test = (long x) => (x % 13 == 0) ? 5 : 2;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 85, 79, 59, 64, 79, 95, 67 };
//    m.Operation = (long old) => old + 8;
//    m.Test = (long x) => (x % 5 == 0) ? 4 : 5;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 70 };
//    m.Operation = (long old) => old + 3;
//    m.Test = (long x) => (x % 19 == 0) ? 6 : 0;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 57, 69, 78, 78 };
//    m.Operation = (long old) => old + 4;
//    m.Test = (long x) => (x % 2 == 0) ? 0 : 3;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 65, 92, 60, 74, 72 };
//    m.Operation = (long old) => old + 7;
//    m.Test = (long x) => (x % 11 == 0) ? 3 : 4;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 77, 91, 91 };
//    m.Operation = (long old) => old * old;
//    m.Test = (long x) => (x % 17 == 0) ? 1 : 7;
//    Monkey.All.Add(m);

//    m = new Monkey();
//    m.ItemsOld = new List<long> { 76, 58, 57, 55, 67, 77, 54, 99 };
//    m.Operation = (long old) => old + 6;
//    m.Test = (long x) => (x % 3 == 0) ? 2 : 1;
//    Monkey.All.Add(m);
//}