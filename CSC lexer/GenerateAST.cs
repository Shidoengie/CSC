using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCS
{
    class GenerateAST
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: generate AST[script]");
                Environment.Exit(64);

            }
            string outpDir = args[0];
        }
    }
}
