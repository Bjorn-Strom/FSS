namespace Fss

[<AutoOpen>]
module Transition =
    let private transitionToString (transition: Types.ITransition) =
        match transition with
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transition"

    let private delayToString (delay: Types.ITransitionDelay) =
        match delay with
        | :? Types.Time as t -> Types.timeToString t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transition delay"

    let private durationToString (duration: Types.ITransitionDuration) =
        match duration with
        | :? Types.Time as t -> Types.timeToString t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transition duration"

    let private timingToString (duration: Types.ITransitionTimingFunction) =
        match duration with
        | :? TimingFunction.TimingFunction as t -> Types.timingToString t
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transition timing"

    let private propertyToString (property: Types.ITransitionProperty) =
        match property with
        | :? Types.Property as p -> Types.toKebabCase p
        | :? Types.None' -> Types.none
        | :? Types.Keywords as k -> Types.keywordsToString k
        | _ -> "Unknown transition property"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition
    let private transitionValue value = Types.cssValue Types.Property.Transition value
    let private transitionValue' value =
        value
        |> transitionToString
        |> transitionValue
    type Transition =
        static member Value (delay: Types.ITransition) = delay |> transitionValue'

        static member Inherit = Types.Inherit |> transitionValue'
        static member Initial = Types.Initial |> transitionValue'
        static member Unset = Types.Unset |> transitionValue'

    /// <summary>Resets transition.</summary>
    /// <param name="transition">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Transition' (transition: Types.ITransition) = Transition.Value(transition)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-delay
    let private delayValue value = Types.cssValue Types.Property.TransitionDelay value
    let private delayValue' value =
        value
        |> delayToString
        |> delayValue
    type TransitionDelay =
        static member Value (delay: Types.ITransitionDelay) = delay |> delayValue'
        static member Value (delays: Types.ITransitionDelay list) = Utilities.Helpers.combineComma delayToString delays |> delayValue

        static member Inherit = Types.Inherit |> delayValue'
        static member Initial = Types.Initial |> delayValue'
        static member Unset = Types.Unset |> delayValue'

    /// <summary>Specifies the duration to wait before a transition starts.</summary>
    /// <param name="delay">
    ///     can be:
    ///     - <c> Units.Time </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionDelay' (delay: Types.ITransitionDelay) = TransitionDelay.Value(delay)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duraion
    let private transitionDurationValue value = Types.cssValue Types.Property.TransitionDuration value
    let private transitionDurationValue' value =
        value
        |> durationToString
        |> transitionDurationValue
    type TransitionDuration =
        static member Value (duration: Types.ITransitionDuration) = duration |> transitionDurationValue'
        static member Value (durations: Types.ITransitionDuration list) =
            Utilities.Helpers.combineComma durationToString durations |> transitionDurationValue

        static member Inherit = Types.Inherit |> transitionDurationValue'
        static member Initial = Types.Initial |> transitionDurationValue'
        static member Unset = Types.Unset |> transitionDurationValue'

    /// <summary>Specifies the duration of the transition.</summary>
    /// <param name="duration">
    ///     can be:
    ///     - <c> Units.Time </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionDuration' (duration: Types.ITransitionDuration) = TransitionDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    let private transitionTimingFunction value =
        printfn $"{value}"
        Types.cssValue Types.Property.TransitionTimingFunction value
    let private transitionTimingFunction' value =
        value
        |> timingToString
        |> transitionTimingFunction
    type TransitionTimingFunction =
        static member Value (timingFunction: Types.ITransitionTimingFunction) = timingFunction |> transitionTimingFunction'
        static member Value (timingFunctions: Types.ITransitionTimingFunction list) =
             Utilities.Helpers.combineComma Types.timingToString timingFunctions |> transitionTimingFunction
        static member Ease = TimingFunction.TimingFunction.Ease |> transitionTimingFunction
        static member EaseIn = TimingFunction.TimingFunction.EaseIn |> transitionTimingFunction
        static member EaseOut = TimingFunction.TimingFunction.EaseOut |> transitionTimingFunction
        static member EaseInOut = TimingFunction.TimingFunction.EaseInOut |> transitionTimingFunction
        static member Linear = TimingFunction.TimingFunction.Linear |> transitionTimingFunction
        static member StepStart = TimingFunction.TimingFunction.StepStart |> transitionTimingFunction
        static member StepEnd = TimingFunction.TimingFunction.StepEnd |> transitionTimingFunction
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = TimingFunction.TimingFunction.CubicBezier(p1,p2,p3,p4) |> transitionTimingFunction
        static member Step (steps: int) = TimingFunction.Step(steps) |> transitionTimingFunction
        static member Step (steps: int, jumpTerm: Types.Step) = TimingFunction.Step(steps, jumpTerm) |> transitionTimingFunction

        static member Inherit = Types.Inherit |> transitionTimingFunction'
        static member Initial = Types.Initial |> transitionTimingFunction'
        static member Unset = Types.Unset |> transitionTimingFunction'

    /// <summary>Specifies how the intermediate values are calculated.</summary>
    /// <param name="timingFunction">
    ///     can be:
    ///     - <c> TransitionTiming </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let TransitionTimingFunction' (timingFunction: Types.ITransitionTimingFunction) = TransitionTimingFunction.Value(timingFunction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-property
    let private transitionProperty value = Types.cssValue Types.Property.TransitionProperty value
    let private transitionProperty' value =
        value
        |> propertyToString
        |> transitionProperty
    type TransitionProperty =
        static member Value (property: Types.ITransitionProperty) = property |> transitionProperty'
        static member Values (properties: Types.Property list) =
             properties
             |> Utilities.Helpers.combineComma propertyToString
             |> transitionProperty
        static member All = Types.Property.All |> transitionProperty'
        static member AlignContent = Types.Property.AlignContent |> transitionProperty'
        static member AlignItems = Types.Property.AlignItems |> transitionProperty'
        static member AlignSelf = Types.Property.AlignSelf |> transitionProperty'
        static member AnimationDelay = Types.Property.AnimationDelay |> transitionProperty'
        static member AnimationDirection = Types.Property.AnimationDirection |> transitionProperty'
        static member AnimationDuration = Types.Property.AnimationDuration |> transitionProperty'
        static member AnimationFillMode = Types.Property.AnimationFillMode |> transitionProperty'
        static member AnimationIterationCount = Types.Property.AnimationIterationCount |> transitionProperty'
        static member AnimationName = Types.Property.AnimationName |> transitionProperty'
        static member AnimationPlayState = Types.Property.AnimationPlayState |> transitionProperty'
        static member AnimationTimingFunction = Types.Property.AnimationTimingFunction |> transitionProperty'
        static member BackfaceVisibility = Types.Property.BackfaceVisibility |> transitionProperty'
        static member BackgroundAttachment = Types.Property.BackgroundAttachment |> transitionProperty'
        static member BackgroundBlendMode = Types.Property.BackgroundBlendMode |> transitionProperty'
        static member BackgroundClip = Types.Property.BackgroundClip |> transitionProperty'
        static member BackgroundColor = Types.Property.BackgroundColor |> transitionProperty'
        static member BackgroundImage = Types.Property.BackgroundImage |> transitionProperty'
        static member BackgroundOrigin = Types.Property.BackgroundOrigin |> transitionProperty'
        static member BackgroundPosition = Types.Property.BackgroundPosition |> transitionProperty'
        static member BackgroundRepeat = Types.Property.BackgroundRepeat |> transitionProperty'
        static member BackgroundSize = Types.Property.BackgroundSize |> transitionProperty'
        static member Bleed = Types.Property.Bleed |> transitionProperty'
        static member BorderBottomColor = Types.Property.BorderBottomColor |> transitionProperty'
        static member BorderBottomLeftRadius = Types.Property.BorderBottomLeftRadius |> transitionProperty'
        static member BorderBottomRightRadius = Types.Property.BorderBottomRightRadius |> transitionProperty'
        static member BorderBottomStyle = Types.Property.BorderBottomStyle |> transitionProperty'
        static member BorderBottomWidth = Types.Property.BorderBottomWidth |> transitionProperty'
        static member BorderBottom = Types.Property.BorderBottom |> transitionProperty'
        static member BorderCollapse = Types.Property.BorderCollapse |> transitionProperty'
        static member BorderColor = Types.Property.BorderColor |> transitionProperty'
        static member BorderImage = Types.Property.BorderImage |> transitionProperty'
        static member BorderImageOutset = Types.Property.BorderImageOutset |> transitionProperty'
        static member BorderImageRepeat = Types.Property.BorderImageRepeat |> transitionProperty'
        static member BorderImageSource = Types.Property.BorderImageSource |> transitionProperty'
        static member BorderImageSlice = Types.Property.BorderImageSlice |> transitionProperty'
        static member BorderImageWidth = Types.Property.BorderImageWidth |> transitionProperty'
        static member BorderLeftColor = Types.Property.BorderLeftColor |> transitionProperty'
        static member BorderLeftStyle = Types.Property.BorderLeftStyle |> transitionProperty'
        static member BorderLeftWidth = Types.Property.BorderLeftWidth |> transitionProperty'
        static member BorderLeft = Types.Property.BorderLeft |> transitionProperty'
        static member BorderRadius = Types.Property.BorderRadius |> transitionProperty'
        static member BorderRightColor = Types.Property.BorderRightColor |> transitionProperty'
        static member BorderRightStyle = Types.Property.BorderRightStyle |> transitionProperty'
        static member BorderRightWidth = Types.Property.BorderRightWidth |> transitionProperty'
        static member BorderRight = Types.Property.BorderRight |> transitionProperty'
        static member BorderSpacing = Types.Property.BorderSpacing |> transitionProperty'
        static member BorderStyle = Types.Property.BorderStyle |> transitionProperty'
        static member BorderTopColor = Types.Property.BorderTopColor |> transitionProperty'
        static member BorderTopLeftRadius = Types.Property.BorderTopLeftRadius |> transitionProperty'
        static member BorderTopRightRadius = Types.Property.BorderTopRightRadius |> transitionProperty'
        static member BorderTopStyle = Types.Property.BorderTopStyle |> transitionProperty'
        static member BorderTopWidth = Types.Property.BorderTopWidth |> transitionProperty'
        static member BorderTop = Types.Property.BorderTop |> transitionProperty'
        static member BorderWidth = Types.Property.BorderWidth |> transitionProperty'
        static member Bottom = Types.Property.Bottom |> transitionProperty'
        static member BoxDecorationBreak = Types.Property.BoxDecorationBreak |> transitionProperty'
        static member BoxShadow = Types.Property.BoxShadow |> transitionProperty'
        static member BoxSizing = Types.Property.BoxSizing |> transitionProperty'
        static member BreakAfter = Types.Property.BreakAfter |> transitionProperty'
        static member BreakBefore = Types.Property.BreakBefore |> transitionProperty'
        static member BreakInside = Types.Property.BreakInside |> transitionProperty'
        static member CaptionSide = Types.Property.CaptionSide |> transitionProperty'
        static member CaretColor = Types.Property.CaretColor |> transitionProperty'
        static member Clear = Types.Property.Clear |> transitionProperty'
        static member Clip = Types.Property.Clip |> transitionProperty'
        static member Color = Types.Property.Color |> transitionProperty'
        static member Columns = Types.Property.Columns |> transitionProperty'
        static member ColumnCount = Types.Property.ColumnCount |> transitionProperty'
        static member ColumnFill = Types.Property.ColumnFill |> transitionProperty'
        static member ColumnGap = Types.Property.ColumnGap |> transitionProperty'
        static member ColumnRule = Types.Property.ColumnRule |> transitionProperty'
        static member ColumnRuleColor = Types.Property.ColumnRuleColor |> transitionProperty'
        static member ColumnRuleStyle = Types.Property.ColumnRuleStyle |> transitionProperty'
        static member ColumnRuleWidth = Types.Property.ColumnRuleWidth |> transitionProperty'
        static member ColumnSpan = Types.Property.ColumnSpan |> transitionProperty'
        static member ColumnWidth = Types.Property.ColumnWidth |> transitionProperty'
        static member Content = Types.Property.Content |> transitionProperty'
        static member CounterIncrement = Types.Property.CounterIncrement |> transitionProperty'
        static member CounterReset = Types.Property.CounterReset |> transitionProperty'
        static member CueAfter = Types.Property.CueAfter |> transitionProperty'
        static member CueBefore = Types.Property.CueBefore |> transitionProperty'
        static member Cue = Types.Property.Cue |> transitionProperty'
        static member Cursor = Types.Property.Cursor |> transitionProperty'
        static member Direction = Types.Property.Direction |> transitionProperty'
        static member Display = Types.Property.Display |> transitionProperty'
        static member Elevation = Types.Property.Elevation |> transitionProperty'
        static member EmptyCells = Types.Property.EmptyCells |> transitionProperty'
        static member Filter = Types.Property.Filter |> transitionProperty'
        static member Flex = Types.Property.Flex |> transitionProperty'
        static member FlexBasis = Types.Property.FlexBasis |> transitionProperty'
        static member FlexDirection = Types.Property.FlexDirection |> transitionProperty'
        static member FontFeatureSettings = Types.Property.FontFeatureSettings |> transitionProperty'
        static member FlexFlow = Types.Property.FlexFlow |> transitionProperty'
        static member FlexGrow = Types.Property.FlexGrow |> transitionProperty'
        static member FlexShrink = Types.Property.FlexShrink |> transitionProperty'
        static member FlexWrap = Types.Property.FlexWrap |> transitionProperty'
        static member Float = Types.Property.Float |> transitionProperty'
        static member FontFamily = Types.Property.FontFamily |> transitionProperty'
        static member FontKerning = Types.Property.FontKerning |> transitionProperty'
        static member FontLanguageOverride = Types.Property.FontLanguageOverride |> transitionProperty'
        static member FontSizeAdjust = Types.Property.FontSizeAdjust |> transitionProperty'
        static member FontSize = Types.Property.FontSize |> transitionProperty'
        static member FontStretch = Types.Property.FontStretch |> transitionProperty'
        static member FontStyle = Types.Property.FontStyle |> transitionProperty'
        static member FontDisplay = Types.Property.FontDisplay |> transitionProperty'
        static member FontSynthesis = Types.Property.FontSynthesis |> transitionProperty'
        static member FontVariant = Types.Property.FontVariant |> transitionProperty'
        static member FontVariantAlternates = Types.Property.FontVariantAlternates |> transitionProperty'
        static member FontVariantCaps = Types.Property.FontVariantCaps |> transitionProperty'
        static member FontVariantEastAsian = Types.Property.FontVariantEastAsian |> transitionProperty'
        static member FontVariantLigatures = Types.Property.FontVariantLigatures |> transitionProperty'
        static member FontVariantNumeric = Types.Property.FontVariantNumeric |> transitionProperty'
        static member FontVariantPosition = Types.Property.FontVariantPosition |> transitionProperty'
        static member FontWeight = Types.Property.FontWeight |> transitionProperty'
        static member Font = Types.Property.Font |> transitionProperty'
        static member GridArea = Types.Property.GridArea |> transitionProperty'
        static member GridAutoColumns = Types.Property.GridAutoColumns |> transitionProperty'
        static member GridAutoFlow = Types.Property.GridAutoFlow |> transitionProperty'
        static member GridAutoRows = Types.Property.GridAutoRows |> transitionProperty'
        static member GridColumnEnd = Types.Property.GridColumnEnd |> transitionProperty'
        static member GridColumnGap = Types.Property.ColumnGap |> transitionProperty'
        static member GridColumnStart = Types.Property.GridColumnStart |> transitionProperty'
        static member GridColumn = Types.Property.GridColumn |> transitionProperty'
        static member GridGap = Types.Property.GridGap |> transitionProperty'
        static member GridRowEnd = Types.Property.GridRowEnd |> transitionProperty'
        static member GridRowGap = Types.Property.GridRowGap |> transitionProperty'
        static member GridRowStart = Types.Property.GridRowStart |> transitionProperty'
        static member GridRow = Types.Property.GridRow |> transitionProperty'
        static member GridTemplateAreas = Types.Property.GridTemplateAreas |> transitionProperty'
        static member GridTemplateColumns = Types.Property.GridTemplateColumns |> transitionProperty'
        static member GridTemplateRows = Types.Property.GridTemplateRows |> transitionProperty'
        static member GridTemplate = Types.Property.GridTemplate |> transitionProperty'
        static member Grid = Types.Property.Grid |> transitionProperty'
        static member HangingPunctuation = Types.Property.HangingPunctuation |> transitionProperty'
        static member Height = Types.Property.Height |> transitionProperty'
        static member Hyphens = Types.Property.Hyphens |> transitionProperty'
        static member Isolation = Types.Property.Isolation |> transitionProperty'
        static member JustifyContent = Types.Property.JustifyContent |> transitionProperty'
        static member JustifyItems = Types.Property.JustifyItems |> transitionProperty'
        static member JustifySelf = Types.Property.JustifySelf |> transitionProperty'
        static member Label = Types.Property.Label |> transitionProperty'
        static member Left = Types.Property.Left |> transitionProperty'
        static member LetterSpacing = Types.Property.LetterSpacing |> transitionProperty'
        static member LineBreak = Types.Property.LineBreak |> transitionProperty'
        static member LineHeight = Types.Property.LineHeight |> transitionProperty'
        static member ListStyleImage = Types.Property.ListStyleImage |> transitionProperty'
        static member ListStylePosition = Types.Property.ListStylePosition |> transitionProperty'
        static member ListStyleType = Types.Property.ListStyleType |> transitionProperty'
        static member MarginBottom = Types.Property.MarginBottom |> transitionProperty'
        static member MarginLeft = Types.Property.MarginLeft |> transitionProperty'
        static member MarginRight = Types.Property.MarginRight |> transitionProperty'
        static member MarginTop = Types.Property.MarginTop |> transitionProperty'
        static member Margin = Types.Property.Margin |> transitionProperty'
        static member MarkerOffset = Types.Property.MarkerOffset |> transitionProperty'
        static member Marks = Types.Property.Marks |> transitionProperty'
        static member MaxHeight = Types.Property.MaxHeight |> transitionProperty'
        static member MaxWidth = Types.Property.MaxWidth |> transitionProperty'
        static member MinHeight = Types.Property.MinHeight |> transitionProperty'
        static member MinWidth = Types.Property.MinWidth |> transitionProperty'
        static member MixBlendMode = Types.Property.MixBlendMode |> transitionProperty'
        static member NavUp = Types.Property.NavUp |> transitionProperty'
        static member NavDown = Types.Property.NavDown |> transitionProperty'
        static member NavLeft = Types.Property.NavLeft |> transitionProperty'
        static member NavRight = Types.Property.NavRight |> transitionProperty'
        static member Opacity = Types.Property.Opacity |> transitionProperty'
        static member Order = Types.Property.Order |> transitionProperty'
        static member Orphans = Types.Property.Orphans |> transitionProperty'
        static member OutlineColor = Types.Property.OutlineColor |> transitionProperty'
        static member OutlineOffset = Types.Property.OutlineOffset |> transitionProperty'
        static member OutlineStyle = Types.Property.OutlineStyle |> transitionProperty'
        static member OutlineWidth = Types.Property.OutlineWidth |> transitionProperty'
        static member Outline = Types.Property.Outline |> transitionProperty'
        static member Overflow = Types.Property.Overflow |> transitionProperty'
        static member OverflowWrap = Types.Property.OverflowWrap |> transitionProperty'
        static member OverflowX = Types.Property.OverflowX |> transitionProperty'
        static member OverflowY = Types.Property.OverflowY |> transitionProperty'
        static member PaddingBottom = Types.Property.PaddingBottom |> transitionProperty'
        static member PaddingLeft = Types.Property.PaddingLeft |> transitionProperty'
        static member PaddingRight = Types.Property.PaddingRight |> transitionProperty'
        static member PaddingTop = Types.Property.PaddingTop |> transitionProperty'
        static member Padding = Types.Property.Padding |> transitionProperty'
        static member Page = Types.Property.Page |> transitionProperty'
        static member PauseAfter = Types.Property.PauseAfter |> transitionProperty'
        static member PauseBefore = Types.Property.PauseBefore |> transitionProperty'
        static member Pause = Types.Property.Pause |> transitionProperty'
        static member Perspective = Types.Property.Perspective |> transitionProperty'
        static member PerspectiveOrigin = Types.Property.PerspectiveOrigin |> transitionProperty'
        static member PitchRange = Types.Property.PitchRange |> transitionProperty'
        static member Pitch = Types.Property.Pitch |> transitionProperty'
        static member PlaceContent = Types.Property.PlaceContent |> transitionProperty'
        static member PlaceItems = Types.Property.PlaceItems |> transitionProperty'
        static member PlaceSelf = Types.Property.PlaceSelf |> transitionProperty'
        static member PlayDuring = Types.Property.PlayDuring |> transitionProperty'
        static member Position = Types.Property.Position |> transitionProperty'
        static member Quotes = Types.Property.Quotes |> transitionProperty'
        static member Resize = Types.Property.Resize |> transitionProperty'
        static member RestAfter = Types.Property.RestAfter |> transitionProperty'
        static member RestBefore = Types.Property.RestBefore |> transitionProperty'
        static member Rest = Types.Property.Rest |> transitionProperty'
        static member Richness = Types.Property.Richness |> transitionProperty'
        static member Right = Types.Property.Right |> transitionProperty'
        static member Size = Types.Property.Size |> transitionProperty'
        static member SpeakHeader = Types.Property.SpeakHeader |> transitionProperty'
        static member SpeakNumeral = Types.Property.SpeakNumeral |> transitionProperty'
        static member SpeakPunctuation = Types.Property.SpeakPunctuation |> transitionProperty'
        static member Speak = Types.Property.Speak |> transitionProperty'
        static member SpeechRate = Types.Property.SpeechRate |> transitionProperty'
        static member Stress = Types.Property.Stress |> transitionProperty'
        static member TabSize = Types.Property.TabSize |> transitionProperty'
        static member TableLayout = Types.Property.TableLayout |> transitionProperty'
        static member TextAlign = Types.Property.TextAlign |> transitionProperty'
        static member TextAlignlast = Types.Property.TextAlignLast |> transitionProperty'
        static member TextDecoration = Types.Property.TextDecoration |> transitionProperty'
        static member TextDecorationColor = Types.Property.TextDecorationColor |> transitionProperty'
        static member TextDecorationLine = Types.Property.TextDecorationLine |> transitionProperty'
        static member TextDecorationThickness = Types.Property.TextDecorationThickness |> transitionProperty'
        static member TextDecorationSkip = Types.Property.TextDecorationSkip |> transitionProperty'
        static member TextDecorationSkipInk = Types.Property.TextDecorationSkipInk |> transitionProperty'
        static member TextDecorationStyle = Types.Property.TextDecorationStyle |> transitionProperty'
        static member TextIndent = Types.Property.TextIndent |> transitionProperty'
        static member TextOverflow = Types.Property.TextOverflow |> transitionProperty'
        static member TextShadow = Types.Property.TextShadow |> transitionProperty'
        static member TextTransform = Types.Property.TextTransform |> transitionProperty'
        static member TextEmphasisColor = Types.Property.TextEmphasisColor |> transitionProperty'
        static member TextEmphasisPosition = Types.Property.TextEmphasisPosition |> transitionProperty'
        static member TextEmphasisStyle = Types.Property.TextEmphasisStyle |> transitionProperty'
        static member TextUnderlineOffset = Types.Property.TextUnderlineOffset |> transitionProperty'
        static member TextUnderlinePosition = Types.Property.TextUnderlinePosition |> transitionProperty'
        static member Top = Types.Property.Top |> transitionProperty'
        static member Transform = Types.Property.Transform |> transitionProperty'
        static member TransformOrigin = Types.Property.TransformOrigin |> transitionProperty'
        static member TransformStyle = Types.Property.TransformStyle |> transitionProperty'
        static member TransitionDelay = Types.Property.TransitionDelay |> transitionProperty'
        static member TransitionDuration = Types.Property.TransitionDuration |> transitionProperty'
        static member TransitionProperty = Types.Property.TransitionProperty |> transitionProperty'
        static member TransitionTimingFunction = Types.Property.TransitionTimingFunction |> transitionProperty'
        static member UnicodeBidi = Types.Property.UnicodeBidi |> transitionProperty'
        static member VerticalAlign = Types.Property.VerticalAlign |> transitionProperty'
        static member Visibility = Types.Property.Visibility |> transitionProperty'
        static member VoiceBalance = Types.Property.VoiceBalance |> transitionProperty'
        static member VoiceDuration = Types.Property.VoiceDuration |> transitionProperty'
        static member VoiceFamily = Types.Property.VoiceFamily |> transitionProperty'
        static member VoicePitch = Types.Property.VoicePitch |> transitionProperty'
        static member VoiceRange = Types.Property.VoiceRange |> transitionProperty'
        static member VoiceRate = Types.Property.VoiceRate |> transitionProperty'
        static member VoiceStress = Types.Property.VoiceStress |> transitionProperty'
        static member VoiceVolume = Types.Property.VoiceVolume |> transitionProperty'
        static member Volume = Types.Property.Volume |> transitionProperty'
        static member WhiteSpace = Types.Property.WhiteSpace |> transitionProperty'
        static member Widows = Types.Property.Widows |> transitionProperty'
        static member Width = Types.Property.Width |> transitionProperty'
        static member WillChange = Types.Property.WillChange |> transitionProperty'
        static member WordBreak = Types.Property.WordBreak |> transitionProperty'
        static member WordSpacing = Types.Property.WordSpacing |> transitionProperty'
        static member WordWrap = Types.Property.WordWrap |> transitionProperty'
        static member ZIndex = Types.Property.ZIndex |> transitionProperty'

        static member None = Types.None' |> transitionProperty'
        static member Inherit = Types.Inherit |> transitionProperty'
        static member Initial = Types.Initial |> transitionProperty'
        static member Unset = Types.Unset |> transitionProperty'

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
    let TransitionProperty' (property: Types.ITransitionProperty) = TransitionProperty.Value(property)
