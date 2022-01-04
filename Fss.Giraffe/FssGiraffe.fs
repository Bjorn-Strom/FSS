namespace Fss.Giraffe

open Fss
open System.Collections.Generic;
open Giraffe.ViewEngine

[<AutoOpen>]
module Fss =
    // TODO: Hent FSS via nuget
    
    /// Injects the css into the dom
    /// Only inject if its not injected already
    let styleCache = Dictionary<string, XmlNode>()
    let private injectCss className (css: string) =
        if styleCache.ContainsKey className then
            styleCache[className]
        else
            let newNode = style [ _type "text/css" ] [ rawText css ]
            styleCache.Add (className, newNode)
            newNode
    
    let private processCssRule (name: string, rule: string) =
        $"{name} {rule}"
        
    /// Creates Css node and returns the classname and xml node
    let fss (properties: Fss.FssTypes.Rule list): FssTypes.ClassName * XmlNode =
        let className, cssRules = createFss properties
        
        className,
        cssRules
        |> List.map processCssRule
        |> String.concat ""
        |> injectCss className
        
    // Creates Css node as global styles. Returns xml ndoe
    let global'(properties: Fss.FssTypes.Rule list): XmlNode =
        let cssRules = createGlobal properties
        
        cssRules
        |> List.map processCssRule
        |> String.concat ""
        |> injectCss "*"
        
    let private processCounterRules (name: string) (rules: string) =
        $"@counter-style {name} {rules}"
        
    /// Creates counter style node and returns the counter name and xml node
    let counterStyle (properties: Fss.FssTypes.CounterRule list): FssTypes.CounterName * XmlNode =
        let counterName, counterStyle =
            properties
            |> createCounterStyle
            
        counterName, injectCss counterName <| processCounterRules counterName counterStyle
        
    let private processFontFaceRules (rules: string) =
        $"@font-face {rules}"
        
    /// Creates font face node and returns the font name and xml node
    let fontFaces name (properties: Fss.FssTypes.FontFaceRule list list): FssTypes.FontName * XmlNode =
        let fontName, fontStyles =
            properties
            |> createFontFaces name
            
        fontName, injectCss fontName <| processFontFaceRules fontStyles
        
    let private processAnimationRules name (rules: string) =
        $"@keyframes {name} {rules}"
        
    /// Creates keyframes node and returns the counter name
    let keyframes (properties: KeyframeAttribute list): FssTypes.AnimationName * XmlNode =
        let animationName, animationStyles =
            properties
            |> createAnimation
            
        animationName, injectCss animationName <| processAnimationRules animationName animationStyles