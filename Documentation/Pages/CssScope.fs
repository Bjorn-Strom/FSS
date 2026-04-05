module Page.CssScope

open Fss
open Feliz
open Fable.Core

[<ReactComponent>]
let CssScope () =
    let scopedToCard =
        fss [
            Scope.scope ".demo-card" [
                Color.hex "#6c5ce7"
                FontWeight.bold
            ]
        ]

    let donutScope =
        fss [
            Scope.scopeTo ".demo-outer" ".demo-inner" [
                Color.hex "#e17055"
                FontStyle.italic
            ]
        ]

    let cardStyle =
        fss [
            Padding.value (px 16)
            BorderWidth.value (px 1)
            BorderStyle.solid
            BorderColor.hex "#ddd"
            BorderRadius.value (px 8)
            BackgroundColor.white
        ]

    let innerStyle =
        fss [
            Padding.value (px 12)
            BackgroundColor.hex "#f8f8f8"
            BorderRadius.value (px 4)
            MarginTop.value (px 8)
        ]

    let wrapper =
        fss [
            Display.flex
            FlexDirection.column
            Gap.value (px 16)
        ]

    let label =
        fss [
            FontFamily.value "monospace"
            FontSize.value (px 13)
            Color.gray
        ]

    let styles =
        [ Html.div [
            prop.className wrapper
            prop.children [
                Html.span [ prop.className label; prop.text "Scope limits where styles apply. The purple bold text only appears inside .demo-card." ]
                Html.div [
                    prop.className scopedToCard
                    prop.children [
                        Html.p [ prop.text "This text is outside .demo-card (not affected)" ]
                        Html.div [
                            prop.className [cardStyle; "demo-card"]
                            prop.children [
                                Html.p [ prop.text "This text is inside .demo-card (purple and bold)" ]
                            ]
                        ]
                    ]
                ]
                Html.span [ prop.className label; prop.text "Donut scope: styles apply inside .demo-outer but stop at .demo-inner." ]
                Html.div [
                    prop.className donutScope
                    prop.children [
                        Html.div [
                            prop.className [cardStyle; "demo-outer"]
                            prop.children [
                                Html.p [ prop.text "This is in .demo-outer (orange italic)" ]
                                Html.div [
                                    prop.className [innerStyle; "demo-inner"]
                                    prop.children [
                                        Html.p [ prop.text "This is in .demo-inner (not affected by scope)" ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
          ] ]

    Page (Pages.FssPage Pages.CssScope) styles

JsInterop.exportDefault CssScope
