using System;
using System.Numerics;

namespace day11
{
	public class Monkey
	{
		public List<PrimePoly> Items = new List<PrimePoly>();
		public Action<PrimePoly> Operation;
		public Func<PrimePoly, int> Test;

		public long NumItemsInspected = 0;

		public static List<Monkey> All = new List<Monkey>();

		public Monkey(params long[] coefficients)
		{
            foreach (var coefficient in coefficients)
            {
                var p = new PrimePoly(coefficient);
                Items.Add(p);
            }

            Operation = (PrimePoly p) => { };
            Test = (PrimePoly p) => 0;
        }

		public void Init()
		{

        }

		public static void CompleteRound()
		{
			foreach(var monkey in All)
			{
				monkey.TakeTurn();
			}
		}

		public static void PrintAll()
		{
			for(int i =0; i<All.Count; i++)
			{
				Monkey m = All[i];
				Console.WriteLine($"Monkey {i}  [num inpected {m.NumItemsInspected}]: {m.ItemsToString()}");
                //Console.WriteLine($"Monkey {i}  [num inpected {m.NumItemsInspected}]");
            }
        }

		public static void PrintMonkeyBusinessLevel()
		{
			List<long> numItems = new List<long>();
			foreach(var m in Monkey.All)
			{
				numItems.Add(m.NumItemsInspected);
			}
			numItems.Sort();

			long v = numItems[numItems.Count - 2] * numItems[numItems.Count - 1];
			Console.WriteLine($"Total monkey-business level: {v}");
		}

		public string ItemsToString()
		{
			List<string> strings = new List<string>();

			foreach(var item in Items)
			{
				strings.Add(item.ToString());
			}
			string s = string.Join(", ", strings);
			return s;
		}

		public void TakeTurn()
		{
			if (Items == null || Items.Count == 0) return;

			List<PrimePoly> items = Items;
			Items = new List<PrimePoly>();

			foreach (var item in items)
			{
                Operation(item);
				//item.DivideBy3();
				
                int targetMonkey = Test(item);

				All[targetMonkey].Items.Add(item);

				NumItemsInspected++;
            }
		}

		//public long Reduce(long value)
		//{
		//	long v = 1;

		//	if (value % 19 == 0) { v *= 19; }
		//	if (value % 17 == 0) { v *= 17; }
		//	if (value % 13 == 0) { v *= 13; }
		//	if (value % 11 == 0) { v *= 11; }
		//	if (value % 7 == 0) { v *= 7; }
		//	if (value % 5 == 0) { v *= 5; }
  //          if (value % 3 == 0) { v *= 3; }
  //          if (value % 2 == 0) { v *= 2; }

  //          return v;
		//}
	}
}

