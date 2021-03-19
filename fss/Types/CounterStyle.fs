namespace FssTypes

[<RequireQualifiedAccess>]
module Counter =
    type CounterStyle =
        | CounterStyle of string
        interface IContent
        interface IListStyleType

    type CounterReset =
        | Reset of CounterStyle
        | ResetTo of CounterStyle * int
        interface ICounterReset

    type CounterIncrement =
        | Increment of CounterStyle
        | Add of CounterStyle * int
        interface ICounterIncrement
    let counterValue (CounterStyle c) = c

