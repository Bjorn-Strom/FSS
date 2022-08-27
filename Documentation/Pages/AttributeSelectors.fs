module Page.AttributeSelectors

open Feliz
open Fable.Core
open Fss
open Fss.Types

[<ReactComponent>]
let AttributeSelectors () =
    let styles =
        [
            // [title]
            Html.div [
                Html.div [
                    prop.title "Some title"
                    prop.fss [
                        Attr.Has (Attribute.Title, [
                            BackgroundColor.red
                        ])
                    ]
                    prop.text "This element has a title attribute and is red"
                ]
                Html.div [
                    prop.fss [
                        Attr.Has (Attribute.Title, [
                            BackgroundColor.red
                        ])
                    ]
                    prop.text "This element has the same styling but no title attribute"
                ]
            ]
            // [title=""]
            Html.div [
                Html.div [
                    prop.title "heading"
                    prop.fss [
                        MatchAttr.Exactly (Attribute.Title, "heading", [
                            TextDecorationLine.underline
                        ])
                    ]
                    prop.text "This element has heading title attribute and has underline"
                ]
                Html.div [
                    prop.title "subheading"
                    prop.fss [
                        MatchAttr.Exactly (Attribute.Title, "heading", [
                            TextDecorationLine.underline
                        ])
                    ]
                    prop.text "This element has a title but it is not 'heading'"
                ]
            ]
        ]

    Page Pages.AttributeSelectors styles

JsInterop.exportDefault AttributeSelectors
