﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CSC_lexer.GMethods;
using static CSC_lexer.Tokentype;

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
        List<Token> ScanTokens()
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
            string text = Substring_fromIndex(source, start, current);
            tokens.Add(new Token(type, text, literal, line));
        }
        private void scan_token()
        {
            char c = Advance();
            char invc = source[current];
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
                    AddToken(match('*') ? FLOOR : STAR);
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
                default:
                    CSC.error(line, "unexpected char");
                    break;
            }
            switch (invc)
            {
                case '-':
                    switch (mult_match('-', '='))
                    {
                        case 0:
                            AddToken(MINUS);
                            break;
                        case 1:
                            AddToken(MINUS_MINUS);
                            break;
                        case 2:
                            AddToken(MINUS_EQUAL);
                            break;
                        default:
                            break;
                    }
                    break;
                case '+':
                    switch (mult_match('+', '='))
                    {
                        case 0:
                            AddToken(PLUS);
                            break;
                        case 1:
                            AddToken(PLUS_PLUS);
                            break;
                        case 2:
                            AddToken(PLUS_EQUAL);
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
        private bool match(char expected)
        {
            if (isAtEnd()) return false;
            if (source[current] != expected) return false;
            current++;
            return true;
        }
        private byte mult_match(char expected1, char expected2)
        {
            if (isAtEnd()) return 0;
            if (source[current + 1] != expected1 || source[current + 1] != expected2) return 0;
            if (source[current + 1] == expected1) return 1;
            if (source[current + 1] == expected2) return 2;
            current++;
            return 0;
        }
        private char peek()
        {
            if (isAtEnd()) return '\0';
            return source[current];
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
            string value = Substring_fromIndex(source, start + 1, current - 1);
            AddToken(STRING, value);
        }
        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        private void number()
        {

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
        

    }
}
