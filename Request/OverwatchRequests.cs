using INET410.Entity;

namespace INET410.Request;

public class OverwatchRequests
{
    
    private static string path = "Data/overwatchs2_character_stats.csv";
    public static List<Overwatch2Statistics> GetAll()
    {
        var requestResult = File.ReadAllLines(path)
            .Skip(1)
            .Select(Overwatch2Statistics.ParseRow);
        return requestResult.ToList();
    }
}