namespace Fss

open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<AutoOpen>]
module Selector =

    type Selector =
        static member AdjacentSibling (html: Types.Html) = sprintf " + %A" (Types.htmlHelpers.htmlToString html)
        static member GeneralSibling (html: Types.Html) = sprintf " ~ %A" (Types.htmlHelpers.htmlToString html)
        static member Child (html: Types.Html) = sprintf " > %A" (Types.htmlHelpers.htmlToString html)
        static member Descendant (html: Types.Html) = sprintf " %A" (Types.htmlHelpers.htmlToString html)

    let (!+) (html: Types.Html) (propertyList: Types.CssProperty list) = Selector.AdjacentSibling(html) ==> (propertyList |> fss) |> Types.CssProperty
    let (!~) (html: Types.Html) (propertyList: Types.CssProperty list) = Selector.GeneralSibling(html) ==> (propertyList  |> fss) |> Types.CssProperty
    let (!>) (html: Types.Html) (propertyList: Types.CssProperty list) = Selector.Child(html) ==> (propertyList |> fss) |> Types.CssProperty
    let (! ) (html: Types.Html) (propertyList: Types.CssProperty list) = Selector.Descendant(html) ==> (propertyList |> fss) |> Types.CssProperty
