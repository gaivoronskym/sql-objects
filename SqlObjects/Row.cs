using SqlObjects.Interfaces;

namespace SqlObjects;

public sealed class Row(IDictionary<string, object> dictionary) : Dictionary<string, object>(dictionary), IRow
{
    public int AsInt(string key)
    {
        return Convert.ToInt32(this[key]);
    }

    public long AsLong(string key)
    {
        return Convert.ToInt64(this[key]);
    }

    public string AsString(string key)
    {
        return Convert.ToString(this[key]) ?? string.Empty;
    }

    public decimal AsDecimal(string key)
    {
        return Convert.ToDecimal(this[key]);
    }

    public bool AsBoolean(string key)
    {
        return Convert.ToBoolean(this[key]);
    }

    public TEnum AsEnumeration<TEnum>(string key) where TEnum : struct
    {
        return Enum.Parse<TEnum>(AsString(key));
    }
}