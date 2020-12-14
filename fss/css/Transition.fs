namespace Fss

[<AutoOpen>]
module Transition =
    let private delayToString (delay: ITransitionDelay) =
        match delay with
        | :? Units.Time.Time as t -> Units.Time.value t
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown transition delay"

    let private durationToString (duration: ITransitionDuration) =
        match duration with
        | :? Units.Time.Time as t -> Units.Time.value t
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown transition duration"

    let private timingToString (duration: ITransitionTimingFunction) =
        match duration with
        | :? TimingFunction.TimingFunction as t -> TimingFunctionType.timingToString t
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown transition timing"

    let private propertyToString (property: ITransitionProperty) =
        match property with
        | :? Property.Property as p -> PropertyValue.toKebabCase p
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown transition property"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-delay
    let private transitionValue value = PropertyValue.cssValue Property.TransitionDelay value
    let private transitionValue' value =
        value
        |> delayToString
        |> transitionValue
    type TransitionDelay =
        static member Value (delay: ITransitionDelay) = delay |> transitionValue'
        static member Value (delays: ITransitionDelay list) = Utilities.Helpers.combineComma delayToString delays |> transitionValue

        static member Inherit = Inherit |> transitionValue'
        static member Initial = Initial |> transitionValue'
        static member Unset = Unset |> transitionValue'

    let TransitionDelay' (delay: ITransitionDelay) = TransitionDelay.Value(delay)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duraion
    let private transitionDurationValue value = PropertyValue.cssValue Property.TransitionDuration value
    let private transitionDurationValue' value =
        value
        |> durationToString
        |> transitionDurationValue
    type TransitionDuration =
        static member Value (duration: ITransitionDuration) = duration |> transitionDurationValue'
        static member Value (durations: ITransitionDuration list) =
            Utilities.Helpers.combineComma durationToString durations |> transitionDurationValue

        static member Inherit = Inherit |> transitionDurationValue'
        static member Initial = Initial |> transitionDurationValue'
        static member Unset = Unset |> transitionDurationValue'

    let TransitionDuration' (duration: ITransitionDuration) = TransitionDuration.Value(duration)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-timing-function
    let private transitionTimingFunction value = PropertyValue.cssValue Property.TransitionTimingFunction value
    let private transitionTimingFunction' value =
        value
        |> timingToString
        |> transitionTimingFunction
    type TransitionTimingFunction =
        static member Value (timingFunction: ITransitionTimingFunction) = timingFunction |> transitionTimingFunction'
        static member Value (timingFunctions: ITransitionTimingFunction list) =
             Utilities.Helpers.combineComma TimingFunctionType.timingToString timingFunctions |> transitionTimingFunction
        static member Ease = TimingFunction.TimingFunction.Ease |> transitionTimingFunction
        static member EaseIn = TimingFunction.TimingFunction.EaseIn |> transitionTimingFunction
        static member EaseOut = TimingFunction.TimingFunction.EaseOut |> transitionTimingFunction
        static member EaseInOut = TimingFunction.TimingFunction.EaseInOut |> transitionTimingFunction
        static member Linear = TimingFunction.TimingFunction.Linear |> transitionTimingFunction
        static member StepStart = TimingFunction.TimingFunction.StepStart |> transitionTimingFunction
        static member StepEnd = TimingFunction.TimingFunction.StepEnd |> transitionTimingFunction
        static member CubicBezier (p1: float, p2:float, p3:float, p4:float) = TimingFunction.CubicBezier(p1,p2,p3,p4) |> transitionTimingFunction
        static member Step (steps: int) = TimingFunction.Step(steps) |> transitionTimingFunction
        static member Step (steps: int, jumpTerm: TimingFunctionType.StepType) = TimingFunction.Step(steps, jumpTerm) |> transitionTimingFunction

        static member Inherit = Inherit |> transitionTimingFunction'
        static member Initial = Initial |> transitionTimingFunction'
        static member Unset = Unset |> transitionTimingFunction'

    let TransitionTimingFunction' (timingFunction: ITransitionTimingFunction) = TransitionTimingFunction.Value(timingFunction)

    // https://developer.mozilla.org/en-US/docs/Web/CSS/transition-property
    let private transitionProperty value = PropertyValue.cssValue Property.TransitionProperty value
    let private transitionProperty' value =
        value
        |> propertyToString
        |> transitionProperty
    type TransitionProperty =
        static member Value (property: ITransitionProperty) = property |> transitionProperty'
        static member Value (properties: ITransitionProperty list) =
             Utilities.Helpers.combineComma propertyToString properties |> transitionProperty
        static member All = Property.All |> transitionProperty'
        static member AlignContent = Property.AlignContent |> transitionProperty'
        static member AlignItems = Property.AlignItems |> transitionProperty'
        static member AlignSelf = Property.AlignSelf |> transitionProperty'
        static member AnimationDelay = Property.AnimationDelay |> transitionProperty'
        static member AnimationDirection = Property.AnimationDirection |> transitionProperty'
        static member AnimationDuration = Property.AnimationDuration |> transitionProperty'
        static member AnimationFillMode = Property.AnimationFillMode |> transitionProperty'
        static member AnimationIterationCount = Property.AnimationIterationCount |> transitionProperty'
        static member AnimationName = Property.AnimationName |> transitionProperty'
        static member AnimationPlayState = Property.AnimationPlayState |> transitionProperty'
        static member AnimationTimingFunction = Property.AnimationTimingFunction |> transitionProperty'
        static member BackfaceVisibility = Property.BackfaceVisibility |> transitionProperty'
        static member BackgroundAttachment = Property.BackgroundAttachment |> transitionProperty'
        static member BackgroundBlendMode = Property.BackgroundBlendMode |> transitionProperty'
        static member BackgroundClip = Property.BackgroundClip |> transitionProperty'
        static member BackgroundColor = Property.BackgroundColor |> transitionProperty'
        static member BackgroundImage = Property.BackgroundImage |> transitionProperty'
        static member BackgroundOrigin = Property.BackgroundOrigin |> transitionProperty'
        static member BackgroundPosition = Property.BackgroundPosition |> transitionProperty'
        static member BackgroundRepeat = Property.BackgroundRepeat |> transitionProperty'
        static member BackgroundSize = Property.BackgroundSize |> transitionProperty'
        static member Bleed = Property.Bleed |> transitionProperty'
        static member BorderBottomColor = Property.BorderBottomColor |> transitionProperty'
        static member BorderBottomLeftRadius = Property.BorderBottomLeftRadius |> transitionProperty'
        static member BorderBottomRightRadius = Property.BorderBottomRightRadius |> transitionProperty'
        static member BorderBottomStyle = Property.BorderBottomStyle |> transitionProperty'
        static member BorderBottomWidth = Property.BorderBottomWidth |> transitionProperty'
        static member BorderBottom = Property.BorderBottom |> transitionProperty'
        static member BorderCollapse = Property.BorderCollapse |> transitionProperty'
        static member BorderColor = Property.BorderColor |> transitionProperty'
        static member BorderImage = Property.BorderImage |> transitionProperty'
        static member BorderImageOutset = Property.BorderImageOutset |> transitionProperty'
        static member BorderImageRepeat = Property.BorderImageRepeat |> transitionProperty'
        static member BorderImageSource = Property.BorderImageSource |> transitionProperty'
        static member BorderImageSlice = Property.BorderImageSlice |> transitionProperty'
        static member BorderImageWidth = Property.BorderImageWidth |> transitionProperty'
        static member BorderLeftColor = Property.BorderLeftColor |> transitionProperty'
        static member BorderLeftStyle = Property.BorderLeftStyle |> transitionProperty'
        static member BorderLeftWidth = Property.BorderLeftWidth |> transitionProperty'
        static member BorderLeft = Property.BorderLeft |> transitionProperty'
        static member BorderRadius = Property.BorderRadius |> transitionProperty'
        static member BorderRightColor = Property.BorderRightColor |> transitionProperty'
        static member BorderRightStyle = Property.BorderRightStyle |> transitionProperty'
        static member BorderRightWidth = Property.BorderRightWidth |> transitionProperty'
        static member BorderRight = Property.BorderRight |> transitionProperty'
        static member BorderSpacing = Property.BorderSpacing |> transitionProperty'
        static member BorderStyle = Property.BorderStyle |> transitionProperty'
        static member BorderTopColor = Property.BorderTopColor |> transitionProperty'
        static member BorderTopLeftRadius = Property.BorderTopLeftRadius |> transitionProperty'
        static member BorderTopRightRadius = Property.BorderTopRightRadius |> transitionProperty'
        static member BorderTopStyle = Property.BorderTopStyle |> transitionProperty'
        static member BorderTopWidth = Property.BorderTopWidth |> transitionProperty'
        static member BorderTop = Property.BorderTop |> transitionProperty'
        static member BorderWidth = Property.BorderWidth |> transitionProperty'
        static member Bottom = Property.Bottom |> transitionProperty'
        static member BoxDecorationBreak = Property.BoxDecorationBreak |> transitionProperty'
        static member BoxShadow = Property.BoxShadow |> transitionProperty'
        static member BoxSizing = Property.BoxSizing |> transitionProperty'
        static member BreakAfter = Property.BreakAfter |> transitionProperty'
        static member BreakBefore = Property.BreakBefore |> transitionProperty'
        static member BreakInside = Property.BreakInside |> transitionProperty'
        static member CaptionSide = Property.CaptionSide |> transitionProperty'
        static member CaretColor = Property.CaretColor |> transitionProperty'
        static member Clear = Property.Clear |> transitionProperty'
        static member Clip = Property.Clip |> transitionProperty'
        static member Color = Property.Color |> transitionProperty'
        static member Columns = Property.Columns |> transitionProperty'
        static member ColumnCount = Property.ColumnCount |> transitionProperty'
        static member ColumnFill = Property.ColumnFill |> transitionProperty'
        static member ColumnGap = Property.ColumnGap |> transitionProperty'
        static member ColumnRule = Property.ColumnRule |> transitionProperty'
        static member ColumnRuleColor = Property.ColumnRuleColor |> transitionProperty'
        static member ColumnRuleStyle = Property.ColumnRuleStyle |> transitionProperty'
        static member ColumnRuleWidth = Property.ColumnRuleWidth |> transitionProperty'
        static member ColumnSpan = Property.ColumnSpan |> transitionProperty'
        static member ColumnWidth = Property.ColumnWidth |> transitionProperty'
        static member Content = Property.Content |> transitionProperty'
        static member CounterIncrement = Property.CounterIncrement |> transitionProperty'
        static member CounterReset = Property.CounterReset |> transitionProperty'
        static member CueAfter = Property.CueAfter |> transitionProperty'
        static member CueBefore = Property.CueBefore |> transitionProperty'
        static member Cue = Property.Cue |> transitionProperty'
        static member Cursor = Property.Cursor |> transitionProperty'
        static member Direction = Property.Direction |> transitionProperty'
        static member Display = Property.Display |> transitionProperty'
        static member Elevation = Property.Elevation |> transitionProperty'
        static member EmptyCells = Property.EmptyCells |> transitionProperty'
        static member Filter = Property.Filter |> transitionProperty'
        static member Flex = Property.Flex |> transitionProperty'
        static member FlexBasis = Property.FlexBasis |> transitionProperty'
        static member FlexDirection = Property.FlexDirection |> transitionProperty'
        static member FontFeatureSettings = Property.FontFeatureSettings |> transitionProperty'
        static member FlexFlow = Property.FlexFlow |> transitionProperty'
        static member FlexGrow = Property.FlexGrow |> transitionProperty'
        static member FlexShrink = Property.FlexShrink |> transitionProperty'
        static member FlexWrap = Property.FlexWrap |> transitionProperty'
        static member Float = Property.Float |> transitionProperty'
        static member FontFamily = Property.FontFamily |> transitionProperty'
        static member FontKerning = Property.FontKerning |> transitionProperty'
        static member FontLanguageOverride = Property.FontLanguageOverride |> transitionProperty'
        static member FontSizeAdjust = Property.FontSizeAdjust |> transitionProperty'
        static member FontSize = Property.FontSize |> transitionProperty'
        static member FontStretch = Property.FontStretch |> transitionProperty'
        static member FontStyle = Property.FontStyle |> transitionProperty'
        static member FontDisplay = Property.FontDisplay |> transitionProperty'
        static member FontSynthesis = Property.FontSynthesis |> transitionProperty'
        static member FontVariant = Property.FontVariant |> transitionProperty'
        static member FontVariantAlternates = Property.FontVariantAlternates |> transitionProperty'
        static member FontVariantCaps = Property.FontVariantCaps |> transitionProperty'
        static member FontVariantEastAsian = Property.FontVariantEastAsian |> transitionProperty'
        static member FontVariantLigatures = Property.FontVariantLigatures |> transitionProperty'
        static member FontVariantNumeric = Property.FontVariantNumeric |> transitionProperty'
        static member FontVariantPosition = Property.FontVariantPosition |> transitionProperty'
        static member FontWeight = Property.FontWeight |> transitionProperty'
        static member Font = Property.Font |> transitionProperty'
        static member GridArea = Property.GridArea |> transitionProperty'
        static member GridAutoColumns = Property.GridAutoColumns |> transitionProperty'
        static member GridAutoFlow = Property.GridAutoFlow |> transitionProperty'
        static member GridAutoRows = Property.GridAutoRows |> transitionProperty'
        static member GridColumnEnd = Property.GridColumnEnd |> transitionProperty'
        static member GridColumnGap = Property.ColumnGap |> transitionProperty'
        static member GridColumnStart = Property.GridColumnStart |> transitionProperty'
        static member GridColumn = Property.GridColumn |> transitionProperty'
        static member GridGap = Property.GridGap |> transitionProperty'
        static member GridRowEnd = Property.GridRowEnd |> transitionProperty'
        static member GridRowGap = Property.GridRowGap |> transitionProperty'
        static member GridRowStart = Property.GridRowStart |> transitionProperty'
        static member GridRow = Property.GridRow |> transitionProperty'
        static member GridTemplateAreas = Property.GridTemplateAreas |> transitionProperty'
        static member GridTemplateColumns = Property.GridTemplateColumns |> transitionProperty'
        static member GridTemplateRows = Property.GridTemplateRows |> transitionProperty'
        static member GridTemplate = Property.GridTemplate |> transitionProperty'
        static member Grid = Property.Grid |> transitionProperty'
        static member HangingPunctuation = Property.HangingPunctuation |> transitionProperty'
        static member Height = Property.Height |> transitionProperty'
        static member Hyphens = Property.Hyphens |> transitionProperty'
        static member Isolation = Property.Isolation |> transitionProperty'
        static member JustifyContent = Property.JustifyContent |> transitionProperty'
        static member JustifyItems = Property.JustifyItems |> transitionProperty'
        static member JustifySelf = Property.JustifySelf |> transitionProperty'
        static member Label = Property.Label |> transitionProperty'
        static member Left = Property.Left |> transitionProperty'
        static member LetterSpacing = Property.LetterSpacing |> transitionProperty'
        static member LineBreak = Property.LineBreak |> transitionProperty'
        static member LineHeight = Property.LineHeight |> transitionProperty'
        static member ListStyleImage = Property.ListStyleImage |> transitionProperty'
        static member ListStylePosition = Property.ListStylePosition |> transitionProperty'
        static member ListStyleType = Property.ListStyleType |> transitionProperty'
        static member MarginBottom = Property.MarginBottom |> transitionProperty'
        static member MarginLeft = Property.MarginLeft |> transitionProperty'
        static member MarginRight = Property.MarginRight |> transitionProperty'
        static member MarginTop = Property.MarginTop |> transitionProperty'
        static member Margin = Property.Margin |> transitionProperty'
        static member MarkerOffset = Property.MarkerOffset |> transitionProperty'
        static member Marks = Property.Marks |> transitionProperty'
        static member MaxHeight = Property.MaxHeight |> transitionProperty'
        static member MaxWidth = Property.MaxWidth |> transitionProperty'
        static member MinHeight = Property.MinHeight |> transitionProperty'
        static member MinWidth = Property.MinWidth |> transitionProperty'
        static member MixBlendMode = Property.MixBlendMode |> transitionProperty'
        static member NavUp = Property.NavUp |> transitionProperty'
        static member NavDown = Property.NavDown |> transitionProperty'
        static member NavLeft = Property.NavLeft |> transitionProperty'
        static member NavRight = Property.NavRight |> transitionProperty'
        static member Opacity = Property.Opacity |> transitionProperty'
        static member Order = Property.Order |> transitionProperty'
        static member Orphans = Property.Orphans |> transitionProperty'
        static member OutlineColor = Property.OutlineColor |> transitionProperty'
        static member OutlineOffset = Property.OutlineOffset |> transitionProperty'
        static member OutlineStyle = Property.OutlineStyle |> transitionProperty'
        static member OutlineWidth = Property.OutlineWidth |> transitionProperty'
        static member Outline = Property.Outline |> transitionProperty'
        static member Overflow = Property.Overflow |> transitionProperty'
        static member OverflowWrap = Property.OverflowWrap |> transitionProperty'
        static member OverflowX = Property.OverflowX |> transitionProperty'
        static member OverflowY = Property.OverflowY |> transitionProperty'
        static member PaddingBottom = Property.PaddingBottom |> transitionProperty'
        static member PaddingLeft = Property.PaddingLeft |> transitionProperty'
        static member PaddingRight = Property.PaddingRight |> transitionProperty'
        static member PaddingTop = Property.PaddingTop |> transitionProperty'
        static member Padding = Property.Padding |> transitionProperty'
        static member PageBreakAfter = Property.PageBreakAfter |> transitionProperty'
        static member PageBreakBefore = Property.PageBreakBefore |> transitionProperty'
        static member PageBreakInside = Property.PageBreakInside |> transitionProperty'
        static member Page = Property.Page |> transitionProperty'
        static member PauseAfter = Property.PauseAfter |> transitionProperty'
        static member PauseBefore = Property.PauseBefore |> transitionProperty'
        static member Pause = Property.Pause |> transitionProperty'
        static member Perspective = Property.Perspective |> transitionProperty'
        static member PerspectiveOrigin = Property.PerspectiveOrigin |> transitionProperty'
        static member PitchRange = Property.PitchRange |> transitionProperty'
        static member Pitch = Property.Pitch |> transitionProperty'
        static member PlaceContent = Property.PlaceContent |> transitionProperty'
        static member PlaceItems = Property.PlaceItems |> transitionProperty'
        static member PlaceSelf = Property.PlaceSelf |> transitionProperty'
        static member PlayDuring = Property.PlayDuring |> transitionProperty'
        static member Position = Property.Position |> transitionProperty'
        static member Quotes = Property.Quotes |> transitionProperty'
        static member Resize = Property.Resize |> transitionProperty'
        static member RestAfter = Property.RestAfter |> transitionProperty'
        static member RestBefore = Property.RestBefore |> transitionProperty'
        static member Rest = Property.Rest |> transitionProperty'
        static member Richness = Property.Richness |> transitionProperty'
        static member Right = Property.Right |> transitionProperty'
        static member Size = Property.Size |> transitionProperty'
        static member SpeakHeader = Property.SpeakHeader |> transitionProperty'
        static member SpeakNumeral = Property.SpeakNumeral |> transitionProperty'
        static member SpeakPunctuation = Property.SpeakPunctuation |> transitionProperty'
        static member Speak = Property.Speak |> transitionProperty'
        static member SpeechRate = Property.SpeechRate |> transitionProperty'
        static member Stress = Property.Stress |> transitionProperty'
        static member TabSize = Property.TabSize |> transitionProperty'
        static member TableLayout = Property.TableLayout |> transitionProperty'
        static member TextAlign = Property.TextAlign |> transitionProperty'
        static member TextAlignlast = Property.TextAlignLast |> transitionProperty'
        static member TextDecoration = Property.TextDecoration |> transitionProperty'
        static member TextDecorationColor = Property.TextDecorationColor |> transitionProperty'
        static member TextDecorationLine = Property.TextDecorationLine |> transitionProperty'
        static member TextDecorationThickness = Property.TextDecorationThickness |> transitionProperty'
        static member TextDecorationSkip = Property.TextDecorationSkip |> transitionProperty'
        static member TextDecorationSkipInk = Property.TextDecorationSkipInk |> transitionProperty'
        static member TextDecorationStyle = Property.TextDecorationStyle |> transitionProperty'
        static member TextIndent = Property.TextIndent |> transitionProperty'
        static member TextOverflow = Property.TextOverflow |> transitionProperty'
        static member TextShadow = Property.TextShadow |> transitionProperty'
        static member TextTransform = Property.TextTransform |> transitionProperty'
        static member TextEmphasisColor = Property.TextEmphasisColor |> transitionProperty'
        static member TextEmphasisPosition = Property.TextEmphasisPosition |> transitionProperty'
        static member TextEmphasisStyle = Property.TextEmphasisStyle |> transitionProperty'
        static member TextUnderlineOffset = Property.TextUnderlineOffset |> transitionProperty'
        static member TextUnderlinePosition = Property.TextUnderlinePosition |> transitionProperty'
        static member Top = Property.Top |> transitionProperty'
        static member Transform = Property.Transform |> transitionProperty'
        static member TransformOrigin = Property.TransformOrigin |> transitionProperty'
        static member TransformStyle = Property.TransformStyle |> transitionProperty'
        static member TransitionDelay = Property.TransitionDelay |> transitionProperty'
        static member TransitionDuration = Property.TransitionDuration |> transitionProperty'
        static member TransitionProperty = Property.TransitionProperty |> transitionProperty'
        static member TransitionTimingFunction = Property.TransitionTimingFunction |> transitionProperty'
        static member UnicodeBidi = Property.UnicodeBidi |> transitionProperty'
        static member VerticalAlign = Property.VerticalAlign |> transitionProperty'
        static member Visibility = Property.Visibility |> transitionProperty'
        static member VoiceBalance = Property.VoiceBalance |> transitionProperty'
        static member VoiceDuration = Property.VoiceDuration |> transitionProperty'
        static member VoiceFamily = Property.VoiceFamily |> transitionProperty'
        static member VoicePitch = Property.VoicePitch |> transitionProperty'
        static member VoiceRange = Property.VoiceRange |> transitionProperty'
        static member VoiceRate = Property.VoiceRate |> transitionProperty'
        static member VoiceStress = Property.VoiceStress |> transitionProperty'
        static member VoiceVolume = Property.VoiceVolume |> transitionProperty'
        static member Volume = Property.Volume |> transitionProperty'
        static member WhiteSpace = Property.WhiteSpace |> transitionProperty'
        static member Widows = Property.Widows |> transitionProperty'
        static member Width = Property.Width |> transitionProperty'
        static member WillChange = Property.WillChange |> transitionProperty'
        static member WordBreak = Property.WordBreak |> transitionProperty'
        static member WordSpacing = Property.WordSpacing |> transitionProperty'
        static member WordWrap = Property.WordWrap |> transitionProperty'
        static member ZIndex = Property.ZIndex |> transitionProperty'

        static member None = None |> transitionProperty'
        static member Inherit = Inherit |> transitionProperty'
        static member Initial = Initial |> transitionProperty'
        static member Unset = Unset |> transitionProperty'

    let TransitionProperty' (property: ITransitionProperty) = TransitionProperty.Value(property)
