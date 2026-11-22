---
type: Playbook
title: Workflows
description: How to pack the templates, verify them end to end, and cut a release.
tags: [build, test]
---

# Workflows

## Build and pack

```bash
dotnet pack FastEndpoints.TemplatePack.csproj -c Release -o <tmp-dir>
```

The pack project itself has no tests. Building inside a template folder (`dotnet build` in `templates/<name>`) checks that folder as a project but does not exercise template substitution.

## Verify templates end to end

Install into an isolated hive so the user's installed templates are untouched:

```bash
dotnet new install <tmp-dir>/FastEndpoints.TemplatePack.<ver>.nupkg --debug:custom-hive <tmp-dir>/hive
dotnet new feproj -n MyAwesomeApp -o <tmp-dir>/out/feproj --debug:custom-hive <tmp-dir>/hive
cd <tmp-dir>/out/feproj && dotnet build && dotnet test
```

- Repeat for `feaot` and `feintproj`. After changing names or symbols, also try names containing `_`, `.` and `-` (known exceptions in [Gotchas](gotchas.md)).
- `feintproj` tests need MongoDB on `localhost:27017` (see [Gotchas](gotchas.md)).
- `fetest` does not build on its own (needs a web app's `Program`); `feat` is an item template scaffolded into an existing project.

## Release

1. Bump `<Version>` in `FastEndpoints.TemplatePack.csproj`.
2. Replace `changelog.md` with this release's notes (it becomes the GitHub release body; it is not cumulative).
3. Push a `v*` tag. `publish-to-nuget.yml` packs from a clean checkout, pushes to NuGet via trusted publishing (`NuGet/login` OIDC exchange for a 1-hour key; needs a nuget.org trusted publishing policy for this repo and workflow file under the package owner, plus the `user` input on the login step set to a nuget.org username, not an email or GitHub login), and creates the GitHub release (skipped for tags containing `beta`).

## Sources
- `.github/workflows/publish-to-nuget.yml`
- `FastEndpoints.TemplatePack.csproj`
