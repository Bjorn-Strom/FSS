﻿namespace Fss.Feliz

open Feliz
open Fss
open Fss.FssTypes

[<AutoOpen>]
module fss =
    let foo = 0
    (*
    type prop with
        /// Allows you to style Feliz elements with Fss
        static member fss (properties: FssTypes.CssRule list) = prop.className (fss properties)
        /// Allows you to combine fss with an already existing classname
        static member fssWithClass (className: string) (properties: FssTypes.CssRule list) =
            prop.className (combine [ className; fss properties ] [ ])
        /// Allows you to optionally combine fss with already existing classnames
        static member fssCombine (classNames: (string * bool) list) (properties: FssTypes.CssRule list) =
            prop.className (combine [fss properties] classNames)
            *)