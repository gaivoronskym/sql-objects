# SQL Objects(in development)

SQL Objects is a powerful SQL query builder written in C#.

#### Select from table

```c#
new Select(
    new Queries(
        new Top(1),
        new Columns(
            new Strings(
                "[Id]",
                "[Name]"
            )
        ),
        new From("[Products]")
    )
)
```

```c#
new Select(
    "[Products]",
    new ListOf<string>(
        "[Id]",
        "[Name]",
        "[Description]",
        "[Cost]",
        "[Price]"
    ),
    new Where(
        new Expression(
            "[Id]",
            5
        )
    )
)
```

#### Insert into

```c#
new Insert(
    "[Products]",
    new Queries(
        new Records(
            new Record(
                new SqlParam(
                    "[Name]", "Computer mouse"
                ),
                new SqlParam(
                    "[Cost]", 1000.0m
                )
            )
        ),
        new ScopeIdentity()
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
    "[Products] _product",
    new Queries(
        new RawSql("_product.[Id]"),
        new RawSql("_product.[Name]"),
        new Sum("_inventory.[Quantity]", "[Quantity]")
    ),
    new LeftJoin("[Inventory] _inventory", "_product.[Id]", "_inventory.[ProductId]"),
    new GroupBy("_product.[Id], _product.[Name]")
)
```

