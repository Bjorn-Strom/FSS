namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type Percent =
        | Percent of string
        interface Types.ILengthPercentage
        interface Types.ITemplateType
        interface Types.IBackgroundSize
        interface Types.IBackgroundPosition
        interface Types.IFlexBasis
        interface Types.IFontSize
        interface Types.IFontStretch
        interface Types.ILineHeight
        interface Types.IBorderRadius
        interface Types.IBorderSpacing
        interface Types.IBorderImageWidth
        interface Types.IBorderImageSlice
        interface Types.IBorderImageOutset
        interface Types.IGridGap
        interface Types.IGridRowGap
        interface Types.IGridColumnGap
        interface Types.IColumnGap
        interface Types.IGridAutoRows
        interface Types.IGridAutoColumns
        interface Types.IMargin
        interface Types.IPadding
        interface Types.ITransformOrigin
        interface Types.ITextIndent
        interface Types.ITextDecorationThickness
        interface Types.ITextUnderlineOffset
        interface Types.ITextSizeAdjust
        interface Types.IPositioned
        interface Types.IVerticalAlign
        interface Types.IWordSpacing
        interface Types.IPerspectiveOrigin
        interface Types.IMaskPosition
    let internal percentToString (Percent p): string = p

    // https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Values_and_units
    type Size =
        | Px of string
        | In of string
        | Cm of string
        | Mm of string
        | Pt of string
        | Pc of string
        | Em' of string
        | Rem of string
        | Ex of string
        | Ch of string
        | Vw of string
        | Vh of string
        | VMax of string
        | VMin of string
        interface Types.ILengthPercentage
        interface Types.ITemplateType
        interface Types.IBorderWidth
        interface Types.IBorderImageOutset
        interface Types.IBorderSpacing
        interface Types.IBorderRadius
        interface Types.IBorderImageWidth
        interface Types.IBorderImageSlice
        interface Types.IPerspective
        interface Types.IOutlineWidth
        interface Types.IOutlineOffset
        interface Types.IBackgroundSize
        interface Types.IBackgroundPosition
        interface Types.IFlexBasis
        interface Types.IFontSize
        interface Types.ILineHeight
        interface Types.ILetterSpacing
        interface Types.IGridGap
        interface Types.IGridRowGap
        interface Types.IGridColumnGap
        interface Types.IGridTemplateRows
        interface Types.IGridTemplateColumns
        interface Types.IGridAutoRows
        interface Types.IGridAutoColumns
        interface Types.IColumnGap
        interface Types.IColumnRuleWidth
        interface Types.IColumnWidth
        interface Types.IMargin
        interface Types.IPadding
        interface Types.ITransformOrigin
        interface Types.ITextIndent
        interface Types.ITextUnderlineOffset
        interface Types.ITextDecorationThickness
        interface Types.IPositioned
        interface Types.IVerticalAlign
        interface Types.IWordSpacing
        interface Types.ITabSize
        interface Types.IScrollMargin
        interface Types.IScrollPadding
        interface Types.IMaskPosition

    let internal sizeToString (v: Size): string =
        match v with
            | Px p -> p
            | In i -> i
            | Cm c -> c
            | Mm m -> m
            | Pt p -> p
            | Pc p -> p
            | Em' e -> e
            | Rem r -> r
            | Ex e -> e
            | Ch c -> c
            | Vw v -> v
            | Vh v -> v
            | VMax v -> v
            | VMin v -> v

    let internal lengthPercentageToString (v: Types.ILengthPercentage) =
        match v with
        | :? Size    as s -> sizeToString s
        | :? Percent as p -> percentToString p
        | _ -> "Unknown length/percentage"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/angle
    type Angle =
        | Deg of string
        | Grad of string
        | Rad of string
        | Turn of string

    let internal angleToString (u: Angle) =
        match u with
            | Deg d -> d
            | Grad g -> g
            | Rad r -> r
            | Turn t -> t

    type Resolution =
        | Dpi of string

    let internal resolutionToString (r: Resolution) =
        match r with
            | Dpi d -> sprintf "%sdpi" d

    type Time =
        | Sec of string
        | Ms of string
        interface Types.ITransitionDelay
        interface Types.ITransitionDuration

    let internal timeToString (v: Time): string =
        match v with
        | Sec s -> s
        | Ms ms -> ms

    type Fraction =
        | Fr of string
        interface Types.IGridTemplateRows
        interface Types.IGridTemplateColumns
        interface Types.IGridAutoRows
        interface Types.IGridAutoColumns
        interface Types.ITemplateType

    let internal fractionToString (Fr f) = f