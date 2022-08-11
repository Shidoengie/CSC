using System;
using System.Collections.Generic;
using LOCS

abstract class Expr
{
    sealed class Binary : Expr
    {
       Binary(Expr left, Token op, Expr right)
        {
          this.left = left;
          this.op = op;
          this.right = right;
        }

    Expr left;
    Token op;
    Expr right;
    }
    sealed class Grouping : Expr
    {
       Grouping(Expr expression)
        {
          this.expression = expression;
        }

    Expr expression;
    }
    sealed class Literal : Expr
    {
       Literal(Object value)
        {
          this.value = value;
        }

    Object value;
    }
    sealed class Unary : Expr
    {
       Unary(Token op, Expr right)
        {
          this.op = op;
          this.right = right;
        }

    Token op;
    Expr right;
    }
}
