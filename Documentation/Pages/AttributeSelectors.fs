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
            // [title~=""]
            Html.div [
                Html.div [
                    prop.title "heading article foo"
                    prop.fss [
                        MatchAttr.Contains (Attribute.Title, "heading", [
                            FontSize.value(px 18)
                        ])
                    ]
                    prop.text "This element has heading title attribute and has larger font size"
                ]
                Html.div [
                    prop.title "subheading article foo"
                    prop.fss [
                        MatchAttr.Contains (Attribute.Title, "heading", [
                            FontSize.value(px 18)
                        ])
                    ]
                    prop.text "This element has a title but it is not 'heading'"
                ]
            ]
            // [title|=""]
            Html.div [
                Html.div [
                    prop.lang "en-US"
                    prop.fss [
                        MatchAttr.ValueOrContinuation (Attribute.Lang, "en", [
                            Color.blue
                        ])
                    ]
                    prop.text "This element has en-US and is blue"
                ]
                Html.div [
                    prop.lang "GB-en"
                    prop.fss [
                        MatchAttr.Contains (Attribute.Lang, "GB-en", [
                            FontSize.value(px 18)
                        ])
                    ]
                    prop.text "This element has GB-en and is not blue"
                ]
                Html.div [
                    prop.lang "en-GB"
                    prop.fss [
                        MatchAttr.ValueOrContinuation (Attribute.Lang, "en", [
                            Color.blue
                        ])
                    ]
                    prop.text "This element has en-GB and is blue"
                ]
            ]
            // [title^=""]
            Html.div [
                Html.a [
                    prop.fss [
                        PointerEvents.none
                        Cursor.default'
                        MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Href, "http://", [
                            BackgroundColor.red
                        ])
                        MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Href, "https://", [
                            BackgroundColor.green
                        ])
                    ]
                    prop.text "HTTP link is red"
                    prop.href "http://foo"
                ]
                Html.a [
                    prop.fss [
                        PointerEvents.none
                        Cursor.default'
                        MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Href, "http://", [
                            BackgroundColor.red
                        ])
                        MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Href, "https://", [
                            BackgroundColor.green
                        ])
                    ]
                    prop.text "HTTP link is green"
                    prop.href "https://foo"
                ]
            ]
            // [title$=""]
            Html.div [
                Html.a [
                    prop.fss [
                        PointerEvents.none
                        Cursor.default'
                        MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Href, ".pdf", [
                            BackgroundColor.blue
                        ])
                        MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Href, ".txt", [
                            BackgroundColor.green
                        ])
                    ]
                    prop.text ".pdf is blue"
                    prop.href "foo.pdf"
                ]
                Html.a [
                    prop.fss [
                        PointerEvents.none
                        Cursor.default'
                        MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Href, ".pdf", [
                            BackgroundColor.blue
                        ])
                        MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Href, ".txt", [
                            BackgroundColor.green
                        ])
                    ]
                    prop.text ".txt is green"
                    prop.href "foo.txt"
                ]
            ]
            // [title*=""]
            Html.div [
                Html.div [
                    prop.fss [
                        MatchAttr.AtLeastOne (Attribute.Id, "heading", [
                            TextDecorationLine.underline
                            TextDecorationThickness.fromFont
                        ])
                    ]
                    prop.text "Heading"
                    prop.id "heading"
                ]
                Html.div [
                    prop.fss [
                        MatchAttr.AtLeastOne (Attribute.Id, "heading", [
                            TextDecorationLine.underline
                            TextDecorationThickness.fromFont
                        ])
                    ]
                    prop.text "Sub-Heading"
                    prop.id "sub-heading"
                ]
                Html.div [
                    prop.fss [
                        MatchAttr.AtLeastOne (Attribute.Id, "heading", [
                            TextDecorationLine.underline
                            TextDecorationThickness.fromFont
                        ])
                    ]
                    prop.text "Sub-Sub-Heading"
                    prop.id "sub-sub-heading"
                ]
                Html.div [
                    prop.fss [
                        MatchAttr.AtLeastOne (Attribute.Id, "heading", [
                            TextDecorationLine.underline
                            TextDecorationThickness.fromFont
                        ])
                    ]
                    prop.text "Not a heading"
                ]
            ]
        ]

    Page (Pages.FssPage Pages.AttributeSelectors) styles

JsInterop.exportDefault AttributeSelectors
