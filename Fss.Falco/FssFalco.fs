namespace Fss

open Fss
open System.Collections.Generic;
open Falco.Markup

[<AutoOpen>]
module Falco =
    let styleCache = Dictionary<string, XmlNode>()
    let private createStyleNode className (css: string) =
        if styleCache.ContainsKey className then
            styleCache[className]
        else
            let newNode = Elem.style [ Attr.type' "text/css" ] [ Text.raw css ]
            styleCache.Add (className, newNode)
            newNode

    /// Creates Css node and returns the classname and xml node
    let fss (properties: Fss.Types.Rule list): string * XmlNode =
        let className, cssRules = createFss properties

        className, createStyleNode className cssRules
        
    /// Injects CSS into dom with a specific classname and returns the classname
    let fssWithClassname (classname: string) (properties: Fss.Types.Rule list): string * XmlNode =
        let className, cssRules = createFssWithClassname classname properties

        className, createStyleNode className cssRules

    // Creates Css node as global styles. Returns XmlNode
    let global'(properties: Fss.Types.Rule list): XmlNode =
        let cssRules = createGlobal properties
        createStyleNode "*" cssRules

    let private processCounterRules (rules: string) =
        $"@counter-style {rules}"

    /// Creates counter style node and returns the counter name and xml node
    let counterStyle (properties: Fss.Types.CounterRule list): string * XmlNode =
        let counterName, counterStyle =
            properties
            |> createCounterStyle

        counterName, createStyleNode counterName <| processCounterRules counterStyle

    let private processFontFaceRules (rules: string) =
        $"@font-face {rules}"

    /// Creates font face node and returns the font name and xml node
    let fontFaces name (properties: Fss.Types.FontFaceRule list list): string * XmlNode =
        let fontName, fontStyles =
            properties
            |> createFontFaces name

        fontName, createStyleNode fontName <| processFontFaceRules fontStyles

    let private processAnimationRules (rules: string) =
        $"@keyframes {rules}"

    /// Creates keyframes node and returns the counter name
    let keyframes (properties: Keyframes list): string * XmlNode =
        let animationName, animationStyles =
            properties
            |> createAnimation

        animationName, createStyleNode animationName <| processAnimationRules animationStyles
