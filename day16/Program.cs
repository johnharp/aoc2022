namespace day16;
class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("../../../input.txt");

        foreach (var line in lines)
        {
            var v = new Valve(line);
        }

        foreach(var v in Valve.ValveDictionary.Values)
        {
            Console.WriteLine(v);
        }
    }
}

