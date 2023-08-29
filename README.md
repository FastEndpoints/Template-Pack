# FastEndpoints.TemplatePack
Template pack for FastEndpoints to quickly scaffold feature file sets and projects using `dotnet new` command line tool.

## Install
```cs
dotnet new install FastEndpoints.TemplatePack
```

## Scaffold Starter Project
```cs
dotnet new feproj -n MyAwesomeProject
```

## Scaffold xUnit Test Project
```cs
dotnet new fetest
```

## Scaffold Feature File Set
```
dotnet new feat -n MyProject.Comments.Create -m post -r api/comments -o Features/Comments/Create
```
#### Available Options

```
> dotnet new feat --help

FastEndpoints Feature Fileset (C#)
Options:
  -t|--attributes  Whether to use attributes for endpoint configuration
                   bool - Optional
                   Default: false

  -p|--mapper      Whether to use a mapper
                   bool - Optional
                   Default: true

  -v|--validator   Whether to use a validator
                   bool - Optional
                   Default: true

  -m|--method      Endpoint HTTP method
                       GET
                       POST
                       PUT
                       DELETE
                       PATCH
                   Default: GET

  -r|--route       Endpoint path
                   string - Optional
                   Default: api/route/here
```