using SqlObjects.Schema;

namespace ElegantSql.Sample.Schema;

public sealed class DboItems(string schema, string alias) : Table(schema, alias, "[Id]", "[Items]"), IDboItems
{
    public DboItems()
        : this("[dbo]", string.Empty)
    {
        
    }
    
    public DboItems(string alias)
        : this("[dbo]", alias)
    {
        
    }

    public string Name()
    {
        return BuildColumn("[Name]");
    }

    public string Cost()
    {
        return BuildColumn("[Cost]");
    }

    public string Description()
    {
        return BuildColumn("[Description]");
    }

    public string Price()
    {
        return BuildColumn("[Price]");
    }
}