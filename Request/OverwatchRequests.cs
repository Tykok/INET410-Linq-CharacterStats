using INET410.Utils;

namespace INET410.Request;

public class OverwatchRequests : BasicsRequest
{

    private readonly static string Path = "./Data/overwatchs2_character_stats.csv";

    public static IEnumerable<Overwatch2Statistics> GetList()
    {
        return File.ReadAllLines(Path)
            .Skip(1)
            .Select(Overwatch2Statistics.ParseRow);
    }

    public static List<Overwatch2Statistics> GetAll()
    {
        return GetList().ToList();
    }

    public static void GetByHero(ref List<Overwatch2Statistics> listOfFilteredStats, string? hero, bool isNot = false)
    {
        listOfFilteredStats = listOfFilteredStats
            .Where(h => hero == null || isNot ? h.Hero != hero: h.Hero == hero)
            .ToList();
    }


    public static void GetBySkillTier(ref List<Overwatch2Statistics> listOfFilteredStats, string? skillTier, bool isNot = false)
    {
        listOfFilteredStats = listOfFilteredStats
            .Where(h => skillTier == null || isNot ? h.SkillTier != skillTier: h.SkillTier == skillTier)
            .ToList();
    }

    public static void GetByKdaRatio(
        ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.KdaRatio >= isHigherThan)
            .Where(h => isLowerThan == null || h.KdaRatio <= isLowerThan)
            .ToList();
    }

    public static void GetByObjectiveKillsPer10Min(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.ObjectiveKillsPer10Min >= isHigherThan)
            .Where(h => isLowerThan == null || h.ObjectiveKillsPer10Min <= isLowerThan)
            .ToList();
    }

    public static void GetByPickRatePercentage(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.PickRatePercentage >= isHigherThan)
            .Where(h => isLowerThan == null || h.PickRatePercentage <= isLowerThan)
            .ToList();
    }

    public static void GetByObjectiveTimePer10Min(ref List<Overwatch2Statistics> listOfFilteredStats, int? isHigherThan, int? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.ObjectiveTimePer10Min >= isHigherThan)
            .Where(h => isLowerThan == null || h.ObjectiveTimePer10Min <= isLowerThan)
            .ToList();
    }

    public static void GetByWinRatePercentage(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.WinRatePercentage >= isHigherThan)
            .Where(h => isLowerThan == null || h.WinRatePercentage <= isLowerThan)
            .ToList();
    }

    public static void GetByEliminationsPer10Min(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.EliminationsPer10Min >= isHigherThan)
            .Where(h => isLowerThan == null || h.EliminationsPer10Min <= isLowerThan)
            .ToList();
    }

    public static void GetByDeathsPer10Min(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.DeathsPer10Min >= isHigherThan)
            .Where(h => isLowerThan == null || h.DeathsPer10Min <= isLowerThan)
            .ToList();
    }

    public static void GetByDamagePer10Min(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.DamagePer10Min >= isHigherThan)
            .Where(h => isLowerThan == null || h.DamagePer10Min <= isLowerThan)
            .ToList();
    }

    public static void GetByHealingPer10Min(ref List<Overwatch2Statistics> listOfFilteredStats, double? isHigherThan, double? isLowerThan)
    {
        CheckCondition(isHigherThan, isLowerThan);
        listOfFilteredStats = listOfFilteredStats
            .Where(h => isHigherThan == null || h.HealingPer10Min >= isHigherThan)
            .Where(h => isLowerThan == null || h.HealingPer10Min <= isLowerThan)
            .ToList();
    }

    public static void Order(ref List<Overwatch2Statistics> listOfStats, SortOrder sortOrder, string sortProperty)
    {
        OrderListByProperty(ref listOfStats, sortOrder, sortProperty);
    }
}