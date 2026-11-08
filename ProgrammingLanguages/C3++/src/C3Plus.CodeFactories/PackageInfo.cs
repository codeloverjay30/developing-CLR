namespace C3Plus.CodeFactories;

public record class PackageInfo
{
    public string PackageName;
    public string Version;
    public string RootNamespace;

    public PackageInfo(
        string packageName,
        string version,
        string rootNamespace
    )
    {
        ArgumentException.
        PackageName = packageName;
        Version = version;
        RootNamespace = rootNamespace;
    }
}
