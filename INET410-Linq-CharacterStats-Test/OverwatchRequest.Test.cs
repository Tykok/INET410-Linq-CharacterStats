using INET410.Utils;

namespace INET410_Linq_CharacterStats_Test;

[TestFixture]
[Description("Overwatch Request test")]
public class Tests
{

    [SetUp]
    public void Setup()
    {
        overwatchStats = OverwatchRequests.GetAll();
    }

    private List<Overwatch2Statistics> overwatchStats;

    [Test]
    [Description("Check if the List was correctly populated")]
    public void CheckFile()
    {
        Assert.IsTrue(overwatchStats.Count > 0);
        Assert.IsTrue(overwatchStats[0] != null);
        Assert.IsTrue(overwatchStats[0] is Overwatch2Statistics);
    }

    [Test]
    [Description("Check if an error is thrown when the higher value is greater than the lower value")]
    public void CheckPickRatePercentageThrowError()
    {
        Assert.Throws<Exception>(() => OverwatchRequests.CheckCondition(50, 40));
    }

    [TestCase("Ana")]
    [TestCase("Kiriko")]
    [TestCase("Hanzo")]
    [Description("Check if the Search method works correctly")]
    public void CheckSearch(string hero)
    {
        OverwatchRequests.GetByHero(ref overwatchStats, hero);
        Console.WriteLine(overwatchStats[0].Hero);
        AssertExtensions.Every(overwatchStats, s => s.Hero == hero);
    }

    [TestCase("Bronze")]
    [TestCase("Silver")]
    [TestCase("Gold")]
    [Description("Check if all the SkillTiers are equal to the given value")]
    public void CheckSkillTier(string skillTier)
    {
        OverwatchRequests.GetBySkillTier(ref overwatchStats, skillTier);
        AssertExtensions.Every(overwatchStats, s => s.SkillTier == skillTier);
    }

    [TestCase("Bronze")]
    [TestCase("Silver")]
    [TestCase("Gold")]
    [Description("Check if all the SkillTiers are not equal to the given value")]
    public void CheckIsNotSkillTier(string skillTier, bool isNot = true)
    {
        OverwatchRequests.GetBySkillTier(ref overwatchStats, skillTier, isNot);
        AssertExtensions.Every(overwatchStats, s => s.SkillTier != skillTier);
    }

    [TestCase(0.0, 1)]
    [TestCase(2, 3)]
    [TestCase(4, 5)]
    [Description("Check if all the KDARatios are greater than or equal to the given value")]
    public void CheckKdaRatio(double kdaRatioHigherThan, double kdaRationLowerThan)
    {
        OverwatchRequests.GetByKdaRatio(ref overwatchStats, kdaRatioHigherThan, kdaRationLowerThan);
        AssertExtensions.Every(overwatchStats, s => s.KdaRatio >= kdaRatioHigherThan && s.KdaRatio <= kdaRationLowerThan);
    }

    [TestCase(5, 8)]
    [TestCase(8, 10)]
    [TestCase(10, 15)]
    [Description("Check if all the ObjectiveKillsPer10Min are greater than or equal to the given value")]
    public void CheckPickRatePercentage(double pickRatePercentageHigher, double pickRatePercentageLower)
    {
        OverwatchRequests.GetByPickRatePercentage(ref overwatchStats, pickRatePercentageHigher, pickRatePercentageLower);
        AssertExtensions.Every(overwatchStats, s => s.PickRatePercentage >= pickRatePercentageHigher && s.PickRatePercentage <= pickRatePercentageLower);
    }

    [TestCase(40, 50)]
    [TestCase(50, 60)]
    [TestCase(60, 70)]
    [Description("Check if all the WinRatePercentages are greater than or equal to the given value")]
    public void CheckWinRatePercentage(double winRatePercentageHigher, double winRatePercentageLower)
    {
        OverwatchRequests.GetByWinRatePercentage(ref overwatchStats, winRatePercentageHigher, winRatePercentageLower);
        AssertExtensions.Every(overwatchStats, s => s.WinRatePercentage >= winRatePercentageHigher && s.WinRatePercentage <= winRatePercentageLower);
    }


    [TestCase(5, 10)]
    [TestCase(10, 15)]
    [TestCase(15, 20)]
    [Description("Check if all the EliminationsPer10Min are greater than or equal to the given value")]
    public void CheckEliminationsPer10Min(double eliminationsPer10MinHigher, double eliminationsPer10MinLower)
    {
        OverwatchRequests.GetByEliminationsPer10Min(ref overwatchStats, eliminationsPer10MinHigher, eliminationsPer10MinLower);
        AssertExtensions.Every(overwatchStats, s => s.EliminationsPer10Min >= eliminationsPer10MinHigher && s.EliminationsPer10Min <= eliminationsPer10MinLower);
    }

    [TestCase(2, 4)]
    [TestCase(4, 8)]
    [TestCase(8, 10)]
    [Description("Check if all the FinalBlowsPer10Min are greater than or equal to the given value")]
    public void CheckObjectiveKillsPer10Min(double objectiveKillsPer10MinHigher, double objectiveKillsPer10MinLower)
    {
        OverwatchRequests.GetByObjectiveKillsPer10Min(ref overwatchStats, objectiveKillsPer10MinHigher, objectiveKillsPer10MinLower);
        AssertExtensions.Every(overwatchStats, s => s.ObjectiveKillsPer10Min >= objectiveKillsPer10MinHigher && s.ObjectiveKillsPer10Min <= objectiveKillsPer10MinLower);
    }


    [TestCase(80, 100)]
    [TestCase(100, 110)]
    [TestCase(110, 120)]
    [Description("Check if all the SoloKillsPer10Min are greater than or equal to the given value")]
    public void CheckObjectiveTimePer10Min(int objectiveTimePer10MinHigher, int objectiveTimePer10MinLower)
    {
        OverwatchRequests.GetByObjectiveTimePer10Min(ref overwatchStats, objectiveTimePer10MinHigher, objectiveTimePer10MinLower);
        AssertExtensions.Every(overwatchStats, s => s.ObjectiveTimePer10Min >= objectiveTimePer10MinHigher && s.ObjectiveTimePer10Min <= objectiveTimePer10MinLower);
    }


    [TestCase(1000, 2000)]
    [TestCase(5000, 6000)]
    [TestCase(8000, 10000)]
    [Description("Check if all the DamagePer10Min are greater than or equal to the given value")]
    public void CheckDamagePer10Min(int damagePer10MinHigher, int damagePer10MinLower)
    {
        OverwatchRequests.GetByDamagePer10Min(ref overwatchStats, damagePer10MinHigher, damagePer10MinLower);
        AssertExtensions.Every(overwatchStats, s => s.DamagePer10Min >= damagePer10MinHigher && s.DamagePer10Min <= damagePer10MinLower);
    }

    [TestCase(0, 200)]
    [TestCase(2000, 4000)]
    [TestCase(8000, 10000)]
    [Description("Check if all the HealingPer10Min are greater than or equal to the given value")]
    public void CheckHealingPer10Min(int healingPer10MinHigher, int healingPer10MinLower)
    {
        OverwatchRequests.GetByHealingPer10Min(ref overwatchStats, healingPer10MinHigher, healingPer10MinLower);
        AssertExtensions.Every(overwatchStats, s => s.HealingPer10Min >= healingPer10MinHigher && s.HealingPer10Min <= healingPer10MinLower);
    }

    [TestCase(5, 6)]
    [TestCase(7, 8)]
    [TestCase(8, 9)]
    [Description("Check if all the DeathsPer10Min are greater than or equal to the given value")]
    public void CheckDeathsPer10Min(int deathsPer10MinHigher, int deathsPer10MinLower)
    {
        OverwatchRequests.GetByDeathsPer10Min(ref overwatchStats, deathsPer10MinHigher, deathsPer10MinLower);
        AssertExtensions.Every(overwatchStats, s => s.DeathsPer10Min >= deathsPer10MinHigher && s.DeathsPer10Min <= deathsPer10MinLower);
    }

    [Test]
    [Description("Check the order is correct")]
    public void CheckOrderDesc()
    {
        OverwatchRequests.Sort(ref overwatchStats, SortOrder.DESC, "deathsPer10Min");
        for (var i = 0; i < overwatchStats.Count - 1; i++)
        {
            var current = overwatchStats[i];
            var next = overwatchStats[i + 1];
            Assert.GreaterOrEqual(current.DeathsPer10Min, next.DeathsPer10Min);
        }
    }

    [Test]
    [Description("Check an error is thrown when the order property is not correct")]
    public void CheckOrderDescError()
    {
        Assert.Throws<ArgumentException>(() => OverwatchRequests.Sort(ref overwatchStats, SortOrder.DESC, "anUnknownProperty"));
    }
}