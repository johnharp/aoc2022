using System;
using System.Text.RegularExpressions;

namespace day16
{
	public class Valve
	{
		public string Name { get; set; }
		public long Rate { get; set; }

		public List<String> ConnectedValveNames { get; set; }

		public static Dictionary<string, Valve> ValveDictionary = new Dictionary<string, Valve>();

		public Valve(string line)
		{
            Regex rx = new Regex(
                @"^Valve (?<Name>\w\w) has flow rate=(?<Rate>\d+); tunnel[s]? lead[s]? to valve[s]? (?<Valves>.+)$",
				RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(line);
            var match = matches.First();

			Name = match.Groups["Name"].Value;
			Rate = long.Parse(match.Groups["Rate"].Value);
			string valvesString = match.Groups["Valves"].Value;

			ConnectedValveNames = new List<string>();

			var names = valvesString.Split(", ");
			foreach(var name in names)
			{
				ConnectedValveNames.Add(name);
			}

			ValveDictionary[Name] = this;
        }

        public override string ToString()
        {
			string connected =
				string.Join(" | ", ConnectedValveNames);
            return $"{Name} rate={Rate} => {connected}";
        }
    }
}

