using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSC_lexer
{
    class Scanner
    {
        private int start = 0;
        private int current = 0;
        private int line = 1;
        private string source;
        private List<Token> tokens = new List<Token>();
        Scanner(string source)
        {
            this.source = source;
        }
        List<Token> scanTokens()
        {
            while (!isAtEnd())
            {
                start = current;
                //scantoken()
            }
            tokens.Add(new Token(Tokentype.EOF, "", null, line));
            return tokens;
        }
        private bool isAtEnd()
        {
            return current >= source.Length;
        }
        private char advance()
        {
            return source[current++];
        }
    }
}
