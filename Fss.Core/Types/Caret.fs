namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module CaretClasses =
    type CaretColor(property) =
        inherit ColorClass.Color(property)
        member this.auto = (property, Auto) |> Rule
