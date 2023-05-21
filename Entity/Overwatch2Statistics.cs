using System.Globalization;
using System.Text.Json.Serialization;
using INET410.Utils;

namespace INET410.Entity;

public class Overwatch2Statistics
{
   
    [JsonPropertyName("hero")]
    public String Hero{get; set;}
    
    [JsonPropertyName("skillTier")]
    public String SkillTier{get; set;}

    [JsonPropertyName("kdaRatio")] 
    public Double KDARatio{get; set;}
    
    [JsonPropertyName("pickRatePercentage")]
    public Double? PickRatePercentage{get; set;}
    
    [JsonPropertyName("winRatePercentage")]
    public Double? WinRatePercentage {get; set;}
    
    [JsonPropertyName("eliminationsPer10min")]
    public Double? EliminationsPer10min {get; set;}
    
    [JsonPropertyName("ObjectiveKillsPer10min")]
    public Double? ObjectiveKillsPer10min {get; set;}
    
    [JsonPropertyName("objectiveTimePer10min")]
    public Int32? ObjectiveTimePer10min {get; set;}
    
    [JsonPropertyName("damagePer10min")]
    public Int32? DamagePer10min {get; set;}
    
    [JsonPropertyName("healingPer10min")]
    public Int32? HealingPer10min {get; set;}
    
    [JsonPropertyName("deathsPer10min")]
    public Double? DeathsPer10min {get; set;}

    public Overwatch2Statistics(
        String Hero,
        String SkillTier,
        Double KDARatio,
        Double? PickRatePercentage,
        Double? WinRatePercentage,
        Double? EliminationsPer10min,
        Double? ObjectiveKillsPer10min,
        Int32? ObjectiveTimePer10min,
        Int32? DamagePer10min,
        Int32? HealingPer10min,
        Double? DeathsPer10min)
    {
        this.Hero = Hero;
        this.SkillTier = SkillTier;
        this.KDARatio = KDARatio;
        this.PickRatePercentage = PickRatePercentage;
        this.WinRatePercentage = WinRatePercentage;
        this.EliminationsPer10min = EliminationsPer10min;
        this.ObjectiveKillsPer10min = ObjectiveKillsPer10min;
        this.ObjectiveTimePer10min = ObjectiveTimePer10min;
        this.DamagePer10min = DamagePer10min;
        this.HealingPer10min = HealingPer10min;
        this.DeathsPer10min = DeathsPer10min;
    }
    
    
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
            !string.IsNullOrEmpty(columns[10]) ? Cast.StringToDouble(columns[10]) : null
        );
    }
    
    public override string ToString()
    {
        string stringOutput =  $"Hero: {Hero}," +
                      $"SkillTier: {SkillTier}," +
                      $"KDARatio: {KDARatio}," +
                      $"PickRatePercentage: {PickRatePercentage}," +
                      $"WinRatePercentage: {WinRatePercentage}," +
                      $"EliminationsPer10min: {EliminationsPer10min}," +
                      $"ObjectiveKillsPer10min: {ObjectiveKillsPer10min}," +
                      $"ObjectiveTimePer10min: {ObjectiveTimePer10min}," +
                      $"DamagePer10min: {DamagePer10min}," + 
                      $"HealingPer10min: {HealingPer10min}," + 
                      $"DeathsPer10min: {DeathsPer10min}";
        return stringOutput;
    }
}