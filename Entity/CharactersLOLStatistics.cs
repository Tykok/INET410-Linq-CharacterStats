namespace INET410;

public class OverwatchStatistics
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

        public override string ToString()
        {
                return base.ToString();
        }
}