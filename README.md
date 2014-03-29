#DacSmash

For when you just want to deploy that damn database project via code!


e.g.

```

    const string connectionString = @"My Connection String";
    const string dacPacFile = @"Path to my dacpac files";
    const string targetDatabase = "Destination Database";

    var deploy = new Smasher(connectionString, dacPacFile, targetDatabase, new Dictionary<string, string>());
    deploy.Smash();

```


###Notes

- [Requires SQL Server Data Tools][DataTools]
- [SQL Server DacPackage][DacPackage]


C:\Program Files (x86)\Microsoft SQL Server\110\DAC\bin


Copyright 2013 DacSmash Contributors - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).

[DacPackage]: http://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dac.dacpackage.aspx
[DataTools]: http://msdn.microsoft.com/en-au/data/tools.aspx