using System;
using System.Text;

namespace day11
{
	public class PrimePolyTerm
	{
        public long Coefficient;
		public Dictionary<long, long> Primes = new Dictionary<long, long>();

        public PrimePolyTerm(long coefficient)
		{
			Coefficient = coefficient;
		}

		public Int64 Check()
		{
			Int64 check = Coefficient;
			foreach(var p in Primes.Keys)
			{
				for(int i = 0; i < Primes[p]; i++)
				{
					check = check * p;
				}
			}

			return check;
		}

		public void MultiplyByPrime(long p)
		{
			if (Primes.ContainsKey(p))
			{
				Primes[p]++;
			}
			else
			{
				Primes[p] = 1;
			}
		}

		public PrimePolyTerm Mult(PrimePolyTerm other)
		{
			var newTerm = new PrimePolyTerm(Coefficient * other.Coefficient);
			foreach(var p in Primes.Keys)
			{
				for (int i = 0; i < Primes[p]; i++)
				{
                    newTerm.MultiplyByPrime(p);
                }
            }
			foreach(var p in other.Primes.Keys)
			{
				for (int i = 0; i < other.Primes[p]; i++)
				{
                    newTerm.MultiplyByPrime(p);
                }
            }

			return newTerm;
		}

		public bool IsDivisibleBy(long p)
		{
			if (Coefficient % p == 0)
			{
				return true;
			}

			if (Primes.Keys.Contains(p) &&
				Primes[p] > 0)
			{
				return true;
			}

			return false;
		}

        public override string ToString()
        {
			var sb = new StringBuilder();
			sb.Append($"{Coefficient}");
			var sortedKeys = Primes
				.Keys
				.OrderByDescending(k => k)
				.ToList();

			if (sortedKeys.Count() > 0)
			{
				sb.Append("(");
			}
			for (int i = 0; i<sortedKeys.Count(); i++)
			{
				sb.Append($"{sortedKeys[i]}^{Primes[sortedKeys[i]]}");
				if (i<sortedKeys.Count() - 1)
				{
					sb.Append(" * ");
				}
			}
			if (sortedKeys.Count() > 0)
			{
				sb.Append(")");
			}

            return sb.ToString();
        }
    }
}

