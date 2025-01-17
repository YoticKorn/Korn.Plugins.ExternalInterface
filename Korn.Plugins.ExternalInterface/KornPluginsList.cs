using Korn.Shared;
using Korn.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Korn.Plugins.ExternalInterface 
{
    public class KornPluginsList
    {
        static void ValidateFile()
        {
            if (!File.Exists(KornPaths.PluginsListFile))
                throw new KornError(
                    "KornPluginsList->Get:",
                    $@"file {KornPaths.PluginsListFile} doesn't exist."
                );
        }

        public static PluginsListJson Get()
        {
            ValidateFile();
            return JsonConvert.DeserializeObject<PluginsListJson>(File.ReadAllText(KornPaths.PluginsListFile));
        }

        // it must be initially created as an empty file, without calling Set
        public static void Set(PluginsListJson pluginsList)
        {
            ValidateFile();
            File.WriteAllText(KornPaths.PluginsListFile, JsonConvert.SerializeObject(pluginsList, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            }));
        }

        public class PluginsListJson
        {
            public List<GithubPluginJson> OfficialPlugins;
            public List<LocalPluginJson> LocalPlugins;
        }

        public class GithubPluginJson
        {
            public string Name;
            public string GithubRepository;
        }

        public class LocalPluginJson
        {
            public string Name;
        }
    }
}