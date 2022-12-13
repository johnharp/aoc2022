using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    public class Term
    {
        public String OriginalStringRep = "";

        public bool IsList = false;
        public bool IsValue {  get { return !IsList; } }
        public int Value;
        public List<Term> Terms = new List<Term>();

        public Term()
        {

        }
        public Term(string s)
        {
            OriginalStringRep = s;
            s = s.Trim();

            if (s.StartsWith('[') &&
                s.EndsWith("]"))
            {
                s = s.Substring(1, s.Length - 2);
                IsList = true;

                if (s != "")
                {
                    var parts = Go(s);

                    foreach (var part in parts)
                    {
                        Terms.Add(new Term(part));
                    }

                }

            }
            else if (s == "")
            {
                IsList = true;
            }
            else 
            {
                IsList = false;
                Value = int.Parse(s);
            }
        }

        public static Term WrapValueTerm(Term t)
        {
            if (t.IsList)
            {
                throw new Exception("Should not happen -- called WrapValueTerm on a term that is already a list");
            }

            Term newterm = new Term();
            newterm.IsList = true;
            newterm.Terms.Add(t);
            return newterm;
        }

        public List<string> Go(string s)
        {
            var parts = new List<string>();
            var commas = new List<int>();

            int nestLevel = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == '[') nestLevel++;
                else if (c == ']') nestLevel--;
                else if (c == ',' && nestLevel < 1) commas.Add(i);
            }

            if (commas.Count == 0)
            {
                parts.Add(s);
            }
            else
            {
                for (int i = 0; i < commas.Count; i++)
                {
                    int start = 0;
                    int end = commas[i] - 1;
                    if (i > 0)
                    {
                        start = commas[i - 1] + 1;
                    }
                    parts.Add(s.Substring(start, end - start + 1));
                }
                parts.Add(s.Substring(commas.Last() + 1));
            }


            return parts;
        }

        

        //private void ParseValue(string s)
        //{
        //    IsList = false;
        //    Value = int.Parse(s);
        //}

        //private void ParseList(String s)
        //{
        //    IsList = true;

        //    var startingBrackets = new Stack <int>();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (s[i] == '[')
        //        {
        //            startingBrackets.Push(i);
        //        }
        //    }
        //    if (s.First() != '[' || s.Last() != ']')
        //    {
        //        throw new FormatException("List is missing start or end square brackets.");
        //    }
        //    // Remove the list start and end brackets
        //    s = s.Substring(1, s.Length - 2);
        //    List<String> parts = AccumulateCommaSeparatedParts(s);

        //    int tokenstart = 0;
        //    for(int i = 0; i < s.Length; i++)
        //    {

        //    }
        //    //TO DO
        //}

        //private List<string> AccumulateCommaSeparatedParts(String s)
        //{
        //    var parts = new List<string>();

        //    // TO DO

        //    return parts;
        //}

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsList == true)
            {
                sb.Append("[");
                foreach(Term t in Terms)
                {
                    sb.Append(t.ToString());
                    if (t != Terms.Last())
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
            }
            else
            {
                sb.Append(Value);
            }
            return sb.ToString();
        }
    }
}
