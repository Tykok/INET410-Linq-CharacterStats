using System.Text.Json.Serialization;
using INET410.Utils;

namespace INET410.Entity;

public class Overwatch2Statistics
{

    public Overwatch2Statistics(
        string hero,
        string skillTier,
        double kdaRatio,
        double? pickRatePercentage,
        double? winRatePercentage,
        double? eliminationsPer10Min,
        double? objectiveKillsPer10Min,
        int? objectiveTimePer10Min,
        int? damagePer10Min,
        int? healingPer10Min,
        double? deathsPer10Min)
    {
        Hero = hero;
        SkillTier = skillTier;
        KdaRatio = kdaRatio;
        PickRatePercentage = pickRatePercentage;
        WinRatePercentage = winRatePercentage;
        EliminationsPer10Min = eliminationsPer10Min;
        ObjectiveKillsPer10Min = objectiveKillsPer10Min;
        ObjectiveTimePer10Min = objectiveTimePer10Min;
        DamagePer10Min = damagePer10Min;
        HealingPer10Min = healingPer10Min;
        DeathsPer10Min = deathsPer10Min;
    }

    [JsonPropertyName("hero")]
    public string Hero {get; set;}

    [JsonPropertyName("skillTier")]
    public string SkillTier {get; set;}

    [JsonPropertyName("kdaRatio")]
    public double KdaRatio {get; set;}

    [JsonPropertyName("pickRatePercentage")]
    public double? PickRatePercentage {get; set;}

    [JsonPropertyName("winRatePercentage")]
    public double? WinRatePercentage {get; set;}

    [JsonPropertyName("eliminationsPer10min")]
    public double? EliminationsPer10Min {get; set;}

    [JsonPropertyName("ObjectiveKillsPer10min")]
    public double? ObjectiveKillsPer10Min {get; set;}

    [JsonPropertyName("objectiveTimePer10min")]
    public int? ObjectiveTimePer10Min {get; set;}

    [JsonPropertyName("damagePer10min")]
    public int? DamagePer10Min {get; set;}

    [JsonPropertyName("healingPer10min")]
    public int? HealingPer10Min {get; set;}

    [JsonPropertyName("deathsPer10min")]
    public double? DeathsPer10Min {get; set;}


    internal static Overwatch2Statistics ParseRow(string row)
    {
        var columns = row.Split(',');
        return new Overwatch2Statistics(
            columns[0],
            columns[1],
            Cast.StringToDouble(columns[2]),
            !string.IsNullOrEmpty(columns[3]) ? Cast.StringToDouble(columns[3]): null,
            !string.IsNullOrEmpty(columns[4]) ? Cast.StringToDouble(columns[4]): null,
            !string.IsNullOrEmpty(columns[5]) ? Cast.StringToDouble(columns[5]): null,
            !string.IsNullOrEmpty(columns[6]) ? Cast.StringToDouble(columns[6]): null,
            !string.IsNullOrEmpty(columns[7]) ? Cast.StringToInt(columns[7]): null,
            !string.IsNullOrEmpty(columns[8]) ? Cast.StringToInt(columns[8]): null,
            !string.IsNullOrEmpty(columns[9]) ? Cast.StringToInt(columns[9]): null,
            !string.IsNullOrEmpty(columns[10]) ? Cast.StringToDouble(columns[10]): null
        );
    }

    public override string ToString()
    {
        var stringOutput = $"Hero: {Hero}," +
                           $"SkillTier: {SkillTier}," +
                           $"KDARatio: {KdaRatio}," +
                           $"PickRatePercentage: {PickRatePercentage}," +
                           $"WinRatePercentage: {WinRatePercentage}," +
                           $"EliminationsPer10Min: {EliminationsPer10Min}," +
                           $"ObjectiveKillsPer10Min: {ObjectiveKillsPer10Min}," +
                           $"ObjectiveTimePer10Min: {ObjectiveTimePer10Min}," +
                           $"DamagePer10Min: {DamagePer10Min}," +
                           $"HealingPer10Min: {HealingPer10Min}," +
                           $"DeathsPer10Min: {DeathsPer10Min}";
        return stringOutput;
    }
}