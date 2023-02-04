namespace Fss

open Fss

[<AutoOpen>]
module Feliz =
    type Feliz.prop with
        /// Allows you to style Feliz elements with Fss
        static member fss (properties: Fss.Types.Rule list) =
            let className = fss properties
            Feliz.prop.className className
        /// Allows you to style Feliz elements with Fss
        static member fssWithClassname (classname: string) (properties: Fss.Types.Rule list) =
            let className = fssWithClassname classname properties
            Feliz.prop.className className
        /// Allows you to combine fss with an already existing classname
        static member fssWithClass (className: string) (properties: Fss.Types.Rule list) =
            Feliz.prop.className (combine [ className; fss properties ] [ ])
        /// Allows you to optionally combine fss with already existing classnames
        static member fssCombine (classNames: (string * bool) list) (properties: Fss.Types.Rule list) =
            Feliz.prop.className (combine [fss properties] classNames)