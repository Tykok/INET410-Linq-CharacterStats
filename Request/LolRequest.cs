using Newtonsoft.Json;

namespace INET410.Request;

public class LolRequest
{
    private readonly static string path = "./Data/lol_character_stats.json";

    public static List<LolStatistics> GetCharacters()
    {
        var jsonContent = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<LolStatistics>>(jsonContent).ToList();
    }

    public static List<LolStatistics> Search(
        string? name = null,
        string? classType = null,
        Role? role = null,
        string? tier = null,
        double? score = null,
        double? trend = null,
        double? winPercentage = null,
        double? rolePercentage = null,
        double? pickPercentage = null,
        double? banPercentage = null,
        double? kda = null
    )
    {
        return GetCharacters()
            .Where(h => name == null || h.Name == name)
            .Where(h => classType == null || h.Class == classType)
            .Where(h => role == null || h.Role == role)
            .Where(h => tier == null || h.Tier == tier)
            .Where(h => score == null || h.Score >= score)
            .Where(h => trend == null || h.Trend >= trend)
            .Where(h => winPercentage == null || h.WinPercentage >= winPercentage)
            .Where(h => rolePercentage == null || h.RolePercentage >= rolePercentage)
            .Where(h => pickPercentage == null || h.PickPercentage >= pickPercentage)
            .Where(h => banPercentage == null || h.BanPercentage >= banPercentage)
            .Where(h => kda == null || h.Kda >= kda)
            .ToList();
    }
}