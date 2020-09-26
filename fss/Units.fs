namespace Fss.Units

open Fss
open Types

module Percent =
    type Percent = 
        | Percent of string
        interface IFontSize
        interface IFontStretch
        interface IBorderWidth
        interface IMargin
        interface IPadding
        interface IFlexBasis
        interface IVerticalAlign
        interface ILinearGradient
        interface IRadialGradient
        interface IBackgroundPosition
        interface IBackgroundSize
        interface IContentSize
        interface ILineHeight
        interface ITextDecorationThickness
        interface ITextIndent
        interface ISize
        interface ITransformOrigin

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
        interface IMargin
        interface IPadding
        interface IFlexBasis
        interface IVerticalAlign
        interface ILinearGradient
        interface IRadialGradient
        interface IBackgroundPosition
        interface IBackgroundSize
        interface IContentSize
        interface ILineHeight
        interface ITextDecorationThickness
        interface ITextIndent
        interface ITransformOrigin

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
    type Time =
        | Sec of string
        | Ms of string
        interface IAnimation

    let value (v: Time) =
        match v with 
            | Sec s -> s
            | Ms ms -> ms