using System.Linq.Expressions;
using INET410.Utils;
using Newtonsoft.Json;

namespace INET410.Request;

public class BasicsRequest
{
    public static void CheckCondition(double? isHigherThan, double? isLowerThan)
    {
        if(isHigherThan.HasValue && isLowerThan.HasValue && isHigherThan > isLowerThan)
            throw new Exception($"The higher value {isHigherThan} cannot be greater than the lower value {isLowerThan}.");
    }

    public static List<T> DeserializeJson<T>(string path)
    {
        var jsonContent = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<T>>(jsonContent);
    }

    public static void OrderListByProperty<T>(ref List<T> listToOrder, SortOrder sortOrder, string sortProperty)
    {
        var parameter = Expression.Parameter(typeof(T), "stat");
        var property = Expression.Property(parameter, sortProperty);
        var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

        var sortedList = sortOrder == SortOrder.ASC
            ? listToOrder.OrderBy(lambda.Compile())
            : listToOrder.OrderByDescending(lambda.Compile());

        listToOrder = sortedList.ToList();
    }
}