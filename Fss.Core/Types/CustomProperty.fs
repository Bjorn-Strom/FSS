namespace Fss
namespace Fss.Types

[<RequireQualifiedAccess>]
module CustomProperty =
    type Syntax =
        | Color
        | Length
        | Percentage
        | LengthPercentage
        | Number
        | Integer
        | Angle
        | Time
        | Resolution
        | TransformFunction
        | TransformList
        | Image
        | Url
        | CustomIdent
        | Any
        | Custom of string
        member this.Stringify() =
            match this with
            | Color -> "<color>"
            | Length -> "<length>"
            | Percentage -> "<percentage>"
            | LengthPercentage -> "<length-percentage>"
            | Number -> "<number>"
            | Integer -> "<integer>"
            | Angle -> "<angle>"
            | Time -> "<time>"
            | Resolution -> "<resolution>"
            | TransformFunction -> "<transform-function>"
            | TransformList -> "<transform-list>"
            | Image -> "<image>"
            | Url -> "<url>"
            | CustomIdent -> "<custom-ident>"
            | Any -> "*"
            | Custom s -> s
