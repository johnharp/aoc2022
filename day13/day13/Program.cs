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


            //CheckString("[4,4]","[4,4]");

            //CheckString("[1,[2,[3,[4,[5,6,7]]]],8,9]","[1,[2,[3,[4,[5,6,0]]]],8,9]");
            //return;

            int sumOfCorrectIndicies = 0;
            for (int j = 0; j < Pairs.Count; j++)
            {
                int c = Check(Pairs[j].Item1, Pairs[j].Item2);
                if (c == 1)
                {
                    sumOfCorrectIndicies += j + 1;
                }
                Console.WriteLine($"L:{Pairs[j].Item1}");
                Console.WriteLine($"R:{Pairs[j].Item2}");
                Console.WriteLine($"{c} <==");
            }

            Console.WriteLine($"SUM: {sumOfCorrectIndicies}");

        }

        public static void CheckString(string l, string r)
        {
            var c = Check(new Term(l), new Term(r));
            Console.WriteLine($"{c} <== {l} || {r}");
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
                if (left.Terms.Count > 0 && right.Terms.Count == 0) return -1; 

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
            else if (left.IsList && right.IsValue && right.Value != -1)
            {
                var wrappedRight = Term.WrapValueTerm(right);
                return Check(left, wrappedRight);
            }
            else if (left.IsValue && right.IsList && left.Value != -1)
            {
                var wrappedLeft = Term.WrapValueTerm(left);
                return Check(wrappedLeft, right);
            }


            return -1;
        }

    }
}