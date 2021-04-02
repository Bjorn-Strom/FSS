namespace Fss

namespace Fss.FssTypes

    type CaretColorClass (valueFunction: ICaretColor -> CssProperty) =
        inherit ColorBase(valueFunction)
        member this.value color = color |> valueFunction
        member this.auto = Auto |> valueFunction
