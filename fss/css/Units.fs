namespace Fss.Units

open Fss
open Types

module Percent =
    type Percent =
        | Percent of string
        interface IFontSize
        interface IFontStretch
        interface IBorderWidth
        interface IBorderRadius
        interface IBorderImageWidth
        interface IBorderImageSlice
        interface IMargin
        interface IPadding
        interface IFlexBasis
        interface IVerticalAlign
        interface ILinearGradient
        interface IRadialGradient
        interface IImagePosition
        interface IBackgroundSize
        interface IContentSize
        interface ILineHeight
        interface ITextDecorationThickness
        interface ITextIndent
        interface ISize
        interface ITransformOrigin
        interface ITextUnderlineOffset
        interface IPlacement
        interface IGridAutoColumns
        interface IGridAutoRows
        interface IGridTemplateColumns
        interface IGridTemplateRows
        interface IMinMax
        interface IRepeat

    let value (Percent p): string = p

// https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Values_and_units
module Size =
    open Percent
    type Size =
        | Px of string
        | In of string
        | Cm of string
        | Mm of string
        | Pt of string
        | Pc of string
        | Em of string
        | Rem of string
        | Ex of string
        | Ch of string
        | Vw of string
        | Vh of string
        | VMax of string
        | VMin of string
        interface ISize
        interface IFontSize
        interface IBorderWidth
        interface IBorderRadius
        interface IBorderSpacing
        interface IBorderImageWidth
        interface IBorderImageOutset
        interface IMargin
        interface IPadding
        interface IFlexBasis
        interface IVerticalAlign
        interface ILinearGradient
        interface IRadialGradient
        interface IImagePosition
        interface IBackgroundSize
        interface IContentSize
        interface ILineHeight
        interface ITextDecorationThickness
        interface ITextIndent
        interface ITransformOrigin
        interface IPerspective
        interface ITextUnderlineOffset
        interface IPlacement
        interface IGridAutoColumns
        interface IGridAutoRows
        interface IGridTemplateColumns
        interface IGridTemplateRows
        interface IMinMax
        interface IRepeat

    let private sizeValue (u: Size) =
        match u with
            | Px p -> p
            | In i -> i
            | Cm c -> c
            | Mm m -> m
            | Pt p -> p
            | Pc p -> p
            | Em e -> e
            | Rem r -> r
            | Ex e -> e
            | Ch c -> c
            | Vw v -> v
            | Vh v -> v
            | VMax v -> v
            | VMin v -> v

    let value (v: ISize): string =
        match v with
            | :? Percent as p -> Percent.value p
            | :? Size    as s -> sizeValue s
            | _               -> "Unkown size"

// https://developer.mozilla.org/en-US/docs/Web/CSS/angle
module Angle =
    type Angle =
        | Deg of string
        | Grad of string
        | Rad of string
        | Turn of string
        interface ITransform
        interface ILinearGradient
        interface IRadialGradient
        interface IFontStyle

    let value (u: Angle) =
        match u with
            | Deg d -> d
            | Grad g -> g
            | Rad r -> r
            | Turn t -> t

module Resolution =
    type Resolution =
        | Dpi of string

    let value (r: Resolution) =
        match r with
            | Dpi d -> sprintf "%sdpi" d

module Time =
    open Global

    type Time =
        | Sec of string
        | Ms of string
        interface ITime

    let value (v: ITime): string =
        let stringifyTime (t: Time) =
            match t with
            | Sec s -> s
            | Ms ms -> ms

        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Time   as t -> stringifyTime t
            | _ -> "Unknown transition duration"
            
module Fraction =
    type Fraction =
        | Fr of string
        interface IFraction
        interface IMinMax
        interface IGridAutoColumns
        interface IGridTemplateRows
        interface IGridAutoRows
        interface IGridTemplateColumns
        interface IRepeat
        
    let value (Fr f) = f