# Changelog

## Version 3.0.0 - 05.04.2026
### Breaking
- Rewrote CSS generation to use CSS Nesting
  - CSS output now uses the `&` nesting selector instead of repeating the full selector for each nested rule
  - This is a breaking change for anyone parsing or comparing raw CSS output strings
  - CSS class names may differ due to hash changes
- Renamed `Font.Synthesis` DU cases: `Weight` -> `SynthWeight`, `Style` -> `SynthStyle`, `SmallCaps` -> `SynthSmallCaps`
  - Avoids naming conflicts with `Font.Style` and `Font.Weight` types used by the new Font shorthand
- Fss.Giraffe / Fss.Falco: style cache is now private (`ConcurrentDictionary`, thread-safe)
### New Features
- CSS shorthand support for `Border`, `Outline`, `ColumnRule`, `Font`, `Flex`, `TextDecoration`, `ListStyle`, and `Transition`
  - Use F# optional parameters: `Border.value(px 2, Border.Style.Solid, hex "008000")`
  - `Font` shorthand requires `size` and `family`: `Font.value(px 16, "Arial", style = Font.Style.Italic)`
  - `Flex.auto` and `Flex.none` convenience members
  - `Transition.create()` helper for building multi-transition lists
- Shorthand sub-type access via proxy members -- `Border.Style.Solid`, `Outline.Width.Thin`, `Font.Weight.Bold`, `ListStyle.Type.Disc` etc. work without `Fss.Types` qualification
- Scroll-driven animations -- `AnimationTimeline` with `scroll()` and `view()`, `ScrollTimelineName/Axis`, `ViewTimelineName/Axis`, `AnimationRange`/`AnimationRangeStart`/`AnimationRangeEnd`
### Improved
- Major performance improvements in CSS generation
  - **CSS Nesting removed the chunk pass** -- Previously, CSS generation had to split interleaved rules into chunks and repeat the full selector for each group. With CSS Nesting, nested rules use `&` and are rendered in a single pass. This alone was a **4-10x speedup** on .NET with **up to 86% less memory**
  - **StringBuilder rendering** -- Replaced `List.map` + `String.concat` with `StringBuilder`, eliminating N intermediate string allocations per style block
  - **Incremental hashing** -- Classname hash is now computed by feeding rules directly into FNV-1a instead of allocating a concatenated string of all rules first
  - **Single-pass label extraction** -- Replaced separate `tryFind` + `filter` traversals with one pass
  - **No more `sprintf`** -- Replaced `sprintf` formatting with direct `StringBuilder.Append` chains
  - Combined result on .NET: **up to 20x faster, up to 88% less memory** for large stylesheets
  - On JavaScript (Fable): **1.5-1.7x faster** for the same optimizations. The JS improvement is smaller because V8 already heavily optimizes string concatenation internally, so the StringBuilder/incremental hash changes have less relative impact than on .NET where intermediate string allocations are more costly
- Added `ConcurrentDictionary` cache for CSS value stringification
- Added CSS validation via `npm run validate`
- Added `Selector` tag shortcuts (`Selector.div`, `Selector.p`, `Selector.a`, etc.) to reduce verbosity
  - `! (Selector.Tag Fss.Types.Html.Div) [...]` can now be written as `! Selector.div [...]`
  - `Selector.Tag` still works for custom or dynamic tags
### Fixed
- `Media.Course` typo (now `Media.Coarse`)
- Fss.Giraffe / Fss.Falco: thread-unsafe `Dictionary` replaced with `ConcurrentDictionary`
- Fss.Builder: hardcoded `net8.0` target changed to `net10.0`
- Fss.Builder: fixed "occured" typo
### New Properties
- `AccentColor` — controls accent color of form elements (checkboxes, radio buttons, range sliders)
- `ColorScheme` — declares supported color schemes (`light`, `dark`, `light dark`, `only light`, etc.)
- `Gap` / `RowGap` — modern gap properties that work in both Grid and Flexbox (replaces deprecated `grid-gap` / `grid-row-gap`)
- `Translate` / `Rotate` / `Scale` — standalone transform properties, independently animatable
- `Contain` / `ContentVisibility` — CSS containment for rendering performance optimization
- `TextWrap` — controls text wrapping with `balance`, `pretty`, `stable`, `wrap`, `nowrap`
- `revert-layer` — new global CSS keyword added to all properties (pairs with `@layer`)
- `Inset` / `InsetBlock` / `InsetInline` — shorthand for `top`/`right`/`bottom`/`left` and logical variants (`inset-block-start`, `inset-block-end`, `inset-inline-start`, `inset-inline-end`)
- `InlineSize` / `BlockSize` — logical width/height with min/max variants (`min-inline-size`, `max-block-size`, etc.)
- `BorderBlock` / `BorderInline` — logical border properties with full sub-property support (color, style, width, start/end)
- Modern color functions — `oklch()`, `oklab()`, `lch()`, `lab()`, `hwb()`, `color-mix()` with standalone helpers and `ColorClass` members
- Dynamic/small/large viewport units — `dvh`, `dvw`, `svh`, `svw`, `lvh`, `lvw` (fixes mobile browser toolbar sizing)
- Container query units — `cqw`, `cqh`, `cqi`, `cqb` (sizes relative to container)
- Container queries (`@container`) — `Container.query`, `Container.queryNamed` with size features, plus `ContainerType`, `ContainerName` properties
- Cascade layers (`@layer`) — `Layer.layer`, `Layer.anonymous`, `Layer.define`, `createLayerOrder` for controlling CSS cascade specificity ordering
- CSS Scope (`@scope`) — `Scope.scope`, `Scope.scopeTo` (donut scope), `Scope.implicit` for proximity-based style scoping
- Starting style (`@starting-style`) — `StartingStyle.style` for defining entry transition states
- Custom properties (`@property`) — `createProperty` for registering typed CSS custom properties with syntax, inheritance, and initial values
- `:has()`, `:is()`, `:where()` pseudo-classes — type-safe with `Selector list` parameter (e.g. `Has [Selector.Class "foo"]`, `Is [Selector.h1; Selector.h2]`)
- `light-dark()` color function — `Color.lightDark` and standalone `lightDark` helper for color-scheme-aware colors
- `MarginInline` / `MarginBlock` — logical margin shorthands
- `PaddingInline` / `PaddingBlock` — logical padding shorthands
- `ScrollbarWidth` — controls scrollbar width (`auto`, `thin`, `none`)
- `ScrollbarColor` — controls scrollbar thumb and track colors
- `OverscrollBehavior` — shorthand for overscroll behavior (`auto`, `contain`, `none`, two-value syntax)
- `TransitionBehavior` — controls transition behavior (`normal`, `allow-discrete`)

## Version 2.11.0 - 03.05.2024
### Added
- Added data attribute
  - This will allow for styling based on the data-* attribute.

## Fss.Fable, Fss.Feliz, Fss.Giraffe (2.2.1) Fss.Falco(2.3.1) - 23.03.2024
### Fixed
- Fixed issue where `fontFaces` was not generating properly

## Version 2.1.0 - 28.01.2023
### Added
- List support for `grid-template-columns/rows`

## Version 2.0.0 (19.03.2022)

### Breaking Changes
- Rewrote CSS generation
  - Improved the correctness of the produced CSS
  - Affects the auto-generated classnames
  - CSS now has less whitespace and newlines for minification
  - Breaking change for those dependent on specific classname or unminified CSS
- Changed return value of all CSS creation functions in Fss.Core
  - Now returns string * string where the first is class/animation/counter name and second is CSS
  - Only affects direct usage of Fss.Core
- Combinators now require selector type specification
  - First parameter is now Selector: `tag`, `class`, or `id`
  - Can be used for attribute selectors
  - Breaking change: find uses of combinator and wrap html tag in selector
    - `! Html.p []` -> `! (Selector.tag Html.p) []`

### New Features
- Added Attribute selectors
  - [Documentation](https://bjorn-strom.github.io/FSS/#/page/attributeSelectors)
- Added helper functions for simpler media query usage
  - No longer need to specify Fss.Types when building media query
  - [Documentation](https://bjorn-strom.github.io/FSS/#/page/MediaQueries.md)

## Version 1.0.5 - 25.07.2022
### Added
- `display: inline-grid` and `::placeholder` pseudo-element

## Version 1.0.4 - 11.05.2022
### Changed
- Optimized CSS generation for faster results

## Version 1.0.3 - 19.03.2022
### Fixed
- Issues in final CSS ordering

## Version 1.0.0 - 07.02.2022
### Released
- Initial release of the software.
