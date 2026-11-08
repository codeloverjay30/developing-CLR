using Utils.Enums;

namespace FluentInstances;

/// <summary>
/// Represents the immutable state container of a C3++ instance variable.
/// </summary>
/// <typeparam name="T">The underlying runtime value type.</typeparam>
public readonly partial struct Instance<T>
{
    /// <summary>
    /// mark <see cref="_status"/> as  <see cref="InstanceStatusOptions.Unset" />
    /// to record the value (<see cref="global::Instance<T>._value"/> ) is in unset status.
    /// </summary>
    internal void MarkAsUnset()
    {
        // add the <see cref="InstanceStatusOptions.Unset" /> flag to indicate that <see cref="global::Instance<T>._value"/> is not unset.
        AddFlag(InstanceStatusOptions.Unset);
    }

    /// <summary>
    /// mark <see cref="_status"/> as <see cref="InstanceStatusOptions.Unset" /> and <see cref="InstanceStatusOptions.Undefined" />
    /// to record the value (<see cref="global::Instance<T>._value"/> ) is in unset status and it is not defined (but is declared).
    /// </summary>
    internal void MarkAsUndefined()
    {
        // add the <see cref="InstanceStatusOptions.Undefined" /> flag to indicate that <see cref="global::Instance<T>._value"/> is declared but not defined.
        AddFlag(InstanceStatusOptions.Undefined);

        // add the <see cref="InstanceStatusOptions.Unset" /> flag to indicate that <see cref="global::Instance<T>._value"/> is in unset status.
        AddFlag(InstanceStatusOptions.Unset);
    }

    internal void MarkAsMissing()
    {
        // add the <see cref="InstanceStatusOptions.Missing" /> flag to indicate that <see cref="global::Instance<T>._value"/> has missing data.
        AddFlag(InstanceStatusOptions.Missing);
    }

    internal void MarkAsDefined()
    {
        // remove the <see cref="InstanceStatusOptions.Undefined" /> flag to indicate that <see cref="global::Instance<T>._value"/> is declared and defined.
        // but it might be on the unset status.
        RemoveFlag(InstanceStatusOptions.Undefined);
    }

    internal void MarkAsSet()
    {
        // remove the <see cref="InstanceStatusOptions.Undefined" /> flag to indicate that <see cref="global::Instance<T>._value"/> is not undefined.
        RemoveFlag(InstanceStatusOptions.Undefined);

        // remove the <see cref="InstanceStatusOptions.Unset" /> flag to indicate that <see cref="global::Instance<T>._value"/> is not unset.
        RemoveFlag(InstanceStatusOptions.Unset);
    }

    internal void MarkAsNotMissing()
    {
        // remove the <see cref="InstanceStatusOptions.Missing" /> flag to indicate that <see cref="global::Instance<T>._value"/> does not have missing data.
        RemoveFlag(InstanceStatusOptions.Missing);
    }
}
    
