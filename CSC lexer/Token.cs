using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_lexer
{
    public class Token
    {
        Tokentype type;
        string lexeme;
        object literal;
        int line;
        public Token(Tokentype type,string lexeme,object literal,int line)
        {
            this.type = type;
            this.lexeme = lexeme;
            this.literal = literal;
            this.line = line;
        }
        public string ToString()
        {
            return $"{type} {lexeme} {literal}";
        }
    }
}
