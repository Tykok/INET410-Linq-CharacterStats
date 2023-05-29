using INET410.Utils;

namespace INET410.Request;

public class LolRequest : BasicsRequest
{
    private readonly static string path = "./Data/lol_character_stats.json";

    public static List<LolStatistics> GetCharacters()
    {
        return DeserializeJson<LolStatistics>(path);
    }

    public static void GetByName(ref List<LolStatistics> listOfFilteredStats, string? name, bool isNot = false)
    {
        listOfFilteredStats = listOfFilteredStats.Where(h => name == null || isNot ? h.Name != name: h.Name == name).ToList();
    }

    public static void GetByClassType(ref List<LolStatistics> listOfFilteredStats, string? classType, bool isNot = false)
    {
        listOfFilteredStats = listOfFilteredStats.Where(h => classType == null || isNot ? h.Class != classType: h.Class == classType).ToList();
    }

    public static void GetByRole(ref List<LolStatistics> listOfFilteredStats, string? role, bool isNot = false)
    {
        listOfFilteredStats = listOfFilteredStats.Where(h => role == null || isNot ? h.Role != role: h.Role == role).ToList();
    }

    public static void GetByTier(ref List<LolStatistics> listOfFilteredStats, string? tier, bool isNot = false)
    {
        listOfFilteredStats = listOfFilteredStats.Where(h => tier == null || isNot ? h.Tier != tier: h.Tier == tier).ToList();
    }

    public static void GetByScore(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.Score >= isHigherThan)
            .Where(h => isLowerThan == null || h.Score <= isLowerThan)
            .ToList();
    }

    public static void GetByRolePercentage(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.RolePercentage >= isHigherThan)
            .Where(h => isLowerThan == null || h.RolePercentage <= isLowerThan)
            .ToList();
    }

    public static void GetByTrend(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.Trend >= isHigherThan)
            .Where(h => isLowerThan == null || h.Trend <= isLowerThan)
            .ToList();
    }

    public static void GetByWinPercentage(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.WinPercentage >= isHigherThan)
            .Where(h => isLowerThan == null || h.WinPercentage <= isLowerThan)
            .ToList();
    }

    public static void GetByPickPercentage(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.PickPercentage >= isHigherThan)
            .Where(h => isLowerThan == null || h.PickPercentage <= isLowerThan)
            .ToList();
    }

    public static void GetByBanPercentage(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.BanPercentage >= isHigherThan)
            .Where(h => isLowerThan == null || h.BanPercentage <= isLowerThan)
            .ToList();
    }

    public static void GetByKdaRatio(ref List<LolStatistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.Kda >= isHigherThan)
            .Where(h => isLowerThan == null || h.Kda <= isLowerThan)
            .ToList();
    }

    public static void Order(ref List<LolStatistics> listOfFilteredStats, SortOrder sortBy, string sortProperty)
    {
        OrderListByProperty(ref listOfFilteredStats, sortBy, sortProperty);
    }
}