using System;
using System.IO;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = File.ReadAllLines("../../../input.txt");

            Console.WriteLine($"total lines: {lines.Length}");
        }
    }
}
