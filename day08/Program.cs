namespace day08;
class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("../../../input.txt");
        TreeMap m = new TreeMap(lines);

        //Console.WriteLine($"# Cols: {m.NumCols}");
        //Console.WriteLine($"# Rows: {m.NumRows}");

        int numberTreesVisible = m.CalculateVisMap();

        Console.WriteLine("Map:");
        m.PrintMap();

        Console.WriteLine();
        Console.WriteLine("VisMap ");
        m.PrintVisMap();

        Console.WriteLine();
        Console.WriteLine($"Total Trees Visible: {numberTreesVisible}");

    }
}

