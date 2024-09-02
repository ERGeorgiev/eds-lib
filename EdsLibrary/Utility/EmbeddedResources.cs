using System.Reflection;

namespace EdsLibrary.Utility;

public static class EmbeddedResources
{
    public static Stream GetOrThrow(string filename, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        => Get(filename, comparisonType) ?? throw new NullReferenceException($"Stream for file '{filename}' is null. Does the file exist?");

    public static Stream? Get(string filename, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
    {
        var callingAssembly = Assembly.GetCallingAssembly();
        var manifestResources = GetManifestResourceNamesThatContainFile(callingAssembly, filename, comparisonType);
        if (manifestResources.Count() > 1) Logger.LogWarning($"More than a single assembly manifest resource contains file '{filename}', using the first instance.");

        var manifestResource = manifestResources.FirstOrDefault();
        if (string.IsNullOrEmpty(manifestResource))
        {
            Logger.LogError($"Failed to load embedded resource '{filename}', no such found.");
            return null;
        }

        return Assembly.GetCallingAssembly().GetManifestResourceStream(manifestResource);
    }

    private static IEnumerable<string> GetManifestResourceNamesThatContainFile(Assembly assembly, string filename, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
    {
        var names = assembly.GetManifestResourceNames().ToArray();
        var validNames = names.Where(v => v.EndsWith("." + filename, comparisonType)).ToArray();
        return validNames;
    }
}
