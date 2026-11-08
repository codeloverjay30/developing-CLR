using Utils.Enums;

namespace FluentInstances;

/// <summary>
/// Represents the immutable state container of a C3++ instance variable.
/// </summary>
/// <typeparam name="T">The underlying runtime value type.</typeparam>
public readonly partial struct Instance<T>
{
    /// <summary>
    /// Remove a flag <paramref name="flagToBeRemoved"/> about <see cref="global::FluentInstances.InstanceStatusOptions"/>
    /// </summary>
    /// <param name="flagToBeRemoved"></param>
    public void RemoveFlag(
        InstanceStatusOptions flagToBeRemoved
    )
    {
        _status = _status & (~flagToBeRemoved);
    }

    /// <summary>
    /// Add a flag <paramref name="flagToBeAdded"/> about <see cref="global::FluentInstances.InstanceStatusOptions"/>
    /// </summary>
    /// <param name="flagToBeAdded"></param>
    public void AddFlag(
        InstanceStatusOptions flagToBeAdded
    )
    {
        _status = _status | flagToBeAdded;
    }
}
    
