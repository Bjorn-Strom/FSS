
namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module AccentClasses =
    type AccentColor(property) =
        inherit ColorClass.Color(property)
        member this.auto = (property, Auto) |> Rule
