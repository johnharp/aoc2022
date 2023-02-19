using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace day15
{
	public class World
	{
		public List<Sensor> Sensors { get; }
		public List<Beacon> Beacons { get; }

		public World()
		{
			Sensors = new List<Sensor>();
			Beacons = new List<Beacon>();
		}

		public void HandleInputLine(string l)
		{
            Regex rx = new Regex(
				@"^Sensor at x=(?<SensorX>[\+-]?\d+), y=(?<SensorY>[\+-]?\d+): closest beacon is at x=(?<BeaconX>[\+-]?\d+), y=(?<BeaconY>[\+-]?\d+)$",
				RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(l);

			var match = matches.First();
			int sx = GetMatch(match, "SensorX");
			int sy = GetMatch(match, "SensorY");
			int bx = GetMatch(match, "BeaconX");
			int by = GetMatch(match, "BeaconY");

			Beacon b = new Beacon(bx, by);
			Sensor s = new Sensor(sx, sy, b);
        }

		private int GetMatch(Match? match, string key)
		{
			if (match == null) throw new FormatException("Bad input line");

			int v = int.Parse(match.Groups[key].Value);
			return v;
		}
    }
}

