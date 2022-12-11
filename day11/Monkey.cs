using System;
using System.Numerics;

namespace day11
{
	public class Monkey
	{
		public List<long> Items = new List<long>();

		public string Op;
		public long OpValue;
		public long TestValue;
		public int TrueValue;
		public int FalseValue;

		public long NumItemsInspected = 0;

		public static List<Monkey> All = new List<Monkey>();

		public static long LCM = 1;

		public Monkey(
			string op, long opv,
			long testv, int trueval, int falseval,
            params long[] values)
		{
			Op = op;
			OpValue = opv;
			TestValue = testv;
			TrueValue = trueval;
			FalseValue = falseval;

            foreach (long v in values)
            {
				Items.Add(v);
            }

			All.Add(this);
        }


		public static void CompleteRound()
		{
			foreach(var monkey in All)
			{
				monkey.TakeTurn();
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

		public void TakeTurn()
		{
			if (Items == null || Items.Count == 0) return;

			List<long> items = Items;
			Items = new List<long>();

			foreach (var item in items)
			{
				long v = item;

				if (Op == "+") v += OpValue;
				else if (Op == "*") v *= OpValue;
				else if (Op == "**") v = v * v;

                v = Reduce(v);
                int targetMonkey = v % TestValue == 0 ? TrueValue : FalseValue;

                All[targetMonkey].Items.Add(v);

				NumItemsInspected++;
            }
		}

		public long Reduce(long value)
		{
			// In part 1, reduce by divide by 3

			// In part 2, use lowest common multiple
			if (LCM == 1)
			{
				List<long> divisors = new List<long>();
				foreach(var monkey in All)
				{
					divisors.Add(monkey.TestValue);
				}
				long[] divisorsArray = divisors.ToArray();

				LCM = lcm(divisorsArray);
			}

            return value % LCM;
		}

        // LCM algorithm taken from here:
        // https://www.w3resource.com/csharp-exercises/math/csharp-math-exercise-20.php

        public static long gcd(long n1, long n2)
        {
            if (n2 == 0) return n1;
            else return gcd(n2, n1 % n2);
        }

		public static long lcm(params long[] nums)
        {
            return nums.Aggregate((S, v) => S * v / gcd(S, v));
        }
    }
}

