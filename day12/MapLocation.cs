﻿using System;
namespace day12
{
	public class MapLocation
	{
        public char Height { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public int StepsFromStart { get; set; }
        public bool Solved = false;

        public List<MapLocation> Neighbors = new List<MapLocation>();

		public MapLocation(char h, int row, int col)
        {
            StepsFromStart = int.MaxValue;
			Height = h;
            Row = row;
            Col = col;
		}

        public (int, int) RowCol
        {
            get { return (Row, Col); }
        }

        public override string ToString()
        {
            return Height.ToString();
        }

        public void Print()
        {
            Console.Write($"L:({Row},{Col}) h:{Height} n:");
            foreach(var l in Neighbors)
            {
                Console.Write(l.RowCol);
            }
            Console.Write($" steps: {StepsFromStart}");
            Console.WriteLine();
        }
    }
}

