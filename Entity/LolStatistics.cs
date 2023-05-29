using System.Text.Json.Serialization;
using INET410.Utils;

namespace INET410.Entity;

public class LolStatistics
{

    public LolStatistics(
        string name,
        string classe,
        string role,
        string tier,
        double score,
        double trend,
        string winPercentage,
        string rolePercentage,
        string pickPercentage,
        string banPercentage,
        double kda
    )
    {
        Name = name;
        Class = classe;
        Role = role;
        Tier = tier;
        Score = score;
        Trend = trend;
        WinPercentage = Cast.StringToDouble(winPercentage.Replace("%", ""));
        RolePercentage = Cast.StringToDouble(rolePercentage.Replace("%", ""));
        PickPercentage = Cast.StringToDouble(pickPercentage.Replace("%", ""));
        BanPercentage = Cast.StringToDouble(banPercentage.Replace("%", ""));
        Kda = kda;
    }

    [JsonPropertyName("name")]
    public string Name {get; set;}

    [JsonPropertyName("class")]
    public string Class {get; set;}

    [JsonPropertyName("role")]
    public string Role {get; set;}

    [JsonPropertyName("tier")]
    public string Tier {get; set;}

    [JsonPropertyName("score")]
    public double Score {get; set;}

    [JsonPropertyName("trend")]
    public double Trend {get; set;}

    [JsonPropertyName("winPercentage")]
    public double WinPercentage {get; set;}

    [JsonPropertyName("rolePercentage")]
    public double RolePercentage {get; set;}

    [JsonPropertyName("pickPercentage")]
    public double PickPercentage {get; set;}

    [JsonPropertyName("banPercentage")]
    public double BanPercentage {get; set;}

    [JsonPropertyName("kda")]
    public double Kda {get; set;}


    public override string ToString()
    {
        return $"Name: {Name}," +
               $"Class: {Class}," +
               $"Role: {Role}," +
               $"Tier: {Tier}," +
               $"Score: {Score}," +
               $"Trend: {Trend}," +
               $"WinPercentage: {WinPercentage}," +
               $"RolePercentage: {RolePercentage}," +
               $"PickPercentage: {PickPercentage}," +
               $"BanPercentage: {BanPercentage}," +
               $"KDA: {Kda}";
    }
}