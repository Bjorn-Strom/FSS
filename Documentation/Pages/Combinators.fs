module Page.Combinators

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let Combinators () =
    let descendantCombinator =
        fss [ Label "Descendant"
              ! (Selector.Tag Fss.Types.Html.P) [ Color.red ] ]

    let childCombinator =
        fss [ Label "Child"
              !> (Selector.Tag Fss.Types.Html.P) [ Color.red ]

               ]

    let directCombinator =
        fss [ Label "Direct"
              !+ (Selector.Tag Fss.Types.Html.P) [ Color.red ] ]

    let adjacentCombinator =
        fss [ Label "Adjacent"
              !~ (Selector.Tag Fss.Types.Html.P) [ Color.red ] ]

    let styles =
        [ Html.div [ prop.className descendantCombinator
                     prop.children [ Html.p "Text in a paragraph and therefore red"
                                     Html.text "Text outside of paragraph"
                                     Html.div [ Html.p "Text in paragraph in div and red" ] ] ]
          Html.div [ prop.className childCombinator
                     prop.children [ Html.p "Text in a paragraph and therefore red"
                                     Html.text "Text outside of paragraph"
                                     Html.div [ Html.p "Text in paragraph in div and not red" ] ] ]
          Html.div [ prop.children [ Html.div [ prop.className directCombinator
                                                prop.children [ Html.p [ Html.text "Text in paragraph in div " ] ] ]
                                     Html.p "Text in a paragraph and after the div with the combinator so is red"
                                     Html.p "Text in a paragraph but not after div with the combinator so is not red" ] ]
          Html.div [ prop.children [ Html.div [ prop.className adjacentCombinator
                                                prop.children [ Html.p [ prop.text "Text in paragraph in div " ] ] ]
                                     Html.p "Text in a paragraph and after the div with the combinator so is red"
                                     Html.p "Text in a paragraph and after the div with the combinator so is red"
                                     Html.div [ Html.p
                                                    "Text in a paragraph inside another div, paragraph is not directly after div with the combinator so is not red" ] ] ]
          Html.div [ prop.fss [ ! (Selector.Id "SomeId") [ BackgroundColor.orangeRed ] ]
                     prop.children [ Html.div [ prop.text "Not orangered"

                                                 ]
                                     Html.div [ prop.id "SomeId"
                                                prop.text "Has the ID and is therefore orangered" ]
                                     Html.div [ prop.text "Not orangered" ] ] ] ]

    Page Pages.Combinators styles

JsInterop.exportDefault Combinators
