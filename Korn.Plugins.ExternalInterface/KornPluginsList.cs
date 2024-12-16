using Korn.Utils;

namespace Korn.Plugins.ExternalInterface;
public class KornPluginsList
{
    static readonly string KornPath = SystemVariablesUtils.GetKornPath()!;
    static readonly string ListPath = Path.Combine(KornPath, "");

    public static ModelJson Read()
    {

    }

    public record ModelJson(
        List<GithubPluginJson> OfficialPlugins,
        List<LocalPluginJson> LocalPlugins
    );

    public record GithubPluginJson(string Name, string GithubRepository);
    public record LocalPluginJson(string Name, string DirectoryPath, string ExecutableFileName);
}