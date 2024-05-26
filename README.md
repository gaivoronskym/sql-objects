# SQL Objects(in development)

SQL Objects is a powerful SQL query builder written in C#.

#### Select from table

```c#
new Select(
    "[Products]",
    new Columns(
        "[Id]",
        "[Name]",
        "[Cost]"
    )
)
```

```c#
new Select(
    "[Products]",
    new Columns(
        "[Id]",
        "[Name]",
        "[Cost]"
    ),
    new Queries(
        new Where(
            new ExpressionOf("[Id]", 99)
        )
    )
)
```

#### Insert into

```c#
new Insert(
    "[Products]",
    new RecordsOf(
        new SqlParamsOf(
            new SqlParam("[Name]", "Computer Mouse"),
            new SqlParam("[Cost]", 99.99m)
        )
    )
)
```

#### Update

```c#
new Update(
    "[Products]",
    new SqlParamsOf(
        new SqlParam("[Cost]", 109.99m)
    )
)
```

#### Delete

```c#
new Delete(
    "[Products]",
    new Where(
        new ExpressionOf("[Id]", 99)
    )
)
```

#### Select with joins

```c#
new Select(
    "[Products]",
    new Columns(
        new StringsOf(
            "[Products].[Id]",
            "[Products].[Name]",
            "[Products].[Cost]"
        ),
        new SumOf("[Inventories].[Quantity]", "[Quantity]")
    ),
    new Queries(
        new LeftJoin("[Inventories]", "[Inventories].[ProductId]", "[Products].[Id]"),
        new GroupBy(
            "[Products].[Id]",
            "[Products].[Name]",
            "[Products].[Cost]"
        )
    )
)
```

