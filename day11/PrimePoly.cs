using System;
using System.Text;


namespace day11
{
	public class PrimePoly
	{
		public Int64 CheckValue = 0;
		public bool DoChecks = true;
		public List<PrimePolyTerm> Terms = new List<PrimePolyTerm>();

		public Int64 Check()
		{
			Int64 check = 0;

			foreach(var term in Terms)
			{
				check += term.Check();
			}
			return check;
		}
		public PrimePoly(long coefficient)
		{
			CheckValue = coefficient;
			PrimePolyTerm t = new PrimePolyTerm(coefficient);
			Terms.Add(t);
		}

		public void MultiplyByPrime(long p)
		{
            if (DoChecks)
            {
                CheckValue = CheckValue * p;
            }

            foreach (var t in Terms)
			{
				t.MultiplyByPrime(p);
			}

		}

		public void AddNumber(long n)
		{
            if (DoChecks)
            {
                CheckValue += n;
            }

            if (Terms.Any())
			{
				var last = Terms.Last();
				if (last.Primes.Count() == 0)
				{
					last.Coefficient += n;
					return;
				}
			}

			var t = new PrimePolyTerm(n);
			Terms.Add(t);


		}

		public void Square()
		{
            if (DoChecks)
            {
                CheckValue = CheckValue * CheckValue;
            }

            var OldTerms = Terms;
			Terms = new List<PrimePolyTerm>();

			for(int i = 0; i<OldTerms.Count(); i++)
			{
				for (int j = 0; j<OldTerms.Count(); j++)
				{
					var t = OldTerms[i].Mult(OldTerms[j]);
					Terms.Add(t);
				}
			}
		}



		public bool IsDivisibleBy(long p)
		{
			bool isdivisible = true;

			foreach(var t in Terms)
			{
				if (!t.IsDivisibleBy(p))
				{
					isdivisible = false;
					break;
				}
			}

			if ((isdivisible && (CheckValue % p != 0)) ||
				(!isdivisible && (CheckValue % p == 0)))
			{

				Console.WriteLine($"{this}");
				Console.WriteLine($"Check value: {CheckValue}");
				Console.WriteLine($"Divide by check {p}");
				throw new Exception();
			}

			return isdivisible;
		}

        public override string ToString()
        {
			var sb = new StringBuilder();

            if (DoChecks)
            {
				sb.Append($"|{CheckValue}| ");
				sb.Append($"{Check()}|");
            }

            for (int i = 0; i<Terms.Count(); i++)
			{
				sb.Append(Terms[i].ToString());
				if (i < Terms.Count()-1)
				{
					sb.Append(" + ");
				}
			}
            return sb.ToString();
        }
    }
}

