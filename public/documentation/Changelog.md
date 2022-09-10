## Changelog

### 2.0.0 - 05.09.2022
- CSS generation has been rewritten
  - This was mainly done to improve the correctness of the produced CSS.
  - This affects the auto-generated classnames
  - The created CSS now has less whitespace and newlines in a first attempt at minification.
  - If your were dependent on a specific classname or the generated CSS not being minified then that will break for you.
- All CSS creation functions in `Fss.Core` have had their return value changed
  - They now return `string * string` where the first is the class/animation/counter name and the second being the CSS.
  - Should only affect you if you use `Fss.Core` directly instead of any of the helper libraries.
- Added Attribute selectors.
  - Go [here](https://bjorn-strom.github.io/FSS/#/page/attributeSelectors) to see how they work.
- Combinators must now specify selector type.
  - Combinators first parameter is now a `Selector` which can be `tag`, `class`, or `id`
  - These selectors can also be used for attribute selectors
  - This complies with the CSS spec, but is a breaking change.
  - Find your uses of a combinator and wrap your html tag in a selector.
    - `! Html.p []` -> `! (Selector.tag Html.p) []`
- Helper functions have been added to make using media queries simpler.
  - You do not have to specify `Fss.Types` when building your media query any longer
  - This is not a breaking change, your media queries should work as before.
  - Go [here](https://bjorn-strom.github.io/FSS/#/page/MediaQueries.md) to see how they look now.
- Documentation has gotten a face lift.

#### Breaking changes TLDR:
- CSS is now more minified and auto-generated classnames work a little different.
  - If you were dependent on the CSS or specific classnames you might have breaking changes.
- Selector tags on combinators are now required
  - `! Html.p []` -> `! (Selector.tag Html.p) []`
- `Fss.Core` return values changed to `string * string`
  - Only affects you if you use `Fss.Core` directly.
