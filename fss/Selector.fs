namespace Fss

open Fable.Core.JsInterop

open FssTypes

// https://developer.mozilla.org/en-US/docs/Web/CSS/Descendant_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Child_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/General_sibling_combinator
// https://developer.mozilla.org/en-US/docs/Web/CSS/Adjacent_sibling_combinator
[<AutoOpen>]
module Selector =
    open Html

    type Selector =
        static member AdjacentSibling (html: Html) = sprintf " + %A" (value html)
        static member GeneralSibling (html: Html) = sprintf " ~ %A" (value html)
        static member Child (html: Html) = sprintf " > %A" (value html)
        static member Descendant (html: Html) = sprintf " %A" (value html)

    let (!+) (html: Html.Html) (propertyList: CssProperty list) = Selector.AdjacentSibling(html) ==> (propertyList |> fss) |> CssProperty
    let (!~) (html: Html.Html) (propertyList: CssProperty list) = Selector.GeneralSibling(html) ==> (propertyList  |> fss) |> CssProperty
    let (!>) (html: Html.Html) (propertyList: CssProperty list) = Selector.Child(html) ==> (propertyList |> fss) |> CssProperty
    let (! ) (html: Html.Html) (propertyList: CssProperty list) = Selector.Descendant(html) ==> (propertyList |> fss) |> CssProperty
