using Newtonsoft.Json;

namespace Korn.Plugins.ExternalInterface
{
    public class PluginManifest
    {
        public string Name;
        public string DisplayName;
        public string Version;
        public PluginAuthor[] Authors;
        public PluginTarget[] Targets;

        public static PluginManifest Deserialize(string path) => JsonConvert.DeserializeObject<PluginManifest>(path);
    }

    public class PluginAuthor
    {
        public string Name;
        public string Github;
    }

    public class PluginTarget
    {
        public PluginFrameworkTarget TargetFramework;
        public string[] TargetProcesses;
        public string ExecutableFilePath;
        public string PluginClass;
    }

    public enum PluginFrameworkTarget
    {
        NetFramework472,
        Net8
    }
}