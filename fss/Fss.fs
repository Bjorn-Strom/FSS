namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Color
open Units
open Fonts
open Border
open BorderStyle
open BorderWidth
open BorderRadius
open BorderColor
open Utilities.Types
open Animation

module Main =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let private css' x = css(x) 

    let value (v: ICss): string =
        match v with
            | :? CssColor as c -> Color.value c
            | :? Unit as c -> Units.value c
            | :? FontSize as f -> Fonts.value f
            | :? BorderStyle as b -> BorderStyle.value b
            | :? BorderWidth as b -> BorderWidth.value b
            | _ -> "Unknown CSS"

    type CSSAttribute =
        | Label of string
        | Color of CssColor
        | BackgroundColor of CssColor
        | Hover of CSSAttribute list
        | FontSize of ICss

        | Border of ICss list
        | BorderStyle of BorderStyle list
        | BorderWidth of ICss list
        | BorderTopWidth of ICss
        | BorderRightWidth of ICss
        | BorderBottomWidth of ICss
        | BorderLeftWidth of ICss

        | BorderRadius of ICss list
        | BorderTopLeftRadius of ICss list
        | BorderTopRightRadius of ICss list
        | BorderBottomRightRadius of ICss list
        | BorderBottomLeftRadius of ICss list

        | BorderColor of CssColor list
        | BorderTopColor of CssColor
        | BorderRightColor of CssColor
        | BorderBottomColor of CssColor
        | BorderLeftColor of CssColor

        | Animation of IAnimation list
        | AnimationName of string
        | AnimationDuration of Time
        | AnimationDurations of Time list
        | AnimationTimingFunction of Timing
        | AnimationTimingFunctions of Timing list
        | AnimationDelay of Time
        | AnimationDelays of Time list
        | AnimationIterationCount of IterationCount
        | AnimationIterationCounts of IterationCount list
        | AnimationDirection of Direction
        | AnimationDirections of Direction list
        | AnimationFillMode of FillMode
        | AnimationFillModes of FillMode list
        | AnimationPlayState of PlayState
        | AnimationPlayStates of PlayState list


    let label = "label"
    let hover = ":hover"

    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
                | Label l -> label ==> l
                | Color c -> color ==> Color.value c
                | BackgroundColor bc -> backgroundColor ==> Color.value bc
                | Hover h -> hover ==> createPOJO h
                | FontSize f -> fontSize ==> value f

                | Border b -> border ==> evalCssListToString b value
                | BorderStyle bss -> borderStyle ==> evalCssListToString bss BorderStyle.value

                | BorderWidth bws -> borderWidth ==> evalCssListToString bws value
                | BorderTopWidth bw -> borderTopWidth ==> value bw
                | BorderRightWidth bw -> borderRightWidth ==> value bw
                | BorderBottomWidth bw -> borderBottomWidth ==> value bw
                | BorderLeftWidth bw -> borderLeftWidth ==> value bw
               
                | BorderRadius br -> borderRadius ==> evalCssListToString br value
                | BorderTopLeftRadius br -> borderTopLeftRadius ==> evalCssListToString br value
                | BorderTopRightRadius br -> borderTopRightRadius ==> evalCssListToString br value
                | BorderBottomRightRadius br -> borderBottomRightRadius ==> evalCssListToString br value
                | BorderBottomLeftRadius br -> borderBottomLeftRadius ==> evalCssListToString br value

                | BorderColor bc -> borderColor ==> evalCssListToString bc Color.value
                | BorderTopColor bc -> borderTopColor ==> Color.value bc
                | BorderRightColor bc -> borderRightColor ==> Color.value bc
                | BorderBottomColor bc -> borderBottomColor ==> Color.value bc
                | BorderLeftColor bc -> borderLeftColor ==> Color.value bc

                | Animation av -> animation ==> evalCssListToString av Animation.value
                | AnimationName n -> animatioName ==> n
                | AnimationDuration d -> animationDuration ==> Animation.value
                | AnimationDurations ds -> animationDuration ==> evalCssListToString ds Animation.value
                | AnimationTimingFunction t ->  animationTimingFunction ==> Animation.value Timing
                | AnimationTimingFunctions ts -> animationTimingFunction ==> evalCssListToString ts Animation.value
                | AnimationDelay d -> animationDelay ==> Animation.value d
                | AnimationDelays ds -> animationDelay ==> evalCssListToString ds Animation.value
                | AnimationIterationCount i -> animationiterationCount ==> Animation.value i
                | AnimationIterationCounts of IterationCount list
                | AnimationDirection of Direction
                | AnimationDirections of Direction list
                | AnimationFillMode of FillMode
                | AnimationFillModes of FillMode list
                | AnimationPlayState of PlayState
                | AnimationPlayStates of PlayState list

        )  |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'


