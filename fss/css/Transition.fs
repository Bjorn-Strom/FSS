namespace Fss

[<AutoOpen>]
module Transition =
    let private transitionToString (transition: FssTypes.ITransition) =
        match transition with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transition"

    let private delayToString (delay: FssTypes.ITransitionDelay) =
        match delay with
        | :? FssTypes.Time as t -> FssTypes.unitHelpers.timeToString t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transition delay"

    let private durationToString (duration: FssTypes.ITransitionDuration) =
        match duration with
        | :? FssTypes.Time as t -> FssTypes.unitHelpers.timeToString t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transition duration"

    let private timingToString (duration: FssTypes.ITransitionTimingFunction) =
        match duration with
        | :? TimingFunction.TimingFunction as t -> FssTypes.timingFunctionHelpers.timingToString t
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transition timing"

    let private propertyToString (property: FssTypes.ITransitionProperty) =
        match property with
        | :? FssTypes.Property.Property as p -> FssTypes.propertyHelpers.toKebabCase p
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown transition property"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    let private transitionValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Transition value
    let private transitionValue' value =
        value
        |> transitionToString
        |> transitionValue
    type Transition =
        static member value (delay: FssTypes.ITransition) = delay |> transitionValue'

        static member inherit' = FssTypes.Inherit |> transitionValue'
        static member initial = FssTypes.Initial |> transitionValue'
        static member unset = FssTypes.Unset |> transitionValue'

    /// <summary>Resets transition.</summary>
    /// <param name="transition">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Transition' (transition: FssTypes.ITransition) = Transition.value(transition)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-delay
    let private delayValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionDelay value
    let private delayValue' value =
        value
        |> delayToString
        |> delayValue
    type TransitionDelay =
        static member value (delay: FssTypes.ITransitionDelay) = delay |> delayValue'
        static member value (delays: FssTypes.ITransitionDelay list) = Utilities.Helpers.combineComma delayToString delays |> delayValue

        static member inherit' = FssTypes.Inherit |> delayValue'
        static member initial = FssTypes.Initial |> delayValue'
        static member unset = FssTypes.Unset |> delayValue'

    /// <summary>Specifies the duration to wait before a transition starts.</summary>
    /// <param name="delay">
    ///     can be:
    ///     - <c> Units.Time </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionDelay' (delay: FssTypes.ITransitionDelay) = TransitionDelay.value(delay)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duraion
    let private transitionDurationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionDuration value
    let private transitionDurationValue' value =
        value
        |> durationToString
        |> transitionDurationValue
    type TransitionDuration =
        static member value (duration: FssTypes.ITransitionDuration) = duration |> transitionDurationValue'
        static member value (durations: FssTypes.ITransitionDuration list) =
            Utilities.Helpers.combineComma durationToString durations |> transitionDurationValue

        static member inherit' = FssTypes.Inherit |> transitionDurationValue'
        static member initial = FssTypes.Initial |> transitionDurationValue'
        static member unset = FssTypes.Unset |> transitionDurationValue'

    /// <summary>Specifies the duration of the transition.</summary>
    /// <param name="duration">
    ///     can be:
    ///     - <c> Units.Time </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionDuration' (duration: FssTypes.ITransitionDuration) = TransitionDuration.value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    let private transitionTimingFunction value =
        FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionTimingFunction value
    let private transitionTimingFunction' value =
        value
        |> timingToString
        |> transitionTimingFunction
    type TransitionTimingFunction =
        static member value (timingFunction: FssTypes.ITransitionTimingFunction) = timingFunction |> transitionTimingFunction'
        static member value (timingFunctions: FssTypes.ITransitionTimingFunction list) =
             Utilities.Helpers.combineComma FssTypes.timingFunctionHelpers.timingToString timingFunctions |> transitionTimingFunction
        static member ease = TimingFunction.TimingFunction.ease |> transitionTimingFunction
        static member easeIn = TimingFunction.TimingFunction.easeIn |> transitionTimingFunction
        static member easeOut = TimingFunction.TimingFunction.easeOut |> transitionTimingFunction
        static member easeInOut = TimingFunction.TimingFunction.easeInOut |> transitionTimingFunction
        static member linear = TimingFunction.TimingFunction.linear |> transitionTimingFunction
        static member stepStart = TimingFunction.TimingFunction.stepStart |> transitionTimingFunction
        static member stepEnd = TimingFunction.TimingFunction.stepEnd |> transitionTimingFunction
        static member cubicBezier (p1: float, p2:float, p3:float, p4:float) = TimingFunction.TimingFunction.cubicBezier(p1,p2,p3,p4) |> transitionTimingFunction
        static member step (steps: int) = TimingFunction.step(steps) |> transitionTimingFunction
        static member step (steps: int, jumpTerm: FssTypes.TimingFunction.Step) = TimingFunction.step(steps, jumpTerm) |> transitionTimingFunction

        static member inherit' = FssTypes.Inherit |> transitionTimingFunction'
        static member initial = FssTypes.Initial |> transitionTimingFunction'
        static member unset = FssTypes.Unset |> transitionTimingFunction'

    /// <summary>Specifies how the intermediate values are calculated.</summary>
    /// <param name="timingFunction">
    ///     can be:
    ///     - <c> TransitionTiming </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionTimingFunction' (timingFunction: FssTypes.ITransitionTimingFunction) = TransitionTimingFunction.value(timingFunction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-property
    let private transitionProperty value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionProperty value
    let private transitionProperty' value =
        value
        |> propertyToString
        |> transitionProperty
    type TransitionProperty =
        static member value (property: FssTypes.ITransitionProperty) = property |> transitionProperty'
        static member values (properties: FssTypes.Property.Property list) =
             properties
             |> Utilities.Helpers.combineComma propertyToString
             |> transitionProperty
        static member all = FssTypes.Property.All |> transitionProperty'
        static member alignContent = FssTypes.Property.AlignContent |> transitionProperty'
        static member alignItems = FssTypes.Property.AlignItems |> transitionProperty'
        static member alignSelf = FssTypes.Property.AlignSelf |> transitionProperty'
        static member animationDelay = FssTypes.Property.AnimationDelay |> transitionProperty'
        static member animationDirection = FssTypes.Property.AnimationDirection |> transitionProperty'
        static member animationDuration = FssTypes.Property.AnimationDuration |> transitionProperty'
        static member animationFillMode = FssTypes.Property.AnimationFillMode |> transitionProperty'
        static member animationIterationCount = FssTypes.Property.AnimationIterationCount |> transitionProperty'
        static member animationName = FssTypes.Property.AnimationName |> transitionProperty'
        static member animationPlayState = FssTypes.Property.AnimationPlayState |> transitionProperty'
        static member animationTimingFunction = FssTypes.Property.AnimationTimingFunction |> transitionProperty'
        static member backfaceVisibility = FssTypes.Property.BackfaceVisibility |> transitionProperty'
        static member backgroundAttachment = FssTypes.Property.BackgroundAttachment |> transitionProperty'
        static member backgroundBlendMode = FssTypes.Property.BackgroundBlendMode |> transitionProperty'
        static member backgroundClip = FssTypes.Property.BackgroundClip |> transitionProperty'
        static member backgroundColor = FssTypes.Property.BackgroundColor |> transitionProperty'
        static member backgroundImage = FssTypes.Property.BackgroundImage |> transitionProperty'
        static member backgroundOrigin = FssTypes.Property.BackgroundOrigin |> transitionProperty'
        static member backgroundPosition = FssTypes.Property.BackgroundPosition |> transitionProperty'
        static member backgroundRepeat = FssTypes.Property.BackgroundRepeat |> transitionProperty'
        static member backgroundSize = FssTypes.Property.BackgroundSize |> transitionProperty'
        static member bleed = FssTypes.Property.Bleed |> transitionProperty'
        static member borderBottomColor = FssTypes.Property.BorderBottomColor |> transitionProperty'
        static member borderBottomLeftRadius = FssTypes.Property.BorderBottomLeftRadius |> transitionProperty'
        static member borderBottomRightRadius = FssTypes.Property.BorderBottomRightRadius |> transitionProperty'
        static member borderBottomStyle = FssTypes.Property.BorderBottomStyle |> transitionProperty'
        static member borderBottomWidth = FssTypes.Property.BorderBottomWidth |> transitionProperty'
        static member borderBottom = FssTypes.Property.BorderBottom |> transitionProperty'
        static member borderCollapse = FssTypes.Property.BorderCollapse |> transitionProperty'
        static member borderColor = FssTypes.Property.BorderColor |> transitionProperty'
        static member borderImage = FssTypes.Property.BorderImage |> transitionProperty'
        static member borderImageOutset = FssTypes.Property.BorderImageOutset |> transitionProperty'
        static member borderImageRepeat = FssTypes.Property.BorderImageRepeat |> transitionProperty'
        static member borderImageSource = FssTypes.Property.BorderImageSource |> transitionProperty'
        static member borderImageSlice = FssTypes.Property.BorderImageSlice |> transitionProperty'
        static member borderImageWidth = FssTypes.Property.BorderImageWidth |> transitionProperty'
        static member borderLeftColor = FssTypes.Property.BorderLeftColor |> transitionProperty'
        static member borderLeftStyle = FssTypes.Property.BorderLeftStyle |> transitionProperty'
        static member borderLeftWidth = FssTypes.Property.BorderLeftWidth |> transitionProperty'
        static member borderLeft = FssTypes.Property.BorderLeft |> transitionProperty'
        static member borderRadius = FssTypes.Property.BorderRadius |> transitionProperty'
        static member borderRightColor = FssTypes.Property.BorderRightColor |> transitionProperty'
        static member borderRightStyle = FssTypes.Property.BorderRightStyle |> transitionProperty'
        static member borderRightWidth = FssTypes.Property.BorderRightWidth |> transitionProperty'
        static member borderRight = FssTypes.Property.BorderRight |> transitionProperty'
        static member borderSpacing = FssTypes.Property.BorderSpacing |> transitionProperty'
        static member borderStyle = FssTypes.Property.BorderStyle |> transitionProperty'
        static member borderTopColor = FssTypes.Property.BorderTopColor |> transitionProperty'
        static member borderTopLeftRadius = FssTypes.Property.BorderTopLeftRadius |> transitionProperty'
        static member borderTopRightRadius = FssTypes.Property.BorderTopRightRadius |> transitionProperty'
        static member borderTopStyle = FssTypes.Property.BorderTopStyle |> transitionProperty'
        static member borderTopWidth = FssTypes.Property.BorderTopWidth |> transitionProperty'
        static member borderTop = FssTypes.Property.BorderTop |> transitionProperty'
        static member borderWidth = FssTypes.Property.BorderWidth |> transitionProperty'
        static member bottom = FssTypes.Property.Bottom |> transitionProperty'
        static member boxDecorationBreak = FssTypes.Property.BoxDecorationBreak |> transitionProperty'
        static member boxShadow = FssTypes.Property.BoxShadow |> transitionProperty'
        static member boxSizing = FssTypes.Property.BoxSizing |> transitionProperty'
        static member breakAfter = FssTypes.Property.BreakAfter |> transitionProperty'
        static member breakBefore = FssTypes.Property.BreakBefore |> transitionProperty'
        static member breakInside = FssTypes.Property.BreakInside |> transitionProperty'
        static member captionSide = FssTypes.Property.CaptionSide |> transitionProperty'
        static member caretColor = FssTypes.Property.CaretColor |> transitionProperty'
        static member clear = FssTypes.Property.Clear |> transitionProperty'
        static member clip = FssTypes.Property.Clip |> transitionProperty'
        static member color = FssTypes.Property.Color |> transitionProperty'
        static member columns = FssTypes.Property.Columns |> transitionProperty'
        static member columnCount = FssTypes.Property.ColumnCount |> transitionProperty'
        static member columnFill = FssTypes.Property.ColumnFill |> transitionProperty'
        static member columnGap = FssTypes.Property.ColumnGap |> transitionProperty'
        static member columnRule = FssTypes.Property.ColumnRule |> transitionProperty'
        static member columnRuleColor = FssTypes.Property.ColumnRuleColor |> transitionProperty'
        static member columnRuleStyle = FssTypes.Property.ColumnRuleStyle |> transitionProperty'
        static member columnRuleWidth = FssTypes.Property.ColumnRuleWidth |> transitionProperty'
        static member columnSpan = FssTypes.Property.ColumnSpan |> transitionProperty'
        static member columnWidth = FssTypes.Property.ColumnWidth |> transitionProperty'
        static member content = FssTypes.Property.Content |> transitionProperty'
        static member counterIncrement = FssTypes.Property.CounterIncrement |> transitionProperty'
        static member counterReset = FssTypes.Property.CounterReset |> transitionProperty'
        static member cueAfter = FssTypes.Property.CueAfter |> transitionProperty'
        static member cueBefore = FssTypes.Property.CueBefore |> transitionProperty'
        static member cue = FssTypes.Property.Cue |> transitionProperty'
        static member cursor = FssTypes.Property.Cursor |> transitionProperty'
        static member direction = FssTypes.Property.Direction |> transitionProperty'
        static member display = FssTypes.Property.Display |> transitionProperty'
        static member elevation = FssTypes.Property.Elevation |> transitionProperty'
        static member emptyCells = FssTypes.Property.EmptyCells |> transitionProperty'
        static member filter = FssTypes.Property.Filter |> transitionProperty'
        static member flex = FssTypes.Property.Flex |> transitionProperty'
        static member flexBasis = FssTypes.Property.FlexBasis |> transitionProperty'
        static member flexDirection = FssTypes.Property.FlexDirection |> transitionProperty'
        static member fontFeatureSettings = FssTypes.Property.FontFeatureSettings |> transitionProperty'
        static member flexFlow = FssTypes.Property.FlexFlow |> transitionProperty'
        static member flexGrow = FssTypes.Property.FlexGrow |> transitionProperty'
        static member flexShrink = FssTypes.Property.FlexShrink |> transitionProperty'
        static member flexWrap = FssTypes.Property.FlexWrap |> transitionProperty'
        static member float = FssTypes.Property.Float |> transitionProperty'
        static member fontFamily = FssTypes.Property.FontFamily |> transitionProperty'
        static member fontKerning = FssTypes.Property.FontKerning |> transitionProperty'
        static member fontLanguageOverride = FssTypes.Property.FontLanguageOverride |> transitionProperty'
        static member fontSizeAdjust = FssTypes.Property.FontSizeAdjust |> transitionProperty'
        static member fontSize = FssTypes.Property.FontSize |> transitionProperty'
        static member fontStretch = FssTypes.Property.FontStretch |> transitionProperty'
        static member fontStyle = FssTypes.Property.FontStyle |> transitionProperty'
        static member fontDisplay = FssTypes.Property.FontDisplay |> transitionProperty'
        static member fontSynthesis = FssTypes.Property.FontSynthesis |> transitionProperty'
        static member fontVariant = FssTypes.Property.FontVariant |> transitionProperty'
        static member fontVariantAlternates = FssTypes.Property.FontVariantAlternates |> transitionProperty'
        static member fontVariantCaps = FssTypes.Property.FontVariantCaps |> transitionProperty'
        static member fontVariantEastAsian = FssTypes.Property.FontVariantEastAsian |> transitionProperty'
        static member fontVariantLigatures = FssTypes.Property.FontVariantLigatures |> transitionProperty'
        static member fontVariantNumeric = FssTypes.Property.FontVariantNumeric |> transitionProperty'
        static member fontVariantPosition = FssTypes.Property.FontVariantPosition |> transitionProperty'
        static member fontWeight = FssTypes.Property.FontWeight |> transitionProperty'
        static member font = FssTypes.Property.Font |> transitionProperty'
        static member gridArea = FssTypes.Property.GridArea |> transitionProperty'
        static member gridAutoColumns = FssTypes.Property.GridAutoColumns |> transitionProperty'
        static member gridAutoFlow = FssTypes.Property.GridAutoFlow |> transitionProperty'
        static member gridAutoRows = FssTypes.Property.GridAutoRows |> transitionProperty'
        static member gridColumnEnd = FssTypes.Property.GridColumnEnd |> transitionProperty'
        static member gridColumnGap = FssTypes.Property.ColumnGap |> transitionProperty'
        static member gridColumnStart = FssTypes.Property.GridColumnStart |> transitionProperty'
        static member gridColumn = FssTypes.Property.GridColumn |> transitionProperty'
        static member gridGap = FssTypes.Property.GridGap |> transitionProperty'
        static member gridRowEnd = FssTypes.Property.GridRowEnd |> transitionProperty'
        static member gridRowGap = FssTypes.Property.GridRowGap |> transitionProperty'
        static member gridRowStart = FssTypes.Property.GridRowStart |> transitionProperty'
        static member gridRow = FssTypes.Property.GridRow |> transitionProperty'
        static member gridTemplateAreas = FssTypes.Property.GridTemplateAreas |> transitionProperty'
        static member gridTemplateColumns = FssTypes.Property.GridTemplateColumns |> transitionProperty'
        static member gridTemplateRows = FssTypes.Property.GridTemplateRows |> transitionProperty'
        static member gridTemplate = FssTypes.Property.GridTemplate |> transitionProperty'
        static member grid = FssTypes.Property.Grid |> transitionProperty'
        static member hangingPunctuation = FssTypes.Property.HangingPunctuation |> transitionProperty'
        static member height = FssTypes.Property.Height |> transitionProperty'
        static member hyphens = FssTypes.Property.Hyphens |> transitionProperty'
        static member isolation = FssTypes.Property.Isolation |> transitionProperty'
        static member justifyContent = FssTypes.Property.JustifyContent |> transitionProperty'
        static member justifyItems = FssTypes.Property.JustifyItems |> transitionProperty'
        static member justifySelf = FssTypes.Property.JustifySelf |> transitionProperty'
        static member label = FssTypes.Property.Label |> transitionProperty'
        static member left = FssTypes.Property.Left |> transitionProperty'
        static member letterSpacing = FssTypes.Property.LetterSpacing |> transitionProperty'
        static member lineBreak = FssTypes.Property.LineBreak |> transitionProperty'
        static member lineHeight = FssTypes.Property.LineHeight |> transitionProperty'
        static member listStyleImage = FssTypes.Property.ListStyleImage |> transitionProperty'
        static member listStylePosition = FssTypes.Property.ListStylePosition |> transitionProperty'
        static member listStyleType = FssTypes.Property.ListStyleType |> transitionProperty'
        static member marginBottom = FssTypes.Property.MarginBottom |> transitionProperty'
        static member marginLeft = FssTypes.Property.MarginLeft |> transitionProperty'
        static member marginRight = FssTypes.Property.MarginRight |> transitionProperty'
        static member marginTop = FssTypes.Property.MarginTop |> transitionProperty'
        static member margin = FssTypes.Property.Margin |> transitionProperty'
        static member markerOffset = FssTypes.Property.MarkerOffset |> transitionProperty'
        static member marks = FssTypes.Property.Marks |> transitionProperty'
        static member maxHeight = FssTypes.Property.MaxHeight |> transitionProperty'
        static member maxWidth = FssTypes.Property.MaxWidth |> transitionProperty'
        static member minHeight = FssTypes.Property.MinHeight |> transitionProperty'
        static member minWidth = FssTypes.Property.MinWidth |> transitionProperty'
        static member mixBlendMode = FssTypes.Property.MixBlendMode |> transitionProperty'
        static member navUp = FssTypes.Property.NavUp |> transitionProperty'
        static member navDown = FssTypes.Property.NavDown |> transitionProperty'
        static member navLeft = FssTypes.Property.NavLeft |> transitionProperty'
        static member navRight = FssTypes.Property.NavRight |> transitionProperty'
        static member opacity = FssTypes.Property.Opacity |> transitionProperty'
        static member order = FssTypes.Property.Order |> transitionProperty'
        static member orphans = FssTypes.Property.Orphans |> transitionProperty'
        static member outlineColor = FssTypes.Property.OutlineColor |> transitionProperty'
        static member outlineOffset = FssTypes.Property.OutlineOffset |> transitionProperty'
        static member outlineStyle = FssTypes.Property.OutlineStyle |> transitionProperty'
        static member outlineWidth = FssTypes.Property.OutlineWidth |> transitionProperty'
        static member outline = FssTypes.Property.Outline |> transitionProperty'
        static member overflow = FssTypes.Property.Overflow |> transitionProperty'
        static member overflowWrap = FssTypes.Property.OverflowWrap |> transitionProperty'
        static member overflowX = FssTypes.Property.OverflowX |> transitionProperty'
        static member overflowY = FssTypes.Property.OverflowY |> transitionProperty'
        static member paddingBottom = FssTypes.Property.PaddingBottom |> transitionProperty'
        static member paddingLeft = FssTypes.Property.PaddingLeft |> transitionProperty'
        static member paddingRight = FssTypes.Property.PaddingRight |> transitionProperty'
        static member paddingTop = FssTypes.Property.PaddingTop |> transitionProperty'
        static member padding = FssTypes.Property.Padding |> transitionProperty'
        static member page = FssTypes.Property.Page |> transitionProperty'
        static member pauseAfter = FssTypes.Property.PauseAfter |> transitionProperty'
        static member pauseBefore = FssTypes.Property.PauseBefore |> transitionProperty'
        static member pause = FssTypes.Property.Pause |> transitionProperty'
        static member perspective = FssTypes.Property.Perspective |> transitionProperty'
        static member perspectiveOrigin = FssTypes.Property.PerspectiveOrigin |> transitionProperty'
        static member pitchRange = FssTypes.Property.PitchRange |> transitionProperty'
        static member pitch = FssTypes.Property.Pitch |> transitionProperty'
        static member placeContent = FssTypes.Property.PlaceContent |> transitionProperty'
        static member placeItems = FssTypes.Property.PlaceItems |> transitionProperty'
        static member placeSelf = FssTypes.Property.PlaceSelf |> transitionProperty'
        static member playDuring = FssTypes.Property.PlayDuring |> transitionProperty'
        static member position = FssTypes.Property.Position |> transitionProperty'
        static member quotes = FssTypes.Property.Quotes |> transitionProperty'
        static member resize = FssTypes.Property.Resize |> transitionProperty'
        static member restAfter = FssTypes.Property.RestAfter |> transitionProperty'
        static member restBefore = FssTypes.Property.RestBefore |> transitionProperty'
        static member rest = FssTypes.Property.Rest |> transitionProperty'
        static member richness = FssTypes.Property.Richness |> transitionProperty'
        static member right = FssTypes.Property.Right |> transitionProperty'
        static member size = FssTypes.Property.Size |> transitionProperty'
        static member speakHeader = FssTypes.Property.SpeakHeader |> transitionProperty'
        static member speakNumeral = FssTypes.Property.SpeakNumeral |> transitionProperty'
        static member speakPunctuation = FssTypes.Property.SpeakPunctuation |> transitionProperty'
        static member speak = FssTypes.Property.Speak |> transitionProperty'
        static member speechRate = FssTypes.Property.SpeechRate |> transitionProperty'
        static member stress = FssTypes.Property.Stress |> transitionProperty'
        static member tabSize = FssTypes.Property.TabSize |> transitionProperty'
        static member tableLayout = FssTypes.Property.TableLayout |> transitionProperty'
        static member textAlign = FssTypes.Property.TextAlign |> transitionProperty'
        static member textAlignlast = FssTypes.Property.TextAlignLast |> transitionProperty'
        static member textDecoration = FssTypes.Property.TextDecoration |> transitionProperty'
        static member textDecorationColor = FssTypes.Property.TextDecorationColor |> transitionProperty'
        static member textDecorationLine = FssTypes.Property.TextDecorationLine |> transitionProperty'
        static member textDecorationThickness = FssTypes.Property.TextDecorationThickness |> transitionProperty'
        static member textDecorationSkip = FssTypes.Property.TextDecorationSkip |> transitionProperty'
        static member textDecorationSkipInk = FssTypes.Property.TextDecorationSkipInk |> transitionProperty'
        static member textDecorationStyle = FssTypes.Property.TextDecorationStyle |> transitionProperty'
        static member textIndent = FssTypes.Property.TextIndent |> transitionProperty'
        static member textOverflow = FssTypes.Property.TextOverflow |> transitionProperty'
        static member textShadow = FssTypes.Property.TextShadow |> transitionProperty'
        static member textTransform = FssTypes.Property.TextTransform |> transitionProperty'
        static member textEmphasisColor = FssTypes.Property.TextEmphasisColor |> transitionProperty'
        static member textEmphasisPosition = FssTypes.Property.TextEmphasisPosition |> transitionProperty'
        static member textEmphasisStyle = FssTypes.Property.TextEmphasisStyle |> transitionProperty'
        static member textUnderlineOffset = FssTypes.Property.TextUnderlineOffset |> transitionProperty'
        static member textUnderlinePosition = FssTypes.Property.TextUnderlinePosition |> transitionProperty'
        static member top = FssTypes.Property.Top |> transitionProperty'
        static member transform = FssTypes.Property.Transform |> transitionProperty'
        static member transformOrigin = FssTypes.Property.TransformOrigin |> transitionProperty'
        static member transformStyle = FssTypes.Property.TransformStyle |> transitionProperty'
        static member transitionDelay = FssTypes.Property.TransitionDelay |> transitionProperty'
        static member transitionDuration = FssTypes.Property.TransitionDuration |> transitionProperty'
        static member transitionProperty = FssTypes.Property.TransitionProperty |> transitionProperty'
        static member transitionTimingFunction = FssTypes.Property.TransitionTimingFunction |> transitionProperty'
        static member unicodeBidi = FssTypes.Property.UnicodeBidi |> transitionProperty'
        static member verticalAlign = FssTypes.Property.VerticalAlign |> transitionProperty'
        static member visibility = FssTypes.Property.Visibility |> transitionProperty'
        static member voiceBalance = FssTypes.Property.VoiceBalance |> transitionProperty'
        static member voiceDuration = FssTypes.Property.VoiceDuration |> transitionProperty'
        static member voiceFamily = FssTypes.Property.VoiceFamily |> transitionProperty'
        static member voicePitch = FssTypes.Property.VoicePitch |> transitionProperty'
        static member voiceRange = FssTypes.Property.VoiceRange |> transitionProperty'
        static member voiceRate = FssTypes.Property.VoiceRate |> transitionProperty'
        static member voiceStress = FssTypes.Property.VoiceStress |> transitionProperty'
        static member voiceVolume = FssTypes.Property.VoiceVolume |> transitionProperty'
        static member volume = FssTypes.Property.Volume |> transitionProperty'
        static member whiteSpace = FssTypes.Property.WhiteSpace |> transitionProperty'
        static member widows = FssTypes.Property.Widows |> transitionProperty'
        static member width = FssTypes.Property.Width |> transitionProperty'
        static member willChange = FssTypes.Property.WillChange |> transitionProperty'
        static member wordBreak = FssTypes.Property.WordBreak |> transitionProperty'
        static member wordSpacing = FssTypes.Property.WordSpacing |> transitionProperty'
        static member wordWrap = FssTypes.Property.WordWrap |> transitionProperty'
        static member zIndex = FssTypes.Property.ZIndex |> transitionProperty'

        static member none = FssTypes.None' |> transitionProperty'
        static member inherit' = FssTypes.Inherit |> transitionProperty'
        static member initial = FssTypes.Initial |> transitionProperty'
        static member unset = FssTypes.Unset |> transitionProperty'

    /// <summary>Specifies which properties should be affected by transition.</summary>
    /// <param name="property">
    ///     can be:
    ///     - <c> Property </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> None </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionProperty' (property: FssTypes.ITransitionProperty) = TransitionProperty.value(property)
