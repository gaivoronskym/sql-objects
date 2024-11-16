using SqlObjects.Interfaces;

namespace SqlObjects;

public sealed class Row(IDictionary<string, object> dictionary) : Dictionary<string, object>(dictionary), IRow
{
    public int Int(string key)
    {
        return Convert.ToInt32(this[key]);
    }

    public long Long(string key)
    {
        return Convert.ToInt64(this[key]);
    }

    public string String(string key)
    {
        return Convert.ToString(this[key]) ?? string.Empty;
    }

    public decimal Decimal(string key)
    {
        return Convert.ToDecimal(this[key]);
    }

    public bool Boolean(string key)
    {
        return Convert.ToBoolean(this[key]);
    }

    public DateTime DateTime(string key)
    {
        return Convert.ToDateTime(this[key]);
    }

    public bool HasVal(string key)
    {
        if (!this.ContainsKey(key))
        {
            return false;
        }

        var val = this[key];

        return val is not null;
    }

    public TEnum Enum<TEnum>(string key) where TEnum : struct
    {
        return System.Enum.Parse<TEnum>(String(key));
    }
}