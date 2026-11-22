---
type: Reference
title: Gotchas
description: Non-obvious traps in the template pack and when to update OKF.
tags: [gotcha, maintain]
---

# Gotchas

- **Pack ignores `.gitignore`.** `NoDefaultExcludes` is on (so template dotfiles get packed), and only the `Exclude` list on the `Content` item in the root `.csproj` keeps local artifacts out (`bin`, `obj`, `.idea`, `TestResults`, `*.DotSettings.user`, `dotnet-tools.json` written by the Generator targets' `dotnet tool install --local`, …). When a new local-only artifact shows up under `templates/`, add it there. Check: packed `content/` entries should match `git ls-files templates`.
- **AOT generated code is committed.** `templates/aot/Source/Generated/FastEndpoints/` (including `.fastendpoints-generator-cache`) is output of the Generator CLI, regenerated on build. Don't hand-edit; build the template folder after a FastEndpoints bump to refresh it.
- **Symbol skipped when its value equals its token.** The template engine ignores a `replaces` symbol whose output equals the token, and the shorter `sourceName` replacement wins. Names that strip to exactly the `sourceName` (e.g. `My.Project` for `feproj`/`feintproj`, `My-App` for `feaot`) still produce uncompilable code.
- **`feaot` with dotted names fails to build** (e.g. `My.Cool.App`): the FastEndpoints Generator CLI puts serializer contexts in `My_Cool_App` while the source generators and `Meta.cs` `global using` use `My.Cool.App`. Upstream FastEndpoints bug, not fixable in the pack without workarounds (checked 2026-11-22).
- **Integrated tests and MongoDB.** `templates/integrated/Source/Program.cs` connects without credentials; a commented `DB.InitAsync` line holds a local auth connection string. Swap it only temporarily for local testing and revert before committing. Test runs leave `<name>-TESTING` databases behind.
- **Misleading test failure.** When `feintproj`'s `Sut.SetupAsync` fails (e.g. Mongo unreachable), teardown also throws "Services are only available when using WAF"; the first exception is the real cause.

## When to update OKF

Evaluate OKF (gate in [AGENTS.md](../AGENTS.md)) when a change touches:
- template list, short names, `sourceName`, or `template.json` symbols;
- target framework, FastEndpoints/xUnit/test platform versions, or `GeneratorCliVersion`;
- pack globs or package metadata in the root `.csproj`;
- release, CI, or container publish workflows;
- integrated template infrastructure (MongoDB, SES, Docker, appsettings keys);
- a new trap found while scaffolding or testing.

## Sources
- `FastEndpoints.TemplatePack.csproj`
- `templates/integrated/Source/Program.cs`
- `templates/integrated/Source/Features/Members/SignUp/Tests/Sut.cs`
