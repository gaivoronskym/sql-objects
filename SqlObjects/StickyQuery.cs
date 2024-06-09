using SqlObjects.Interfaces;

namespace SqlObjects;

/// <summary>
/// Caches SQL query
/// </summary>
public sealed class StickyQuery(IQuery origin) : IQuery
{
    private readonly bool[] filled = new bool[1];
    private readonly string[] cache = new string[1];
    
    public string Raw()
    {
        if (filled[0])
        {
            return cache[0];
        }

        cache[0] = origin.Raw();
        filled[0] = true;

        return cache[0];
    }
}