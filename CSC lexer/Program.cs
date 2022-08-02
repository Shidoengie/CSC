using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSC_lexer
{
    public class CSC
    {
        static bool had_error;
        
        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: csc[script]");
                Environment.Exit(64);
            }
            else if (args.Length == 1)
            {
                Run_file(args[0]);
            }
            else
            {
                Run_prompt();
            }
            
        }
        
        static void Run_prompt()
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                if (input == null) { break; }
                Run(input);
                had_error = false;
            }
        }
        static void Run_file(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            Run(Encoding.UTF8.GetString(bytes));
            if (had_error) { Environment.Exit(65); }
        }
        static void Run(string source)
        {
            Scanner scanner = new Scanner(source);
            List<Token> tokens = scanner.ScanTokens();
            foreach (Token token in tokens)
            {
                Console.WriteLine(token.ToString());
            }
        }
        public static void error(int line, string message)
        {
            report(line, "", message);
            
        }
        static void report(int line, string where, string message)
        {
            Console.Error.WriteLine($"Line: {line} Error {where}: {message}");
            had_error = true;
        }
    }
}
