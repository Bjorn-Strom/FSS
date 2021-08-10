namespace Fss

namespace Fss.FssTypes
    type Percent =
        | Percent of string
        interface ILengthPercentage
        interface ITemplateType
        interface IBackgroundSize
        interface IBackgroundPosition
        interface IFlexBasis
        interface IFontSize
        interface IFontStretch
        interface ILineHeight
        interface IBorderRadius
        interface IBorderSpacing
        interface IBorderImageWidth
        interface IBorderImageSlice
        interface IBorderImageOutset
        interface IGridGap
        interface IGridRowGap
        interface IGridColumnGap
        interface IColumnGap
        interface IGridAutoRows
        interface IGridAutoColumns
        interface IMargin
        interface IPadding
        interface ITransformOrigin
        interface ITextIndent
        interface ITextDecorationThickness
        interface ITextUnderlineOffset
        interface ITextSizeAdjust
        interface IPositioned
        interface IVerticalAlign
        interface IWordSpacing
        interface IPerspectiveOrigin
        interface IMaskPosition
        interface IMaskSize
        interface IBaselineShift
        interface IStrokeWidth
        interface ILineGapOverride

    // https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Values_and_units
    type Length =
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
        interface ILengthPercentage
        interface ITemplateType
        interface IBorderWidth
        interface IBorderImageOutset
        interface IBorderSpacing
        interface IBorderRadius
        interface IBorderImageWidth
        interface IBorderImageSlice
        interface IPerspective
        interface IOutlineWidth
        interface IOutlineOffset
        interface IBackgroundSize
        interface IBackgroundPosition
        interface IFlexBasis
        interface IFontSize
        interface ILineHeight
        interface ILetterSpacing
        interface IGridGap
        interface IGridRowGap
        interface IGridColumnGap
        interface IGridTemplateRows
        interface IGridTemplateColumns
        interface IGridAutoRows
        interface IGridAutoColumns
        interface IColumnGap
        interface IColumnRuleWidth
        interface IColumnWidth
        interface IMargin
        interface IPadding
        interface ITransformOrigin
        interface ITextIndent
        interface ITextUnderlineOffset
        interface ITextDecorationThickness
        interface IPositioned
        interface IVerticalAlign
        interface IWordSpacing
        interface ITabSize
        interface IScrollMargin
        interface IScrollPadding
        interface IMaskPosition
        interface IMaskSize
        interface IBaselineShift
        interface IStrokeWidth

    // https://developer.mozilla.org/en-US/docs/Web/CSS/angle
    type Angle =
        | Deg of string
        | Grad of string
        | Rad of string
        | Turn of string

    type Resolution =
        | Dpi of string

    type Time =
        | Sec of string
        | Ms of string
        interface ITransitionDelay
        interface ITransitionDuration

    type Fraction =
        | Fr of string
        interface IGridTemplateRows
        interface IGridTemplateColumns
        interface IGridAutoRows
        interface IGridAutoColumns
        interface ITemplateType

    [<AutoOpen>]
    module unitHelpers =
        let internal percentToString (Percent p): string = p
        let internal sizeToString (v: Length): string =
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
        let internal lengthPercentageToString (v: ILengthPercentage) =
            match v with
            | :? Length    as s -> sizeToString s
            | :? Percent as p -> percentToString p
            | _ -> "Unknown length/percentage"
        let internal angleToString (u: Angle) =
            match u with
                | Deg d -> d
                | Grad g -> g
                | Rad r -> r
                | Turn t -> t
        let internal resolutionToString (r: Resolution) =
            match r with
                | Dpi d -> sprintf "%sdpi" d
        let internal timeToString (v: Time): string =
            match v with
            | Sec s -> s
            | Ms ms -> ms
        let internal fractionToString (Fr f) = f

