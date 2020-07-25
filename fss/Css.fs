namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Utilities.Types
open Utilities.Global
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
open Display
open FlexDirection
open JustifyContent
open AlignItems
open FlexWrap
open FlexTypes
open AlignContent
open AlignSelf
open Order
open FlexGrow
open FlexShrink
open FlexBasis
open Flex
open Margin
open Selector

module Css = 
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x) 

    let value (v: ICSSProperty): string =
        match v with
            | :? Display as d        -> Display.value d
            | :? Global as g         -> Utilities.Global.value g
            | :? Property as n       -> Property.value n
            | :? CssColor as c       -> Color.value c
            | :? Size as c           -> Units.Size.value c
            | :? Angle as a          -> Units.Angle.value a
            | :? FontSize as f       -> Fonts.value f
            | :? BorderStyle as b    -> BorderStyle.value b
            | :? BorderWidth as b    -> BorderWidth.value b
            | :? Transform as t      -> Transform.value t
            | :? Margin as m         -> Margin.value m
            | :? JustifyContent as j -> JustifyContent.value j
            | :? FlexDirection as f  -> FlexDirection.value f
            | :? FlexWrap as f       -> FlexWrap.value f
            | :? FlexGrow as f       -> FlexGrow.value f
            | :? FlexShrink as f     -> FlexShrink.value f
            | :? FlexBasis as f      -> FlexBasis.value f
            | :? AlignItems as a     -> AlignItems.value a
            | :? AlignContent as a   -> AlignContent.value a
            | :? AlignSelf as a      -> AlignSelf.value a
            | :? Order as o          -> Order.value o
            | :? Transition as t     -> Transition.value t
            | _ -> "Unknown CSS"

    type CSSProperty =
        | Selector of Selector * CSSProperty list

        | Label of string
        | Color of ICSSProperty
        | BackgroundColor of ICSSProperty
        | Hover of CSSProperty list
        | FontSize of ICSSProperty

        | Border of ICSSProperty list
        | BorderStyle of ICSSProperty list
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

        | BorderColor of ICSSProperty list
        | BorderTopColor of ICSSProperty
        | BorderRightColor of ICSSProperty 
        | BorderBottomColor of ICSSProperty
        | BorderLeftColor of ICSSProperty

        | Width of ICSSProperty
        | Height of ICSSProperty
        | Perspective of ICSSProperty

        | Display of ICSSProperty
        | FlexDirection of ICSSProperty
        | FlexWrap of ICSSProperty
        | JustifyContent of ICSSProperty
        | AlignItems of ICSSProperty
        | AlignContent of ICSSProperty
        | Order of ICSSProperty
        | FlexGrow of ICSSProperty
        | FlexShrink of ICSSProperty
        | FlexBasis of ICSSProperty
        | AlignSelf of ICSSProperty
        | Flex of ICSSProperty list

        | MarginTop of ICSSProperty
        | MarginRight of ICSSProperty
        | MarginBottom of ICSSProperty
        | MarginLeft of ICSSProperty
        | Margin of ICSSProperty 
        | Margins of ICSSProperty list

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

        | Transform of ICSSProperty
        | Transforms of ICSSProperty list

        | Transition of ICSSProperty
        | Transitions of ICSSProperty list
        | TransitionDelay of ICSSProperty
        | TransitionDuration of ICSSProperty
        | TransitionProperty of ICSSProperty
        | TransitionTimingFunction of ICSSProperty

    let combineWs (list: 'a list) (value: 'a -> string) = combineList list value " "
    let combineComma (list: 'a list) (value: 'a -> string) = combineList list value ", " 
    let combineAnimationNames (list: IAnimation list): string = list |> List.map string |> String.concat ", "
    let combineAnimations (list: IAnimation list list): string =
        combineComma list (fun a -> combineWs a Animation.value)

    let rec createCSSObject (attributeList: CSSProperty list) = 
        attributeList
        |> List.map (
            function
                | Selector (s, ss)   -> Selector.value s               ==> createCSSObject ss

                | Label l            -> Property.value label           ==> l
                | Color c            -> Property.value color           ==> value c
                | BackgroundColor bc -> Property.value backgroundColor ==> value bc
                | Hover h            -> Property.value hover           ==> createCSSObject h
                | FontSize f         -> Property.value fontSize        ==> value f

                | Border b        -> Property.value border      ==> combineWs b value
                | BorderStyle bss -> Property.value borderStyle ==> combineWs bss value

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

                | BorderColor bc       -> Property.value borderColor       ==> combineWs bc value
                | BorderTopColor bc    -> Property.value borderTopColor    ==> value bc
                | BorderRightColor bc  -> Property.value borderRightColor  ==> value bc
                | BorderBottomColor bc -> Property.value borderBottomColor ==> value bc
                | BorderLeftColor bc   -> Property.value borderLeftColor   ==> value bc

                | Width w       -> Property.value width       ==> value w
                | Height h      -> Property.value height      ==> value h
                | Perspective p -> Property.value perspective ==> value p

                | Display d        -> Property.value display        ==> value d
                | FlexDirection f  -> Property.value flexDirection  ==> value f
                | FlexWrap f       -> Property.value flexWrap       ==> value f
                | FlexBasis f      -> Property.value flexBasis      ==> value f
                | JustifyContent j -> Property.value justifyContent ==> value j
                | AlignItems a     -> Property.value alignItems     ==> value a
                | AlignContent a   -> Property.value alignContent   ==> value a
                | Order o          -> Property.value order          ==> value o
                | FlexGrow f       -> Property.value flexGrow       ==> value f
                | FlexShrink f     -> Property.value flexShrink     ==> value f
                | AlignSelf a      -> Property.value alignSelf      ==> value a
                | Flex f           -> Property.value flex           ==> combineWs f Flex.value

                | MarginTop m    -> Property.value marginTop    ==> value m
                | MarginRight m  -> Property.value marginRight  ==> value m
                | MarginBottom m -> Property.value marginBottom ==> value m
                | MarginLeft m   -> Property.value marginLeft   ==> value m
                | Margin m       -> Property.value margin       ==> value m
                | Margins ms     -> Property.value margin       ==> combineWs ms value

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

                | Transform t   -> Property.value transform ==> value t
                | Transforms ts -> Property.value transform ==> combineWs ts value

                | Transition t               -> Property.value transition               ==> value t
                | Transitions ts             -> Property.value transition               ==> combineComma ts value
                | TransitionDelay t          -> Property.value transitionDelay          ==> value t
                | TransitionDuration t       -> Property.value transitionDuration       ==> value t
                | TransitionProperty t       -> Property.value transitionProperty       ==> value t
                | TransitionTimingFunction t -> Property.value transitionTimingFunction ==> value t

        )  |> createObj


