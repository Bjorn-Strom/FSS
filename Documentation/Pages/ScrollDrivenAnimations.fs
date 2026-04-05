module Page.ScrollDrivenAnimations

open Fss
open Fss.Types
open Feliz
open Fable.Core

[<ReactComponent>]
let ScrollDrivenAnimations () =
    let fadeSlideIn =
        keyframes [
            frame 0 [ Opacity.value 0.0; Transform.value [ Transform.translateY(px 50); Transform.scale(0.9) ] ]
            frame 100 [ Opacity.value 1.0; Transform.value [ Transform.translateY(px 0); Transform.scale(1.0) ] ]
        ]

    let growWidth =
        keyframes [
            frame 0 [ Width.value (pct 0) ]
            frame 100 [ Width.value (pct 100) ]
        ]

    let outerStyle =
        fss [
            Display.flex
            FlexDirection.column
            Gap.value (px 16)
        ]

    let scrollContainer =
        fss [
            Height.value (px 500)
            OverflowY.auto
            BorderWidth.value (px 2)
            BorderStyle.solid
            BorderColor.hex "#ccc"
            BorderRadius.value (px 8)
            Position.relative
            BackgroundColor.hex "#f0f0f0"
        ]

    let progressBar =
        fss [
            Position.sticky
            Top.value (px 0)
            Height.value (px 6)
            BackgroundColor.hex "#6c5ce7"
            AnimationName.value growWidth
            AnimationTimingFunction.linear
            AnimationFillMode.forwards
            AnimationTimeline.scroll()
            ZIndex.value 1
        ]

    let card =
        fss [
            Padding.value (px 32)
            Margin.value (px 16)
            BackgroundColor.hex "#2d3436"
            Color.white
            BorderRadius.value (px 12)
            FontSize.value (px 18)
            BoxShadow.value (px 0, px 4, px 12, Fss.Types.Color.Rgba(0, 0, 0, 0.2))
            AnimationName.value fadeSlideIn
            AnimationTimingFunction.linear
            AnimationFillMode.both
            AnimationTimeline.view()
            AnimationRange.value ScrollTimeline.Entry
        ]

    let spacer =
        fss [
            Height.value (px 300)
        ]

    let label =
        fss [
            FontFamily.value "monospace"
            FontSize.value (px 13)
            Color.gray
        ]

    let styles =
        [ Html.div [
            prop.className outerStyle
            prop.children [
                Html.span [ prop.className label; prop.text "Scroll inside this box. The purple bar tracks scroll progress. Cards fade in as they enter view." ]
                Html.div [
                    prop.className scrollContainer
                    prop.children [
                        Html.div [ prop.className progressBar ]
                        Html.div [ prop.className spacer ]
                        Html.div [ prop.className card; prop.text "This card fades in as you scroll to it." ]
                        Html.div [ prop.className spacer ]
                        Html.div [ prop.className card; prop.text "So does this one. Each card animates independently." ]
                        Html.div [ prop.className spacer ]
                        Html.div [ prop.className card; prop.text "The animation is driven entirely by scroll position." ]
                        Html.div [ prop.className spacer ]
                        Html.div [ prop.className card; prop.text "No JavaScript. No timers. Pure CSS." ]
                        Html.div [ prop.className spacer ]
                        Html.div [ prop.className card; prop.text "Scroll back up and the animations reverse." ]
                        Html.div [ prop.className spacer ]
                    ]
                ]
            ]
          ] ]

    Page (Pages.FssPage Pages.ScrollDrivenAnimations) styles

JsInterop.exportDefault ScrollDrivenAnimations
