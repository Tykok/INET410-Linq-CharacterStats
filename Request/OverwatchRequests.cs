using INET410.Entity;

namespace INET410.Request;

public class OverwatchRequests
{
    
    private static string path = "Data/overwatchs2_character_stats.csv";
    
    private static IEnumerable<Overwatch2Statistics> GetList() => File.ReadAllLines(path)
        .Skip(1)
        .Select(Overwatch2Statistics.ParseRow);
    
    public static  List<Overwatch2Statistics> GetAll()=> GetList().ToList();

    public static List<Overwatch2Statistics> Search(
        string? hero,
        string? skillTier,
        double? kdaRatio,
        double? pickRatePercentage,
        double? winRatePercentage,
        double? eliminationsPer10min,
        double? objectiveKillsPer10min,
        int? objectiveTimePer10min,
        int? damagePer10min,
        int? healingPer10min,
        double? deathsPer10min
    )
    {
        return GetAll()
            .Where(h => hero == null || h.Hero == hero)
            .Where(h => skillTier == null || h.SkillTier == skillTier)
            .Where(h => kdaRatio == null || h.KDARatio >= kdaRatio)
            .Where(h => pickRatePercentage == null || h.PickRatePercentage >= pickRatePercentage)
            .Where(h => winRatePercentage == null || h.WinRatePercentage >= winRatePercentage)
            .Where(h => eliminationsPer10min == null || h.EliminationsPer10min >= eliminationsPer10min)
            .Where(h => objectiveKillsPer10min == null || h.ObjectiveKillsPer10min >= objectiveKillsPer10min)
            .Where(h => objectiveTimePer10min == null || h.ObjectiveTimePer10min >= objectiveTimePer10min)
            .Where(h => damagePer10min == null || h.DamagePer10min >= damagePer10min)
            .Where(h => healingPer10min == null || h.HealingPer10min >= healingPer10min)
            .Where(h => deathsPer10min == null || h.DeathsPer10min >= deathsPer10min)
            .ToList();
    }

}