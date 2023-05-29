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
        public Double Kda {get; set;}

        public LolStatistics(
                String name,
                String classe,
                String role,
                String tier,
                Double score,
                Double trend,
                String winPercentage,
                String rolePercentage,
                String pickPercentage,
                String banPercentage,
                Double kda
        )
        {
                this.Name = name;
                this.Class = classe;
                this.Role = (Role)Enum.Parse(typeof(Role), role);
                this.Tier = tier;
                this.Score = score;
                this.Trend = trend;
                this.WinPercentage = Cast.StringToDouble(winPercentage.Replace("%", ""));
                this.RolePercentage = Cast.StringToDouble(rolePercentage.Replace("%", ""));
                this.PickPercentage = Cast.StringToDouble(pickPercentage.Replace("%", ""));
                this.BanPercentage = Cast.StringToDouble(banPercentage.Replace("%", ""));
                this.Kda = kda;        
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
                                             $"KDA: {Kda}";
}