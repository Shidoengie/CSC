using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CSC_lexer.GMethods;
using static CSC_lexer.Tokentype;

namespace CSC_lexer
{
    public class Scanner
    {
        private int start = 0;
        private int current = 0;
        private int line = 1;
        private string source;
        
        private List<Token> tokens = new List<Token>();
        public Scanner(string source)
        {
            this.source = source;
        }
        public List<Token> ScanTokens()
        {
            while (!isAtEnd())
            {
                start = current;
                scan_token();
            }
            tokens.Add(new Token(EOF, "", null, line));
            return tokens;
        }
        private bool isAtEnd()
        {
            return current >= source.Length;
        }
        private char Advance()
        {
            return source[current++];
        }
        private void AddToken(Tokentype type)
        {
            AddToken(type, null);
        }
        private void AddToken(Tokentype type, object literal)
        {
            string text = source[start..current];
            tokens.Add(new Token(type, text, literal, line));
        }
        private void scan_token()
        {
            char c = Advance();
            
            switch (c)
            {
                case '(': AddToken(LEFT_PAREN); break;
                case ')': AddToken(RIGHT_PAREN); break;
                case '{': AddToken(LEFT_BRACE); break;
                case '}': AddToken(RIGHT_BRACE); break;
                case ',': AddToken(COMMA); break;
                case '.': AddToken(DOT); break;
                case ';': AddToken(SEMICOLON); break;
                case '"': str(); break;
                
                
                case '#': while (peek() != '\n' && !isAtEnd()) Advance(); break;
                case ' ':
                case '\r':
                case '\t':
                    // Ignore whitespace.
                    break;
                case '\n':
                    line++;
                    break;
                case '!':
                    AddToken(match('=') ? BANG_EQUAL : BANG);
                    break;
                case '=':
                    AddToken(match('=') ? EQUAL_EQUAL : EQUAL);
                    break;
                case '*':
                    AddToken(match('*') ? EXPO : STAR);
                    break;
                case '<':
                    AddToken(match('=') ? LESS_EQUAL : LESS);
                    break;
                case '>':
                    AddToken(match('=') ? GREATER_EQUAL : GREATER);
                    break;
                case '%':
                    AddToken(match('=') ? MOD_EQUAL : MOD);
                    break;
                case '/':
                    AddToken(match('=') ? SLASH_EQUAL : SLASH);
                    break;

                case '+':
                    if (match('+'))
                    {
                        if (Comment_Or_EOF()) { AddToken(PLUS_PLUS); }
                        else { CSC.error(line, "unexpected char post assignment"); }
                    }
                    else if (match('='))
                    {
                        AddToken(PLUS_EQUAL);
                    }
                    else
                    {
                        AddToken(PLUS);
                    }
                    break;
                case '-':
                    if (match('-'))
                    {
                        if (Comment_Or_EOF()) { AddToken(MINUS_MINUS); }
                        else { CSC.error(line, "unexpected char post assignment"); }
                    }
                    else if (match('='))
                    {
                        AddToken(MINUS_EQUAL);
                    }
                    else
                    {
                        AddToken(PLUS);
                    }
                    break;
                // keywords
                case 'o':
                    if (match('r'))
                    {
                        AddToken(OR);
                    }
                    break;
                default:
                    if (isDigit(c))
                    {
                        number();
                    }
                    else if (isAlphaNumeric(c))
                    {
                        identifier();
                    }
                    else
                    {
                        CSC.error(line, "unexpected char");
                    }
                    break;
            }
            
        }
        private bool Comment_Or_EOF()
        {
            Console.WriteLine(current);
            foreach (char c in source.Substring(current-1))
            {
                if (c == ' ' || c == '\t' || c == '\r')
                {
                    continue;
                }
                if (c == '\n' || c == '#')
                {
                    return true;
                }
            }
            Console.WriteLine("a");
            return true;
        }
        private bool match(char expected)
        {
            if (isAtEnd()) return false;
            if (source[current] != expected) return false;
            current++;
            return true;
        }
        private char peek()
        {
            if (isAtEnd()) return '\0';
            return source[current];
        }
        private char peekNext()
        {
            if (current + 1 >= source.Length) return '\0';
            return source[current+1];
        }
        private bool isAlpha(char c)
        {
            return (c >= 'a' && c <= 'z') ||
                   (c >= 'A' && c <= 'Z') ||
                    c == '_';
        }
        private bool isAlphaNumeric(char c)
        {
            return isAlpha(c) || isDigit(c);
        }
        private void str()
        {
            while (peek() != '"' && !isAtEnd())
            {
                if (peek() == '\n') line++;
                Advance();
            }

            if (isAtEnd())
            {
                CSC.error(line, "Unterminated string.");
                return;
            }

            // The closing ".
            Advance();

            // Trim the surrounding quotes.
            string value = source[(start+1)..(current-1)];
            AddToken(STRING, value);
        }
        private bool isDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        private void number()
        {
            while (isDigit(peek())) Advance();
            if (peek() == '.' && isDigit(peekNext()))
            {
                Advance();

                while (isDigit(peek())) Advance();
            }


            AddToken(NUMBER, Double.Parse(source[start..current]));
        }
        public static Dictionary<string, Tokentype> keywords = new Dictionary<string, Tokentype>() 
        {
            { "and", AND },
            { "or", OR },
            { "not", NOT },
            { "true", TRUE },
            { "false", FALSE },
            { "if", IF },
            { "else", ELSE },
            { "elif", ELIF },
            { "func", FUNC },
            { "while", WHILE },
            { "for", FOR },
            { "class", CLASS },
            { "super", SUPER },
            { "print", PRINT },
            { "this", THIS },
            { "nil", NIL },
        };
        private void identifier()
        {
            string text = source[start..current];
            Tokentype type = new Tokentype();
            if (!keywords.TryGetValue(text,out type))
            {
                CSC.error(line,"invalid keyword");
            }
            
            if (type == null) type = IDENTIFIER;
            AddToken(type);
            AddToken(IDENTIFIER);
        }

    }
}
