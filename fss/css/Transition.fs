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
        static member Value (delay: FssTypes.ITransition) = delay |> transitionValue'

        static member Inherit = FssTypes.Inherit |> transitionValue'
        static member Initial = FssTypes.Initial |> transitionValue'
        static member Unset = FssTypes.Unset |> transitionValue'

    /// <summary>Resets transition.</summary>
    /// <param name="transition">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Transition' (transition: FssTypes.ITransition) = Transition.Value(transition)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-delay
    let private delayValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionDelay value
    let private delayValue' value =
        value
        |> delayToString
        |> delayValue
    type TransitionDelay =
        static member Value (delay: FssTypes.ITransitionDelay) = delay |> delayValue'
        static member Value (delays: FssTypes.ITransitionDelay list) = Utilities.Helpers.combineComma delayToString delays |> delayValue

        static member Inherit = FssTypes.Inherit |> delayValue'
        static member Initial = FssTypes.Initial |> delayValue'
        static member Unset = FssTypes.Unset |> delayValue'

    /// <summary>Specifies the duration to wait before a transition starts.</summary>
    /// <param name="delay">
    ///     can be:
    ///     - <c> Units.Time </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionDelay' (delay: FssTypes.ITransitionDelay) = TransitionDelay.Value(delay)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duraion
    let private transitionDurationValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionDuration value
    let private transitionDurationValue' value =
        value
        |> durationToString
        |> transitionDurationValue
    type TransitionDuration =
        static member Value (duration: FssTypes.ITransitionDuration) = duration |> transitionDurationValue'
        static member Value (durations: FssTypes.ITransitionDuration list) =
            Utilities.Helpers.combineComma durationToString durations |> transitionDurationValue

        static member Inherit = FssTypes.Inherit |> transitionDurationValue'
        static member Initial = FssTypes.Initial |> transitionDurationValue'
        static member Unset = FssTypes.Unset |> transitionDurationValue'

    /// <summary>Specifies the duration of the transition.</summary>
    /// <param name="duration">
    ///     can be:
    ///     - <c> Units.Time </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionDuration' (duration: FssTypes.ITransitionDuration) = TransitionDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    let private transitionTimingFunction value =
        FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionTimingFunction value
    let private transitionTimingFunction' value =
        value
        |> timingToString
        |> transitionTimingFunction
    type TransitionTimingFunction =
        static member Value (timingFunction: FssTypes.ITransitionTimingFunction) = timingFunction |> transitionTimingFunction'
        static member Value (timingFunctions: FssTypes.ITransitionTimingFunction list) =
             Utilities.Helpers.combineComma FssTypes.timingFunctionHelpers.timingToString timingFunctions |> transitionTimingFunction
        static member Ease = TimingFunction.TimingFunction.Ease |> transitionTimingFunction
        static member EaseIn = TimingFunction.TimingFunction.EaseIn |> transitionTimingFunction
        static member EaseOut = TimingFunction.TimingFunction.EaseOut |> transitionTimingFunction
        static member EaseInOut = TimingFunction.TimingFunction.EaseInOut |> transitionTimingFunction
        static member Linear = TimingFunction.TimingFunction.Linear |> transitionTimingFunction
        static member StepStart = TimingFunction.TimingFunction.StepStart |> transitionTimingFunction
        static member StepEnd = TimingFunction.TimingFunction.StepEnd |> transitionTimingFunction
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = TimingFunction.TimingFunction.CubicBezier(p1,p2,p3,p4) |> transitionTimingFunction
        static member Step (steps: int) = TimingFunction.Step(steps) |> transitionTimingFunction
        static member Step (steps: int, jumpTerm: FssTypes.TimingFunction.Step) = TimingFunction.Step(steps, jumpTerm) |> transitionTimingFunction

        static member Inherit = FssTypes.Inherit |> transitionTimingFunction'
        static member Initial = FssTypes.Initial |> transitionTimingFunction'
        static member Unset = FssTypes.Unset |> transitionTimingFunction'

    /// <summary>Specifies how the intermediate values are calculated.</summary>
    /// <param name="timingFunction">
    ///     can be:
    ///     - <c> TransitionTiming </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionTimingFunction' (timingFunction: FssTypes.ITransitionTimingFunction) = TransitionTimingFunction.Value(timingFunction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-property
    let private transitionProperty value = FssTypes.propertyHelpers.cssValue FssTypes.Property.TransitionProperty value
    let private transitionProperty' value =
        value
        |> propertyToString
        |> transitionProperty
    type TransitionProperty =
        static member Value (property: FssTypes.ITransitionProperty) = property |> transitionProperty'
        static member Values (properties: FssTypes.Property.Property list) =
             properties
             |> Utilities.Helpers.combineComma propertyToString
             |> transitionProperty
        static member All = FssTypes.Property.All |> transitionProperty'
        static member AlignContent = FssTypes.Property.AlignContent |> transitionProperty'
        static member AlignItems = FssTypes.Property.AlignItems |> transitionProperty'
        static member AlignSelf = FssTypes.Property.AlignSelf |> transitionProperty'
        static member AnimationDelay = FssTypes.Property.AnimationDelay |> transitionProperty'
        static member AnimationDirection = FssTypes.Property.AnimationDirection |> transitionProperty'
        static member AnimationDuration = FssTypes.Property.AnimationDuration |> transitionProperty'
        static member AnimationFillMode = FssTypes.Property.AnimationFillMode |> transitionProperty'
        static member AnimationIterationCount = FssTypes.Property.AnimationIterationCount |> transitionProperty'
        static member AnimationName = FssTypes.Property.AnimationName |> transitionProperty'
        static member AnimationPlayState = FssTypes.Property.AnimationPlayState |> transitionProperty'
        static member AnimationTimingFunction = FssTypes.Property.AnimationTimingFunction |> transitionProperty'
        static member BackfaceVisibility = FssTypes.Property.BackfaceVisibility |> transitionProperty'
        static member BackgroundAttachment = FssTypes.Property.BackgroundAttachment |> transitionProperty'
        static member BackgroundBlendMode = FssTypes.Property.BackgroundBlendMode |> transitionProperty'
        static member BackgroundClip = FssTypes.Property.BackgroundClip |> transitionProperty'
        static member BackgroundColor = FssTypes.Property.BackgroundColor |> transitionProperty'
        static member BackgroundImage = FssTypes.Property.BackgroundImage |> transitionProperty'
        static member BackgroundOrigin = FssTypes.Property.BackgroundOrigin |> transitionProperty'
        static member BackgroundPosition = FssTypes.Property.BackgroundPosition |> transitionProperty'
        static member BackgroundRepeat = FssTypes.Property.BackgroundRepeat |> transitionProperty'
        static member BackgroundSize = FssTypes.Property.BackgroundSize |> transitionProperty'
        static member Bleed = FssTypes.Property.Bleed |> transitionProperty'
        static member BorderBottomColor = FssTypes.Property.BorderBottomColor |> transitionProperty'
        static member BorderBottomLeftRadius = FssTypes.Property.BorderBottomLeftRadius |> transitionProperty'
        static member BorderBottomRightRadius = FssTypes.Property.BorderBottomRightRadius |> transitionProperty'
        static member BorderBottomStyle = FssTypes.Property.BorderBottomStyle |> transitionProperty'
        static member BorderBottomWidth = FssTypes.Property.BorderBottomWidth |> transitionProperty'
        static member BorderBottom = FssTypes.Property.BorderBottom |> transitionProperty'
        static member BorderCollapse = FssTypes.Property.BorderCollapse |> transitionProperty'
        static member BorderColor = FssTypes.Property.BorderColor |> transitionProperty'
        static member BorderImage = FssTypes.Property.BorderImage |> transitionProperty'
        static member BorderImageOutset = FssTypes.Property.BorderImageOutset |> transitionProperty'
        static member BorderImageRepeat = FssTypes.Property.BorderImageRepeat |> transitionProperty'
        static member BorderImageSource = FssTypes.Property.BorderImageSource |> transitionProperty'
        static member BorderImageSlice = FssTypes.Property.BorderImageSlice |> transitionProperty'
        static member BorderImageWidth = FssTypes.Property.BorderImageWidth |> transitionProperty'
        static member BorderLeftColor = FssTypes.Property.BorderLeftColor |> transitionProperty'
        static member BorderLeftStyle = FssTypes.Property.BorderLeftStyle |> transitionProperty'
        static member BorderLeftWidth = FssTypes.Property.BorderLeftWidth |> transitionProperty'
        static member BorderLeft = FssTypes.Property.BorderLeft |> transitionProperty'
        static member BorderRadius = FssTypes.Property.BorderRadius |> transitionProperty'
        static member BorderRightColor = FssTypes.Property.BorderRightColor |> transitionProperty'
        static member BorderRightStyle = FssTypes.Property.BorderRightStyle |> transitionProperty'
        static member BorderRightWidth = FssTypes.Property.BorderRightWidth |> transitionProperty'
        static member BorderRight = FssTypes.Property.BorderRight |> transitionProperty'
        static member BorderSpacing = FssTypes.Property.BorderSpacing |> transitionProperty'
        static member BorderStyle = FssTypes.Property.BorderStyle |> transitionProperty'
        static member BorderTopColor = FssTypes.Property.BorderTopColor |> transitionProperty'
        static member BorderTopLeftRadius = FssTypes.Property.BorderTopLeftRadius |> transitionProperty'
        static member BorderTopRightRadius = FssTypes.Property.BorderTopRightRadius |> transitionProperty'
        static member BorderTopStyle = FssTypes.Property.BorderTopStyle |> transitionProperty'
        static member BorderTopWidth = FssTypes.Property.BorderTopWidth |> transitionProperty'
        static member BorderTop = FssTypes.Property.BorderTop |> transitionProperty'
        static member BorderWidth = FssTypes.Property.BorderWidth |> transitionProperty'
        static member Bottom = FssTypes.Property.Bottom |> transitionProperty'
        static member BoxDecorationBreak = FssTypes.Property.BoxDecorationBreak |> transitionProperty'
        static member BoxShadow = FssTypes.Property.BoxShadow |> transitionProperty'
        static member BoxSizing = FssTypes.Property.BoxSizing |> transitionProperty'
        static member BreakAfter = FssTypes.Property.BreakAfter |> transitionProperty'
        static member BreakBefore = FssTypes.Property.BreakBefore |> transitionProperty'
        static member BreakInside = FssTypes.Property.BreakInside |> transitionProperty'
        static member CaptionSide = FssTypes.Property.CaptionSide |> transitionProperty'
        static member CaretColor = FssTypes.Property.CaretColor |> transitionProperty'
        static member Clear = FssTypes.Property.Clear |> transitionProperty'
        static member Clip = FssTypes.Property.Clip |> transitionProperty'
        static member Color = FssTypes.Property.Color |> transitionProperty'
        static member Columns = FssTypes.Property.Columns |> transitionProperty'
        static member ColumnCount = FssTypes.Property.ColumnCount |> transitionProperty'
        static member ColumnFill = FssTypes.Property.ColumnFill |> transitionProperty'
        static member ColumnGap = FssTypes.Property.ColumnGap |> transitionProperty'
        static member ColumnRule = FssTypes.Property.ColumnRule |> transitionProperty'
        static member ColumnRuleColor = FssTypes.Property.ColumnRuleColor |> transitionProperty'
        static member ColumnRuleStyle = FssTypes.Property.ColumnRuleStyle |> transitionProperty'
        static member ColumnRuleWidth = FssTypes.Property.ColumnRuleWidth |> transitionProperty'
        static member ColumnSpan = FssTypes.Property.ColumnSpan |> transitionProperty'
        static member ColumnWidth = FssTypes.Property.ColumnWidth |> transitionProperty'
        static member Content = FssTypes.Property.Content |> transitionProperty'
        static member CounterIncrement = FssTypes.Property.CounterIncrement |> transitionProperty'
        static member CounterReset = FssTypes.Property.CounterReset |> transitionProperty'
        static member CueAfter = FssTypes.Property.CueAfter |> transitionProperty'
        static member CueBefore = FssTypes.Property.CueBefore |> transitionProperty'
        static member Cue = FssTypes.Property.Cue |> transitionProperty'
        static member Cursor = FssTypes.Property.Cursor |> transitionProperty'
        static member Direction = FssTypes.Property.Direction |> transitionProperty'
        static member Display = FssTypes.Property.Display |> transitionProperty'
        static member Elevation = FssTypes.Property.Elevation |> transitionProperty'
        static member EmptyCells = FssTypes.Property.EmptyCells |> transitionProperty'
        static member Filter = FssTypes.Property.Filter |> transitionProperty'
        static member Flex = FssTypes.Property.Flex |> transitionProperty'
        static member FlexBasis = FssTypes.Property.FlexBasis |> transitionProperty'
        static member FlexDirection = FssTypes.Property.FlexDirection |> transitionProperty'
        static member FontFeatureSettings = FssTypes.Property.FontFeatureSettings |> transitionProperty'
        static member FlexFlow = FssTypes.Property.FlexFlow |> transitionProperty'
        static member FlexGrow = FssTypes.Property.FlexGrow |> transitionProperty'
        static member FlexShrink = FssTypes.Property.FlexShrink |> transitionProperty'
        static member FlexWrap = FssTypes.Property.FlexWrap |> transitionProperty'
        static member Float = FssTypes.Property.Float |> transitionProperty'
        static member FontFamily = FssTypes.Property.FontFamily |> transitionProperty'
        static member FontKerning = FssTypes.Property.FontKerning |> transitionProperty'
        static member FontLanguageOverride = FssTypes.Property.FontLanguageOverride |> transitionProperty'
        static member FontSizeAdjust = FssTypes.Property.FontSizeAdjust |> transitionProperty'
        static member FontSize = FssTypes.Property.FontSize |> transitionProperty'
        static member FontStretch = FssTypes.Property.FontStretch |> transitionProperty'
        static member FontStyle = FssTypes.Property.FontStyle |> transitionProperty'
        static member FontDisplay = FssTypes.Property.FontDisplay |> transitionProperty'
        static member FontSynthesis = FssTypes.Property.FontSynthesis |> transitionProperty'
        static member FontVariant = FssTypes.Property.FontVariant |> transitionProperty'
        static member FontVariantAlternates = FssTypes.Property.FontVariantAlternates |> transitionProperty'
        static member FontVariantCaps = FssTypes.Property.FontVariantCaps |> transitionProperty'
        static member FontVariantEastAsian = FssTypes.Property.FontVariantEastAsian |> transitionProperty'
        static member FontVariantLigatures = FssTypes.Property.FontVariantLigatures |> transitionProperty'
        static member FontVariantNumeric = FssTypes.Property.FontVariantNumeric |> transitionProperty'
        static member FontVariantPosition = FssTypes.Property.FontVariantPosition |> transitionProperty'
        static member FontWeight = FssTypes.Property.FontWeight |> transitionProperty'
        static member Font = FssTypes.Property.Font |> transitionProperty'
        static member GridArea = FssTypes.Property.GridArea |> transitionProperty'
        static member GridAutoColumns = FssTypes.Property.GridAutoColumns |> transitionProperty'
        static member GridAutoFlow = FssTypes.Property.GridAutoFlow |> transitionProperty'
        static member GridAutoRows = FssTypes.Property.GridAutoRows |> transitionProperty'
        static member GridColumnEnd = FssTypes.Property.GridColumnEnd |> transitionProperty'
        static member GridColumnGap = FssTypes.Property.ColumnGap |> transitionProperty'
        static member GridColumnStart = FssTypes.Property.GridColumnStart |> transitionProperty'
        static member GridColumn = FssTypes.Property.GridColumn |> transitionProperty'
        static member GridGap = FssTypes.Property.GridGap |> transitionProperty'
        static member GridRowEnd = FssTypes.Property.GridRowEnd |> transitionProperty'
        static member GridRowGap = FssTypes.Property.GridRowGap |> transitionProperty'
        static member GridRowStart = FssTypes.Property.GridRowStart |> transitionProperty'
        static member GridRow = FssTypes.Property.GridRow |> transitionProperty'
        static member GridTemplateAreas = FssTypes.Property.GridTemplateAreas |> transitionProperty'
        static member GridTemplateColumns = FssTypes.Property.GridTemplateColumns |> transitionProperty'
        static member GridTemplateRows = FssTypes.Property.GridTemplateRows |> transitionProperty'
        static member GridTemplate = FssTypes.Property.GridTemplate |> transitionProperty'
        static member Grid = FssTypes.Property.Grid |> transitionProperty'
        static member HangingPunctuation = FssTypes.Property.HangingPunctuation |> transitionProperty'
        static member Height = FssTypes.Property.Height |> transitionProperty'
        static member Hyphens = FssTypes.Property.Hyphens |> transitionProperty'
        static member Isolation = FssTypes.Property.Isolation |> transitionProperty'
        static member JustifyContent = FssTypes.Property.JustifyContent |> transitionProperty'
        static member JustifyItems = FssTypes.Property.JustifyItems |> transitionProperty'
        static member JustifySelf = FssTypes.Property.JustifySelf |> transitionProperty'
        static member Label = FssTypes.Property.Label |> transitionProperty'
        static member Left = FssTypes.Property.Left |> transitionProperty'
        static member LetterSpacing = FssTypes.Property.LetterSpacing |> transitionProperty'
        static member LineBreak = FssTypes.Property.LineBreak |> transitionProperty'
        static member LineHeight = FssTypes.Property.LineHeight |> transitionProperty'
        static member ListStyleImage = FssTypes.Property.ListStyleImage |> transitionProperty'
        static member ListStylePosition = FssTypes.Property.ListStylePosition |> transitionProperty'
        static member ListStyleType = FssTypes.Property.ListStyleType |> transitionProperty'
        static member MarginBottom = FssTypes.Property.MarginBottom |> transitionProperty'
        static member MarginLeft = FssTypes.Property.MarginLeft |> transitionProperty'
        static member MarginRight = FssTypes.Property.MarginRight |> transitionProperty'
        static member MarginTop = FssTypes.Property.MarginTop |> transitionProperty'
        static member Margin = FssTypes.Property.Margin |> transitionProperty'
        static member MarkerOffset = FssTypes.Property.MarkerOffset |> transitionProperty'
        static member Marks = FssTypes.Property.Marks |> transitionProperty'
        static member MaxHeight = FssTypes.Property.MaxHeight |> transitionProperty'
        static member MaxWidth = FssTypes.Property.MaxWidth |> transitionProperty'
        static member MinHeight = FssTypes.Property.MinHeight |> transitionProperty'
        static member MinWidth = FssTypes.Property.MinWidth |> transitionProperty'
        static member MixBlendMode = FssTypes.Property.MixBlendMode |> transitionProperty'
        static member NavUp = FssTypes.Property.NavUp |> transitionProperty'
        static member NavDown = FssTypes.Property.NavDown |> transitionProperty'
        static member NavLeft = FssTypes.Property.NavLeft |> transitionProperty'
        static member NavRight = FssTypes.Property.NavRight |> transitionProperty'
        static member Opacity = FssTypes.Property.Opacity |> transitionProperty'
        static member Order = FssTypes.Property.Order |> transitionProperty'
        static member Orphans = FssTypes.Property.Orphans |> transitionProperty'
        static member OutlineColor = FssTypes.Property.OutlineColor |> transitionProperty'
        static member OutlineOffset = FssTypes.Property.OutlineOffset |> transitionProperty'
        static member OutlineStyle = FssTypes.Property.OutlineStyle |> transitionProperty'
        static member OutlineWidth = FssTypes.Property.OutlineWidth |> transitionProperty'
        static member Outline = FssTypes.Property.Outline |> transitionProperty'
        static member Overflow = FssTypes.Property.Overflow |> transitionProperty'
        static member OverflowWrap = FssTypes.Property.OverflowWrap |> transitionProperty'
        static member OverflowX = FssTypes.Property.OverflowX |> transitionProperty'
        static member OverflowY = FssTypes.Property.OverflowY |> transitionProperty'
        static member PaddingBottom = FssTypes.Property.PaddingBottom |> transitionProperty'
        static member PaddingLeft = FssTypes.Property.PaddingLeft |> transitionProperty'
        static member PaddingRight = FssTypes.Property.PaddingRight |> transitionProperty'
        static member PaddingTop = FssTypes.Property.PaddingTop |> transitionProperty'
        static member Padding = FssTypes.Property.Padding |> transitionProperty'
        static member Page = FssTypes.Property.Page |> transitionProperty'
        static member PauseAfter = FssTypes.Property.PauseAfter |> transitionProperty'
        static member PauseBefore = FssTypes.Property.PauseBefore |> transitionProperty'
        static member Pause = FssTypes.Property.Pause |> transitionProperty'
        static member Perspective = FssTypes.Property.Perspective |> transitionProperty'
        static member PerspectiveOrigin = FssTypes.Property.PerspectiveOrigin |> transitionProperty'
        static member PitchRange = FssTypes.Property.PitchRange |> transitionProperty'
        static member Pitch = FssTypes.Property.Pitch |> transitionProperty'
        static member PlaceContent = FssTypes.Property.PlaceContent |> transitionProperty'
        static member PlaceItems = FssTypes.Property.PlaceItems |> transitionProperty'
        static member PlaceSelf = FssTypes.Property.PlaceSelf |> transitionProperty'
        static member PlayDuring = FssTypes.Property.PlayDuring |> transitionProperty'
        static member Position = FssTypes.Property.Position |> transitionProperty'
        static member Quotes = FssTypes.Property.Quotes |> transitionProperty'
        static member Resize = FssTypes.Property.Resize |> transitionProperty'
        static member RestAfter = FssTypes.Property.RestAfter |> transitionProperty'
        static member RestBefore = FssTypes.Property.RestBefore |> transitionProperty'
        static member Rest = FssTypes.Property.Rest |> transitionProperty'
        static member Richness = FssTypes.Property.Richness |> transitionProperty'
        static member Right = FssTypes.Property.Right |> transitionProperty'
        static member Size = FssTypes.Property.Size |> transitionProperty'
        static member SpeakHeader = FssTypes.Property.SpeakHeader |> transitionProperty'
        static member SpeakNumeral = FssTypes.Property.SpeakNumeral |> transitionProperty'
        static member SpeakPunctuation = FssTypes.Property.SpeakPunctuation |> transitionProperty'
        static member Speak = FssTypes.Property.Speak |> transitionProperty'
        static member SpeechRate = FssTypes.Property.SpeechRate |> transitionProperty'
        static member Stress = FssTypes.Property.Stress |> transitionProperty'
        static member TabSize = FssTypes.Property.TabSize |> transitionProperty'
        static member TableLayout = FssTypes.Property.TableLayout |> transitionProperty'
        static member TextAlign = FssTypes.Property.TextAlign |> transitionProperty'
        static member TextAlignlast = FssTypes.Property.TextAlignLast |> transitionProperty'
        static member TextDecoration = FssTypes.Property.TextDecoration |> transitionProperty'
        static member TextDecorationColor = FssTypes.Property.TextDecorationColor |> transitionProperty'
        static member TextDecorationLine = FssTypes.Property.TextDecorationLine |> transitionProperty'
        static member TextDecorationThickness = FssTypes.Property.TextDecorationThickness |> transitionProperty'
        static member TextDecorationSkip = FssTypes.Property.TextDecorationSkip |> transitionProperty'
        static member TextDecorationSkipInk = FssTypes.Property.TextDecorationSkipInk |> transitionProperty'
        static member TextDecorationStyle = FssTypes.Property.TextDecorationStyle |> transitionProperty'
        static member TextIndent = FssTypes.Property.TextIndent |> transitionProperty'
        static member TextOverflow = FssTypes.Property.TextOverflow |> transitionProperty'
        static member TextShadow = FssTypes.Property.TextShadow |> transitionProperty'
        static member TextTransform = FssTypes.Property.TextTransform |> transitionProperty'
        static member TextEmphasisColor = FssTypes.Property.TextEmphasisColor |> transitionProperty'
        static member TextEmphasisPosition = FssTypes.Property.TextEmphasisPosition |> transitionProperty'
        static member TextEmphasisStyle = FssTypes.Property.TextEmphasisStyle |> transitionProperty'
        static member TextUnderlineOffset = FssTypes.Property.TextUnderlineOffset |> transitionProperty'
        static member TextUnderlinePosition = FssTypes.Property.TextUnderlinePosition |> transitionProperty'
        static member Top = FssTypes.Property.Top |> transitionProperty'
        static member Transform = FssTypes.Property.Transform |> transitionProperty'
        static member TransformOrigin = FssTypes.Property.TransformOrigin |> transitionProperty'
        static member TransformStyle = FssTypes.Property.TransformStyle |> transitionProperty'
        static member TransitionDelay = FssTypes.Property.TransitionDelay |> transitionProperty'
        static member TransitionDuration = FssTypes.Property.TransitionDuration |> transitionProperty'
        static member TransitionProperty = FssTypes.Property.TransitionProperty |> transitionProperty'
        static member TransitionTimingFunction = FssTypes.Property.TransitionTimingFunction |> transitionProperty'
        static member UnicodeBidi = FssTypes.Property.UnicodeBidi |> transitionProperty'
        static member VerticalAlign = FssTypes.Property.VerticalAlign |> transitionProperty'
        static member Visibility = FssTypes.Property.Visibility |> transitionProperty'
        static member VoiceBalance = FssTypes.Property.VoiceBalance |> transitionProperty'
        static member VoiceDuration = FssTypes.Property.VoiceDuration |> transitionProperty'
        static member VoiceFamily = FssTypes.Property.VoiceFamily |> transitionProperty'
        static member VoicePitch = FssTypes.Property.VoicePitch |> transitionProperty'
        static member VoiceRange = FssTypes.Property.VoiceRange |> transitionProperty'
        static member VoiceRate = FssTypes.Property.VoiceRate |> transitionProperty'
        static member VoiceStress = FssTypes.Property.VoiceStress |> transitionProperty'
        static member VoiceVolume = FssTypes.Property.VoiceVolume |> transitionProperty'
        static member Volume = FssTypes.Property.Volume |> transitionProperty'
        static member WhiteSpace = FssTypes.Property.WhiteSpace |> transitionProperty'
        static member Widows = FssTypes.Property.Widows |> transitionProperty'
        static member Width = FssTypes.Property.Width |> transitionProperty'
        static member WillChange = FssTypes.Property.WillChange |> transitionProperty'
        static member WordBreak = FssTypes.Property.WordBreak |> transitionProperty'
        static member WordSpacing = FssTypes.Property.WordSpacing |> transitionProperty'
        static member WordWrap = FssTypes.Property.WordWrap |> transitionProperty'
        static member ZIndex = FssTypes.Property.ZIndex |> transitionProperty'

        static member None = FssTypes.None' |> transitionProperty'
        static member Inherit = FssTypes.Inherit |> transitionProperty'
        static member Initial = FssTypes.Initial |> transitionProperty'
        static member Unset = FssTypes.Unset |> transitionProperty'

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
    let TransitionProperty' (property: FssTypes.ITransitionProperty) = TransitionProperty.Value(property)
