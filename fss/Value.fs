namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open Fable.React.Props
open Types
open Utilities.Helpers
open Animation
open Selector
open Media
open Opacity
open Units.Time

[<AutoOpen>]
module Value =
    [<Import("css", from="emotion")>]
    let private css(x) = jsNative
    let css' x = css(x)

    type CSSProperty =
        | Selector  of Selector * CSSProperty list

        | MediaProperty    of MediaFeature list * CSSProperty list
        | MediaForProperty of Device * MediaFeature list * CSSProperty list

        | Label of string

        | Color of IColor

        | BackgroundColor       of IColor
        | BackgroundImage       of Background.Image
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

        | Active           of CSSProperty list
        | AnyLink          of CSSProperty list
        | Blank            of CSSProperty list
        | Checked          of CSSProperty list
        | Disabled         of CSSProperty list
        | Empty            of CSSProperty list
        | Enabled          of CSSProperty list
        | FirstOfType      of CSSProperty list
        | Focus            of CSSProperty list
        | Hover            of CSSProperty list
        | Indeterminate    of CSSProperty list
        | Invalid          of CSSProperty list
        | Lang             of string * CSSProperty list
        | LastChild        of CSSProperty list
        | LastOfType       of CSSProperty list
        | Link             of CSSProperty list
        | NthChild         of string * CSSProperty list
        | NthLastChild     of string * CSSProperty list
        | NthLastOfType    of string * CSSProperty list
        | NthOfType        of string * CSSProperty list
        | OnlyChild        of CSSProperty list
        | OnlyOfType       of CSSProperty list
        | Optional         of CSSProperty list
        | OutOfRange       of CSSProperty list
        | ReadOnly         of CSSProperty list
        | ReadWrite        of CSSProperty list
        | Required         of CSSProperty list
        | Target           of CSSProperty list
        | Valid            of CSSProperty list
        | Visited          of CSSProperty list
        | FirstChild       of CSSProperty list

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
        | TextDecorationSkip      of ITextDecorationSkip
        | TextDecorationSkips     of ITextDecorationSkip list
        | TextDecorationSkipInk   of ITextDecorationSkipInk
        | TextTransform           of ITextTransform
        | TextIndent              of ITextIndent
        | TextIndents             of ITextIndent list
        | TextShadow              of ITextShadow
        | TextShadows             of ITextShadow list
        | TextOverflow            of Text.Overflow
        | TextEmphasisColor       of ITextEmphasisColor
        | TextEmphasisPosition    of ITextEmphasisPosition
        | TextEmphasisStyle       of ITextEmphasisStyle
        | TextUnderlineOffset     of ITextUnderlineOffset
        | TextUnderlinePosition   of ITextUnderlinePosition
        | TextUnderlinePositions  of ITextUnderlinePosition * ITextUnderlinePosition

        | BorderStyle       of IBorderStyle
        | BorderStyles      of IBorderStyle list
        | BorderWidth       of IBorderWidth
        | BorderWidths      of IBorderWidth list
        | BorderTopWidth    of IBorderWidth
        | BorderRightWidth  of IBorderWidth
        | BorderBottomWidth of IBorderWidth
        | BorderLeftWidth   of IBorderWidth

        | BorderRadius              of IBorderRadius
        | BorderRadiuses            of IBorderRadius list
        | BorderTopLeftRadius       of IBorderRadius
        | BorderTopLeftRadiuses     of IBorderRadius list
        | BorderTopRightRadius      of IBorderRadius
        | BorderTopRightRadiuses    of IBorderRadius list
        | BorderBottomRightRadius   of IBorderRadius
        | BorderBottomRightRadiuses of IBorderRadius list
        | BorderBottomLeftRadius    of IBorderRadius
        | BorderBottomLeftRadiuses  of IBorderRadius list

        | BorderColor       of IBorderColor
        | BorderColors      of IBorderColor list
        | BorderTopColor    of IBorderColor
        | BorderRightColor  of IBorderColor
        | BorderBottomColor of IBorderColor
        | BorderLeftColor   of IBorderColor

        | Width       of IContentSize
        | MinWidth    of IContentSize
        | MaxWidth    of IContentSize
        | Height      of IContentSize
        | MinHeight   of IContentSize
        | MaxHeight   of IContentSize

        | Perspective of IPerspective

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
        | Position       of Position.Position

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

        | AnimationName            of IAnimationName
        | AnimationNames           of IAnimationName list
        | AnimationDuration        of Time
        | AnimationDurations       of Time list
        | AnimationTimingFunction  of IAnimationTimingFunction
        | AnimationTimingFunctions of IAnimationTimingFunction list
        | AnimationDelay           of Time
        | AnimationDelays          of Time list
        | AnimationIterationCount  of IterationCount
        | AnimationIterationCounts of IterationCount list
        | AnimationDirection       of IAnimationDirection
        | AnimationDirections      of IAnimationDirection list
        | AnimationFillMode        of IAnimationFillMode
        | AnimationFillModes       of IAnimationFillMode list
        | AnimationPlayState       of IAnimationPlayState
        | AnimationPlayStates      of IAnimationPlayState list

        | Transform        of ITransform
        | Transforms       of ITransform list
        | TransformOrigin  of ITransformOrigin
        | TransformOrigins of ITransformOrigin list

        | TransitionDuration        of ITime
        | TransitionDurations       of ITime list
        | TransitionDelay           of ITime
        | TransitionDelays          of ITime list
        | TransitionProperty        of IProperty
        | TransitionProperties      of IProperty list
        | TransitionTimingFunction  of ITimingFunction
        | TransitionTimingFunctions of ITimingFunction List

        | Cursor of ICursor

    let combineAnimationNames (list: IAnimationName list): string = list |> List.map string |> String.concat ", "


    let rec private createCSS (attributeList: CSSProperty list) callback =

        let cssValue (property: Property.Property) value =
            property |> Property.value ==> value

        let psuedoClass (property: Property.Property) cssProperty =
            property |> Property.value |> toPsuedo ==> createCSS cssProperty callback

        let psuedoClassKebab (property: Property.Property) cssProperty =
            property |> Property.toKebabCase |> toPsuedo ==> createCSS cssProperty callback

        let psuedoClassFunc (property: Property.Property) content cssProperty =
            sprintf ":%s(%s)" (Property.value property) content ==> createCSS cssProperty callback

        let psuedoClassFuncKebab (property: Property.Property) content cssProperty =
            sprintf ":%s(%s)" (Property.toKebabCase property) content ==> createCSS cssProperty callback

        attributeList
        |> List.map (
            function
                | Label l -> Property.value Property.Label ==> l

                | Selector (s, ss)    -> SelectorValue.selector s ==> createCSS ss callback

                | MediaProperty    (f, p)     -> sprintf "@media %s" <| MediaValue.mediaFeature f                              ==> createCSS p callback
                | MediaForProperty (d, f, p)  -> sprintf "@media %s %s" (MediaValue.deviceLabel d) (MediaValue.mediaFeature f) ==> createCSS p callback

                | Color c            -> Property.value Property.Color ==> Color.value c

                | BackgroundColor       bc -> cssValue Property.BackgroundColor <| Color.value bc

                | BackgroundImage       bi -> cssValue Property.BackgroundImage      <| BackgroundValues.backgroundImage bi
                | BackgroundPosition    b  -> cssValue Property.BackgroundPosition   <| BackgroundValues.position b
                | BackgroundPositions   bs -> cssValue Property.BackgroundPosition   <| combineWs BackgroundValues.position bs
                | BackgroundOrigin      b  -> cssValue Property.BackgroundOrigin     <| BackgroundValues.backgroundOrigin b
                | BackgroundClip        b  -> cssValue Property.BackgroundClip       <| BackgroundValues.backgroundClip b
                | BackgroundRepeat      b  -> cssValue Property.BackgroundRepeat     <| BackgroundValues.backgroundRepeat b
                | BackgroundRepeats     bs -> cssValue Property.BackgroundRepeat     <| combineWs BackgroundValues.backgroundRepeat bs
                | BackgroundSize        b  -> cssValue Property.BackgroundSize       <| BackgroundValues.backgroundSize b
                | BackgroundSizes       bs -> cssValue Property.BackgroundSize       <| combineWs BackgroundValues.backgroundSize bs
                | BackgroundAttachment  b  -> cssValue Property.BackgroundAttachment <| BackgroundValues.backgroundAttachment b
                | BackgroundAttachments bs -> cssValue Property.BackgroundAttachment <| combineWs BackgroundValues.backgroundAttachment bs

                | Active         a      -> psuedoClass          Property.Active a
                | AnyLink        a      -> psuedoClassKebab     Property.AnyLink a
                | Blank          b      -> psuedoClass          Property.Blank b
                | Checked        c      -> psuedoClass          Property.Checked c
                | Disabled       d      -> psuedoClass          Property.Disabled d
                | Empty          e      -> psuedoClass          Property.Empty e
                | Enabled        e      -> psuedoClass          Property.Enabled e
                | FirstChild     f      -> psuedoClassKebab     Property.FirstChild f
                | FirstOfType    f      -> psuedoClassKebab     Property.FirstOfType f
                | Focus          f      -> psuedoClass          Property.Focus f
                | Hover          h      -> psuedoClass          Property.Hover h
                | Visited        v      -> psuedoClass          Property.Visited v
                | Indeterminate  v      -> psuedoClass          Property.Indeterminate v
                | Invalid        v      -> psuedoClass          Property.Invalid v
                | Lang          (ls, l) -> psuedoClassFunc      Property.Lang ls l
                | LastChild      l      -> psuedoClassKebab     Property.LastChild l
                | LastOfType     f      -> psuedoClassKebab     Property.LastOfType f
                | Link           l      -> psuedoClass          Property.Link l
                | NthChild      (ns, n) -> psuedoClassFuncKebab Property.NthChild ns n
                | NthLastChild  (ns, n) -> psuedoClassFuncKebab Property.NthLastChild ns n
                | NthLastOfType (ns, n) -> psuedoClassFuncKebab Property.NthLastOfType ns n
                | NthOfType     (ns, n) -> psuedoClassFuncKebab Property.NthOfType ns n
                | OnlyChild      a      -> psuedoClassKebab     Property.OnlyChild a
                | OnlyOfType     a      -> psuedoClassKebab     Property.OnlyOfType a
                | Optional       o      -> psuedoClass          Property.Optional o
                | OutOfRange     o      -> psuedoClassKebab     Property.OutOfRange o
                | ReadOnly       r      -> psuedoClassKebab     Property.ReadOnly r
                | ReadWrite      r      -> psuedoClassKebab     Property.ReadWrite r
                | Required       r      -> psuedoClassKebab     Property.Required r
                | Target         t      -> psuedoClass          Property.Target t
                | Valid          v      -> psuedoClass          Property.Valid v

                | FontSize              f  -> cssValue Property.FontSize             <| FontValues.fontSize f
                | FontStyle             f  -> cssValue Property.FontStyle            <| FontValues.fontStyle f
                | FontStretch           f  -> cssValue Property.FontStretch          <| FontValues.fontStretch f
                | FontWeight            f  -> cssValue Property.FontWeight           <| FontValues.fontWeight f
                | LineHeight            l  -> cssValue Property.LineHeight           <| FontValues.lineHeight l
                | FontFamily            f  -> cssValue Property.FontFamily           <| FontValues.fontFamily f
                | FontFamilies          fs -> cssValue Property.FontFamily           <| combineComma FontValues.fontFamily fs
                | FontFeatureSetting    f  -> cssValue Property.FontFeatureSettings  <| FontValues.fontFeatureSetting f
                | FontFeatureSettings   fs -> cssValue Property.FontFeatureSettings  <| combineComma FontValues.fontFeatureSetting fs
                | FontVariantNumeric    f  -> cssValue Property.FontVariantNumeric   <| FontValues.fontVariantNumeric f
                | FontVariantNumerics   fs -> cssValue Property.FontVariantNumeric   <| combineWs FontValues.fontVariantNumeric fs
                | FontVariantCaps       f  -> cssValue Property.FontVariantCaps      <| FontValues.fontVariantCap f
                | FontVariantEastAsian  f  -> cssValue Property.FontVariantEastAsian <| FontValues.fontVariantEastAsian f
                | FontVariantEastAsians fs -> cssValue Property.FontVariantEastAsian <| combineWs FontValues.fontVariantEastAsian fs
                | FontVariantLigatures  f  -> cssValue Property.FontVariantLigatures <| FontValues.fontVariantLigature f

                | TextAlign               t       -> cssValue Property.TextAlign               <| TextValue.align t
                | TextDecorationLine      t       -> cssValue Property.TextDecorationLine      <| TextValue.decorationLine t
                | TextDecorationLines     ts      -> cssValue Property.TextDecorationLine      <| combineWs TextValue.decorationLine ts
                | TextDecorationColor     t       -> cssValue Property.TextDecorationColor     <| Color.value t
                | TextDecorationThickness t       -> cssValue Property.TextDecorationThickness <| TextValue.decorationThickness t
                | TextDecorationStyle     t       -> cssValue Property.TextDecorationStyle     <| TextValue.decorationStyle t
                | TextDecorationSkip      t       -> cssValue Property.TextDecorationSkip      <| TextValue.decorationSkip t
                | TextDecorationSkips     ts      -> cssValue Property.TextDecorationSkip      <| combineWs TextValue.decorationSkip ts
                | TextDecorationSkipInk   t       -> cssValue Property.TextDecorationSkipInk   <| TextValue.decorationSkipInk t
                | TextTransform           t       -> cssValue Property.TextTransform           <| TextValue.transform t
                | TextIndent              t       -> cssValue Property.TextIndent              <| TextValue.indent t
                | TextIndents             ts      -> cssValue Property.TextIndent              <| combineWs TextValue.indent ts
                | TextShadow              t       -> cssValue Property.TextShadow              <| TextValue.shadow t
                | TextShadows             ts      -> cssValue Property.TextShadow              <| combineComma TextValue.shadow ts
                | TextOverflow            t       -> cssValue Property.TextOverflow            <| TextValue.overflow t
                | TextEmphasisColor       t       -> cssValue Property.TextEmphasisColor       <| TextValue.emphasisColor t
                | TextEmphasisPosition    t       -> cssValue Property.TextEmphasisPosition    <| TextValue.emphasisPosition t
                | TextEmphasisStyle       t       -> cssValue Property.TextEmphasisStyle       <| TextValue.emphasisStyle t
                | TextUnderlineOffset     t       -> cssValue Property.TextUnderlineOffset     <| TextValue.underlineOffset t
                | TextUnderlinePosition   t       -> cssValue Property.TextUnderlinePosition   <| TextValue.underlinePosition t
                | TextUnderlinePositions (t1, t2) -> cssValue Property.TextUnderlinePosition   <| sprintf "%s %s" (TextValue.underlinePosition t1) (TextValue.underlinePosition t2)

                | BorderStyle  bs  -> cssValue Property.BorderStyle <| BorderValue.borderStyle bs
                | BorderStyles bss -> cssValue Property.BorderStyle <| combineWs BorderValue.borderStyle bss

                | BorderWidth       bw  -> cssValue Property.BorderWidth       <| BorderValue.borderWidth bw
                | BorderWidths      bws -> cssValue Property.BorderWidth       <| combineWs BorderValue.borderWidth bws
                | BorderTopWidth    bw  -> cssValue Property.BorderTopWidth    <| BorderValue.borderWidth bw
                | BorderRightWidth  bw  -> cssValue Property.BorderRightWidth  <| BorderValue.borderWidth bw
                | BorderBottomWidth bw  -> cssValue Property.BorderBottomWidth <| BorderValue.borderWidth bw
                | BorderLeftWidth   bw  -> cssValue Property.BorderLeftWidth   <| BorderValue.borderWidth  bw

                | BorderRadius              br -> cssValue Property.BorderRadius            <| BorderValue.borderRadius br
                | BorderRadiuses            br -> cssValue Property.BorderRadius            <| combineWs BorderValue.borderRadius br
                | BorderTopLeftRadius       br -> cssValue Property.BorderTopLeftRadius     <| BorderValue.borderRadius br
                | BorderTopLeftRadiuses     br -> cssValue Property.BorderTopLeftRadius     <| combineWs BorderValue.borderRadius br
                | BorderTopRightRadius      br -> cssValue Property.BorderTopRightRadius    <| BorderValue.borderRadius br
                | BorderTopRightRadiuses    br -> cssValue Property.BorderTopRightRadius    <| combineWs BorderValue.borderRadius br
                | BorderBottomRightRadius   br -> cssValue Property.BorderBottomRightRadius <| BorderValue.borderRadius br
                | BorderBottomRightRadiuses br -> cssValue Property.BorderBottomRightRadius <| combineWs BorderValue.borderRadius br
                | BorderBottomLeftRadius    br -> cssValue Property.BorderBottomLeftRadius  <| BorderValue.borderRadius br
                | BorderBottomLeftRadiuses  br -> cssValue Property.BorderBottomLeftRadius  <| combineWs BorderValue.borderRadius br

                | BorderColor       bc  -> cssValue Property.BorderColor       <| BorderValue.borderColor bc
                | BorderColors      bcs -> cssValue Property.BorderColor       <| combineWs BorderValue.borderColor bcs
                | BorderTopColor    bc  -> cssValue Property.BorderTopColor    <| BorderValue.borderColor bc
                | BorderRightColor  bc  -> cssValue Property.BorderRightColor  <| BorderValue.borderColor bc
                | BorderBottomColor bc  -> cssValue Property.BorderBottomColor <| BorderValue.borderColor bc
                | BorderLeftColor   bc  -> cssValue Property.BorderLeftColor   <| BorderValue.borderColor bc

                | Width     w -> cssValue Property.Width     <| ContentSize.value w
                | MinWidth  w -> cssValue Property.MinWidth  <| ContentSize.value w
                | MaxWidth  w -> cssValue Property.MaxWidth  <| ContentSize.value w
                | Height    h -> cssValue Property.Height    <| ContentSize.value h
                | MinHeight h -> cssValue Property.MinHeight <| ContentSize.value h
                | MaxHeight h -> cssValue Property.MaxHeight <| ContentSize.value h

                | Perspective p -> cssValue Property.Perspective <| PerspectiveValue.perspective p

                | Display        d -> cssValue Property.Display        <| DisplayValue.display d
                | FlexDirection  f -> cssValue Property.FlexDirection  <| FlexValue.flexDirection f
                | FlexWrap       f -> cssValue Property.FlexWrap       <| FlexValue.flexWrap f
                | FlexBasis      f -> cssValue Property.FlexBasis      <| FlexValue.flexBasis f
                | JustifyContent j -> cssValue Property.JustifyContent <| FlexValue.justifyContent j
                | AlignItems     a -> cssValue Property.AlignItems     <| FlexValue.alignItems a
                | AlignContent   a -> cssValue Property.AlignContent   <| FlexValue.alignContent a
                | Order          o -> cssValue Property.Order          <| FlexValue.order o
                | FlexGrow       f -> cssValue Property.FlexGrow       <| FlexValue.flexGrow f
                | FlexShrink     f -> cssValue Property.FlexShrink     <| FlexValue.flexShrink f
                | AlignSelf      a -> cssValue Property.AlignSelf      <| FlexValue.alignSelf a
                | VerticalAlign  v -> cssValue Property.VerticalAlign  <| VerticalAlignValue.verticalAlign v
                | Visibility     v -> cssValue Property.Visibility     <| VisibilityValue.visibility v
                | Opacity        o -> cssValue Property.Opacity        <| OpacityValue.opacity o
                | Position       p -> cssValue Property.Position       <| PositionValue.position p

                | MarginTop    m  -> cssValue Property.MarginTop    <| MarginValue.margin m
                | MarginRight  m  -> cssValue Property.MarginRight  <| MarginValue.margin m
                | MarginBottom m  -> cssValue Property.MarginBottom <| MarginValue.margin m
                | MarginLeft   m  -> cssValue Property.MarginLeft   <| MarginValue.margin m
                | Margin       m  -> cssValue Property.Margin       <| MarginValue.margin m
                | Margins      ms -> cssValue Property.Margin       <| combineWs MarginValue.margin ms

                | PaddingTop    m  -> cssValue Property.PaddingTop    <| PaddingValue.padding m
                | PaddingRight  m  -> cssValue Property.PaddingRight  <| PaddingValue.padding m
                | PaddingBottom m  -> cssValue Property.PaddingBottom <| PaddingValue.padding m
                | PaddingLeft   m  -> cssValue Property.PaddingLeft   <| PaddingValue.padding m
                | Padding       m  -> cssValue Property.Padding       <| PaddingValue.padding m
                | Paddings      ms -> cssValue Property.Padding       <| combineWs PaddingValue.padding ms

                | AnimationName            n   -> cssValue Property.AnimationName           <| AnimationValue.name n
                | AnimationNames           ns  -> cssValue Property.AnimationName           <| combineComma AnimationValue.name ns
                | AnimationDuration        d   -> cssValue Property.AnimationDuration       <| Units.Time.value d
                | AnimationDurations       ds  -> cssValue Property.AnimationDuration       <| combineComma Units.Time.value ds
                | AnimationTimingFunction  t   -> cssValue Property.AnimationTimingFunction <| AnimationValue.timingFunction t
                | AnimationTimingFunctions ts  -> cssValue Property.AnimationTimingFunction <| combineComma AnimationValue.timingFunction ts
                | AnimationDelay           d   -> cssValue Property.AnimationDelay          <| Units.Time.value d
                | AnimationDelays          ds  -> cssValue Property.AnimationDelay          <| combineComma Units.Time.value ds
                | AnimationIterationCount  i   -> cssValue Property.AnimationIterationCount <| AnimationValue.iterationCount i
                | AnimationIterationCounts is  -> cssValue Property.AnimationIterationCount <| combineComma AnimationValue.iterationCount is
                | AnimationDirection       d   -> cssValue Property.AnimationDirection      <| AnimationValue.direction d
                | AnimationDirections      ds  -> cssValue Property.AnimationDirection      <| combineComma AnimationValue.direction ds
                | AnimationFillMode        f   -> cssValue Property.AnimationFillMode       <| AnimationValue.fillMode f
                | AnimationFillModes       fs  -> cssValue Property.AnimationFillMode       <| combineComma AnimationValue.fillMode fs
                | AnimationPlayState       p   -> cssValue Property.AnimationPlayState      <| AnimationValue.playState p
                | AnimationPlayStates      ps  -> cssValue Property.AnimationPlayState      <| combineComma AnimationValue.playState ps

                | Transform       t   -> cssValue Property.Transform       <| TransformValue.transform t
                | Transforms      ts  -> cssValue Property.Transform       <| combineWs TransformValue.transform ts
                | TransformOrigin t   -> cssValue Property.TransformOrigin <| TransformValue.transformOrigin t
                | TransformOrigins ts -> cssValue Property.TransformOrigin <| combineWs TransformValue.transformOrigin ts

                | TransitionDelay           t  -> cssValue Property.TransitionDelay          <| TransitionValue.time t
                | TransitionDelays          ts -> cssValue Property.TransitionDelay          <| combineComma TransitionValue.time ts
                | TransitionDuration        t  -> cssValue Property.TransitionDuration       <| TransitionValue.time t
                | TransitionDurations       ts -> cssValue Property.TransitionDuration       <| combineComma TransitionValue.time ts
                | TransitionProperty        t  -> cssValue Property.TransitionProperty       <| TransitionValue.property t
                | TransitionProperties      ts -> cssValue Property.TransitionProperty       <| combineComma TransitionValue.property ts
                | TransitionTimingFunction  t  -> cssValue Property.TransitionTimingFunction <| TransitionValue.timingFunction t
                | TransitionTimingFunctions ts -> cssValue Property.TransitionTimingFunction <| combineComma TransitionValue.timingFunction ts

                | Cursor c -> cssValue Property.Cursor <| CursorValue.cursor c
        )
        |> callback

    let createCSSRecord (attributeList: CSSProperty list) = createCSS attributeList id
    let createCSSObject (attributeList: CSSProperty list) = createCSS attributeList createObj