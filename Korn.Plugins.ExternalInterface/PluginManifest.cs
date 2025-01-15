using Newtonsoft.Json;

namespace Korn.Plugins.ExternalInterface;
public record PluginManifest(
    string Name,
    string DisplayName,
    string Version,
    PluginAuthor[] Authors,
    PluginTarget[] Targets)
{
    public static PluginManifest? Deserialize(string path) => JsonConvert.DeserializeObject<PluginManifest>(path);
}

public record PluginAuthor(
    string Name,
    string? Github
);

public record PluginTarget(
    PluginFrameworkTarget TargetFramework,
    string[]? TargetProcesses,
    string ExecutableFilePath,
    string PluginClass
);

public enum PluginFrameworkTarget
{
    NetFramework472,
    Net8
}