using System.Globalization;

namespace day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");
            List<(Term, Term)> Pairs = new List<(Term, Term)> ();

            int i = 0;
            while (i < lines.Length)
            {
                string leftstr = lines[i++];
                string rightstr = lines[i++];

                Pairs.Add((new Term(leftstr), new Term(rightstr)));

                if (i < lines.Length-1) { i++; }
            }


            //Term t1 = new Term("[7,7,7,7]");
            //Term t2 = new Term("[7,7,7]");
            //var c = Check(t1, t2);
            //Console.WriteLine(c);

            int sumOfCorrectIndicies = 0;
            for (int j = 0; j< Pairs.Count; j++)
            {
                int c = Check(Pairs[j].Item1, Pairs[j].Item2);
                if (c == 1)
                {
                    sumOfCorrectIndicies += j + 1;
                }
            }

            Console.WriteLine($"SUM: {sumOfCorrectIndicies}");

        }


        // -1 FAIL
        //  0 DON'T KNOW YET
        //  1 SUCCESS
        public static int Check(Term left, Term right)
        {
            if (left.IsValue && right.IsValue)
            {
                if (left.Value < right.Value)
                {
                    return 1;
                }
                else if (left.Value == right.Value)
                { 
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (left.IsList && right.IsList) {
                for (int i = 0; i < left.Terms.Count(); i++)
                {
                    // if we run out of right terms before getting a
                    // positive, fail
                    if (right.Terms.Count() < i+1 ) { return -1; }

                    var check = Check(left.Terms[i], right.Terms[i]);

                    if ( check == 0) {
                        // KEEP CHECKING
                    }
                    else if (check == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }

                // OK if we exceed all the left terms
                return 1;
            }
            else if (left.IsList && right.IsValue)
            {
                var wrappedRight = Term.WrapValueTerm(right);
                return Check(left, wrappedRight);
            }
            else if (left.IsValue && right.IsList)
            {
                var wrappedLeft = Term.WrapValueTerm(left);
                return Check(wrappedLeft, right);
            }


            return -1;
        }

    }
}