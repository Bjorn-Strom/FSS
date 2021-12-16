namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Transition =

    [<RequireQualifiedAccess>]
    module TransitionClasses =
        type TransitionClass(property) =
            inherit CssRule(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-delay
        type TransitionDelay(property) =
            inherit CssRule(property)
            member this.value(time: Time) = (property, time) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duration
        type TransitionDuration(property) =
            inherit CssRule(property)
            member this.value(time: Time) = (property, time) |> Rule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
        type TransitionTimingFunction(property) =
            inherit Animation.AnimationClasses.AnimationTimingFunction(property)
        // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-property
        type TransitionProperty(property) =
            inherit CssRule(property)
            member this.appearance = (property, Property.Appearance) |> Rule

            member this.alignContent =
                (property, Property.AlignContent) |> Rule

            member this.alignItems = (property, Property.AlignItems) |> Rule
            member this.alignSelf = (property, Property.AlignSelf) |> Rule
            member this.all = (property, Property.All) |> Rule

            member this.animationDelay =
                (property, Property.AnimationDelay) |> Rule

            member this.animationDirection =
                (property, Property.AnimationDirection) |> Rule

            member this.animationDuration =
                (property, Property.AnimationDuration) |> Rule

            member this.animationFillMode =
                (property, Property.AnimationFillMode) |> Rule

            member this.animationIterationCount =
                (property, Property.AnimationIterationCount)
                |> Rule

            member this.animationName =
                (property, Property.AnimationName) |> Rule

            member this.animationPlayState =
                (property, Property.AnimationPlayState) |> Rule

            member this.animationTimingFunction =
                (property, Property.AnimationTimingFunction)
                |> Rule

            member this.aspectRatio = (property, Property.AspectRatio) |> Rule

            member this.backfaceVisibility =
                (property, Property.BackfaceVisibility) |> Rule

            member this.backgroundAttachment =
                (property, Property.BackgroundAttachment) |> Rule

            member this.backgroundBlendMode =
                (property, Property.BackgroundBlendMode) |> Rule

            member this.backgroundClip =
                (property, Property.BackgroundClip) |> Rule

            member this.backgroundColor =
                (property, Property.BackgroundColor) |> Rule

            member this.backgroundImage =
                (property, Property.BackgroundImage) |> Rule

            member this.backgroundOrigin =
                (property, Property.BackgroundOrigin) |> Rule

            member this.backgroundPosition =
                (property, Property.BackgroundPosition) |> Rule

            member this.backgroundRepeat =
                (property, Property.BackgroundRepeat) |> Rule

            member this.backgroundSize =
                (property, Property.BackgroundSize) |> Rule

            member this.backdropFilter =
                (property, Property.BackdropFilter) |> Rule

            member this.bleed = (property, Property.Bleed) |> Rule
            member this.border = (property, Property.Border) |> Rule

            member this.borderBottomColor =
                (property, Property.BorderBottomColor) |> Rule

            member this.borderBottomLeftRadius =
                (property, Property.BorderBottomLeftRadius)
                |> Rule

            member this.borderBottomRightRadius =
                (property, Property.BorderBottomRightRadius)
                |> Rule

            member this.borderBottomStyle =
                (property, Property.BorderBottomStyle) |> Rule

            member this.borderBottomWidth =
                (property, Property.BorderBottomWidth) |> Rule

            member this.borderBottom =
                (property, Property.BorderBottom) |> Rule

            member this.borderCollapse =
                (property, Property.BorderCollapse) |> Rule

            member this.borderColor = (property, Property.BorderColor) |> Rule
            member this.borderImage = (property, Property.BorderImage) |> Rule

            member this.borderImageOutset =
                (property, Property.BorderImageOutset) |> Rule

            member this.borderImageRepeat =
                (property, Property.BorderImageRepeat) |> Rule

            member this.borderImageSource =
                (property, Property.BorderImageSource) |> Rule

            member this.borderImageSlice =
                (property, Property.BorderImageSlice) |> Rule

            member this.borderImageWidth =
                (property, Property.BorderImageWidth) |> Rule

            member this.borderLeftColor =
                (property, Property.BorderLeftColor) |> Rule

            member this.borderLeftStyle =
                (property, Property.BorderLeftStyle) |> Rule

            member this.borderLeftWidth =
                (property, Property.BorderLeftWidth) |> Rule

            member this.borderLeft = (property, Property.BorderLeft) |> Rule

            member this.borderRadius =
                (property, Property.BorderRadius) |> Rule

            member this.borderRightColor =
                (property, Property.BorderRightColor) |> Rule

            member this.borderRightStyle =
                (property, Property.BorderRightStyle) |> Rule

            member this.borderRightWidth =
                (property, Property.BorderRightWidth) |> Rule

            member this.borderRight = (property, Property.BorderRight) |> Rule

            member this.borderSpacing =
                (property, Property.BorderSpacing) |> Rule

            member this.borderStyle = (property, Property.BorderStyle) |> Rule

            member this.borderTopColor =
                (property, Property.BorderTopColor) |> Rule

            member this.borderTopLeftRadius =
                (property, Property.BorderTopLeftRadius) |> Rule

            member this.borderTopRightRadius =
                (property, Property.BorderTopRightRadius) |> Rule

            member this.borderTopStyle =
                (property, Property.BorderTopStyle) |> Rule

            member this.borderTopWidth =
                (property, Property.BorderTopWidth) |> Rule

            member this.borderTop = (property, Property.BorderTop) |> Rule
            member this.borderWidth = (property, Property.BorderWidth) |> Rule

            member this.borderBlockColor =
                (property, Property.BorderBlockColor) |> Rule

            member this.bottom = (property, Property.Bottom) |> Rule

            member this.boxDecorationBreak =
                (property, Property.BoxDecorationBreak) |> Rule

            member this.boxShadow = (property, Property.BoxShadow) |> Rule
            member this.boxSizing = (property, Property.BoxSizing) |> Rule
            member this.breakAfter = (property, Property.BreakAfter) |> Rule
            member this.breakBefore = (property, Property.BreakBefore) |> Rule
            member this.breakInside = (property, Property.BreakInside) |> Rule
            member this.captionSide = (property, Property.CaptionSide) |> Rule
            member this.caretColor = (property, Property.CaretColor) |> Rule
            member this.clear = (property, Property.Clear) |> Rule
            member this.clip = (property, Property.Clip) |> Rule
            member this.clipPath = (property, Property.ClipPath) |> Rule
            member this.color = (property, Property.Color) |> Rule
            member this.colorAdjust = (property, Property.ColorAdjust) |> Rule
            member this.columns = (property, Property.Columns) |> Rule
            member this.columnCount = (property, Property.ColumnCount) |> Rule
            member this.columnFill = (property, Property.ColumnFill) |> Rule
            member this.columnGap = (property, Property.ColumnGap) |> Rule
            member this.columnRule = (property, Property.ColumnRule) |> Rule

            member this.columnRuleColor =
                (property, Property.ColumnRuleColor) |> Rule

            member this.columnRuleStyle =
                (property, Property.ColumnRuleStyle) |> Rule

            member this.columnRuleWidth =
                (property, Property.ColumnRuleWidth) |> Rule

            member this.columnSpan = (property, Property.ColumnSpan) |> Rule
            member this.columnWidth = (property, Property.ColumnWidth) |> Rule
            member this.content = (property, Property.Content) |> Rule

            member this.counterIncrement =
                (property, Property.CounterIncrement) |> Rule

            member this.counterReset =
                (property, Property.CounterReset) |> Rule

            member this.cueAfter = (property, Property.CueAfter) |> Rule
            member this.cueBefore = (property, Property.CueBefore) |> Rule
            member this.cue = (property, Property.Cue) |> Rule
            member this.cursor = (property, Property.Cursor) |> Rule
            member this.direction = (property, Property.Direction) |> Rule
            member this.display = (property, Property.Display) |> Rule
            member this.elevation = (property, Property.Elevation) |> Rule
            member this.emptyCells = (property, Property.EmptyCells) |> Rule
            member this.filter = (property, Property.Filter) |> Rule
            member this.flex = (property, Property.Flex) |> Rule
            member this.flexBasis = (property, Property.FlexBasis) |> Rule

            member this.flexDirection =
                (property, Property.FlexDirection) |> Rule

            member this.fontFeatureSettings =
                (property, Property.FontFeatureSettings) |> Rule

            member this.fontVariationSettings =
                (property, Property.FontVariationSettings) |> Rule

            member this.flexFlow = (property, Property.FlexFlow) |> Rule
            member this.flexGrow = (property, Property.FlexGrow) |> Rule
            member this.flexShrink = (property, Property.FlexShrink) |> Rule
            member this.flexWrap = (property, Property.FlexWrap) |> Rule
            member this.float = (property, Property.Float) |> Rule
            member this.fontFamily = (property, Property.FontFamily) |> Rule
            member this.fontKerning = (property, Property.FontKerning) |> Rule

            member this.fontLanguageOverride =
                (property, Property.FontLanguageOverride) |> Rule

            member this.fontSizeAdjust =
                (property, Property.FontSizeAdjust) |> Rule

            member this.fontSize = (property, Property.FontSize) |> Rule
            member this.fontStretch = (property, Property.FontStretch) |> Rule
            member this.fontStyle = (property, Property.FontStyle) |> Rule
            member this.fontDisplay = (property, Property.FontDisplay) |> Rule

            member this.fontSynthesis =
                (property, Property.FontSynthesis) |> Rule

            member this.fontVariant = (property, Property.FontVariant) |> Rule

            member this.fontVariantAlternates =
                (property, Property.FontVariantAlternates) |> Rule

            member this.fontVariantCaps =
                (property, Property.FontVariantCaps) |> Rule

            member this.fontVariantEastAsian =
                (property, Property.FontVariantEastAsian) |> Rule

            member this.fontVariantLigatures =
                (property, Property.FontVariantLigatures) |> Rule

            member this.fontVariantNumeric =
                (property, Property.FontVariantNumeric) |> Rule

            member this.fontVariantPosition =
                (property, Property.FontVariantPosition) |> Rule

            member this.fontWeight = (property, Property.FontWeight) |> Rule
            member this.font = (property, Property.Font) |> Rule
            member this.gridArea = (property, Property.GridArea) |> Rule

            member this.gridAutoColumns =
                (property, Property.GridAutoColumns) |> Rule

            member this.gridAutoFlow =
                (property, Property.GridAutoFlow) |> Rule

            member this.gridAutoRows =
                (property, Property.GridAutoRows) |> Rule

            member this.gridColumnEnd =
                (property, Property.GridColumnEnd) |> Rule

            member this.gridColumnStart =
                (property, Property.GridColumnStart) |> Rule

            member this.gridColumn = (property, Property.GridColumn) |> Rule
            member this.gridGap = (property, Property.GridGap) |> Rule
            member this.gridRowEnd = (property, Property.GridRowEnd) |> Rule
            member this.gridRowGap = (property, Property.GridRowGap) |> Rule

            member this.gridColumnGap =
                (property, Property.GridColumnGap) |> Rule

            member this.gridRowStart =
                (property, Property.GridRowStart) |> Rule

            member this.gridRow = (property, Property.GridRow) |> Rule

            member this.gridTemplateAreas =
                (property, Property.GridTemplateAreas) |> Rule

            member this.gridTemplateColumns =
                (property, Property.GridTemplateColumns) |> Rule

            member this.gridTemplateRows =
                (property, Property.GridTemplateRows) |> Rule

            member this.gridTemplate =
                (property, Property.GridTemplate) |> Rule

            member this.grid = (property, Property.Grid) |> Rule

            member this.hangingPunctuation =
                (property, Property.HangingPunctuation) |> Rule

            member this.height = (property, Property.Height) |> Rule
            member this.hyphens = (property, Property.Hyphens) |> Rule
            member this.isolation = (property, Property.Isolation) |> Rule

            member this.imageRendering =
                (property, Property.ImageRendering) |> Rule

            member this.justifyContent =
                (property, Property.JustifyContent) |> Rule

            member this.justifyItems =
                (property, Property.JustifyItems) |> Rule

            member this.justifySelf = (property, Property.JustifySelf) |> Rule
            member this.label = (property, Property.Label) |> Rule
            member this.left = (property, Property.Left) |> Rule

            member this.letterSpacing =
                (property, Property.LetterSpacing) |> Rule

            member this.lineBreak = (property, Property.LineBreak) |> Rule
            member this.lineHeight = (property, Property.LineHeight) |> Rule
            member this.listStyle = (property, Property.ListStyle) |> Rule

            member this.listStyleImage =
                (property, Property.ListStyleImage) |> Rule

            member this.listStylePosition =
                (property, Property.ListStylePosition) |> Rule

            member this.listStyleType =
                (property, Property.ListStyleType) |> Rule

            member this.lineGapOverride =
                (property, Property.LineGapOverride) |> Rule

            member this.maskClip = (property, Property.MaskClip) |> Rule

            member this.maskComposite =
                (property, Property.MaskComposite) |> Rule

            member this.maskImage = (property, Property.MaskImage) |> Rule
            member this.maskMode = (property, Property.MaskMode) |> Rule
            member this.maskOrigin = (property, Property.MaskOrigin) |> Rule

            member this.maskPosition =
                (property, Property.MaskPosition) |> Rule

            member this.maskRepeat = (property, Property.MaskRepeat) |> Rule
            member this.maskSize = (property, Property.MaskSize) |> Rule

            member this.marginBottom =
                (property, Property.MarginBottom) |> Rule

            member this.marginLeft = (property, Property.MarginLeft) |> Rule
            member this.marginRight = (property, Property.MarginRight) |> Rule
            member this.marginTop = (property, Property.MarginTop) |> Rule
            member this.margin = (property, Property.Margin) |> Rule

            member this.marginInlineStart =
                (property, Property.MarginInlineStart) |> Rule

            member this.marginInlineEnd =
                (property, Property.MarginInlineEnd) |> Rule

            member this.marginBlockStart =
                (property, Property.MarginBlockStart) |> Rule

            member this.marginBlockEnd =
                (property, Property.MarginBlockEnd) |> Rule

            member this.markerOffset =
                (property, Property.MarkerOffset) |> Rule

            member this.marks = (property, Property.Marks) |> Rule
            member this.maxHeight = (property, Property.MaxHeight) |> Rule
            member this.maxWidth = (property, Property.MaxWidth) |> Rule
            member this.minHeight = (property, Property.MinHeight) |> Rule
            member this.minWidth = (property, Property.MinWidth) |> Rule

            member this.mixBlendMode =
                (property, Property.MixBlendMode) |> Rule

            member this.navUp = (property, Property.NavUp) |> Rule
            member this.navDown = (property, Property.NavDown) |> Rule
            member this.navLeft = (property, Property.NavLeft) |> Rule
            member this.navRight = (property, Property.NavRight) |> Rule
            member this.opacity = (property, Property.Opacity) |> Rule
            member this.order = (property, Property.Order) |> Rule
            member this.orphans = (property, Property.Orphans) |> Rule

            member this.outlineColor =
                (property, Property.OutlineColor) |> Rule

            member this.outlineOffset =
                (property, Property.OutlineOffset) |> Rule

            member this.outlineStyle =
                (property, Property.OutlineStyle) |> Rule

            member this.outlineWidth =
                (property, Property.OutlineWidth) |> Rule

            member this.outline = (property, Property.Outline) |> Rule
            member this.overflow = (property, Property.Overflow) |> Rule

            member this.overflowWrap =
                (property, Property.OverflowWrap) |> Rule

            member this.overflowX = (property, Property.OverflowX) |> Rule
            member this.overflowY = (property, Property.OverflowY) |> Rule
            member this.objectFit = (property, Property.ObjectFit) |> Rule

            member this.objectPosition =
                (property, Property.ObjectPosition) |> Rule

            member this.paddingBottom =
                (property, Property.PaddingBottom) |> Rule

            member this.paddingLeft = (property, Property.PaddingLeft) |> Rule

            member this.paddingRight =
                (property, Property.PaddingRight) |> Rule

            member this.paddingTop = (property, Property.PaddingTop) |> Rule
            member this.padding = (property, Property.Padding) |> Rule

            member this.paddingInlineStart =
                (property, Property.PaddingInlineStart) |> Rule

            member this.paddingInlineEnd =
                (property, Property.PaddingInlineEnd) |> Rule

            member this.paddingBlockStart =
                (property, Property.PaddingBlockStart) |> Rule

            member this.paddingBlockEnd =
                (property, Property.PaddingBlockEnd) |> Rule

            member this.page = (property, Property.Page) |> Rule
            member this.pauseAfter = (property, Property.PauseAfter) |> Rule
            member this.pauseBefore = (property, Property.PauseBefore) |> Rule
            member this.pause = (property, Property.Pause) |> Rule
            member this.paintOrder = (property, Property.PaintOrder) |> Rule

            member this.pointerEvents =
                (property, Property.PointerEvents) |> Rule

            member this.perspective = (property, Property.Perspective) |> Rule

            member this.perspectiveOrigin =
                (property, Property.PerspectiveOrigin) |> Rule

            member this.pitchRange = (property, Property.PitchRange) |> Rule
            member this.pitch = (property, Property.Pitch) |> Rule

            member this.placeContent =
                (property, Property.PlaceContent) |> Rule

            member this.placeItems = (property, Property.PlaceItems) |> Rule
            member this.placeSelf = (property, Property.PlaceSelf) |> Rule
            member this.playDuring = (property, Property.PlayDuring) |> Rule
            member this.position = (property, Property.Position) |> Rule
            member this.Quotes = (property, Property.Quotes) |> Rule
            member this.resize = (property, Property.Resize) |> Rule
            member this.restAfter = (property, Property.RestAfter) |> Rule
            member this.restBefore = (property, Property.RestBefore) |> Rule
            member this.rest = (property, Property.Rest) |> Rule
            member this.richness = (property, Property.Richness) |> Rule
            member this.right = (property, Property.Right) |> Rule
            member this.size = (property, Property.Size) |> Rule
            member this.speakHeader = (property, Property.SpeakHeader) |> Rule

            member this.speakNumeral =
                (property, Property.SpeakNumeral) |> Rule

            member this.speakPunctuation =
                (property, Property.SpeakPunctuation) |> Rule

            member this.src = (property, Property.Src) |> Rule
            member this.speak = (property, Property.Speak) |> Rule
            member this.speechRate = (property, Property.SpeechRate) |> Rule
            member this.stress = (property, Property.Stress) |> Rule

            member this.scrollBehavior =
                (property, Property.ScrollBehavior) |> Rule

            member this.scrollMarginBottom =
                (property, Property.ScrollMarginBottom) |> Rule

            member this.scrollMarginLeft =
                (property, Property.ScrollMarginLeft) |> Rule

            member this.scrollMarginRight =
                (property, Property.ScrollMarginRight) |> Rule

            member this.scrollMarginTop =
                (property, Property.ScrollMarginTop) |> Rule

            member this.scrollMargin =
                (property, Property.ScrollMargin) |> Rule

            member this.scrollPaddingBottom =
                (property, Property.ScrollPaddingBottom) |> Rule

            member this.scrollPaddingLeft =
                (property, Property.ScrollPaddingLeft) |> Rule

            member this.scrollPaddingRight =
                (property, Property.ScrollPaddingRight) |> Rule

            member this.scrollPaddingTop =
                (property, Property.ScrollPaddingTop) |> Rule

            member this.scrollPadding =
                (property, Property.ScrollPadding) |> Rule

            member this.scrollSnapType =
                (property, Property.ScrollSnapType) |> Rule

            member this.scrollSnapAlign =
                (property, Property.ScrollSnapAlign) |> Rule

            member this.scrollSnapStop =
                (property, Property.ScrollSnapStop) |> Rule

            member this.sizeAdjust = (property, Property.SizeAdjust) |> Rule

            member this.overscrollBehaviorX =
                (property, Property.OverscrollBehaviorX) |> Rule

            member this.overscrollBehaviorY =
                (property, Property.OverscrollBehaviorY) |> Rule

            member this.tabSize = (property, Property.TabSize) |> Rule
            member this.tableLayout = (property, Property.TableLayout) |> Rule
            member this.textAlign = (property, Property.TextAlign) |> Rule

            member this.textAlignLast =
                (property, Property.TextAlignLast) |> Rule

            member this.textDecoration =
                (property, Property.TextDecoration) |> Rule

            member this.textDecorationColor =
                (property, Property.TextDecorationColor) |> Rule

            member this.textDecorationLine =
                (property, Property.TextDecorationLine) |> Rule

            member this.textDecorationThickness =
                (property, Property.TextDecorationThickness)
                |> Rule

            member this.textDecorationSkip =
                (property, Property.TextDecorationSkip) |> Rule

            member this.textDecorationSkipInk =
                (property, Property.TextDecorationSkipInk) |> Rule

            member this.textDecorationStyle =
                (property, Property.TextDecorationStyle) |> Rule

            member this.textIndent = (property, Property.TextIndent) |> Rule

            member this.textOverflow =
                (property, Property.TextOverflow) |> Rule

            member this.textShadow = (property, Property.TextShadow) |> Rule

            member this.textTransform =
                (property, Property.TextTransform) |> Rule

            member this.textEmphasis =
                (property, Property.TextEmphasis) |> Rule

            member this.textEmphasisColor =
                (property, Property.TextEmphasisColor) |> Rule

            member this.textEmphasisPosition =
                (property, Property.TextEmphasisPosition) |> Rule

            member this.textEmphasisStyle =
                (property, Property.TextEmphasisStyle) |> Rule

            member this.textUnderlineOffset =
                (property, Property.TextUnderlineOffset) |> Rule

            member this.textUnderlinePosition =
                (property, Property.TextUnderlinePosition) |> Rule

            member this.textSizeAdjust =
                (property, Property.TextSizeAdjust) |> Rule

            member this.textOrientation =
                (property, Property.TextOrientation) |> Rule

            member this.textRendering =
                (property, Property.TextRendering) |> Rule

            member this.textJustify = (property, Property.TextJustify) |> Rule
            member this.top = (property, Property.Top) |> Rule
            member this.transform = (property, Property.Transform) |> Rule

            member this.transformOrigin =
                (property, Property.TransformOrigin) |> Rule

            member this.transformStyle =
                (property, Property.TransformStyle) |> Rule

            member this.transition = (property, Property.Transition) |> Rule

            member this.transitionDelay =
                (property, Property.TransitionDelay) |> Rule

            member this.transitionDuration =
                (property, Property.TransitionDuration) |> Rule

            member this.transitionProperty =
                (property, Property.TransitionProperty) |> Rule

            member this.transitionTimingFunction =
                (property, Property.TransitionTimingFunction)
                |> Rule

            member this.unicodeBidi = (property, Property.UnicodeBidi) |> Rule

            member this.unicodeRange =
                (property, Property.UnicodeRange) |> Rule

            member this.userSelect = (property, Property.UserSelect) |> Rule

            member this.verticalAlign =
                (property, Property.VerticalAlign) |> Rule

            member this.visibility = (property, Property.Visibility) |> Rule

            member this.voiceBalance =
                (property, Property.VoiceBalance) |> Rule

            member this.voiceDuration =
                (property, Property.VoiceDuration) |> Rule

            member this.voiceFamily = (property, Property.VoiceFamily) |> Rule
            member this.voicePitch = (property, Property.VoicePitch) |> Rule
            member this.voiceRange = (property, Property.VoiceRange) |> Rule
            member this.voiceRate = (property, Property.VoiceRate) |> Rule
            member this.voiceStress = (property, Property.VoiceStress) |> Rule
            member this.voiceVolume = (property, Property.VoiceVolume) |> Rule
            member this.volume = (property, Property.Volume) |> Rule
            member this.whiteSpace = (property, Property.WhiteSpace) |> Rule
            member this.widows = (property, Property.Widows) |> Rule
            member this.width = (property, Property.Width) |> Rule
            member this.willChange = (property, Property.WillChange) |> Rule
            member this.wordBreak = (property, Property.WordBreak) |> Rule
            member this.wordSpacing = (property, Property.WordSpacing) |> Rule
            member this.wordWrap = (property, Property.WordWrap) |> Rule
            member this.writingMode = (property, Property.WritingMode) |> Rule
            member this.zIndex = (property, Property.ZIndex) |> Rule

            // Pseudo
            member this.active = (property, Property.Active) |> Rule
            member this.anyLink = (property, Property.AnyLink) |> Rule
            member this.blank = (property, Property.Blank) |> Rule
            member this.``checked`` = (property, Property.Checked) |> Rule
            member this.current = (property, Property.Current) |> Rule
            member this.disabled = (property, Property.Disabled) |> Rule
            member this.empty = (property, Property.Empty) |> Rule
            member this.enabled = (property, Property.Enabled) |> Rule
            member this.firstChild = (property, Property.FirstChild) |> Rule
            member this.firstOfType = (property, Property.FirstOfType) |> Rule
            member this.focus = (property, Property.Focus) |> Rule

            member this.focusVisible =
                (property, Property.FocusVisible) |> Rule

            member this.focusWithin = (property, Property.FocusWithin) |> Rule
            member this.future = (property, Property.Future) |> Rule
            member this.hover = (property, Property.Hover) |> Rule

            member this.indeterminate =
                (property, Property.Indeterminate) |> Rule

            member this.invalid = (property, Property.Invalid) |> Rule
            member this.inRange = (property, Property.InRange) |> Rule
            member this.lang = (property, Property.Lang) |> Rule
            member this.lastChild = (property, Property.LastChild) |> Rule
            member this.lastOfType = (property, Property.LastOfType) |> Rule
            member this.link = (property, Property.Link) |> Rule
            member this.localLink = (property, Property.LocalLink) |> Rule
            member this.nthChild = (property, Property.NthChild) |> Rule

            member this.nthLastChild =
                (property, Property.NthLastChild) |> Rule

            member this.nthLastOfType =
                (property, Property.NthLastOfType) |> Rule

            member this.nthOfType = (property, Property.NthOfType) |> Rule
            member this.onlyChild = (property, Property.OnlyChild) |> Rule
            member this.onlyOfType = (property, Property.OnlyOfType) |> Rule
            member this.optional = (property, Property.Optional) |> Rule
            member this.outOfRange = (property, Property.OutOfRange) |> Rule
            member this.past = (property, Property.Past) |> Rule
            member this.playing = (property, Property.Playing) |> Rule
            member this.paused = (property, Property.Paused) |> Rule

            member this.placeholderShown =
                (property, Property.PlaceholderShown) |> Rule

            member this.readOnly = (property, Property.ReadOnly) |> Rule
            member this.readWrite = (property, Property.ReadWrite) |> Rule
            member this.required = (property, Property.Required) |> Rule
            member this.root = (property, Property.Root) |> Rule
            member this.scope = (property, Property.Scope) |> Rule
            member this.target = (property, Property.Target) |> Rule

            member this.targetWithin =
                (property, Property.TargetWithin) |> Rule

            member this.valid = (property, Property.Valid) |> Rule
            member this.visited = (property, Property.Visited) |> Rule
            member this.userInvalid = (property, Property.UserInvalid) |> Rule
            member this.after = (property, Property.After) |> Rule
            member this.before = (property, Property.Before) |> Rule
            member this.firstLetter = (property, Property.FirstLetter) |> Rule
            member this.firstLine = (property, Property.FirstLine) |> Rule
            member this.selection = (property, Property.Selection) |> Rule

            member this.alignmentBaseline =
                (property, Property.AlignmentBaseline) |> Rule

            member this.baselineShift =
                (property, Property.BaselineShift) |> Rule

            member this.dominantBaseline =
                (property, Property.DominantBaseline) |> Rule

            member this.textAnchor = (property, Property.TextAnchor) |> Rule
            member this.clipRule = (property, Property.ClipRule) |> Rule
            member this.floodColor = (property, Property.FloodColor) |> Rule

            member this.floodOpacity =
                (property, Property.FloodOpacity) |> Rule

            member this.lightingColor =
                (property, Property.LightingColor) |> Rule

            member this.stopColor = (property, Property.StopColor) |> Rule
            member this.stopOpacity = (property, Property.StopOpacity) |> Rule

            member this.colorInterpolation =
                (property, Property.ColorInterpolation) |> Rule

            member this.colorInterpolationFilters =
                (property, Property.ColorInterpolationFilters)
                |> Rule

            member this.fill = (property, Property.Fill) |> Rule
            member this.fillOpacity = (property, Property.FillOpacity) |> Rule
            member this.fillRule = (property, Property.FillRule) |> Rule

            member this.shapeRendering =
                (property, Property.ShapeRendering) |> Rule

            member this.stroke = (property, Property.Stroke) |> Rule

            member this.strokeOpacity =
                (property, Property.StrokeOpacity) |> Rule

            member this.strokeDasharray =
                (property, Property.StrokeDasharray) |> Rule

            member this.strokeDashoffset =
                (property, Property.StrokeDashoffset) |> Rule

            member this.strokeLinecap =
                (property, Property.StrokeLinecap) |> Rule

            member this.strokeLinejoin =
                (property, Property.StrokeLinejoin) |> Rule

            member this.strokeMiterlimit =
                (property, Property.StrokeMiterlimit) |> Rule

            member this.strokeWidth = (property, Property.StrokeWidth) |> Rule
