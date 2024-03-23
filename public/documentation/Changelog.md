# Changelog

## Version 2.0.1 - 28.01.2023
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

#t Version 1.0.0 - 07.02.2022
### Released
- Initial release of the software.