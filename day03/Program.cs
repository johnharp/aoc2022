using System;
using System.Collections.Generic;
using System.IO;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");
            Solve(lines);
        }

        static void Solve(String[] lines)
        {
            long totalOfPriorities = 0;

            foreach(var line in lines)
            {
                totalOfPriorities += SolveLine(line);
            }

            Console.WriteLine($"Total priority of matching items: {totalOfPriorities}");
        }

        static long SolveLine(String line)
        {
            long priorityOfMatchingItems = 0;

            int numItems = line.Length;
            int itemsPerCompartment = numItems / 2;

            String leftItems = line.Substring(0, itemsPerCompartment);
            String rightItems = line.Substring(itemsPerCompartment, itemsPerCompartment);

            char match = FindMatchingItem(leftItems, rightItems);
            long priority = priorityOfMatchingItem(match);

            priorityOfMatchingItems += priority;

            return priorityOfMatchingItems;
        }

        static char FindMatchingItem(String left, String right)
        {
            HashSet<char> leftHash = new HashSet<char>(left);
            foreach(char c in right.ToCharArray())
            {
                if (leftHash.Contains(c)) return c;
            }

            return ' ';
        }

        static long priorityOfMatchingItem(char c)
        {
            long value = 0;

            if (Char.IsUpper(c))
            {
                value = c - 'A' + 27;
            }
            else
            {
                value = c - 'a' + 1;
            }

            return value;
        }
    }
}
