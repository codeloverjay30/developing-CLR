using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CS3Plus.Compiler.Customs;

public class CustomC3ppVisitor : C3ppBaseVisitor<string>
{
    // 補上這個方法，讓測試可以呼叫
    public string Translate(string input)
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new C3ppLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new C3ppParser(tokens);

        // 呼叫 .prog() 取得根節點 (根據您的 .g4 定義)
        var tree = parser.prog();

        if (tree == null)
        {
            throw new Exception("Parsing failed!");
        }
        // 開始 Visit 並回傳結果
        return Visit(tree);
    }

    public override string VisitAddSub(C3ppParser.AddSubContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.op.Text;

        return $"{left}.{ (op == "+" ? "Add" : "Subtract") }({right})";
    }

    // 實作數值節點處理
    public override string VisitNumberLiteral(C3ppParser.NumberLiteralContext context)
    {
        string val = context.NUMBER().GetText();

        if (val.Contains("."))
        {
            var parts = val.Split('.');
            var integerPart = decimal.Parse(parts[0]);
            string decimalPart = parts[1];

            // 例如 0.1 -> 分子 1, 分母 10
            var denominator = Math.Pow(10, decimalPart.Length);
            var numerator = integerPart * (decimal)denominator + decimal.Parse(decimalPart);

            return $"new Fraction({numerator}, {denominator})";
        }

        // 如果是整數，例如 1 -> new Rational(1, 1)
        return $"new Fraction({val}, 1)";
    }


    public override string VisitExprStmt(C3ppParser.ExprStmtContext context)
    {
        // 進入 expression 節點
        return Visit(context.expression());
    }

    public override string VisitProg(C3ppParser.ProgContext context)
    {
        // 處理多個 statement，串接結果
        var results = context.statement().Select(Visit);
        return string.Join(Environment.NewLine, results);
    }

}