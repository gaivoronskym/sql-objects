using System.Collections;
using System.Data;
using System.Windows.Input;
using SqlObjects.Interfaces;
using Yaapii.Atoms;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Func;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Map;
using Yaapii.Atoms.Scalar;
using Yaapii.Atoms.Text;

namespace SqlObjects;

public sealed class ColumnsFromReader : IEnumerable<string>
{
    private readonly IDataReader reader;

    public ColumnsFromReader(IDataReader reader)
    {
        this.reader = reader;
    }

    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < this.reader.FieldCount; i++)
        {
            yield return this.reader.GetName(i);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public sealed class ValuesFromReader : IEnumerable<string>
{
    private readonly IDataReader reader;

    public ValuesFromReader(IDataReader reader)
    {
        this.reader = reader;
    }

    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < this.reader.FieldCount; i++)
        {
            yield return this.reader.GetValue(i).ToString();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public sealed class ManyKvp<T> : IEnumerable<IKvp<T>>
{
    private readonly IList<string> keys;
    private readonly IList<T> values;

    public ManyKvp(IEnumerable<string> keys, IEnumerable<T> values)
        : this(
            new ListOf<string>(keys),
            new ListOf<T>(values)
        )
    {
    }

    public ManyKvp(IList<string> keys, IList<T> values)
    {
        this.keys = keys;
        this.values = values;
    }

    public IEnumerator<IKvp<T>> GetEnumerator()
    {
        if (this.keys.Count != this.values.Count)
        {
            throw new Exception();
        }

        for (int i = 0; i < this.keys.Count; i++)
        {
            yield return new KvpOf<T>(new TextOf(this.keys[i]), this.values[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public sealed class MappedFromReader : IEnumerable<IRow>
{
    private readonly IDataReader reader;

    public MappedFromReader(IDataReader reader)
    {
        this.reader = reader;
    }

    public IEnumerator<IRow> GetEnumerator()
    {
        var columns = new Sticky<string>(
            new ColumnsFromReader(
                this.reader
            )
        );

        while (this.reader.Read())
        {
            yield return new Row(
                new MapOf<string>(
                    new ManyKvp<string>(
                        columns,
                        new ValuesFromReader(
                            this.reader
                        )
                    ),
                    false
                )
            );
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public abstract class FetchEnvelope : IFetch
{
    private readonly FuncOf<IQuery, IDbCommand> command;

    protected FetchEnvelope(Func<IQuery, IDbCommand> command)
    {
        this.command = new FuncOf<IQuery, IDbCommand>(command);
    }

    public IList<IRow> Rows(IQuery query)
    {
        var reader = this.command.Invoke(query).ExecuteReader();
        var rows = new MappedFromReader(reader).ToList();
        reader.Close();
        return new ListOf<IRow>(rows);
    }
}