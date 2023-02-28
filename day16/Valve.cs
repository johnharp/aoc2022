using System;
using System.Text.RegularExpressions;

namespace day16
{
	public class Valve
	{
		public string Name { get; set; }
		public long Rate { get; set; }

		public List<String> ConnectedValveNames { get; set; }
		public List<Valve> ConnectedValves { get; set; }

		public static Dictionary<string, Valve> ValveDictionary = new Dictionary<string, Valve>();
		public static List<Valve> GetAllValves()
		{
			var all = ValveDictionary.Values;

			return all.ToList();
		}

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

			ConnectedValves = new List<Valve>();

			ValveDictionary[Name] = this;
        }

		/// <summary>
		/// Checks all the connected valves and verifies only "significant" valves are
		/// connected.  (Those with a flow of 0 will never be opened so they just serve as connections
		/// and should be traversed.)
		/// </summary>
		/// <returns>
		///   True - all connected valves have a non-zero flow
		///   False - one or more connected valves have a zero flow
		/// </returns>
		public bool IsFullyCompacted()
		{
			return !ConnectedValves.Any(x => x.Rate == 0);
		}

		public static void LinkAllConnectedValves()
		{
			foreach(var valve in GetAllValves())
			{
				valve.LinkConnectedValves();
			}
		}


		private void LinkConnectedValves()
		{
			foreach(string valveName in ConnectedValveNames)
			{
				Valve v = ValveDictionary[valveName];
				ConnectedValves.Add(v);
			}
		}

        public override string ToString()
        {
			string connected =
				string.Join(" | ", ConnectedValves.Select(x => x.Name));
            return $"{Name} rate={Rate} => {connected}";
        }
    }
}

