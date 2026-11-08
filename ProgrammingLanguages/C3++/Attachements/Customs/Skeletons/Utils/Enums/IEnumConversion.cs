namespace Utils.Enums;

/// <summary>
/// The contract about
/// 1. explicit conversion from <see langword="enum"/> to numbers
/// 2. convert from the result (a number) to <see langword="enum"/>.
/// </summary>
public interface IEnumConversion<TEnum,TNumber>
{
    /// <summary>
    /// Convert the <paramref name="number"/> back to <see cref="TEnum"/> 
    /// </summary>
    /// <param name="number">the number</param>
    /// <returns></returns>
    TEnum ConvertTNumberToEnum(TNumber number);

    /// <summary>
    /// Convert the <paramref name="enum"/> to <see cref="TNumber"/> 
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    TNumber ConvertEnumToTNumber(TEnum @enum);
}