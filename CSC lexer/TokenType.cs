using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCS
{

    public enum Tokentype
    {
        // Single-character tokens.
        LEFT_PAREN, RIGHT_PAREN, LEFT_BRACE, RIGHT_BRACE,
        COMMA, DOT, MINUS, PLUS, SEMICOLON, SLASH, STAR,
        MOD,

        // One or two character tokens.
        BANG, BANG_EQUAL,
        EQUAL, EQUAL_EQUAL,
        GREATER, GREATER_EQUAL,
        LESS, LESS_EQUAL,
        MINUS_MINUS, PLUS_PLUS,
        MINUS_EQUAL, PLUS_EQUAL,
        EXPO, MOD_EQUAL,
        SLASH_EQUAL,

        // Literals.
        IDENTIFIER,STRING,NUMBER,

        // Keywords.
        AND, CLASS, ELSE, ELIF, FALSE, FUNC, FOR, IF,IN, NIL, OR,
        RETURN, SUPER, THIS, TRUE, VAR, CONST, WHILE,NOT,PRINT,INPUT,

        EOF
    }
}
