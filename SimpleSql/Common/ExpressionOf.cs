﻿using SimpleSql.Interfaces;
using SimpleSql.Types;
using Yaapii.Atoms.Text;

namespace SimpleSql.Common;

/// <summary>
/// SQL boolean expression
/// </summary>
/// <param name="first">first expression</param>
/// <param name="operation">boolean operation</param>
/// <param name="second">second expression</param>
public sealed class ExpressionOf(IQuery first, string operation, IQuery second) : IQuery
{
    public ExpressionOf(IQuery first, IQuery value)
        : this(first, "=", value)
    {

    }

    public ExpressionOf(string field, string operation, IQuery second)
        : this(new RawSql(field), operation, second)
    {
        
    }
    
    public ExpressionOf(string field, IQuery value)
        : this(new RawSql(field), "=", value)
    {

    }

    public ExpressionOf(string field, long value)
        : this(field, new SqlBigintOf(value))
    {
        
    }
    
    public ExpressionOf(string field, int value)
        : this(field, new SqlIntOf(value))
    {
        
    }
    
    public ExpressionOf(string field, string value)
        : this(field, new SqlStringOf(value))
    {
        
    }
    
    public ExpressionOf(string field, decimal value)
        : this(field, new SqlDecimalOf(value))
    {
        
    }
    
    public ExpressionOf(string field, bool value)
        : this(field, new SqlBoolOf(value))
    {
        
    }
    
    public ExpressionOf(string field, string operation, long value)
        : this(field, operation, new SqlBigintOf(value))
    {
        
    }
    
    public ExpressionOf(string field, string operation, int value)
        : this(field, operation, new SqlIntOf(value))
    {
        
    }
    
    public ExpressionOf(string field, string operation, decimal value)
        : this(field, operation, new SqlDecimalOf(value))
    {
        
    }
    
    public ExpressionOf(string field, string operation, string value)
        : this(field, operation, new SqlStringOf(value))
    {
        
    }
    
    public ExpressionOf(string field, string operation, bool value)
        : this(field, operation, new SqlBoolOf(value))
    {
        
    }
    
    public ExpressionOf(IQuery first, string operation, long value)
        : this(first, operation, new SqlBigintOf(value))
    {
        
    }
    
    public ExpressionOf(IQuery first, string operation, int value)
        : this(first, operation, new SqlIntOf(value))
    {
        
    }
    
    public ExpressionOf(IQuery first, string operation, decimal value)
        : this(first, operation, new SqlDecimalOf(value))
    {
        
    }
    
    public ExpressionOf(IQuery first, string operation, string value)
        : this(first, operation, new SqlStringOf(value))
    {
        
    }
    
    public ExpressionOf(IQuery first, string operation, bool value)
        : this(first, operation, new SqlBoolOf(value))
    {
        
    }

    public string Raw()
    {
        return new Formatted(
            "{0} {1} {2}",
            true,
            new TextOf(first.Raw()),
            new TextOf(operation),
            new TextOf(second.Raw())
        ).AsString();
    }
}
