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

        bool IsList = false;
        public int Value = 0;
        public List<Term> Terms = new List<Term>();

        public Term(string s)
        {
            OriginalStringRep = s;
            s = s.Trim();
            if (s.StartsWith("["))
            {
                IsList = true;
            }
            else
            {
                IsList = false;
                Value = int.Parse(s);
            }
        }

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
