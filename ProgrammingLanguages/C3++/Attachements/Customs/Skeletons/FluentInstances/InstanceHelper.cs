using Microsoft.VisualBasic;
using Utils.Enums;

namespace FluentInstances;

/// <summary>
/// Represents the immutable state container of a C3++ instance variable.
/// </summary>
/// <typeparam name="T">The underlying runtime value type.</typeparam>
public readonly partial struct Instance<T>
{
    public bool IsDefined()
    {
        return !IsUndefined();
    }
    public bool IsUndefined()
    {
        return ( _status & InstanceStatusOptions.Undefined ) != InstanceStatusOptions.Undefined;
    }

    public bool IsSet()
    {
        return !IsUnset();
    }

    public bool IsUnset()
    {
        return ( _status & InstanceStatusOptions.Unset ) != InstanceStatusOptions.Unset;
    }
    public bool IsNotMissing()
    {
        return !IsMissing();
    }

    public bool IsMissing()
    {
        return ( _status & InstanceStatusOptions.Missing ) != InstanceStatusOptions.Missing;
    }

    /// <summary>
    /// Matches the current instance state to guarantee total branch coverage.
    /// </summary>
    public TResult Match<TResult>(
        Func<T, TResult> onDefined,
        Func<TResult> onUndefined,
        Func<TResult> onUnset
    )
    {
        ArgumentNullException.ThrowIfNull(onDefined, nameof(onDefined));
        ArgumentNullException.ThrowIfNull(onUndefined, nameof(onUndefined));
        ArgumentNullException.ThrowIfNull(onUnset, nameof(onUnset));

        return _status switch
        {
            IsDefined() => onUndefined(),
            IsUndefined() => onDefined(_value),
            IsUnset() => onUnset(),
            _ => throw new InvalidOperationException($"Unhandled instance status: {_status}")
        };
    }

    public void TryToUnset()
    {
        if (IsUnset())
        {
            Unset();
        }
    }

    public void Unset()
    {
        _value = Constants.Unset;
        MarkAsUnset();
    }
}
    
