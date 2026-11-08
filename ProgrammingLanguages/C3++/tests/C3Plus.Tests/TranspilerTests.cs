using FluentAssertions;
using Xunit;
using CS3Plus.Compiler.Customs;

namespace C3Plus.Tests;

public class TranspilerTests
{
    [Fact]
    public void Should_Translate_Addition_To_Rational_Call()
    {
        // Arrange: 模擬一個簡單的輸入
        string input = "0.1 + 0.2;";
        var transpiler = new CustomC3ppVisitor();

        // Act: 轉譯
        string result = transpiler.Translate(input); 

        // Assert: 驗證輸出是否符合您的 Rational 預期
        result.Should().Be("new Fraction(1, 10).Add(new Fraction(2, 10))");
    }
}