using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day14
{
    internal class Map
    {
        Dictionary<int, Dictionary<int, char>> Points = new Dictionary<int, Dictionary<int, char>>();
        public void Init(string[] lines)
        {
            foreach(string line in lines)
            {
                HandleLine(line);
            }
        }

        private void HandleLine(string line)
        {
            string[] parts = line.Split(" -> ");

            for (int i = 0; i < parts.Length - 1; i++)
            {
                string[] start = parts[i].Split(",");
                string[] end = parts[i + 1].Split(",");

                int startx = int.Parse(start[0]);
                int starty = int.Parse(start[1]);
                int endx = int.Parse(end[0]);
                int endy = int.Parse(end[1]);

                int dx = startx > endx ? -1 : 1;
                int dy = starty > endy ? -1 : 1;

                for (int x = startx; (dx>0 && x<=endx) || (dx <0 && x>=endx); x += dx)
                {
                    for (int y = starty; (dy>0 && y<=endy) || (dy<0 && y>= endy); y += dy)
                    {
                        Set(x, y, '#');
                    }
                }

                Console.WriteLine($"From ({startx}, {starty}) to ({endx}, {endy})");
            }

        }

        public void Set(int x, int y, char v)
        {
            if (!Points.ContainsKey(x))
            {
                Points.Add(x, new Dictionary<int, char>());
            }

            if (!Points[x].ContainsKey(y)) Points[x].Add(y, v);
            else Points[x][y] = v;
        }

        public char Get(int x, int y)
        {
            if (Points.ContainsKey(x))
            {
                if (Points[x].ContainsKey(y))
                {
                    return Points[x][y];
                }
            }

            return '.';
        }

        public void Print()
        {
            int minx = int.MaxValue;
            int maxx = int.MinValue;

            int miny = int.MaxValue;
            int maxy = int.MinValue;

            foreach (var x in Points.Keys)
            {
                foreach (var y in Points[x].Keys)
                {
                    if (x < minx) minx = x;
                    if (x > maxx) maxx = x;
                    if (y < miny) miny = y;
                    if (y > maxy) maxy = y;
                }
            }

            for (int y = miny; y <= maxy; y++)
            {
                for (int x = minx; x <= maxx; x++)
                {
                    Console.Write(Get(x, y));
                }
                Console.WriteLine();
            }
        }
    }
}
