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

            Console.WriteLine(Pairs.First());
            Console.WriteLine(Pairs.Last());
        }
    }
}