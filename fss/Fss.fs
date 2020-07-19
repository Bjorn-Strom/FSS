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
        | AnimationNames of string list
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

    let combineWs (list: 'a list) (value: 'a -> string) = combineList list value " "
    let combineComma (list: 'a list) (value: 'a -> string) = combineList list value ", " 


    let rec createPOJO (attributeList: CSSAttribute list) = 
        attributeList
        |> List.map (
            function
                | Label l            -> label           ==> l
                | Color c            -> color           ==> Color.value c
                | BackgroundColor bc -> backgroundColor ==> Color.value bc
                | Hover h            -> hover           ==> createPOJO h
                | FontSize f         -> fontSize        ==> value f

                | Border b        -> border      ==> combineWs b value
                | BorderStyle bss -> borderStyle ==> combineWs bss BorderStyle.value

                | BorderWidth bws      -> borderWidth       ==> combineWs bws value
                | BorderTopWidth bw    -> borderTopWidth    ==> value bw
                | BorderRightWidth bw  -> borderRightWidth  ==> value bw
                | BorderBottomWidth bw -> borderBottomWidth ==> value bw
                | BorderLeftWidth bw   -> borderLeftWidth   ==> value bw
               
                | BorderRadius br            -> borderRadius            ==> combineWs br value
                | BorderTopLeftRadius br     -> borderTopLeftRadius     ==> combineWs br value
                | BorderTopRightRadius br    -> borderTopRightRadius    ==> combineWs br value
                | BorderBottomRightRadius br -> borderBottomRightRadius ==> combineWs br value
                | BorderBottomLeftRadius br  -> borderBottomLeftRadius  ==> combineWs br value

                | BorderColor bc       -> borderColor       ==> combineWs bc Color.value
                | BorderTopColor bc    -> borderTopColor    ==> Color.value bc
                | BorderRightColor bc  -> borderRightColor  ==> Color.value bc
                | BorderBottomColor bc -> borderBottomColor ==> Color.value bc
                | BorderLeftColor bc   -> borderLeftColor   ==> Color.value bc

                | Animation av                -> animation               ==> combineWs av Animation.value
                | AnimationName n             -> animationName           ==> n
                | AnimationNames ns           -> animationName           ==> String.concat ", " ns
                | AnimationDuration d         -> animationDuration       ==> Animation.value d
                | AnimationDurations ds       -> animationDuration       ==> combineComma ds Animation.value
                | AnimationTimingFunction t   -> animationTimingFunction ==> Animation.value t
                | AnimationTimingFunctions ts -> animationTimingFunction ==> combineComma ts Animation.value
                | AnimationDelay d            -> animationDelay          ==> Animation.value d
                | AnimationDelays ds          -> animationDelay          ==> combineComma ds Animation.value
                | AnimationIterationCount i   -> animationIterationCount ==> Animation.value i
                | AnimationIterationCounts is -> animationIterationCount ==> combineComma is Animation.value
                | AnimationDirection d        -> animationDirection      ==> Animation.value d
                | AnimationDirections ds      -> animationDirection      ==> combineComma ds Animation.value
                | AnimationFillMode f         -> animationFillMode       ==> Animation.value f
                | AnimationFillModes fs       -> animationFillMode       ==> combineComma fs Animation.value
                | AnimationPlayState p        -> animationPlayState      ==> Animation.value p
                | AnimationPlayStates ps      -> animationPlayState      ==> combineComma ps Animation.value

        )  |> createObj

    let fss (attributeList: CSSAttribute list) = 
        attributeList |> createPOJO |> css'


