using System.Text;
using SimpleSql.Interfaces;

namespace SimpleSql.Schema;

public abstract class Table(string schema, string alias, string id, string tableName) : ITable
{
    public string Id()
    {
        return BuildColumn(id);
    }

    public string TableName()
    {
        return BuildTable();
    }

    protected virtual string BuildTable()
    {
        var builder = new StringBuilder();

        if (!string.IsNullOrEmpty(schema))
        {
            builder.Append(schema)
                .Append(".");
        }

        builder.Append(tableName);

        if (!string.IsNullOrEmpty(alias))
        {
            builder.Append(" ")
                .Append(alias);
        }

        return builder.ToString();
    }

    protected virtual string BuildColumn(string name)
    {
        var builder = new StringBuilder();

        if (!string.IsNullOrEmpty(alias))
        {
            builder.Append(alias)
                .Append(".");
        }
        
        builder.Append(name);
        
        return builder.ToString();
    }
}