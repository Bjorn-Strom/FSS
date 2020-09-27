﻿namespace Fss

module FontFace =
    open Types
    
     // https://developer.mozilla.org/en-US/docs/Web/CSS/@font-face
    type Format =
        | Truetype
        | Opentype
        | EmpbeddedOpentype
        | Woff
        | Woff2
        | Svg

    type Source =
        | Url of string * Format
        | Local of string

    type FontFace =
        | Source of Source
        | Sources of Source list
        | FontStyle of IFontStyle
        | FontDisplay of IFontDisplay
        | FontStretch of IFontStretch
        | FontWeight of IFontWeight
        
module FontFaceValue =
    open Fable.Core.JsInterop
    
    open FontFace
    open Utilities.Helpers
    
    let private source (v: Source): string =
        match v with
            | Url (s, f) -> sprintf "url('%s') format('%s')" s (duToKebab f)
            | Local l    -> sprintf "local('%s')" l

    let createFontFaceObject (fontName: string) (attributeList: FontFace list) =
        let innerStyle =
            attributeList |> List.map (
                function
                    | Source      s -> "src"                               ==> source s
                    | Sources     s -> "src"                               ==> combineComma source s
                    | FontStyle   f -> Property.value Property.fontStyle   ==> FontValues.fontStyle f
                    | FontDisplay f -> Property.value Property.fontDisplay ==> FontValues.fontDisplay f
                    | FontStretch f -> Property.value Property.fontStretch ==> FontValues.fontStretch f
                    | FontWeight  f -> Property.value Property.fontWeight  ==> FontValues.fontWeight f)

        createObj
            [
                "@font-face" ==>
                    createObj
                        ([
                            "fontFamily" ==> fontName
                        ] @ innerStyle)
            ]