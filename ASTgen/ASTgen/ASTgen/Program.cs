using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASTgen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: generate AST[script]");
                Environment.Exit(64);

            }
            string outpDir = args[0];
            string[] ast_list = {
                "Binary   : Expr left, Token operator, Expr right",
                "Grouping : Expr expression",
                "Literal  : Object value",
                "Unary    : Token operator, Expr right"
            };
            define_ast(outpDir, "Expr", ast_list.ToList());
            
        }
        private static void define_ast(string output_dir,string basename,List<string> types)
        {
            string path = $"{output_dir}/{basename}.cs";
            var file = File.CreateText(path);
            file.WriteLine("using System;");
            file.WriteLine("using System.Collections.Generic;");
            file.WriteLine();
            file.WriteLine("abstract class "+basename);
            file.WriteLine("{");

            file.WriteLine("}");
        }

    }
    //template class
    abstract class test
    {
        class Binary : test
        {

        }
    }
    //template class
}
