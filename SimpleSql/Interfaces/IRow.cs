namespace SimpleSql.Interfaces;

public interface IRow : IDictionary<string, object>
{
    int Int(string key);
    
    long Long(string key);

    string String(string key);

    decimal Decimal(string key);
    
    bool Boolean(string key);

    TEnum Enumeration<TEnum>(string key) where TEnum : struct;
}