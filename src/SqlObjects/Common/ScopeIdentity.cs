namespace SqlObjects.Common;

/// <summary>
/// SCOPE_IDENTITY() function
/// </summary>
public sealed class ScopeIdentity : QueryEnvelope
{
    public ScopeIdentity() : base("SELECT scope_identity() as Id")
    {
    }
}