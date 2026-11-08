namespace C3Plus.CodeFactories;

public class C3CodeFractionFactory : IC3CodeFractionFactory
{
    public string CreateInstance(string input)
    {
        // 這裡封裝了轉換邏輯，未來若要使用 FractionsUtilityServices 的進階 API
        // 只需在此處修改，Visitor 無需異動
        if (input.Contains('.'))
        {
            var parts = input.Split('.');
            long denom = (long)Math.Pow(10, parts[1].Length);
            long num = long.Parse(parts[0] + parts[1]);
            return $"new C3Plus.Runtime.Rational({num}, {denom})";
        }
        return $"new C3Plus.Runtime.Rational({input}, 1)";
    }
}
