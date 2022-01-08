namespace Fss.Giraffe

open Fss
open System.Collections.Generic;
open Giraffe.ViewEngine

[<AutoOpen>]
module Fss =
    let styleCache = Dictionary<string, XmlNode>()
    let private createStyleNode className (css: string) =
        if styleCache.ContainsKey className then
            styleCache[className]
        else
            let newNode = style [ _type "text/css" ] [ rawText css ]
            styleCache.Add (className, newNode)
            newNode
    
    let private processCssRule (name: string, rule: string) =
        $"{name} {rule}"
        
    /// Creates Css node and returns the classname and xml node
    let fss (properties: Fss.Types.Rule list): string * XmlNode =
        let className, cssRules = createFss properties
        
        className,
        cssRules
        |> List.map processCssRule
        |> String.concat ""
        |> createStyleNode className
        
    // Creates Css node as global styles. Returns xml ndoe
    let global'(properties: Fss.Types.Rule list): XmlNode =
        let cssRules = createGlobal properties
        
        cssRules
        |> List.map processCssRule
        |> String.concat ""
        |> createStyleNode "*"
        
    let private processCounterRules (name: string) (rules: string) =
        $"@counter-style {name} {rules}"
        
    /// Creates counter style node and returns the counter name and xml node
    let counterStyle (properties: Fss.Types.CounterRule list): string * XmlNode =
        let counterName, counterStyle =
            properties
            |> createCounterStyle
            
        counterName, createStyleNode counterName <| processCounterRules counterName counterStyle
        
    let private processFontFaceRules (rules: string) =
        $"@font-face {rules}"
        
    /// Creates font face node and returns the font name and xml node
    let fontFaces name (properties: Fss.Types.FontFaceRule list list): string * XmlNode =
        let fontName, fontStyles =
            properties
            |> createFontFaces name
            
        fontName, createStyleNode fontName <| processFontFaceRules fontStyles
        
    let private processAnimationRules name (rules: string) =
        $"@keyframes {name} {rules}"
        
    /// Creates keyframes node and returns the counter name
    let keyframes (properties: Keyframes list): string * XmlNode =
        let animationName, animationStyles =
            properties
            |> createAnimation
            
        animationName, createStyleNode animationName <| processAnimationRules animationName animationStyles