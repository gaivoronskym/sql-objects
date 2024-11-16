namespace SqlObjects.Interfaces;

public interface IRow : IDictionary<string, object>
{
    int Int(string key);
    
    long Long(string key);

    string String(string key);

    decimal Decimal(string key);
    
    bool Boolean(string key);

    DateTime DateTime(string key);

    bool HasVal(string key);

    TEnum Enum<TEnum>(string key) where TEnum : struct;
}