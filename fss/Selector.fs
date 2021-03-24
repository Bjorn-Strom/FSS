namespace Fss

open Fable.Core.JsInterop

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<AutoOpen>]
module Selector =

    type Selector =
        static member AdjacentSibling (html: FssTypes.Html.Html) = sprintf " + %A" (FssTypes.htmlHelpers.htmlToString html)
        static member GeneralSibling (html: FssTypes.Html.Html) = sprintf " ~ %A" (FssTypes.htmlHelpers.htmlToString html)
        static member Child (html: FssTypes.Html.Html) = sprintf " > %A" (FssTypes.htmlHelpers.htmlToString html)
        static member Descendant (html: FssTypes.Html.Html) = sprintf " %A" (FssTypes.htmlHelpers.htmlToString html)

    let (!+) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.AdjacentSibling(html) ==> (propertyList |> fss) |> FssTypes.CssProperty
    let (!~) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.GeneralSibling(html) ==> (propertyList  |> fss) |> FssTypes.CssProperty
    let (!>) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.Child(html) ==> (propertyList |> fss) |> FssTypes.CssProperty
    let (! ) (html: FssTypes.Html.Html) (propertyList: FssTypes.CssProperty list) = Selector.Descendant(html) ==> (propertyList |> fss) |> FssTypes.CssProperty
