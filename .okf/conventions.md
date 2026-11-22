---
type: Reference
title: Conventions
description: Rules for editing template content, versions, and template.json symbols.
tags: [conventions]
---

# Conventions

## Versions

- Package versions are inline `PackageReference` versions in each template `.csproj` (no central package management). Keep all `FastEndpoints*` packages on the same version across every template, and keep `templates/aot/Source/MyApp.csproj` `<GeneratorCliVersion>` equal to the `FastEndpoints.Generator` version.
- A target framework bump touches more than `<TargetFramework>`: Rider `.run/*.run.xml` (TFM and publish paths), `dotnet-version` in both GitHub workflows (root and `templates/integrated/.github/workflows/`), and `ContainerBaseImage` in `templates/integrated/Source/MyProject.csproj`. Grep for the old TFM before finishing.
- The pack `<Version>` lives in the root `.csproj`.

## Template content

- Template files are copied verbatim except for `sourceName` and symbol `replaces` tokens. Any identifier or string containing the `sourceName` (`MyProject`, `MyApp`, `FeatureName`) is rewritten in output, so name things deliberately.
- Names the FastEndpoints generators derive from the assembly name cannot use the plain `sourceName` substitution. They are mapped with `generated`/`regex` symbols in `template.json`:
  - `reflectionCacheMethod`: `AddFrom<name with non-alphanumerics removed>`
  - `serializerContextsMethod` (AOT): `AddSerializerContextsFrom<name with non-identifier chars as _>`
  - `projectFile`: `<name>.csproj` references in `.slnx` and `Tests.csproj`
  - `databaseName` (integrated): Mongo-safe `Database:Name` values in appsettings
  Add a symbol like these when new code references a generator-derived or file-derived name.
- Formatting follows Rider defaults already in the files: XML with 4-space indent and `/>` without a preceding space; `template.json` with 2-space indent.

## Sources
- `templates/*/.template.config/template.json`
- `templates/aot/Source/MyApp.csproj`
- `templates/integrated/Source/MyProject.csproj`
