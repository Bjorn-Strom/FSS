namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Types
open Utilities.Helpers
open Property
open Animation
open Selector
open Media
open Opacity
open Position
open Cursor
open Units.Time
open Background

[<AutoOpen>]
module Value = 
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x) 

    type CSSProperty =
        | Selector  of Selector * CSSProperty list

        | Media    of MediaFeature list * CSSProperty list
        | MediaFor of Device * MediaFeature list * CSSProperty list

        | Label of string

        | Color of IColor

        | BackgroundColor       of IColor
        | BackgroundImage       of BackgroundImage
        | BackgroundPosition    of IBackgroundPosition
        | BackgroundPositions   of IBackgroundPosition list
        | BackgroundOrigin      of IBackgroundOrigin
        | BackgroundClip        of IBackgroundClip
        | BackgroundRepeat      of IBackgroundRepeat
        | BackgroundRepeats     of IBackgroundRepeat list
        | BackgroundSize        of IBackgroundSize
        | BackgroundSizes       of IBackgroundSize list
        | BackgroundAttachment  of IBackgroundAttachment
        | BackgroundAttachments of IBackgroundAttachment list

        | Hover of CSSProperty list

        | FontSize              of IFontSize
        | FontStyle             of IFontStyle
        | FontWeight            of IFontWeight
        | FontStretch           of IFontStretch
        | LineHeight            of ILineHeight
        | FontFamily            of IFontFamily
        | FontFamilies          of IFontFamily list
        | FontFeatureSetting    of IFontFeatureSetting
        | FontFeatureSettings   of IFontFeatureSetting list
        | FontVariantNumeric    of IFontVariantNumeric
        | FontVariantNumerics   of IFontVariantNumeric list
        | FontVariantCaps       of IFontVariantCaps
        | FontVariantEastAsian  of IFontVariantEastAsian
        | FontVariantEastAsians of IFontVariantEastAsian list
        | FontVariantLigatures  of IFontVariantLigatures

        | TextAlign               of ITextAlign
        | TextDecorationLine      of ITextDecorationLine
        | TextDecorationLines     of ITextDecorationLine list
        | TextDecorationColor     of IColor
        | TextDecorationThickness of ITextDecorationThickness
        | TextDecorationStyle     of ITextDecorationStyle
        | TextDecorationSkipInk   of ITextDecorationSkipInk
        | TextTransform           of ITextTransform
        | TextIndent              of ITextIndent
        | TextIndents             of ITextIndent list
        | TextShadowProperty      of ITextShadow
        | TextShadowProperties    of ITextShadow list
        | TextOverflow            of Text.TextOverflow

        | BorderStyle       of IBorderStyle
        | BorderStyles      of IBorderStyle list
        | BorderWidth       of IBorderWidth
        | BorderWidths      of IBorderWidth list
        | BorderTopWidth    of IBorderWidth
        | BorderRightWidth  of IBorderWidth
        | BorderBottomWidth of IBorderWidth
        | BorderLeftWidth   of IBorderWidth

        | BorderRadius              of ISize
        | BorderRadiuses            of ISize list
        | BorderTopLeftRadius       of ISize
        | BorderTopLeftRadiuses     of ISize list
        | BorderTopRightRadius      of ISize
        | BorderTopRightRadiuses    of ISize list
        | BorderBottomRightRadius   of ISize
        | BorderBottomRightRadiuses of ISize list
        | BorderBottomLeftRadius    of ISize
        | BorderBottomLeftRadiuses  of ISize list

        | BorderColor       of IColor 
        | BorderColors      of IColor list
        | BorderTopColor    of IColor
        | BorderRightColor  of IColor 
        | BorderBottomColor of IColor
        | BorderLeftColor   of IColor

        | Width       of IContentSize
        | MinWidth    of IContentSize
        | MaxWidth    of IContentSize
        | Height      of IContentSize
        | MinHeight   of IContentSize
        | MaxHeight   of IContentSize

        | Perspective of ISize

        | Display        of IDisplay
        | FlexDirection  of IFlexDirection
        | FlexWrap       of IFlexWrap
        | JustifyContent of IJustifyContent
        | AlignItems     of IAlignItems
        | AlignContent   of IAlignContent
        | Order          of IOrder
        | FlexGrow       of IFlexGrow
        | FlexShrink     of IFlexShrink
        | FlexBasis      of IFlexBasis
        | AlignSelf      of IAlignSelf
        | VerticalAlign  of IVerticalAlign
        | Visibility     of IVisibility
        | Opacity        of Opacity
        | Position       of Position

        | MarginTop    of IMargin
        | MarginRight  of IMargin
        | MarginBottom of IMargin
        | MarginLeft   of IMargin
        | Margin       of IMargin 
        | Margins      of IMargin list

        | PaddingTop    of IPadding
        | PaddingRight  of IPadding
        | PaddingBottom of IPadding
        | PaddingLeft   of IPadding
        | Padding       of IPadding 
        | Paddings      of IPadding list

        | Animation                of IAnimation list  
        | Animations               of IAnimation list list
        | AnimationName            of IAnimation
        | AnimationNames           of IAnimation list
        | AnimationDuration        of Time
        | AnimationDurations       of Time list
        | AnimationTimingFunction  of Timing
        | AnimationTimingFunctions of Timing list
        | AnimationDelay           of Time
        | AnimationDelays          of Time list
        | AnimationIterationCount  of IterationCount
        | AnimationIterationCounts of IterationCount list
        | AnimationDirection       of IAnimationDirection
        | AnimationDirections      of IAnimationDirection list
        | AnimationFillMode        of FillMode
        | AnimationFillModes       of FillMode list
        | AnimationPlayState       of IAnimationPlayState
        | AnimationPlayStates      of IAnimationPlayState list

        | Transform       of ITransform
        | Transforms      of ITransform list
        | TransformOrigin of ITransformOrigin list

        | Transition               of ITransition
        | Transitions              of ITransition list
        | TransitionDelay          of Time
        | TransitionDuration       of Time
        | TransitionProperty       of Property
        | TransitionTimingFunction of Timing

        | Cursor of Cursor

    let combineAnimationNames (list: IAnimation list): string = list |> List.map string |> String.concat ", "
    let combineAnimations (list: IAnimation list list): string = combineComma (fun a -> combineWs AnimationValue.animation a) list

    let rec createCSSObject (attributeList: CSSProperty list) = 
        attributeList
        |> List.map (
            function
                | Selector (s, ss)    -> Selector.value s ==> createCSSObject ss

                | Media    (f, p)     -> sprintf "@media %s" <| Media.featureLabel f                         ==> createCSSObject p
                | MediaFor (d, f, p)  -> sprintf "@media %s %s" (Media.deviceLabel d) (Media.featureLabel f) ==> createCSSObject p

                | Label l            -> Property.value label ==> l
                
                | Color c            -> Property.value color ==> Color.value c
                
                | BackgroundColor       bc -> Property.value backgroundColor      ==> Color.value bc
                | BackgroundImage       bi -> Property.value backgroundImage      ==> BackgroundValues.backgroundImage bi
                | BackgroundPosition    b  -> Property.value backgroundPosition   ==> BackgroundValues.backgroundPosition b
                | BackgroundPositions   bs -> Property.value backgroundPosition   ==> combineWs BackgroundValues.backgroundPosition bs
                | BackgroundOrigin      b  -> Property.value backgroundOrigin     ==> BackgroundValues.backgroundOrigin b
                | BackgroundClip        b  -> Property.value backgroundClip       ==> BackgroundValues.backgroundClip b
                | BackgroundRepeat      b  -> Property.value backgroundRepeat     ==> BackgroundValues.backgroundRepeat b
                | BackgroundRepeats     bs -> Property.value backgroundRepeat     ==> combineWs BackgroundValues.backgroundRepeat bs
                | BackgroundSize        b  -> Property.value backgroundSize       ==> BackgroundValues.backgroundSize b
                | BackgroundSizes       bs -> Property.value backgroundSize       ==> combineWs BackgroundValues.backgroundSize bs
                | BackgroundAttachment  b  -> Property.value backgroundAttachment ==> BackgroundValues.backgroundAttachment b
                | BackgroundAttachments bs -> Property.value backgroundAttachment ==> combineWs BackgroundValues.backgroundAttachment bs
                
                | Hover h -> hover |> Property.value |> toPsuedo ==> createCSSObject h
                
                | FontSize              f  -> Property.value fontSize             ==> FontValues.fontSize f
                | FontStyle             f  -> Property.value fontStyle            ==> FontValues.fontStyle f
                | FontStretch           f  -> Property.value fontStretch          ==> FontValues.fontStretch f
                | FontWeight            f  -> Property.value fontWeight           ==> FontValues.fontWeight f
                | LineHeight            l  -> Property.value lineHeight           ==> FontValues.lineHeight l
                | FontFamily            f  -> Property.value fontFamily           ==> FontValues.fontFamily f
                | FontFamilies          fs -> Property.value fontFamily           ==> combineWs FontValues.fontFamily fs
                | FontFeatureSetting    f  -> Property.value fontFeatureSettings  ==> FontValues.fontFeatureSetting f
                | FontFeatureSettings   fs -> Property.value fontFeatureSettings  ==> combineComma FontValues.fontFeatureSetting fs 
                | FontVariantNumeric    f  -> Property.value fontVariantNumeric   ==> FontValues.fontVariantNumeric f
                | FontVariantNumerics   fs -> Property.value fontVariantNumeric   ==> combineWs FontValues.fontVariantNumeric fs 
                | FontVariantCaps       f  -> Property.value fontVariantCaps      ==> FontValues.fontVariantCap f
                | FontVariantEastAsian  f  -> Property.value fontVariantEastAsian ==> FontValues.fontVariantEastAsian f
                | FontVariantEastAsians fs -> Property.value fontVariantEastAsian ==> combineWs FontValues.fontVariantEastAsian fs 
                | FontVariantLigatures  f  -> Property.value fontVariantLigatures ==> FontValues.fontVariantLigature f

                | TextAlign               t  -> Property.value textAlign               ==> TextValue.textAlign t
                | TextDecorationLine      t  -> Property.value textDecorationLine      ==> TextValue.textDecorationLine t
                | TextDecorationLines     ts -> Property.value textDecorationLine      ==> combineWs TextValue.textDecorationLine ts 
                | TextDecorationColor     t  -> Property.value textDecorationColor     ==> Color.value t
                | TextDecorationThickness t  -> Property.value textDecorationThickness ==> TextValue.textDecorationThickness t
                | TextDecorationStyle     t  -> Property.value textDecorationStyle     ==> TextValue.textDecorationStyle t 
                | TextDecorationSkipInk   t  -> Property.value textDecorationSkipInk   ==> TextValue.textDecorationSkipInk t 
                | TextTransform           t  -> Property.value textTransform           ==> TextValue.textTransform t
                | TextIndent              t  -> Property.value textIndent              ==> TextValue.textIndent t
                | TextIndents             ts -> Property.value textIndent              ==> combineWs TextValue.textIndent ts 
                | TextShadowProperty      t  -> Property.value textShadow              ==> TextValue.textShadow t
                | TextShadowProperties    ts -> Property.value textShadow              ==> combineComma TextValue.textShadow ts 
                | TextOverflow            t  -> Property.value textOverflow            ==> TextValue.textOverflow t

                | BorderStyle  bs  -> Property.value borderStyle ==> BorderValue.borderStyle bs
                | BorderStyles bss -> Property.value borderStyle ==> combineWs BorderValue.borderStyle bss 

                | BorderWidth       bw  -> Property.value borderWidth       ==> BorderValue.borderWidth bw
                | BorderWidths      bws -> Property.value borderWidth       ==> combineWs BorderValue.borderWidth bws 
                | BorderTopWidth    bw  -> Property.value borderTopWidth    ==> BorderValue.borderWidth bw
                | BorderRightWidth  bw  -> Property.value borderRightWidth  ==> BorderValue.borderWidth bw
                | BorderBottomWidth bw  -> Property.value borderBottomWidth ==> BorderValue.borderWidth bw
                | BorderLeftWidth   bw  -> Property.value borderLeftWidth   ==> BorderValue.borderWidth  bw
               
                | BorderRadius              br -> Property.value borderRadius            ==> Units.Size.value br
                | BorderRadiuses            br -> Property.value borderRadius            ==> combineWs Units.Size.value br 
                | BorderTopLeftRadius       br -> Property.value borderTopLeftRadius     ==> Units.Size.value br
                | BorderTopLeftRadiuses     br -> Property.value borderTopLeftRadius     ==> combineWs Units.Size.value br
                | BorderTopRightRadius      br -> Property.value borderTopRightRadius    ==> Units.Size.value br
                | BorderTopRightRadiuses    br -> Property.value borderTopRightRadius    ==> combineWs Units.Size.value br 
                | BorderBottomRightRadius   br -> Property.value borderBottomRightRadius ==> Units.Size.value br
                | BorderBottomRightRadiuses br -> Property.value borderBottomRightRadius ==> combineWs Units.Size.value br
                | BorderBottomLeftRadius    br -> Property.value borderBottomLeftRadius  ==> Units.Size.value br
                | BorderBottomLeftRadiuses  br -> Property.value borderBottomLeftRadius  ==> combineWs Units.Size.value br

                | BorderColor       bc  -> Property.value borderColor       ==> Color.value bc
                | BorderColors      bcs -> Property.value borderColor       ==> combineWs Color.value bcs
                | BorderTopColor    bc  -> Property.value borderTopColor    ==> Color.value bc
                | BorderRightColor  bc  -> Property.value borderRightColor  ==> Color.value bc
                | BorderBottomColor bc  -> Property.value borderBottomColor ==> Color.value bc
                | BorderLeftColor   bc  -> Property.value borderLeftColor   ==> Color.value bc

                | Width     w -> Property.value width     ==> ContentSize.value w
                | MinWidth  w -> Property.value minWidth  ==> ContentSize.value w
                | MaxWidth  w -> Property.value maxWidth  ==> ContentSize.value w
                | Height    h -> Property.value height    ==> ContentSize.value h
                | MinHeight h -> Property.value minHeight ==> ContentSize.value h
                | MaxHeight h -> Property.value maxHeight ==> ContentSize.value h

                | Perspective p -> Property.value perspective ==> Units.Size.value p

                | Display        d -> Property.value display        ==> DisplayValue.display d
                | FlexDirection  f -> Property.value flexDirection  ==> FlexValue.flexDirection f
                | FlexWrap       f -> Property.value flexWrap       ==> FlexValue.flexWrap f
                | FlexBasis      f -> Property.value flexBasis      ==> FlexValue.flexBasis f
                | JustifyContent j -> Property.value justifyContent ==> FlexValue.justifyContent j
                | AlignItems     a -> Property.value alignItems     ==> FlexValue.alignItems a
                | AlignContent   a -> Property.value alignContent   ==> FlexValue.alignContent a
                | Order          o -> Property.value order          ==> FlexValue.order o
                | FlexGrow       f -> Property.value flexGrow       ==> FlexValue.flexGrow f
                | FlexShrink     f -> Property.value flexShrink     ==> FlexValue.flexShrink f
                | AlignSelf      a -> Property.value alignSelf      ==> FlexValue.alignSelf a
                | VerticalAlign  v -> Property.value verticalAlign  ==> VerticalAlignValue.verticalAlign v
                | Visibility     v -> Property.value visibility     ==> VisibilityValue.visibility v
                | Opacity        o -> Property.value opacity        ==> OpacityValue.opacity o
                | Position       p -> Property.value position       ==> PositionValue.position p

                | MarginTop    m  -> Property.value marginTop    ==> MarginValue.margin m
                | MarginRight  m  -> Property.value marginRight  ==> MarginValue.margin m
                | MarginBottom m  -> Property.value marginBottom ==> MarginValue.margin m
                | MarginLeft   m  -> Property.value marginLeft   ==> MarginValue.margin m
                | Margin       m  -> Property.value margin       ==> MarginValue.margin m
                | Margins      ms -> Property.value margin       ==> combineWs MarginValue.margin ms

                | PaddingTop    m  -> Property.value paddingTop    ==> PaddingValue.padding m
                | PaddingRight  m  -> Property.value paddingRight  ==> PaddingValue.padding m
                | PaddingBottom m  -> Property.value paddingBottom ==> PaddingValue.padding m
                | PaddingLeft   m  -> Property.value paddingLeft   ==> PaddingValue.padding m
                | Padding       m  -> Property.value padding       ==> PaddingValue.padding m
                | Paddings      ms -> Property.value padding       ==> combineWs PaddingValue.padding ms

                | Animation                a   -> Property.value animation               ==> combineWs AnimationValue.animation a
                | Animations               ans -> Property.value animation               ==> combineAnimations ans
                | AnimationName            n   -> Property.value animationName           ==> string n
                | AnimationNames           ns  -> Property.value animationName           ==> combineAnimationNames ns
                | AnimationDuration        d   -> Property.value animationDuration       ==> Units.Time.value d
                | AnimationDurations       ds  -> Property.value animationDuration       ==> combineComma Units.Time.value ds
                | AnimationTimingFunction  t   -> Property.value animationTimingFunction ==> AnimationValue.timing
                | AnimationTimingFunctions ts  -> Property.value animationTimingFunction ==> combineComma AnimationValue.timing ts
                | AnimationDelay           d   -> Property.value animationDelay          ==> Units.Time.value d
                | AnimationDelays          ds  -> Property.value animationDelay          ==> combineComma Units.Time.value
                | AnimationIterationCount  i   -> Property.value animationIterationCount ==> AnimationValue.iterationCount i
                | AnimationIterationCounts is  -> Property.value animationIterationCount ==> combineComma AnimationValue.iterationCount is
                | AnimationDirection       d   -> Property.value animationDirection      ==> AnimationValue.direction d
                | AnimationDirections      ds  -> Property.value animationDirection      ==> combineComma AnimationValue.direction ds
                | AnimationFillMode        f   -> Property.value animationFillMode       ==> AnimationValue.fillMode f
                | AnimationFillModes       fs  -> Property.value animationFillMode       ==> combineComma AnimationValue.fillMode fs
                | AnimationPlayState       p   -> Property.value animationPlayState      ==> AnimationValue.playState p
                | AnimationPlayStates      ps  -> Property.value animationPlayState      ==> combineComma AnimationValue.playState ps

                | Transform       t  -> Property.value transform       ==> TransformValue.transform t
                | Transforms      ts -> Property.value transform       ==> combineWs TransformValue.transform ts
                | TransformOrigin ts -> Property.value transformOrigin ==> combineWs TransformValue.transformOrigin ts

                | Transition               t  -> Property.value transition               ==> TransitionValue.value t
                | Transitions              ts -> Property.value transition               ==> combineComma TransitionValue.value ts
                | TransitionDelay          t  -> Property.value transitionDelay          ==> Units.Time.value t
                | TransitionDuration       t  -> Property.value transitionDuration       ==> Units.Time.value t
                | TransitionProperty       t  -> Property.value transitionProperty       ==> Property.value t
                | TransitionTimingFunction t  -> Property.value transitionTimingFunction ==> AnimationValue.timing t

                | Cursor c -> Property.value cursor ==> Cursor.value c
        )
        |> createObj