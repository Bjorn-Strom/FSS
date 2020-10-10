namespace Fss

module Content =
    open Types
    
    type Content =
        | Counter of string
        // Todo: Finish this after getting line style in
        | Counter2 of string * string
        | Attribute of string
        | Url of string
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
    
    let content (v: IContent): string =
        let stringifyContent (c: Content): string = ""
        
        match v with
            | :? Global  as g -> GlobalValue.globalValue g
            | :? None    as n -> GlobalValue.none n
            | :? Normal  as n -> GlobalValue.normal n
            | _ -> "Unknown content"