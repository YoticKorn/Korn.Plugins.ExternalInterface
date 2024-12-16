using Korn.Utils;
using Newtonsoft.Json;

namespace Korn.Plugins.ExternalInterface;
public class KornPluginsList
{
    static readonly string KornPath = SystemVariablesUtils.GetKornPath()!;
    static readonly string ListPath = Path.Combine(KornPath, @"Data\plugins.txt");

    static void ValidateFile()
    {
        if (!File.Exists(ListPath))
            throw new KornError([
                "KornPluginsList->Get:",
                @"Korn\Data\plugins.txt doesn't exist."
            ]);
    }

    public static PluginsListJson? Get()
    {
        ValidateFile();
        return JsonConvert.DeserializeObject<PluginsListJson>(File.ReadAllText(ListPath));
    }

    // it must be initially created as an empty file, without calling Set
    public static void Set(PluginsListJson pluginsList)
    {
        ValidateFile();
        File.WriteAllText(ListPath, JsonConvert.SerializeObject(pluginsList, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        }));
    }

    public record PluginsListJson(
        List<GithubPluginJson> OfficialPlugins,
        List<LocalPluginJson> LocalPlugins
    );

    public record GithubPluginJson(string Name, string GithubRepository);
    public record LocalPluginJson(string Name);
}