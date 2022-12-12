namespace day12;
class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        Map m = new Map(lines);
        // for each map location, set its list of neighbors
        // only allow 1 step upward
        m.ComputeNeighbors(maxUpHeight: 1);

        Console.WriteLine($"Max int: {int.MaxValue}");

        foreach (var start in m.PossibleStartLocations())
        {
            int steps = SolveFrom(m, start);
            Console.WriteLine(steps);
        }

    }

    public static int SolveFrom(Map m, MapLocation startLoc)
    {
        List<MapLocation> ShortestPathSet = new List<MapLocation>();
        m.SetDistancesToMax();
        var allLocations = m.AllLocations();
        startLoc.StepsFromStart = 0;

        // continue until the ShortestPathSet contains all locations
        while (allLocations.Any())
        {
            MapLocation l = allLocations
                .OrderBy(x => x.StepsFromStart)
                .First();
            ShortestPathSet.Add(l);
            allLocations.Remove(l);

            var neighbors = l.Neighbors;
            foreach (MapLocation neighbor in neighbors)
            {
                if (neighbor.StepsFromStart > l.StepsFromStart + 1)
                {
                    neighbor.StepsFromStart = l.StepsFromStart + 1;
                }
            }

        }

        return m.EndLoc.StepsFromStart;
    }
}

