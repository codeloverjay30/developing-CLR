using System.Reflection.Metadata;
using Utils.Enums;

namespace FluentInstances;

/// <summary>
/// Represents the immutable state container of a C3++ instance variable.
/// </summary>
/// <typeparam name="T">The underlying runtime value type.</typeparam>
public readonly partial struct Instance<T>
    // uses the rule defined in Data Anotation Attribute on `EnumBitwise<T>` class.
    uses EnumBitwise<T>
{
    // private readonly EnumBitwise<T> _enumBitwise = new EnumBitwise<T>();
    private readonly InstanceStatusOptions _status;
    private readonly T _value;

    public InstanceStatusOptions Status => _status;
    public T Value
    {
        get => _value;
        set
        {
            if (value == Constant.MissingValue)
            {
                MarkAsMissing();
                _value = value;
                return;
            }

            MarkAsNotMissing();
            
            if (value != Constants.Unset)
            {
                MarkAsSet();
            }
            else
            {
                MarkAsUnset();
            }

            MarkAsDefined();
                        
            _value = value;
        }
    }

    internal Instance(InstanceStatusOptions status, T value)
    {
        _status = status;
        _value = value;
    }
}
    
