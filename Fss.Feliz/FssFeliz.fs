namespace Fss.Feliz

open Fss
open Fss.Fable

[<AutoOpen>]
module Fss =
    type Feliz.prop with
        /// Allows you to style Feliz elements with Fss
        static member fss (properties: FssTypes.Rule list) =
            let className = fss properties
            Feliz.prop.className className
        /// Allows you to combine fss with an already existing classname
        static member fssWithClass (className: string) (properties: FssTypes.Rule list) =
            Feliz.prop.className (combine [ className; fss properties ] [ ])
        /// Allows you to optionally combine fss with already existing classnames
        static member fssCombine (classNames: (string * bool) list) (properties: FssTypes.Rule list) =
            Feliz.prop.className (combine [fss properties] classNames)