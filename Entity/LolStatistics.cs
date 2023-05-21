using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using INET410.Utils;

namespace INET410.Entity;

public class LolStatistics
{
        [JsonPropertyName("name")]
        public String Name {get; set;}
        
        [JsonPropertyName("class")]
        public String Class {get; set;}
        
        [JsonPropertyName("role")]
        public Role Role {get; set;}
        
        [JsonPropertyName("tier")]
        public String Tier {get; set;}
        
        [JsonPropertyName("score")]
        public Double Score {get; set;}
        
        [JsonPropertyName("trend")]
        public Double Trend {get; set;}
        
        [JsonPropertyName("winPercentage")]
        public Double WinPercentage {get; set;}
        
        [JsonPropertyName("rolePercentage")]
        public Double RolePercentage {get; set;}
        
        [JsonPropertyName("pickPercentage")]
        public Double PickPercentage {get; set;}
        
        [JsonPropertyName("banPercentage")]
        public Double BanPercentage {get; set;}
        
        [JsonPropertyName("kda")]
        public Double KDA {get; set;}

        public LolStatistics(
                String Name,
                String Class,
                String Role,
                String Tier,
                Double Score,
                Double Trend,
                String WinPercentage,
                String RolePercentage,
                String PickPercentage,
                String BanPercentage,
                Double KDA
        )
        {
                this.Name = Name;
                this.Class = Class;
                this.Role = (Role)Enum.Parse(typeof(Role), Role);
                this.Tier = Tier;
                this.Score = Score;
                this.Trend = Trend;
                this.WinPercentage = Cast.StringToDouble(WinPercentage.Replace("%", ""));
                this.RolePercentage = Cast.StringToDouble(RolePercentage.Replace("%", ""));
                this.PickPercentage = Cast.StringToDouble(PickPercentage.Replace("%", ""));
                this.BanPercentage = Cast.StringToDouble(BanPercentage.Replace("%", ""));
                this.KDA = KDA;        
        }
        
        
        public override string ToString() => $"Name: {Name}," +
                                             $"Class: {Class}," +
                                             $"Role: {Role}," +
                                             $"Tier: {Tier}," +
                                             $"Score: {Score}," +
                                             $"Trend: {Trend}," +
                                             $"WinPercentage: {WinPercentage}," +
                                             $"RolePercentage: {RolePercentage}," +
                                             $"PickPercentage: {PickPercentage}," +
                                             $"BanPercentage: {BanPercentage}," +
                                             $"KDA: {KDA}";
}