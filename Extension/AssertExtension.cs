namespace INET410.Extension;

public static class AssertExtensions
{
    public static void Every<T>(IEnumerable<T> collection, Func<T, bool> condition, string message = null)
    {
        foreach (var item in collection)
        {
            if (!condition(item))
            {
                string itemString = item != null ? item.ToString() : "null";
                string assertionMessage = message != null ? $"{message} - Item: {itemString}" : $"Condition failed for item: {itemString}";
                Assert.Fail(assertionMessage);
            }
        }
    }
}
