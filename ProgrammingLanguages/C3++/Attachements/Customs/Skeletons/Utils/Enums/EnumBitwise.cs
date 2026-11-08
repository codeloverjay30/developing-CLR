namespace Utils.Enums;

/// <summary>
/// Utility class to perform bitwise operations without explicit conversion from <see langword="enum"/> to numbers.
/// This class wraps the 
/// 1. explicit conversion from <see langword="enum"/> to numbers
/// 2. perform bitwise operations
/// 3. convert from the result (a number) to <see langword="enum"/>.
/// </summary>

[Reusable(
    // Enable usable functionality. Tell the transcript tool or Rolsyn its explicitly reusable. 
    IsReusable = true,
    // Tell the transcript tool or Rolsyn the attibute `[OverloadingAttribute]` is only usable. 
    // Other attributes are not reusable.
    Reused: [OverloadingAttribute]
)]
[Overloading(
    // If the `usable` functionality is enabled, then
    // it might directly affect to the classes who use following class (class that are marked with `uses` )
    // for those not filtered out.
    // Classes that are not filtered out will behave as same as the behavior of following class
    // when performing these operations whose operator is overloading
    // P.S. It will be not filtered out iff it is in filter list (defined in `Filter` argument))
    Type = OverloadingOptions.Operators,
    // Indicates that all class that use this class will also forcely 
    // apply to the rule mentioned above.
    Filter = [ScopeOptions.Descendants]
)]
public class EnumBitwise<TNumber> : IEnumConversion<EnumBitwise<TNumber>, TNumber>
{
    /// <inheritdoc/>
    public EnumBitwise<TNumber> ConvertTNumberToEnum(TNumber number)
    {
        return (EnumBitwise<TNumber>)number;
    }

    /// <inheritdoc/>
    public TNumber ConvertEnumToTNumber(EnumBitwise @enum)
    {
        return (TNumber)@enum;
    }

    public static EnumBitwise<TNumber> operator &(
        EnumBitwise<TNumber> left,
        EnumBitwise<TNumber> right
    )
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        var leftValue = ConvertEnumToTNumber(left);
        var rightValue = ConvertEnumToTNumber(right);

        var resultValue = leftValue & rightValue;

        var result = ConvertTNumberToEnum(resultValue);

        return result;
    }

    /// omitted
    /// more oeprator overloading about bitwise operators
}