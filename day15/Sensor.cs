using System;
namespace day15
{
	public class Sensor
	{
        public Location Location { get; set; }
        public Beacon ClosestBeacon { get; set; }

		public Sensor(int x, int y, Beacon b)
		{
            Location = new Location(x, y);
            ClosestBeacon = b;
		}

        public override string ToString()
        {
            return $"Sensor at {Location.ToString()} with closest {ClosestBeacon}";
        }
    }
}

