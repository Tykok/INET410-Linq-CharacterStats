using System.Globalization;
using INET410.Utils;

namespace INET410.Entity;

public class Overwatch2Statistics
{
    
    // TODO See Getter and setter
    public String Hero ;
    public String SkillTier ;
    public Double KDARatio ;
    public Double? PickRatePercentage ;
    public Double? WinRatePercentage ;
    public Double? EliminationsPer10min ;
    public Double? ObjectiveKillsPer10min ;
    public Int32? ObjectiveTimePer10min ;
    public Int32? DamagePer10min ;
    public Int32? HealingPer10min ;
    public Double? DeathsPer10min ;

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
        
        double? PickRatePercentage = null;
        double? WinRatePercentage = null;
        double? EliminationsPer10min = null;
        double? ObjectiveKillsPer10min = null;
        int? ObjectiveTimePer10min = null;
        int? DamagePer10min = null;
        int? HealingPer10min = null;
        double? DeathsPer10min = null;
        
        
        if (!string.IsNullOrEmpty(columns[3]))
            PickRatePercentage = Cast.StringToDouble(columns[3]);
        
        if (!string.IsNullOrEmpty(columns[4]))
            WinRatePercentage = Cast.StringToDouble(columns[4]);
        
        if (!string.IsNullOrEmpty(columns[5]))
            EliminationsPer10min = Cast.StringToDouble(columns[5]);
        
        if (!string.IsNullOrEmpty(columns[6]))
            ObjectiveKillsPer10min = Cast.StringToDouble(columns[6]);
        
        if (!string.IsNullOrEmpty(columns[7]))
            ObjectiveTimePer10min = Cast.StringToInt(columns[7]);
        
        if (!string.IsNullOrEmpty(columns[8]))
            HealingPer10min = Cast.StringToInt(columns[8]);
        
        if (!string.IsNullOrEmpty(columns[9]))
            DeathsPer10min = Cast.StringToDouble(columns[9]);
        
        return new Overwatch2Statistics(
            columns[0],
            columns[1],
            Cast.StringToDouble(columns[2]),
            PickRatePercentage,
            WinRatePercentage,
            EliminationsPer10min,
            ObjectiveKillsPer10min,
            ObjectiveTimePer10min,
            DamagePer10min,
            HealingPer10min,
            DeathsPer10min
        );
    }
    
    public override string ToString()
    {
        return base.ToString();
    }
}