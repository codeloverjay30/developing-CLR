using System.ComponentModel;

namespace FluentInstances;

public enum InstanceStatusOptions
{
    [Description("""A variable is declared, defined, set, and not missing""")]
    AllReady = 0,

    [Description("""A variable is declared but has not been defined (i.e. has not been specified with value)""")]
    Undefined = 1,

    [Description("""Either a variable is declared but has not been defined <see cref="InstanceStatusOptions.Undefined"/> or a variable is in unset state""")]
    Unset = 2,

    [Description("""A value on key-value pairs structure is missing.""")]
    Missing = 4,
}