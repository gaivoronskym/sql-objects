namespace SqlObjects.Interfaces;

public interface IRow : IDictionary<string, object>
{
    int AsInt(string key);
    
    long AsLong(string key);

    string AsString(string key);

    decimal AsDecimal(string key);
    
    bool AsBoolean(string key);

    TEnum AsEnumeration<TEnum>(string key) where TEnum : struct;
}