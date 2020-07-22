namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Utilities.Types
open Property
open Color
open Units.Size
open Units.Angle
open Fonts
open BorderStyle
open BorderWidth
open Animation
open Transform
open Transition


module Css = 
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x) 


    let value (v: ICSSProperty): string =
        match v with
            | :? Property as n -> Property.value n
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

        | Width of Size
        | Height of Size

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

        | Transition of Transition
        | Transition3 of Property * Time * Timing * Time
        | Transitions of ICSSProperty list
        | TransitionDelay of Time
        | TransitionDuration of Time
        | TransitionProperty of ICSSProperty
        | TransitionTimingFunction of Animation.Timing

    let combineWs (list: 'a list) (value: 'a -> string) = combineList list value " "
    let combineComma (list: 'a list) (value: 'a -> string) = combineList list value ", " 
    let combineAnimationNames (list: IAnimation list): string = list |> List.map string |> String.concat ", "
    let combineAnimations (list: IAnimation list list): string =
        combineComma list (fun a -> combineWs a Animation.value)

    let rec createCSSObject (attributeList: CSSProperty list) = 
        attributeList
        |> List.map (
            function
                | Label l            -> Property.value label           ==> l
                | Color c            -> Property.value color           ==> Color.value c
                | BackgroundColor bc -> Property.value backgroundColor ==> Color.value bc
                | Hover h            -> Property.value hover           ==> createCSSObject h
                | FontSize f         -> Property.value fontSize        ==> value f

                | Border b        -> Property.value border      ==> combineWs b value
                | BorderStyle bss -> Property.value borderStyle ==> combineWs bss BorderStyle.value

                | BorderWidth bws      -> Property.value borderWidth       ==> combineWs bws value
                | BorderTopWidth bw    -> Property.value borderTopWidth    ==> value bw
                | BorderRightWidth bw  -> Property.value borderRightWidth  ==> value bw
                | BorderBottomWidth bw -> Property.value borderBottomWidth ==> value bw
                | BorderLeftWidth bw   -> Property.value borderLeftWidth   ==> value bw
               
                | BorderRadius br            -> Property.value borderRadius            ==> combineWs br value
                | BorderTopLeftRadius br     -> Property.value borderTopLeftRadius     ==> combineWs br value
                | BorderTopRightRadius br    -> Property.value borderTopRightRadius    ==> combineWs br value
                | BorderBottomRightRadius br -> Property.value borderBottomRightRadius ==> combineWs br value
                | BorderBottomLeftRadius br  -> Property.value borderBottomLeftRadius  ==> combineWs br value

                | BorderColor bc       -> Property.value borderColor       ==> combineWs bc Color.value
                | BorderTopColor bc    -> Property.value borderTopColor    ==> Color.value bc
                | BorderRightColor bc  -> Property.value borderRightColor  ==> Color.value bc
                | BorderBottomColor bc -> Property.value borderBottomColor ==> Color.value bc
                | BorderLeftColor bc   -> Property.value borderLeftColor   ==> Color.value bc

                | Width w  -> Property.value width ==> Units.Size.value w
                | Height h -> Property.value height ==> Units.Size.value h

                | Animation a                 -> Property.value animation               ==> combineWs a Animation.value
                | Animations ans              -> Property.value animation               ==> combineAnimations ans
                | AnimationName n             -> Property.value animationName           ==> string n
                | AnimationNames ns           -> Property.value animationName           ==> combineAnimationNames ns
                | AnimationDuration d         -> Property.value animationDuration       ==> Animation.value d
                | AnimationDurations ds       -> Property.value animationDuration       ==> combineComma ds Animation.value
                | AnimationTimingFunction t   -> Property.value animationTimingFunction ==> Animation.value t
                | AnimationTimingFunctions ts -> Property.value animationTimingFunction ==> combineComma ts Animation.value
                | AnimationDelay d            -> Property.value animationDelay          ==> Animation.value d
                | AnimationDelays ds          -> Property.value animationDelay          ==> combineComma ds Animation.value
                | AnimationIterationCount i   -> Property.value animationIterationCount ==> Animation.value i
                | AnimationIterationCounts is -> Property.value animationIterationCount ==> combineComma is Animation.value
                | AnimationDirection d        -> Property.value animationDirection      ==> Animation.value d
                | AnimationDirections ds      -> Property.value animationDirection      ==> combineComma ds Animation.value
                | AnimationFillMode f         -> Property.value animationFillMode       ==> Animation.value f
                | AnimationFillModes fs       -> Property.value animationFillMode       ==> combineComma fs Animation.value
                | AnimationPlayState p        -> Property.value animationPlayState      ==> Animation.value p
                | AnimationPlayStates ps      -> Property.value animationPlayState      ==> combineComma ps Animation.value

                | Transform t   -> Property.value transform ==> Transform.value t
                | Transforms ts -> Property.value transform ==> combineWs ts Transform.value

                | Transition t               -> "transition"                 ==> Transition.value t
                | Transition3 (a,b,c,d)      -> "transition"                 ==> sprintf "%s %s %s %s" (value a) (Animation.value b) (Animation.value c) (Animation.value d)
                | Transitions ts             -> "transition"                 ==> combineComma ts value
                | TransitionDelay t          -> "transition-delay"           ==> Animation.value t
                | TransitionDuration t       -> "transition-duration"        ==> Animation.value t
                | TransitionProperty t       -> "transition-property"        ==> value t
                | TransitionTimingFunction t -> "transition-timing-function" ==> Animation.value t

        )  |> createObj


