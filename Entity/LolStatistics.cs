namespace INET410.Entity;

public class LolStatistics
{
        public String Name {get;}
        public String Class {get;}
        public String Role {get;}
        public String Tier {get;}
        public Double Score {get;}
        public Double Trend {get;}
        public String WinPercentage {get;}
        public String RolPercentage {get;}
        public String PicPercentage {get;}
        public String BanPercentage {get;}
        public Double KDA {get;}

        public LolStatistics(
                String Name,
                String Class,
                String Role,
                String Tier,
                Double Score,
                Double Trend,
                String WinPercentage,
                String RolPercentage,
                String PicPercentage,
                String BanPercentage,
                Double KDA
        )
        {
                this.Name = Name;
                this.Class = Class;
                this.Role = Role;
                this.Tier = Tier;
                this.Score = Score;
                this.Trend = Trend;
                this.WinPercentage = WinPercentage;
                this.RolPercentage = RolPercentage;
                this.PicPercentage = PicPercentage;
                this.BanPercentage = BanPercentage;
                this.KDA = KDA;        
        }
        
        
        public override string ToString()
        {
                return base.ToString();
        }
}