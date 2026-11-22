# Agent Instructions

## OKF knowledge set

This repository uses `.okf/` as compact operational memory for AI agents.

OKF v0.1: non-reserved `.md` files need YAML frontmatter with non-empty `type`, `title`, and `description`; `index.md` is a directory listing; only bundle-root `index.md` may have frontmatter (`okf_version`).

Normative OKF use/update gates live in this file. `.okf/index.md` and the trigger list in `.okf/gotchas.md` are reminders. Setup and full re-audits follow a separate procedure (the okf skill, where available).

### Before work

Match OKF depth to blast radius:

- Local/small change: `.okf/index.md` + conventions/gotchas (and workflows if you will pack or verify templates).
- Version/TFM bumps, new or renamed templates, `template.json` symbols, pack globs, or release/CI changes: read the whole set (it is small).

OKF guides, but it does not replace checking source, template files, or manifests for exact behavior.

### During work

Preserve conventions and workflows from OKF. On conflict with source/templates/generated artifacts/manifests: prefer verified current behavior, update OKF, mention the correction.

### OKF content discipline

- OKF is operational memory, not a change log or second documentation site.
- Add facts only when they guide future decisions: boundaries, contracts, commands, non-obvious failure modes, or owner-approved policies. Omit routine implementation details and exhaustive API/test inventories.
- Keep each detailed fact in one topic owner. Elsewhere, use a short summary or link only when needed for navigation.
- Update or replace existing guidance rather than appending another account of the same behavior. Remove superseded material in the same edit.
- Test guidance should identify relevant suites, commands, setup, and isolation requirements, not enumerate assertions.
- Before finishing an OKF edit, check for duplication, stale detail, and unnecessary reading cost. Preserve critical safety, compatibility, persistence, and owner-decision constraints.

### Before finishing

Evaluate OKF when a change hits the update triggers in `.okf/gotchas.md` ("When to update OKF"). Update it only when existing guidance becomes incorrect or incomplete, or the change introduces durable operational knowledge that future agents would otherwise need to rediscover. A trigger requires evaluation, not an automatic addition.

Task is incomplete until OKF is synced or reported unaffected: `OKF unaffected (existing guidance remains accurate and sufficient)`, or `OKF unaffected (non-behavioral edit)` for pure comment/typo/formatting changes.

### General

Subject to project conventions in `.okf/conventions.md` and this file:

- Focused, minimal changes; prefer existing patterns.
- Do not hand-edit generated artifacts listed in gotchas (e.g. `templates/aot/Source/Generated/FastEndpoints/`); regenerate by building the template folder instead.
- If template content or `template.json` changes, verify by packing and scaffolding as described in `.okf/workflows.md`. If not run, state the blocker.
