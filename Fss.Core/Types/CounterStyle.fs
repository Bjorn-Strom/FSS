namespace Fss
namespace Fss.Types

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
        | Extends of string
        interface ICounterValue with
            member this.StringifyCounter() =
                match this with
                | Cyclic -> "cyclic"
                | Numeric -> "numeric"
                | Alphabetic -> "alphabetic"
                | Symbolic -> "symbolic"
                | Additive -> "additive"
                | Fixed -> "fixed"
                | FixedValue value -> $"fixed {value}"
                | Extends extends -> $"extends {extends}"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type Negative =
        | One of Stringed
        | Two of Stringed * Stringed
        interface ICounterValue with
            member this.StringifyCounter() =
                match this with
                | One s -> (stringifyICssValue s)
                | Two (a, b) -> $"{(stringifyICssValue a)} {(stringifyICssValue b)}"


    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type Range =
        | Infinite
        | Range' of int
        | Ranges of (Range * Range) list
        interface ICounterValue with
            member this.StringifyCounter() =
                match this with
                | Infinite -> "infinite"
                | Range' i -> string i
                | Ranges is ->
                    List.map (fun (a, b) -> $"{stringifyICounterValue a} {stringifyICounterValue b}") is
                    |> String.concat ", "

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type PadType =
        | PadType of int * Stringed
        interface ICounterValue with
            member this.StringifyCounter() =
                match this with
                | PadType (pad, value) -> $"{pad} {(stringifyICssValue value)}"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/fallback
    type Fallback =
        | LowerAlpha
        | CustomGangnamStyle
        interface ICounterValue with
            member this.StringifyCounter() = Fss.Utilities.Helpers.toKebabCase this

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type Symbols =
        | String of string
        | Strings of string list
        | Images of Image.Image list
        interface ICounterValue with
            member this.StringifyCounter() =
                match this with
                | String s -> s
                | Strings s ->
                    s
                    |> List.map Stringed
                    |> List.map stringifyICssValue
                    |> String.concat " "
                | Images is ->
                    is
                    |> List.map stringifyICssValue
                    |> String.concat " "

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
    type AdditiveSymbols =
        | AdditiveSymbols of string list
        interface ICounterValue with
            member this.StringifyCounter() =
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
            member this.StringifyCounter() =
                match this with
                | Value v -> v
                | _ -> Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module CounterClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/system
    type SystemClass() =
        /// Cycles through a list of provided symbols
        /// Once the end has been reached it loops back to the beginning and starts over
        member this.cyclic = (Property.CounterProperty.System, Counter.Cyclic) |> CounterRule
        /// Numeric counter style
        member this.numeric = (Property.CounterProperty.System, Counter.Numeric) |> CounterRule
        /// Interprets specified symbols as digits
        member this.alphabetic = (Property.CounterProperty.System, Counter.Alphabetic) |> CounterRule
        /// Cycles through a provided list of symbols
        /// For each pass the counter representation are doubled, then tripled and so on
        member this.symbolic = (Property.CounterProperty.System, Counter.Symbolic) |> CounterRule
        /// Represents sign value numbering systems such as roman numerals
        member this.additive = (Property.CounterProperty.System, Counter.Additive) |> CounterRule
        /// Defines a finite set of symbols
        member this.fixed' = (Property.CounterProperty.System, Counter.Fixed) |> CounterRule
        member this.fixedValue(value: int) = (Property.CounterProperty.System, Counter.FixedValue value) |> CounterRule
        member this.extends(extends: string) = (Property.CounterProperty.System, Counter.Extends extends) |> CounterRule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/negative
    type NegativeClass() =
        member this.value(negative: string) =
            (Property.CounterProperty.Negative, Counter.One(Stringed negative)) |> CounterRule

        member this.value(one: string, two: string) =
            (Property.CounterProperty.Negative, Counter.Two(Stringed one, Stringed two))
            |> CounterRule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/prefix
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/suffix
    type CounterImage(property) =
        member this.url(url: string) =
            (property, ImageClasses.Image.url url)
            |> CounterRule

        member this.linearGradient(gradients: Angle * (Color * ILengthPercentage) list) =
            (property, ImageClasses.Image.linearGradient gradients)
            |> CounterRule


        member this.linearGradients(gradients: (Angle * (Color * ILengthPercentage) list) list) =
            (property, ImageClasses.Image.linearGradients gradients)
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
            (property, Stringed fix)
            |> CounterRule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/range
    type RangeClass() =
        member this.auto =
            (Property.CounterProperty.Range, Auto) |> CounterRule

        member this.value(a: int, b: int) =
            (Property.CounterProperty.Range, Counter.Range.Ranges [ Counter.Range.Range' a, Counter.Range.Range' b ])
            |> CounterRule

        member this.value(range: (Counter.Range * Counter.Range) list) =
            (Property.CounterProperty.Range, Counter.Range.Ranges range) |> CounterRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/pad
    type PadClass() =
        member this.value(pad: int, value: string) =
            let pad = Counter.PadType(pad, Stringed value)
            (Property.CounterProperty.Pad, pad) |> CounterRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/symbols
    type SymbolsClass() =
        inherit CounterImage(Property.CounterProperty.Symbols)

        member this.value(symbols: string) =
            (Property.CounterProperty.Symbols, String symbols) |> CounterRule

        member this.value(symbols: string list) =
            let symbols =
                symbols
                |> List.map (fun s -> $"\"{s}\"")
                |> String.concat " "
            (Property.CounterProperty.Symbols, String symbols) |> CounterRule

        member this.value(images: Image.Image list) =
            let images =
                images
                |> List.map stringifyICssValue
                |> String.concat " "
            (Property.CounterProperty.Symbols, String images) |> CounterRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/additive-symbols
    type AdditiveSymbolsClass() =
        member this.value(symbols: string list) =
            (Property.CounterProperty.Symbols, Counter.AdditiveSymbols symbols)
            |> CounterRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/speak-as
    type SpeakAsClass() =
        member this.auto = (Property.CounterProperty.SpeakAs, Auto) |> CounterRule
        member this.bullets = (Property.CounterProperty.SpeakAs, Counter.Bullets) |> CounterRule
        member this.numbers = (Property.CounterProperty.SpeakAs, Counter.Numbers) |> CounterRule
        member this.words = (Property.CounterProperty.SpeakAs, Counter.Words) |> CounterRule
        member this.spellOut = (Property.CounterProperty.SpeakAs, Counter.SpellOut) |> CounterRule
        member this.value(ident: string) = (Property.CounterProperty.SpeakAs, Counter.Value ident) |> CounterRule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/@counter-style/fallback
    type FallbackClass() =
        member this.lowerAlpha = (Property.CounterProperty.Fallback, Counter.LowerAlpha) |> CounterRule

        member this.customGangnamStyle =
            (Property.CounterProperty.Fallback, Counter.CustomGangnamStyle) |> CounterRule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-reset
    type CounterReset(property) =
        inherit CssRuleWithNone(property)

        member this.value(counter: string) =
            (property, String counter) |> Rule

        member this.value(counter: string, value: int) =
            let value = $"{counter} {value}"
            (property, String value) |> Rule

        member this.reversed(counter: string) =
            let value = $"reversed({counter})"
            (property, String value) |> Rule

        member this.reversed(counter: string, value: int) =
            let value = $"reversed({counter}) {value}"
            (property, String value) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-set
    type CounterSet(property) =
        inherit CssRuleWithNone(property)

        member this.value(counter: string) =
            (property, String counter) |> Rule

        member this.value(counter: string, value: int) =
            let value = $"{counter} {value}"
            (property, String value) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/counter-increment
    type CounterIncrement(property) =
        inherit CssRuleWithNone(property)

        member this.value(counter: string) =
            (property, String counter) |> Rule

        member this.value(counter: string, value: int) =
            let value = $"{counter} {value}"
            (property, String value) |> Rule
