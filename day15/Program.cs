namespace day15;

class Program
{
    static void Main(string[] args)
    {
        World world = new World();
        string[] lines = File.ReadAllLines("../../../input-example.txt");

        foreach(var line in lines)
        {
            world.HandleInputLine(line);
        }


    }
}

