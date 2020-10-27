namespace Fss

open Fable.Core
open Fable.Core.JsInterop

open BoxSizing
open Fss.Flex
open Types
open Utilities.Helpers
open Animation
open Selector
open Media
open Opacity

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

        | BackgroundColor       of IBackgroundColor
        | BackgroundImage       of IImage
        | BackgroundPosition    of IImagePosition
        | BackgroundPositions   of IImagePosition list
        | BackgroundOrigin      of IBackgroundOrigin
        | BackgroundClip        of IBackgroundClip
        | BackgroundRepeat      of IBackgroundRepeat
        | BackgroundRepeats     of IBackgroundRepeat list
        | BackgroundSize        of IBackgroundSize
        | BackgroundSizes       of IBackgroundSize list
        | BackgroundAttachment  of IBackgroundAttachment
        | BackgroundAttachments of IBackgroundAttachment list

        | BoxSizing of BoxSizing

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

        | After       of CSSProperty list
        | Before      of CSSProperty list
        | FirstLetter of CSSProperty list
        | FirstLine   of CSSProperty list
        | Selection   of CSSProperty list

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
        | BorderTopStyle    of IBorderStyle
        | BorderRightStyle  of IBorderStyle
        | BorderBottomStyle of IBorderStyle
        | BorderLeftStyle   of IBorderStyle

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

        | BorderCollapse of IBorderCollapse
        | BorderSpacing  of IBorderSpacing
        | BorderSpacing2 of IBorderSpacing * IBorderSpacing

        | BorderImageSource  of IImage
        | BorderImageWidth   of IBorderImageWidth
        | BorderImageWidths  of IBorderImageWidth list
        | BorderImageRepeat  of IBorderImageRepeat
        | BorderImageRepeat2 of IBorderImageRepeat * IBorderImageRepeat
        | BorderImageSlice   of IBorderImageSlice
        | BorderImageSlices  of IBorderImageSlice list
        | BorderImageOutset  of IBorderImageOutset
        | BorderImageOutsets of IBorderImageOutset list

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
        | PlaceItems     of IPlaceItems
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
        | AnimationDuration        of Units.Time.Time
        | AnimationDurations       of Units.Time.Time list
        | AnimationTimingFunction  of ITimingFunction
        | AnimationTimingFunctions of ITimingFunction list
        | AnimationDelay           of Units.Time.Time
        | AnimationDelays          of Units.Time.Time list
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

        | ListStyleImage     of IListStyleImage
        | ListStylePosition  of IListStylePosition
        | ListStyleType      of IListStyleType

        | Content of IContent

        | Top    of IPlacement
        | Right  of IPlacement
        | Bottom of IPlacement
        | Left   of IPlacement

        | Float of IFloat

        | Quotes of IQuote

        | OverflowX  of IOverflow
        | OverflowY  of IOverflow
        | OverflowXY of IOverflow * IOverflow

        | GridAutoColumn      of IGridAutoColumns
        | GridAutoColumns     of IGridAutoColumns list
        | GridAutoFlow        of IGridAutoFlow
        | GridAutoFlow2       of IGridAutoFlow * IGridAutoFlow
        | GridAutoRow         of IGridAutoRows
        | GridAutoRows        of IGridAutoRows list
        | GridTemplateAreas   of IGridTemplateAreas
        | GridTemplateColumn  of IGridTemplateColumns
        | GridTemplateColumns of IGridTemplateColumns list
        | GridTemplateRow     of IGridTemplateRows
        | GridTemplateRows    of IGridTemplateRows list
        | GridColumnGap       of IGridColumnGap
        | GridRowGap          of IGridRowGap
        | GridGap             of IGridGap
        | GridRowStart        of IGridRowStart
        | GridRowStarts       of IGridRowStart list
        | GridRowEnd          of IGridRowEnd
        | GridRowEnds         of IGridRowEnd list
        | GridRow             of IGridRow
        | GridColumnStart     of IGridColumnStart
        | GridColumnStarts    of IGridColumnStart list
        | GridColumnEnd       of IGridColumnEnd
        | GridColumnEnds      of IGridColumnEnd list
        | GridColumn          of IGridColumn
        | GridArea            of IGridArea

        | OutlineColor of IOutlineColor
        | OutlineStyle of IOutlineStyle
        | OutlineWidth of IOutlineWidth

        interface IGridRow

    let combineAnimationNames (list: IAnimationName list): string = list |> List.map string |> String.concat ", "

    let rec private createCSS (attributeList: CSSProperty list) callback =
        let cssValue (property: Property.Property) value =
            property |> Property.value ==> value

        let cssValueKebab (property: Property.Property) value =
            property |> Property.toKebabCase ==> value

        let pseudoClass (property: Property.Property) cssProperty =
            property |> Property.value |> toPsuedoClass ==> createCSS cssProperty callback

        let pseudoClassKebab (property: Property.Property) cssProperty =
            property |> Property.toKebabCase |> toPsuedoClass ==> createCSS cssProperty callback

        let pseudoClassFunc (property: Property.Property) content cssProperty =
            sprintf "%s(%s)" (Property.value property) content |> toPsuedoClass ==> createCSS cssProperty callback

        let pseudoClassFuncKebab (property: Property.Property) content cssProperty =
            sprintf "%s(%s)" (Property.toKebabCase property) content |> toPsuedoClass ==> createCSS cssProperty callback

        let pseudoElement (property: Property.Property) cssProperty =
            property |> Property.value |> toPsuedoElement ==> createCSS cssProperty callback

        let pseudoElementKebab (property: Property.Property) cssProperty =
            property |> Property.toKebabCase |> toPsuedoElement ==> createCSS cssProperty callback

        attributeList
        |> List.map (
            function
                | Label l -> Property.value Property.Label ==> l

                | Selector (s, ss)    -> SelectorValue.selector s ==> createCSS ss callback

                | MediaProperty    (f, p)     -> sprintf "@media %s" <| MediaValue.mediaFeature f                              ==> createCSS p callback
                | MediaForProperty (d, f, p)  -> sprintf "@media %s %s" (MediaValue.deviceLabel d) (MediaValue.mediaFeature f) ==> createCSS p callback

                | Color c            -> Property.value Property.Color ==> Color.value c

                | BackgroundColor       bc -> cssValue Property.BackgroundColor      <| ImageValue.color bc
                | BackgroundImage       bi -> cssValue Property.BackgroundImage      <| ImageValue.image bi
                | BackgroundPosition    b  -> cssValue Property.BackgroundPosition   <| ImageValue.position b
                | BackgroundPositions   bs -> cssValue Property.BackgroundPosition   <| combineWs ImageValue.position bs
                | BackgroundOrigin      b  -> cssValue Property.BackgroundOrigin     <| BackgroundValues.origin b
                | BackgroundClip        b  -> cssValue Property.BackgroundClip       <| BackgroundValues.clip b
                | BackgroundRepeat      b  -> cssValue Property.BackgroundRepeat     <| BackgroundValues.repeat b
                | BackgroundRepeats     bs -> cssValue Property.BackgroundRepeat     <| combineWs BackgroundValues.repeat bs
                | BackgroundSize        b  -> cssValue Property.BackgroundSize       <| BackgroundValues.size b
                | BackgroundSizes       bs -> cssValue Property.BackgroundSize       <| combineWs BackgroundValues.size bs
                | BackgroundAttachment  b  -> cssValue Property.BackgroundAttachment <| BackgroundValues.attachment b
                | BackgroundAttachments bs -> cssValue Property.BackgroundAttachment <| combineWs BackgroundValues.attachment bs

                | BoxSizing b -> cssValue Property.BoxSizing <| BoxSizingValue.boxSizing b

                | Active         a      -> pseudoClass          Property.Active        a
                | AnyLink        a      -> pseudoClassKebab     Property.AnyLink       a
                | Blank          b      -> pseudoClass          Property.Blank         b
                | Checked        c      -> pseudoClass          Property.Checked       c
                | Disabled       d      -> pseudoClass          Property.Disabled      d
                | Empty          e      -> pseudoClass          Property.Empty         e
                | Enabled        e      -> pseudoClass          Property.Enabled       e
                | FirstChild     f      -> pseudoClassKebab     Property.FirstChild    f
                | FirstOfType    f      -> pseudoClassKebab     Property.FirstOfType   f
                | Focus          f      -> pseudoClass          Property.Focus         f
                | Hover          h      -> pseudoClass          Property.Hover         h
                | Visited        v      -> pseudoClass          Property.Visited       v
                | Indeterminate  v      -> pseudoClass          Property.Indeterminate v
                | Invalid        v      -> pseudoClass          Property.Invalid       v
                | Lang          (ls, l) -> pseudoClassFunc      Property.Lang          ls l
                | LastChild      l      -> pseudoClassKebab     Property.LastChild     l
                | LastOfType     f      -> pseudoClassKebab     Property.LastOfType    f
                | Link           l      -> pseudoClass          Property.Link          l
                | NthChild      (ns, n) -> pseudoClassFuncKebab Property.NthChild      ns n
                | NthLastChild  (ns, n) -> pseudoClassFuncKebab Property.NthLastChild  ns n
                | NthLastOfType (ns, n) -> pseudoClassFuncKebab Property.NthLastOfType ns n
                | NthOfType     (ns, n) -> pseudoClassFuncKebab Property.NthOfType     ns n
                | OnlyChild      a      -> pseudoClassKebab     Property.OnlyChild     a
                | OnlyOfType     a      -> pseudoClassKebab     Property.OnlyOfType    a
                | Optional       o      -> pseudoClass          Property.Optional      o
                | OutOfRange     o      -> pseudoClassKebab     Property.OutOfRange    o
                | ReadOnly       r      -> pseudoClassKebab     Property.ReadOnly      r
                | ReadWrite      r      -> pseudoClassKebab     Property.ReadWrite     r
                | Required       r      -> pseudoClassKebab     Property.Required      r
                | Target         t      -> pseudoClass          Property.Target        t
                | Valid          v      -> pseudoClass          Property.Valid         v

                | After       a -> pseudoElement      Property.After       a
                | Before      b -> pseudoElement      Property.Before      b
                | FirstLetter f -> pseudoElementKebab Property.FirstLetter f
                | FirstLine   f -> pseudoElementKebab Property.FirstLine   f
                | Selection   s -> pseudoElement      Property.Selection   s

                | FontSize              f  -> cssValue Property.FontSize             <| FontValues.size f
                | FontStyle             f  -> cssValue Property.FontStyle            <| FontValues.style f
                | FontStretch           f  -> cssValue Property.FontStretch          <| FontValues.stretch f
                | FontWeight            f  -> cssValue Property.FontWeight           <| FontValues.weight f
                | LineHeight            l  -> cssValue Property.LineHeight           <| FontValues.lineHeight l
                | FontFamily            f  -> cssValue Property.FontFamily           <| FontValues.family f
                | FontFamilies          fs -> cssValue Property.FontFamily           <| combineComma FontValues.family fs
                | FontFeatureSetting    f  -> cssValue Property.FontFeatureSettings  <| FontValues.featureSetting f
                | FontFeatureSettings   fs -> cssValue Property.FontFeatureSettings  <| combineComma FontValues.featureSetting fs
                | FontVariantNumeric    f  -> cssValue Property.FontVariantNumeric   <| FontValues.variantNumeric f
                | FontVariantNumerics   fs -> cssValue Property.FontVariantNumeric   <| combineWs FontValues.variantNumeric fs
                | FontVariantCaps       f  -> cssValue Property.FontVariantCaps      <| FontValues.variantCap f
                | FontVariantEastAsian  f  -> cssValue Property.FontVariantEastAsian <| FontValues.variantEastAsian f
                | FontVariantEastAsians fs -> cssValue Property.FontVariantEastAsian <| combineWs FontValues.variantEastAsian fs
                | FontVariantLigatures  f  -> cssValue Property.FontVariantLigatures <| FontValues.variantLigature f

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

                | BorderStyle       bs  -> cssValue Property.BorderStyle       <| BorderValue.style bs
                | BorderStyles      bss -> cssValue Property.BorderStyle       <| combineWs BorderValue.style bss
                | BorderTopStyle    bw  -> cssValue Property.BorderTopStyle    <| BorderValue.style bw
                | BorderRightStyle  bw  -> cssValue Property.BorderRightStyle  <| BorderValue.style bw
                | BorderBottomStyle bw  -> cssValue Property.BorderBottomStyle <| BorderValue.style bw
                | BorderLeftStyle   bw  -> cssValue Property.BorderLeftStyle   <| BorderValue.style bw

                | BorderWidth       bw  -> cssValue Property.BorderWidth       <| BorderValue.width bw
                | BorderWidths      bws -> cssValue Property.BorderWidth       <| combineWs BorderValue.width bws
                | BorderTopWidth    bw  -> cssValue Property.BorderTopWidth    <| BorderValue.width bw
                | BorderRightWidth  bw  -> cssValue Property.BorderRightWidth  <| BorderValue.width bw
                | BorderBottomWidth bw  -> cssValue Property.BorderBottomWidth <| BorderValue.width bw
                | BorderLeftWidth   bw  -> cssValue Property.BorderLeftWidth   <| BorderValue.width  bw

                | BorderRadius              br -> cssValue Property.BorderRadius            <| BorderValue.radius br
                | BorderRadiuses            br -> cssValue Property.BorderRadius            <| combineWs BorderValue.radius br
                | BorderTopLeftRadius       br -> cssValue Property.BorderTopLeftRadius     <| BorderValue.radius br
                | BorderTopLeftRadiuses     br -> cssValue Property.BorderTopLeftRadius     <| combineWs BorderValue.radius br
                | BorderTopRightRadius      br -> cssValue Property.BorderTopRightRadius    <| BorderValue.radius br
                | BorderTopRightRadiuses    br -> cssValue Property.BorderTopRightRadius    <| combineWs BorderValue.radius br
                | BorderBottomRightRadius   br -> cssValue Property.BorderBottomRightRadius <| BorderValue.radius br
                | BorderBottomRightRadiuses br -> cssValue Property.BorderBottomRightRadius <| combineWs BorderValue.radius br
                | BorderBottomLeftRadius    br -> cssValue Property.BorderBottomLeftRadius  <| BorderValue.radius br
                | BorderBottomLeftRadiuses  br -> cssValue Property.BorderBottomLeftRadius  <| combineWs BorderValue.radius br

                | BorderColor       bc  -> cssValue Property.BorderColor       <| BorderValue.color bc
                | BorderColors      bcs -> cssValue Property.BorderColor       <| combineWs BorderValue.color bcs
                | BorderTopColor    bc  -> cssValue Property.BorderTopColor    <| BorderValue.color bc
                | BorderRightColor  bc  -> cssValue Property.BorderRightColor  <| BorderValue.color bc
                | BorderBottomColor bc  -> cssValue Property.BorderBottomColor <| BorderValue.color bc
                | BorderLeftColor   bc  -> cssValue Property.BorderLeftColor   <| BorderValue.color bc

                | BorderCollapse b      -> cssValue Property.BorderCollapse <| BorderValue.collapse b
                | BorderSpacing  b      -> cssValue Property.BorderSpacing  <| BorderValue.spacing b
                | BorderSpacing2 (x, y) -> cssValue Property.BorderSpacing  <| sprintf "%s %s" (BorderValue.spacing x) (BorderValue.spacing y)

                | BorderImageSource   b       -> cssValue Property.BorderImageSource <| ImageValue.image b
                | BorderImageWidth    bw      -> cssValue Property.BorderImageWidth  <| BorderValue.imageWidth bw
                | BorderImageWidths   bws     -> cssValue Property.BorderImageWidth  <| combineWs BorderValue.imageWidth bws
                | BorderImageRepeat   b       -> cssValue Property.BorderImageRepeat <| BorderValue.imageRepeat b
                | BorderImageRepeat2 (b1, b2) -> cssValue Property.BorderImageRepeat <| sprintf "%s %s" (BorderValue.imageRepeat b1) (BorderValue.imageRepeat b2)
                | BorderImageSlice    b       -> cssValue Property.BorderImageSlice  <| BorderValue.imageSlice b
                | BorderImageSlices   bs      -> cssValue Property.BorderImageSlice  <| combineWs BorderValue.imageSlice bs
                | BorderImageOutset    b      -> cssValue Property.BorderImageOutset <| BorderValue.imageOutset b
                | BorderImageOutsets   bs     -> cssValue Property.BorderImageOutset <| combineWs BorderValue.imageOutset bs

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
                | PlaceItems     a -> cssValue Property.PlaceItems     <| FlexValue.placeItems a
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
                | AnimationTimingFunction  t   -> cssValue Property.AnimationTimingFunction <| TimingFunctionValue.timingFunction t
                | AnimationTimingFunctions ts  -> cssValue Property.AnimationTimingFunction <| combineComma TimingFunctionValue.timingFunction ts
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

                | TransitionDelay           t  -> cssValue Property.TransitionDelay          <| Units.Time.value t
                | TransitionDelays          ts -> cssValue Property.TransitionDelay          <| combineComma Units.Time.value ts
                | TransitionDuration        t  -> cssValue Property.TransitionDuration       <| Units.Time.value t
                | TransitionDurations       ts -> cssValue Property.TransitionDuration       <| combineComma Units.Time.value ts
                | TransitionProperty        t  -> cssValue Property.TransitionProperty       <| TransitionValue.property t
                | TransitionProperties      ts -> cssValue Property.TransitionProperty       <| combineComma TransitionValue.property ts
                | TransitionTimingFunction  t  -> cssValue Property.TransitionTimingFunction <| TransitionValue.timing t
                | TransitionTimingFunctions ts -> cssValue Property.TransitionTimingFunction <| combineComma TransitionValue.timing ts

                | Cursor c -> cssValue Property.Cursor <| CursorValue.cursor c

                | ListStyleImage     l -> cssValue Property.ListStyleImage    <| ListStyleValue.image l
                | ListStylePosition  l -> cssValue Property.ListStylePosition <| ListStyleValue.position l
                | ListStyleType      l -> cssValue Property.ListStyleType     <| ListStyleValue.styleType l

                | Content c -> cssValue Property.Content <| ContentValue.content c

                | Top    t -> cssValue Property.Top    <| PlacementValue.placement t
                | Right  r -> cssValue Property.Right  <| PlacementValue.placement r
                | Bottom b -> cssValue Property.Bottom <| PlacementValue.placement b
                | Left   l -> cssValue Property.Left   <| PlacementValue.placement l

                | Float   f -> cssValue Property.Float <| FloatValue.float f

                | Quotes q -> cssValue Property.Quotes <| QuotesValue.quotes q

                | OverflowX  o      -> cssValueKebab Property.OverflowX <| OverflowValue.overflow o
                | OverflowY  o      -> cssValueKebab Property.OverflowY <| OverflowValue.overflow o
                | OverflowXY (x, y) -> cssValueKebab Property.Overflow  <| sprintf "%s %s" (OverflowValue.overflow x) (OverflowValue.overflow y)

                | GridAutoColumn      g       -> cssValueKebab Property.GridAutoColumns     <| GridValue.autoColumns g
                | GridAutoColumns     gs      -> cssValueKebab Property.GridAutoColumns     <| combineWs GridValue.autoColumns gs
                | GridAutoRow         g       -> cssValueKebab Property.GridAutoRows        <| GridValue.autoRows g
                | GridAutoRows        gs      -> cssValueKebab Property.GridAutoRows        <| combineWs GridValue.autoRows gs
                | GridAutoFlow        g       -> cssValueKebab Property.GridAutoFlow        <| GridValue.autoFlow g
                | GridAutoFlow2      (g1, g2) -> cssValueKebab Property.GridAutoFlow        <| sprintf "%s %s" (GridValue.autoFlow g1) (GridValue.autoFlow g2)
                | GridTemplateAreas   g       -> cssValueKebab Property.GridTemplateAreas   <| GridValue.templateAreas g
                | GridTemplateColumn  c       -> cssValueKebab Property.GridTemplateColumns <| GridValue.templateColumns c
                | GridTemplateColumns cs      -> cssValueKebab Property.GridTemplateColumns <| combineWs GridValue.templateColumns cs
                | GridTemplateRow     r       -> cssValueKebab Property.GridTemplateRows    <| GridValue.templateRows r
                | GridTemplateRows    rs      -> cssValueKebab Property.GridTemplateRows    <| combineWs GridValue.templateRows rs
                | GridColumnGap       g       -> cssValueKebab Property.GridColumnGap       <| GridValue.columnGap g
                | GridRowGap          g       -> cssValueKebab Property.GridRowGap          <| GridValue.rowGap g
                | GridGap             g       -> cssValueKebab Property.GridGap             <| GridValue.gap g
                | GridRowStart        g       -> cssValueKebab Property.GridRowStart        <| GridValue.rowStart g
                | GridRowStarts       gs      -> cssValueKebab Property.GridRowStart        <| combineWs GridValue.rowStart gs
                | GridRowEnd          g       -> cssValueKebab Property.GridRowEnd          <| GridValue.rowEnd g
                | GridRowEnds         gs      -> cssValueKebab Property.GridRowEnd          <| combineWs GridValue.rowEnd gs
                | GridRow             g       -> cssValueKebab Property.GridRow             <| GridValue.row g
                | GridColumnStart     g       -> cssValueKebab Property.GridColumnStart     <| GridValue.columnStart g
                | GridColumnStarts    gs      -> cssValueKebab Property.GridColumnStart     <| combineWs GridValue.columnStart gs
                | GridColumnEnd       g       -> cssValueKebab Property.GridColumnEnd       <| GridValue.columnEnd g
                | GridColumnEnds      gs      -> cssValueKebab Property.GridColumnEnd       <| combineWs GridValue.columnEnd gs
                | GridColumn          g       -> cssValueKebab Property.GridColumn          <| GridValue.column g
                | GridArea            g       -> cssValueKebab Property.GridArea            <| GridValue.area g

                | OutlineColor        c -> cssValue Property.OutlineColor <| OutlineValue.color c
                | OutlineStyle        c -> cssValue Property.OutlineStyle <| OutlineValue.style c
                | OutlineWidth        c -> cssValue Property.OutlineWidth <| OutlineValue.width c
        )
        |> callback

    let createCSSRecord (attributeList: CSSProperty list) = createCSS attributeList id
    let createCSSObject (attributeList: CSSProperty list) = createCSS attributeList createObj
