namespace INET410_Linq_CharacterStats_Test;

[TestFixture]
public class LolRequest_Test
{

    [SetUp]
    public void Setup()
    {
        _lolStats = LolRequest.GetAll();
    }

    private List<LolStatistics> _lolStats;

    [TestCase("yn")]
    [TestCase("Sera")]
    [TestCase("set")]
    [TestCase("Yone")]
    [Description("Check if the name is contained in the list of characters")]
    public void CheckNameCondition(string champion)
    {
        LolRequest.FilterByName(ref _lolStats, champion);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Name.ToUpper().Contains(champion.ToUpper()));
    }

    [TestCase("fight")]
    [TestCase("Sup")]
    [TestCase("mage")]
    [Description("Check if the class is contained in the list of characters")]
    public void CheckClassCondition(string classe)
    {
        LolRequest.FilterByType(ref _lolStats, classe);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Class.ToUpper().Contains(classe.ToUpper()));
    }

    [TestCase("adc")]
    [TestCase("mid")]
    [TestCase("toP")]
    [Description("Check if the role is contained in the list of characters")]
    public void CheckRoleCondition(string role)
    {
        LolRequest.FilterByRole(ref _lolStats, role);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Role.ToUpper().Contains(role.ToUpper()));
    }

    [TestCase("A")]
    [TestCase("B")]
    [TestCase("C")]
    [Description("Check if the tier is contained in the list of characters")]
    public void CheckTierCondition(string tier)
    {
        LolRequest.GetTierEqual(ref _lolStats, tier);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Tier == tier);
    }

    [TestCase(30, 40)]
    [TestCase(40, 65)]
    [TestCase(50, 80)]
    [Description("Check if the role percentage is contained in the list of characters")]
    public void CheckScoreCondition(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByScore(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Score >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.Score <= isLowerThan);
    }

    [TestCase(-5, -1)]
    [TestCase(-1, 0)]
    [TestCase(0, 2)]
    [Description("Check if the role percentage is contained in the list of characters")]
    public void CheckTrendCondition(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByTrend(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Trend >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.Trend <= isLowerThan);
    }

    [TestCase(40, 50)]
    [TestCase(50, 60)]
    [Description("Check if the win percentage is contained in the list of characters")]
    public void CheckWinpercentageCondition(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByWinPercentage(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.WinPercentage >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.WinPercentage <= isLowerThan);
    }

    [TestCase(10, 30)]
    [TestCase(20, 50)]
    [TestCase(50, 70)]
    [Description("Check if the pick percentage is contained in the list of characters")]
    public void CheckRolePercentageCondition(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByRolePercentage(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.RolePercentage >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.RolePercentage <= isLowerThan);
    }

    [TestCase(0.7, 1.2)]
    [TestCase(0.8, 1.3)]
    [TestCase(0.9, 1.4)]
    [Description("Check if the pick percentage is contained in the list of characters")]
    public void CheckPickPercentageCondition(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByPickPercentage(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.PickPercentage >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.PickPercentage <= isLowerThan);
    }

    [TestCase(0.9, 1.2)]
    [TestCase(1, 1.4)]
    [Description("Check if the ban percentage is contained in the list of characters")]
    public void CheckBanPercentage(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByBanPercentage(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.BanPercentage >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.BanPercentage <= isLowerThan);
    }

    [TestCase(1, 2)]
    [TestCase(2, 3)]
    [TestCase(3, 4)]
    [Description("Check if the ban percentage is contained in the list of characters")]
    public void CheckKdaCondition(double isHigherThan, double isLowerThan)
    {
        LolRequest.GetByKdaRatio(ref _lolStats, isHigherThan, isLowerThan);
        Assert.IsTrue(_lolStats.Count > 0);
        AssertExtensions.Every(_lolStats, h => h.Kda >= isHigherThan);
        AssertExtensions.Every(_lolStats, h => h.Kda <= isLowerThan);
    }
}