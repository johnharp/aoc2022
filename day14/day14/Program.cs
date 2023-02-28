using System.Dynamic;

namespace day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input-example.txt");
            Map m = new Map();
            m.Init(lines);
            m.MovingSand.Add(new Sand(500, 0));


            m.Print();
        }
    }
}