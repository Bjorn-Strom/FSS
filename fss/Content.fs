namespace Fss

open Fss.ListStyle

module Content =
    open Types
    open Attribute
    
    type Content =
        | Counter of CounterStyle
        | Counter2 of CounterStyle * ListStyleType
        | Url of string
        | UrlWithAlt of string * string
        | LinearGradient of ILinearGradient list
        | Attribute of Attribute
        | String of string
        | OpenQuote
        | CloseQuote
        | NoOpenQuote
        | NoCloseQuote
        interface IContent

module ContentValue =
    open Types
    open Global
    open Content
    open Utilities.Helpers

    let content (v: IContent): string =
        let stringifyContent (c: Content): string =
            match c with
                | Counter  c        -> sprintf "counter(%s)" <| counterValue c
                | Counter2 (c, ls)  -> sprintf "counter(%s, %s)" (counterValue c) (ListStyleValue.styleType ls)
                | Url u             -> sprintf "url(%s)" u
                | UrlWithAlt (u, t) -> sprintf "url(%s) / \"%s\"" u t
                | Attribute a       -> sprintf "attr(%s)" <| AttributeValues.attribute a
                | String    s       -> sprintf "\"%s\"" s
                | LinearGradient g  -> BackgroundValues.linearGradientValue g
                | _                 -> duToKebab c
        
        match v with
            | :? Global           as g -> GlobalValue.globalValue g
            | :? None             as n -> GlobalValue.none n
            | :? Normal           as n -> GlobalValue.normal n
            | :? Content          as c -> stringifyContent c
            | _ -> "Unknown content"