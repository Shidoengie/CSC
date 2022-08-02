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
            string outp = "";
            foreach (char item in text.Substring(start))
            {
                outp += item;
                if (item == text[stop-1])
                {
                    outp += item;
                    break;
                }
                
            }
            return outp;
        }
        //HAS NO USE
    }
}
