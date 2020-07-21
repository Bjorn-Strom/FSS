namespace Fss

open Fable.Core
open Fable.Core.JsInterop
open Browser

open Color
open Units.Size
open Units.Angle
open Fonts
open Border
open BorderStyle
open BorderWidth
open BorderRadius
open BorderColor
open Utilities.Types
open Animation
open Transform
open Transition

module Css = 
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x) 

    let value (v: ICSSProperty): string =
        match v with
            | :? CssColor as c -> Color.value c
            | :? Size as c -> Units.Size.value c
            | :? Angle as a -> Units.Angle.value a
            | :? FontSize as f -> Fonts.value f
            | :? BorderStyle as b -> BorderStyle.value b
            | :? BorderWidth as b -> BorderWidth.value b
            | _ -> "Unknown CSS"

    type CSSProperty =
        | Label of string
        | Color of CssColor
        | BackgroundColor of CssColor
        | Hover of CSSProperty list
        | FontSize of ICSSProperty

        | Border of ICSSProperty list
        | BorderStyle of BorderStyle list
        | BorderWidth of ICSSProperty list
        | BorderTopWidth of ICSSProperty
        | BorderRightWidth of ICSSProperty
        | BorderBottomWidth of ICSSProperty
        | BorderLeftWidth of ICSSProperty

        | BorderRadius of ICSSProperty list
        | BorderTopLeftRadius of ICSSProperty list
        | BorderTopRightRadius of ICSSProperty list
        | BorderBottomRightRadius of ICSSProperty list
        | BorderBottomLeftRadius of ICSSProperty list

        | BorderColor of CssColor list
        | BorderTopColor of CssColor
        | BorderRightColor of CssColor
        | BorderBottomColor of CssColor
        | BorderLeftColor of CssColor

        | Animation of IAnimation list  
        | Animations of IAnimation list list
        | AnimationName of IAnimation
        | AnimationNames of IAnimation list
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

        | Transform of Transform
        | Transforms of Transform list

        | Transition of string //Transition
        | Transitions of ICSSProperty list
        | TransitionDelay of Time
        | TransitionDuration of Time
        | TransitionProperty of ICSSProperty
        | TransitionTimingFunction of Animation.Timing

    let label = "label"
    let hover = ":hover"

    let combineWs (list: 'a list) (value: 'a -> string) = combineList list value " "
    let combineComma (list: 'a list) (value: 'a -> string) = combineList list value ", " 
    let combineAnimationNames (list: IAnimation list): string = list |> List.map string |> String.concat ", "
    let combineAnimations (list: IAnimation list list): string =
        combineComma list (fun a -> combineWs a Animation.value)
        (*
            list
        |> List.map (fun a -> combineWs a Animation.value)
        |> String.concat ", "
        *)

    let rec createCSSObject (attributeList: CSSProperty list) = 
        attributeList
        |> List.map (
            function
                | Label l            -> label           ==> l
                | Color c            -> color           ==> Color.value c
                | BackgroundColor bc -> backgroundColor ==> Color.value bc
                | Hover h            -> hover           ==> createCSSObject h
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

                | Animation a                 -> animation               ==> combineWs a Animation.value
                | Animations ans              -> animation               ==> combineAnimations ans
                | AnimationName n             -> animationName           ==> string n
                | AnimationNames ns           -> animationName           ==> combineAnimationNames ns
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

                | Transform t   -> transform ==> Transform.value t
                | Transforms ts -> transform ==> combineWs ts Transform.value

                //| Transition t               -> "transition"                 ==> Transition.value t
                | Transitions ts             -> "transition"                 ==> combineComma ts value
                | TransitionDelay t          -> "transition-delay"           ==> Animation.value t
                | TransitionDuration t       -> "transition-duration"        ==> Animation.value t
                | TransitionProperty t       -> "transition-property"        ==> value t
                | TransitionTimingFunction t -> "transition-timing-function" ==> Animation.value t

        )  |> createObj


