namespace Fss

open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<AutoOpen>]
module Selector =

    type Selector =
        static member adjacentSibling (html: FssTypes.Html.Html) = sprintf " + %A" (FssTypes.htmlHelpers.htmlToString html)
        static member generalSibling (html: FssTypes.Html.Html) = sprintf " ~ %A" (FssTypes.htmlHelpers.htmlToString html)
        static member child (html: FssTypes.Html.Html) = sprintf " > %A" (FssTypes.htmlHelpers.htmlToString html)
        static member descendant (html: FssTypes.Html.Html) = sprintf " %A" (FssTypes.htmlHelpers.htmlToString html)

    let (!+) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.adjacentSibling(html) ==> (propertyList |> fss) |> FssTypes.CssProperty
    let (!~) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.generalSibling(html) ==> (propertyList  |> fss) |> FssTypes.CssProperty
    let (!>) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.child(html) ==> (propertyList |> fss) |> FssTypes.CssProperty
    let (! ) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.descendant(html) ==> (propertyList |> fss) |> FssTypes.CssProperty
