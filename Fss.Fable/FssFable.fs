namespace Fss.Fable

open Browser.Dom
open Fss

// TODO: Legg til en cache her, så dersom CSSen allerede eksisterer, så ikke legg den inn i DOM

[<AutoOpen>]
module Fss =
    let private processCssRule (name: string, rule: string) =
        $"{name} {{ {rule} }}"
        
    let private injectCss (css: string) =
        let head = document.getElementsByTagName("head")[0]
        let style = document.createElement "style"
        style.setAttribute ("type", "text/css")
        style.appendChild(document.createTextNode(css)) |> ignore
        head.appendChild(style) |> ignore
    
    /// Injects CSS into dom and returns the classname
    let fss (properties: Fss.FssTypes.Rule list): string =
        let className, cssRules = createFss properties
        let foo = cssRules
                |> List.map processCssRule
                |> String.concat ""
        foo |> injectCss
        
        className
        
    // Injects CSS into dom as global styles
    let global'(properties: Fss.FssTypes.Rule list): unit =
        let _, cssRules = createGlobal properties
        
        cssRules
        |> List.map processCssRule
        |> String.concat ""
        |> injectCss
        
    let private processCounterRules (name: string) (rules: string) =
        $"@counter-style {name} {{ {rules} }}"
        
    /// Injects counter style into dom and returns the counter name
    let counterStyle (properties: Fss.FssTypes.CounterRule list): string =
        let counterName, counterStyle =
            properties
            |> createCounterStyle
            
        injectCss <| processCounterRules counterName counterStyle
            
        counterName
        
    let private processFontFaceRules (rules: string) =
        $"@font-face {{ {rules} }}"
        
    /// Injects counter style into dom and returns the counter name
    let fontFace name (properties: Fss.FssTypes.FontFaceRule list): string =
        let fontName, fontStyles =
            properties
            |> createFontFace name
            
        injectCss <| processFontFaceRules fontStyles
        
        fontName
        
    let private processAnimationRules name (rules: string) =
        $"@keyframes {name} {{ {rules} }}"
        
    /// Injects keyframes into dom and returns the counter name
    let keyframes (properties: KeyframeAttribute list): string =
        let animationName, animationStyles =
            properties
            |> createAnimation
            
        injectCss <| processAnimationRules animationName animationStyles
        
        animationName