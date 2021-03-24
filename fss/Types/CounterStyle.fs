namespace Fss

namespace Fss.FssTypes

    open Fss.FssTypes

    [<RequireQualifiedAccess>]
    module Counter =
        type Style =
            | Style of string
            interface IContent
            interface IListStyleType

        type Reset =
            | Reset of Style
            | ResetTo of Style * int
            interface ICounterReset

        type Increment =
            | Increment of Style
            | Add of Style * int
            interface ICounterIncrement

    [<AutoOpen>]
    module counterStyleHelpers =
        let counterStyleToString (Counter.Style c) = c

