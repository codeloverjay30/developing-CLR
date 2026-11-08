using System;
using System.IO;
using Antlr4.Runtime;
using CS3Plus.Compiler.Customs; // 假設您已經建立好 CustomC3ppVisitor

namespace C3ppTranspiler
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0])) 
            {
                Console.WriteLine("Usage: C3ppTranspiler.exe <input.csixp> -o <output.g.cs>");
                return 1;
            }

            string inputFile = args[0];
            string outputFile = "output.g.cs"; // 簡化處理，實際可透過 args 解析

            // 1. 讀取 .csixp 檔案
            string code = File.ReadAllText(inputFile);

            // 2. Antlr4 解析與轉譯
            var inputStream = new AntlrInputStream(code);
            var lexer = new C3ppLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new C3ppParser(tokens);
            var tree = parser.prog();

            var visitor = new CustomC3ppVisitor();
            string result = visitor.Visit(tree);

            // 3. 輸出結果
            File.WriteAllText(outputFile, result);
            Console.WriteLine($"Transpilation successful: {outputFile}");
            return 0;
        }
    }
}