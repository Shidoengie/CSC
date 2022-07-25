using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_lexer
{
    public class GMethods
    {
        public static string Substring_fromIndex(string text, int start, int stop)
        {
            int fixedstart = start;
            if (start > stop)
            {
                start = stop;
                stop = fixedstart;
            }
            return (text.Substring(start, Math.Abs(text.Substring(0, start + 1).Length - text.Substring(0, stop + 2).Length)));
        }
    }
}
