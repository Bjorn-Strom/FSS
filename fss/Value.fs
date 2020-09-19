namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Types
open Utilities.Helpers
open Property
open Animation
open Selector
open Padding
open Media
open TextOverflow
open Opacity
open Position
open Cursor
open Time
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
        | TextShadow              of ITextShadow
        | TextShadows             of ITextShadow list
        | TextOverflow            of TextOverflow

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
        | AnimationDirection       of Direction
        | AnimationDirections      of Direction list
        | AnimationFillMode        of FillMode
        | AnimationFillModes       of FillMode list
        | AnimationPlayState       of PlayState
        | AnimationPlayStates      of PlayState list

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
    let combineAnimations (list: IAnimation list list): string = combineComma (fun a -> combineWs Animation.value a) list

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
                | BackgroundImage       bi -> Property.value backgroundImage      ==> BackgroundValues.backgroundImageValue bi
                | BackgroundPosition    b  -> Property.value backgroundPosition   ==> BackgroundValues.backgroundPositionValue b
                | BackgroundPositions   bs -> Property.value backgroundPosition   ==> combineWs BackgroundValues.backgroundPositionValue bs
                | BackgroundOrigin      b  -> Property.value backgroundOrigin     ==> BackgroundValues.backgroundOriginValue b
                | BackgroundClip        b  -> Property.value backgroundClip       ==> BackgroundValues.backgroundClipValue b
                | BackgroundRepeat      b  -> Property.value backgroundRepeat     ==> BackgroundValues.backgroundRepeatValue b
                | BackgroundRepeats     bs -> Property.value backgroundRepeat     ==> combineWs BackgroundValues.backgroundRepeatValue bs
                | BackgroundSize        b  -> Property.value backgroundSize       ==> BackgroundValues.backgroundSizeValue b
                | BackgroundSizes       bs -> Property.value backgroundSize       ==> combineWs BackgroundValues.backgroundSizeValue bs
                | BackgroundAttachment  b  -> Property.value backgroundAttachment ==> BackgroundValues.backgroundAttachmentValue b
                | BackgroundAttachments bs -> Property.value backgroundAttachment ==> combineWs BackgroundValues.backgroundAttachmentValue bs
                
                | Hover h -> hover |> Property.value |> toPsuedo ==> createCSSObject h
                
                | FontSize              f  -> Property.value fontSize             ==> FontValues.fontSizeValue f
                | FontStyle             f  -> Property.value fontStyle            ==> FontValues.fontStyleValue f
                | FontStretch           f  -> Property.value fontStretch          ==> FontValues.fontStretchValue f
                | FontWeight            f  -> Property.value fontWeight           ==> FontValues.fontWeightValue f
                | LineHeight            l  -> Property.value lineHeight           ==> FontValues.lineHeightValue l
                | FontFamily            f  -> Property.value fontFamily           ==> FontValues.fontFamilyValue f
                | FontFamilies          fs -> Property.value fontFamily           ==> combineWs FontValues.fontFamilyValue fs
                | FontFeatureSetting    f  -> Property.value fontFeatureSettings  ==> FontValues.fontFeatureSettingValue f
                | FontFeatureSettings   fs -> Property.value fontFeatureSettings  ==> combineComma FontValues.fontFeatureSettingValue fs 
                | FontVariantNumeric    f  -> Property.value fontVariantNumeric   ==> FontValues.fontVariantNumericValue f
                | FontVariantNumerics   fs -> Property.value fontVariantNumeric   ==> combineWs FontValues.fontVariantNumericValue fs 
                | FontVariantCaps       f  -> Property.value fontVariantCaps      ==> FontValues.fontVariantCapValue f
                | FontVariantEastAsian  f  -> Property.value fontVariantEastAsian ==> FontValues.fontVariantEastAsianValue f
                | FontVariantEastAsians fs -> Property.value fontVariantEastAsian ==> combineWs FontValues.fontVariantEastAsianValue fs 
                | FontVariantLigatures  f  -> Property.value fontVariantLigatures ==> FontValues.fontVariantLigatureValue f

                | TextAlign               t  -> Property.value textAlign               ==> TextAlign.value t
                | TextDecorationLine      t  -> Property.value textDecorationLine      ==> TextDecorationLine.value t
                | TextDecorationLines     ts -> Property.value textDecorationLine      ==> combineWs TextDecorationLine.value ts 
                | TextDecorationColor     t  -> Property.value textDecorationColor     ==> Color.value t
                | TextDecorationThickness t  -> Property.value textDecorationThickness ==> TextDecorationThickness.value t
                | TextDecorationStyle     t  -> Property.value textDecorationStyle     ==> TextDecorationStyle.value t 
                | TextDecorationSkipInk   t  -> Property.value textDecorationSkipInk   ==> TextDecorationSkipInk.value t 
                | TextTransform           t  -> Property.value textTransform           ==> TextTransform.value t
                | TextIndent              t  -> Property.value textIndent              ==> TextIndent.value t
                | TextIndents             ts -> Property.value textIndent              ==> combineWs TextIndent.value ts 
                | TextShadow              t  -> Property.value textShadow              ==> TextShadow.value t
                | TextShadows             ts -> Property.value textShadow              ==> combineComma TextShadow.value ts 
                | TextOverflow            t  -> Property.value textOverflow            ==> TextOverflow.value t

                | BorderStyle  bs  -> Property.value borderStyle ==> BorderValue.borderStyleValue bs
                | BorderStyles bss -> Property.value borderStyle ==> combineWs BorderValue.borderStyleValue bss 

                | BorderWidth       bw  -> Property.value borderWidth       ==> BorderValue.borderWidthValue bw
                | BorderWidths      bws -> Property.value borderWidth       ==> combineWs BorderValue.borderWidthValue bws 
                | BorderTopWidth    bw  -> Property.value borderTopWidth    ==> BorderValue.borderWidthValue bw
                | BorderRightWidth  bw  -> Property.value borderRightWidth  ==> BorderValue.borderWidthValue bw
                | BorderBottomWidth bw  -> Property.value borderBottomWidth ==> BorderValue.borderWidthValue bw
                | BorderLeftWidth   bw  -> Property.value borderLeftWidth   ==> BorderValue.borderWidthValue  bw
               
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

                | Display        d -> Property.value display        ==> Display.value d
                | FlexDirection  f -> Property.value flexDirection  ==> FlexDirection.value f
                | FlexWrap       f -> Property.value flexWrap       ==> FlexWrap.value f
                | FlexBasis      f -> Property.value flexBasis      ==> FlexBasis.value f
                | JustifyContent j -> Property.value justifyContent ==> JustifyContent.value j
                | AlignItems     a -> Property.value alignItems     ==> AlignItems.value a
                | AlignContent   a -> Property.value alignContent   ==> AlignContent.value a
                | Order          o -> Property.value order          ==> Order.value o
                | FlexGrow       f -> Property.value flexGrow       ==> FlexGrow.value f
                | FlexShrink     f -> Property.value flexShrink     ==> FlexShrink.value f
                | AlignSelf      a -> Property.value alignSelf      ==> AlignSelf.value a
                | VerticalAlign  v -> Property.value verticalAlign  ==> VerticalAlign.value v
                | Visibility     v -> Property.value visibility     ==> Visibility.value v
                | Opacity        o -> Property.value opacity        ==> Opacity.value o
                | Position       p -> Property.value position       ==> Position.value p

                | MarginTop    m  -> Property.value marginTop    ==> MarginValue.value m
                | MarginRight  m  -> Property.value marginRight  ==> MarginValue.value m
                | MarginBottom m  -> Property.value marginBottom ==> MarginValue.value m
                | MarginLeft   m  -> Property.value marginLeft   ==> MarginValue.value m
                | Margin       m  -> Property.value margin       ==> MarginValue.value m
                | Margins      ms -> Property.value margin       ==> combineWs MarginValue.value ms

                | PaddingTop    m  -> Property.value paddingTop    ==> PaddingValue.value m
                | PaddingRight  m  -> Property.value paddingRight  ==> PaddingValue.value m
                | PaddingBottom m  -> Property.value paddingBottom ==> PaddingValue.value m
                | PaddingLeft   m  -> Property.value paddingLeft   ==> PaddingValue.value m
                | Padding       m  -> Property.value padding       ==> PaddingValue.value m
                | Paddings      ms -> Property.value padding       ==> combineWs PaddingValue.value ms

                | Animation                a   -> Property.value animation               ==> combineWs Animation.value a
                | Animations               ans -> Property.value animation               ==> combineAnimations ans
                | AnimationName            n   -> Property.value animationName           ==> string n
                | AnimationNames           ns  -> Property.value animationName           ==> combineAnimationNames ns
                | AnimationDuration        d   -> Property.value animationDuration       ==> Animation.value d
                | AnimationDurations       ds  -> Property.value animationDuration       ==> combineComma Animation.value ds
                | AnimationTimingFunction  t   -> Property.value animationTimingFunction ==> Animation.value t
                | AnimationTimingFunctions ts  -> Property.value animationTimingFunction ==> combineComma Animation.value ts
                | AnimationDelay           d   -> Property.value animationDelay          ==> Animation.value d
                | AnimationDelays          ds  -> Property.value animationDelay          ==> combineComma Animation.value ds
                | AnimationIterationCount  i   -> Property.value animationIterationCount ==> Animation.value i
                | AnimationIterationCounts is  -> Property.value animationIterationCount ==> combineComma Animation.value is
                | AnimationDirection       d   -> Property.value animationDirection      ==> Animation.value d
                | AnimationDirections      ds  -> Property.value animationDirection      ==> combineComma Animation.value ds
                | AnimationFillMode        f   -> Property.value animationFillMode       ==> Animation.value f
                | AnimationFillModes       fs  -> Property.value animationFillMode       ==> combineComma Animation.value fs
                | AnimationPlayState       p   -> Property.value animationPlayState      ==> Animation.value p
                | AnimationPlayStates      ps  -> Property.value animationPlayState      ==> combineComma Animation.value ps

                | Transform       t  -> Property.value transform       ==> TransformValue.transformValue t
                | Transforms      ts -> Property.value transform       ==> combineWs TransformValue.transformValue ts
                | TransformOrigin ts -> Property.value transformOrigin ==> combineWs TransformValue.transformOriginValue ts

                | Transition               t  -> Property.value transition               ==> TransitionValue.value t
                | Transitions              ts -> Property.value transition               ==> combineComma TransitionValue.value ts
                | TransitionDelay          t  -> Property.value transitionDelay          ==> Animation.value t
                | TransitionDuration       t  -> Property.value transitionDuration       ==> Animation.value t
                | TransitionProperty       t  -> Property.value transitionProperty       ==> Property.value t
                | TransitionTimingFunction t  -> Property.value transitionTimingFunction ==> Animation.value t

                | Cursor c -> Property.value cursor ==> Cursor.value c
        )
        |> createObj