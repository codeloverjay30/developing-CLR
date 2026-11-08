using Utils.Enums;

namespace FluentInstances;

/// <summary>
/// Represents the immutable state container of a C3++ instance variable.
/// </summary>
/// <typeparam name="T">The underlying runtime value type.</typeparam>
public readonly partial struct Instance<T>
{
    private readonly EnumBitwise<T> _enumBitwise = new EnumBitwise<T>();
    private readonly InstanceStatusOptions _status;
    private readonly T _value;

    public InstanceStatusOptions Status => _status;
    public T Value => _value;

    private Instance(InstanceStatusOptions status, T value)
    {
        _status = status;
        _value = value;
    }

    /// <summary>
    /// Creates an instance in a defined state with a valid value.
    /// </summary>
    public static Instance<T> Defined(T value) => new(InstanceStatusOptions.Defined, value);

    /// <summary>
    /// Creates an instance in an undefined state.
    /// </summary>
    public static Instance<T> Undefined() => new(InstanceStatusOptions.Undefined, default!);

    /// omitted
    /// Other static factory methods 
    /// since its logic are same.
}
    
