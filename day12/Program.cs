﻿namespace day12;
class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        Map m = new Map(lines);
        // for each map location, set its list of neighbors
        // only allow 1 step upward
        m.ComputeNeighbors();

        SolveFrom(m, m.EndLoc);

        var startingLocations = m.PossibleStartLocations();

        int min = int.MaxValue;
        foreach(var l in startingLocations)
        {
            if (l.StepsFromStart < min)
            {
                min = l.StepsFromStart;
            }
        }

        Console.WriteLine($"Part 1 Answer: {m.StartLoc.StepsFromStart}");
        Console.WriteLine($"Part 2 Answer: {min}");
    }

    public static void SolveFrom(Map m, MapLocation startLoc)
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
                if (l.StepsFromStart != int.MaxValue &&
                    l.StepsFromStart + 1 < neighbor.StepsFromStart)
                {
                    neighbor.StepsFromStart = l.StepsFromStart + 1;
                }
            }

        }
    }
}

