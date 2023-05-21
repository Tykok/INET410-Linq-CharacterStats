namespace INET410_Linq_CharacterStats_Test;

[TestFixture, Description("Fixture description here")]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test, Description("Check if the List was correctly populated")]
    public void CheckFile()
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.GetAll();
        Assert.IsTrue(stats.Count > 0);
        Assert.IsTrue(stats[0] != null);
        Assert.IsTrue(stats[0] is Overwatch2Statistics);
    }
    
    [TestCase("Ana")]
    [TestCase("Kiriko")]
    [TestCase("Hanzo")]
    [Description("Check if the Search method works correctly")]
    public void CheckSearch(string hero)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(hero: hero);
        Console.WriteLine(stats[0].Hero);
        AssertExtensions.Every(stats, s => s.Hero == hero);
    }
    
    [TestCase("Bronze")]
    [TestCase("Silver")]
    [TestCase("Gold")]
    [Description("Check if all the SkillTiers are equal to the given value")]
    public void CheckSkillTier(string skillTier)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(skillTier: skillTier);
        AssertExtensions.Every(stats, s => s.SkillTier == skillTier);
    }
    
    [TestCase(0.0)]
    [TestCase(2)]
    [TestCase(4)]
    [Description("Check if all the KDARatios are greater than or equal to the given value")]
    public void CheckKdaRatio(double kdaRatio)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(kdaRatio: kdaRatio);
        AssertExtensions.Every(stats, s => s.KDARatio >= kdaRatio);
    }
    
    [TestCase(5)]
    [TestCase(8)]
    [TestCase(10)]
    [Description("Check if all the ObjectiveKillsPer10min are greater than or equal to the given value")]
    public void CheckPickRatePercentage(double pickRatePercentage)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(pickRatePercentage: pickRatePercentage);
        AssertExtensions.Every(stats, s => s.PickRatePercentage >= pickRatePercentage);
    }
    
    [TestCase(40)]
    [TestCase(50)]
    [TestCase(60)]
    [Description("Check if all the WinRatePercentages are greater than or equal to the given value")]
    public void CheckWinRatePercentage(double winRatePercentage)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(winRatePercentage: winRatePercentage);
        AssertExtensions.Every(stats, s => s.WinRatePercentage >= winRatePercentage);
    }
    
    
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(15)]
    [Description("Check if all the EliminationsPer10min are greater than or equal to the given value")]
    public void CheckEliminationsPer10min(double eliminationsPer10min)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(eliminationsPer10min: eliminationsPer10min);
        AssertExtensions.Every(stats, s => s.EliminationsPer10min >= eliminationsPer10min);
    }
    
    
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(8)]
    [Description("Check if all the FinalBlowsPer10min are greater than or equal to the given value")]
    public void CheckObjectiveKillsPer10min(double objectiveKillsPer10min)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(objectiveKillsPer10min: objectiveKillsPer10min);
        AssertExtensions.Every(stats, s => s.ObjectiveKillsPer10min >= objectiveKillsPer10min);
    }
    
    
    [TestCase(80)]
    [TestCase(100)]
    [TestCase(110)]
    [Description("Check if all the SoloKillsPer10min are greater than or equal to the given value")]
    public void CheckObjectiveTimePer10min(int objectiveTimePer10min)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(objectiveTimePer10min: objectiveTimePer10min);
        AssertExtensions.Every(stats, s => s.ObjectiveTimePer10min >= objectiveTimePer10min);
    }
    
    
    [TestCase(1000)]
    [TestCase(5000)]
    [TestCase(8000)]
    [Description("Check if all the DamagePer10min are greater than or equal to the given value")]
    public void CheckDamagePer10min(int damagePer10min)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(damagePer10min: damagePer10min);
        AssertExtensions.Every(stats, s => s.DamagePer10min >= damagePer10min);
    }
    
    
    [TestCase(0)]
    [TestCase(2000)]
    [TestCase(8000)]
    [Description("Check if all the HealingPer10min are greater than or equal to the given value")]
    public void CheckHealingPer10min(int healingPer10min)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(healingPer10min: healingPer10min);
        AssertExtensions.Every(stats, s => s.HealingPer10min >= healingPer10min);
    }
    
    
    [TestCase(5)]
    [TestCase(7)]
    [TestCase(8)]
    [Description("Check if all the DeathsPer10min are greater than or equal to the given value")]
    public void CheckDeathsPer10min(int deathsPer10min)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(deathsPer10min: deathsPer10min);
        AssertExtensions.Every(stats, s => s.DeathsPer10min >= deathsPer10min);
    }

    [TestCase("Ana", "Bronze")]
    [TestCase("Kiriko", "Silver")]
    [TestCase("Hanzo", "Gold")]
    [Description("Check if all the Hero and SkillTier are equal to the given values")]
    public void CheckNameAndSkillTier(string hero, string skillTier)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(hero: hero, skillTier: skillTier);
        AssertExtensions.Every(stats, s => s.Hero == hero && s.SkillTier == skillTier);
    }
    
    [TestCase("Ana", 0.0)]
    [TestCase("Kiriko", 2)]
    [TestCase("Hanzo", 4)]
    [Description("Check if all the Hero are equal to the given values, and KDARatio are greater than or equal to the given value")]
    public void CheckNameAndKdaRatio(string hero, double kdaRatio)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(hero: hero, kdaRatio: kdaRatio);
        AssertExtensions.Every(stats, s => s.Hero == hero && s.KDARatio >= kdaRatio);
    }
    
    
    [TestCase("Ana", 5)]
    [TestCase("Kiriko", 8)]
    [TestCase("Hanzo", 10)]
    [Description("Check if all the Hero are equal to the given values, and ObjectiveKillsPer10min are greater than or equal to the given value")]
    public void CheackNameAndPickRatePercentage(string hero, double pickRatePercentage)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(hero: hero, pickRatePercentage: pickRatePercentage);
        AssertExtensions.Every(stats, s => s.Hero == hero && s.PickRatePercentage >= pickRatePercentage);
    }
    
    
    [TestCase("Ana", 40)]
    [TestCase("Kiriko", 50)]
    [TestCase("Hanzo", 60)]
    [Description("Check if all the Hero are equal to the given values, and WinRatePercentage are greater than or equal to the given value")]
    public void CheckNameAndWinRatePercentage(string hero, double winRatePercentage)
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(hero: hero, winRatePercentage: winRatePercentage);
        AssertExtensions.Every(stats, s => s.Hero == hero && s.WinRatePercentage >= winRatePercentage);
    }

    [Test, Description("Check if all conditions are met")]
    public void CheckForAllConditions()
    {
        List<Overwatch2Statistics> stats = OverwatchRequests.Search(
            hero: "Ana", 
            skillTier: "Bronze", 
            kdaRatio: 0.0, 
            pickRatePercentage: 5, 
            winRatePercentage: 40,
            eliminationsPer10min: 5,
            objectiveKillsPer10min: 2,
            objectiveTimePer10min: 80,
            damagePer10min: 1000,
            healingPer10min: 0,
            deathsPer10min: 5
            );
        AssertExtensions.Every(stats, s => 
            s.Hero == "Ana" 
            && s.SkillTier == "Bronze" 
            && s.KDARatio >= 0.0 
            && s.PickRatePercentage >= 5 
            && s.WinRatePercentage >= 40
            && s.EliminationsPer10min >= 5
            && s.ObjectiveKillsPer10min >= 2
            && s.ObjectiveTimePer10min >= 80
            && s.DamagePer10min >= 1000
            && s.HealingPer10min >= 0
            && s.DeathsPer10min >= 5
            );
    }
    
}