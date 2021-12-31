namespace Fss.Fable

open Browser.Dom
open System.Collections.Generic;
open Fss

// TODO: Legg til en cache her, så dersom CSSen allerede eksisterer, så ikke legg den inn i DOM

[<AutoOpen>]
module Fss =
    let private processCssRule (name: string, rule: string) =
        $"{name} {rule}"
        
        
    /// Injects the css into the dom
    /// Only inject if its not injected already
    let styleCache = HashSet<string>()
    let private injectCss className (css: string) =
        if styleCache.Contains className then
            ()
        else
            let head = document.getElementsByTagName("head")[0]
            let style = document.createElement "style"
            style.setAttribute ("type", "text/css")
            style.appendChild(document.createTextNode(css)) |> ignore
            head.appendChild(style) |> ignore
            styleCache.Add className |> ignore
    
    /// Injects CSS into dom and returns the classname
    let fss (properties: Fss.FssTypes.Rule list): string =
        let className, cssRules = createFss properties
        cssRules
            |> List.map processCssRule
            |> String.concat ""
            |> injectCss className
        
        className
        
    // Injects CSS into dom as global styles
    let global'(properties: Fss.FssTypes.Rule list): unit =
        let _, cssRules = createGlobal properties
        
        cssRules
        |> List.map processCssRule
        |> String.concat ""
        |> injectCss "*"
        
    let private processCounterRules (name: string) (rules: string) =
        $"@counter-style {name} {rules}"
        
        
    /// Injects counter style into dom and returns the counter name
    let counterStyle (properties: Fss.FssTypes.CounterRule list): string =
        let counterName, counterStyle =
            properties
            |> createCounterStyle
            
        injectCss counterName <| processCounterRules counterName counterStyle
            
        counterName
        
    let private processFontFaceRules (rules: string) =
        $"@font-face {rules}"
        
    /// Injects font face into dom and returns the font name
    let fontFaces name (properties: Fss.FssTypes.FontFaceRule list list): string =
        let fontName, fontStyles =
            properties
            |> createFontFaces name
            
        injectCss fontName <| processFontFaceRules fontStyles
        
        fontName
        
    /// Injects font face into dom and returns the font name
    let fontFace name (properties: Fss.FssTypes.FontFaceRule list): string =
        let fontName, fontStyles =
            properties
            |> createFontFace name
            
        injectCss fontName <| processFontFaceRules fontStyles
        
        fontName
        
    let private processAnimationRules name (rules: string) =
        $"@keyframes {name} {rules}"
        
    /// Injects keyframes into dom and returns the counter name
    let keyframes (properties: KeyframeAttribute list): string =
        let animationName, animationStyles =
            properties
            |> createAnimation
            
        injectCss animationName <| processAnimationRules animationName animationStyles
        
        animationName