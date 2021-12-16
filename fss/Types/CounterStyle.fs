namespace Fss

// TODO: FALLBACK

namespace Fss.FssTypes

// TODO: Teit navngivning her
type CounterProperty =
    | System
    | Negative
    | Prefix
    | Suffix
    | Range
    | Pad
    | Fallback
    | Symbols
    | AdditiveSymbols
    | SpeakAs

type CounterRule = CounterProperty * ICounterValue

[<RequireQualifiedAccess>]
module Counter =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type System =
        | Cyclic
        | Numeric
        | Alphabetic
        | Symbolic
        | Additive
        | Fixed
        | FixedValue of int
        // TODO: Ikke ha string, men en egen type
        | Extends of string
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | FixedValue value -> $"fixed {value}"
                | Extends extends -> $"extends {extends}"
                | _ -> this.ToString().ToLower()

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        | One of Stringed
        | Two of Stringed * Stringed
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | One s -> (s :> ICssValue).Stringify()
                | Two (a, b) -> $"{(a :> ICssValue).Stringify()} {(b :> ICssValue).Stringify()}"


    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    type FixType =
        | Value of Stringed
        | Image of Image.Image
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | Value s -> (s :> ICssValue).Stringify()
                | Image i -> (i :> ICssValue).Stringify()

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        | Infinite
        | Range' of int
        | Ranges of (Range * Range) list
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | Infinite -> "infinite"
                | Range' i -> string i
                | Ranges is ->
                    List.map (fun (a, b) -> $"{(a :> ICounterValue).Stringify()} {(b :> ICounterValue).Stringify()}") is
                    |> String.concat ", "

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type PadType =
        | PadType of int * Stringed
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | PadType (pad, value) -> $"{pad} {(value :> ICssValue).Stringify()}"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/fallback
    type Fallback =
        | LowerAlpha
        | CustomGangnamStyle

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        | String of string
        | Strings of string list
        | Images of Image.Image list
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | String s -> s
                | Strings s ->
                    s
                    |> List.map Stringed
                    |> List.map (fun x -> (x :> ICssValue).Stringify())
                    |> String.concat " "
                | Images is ->
                    is
                    |> List.map (fun i -> (i :> ICssValue).Stringify())
                    |> String.concat " "

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
    type AdditiveSymbols =
        | AdditiveSymbols of string list
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | AdditiveSymbols s -> s |> String.concat " "

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAs =
        | Auto
        | Bullets
        | Numbers
        | Words
        | SpellOut
        | Value of string
        interface ICounterValue with
            member this.Stringify() =
                match this with
                | Value v -> v
                | _ -> Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module CounterClasses =
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
        type SystemClass() =
            member this.cyclic = (System, Cyclic) |> CounterRule
            member this.numeric = (System, Numeric) |> CounterRule
            member this.alphabetic = (System, Alphabetic) |> CounterRule
            member this.symbolic = (System, Symbolic) |> CounterRule
            member this.additive = (System, Additive) |> CounterRule
            member this.fixed' = (System, Fixed) |> CounterRule

            member this.fixedValue(value: int) =
                (System, FixedValue value) |> CounterRule

            member this.extends(extends: string) =
                (System, Extends extends) |> CounterRule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
        type NegativeClass() =
            member this.value(negative: string) =
                (Negative, One(Stringed negative)) |> CounterRule

            member this.value(one: string, two: string) =
                (Negative, Two(Stringed one, Stringed two))
                |> CounterRule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
        type CounterImage(property) =
            member this.url(url: string) =
                (property, Image.ImageClasses.Image.url url)
                |> CounterRule

            member this.linearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
                (property, Image.ImageClasses.Image.linearGradient gradients)
                |> CounterRule


            member this.linearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
                (property, Image.ImageClasses.Image.linearGradients gradients)
                |> CounterRule

            member this.repeatingLinearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
                (property, Image.RepeatingLinearGradient gradients)
                |> CounterRule

            member this.repeatingLinearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
                (property, Image.RepeatingLinearGradients gradients)
                |> CounterRule

            member this.radialGradient
                (
                    shape: Image.Shape,
                    size: Image.Side,
                    x: Percent,
                    y: Percent,
                    gradients: (Color * ILengthPercentage) list
                ) =
                (property, Image.RadialGradient(shape, size, x, y, gradients))
                |> CounterRule

            member this.radialGradients
                (gradients: (Image.Shape * Image.Side * Percent * Percent * (Color * ILengthPercentage) list) list)
                =
                (property, Image.RadialGradients(gradients))
                |> CounterRule


            member this.repeatingRadialGradient
                (
                    shape: Image.Shape,
                    size: Image.Side,
                    x: Percent,
                    y: Percent,
                    gradients: (Color * ILengthPercentage) list
                ) =
                (property, Image.RepeatingRadialGradient(shape, size, x, y, gradients))
                |> CounterRule

            member this.conicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Angle) list) =
                (property, Image.ConicGradientAngle(angle, x, y, gradients))
                |> CounterRule


            member this.conicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Percent) list) =
                (property, Image.ConicGradientPercent(angle, x, y, gradients))
                |> CounterRule


            member this.repeatingConicGradient(angle: Angle, x: Percent, y: Percent, gradients: (Color * Angle) list) =
                (property, Image.RepeatingConicGradientAngle(angle, x, y, gradients))
                |> CounterRule


            member this.repeatingConicGradient
                (
                    angle: Angle,
                    x: Percent,
                    y: Percent,
                    gradients: (Color * Percent) list
                ) =
                (property, Image.RepeatingConicGradientPercent(angle, x, y, gradients))
                |> CounterRule

        type FixClass(property) =
            inherit CounterImage(property)

            member this.value(fix: string) =
                (property, FixType.Value <| Stringed fix)
                |> CounterRule

        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
        type RangeClass() =
            member this.auto =
                (Range, Fss.FssTypes.Auto) |> CounterRule

            member this.value(a: int, b: int) =
                (Range, Range.Ranges [ Range.Range' a, Range.Range' b ])
                |> CounterRule

            member this.value(range: (Range * Range) list) =
                (Range, Range.Ranges range) |> CounterRule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
        type PadClass() =
            member this.value(pad: int, value: string) =
                let pad = PadType.PadType(pad, Stringed value)
                (Pad, pad) |> CounterRule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
        type SymbolsClass() =
            inherit CounterImage(CounterProperty.Symbols)

            member this.value(symbols: string) =
                (Symbols, Symbols.String symbols) |> CounterRule

            member this.value(symbols: string list) =
                (Symbols, Symbols.Strings symbols) |> CounterRule

            member this.value(images: Image.Image list) =
                (Symbols, Symbols.Images images) |> CounterRule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
        type AdditiveSymbolsClass() =
            member this.value(symbols: string list) =
                (Symbols, AdditiveSymbols.AdditiveSymbols symbols)
                |> CounterRule
        // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
        type SpeakAsClass() =
            member this.auto = (SpeakAs, Auto) |> CounterRule
            member this.bullets = (SpeakAs, Bullets) |> CounterRule
            member this.numbers = (SpeakAs, Numbers) |> CounterRule
            member this.words = (SpeakAs, Words) |> CounterRule
            member this.spellOut = (SpeakAs, SpellOut) |> CounterRule
            member this.value(ident: string) = (SpeakAs, Value ident) |> CounterRule
