namespace Fss

[<RequireQualifiedAccess>]
module Types =
    type CounterStyle =
        | CounterStyle of string
        interface Types.IContent
        interface Types.IListStyleType

    type CounterReset =
        | Reset of CounterStyle
        | ResetTo of CounterStyle * int
        interface Types.ICounterReset

    type CounterIncrement =
        | Increment of CounterStyle
        | Add of CounterStyle * int
        interface Types.ICounterIncrement

    let internal counterStyleToString (CounterStyle c) = c

