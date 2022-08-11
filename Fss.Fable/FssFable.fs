﻿namespace Fss

open Browser.Dom
open System.Collections.Generic;
open Fss

[<AutoOpen>]
module Fable =
    /// Injects the css into the dom
    /// Only inject if its not injected already
    let private styleCache = HashSet<string>()
    let private injectCss (className: string) (css: string) =
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
    let fss (properties: Fss.Types.Rule list): string =
        let className, cssRules = createFss properties
        injectCss className cssRules

        className

    // Injects CSS into dom as global styles
    let global'(properties: Fss.Types.Rule list): unit =
        let cssRules = createGlobal properties

        injectCss "*" cssRules
        ()

    let private processCounterRules (name: string) (rules: string) =
        $"@counter-style {name} {rules}"


    /// Injects counter style into dom and returns the counter name
    let counterStyle (properties: Fss.Types.CounterRule list): string =
        let counterName, counterStyle =
            properties
            |> createCounterStyle

        injectCss counterName <| processCounterRules counterName counterStyle

        counterName

    let private processFontFaceRules (rules: string) =
        $"@font-face {rules}"

    /// Injects font face into dom and returns the font name
    let fontFaces name (properties: Fss.Types.FontFaceRule list list): string =
        let fontName, fontStyles =
            properties
            |> createFontFaces name

        injectCss fontName <| processFontFaceRules fontStyles

        fontName

    /// Injects font face into dom and returns the font name
    let fontFace name (properties: Fss.Types.FontFaceRule list): string =
        let fontName, fontStyles =
            properties
            |> createFontFace name

        injectCss fontName <| processFontFaceRules fontStyles

        fontName

    let private processAnimationRules name (rules: string) =
        $"@keyframes {name} {rules}"

    /// Injects keyframes into dom and returns the animation name
    let keyframes (properties: Keyframes list): string =
        let animationName, animationStyles =
            properties
            |> createAnimation

        injectCss animationName <| processAnimationRules animationName animationStyles

        animationName
