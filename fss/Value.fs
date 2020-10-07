namespace Fss

open Fable.Core
open Fable.Core.JsInterop

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
        | Current          of CSSProperty list
        | Disabled         of CSSProperty list
        | Drop             of CSSProperty list
        | Empty            of CSSProperty list
        | Enabled          of CSSProperty list
        | First            of CSSProperty list
        | FirstOfType      of CSSProperty list
        | Fullscreen       of CSSProperty list
        | Future           of CSSProperty list
        | Focus            of CSSProperty list
        | FocusVisible     of CSSProperty list
        | FocusWithin      of CSSProperty list
        | Has              of CSSProperty list
        | Host             of CSSProperty list
        | HostElement      of CSSProperty list
        | HostContext      of CSSProperty list
        | Hover            of CSSProperty list
        | Indeterminate    of CSSProperty list
        | InRange          of CSSProperty list
        | Invalid          of CSSProperty list
        | Is               of CSSProperty list
        | Lang             of CSSProperty list
        | LastChild        of CSSProperty list
        | LastOfType       of CSSProperty list
        | LeftPSUEDO       of CSSProperty list
        | Link             of CSSProperty list
        | LocalLink        of CSSProperty list
        | Not              of CSSProperty list
        | NthChild         of CSSProperty list
        | NthCol           of CSSProperty list
        | NthLastChild     of CSSProperty list
        | NthLastCol       of CSSProperty list
        | NthLastOfType    of CSSProperty list
        | NthOfType        of CSSProperty list
        | OnlyChild        of CSSProperty list
        | OnlyOfType       of CSSProperty list
        | Optional         of CSSProperty list
        | OutOfRange       of CSSProperty list
        | Past             of CSSProperty list
        | PlaceholderShown of CSSProperty list
        | ReadOnly         of CSSProperty list
        | ReadWrite        of CSSProperty list
        | Required         of CSSProperty list
        | RightPSUEDO      of CSSProperty list
        | Root             of CSSProperty list
        | Scope            of CSSProperty list
        | State            of CSSProperty list
        | Target           of CSSProperty list
        | TargetWithin     of CSSProperty list
        | UserInvalid      of CSSProperty list
        | Valid            of CSSProperty list
        | Visited          of CSSProperty list
        | Where            of CSSProperty list

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
        attributeList
        |> List.map (
            function
                | Selector (s, ss)    -> SelectorValue.selector s ==> createCSS ss callback

                | MediaProperty    (f, p)     -> sprintf "@media %s" <| MediaValue.mediaFeature f                              ==> createCSS p callback
                | MediaForProperty (d, f, p)  -> sprintf "@media %s %s" (MediaValue.deviceLabel d) (MediaValue.mediaFeature f) ==> createCSS p callback

                | Label l            -> Property.value Property.Label ==> l

                | Color c            -> Property.value Property.Color ==> Color.value c

                | BackgroundColor       bc -> Property.value Property.BackgroundColor      ==> Color.value bc
                | BackgroundImage       bi -> Property.value Property.BackgroundImage      ==> BackgroundValues.backgroundImage bi
                | BackgroundPosition    b  -> Property.value Property.BackgroundPosition   ==> BackgroundValues.position b
                | BackgroundPositions   bs -> Property.value Property.BackgroundPosition   ==> combineWs BackgroundValues.position bs
                | BackgroundOrigin      b  -> Property.value Property.BackgroundOrigin     ==> BackgroundValues.backgroundOrigin b
                | BackgroundClip        b  -> Property.value Property.BackgroundClip       ==> BackgroundValues.backgroundClip b
                | BackgroundRepeat      b  -> Property.value Property.BackgroundRepeat     ==> BackgroundValues.backgroundRepeat b
                | BackgroundRepeats     bs -> Property.value Property.BackgroundRepeat     ==> combineWs BackgroundValues.backgroundRepeat bs
                | BackgroundSize        b  -> Property.value Property.BackgroundSize       ==> BackgroundValues.backgroundSize b
                | BackgroundSizes       bs -> Property.value Property.BackgroundSize       ==> combineWs BackgroundValues.backgroundSize bs
                | BackgroundAttachment  b  -> Property.value Property.BackgroundAttachment ==> BackgroundValues.backgroundAttachment b
                | BackgroundAttachments bs -> Property.value Property.BackgroundAttachment ==> combineWs BackgroundValues.backgroundAttachment bs

                | Active         a -> Property.Active   |> Property.value               |> toPsuedo ==> createCSS a callback
                | AnyLink        a -> Property.AnyLink  |> Property.propertyToKebabCase |> toPsuedo ==> createCSS a callback
                | Blank          b -> Property.Blank    |> Property.value               |> toPsuedo ==> createCSS b callback
                | Checked        c -> Property.Checked  |> Property.value               |> toPsuedo ==> createCSS c callback
                | Disabled       d -> Property.Disabled |> Property.value               |> toPsuedo ==> createCSS d callback
                | Empty          e -> Property.Empty    |> Property.value               |> toPsuedo ==> createCSS e callback
                | Enabled        e -> Property.Enabled  |> Property.value               |> toPsuedo ==> createCSS e callback
                | Focus          f -> Property.Focus    |> Property.value               |> toPsuedo ==> createCSS f callback
                | Hover          h -> Property.Hover    |> Property.value               |> toPsuedo ==> createCSS h callback
                | Visited        v -> Property.Visited  |> Property.value               |> toPsuedo ==> createCSS v callback
                | Indeterminate  v -> Property.Visited  |> Property.value               |> toPsuedo ==> createCSS v callback



                (*    indeterminate, invalid, lang, lastChild, lastOfType, link, nthChild, nthLastChild, nthLastOfType, nthOfType, onlyChild, onlyOfType, optional, outOfRange, readWrite, required, root, scope, target, valid  *)

                // Psuedo element?
                // | FirstChild f -> Property.FirstChild |> Property.value               |> toPsuedo ==> createCSS f callback
                // | FirstOfType f    -> Property.Enabled    |> Property.value               |> toPsuedo ==> createCSS f callback
                // | Fullscreen f    -> Property.Enabled    |> Property.value               |> toPsuedo ==> createCSS f callback

                | FontSize              f  -> Property.value Property.FontSize             ==> FontValues.fontSize f
                | FontStyle             f  -> Property.value Property.FontStyle            ==> FontValues.fontStyle f
                | FontStretch           f  -> Property.value Property.FontStretch          ==> FontValues.fontStretch f
                | FontWeight            f  -> Property.value Property.FontWeight           ==> FontValues.fontWeight f
                | LineHeight            l  -> Property.value Property.LineHeight           ==> FontValues.lineHeight l
                | FontFamily            f  -> Property.value Property.FontFamily           ==> FontValues.fontFamily f
                | FontFamilies          fs -> Property.value Property.FontFamily           ==> combineComma FontValues.fontFamily fs
                | FontFeatureSetting    f  -> Property.value Property.FontFeatureSettings  ==> FontValues.fontFeatureSetting f
                | FontFeatureSettings   fs -> Property.value Property.FontFeatureSettings  ==> combineComma FontValues.fontFeatureSetting fs
                | FontVariantNumeric    f  -> Property.value Property.FontVariantNumeric   ==> FontValues.fontVariantNumeric f
                | FontVariantNumerics   fs -> Property.value Property.FontVariantNumeric   ==> combineWs FontValues.fontVariantNumeric fs
                | FontVariantCaps       f  -> Property.value Property.FontVariantCaps      ==> FontValues.fontVariantCap f
                | FontVariantEastAsian  f  -> Property.value Property.FontVariantEastAsian ==> FontValues.fontVariantEastAsian f
                | FontVariantEastAsians fs -> Property.value Property.FontVariantEastAsian ==> combineWs FontValues.fontVariantEastAsian fs
                | FontVariantLigatures  f  -> Property.value Property.FontVariantLigatures ==> FontValues.fontVariantLigature f

                | TextAlign               t      -> Property.value Property.TextAlign               ==> TextValue.align t
                | TextDecorationLine      t      -> Property.value Property.TextDecorationLine      ==> TextValue.decorationLine t
                | TextDecorationLines     ts     -> Property.value Property.TextDecorationLine      ==> combineWs TextValue.decorationLine ts
                | TextDecorationColor     t      -> Property.value Property.TextDecorationColor     ==> Color.value t
                | TextDecorationThickness t      -> Property.value Property.TextDecorationThickness ==> TextValue.decorationThickness t
                | TextDecorationStyle     t      -> Property.value Property.TextDecorationStyle     ==> TextValue.decorationStyle t
                | TextDecorationSkip      t      -> Property.value Property.TextDecorationSkip      ==> TextValue.decorationSkip t
                | TextDecorationSkips     ts     -> Property.value Property.TextDecorationSkip      ==> combineWs TextValue.decorationSkip ts
                | TextDecorationSkipInk   t      -> Property.value Property.TextDecorationSkipInk   ==> TextValue.decorationSkipInk t
                | TextTransform           t      -> Property.value Property.TextTransform           ==> TextValue.transform t
                | TextIndent              t      -> Property.value Property.TextIndent              ==> TextValue.indent t
                | TextIndents             ts     -> Property.value Property.TextIndent              ==> combineWs TextValue.indent ts
                | TextShadow              t      -> Property.value Property.TextShadow              ==> TextValue.shadow t
                | TextShadows             ts     -> Property.value Property.TextShadow              ==> combineComma TextValue.shadow ts
                | TextOverflow            t      -> Property.value Property.TextOverflow            ==> TextValue.overflow t
                | TextEmphasisColor       t      -> Property.value Property.TextEmphasisColor       ==> TextValue.emphasisColor t
                | TextEmphasisPosition    t      -> Property.value Property.TextEmphasisPosition    ==> TextValue.emphasisPosition t
                | TextEmphasisStyle       t      -> Property.value Property.TextEmphasisStyle       ==> TextValue.emphasisStyle t
                | TextUnderlineOffset     t      -> Property.value Property.TextUnderlineOffset     ==> TextValue.underlineOffset t
                | TextUnderlinePosition   t      -> Property.value Property.TextUnderlinePosition   ==> TextValue.underlinePosition t
                | TextUnderlinePositions (t1, t2)-> Property.value Property.TextUnderlinePosition   ==> sprintf "%s %s" (TextValue.underlinePosition t1) (TextValue.underlinePosition t2)

                | BorderStyle  bs  -> Property.value Property.BorderStyle ==> BorderValue.borderStyle bs
                | BorderStyles bss -> Property.value Property.BorderStyle ==> combineWs BorderValue.borderStyle bss

                | BorderWidth       bw  -> Property.value Property.BorderWidth       ==> BorderValue.borderWidth bw
                | BorderWidths      bws -> Property.value Property.BorderWidth       ==> combineWs BorderValue.borderWidth bws
                | BorderTopWidth    bw  -> Property.value Property.BorderTopWidth    ==> BorderValue.borderWidth bw
                | BorderRightWidth  bw  -> Property.value Property.BorderRightWidth  ==> BorderValue.borderWidth bw
                | BorderBottomWidth bw  -> Property.value Property.BorderBottomWidth ==> BorderValue.borderWidth bw
                | BorderLeftWidth   bw  -> Property.value Property.BorderLeftWidth   ==> BorderValue.borderWidth  bw

                | BorderRadius              br -> Property.value Property.BorderRadius            ==> BorderValue.borderRadius br
                | BorderRadiuses            br -> Property.value Property.BorderRadius            ==> combineWs BorderValue.borderRadius br
                | BorderTopLeftRadius       br -> Property.value Property.BorderTopLeftRadius     ==> BorderValue.borderRadius br
                | BorderTopLeftRadiuses     br -> Property.value Property.BorderTopLeftRadius     ==> combineWs BorderValue.borderRadius br
                | BorderTopRightRadius      br -> Property.value Property.BorderTopRightRadius    ==> BorderValue.borderRadius br
                | BorderTopRightRadiuses    br -> Property.value Property.BorderTopRightRadius    ==> combineWs BorderValue.borderRadius br
                | BorderBottomRightRadius   br -> Property.value Property.BorderBottomRightRadius ==> BorderValue.borderRadius br
                | BorderBottomRightRadiuses br -> Property.value Property.BorderBottomRightRadius ==> combineWs BorderValue.borderRadius br
                | BorderBottomLeftRadius    br -> Property.value Property.BorderBottomLeftRadius  ==> BorderValue.borderRadius br
                | BorderBottomLeftRadiuses  br -> Property.value Property.BorderBottomLeftRadius  ==> combineWs BorderValue.borderRadius br

                | BorderColor       bc  -> Property.value Property.BorderColor       ==> BorderValue.borderColor bc
                | BorderColors      bcs -> Property.value Property.BorderColor       ==> combineWs BorderValue.borderColor bcs
                | BorderTopColor    bc  -> Property.value Property.BorderTopColor    ==> BorderValue.borderColor bc
                | BorderRightColor  bc  -> Property.value Property.BorderRightColor  ==> BorderValue.borderColor bc
                | BorderBottomColor bc  -> Property.value Property.BorderBottomColor ==> BorderValue.borderColor bc
                | BorderLeftColor   bc  -> Property.value Property.BorderLeftColor   ==> BorderValue.borderColor bc

                | Width     w -> Property.value Property.Width     ==> ContentSize.value w
                | MinWidth  w -> Property.value Property.MinWidth  ==> ContentSize.value w
                | MaxWidth  w -> Property.value Property.MaxWidth  ==> ContentSize.value w
                | Height    h -> Property.value Property.Height    ==> ContentSize.value h
                | MinHeight h -> Property.value Property.MinHeight ==> ContentSize.value h
                | MaxHeight h -> Property.value Property.MaxHeight ==> ContentSize.value h

                | Perspective p -> Property.value Property.Perspective ==> PerspectiveValue.perspective p

                | Display        d -> Property.value Property.Display        ==> DisplayValue.display d
                | FlexDirection  f -> Property.value Property.FlexDirection  ==> FlexValue.flexDirection f
                | FlexWrap       f -> Property.value Property.FlexWrap       ==> FlexValue.flexWrap f
                | FlexBasis      f -> Property.value Property.FlexBasis      ==> FlexValue.flexBasis f
                | JustifyContent j -> Property.value Property.JustifyContent ==> FlexValue.justifyContent j
                | AlignItems     a -> Property.value Property.AlignItems     ==> FlexValue.alignItems a
                | AlignContent   a -> Property.value Property.AlignContent   ==> FlexValue.alignContent a
                | Order          o -> Property.value Property.Order          ==> FlexValue.order o
                | FlexGrow       f -> Property.value Property.FlexGrow       ==> FlexValue.flexGrow f
                | FlexShrink     f -> Property.value Property.FlexShrink     ==> FlexValue.flexShrink f
                | AlignSelf      a -> Property.value Property.AlignSelf      ==> FlexValue.alignSelf a
                | VerticalAlign  v -> Property.value Property.VerticalAlign  ==> VerticalAlignValue.verticalAlign v
                | Visibility     v -> Property.value Property.Visibility     ==> VisibilityValue.visibility v
                | Opacity        o -> Property.value Property.Opacity        ==> OpacityValue.opacity o
                | Position       p -> Property.value Property.Position       ==> PositionValue.position p

                | MarginTop    m  -> Property.value Property.MarginTop    ==> MarginValue.margin m
                | MarginRight  m  -> Property.value Property.MarginRight  ==> MarginValue.margin m
                | MarginBottom m  -> Property.value Property.MarginBottom ==> MarginValue.margin m
                | MarginLeft   m  -> Property.value Property.MarginLeft   ==> MarginValue.margin m
                | Margin       m  -> Property.value Property.Margin       ==> MarginValue.margin m
                | Margins      ms -> Property.value Property.Margin       ==> combineWs MarginValue.margin ms

                | PaddingTop    m  -> Property.value Property.PaddingTop    ==> PaddingValue.padding m
                | PaddingRight  m  -> Property.value Property.PaddingRight  ==> PaddingValue.padding m
                | PaddingBottom m  -> Property.value Property.PaddingBottom ==> PaddingValue.padding m
                | PaddingLeft   m  -> Property.value Property.PaddingLeft   ==> PaddingValue.padding m
                | Padding       m  -> Property.value Property.Padding       ==> PaddingValue.padding m
                | Paddings      ms -> Property.value Property.Padding       ==> combineWs PaddingValue.padding ms

                | AnimationName            n   -> Property.value Property.AnimationName           ==> AnimationValue.name n
                | AnimationNames           ns  -> Property.value Property.AnimationName           ==> combineComma AnimationValue.name ns
                | AnimationDuration        d   -> Property.value Property.AnimationDuration       ==> Units.Time.value d
                | AnimationDurations       ds  -> Property.value Property.AnimationDuration       ==> combineComma Units.Time.value ds
                | AnimationTimingFunction  t   -> Property.value Property.AnimationTimingFunction ==> AnimationValue.timingFunction t
                | AnimationTimingFunctions ts  -> Property.value Property.AnimationTimingFunction ==> combineComma AnimationValue.timingFunction ts
                | AnimationDelay           d   -> Property.value Property.AnimationDelay          ==> Units.Time.value d
                | AnimationDelays          ds  -> Property.value Property.AnimationDelay          ==> combineComma Units.Time.value ds
                | AnimationIterationCount  i   -> Property.value Property.AnimationIterationCount ==> AnimationValue.iterationCount i
                | AnimationIterationCounts is  -> Property.value Property.AnimationIterationCount ==> combineComma AnimationValue.iterationCount is
                | AnimationDirection       d   -> Property.value Property.AnimationDirection      ==> AnimationValue.direction d
                | AnimationDirections      ds  -> Property.value Property.AnimationDirection      ==> combineComma AnimationValue.direction ds
                | AnimationFillMode        f   -> Property.value Property.AnimationFillMode       ==> AnimationValue.fillMode f
                | AnimationFillModes       fs  -> Property.value Property.AnimationFillMode       ==> combineComma AnimationValue.fillMode fs
                | AnimationPlayState       p   -> Property.value Property.AnimationPlayState      ==> AnimationValue.playState p
                | AnimationPlayStates      ps  -> Property.value Property.AnimationPlayState      ==> combineComma AnimationValue.playState ps

                | Transform       t   -> Property.value Property.Transform       ==> TransformValue.transform t
                | Transforms      ts  -> Property.value Property.Transform       ==> combineWs TransformValue.transform ts
                | TransformOrigin t   -> Property.value Property.TransformOrigin ==> TransformValue.transformOrigin t
                | TransformOrigins ts -> Property.value Property.TransformOrigin ==> combineWs TransformValue.transformOrigin ts

                | TransitionDelay           t  -> Property.value Property.TransitionDelay          ==> TransitionValue.time t
                | TransitionDelays          ts -> Property.value Property.TransitionDelay          ==> combineComma TransitionValue.time ts
                | TransitionDuration        t  -> Property.value Property.TransitionDuration       ==> TransitionValue.time t
                | TransitionDurations       ts -> Property.value Property.TransitionDuration       ==> combineComma TransitionValue.time ts
                | TransitionProperty        t  -> Property.value Property.TransitionProperty       ==> TransitionValue.property t
                | TransitionProperties      ts -> Property.value Property.TransitionProperty       ==> combineComma TransitionValue.property ts
                | TransitionTimingFunction  t  -> Property.value Property.TransitionTimingFunction ==> TransitionValue.timingFunction t
                | TransitionTimingFunctions ts -> Property.value Property.TransitionTimingFunction ==> combineComma TransitionValue.timingFunction ts

                | Cursor c -> Property.value Property.Cursor ==> CursorValue.cursor c
        )
        |> (fun x ->
            Fable.Core.JS.console.log(x)
            x)
        |> callback

    let createCSSRecord (attributeList: CSSProperty list) = createCSS attributeList id
    let createCSSObject (attributeList: CSSProperty list) = createCSS attributeList createObj