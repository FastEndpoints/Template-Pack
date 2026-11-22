---
type: Reference
title: Project Overview
description: What the FastEndpoints template pack ships and how the repo is laid out.
tags: [overview, layout]
resource: FastEndpoints.TemplatePack.csproj
---

# Project Overview

## Purpose

`FastEndpoints.TemplatePack` is a `dotnet new` template pack (NuGet `PackageType` `Template`) for scaffolding FastEndpoints projects and feature file sets. The root `.csproj` compiles nothing (`Compile Remove="**\*"`, `IncludeBuildOutput=false`); it only packs `templates/**` as content. Issues are tracked in the main FastEndpoints repo.

## Templates

| Folder | Short name | `sourceName` | Kind |
| --- | --- | --- | --- |
| `templates/project` | `feproj` | `MyProject` | Minimal starter, `Source/` + `Tests/` |
| `templates/aot` | `feaot` | `MyApp` | Native AOT starter; uses FastEndpoints Generator CLI for serializer contexts |
| `templates/integrated` | `feintproj` | `MyProject` | MongoDB (`MongoDB.Entities`), AWS SES, job queues, Docker/container publish; tests live inside `Source/` and are excluded from Release builds |
| `templates/test` | `fetest` | none | xUnit v3 test project meant to be added beside an existing web app |
| `templates/item` | `feat` | `FeatureName` | Feature file set (endpoint, models, mapper, data) with CLI options in `dotnetcli.host.json` |

Except `feat`, each template folder is a real, buildable project (with `global.json` selecting `Microsoft.Testing.Platform`; the starters also carry a `.slnx`). Template engine settings live in `templates/*/.template.config/template.json`.

## Layout

| Path | Contents |
| --- | --- |
| `FastEndpoints.TemplatePack.csproj` | Package metadata, `<Version>`, content include/exclude globs |
| `templates/` | One folder per template (above) |
| `changelog.md` | Release notes body for the current version only |
| `.github/workflows/publish-to-nuget.yml` | Tag-triggered pack, NuGet push, GitHub release |
| `README.md` | User-facing install and usage |
