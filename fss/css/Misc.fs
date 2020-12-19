namespace Fss

[<AutoOpen>]
module All =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/all
    let private stringifyAll (all: IAll) =
        match all with
        | :? Global as g -> GlobalValue.global' g
        | _ -> "Unknown all"

    let private allValue value = PropertyValue.cssValue Property.All value
    let private allValue' value =
        value
        |> stringifyAll
        |> allValue

    type All =
        static member Value (all: IAll) = all |> allValue'
        static member Inherit = Inherit |> allValue'


        static member Initial = Initial |> allValue'
        static member Unset = Unset |> allValue'

    let private All' (all: IAll) = all |> All.Value
