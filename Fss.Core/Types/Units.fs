namespace Fss

namespace Fss.Types

type IUnit =
    interface
    end

type ILengthPercentage =
    interface
    end

type Percent =
    | Percent of int
    interface IUnit
    interface ILengthPercentage
    interface IFontFaceValue with
        member this.StringifyFontFace() = stringifyICssValue this

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Percent p -> $"{p}%%"

// https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Values_and_units
type Length =
    | Px of int
    | In of float
    | Cm of float
    | Mm of float
    | Pt of float
    | Pc of float
    | Em' of float
    | Rem of float
    | Ex of float
    | Ch of float
    | Vw of float
    | Vh of float
    | VMax of float
    | VMin of float
    interface IUnit
    interface ILengthPercentage

    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Px p -> $"{p}px"
            | In i -> $"{i}in"
            | Cm c -> $"{c}cm"
            | Mm m -> $"{m}mm"
            | Pt p -> $"{p}pt"
            | Pc p -> $"{p}pc"
            | Em' e -> $"{e}em"
            | Rem r -> $"{r}rem"
            | Ex e -> $"{e}ex"
            | Ch c -> $"{c}ch"
            | Vw v -> $"{v}vw"
            | Vh v -> $"{v}vh"
            | VMax v -> $"{v}vmax"
            | VMin v -> $"{v}vmin"


// https://developer.mozilla.org/en-US/docs/Web/CSS/angle
type Angle =
    | Deg of float
    | Grad of float
    | Rad of float
    | Turn of float
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Deg d -> $"{d}deg"
            | Grad g -> $"{g}grad"
            | Rad r -> $"{r}rad"
            | Turn t -> $"{t}turn"

type Resolution =
    | Dpi of string
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Dpi dpi -> $"{dpi}dpi"

type Time =
    | Sec of float
    | Ms of float
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Sec s -> $"{s}s"
            | Ms ms -> $"{ms}ms"

type Fraction =
    | Fr of float
    interface ICssValue with
        member this.StringifyCss() =
            match this with
            | Fr f -> $"{f}fr"

[<AutoOpen>]
module unitHelpers =
    let internal lengthPercentageToType (lp: ILengthPercentage) =
        match lp with
        | :? Percent as p -> p :> ICssValue
        | :? Length as l -> l :> ICssValue
        | _ -> Px 0

    let internal lengthPercentageString (lp: ILengthPercentage) =
        match lp with
        | :? Percent as p -> stringifyICssValue p 
        | :? Length as l -> stringifyICssValue l 
        | _ -> ""

    type CssRuleWithLength(property) =
        inherit CssRule(property)

        member this.value(length: ILengthPercentage) =
            (property, lengthPercentageToType length) |> Rule

    type CssRuleWithLengthNormal(property) =
        inherit CssRuleWithLength(property)
        member this.normal = (property, Normal) |> Rule

    type CssRuleWithLengthNone(property) =
        inherit CssRuleWithLength(property)
        member this.none = (property, None') |> Rule

    type CssRuleWithAutoLength(property) =
        inherit CssRuleWithAuto(property)

        member this.value(length: ILengthPercentage) =
            (property, lengthPercentageToType length) |> Rule

    type CssRuleWithAutoLengthNone(property) =
        inherit CssRuleWithAutoLength(property)
        member this.none = (property, None') |> Rule

    type DirectionalLength(property) =
        inherit CssRule(property)

        member this.value(length: ILengthPercentage) =
            (property, lengthPercentageToType length) |> Rule

        member this.value(vertical: ILengthPercentage, horizontal: ILengthPercentage) =
            let value =
                $"{lengthPercentageString vertical} {lengthPercentageString horizontal}"
                |> String
            (property, value) |> Rule

        member this.value(top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage) =
            let value =
                $"{lengthPercentageString top} {lengthPercentageString horizontal} {lengthPercentageString bottom}"
                |> String

            (property, value) |> Rule

        member this.value
            (
                top: ILengthPercentage,
                right: ILengthPercentage,
                bottom: ILengthPercentage,
                left: ILengthPercentage
            ) =
            let value =
                $"{lengthPercentageString top} {lengthPercentageString right} {lengthPercentageString bottom} {lengthPercentageString left}"
                |> String

            (property, value) |> Rule