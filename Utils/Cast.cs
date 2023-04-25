using System.Globalization;

namespace INET410.Utils;

public class Cast
{
    public static Double StringToDouble(string value)
    {
        return Convert.ToDouble(value.Replace("\"", ""), CultureInfo.InvariantCulture);
    }
    
    public static Int32 StringToInt(string value)
    {
        return Convert.ToInt32(value.Replace("\"", ""));
    }
}