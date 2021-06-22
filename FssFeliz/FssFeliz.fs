namespace Fss.Feliz

open Feliz
open Fss

[<AutoOpen>]
module fss =
    type prop with
        static member fss (properties: FssTypes.CssProperty list) = prop.className (fss properties)
        static member fssWithClassName (className: string) (properties: FssTypes.CssProperty list) =
            prop.className (combine [ className; fss properties ] [ ])
        static member fssWithClassNames (classNames: (string * bool) list) (properties: FssTypes.CssProperty list) =
            prop.className (combine [fss properties] classNames)