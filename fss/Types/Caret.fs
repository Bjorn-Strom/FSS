namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module CaretClasses =
    type CaretColor(property) =
        inherit ColorClass.Color(property)
        member this.auto = (property, Auto) |> Rule
