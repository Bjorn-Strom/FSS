
// Hvis filstrukturen er slik:
// /Button
// button.fs - har en komponent
// buttonStyles.fs
// /styles
// index.fs
// buttonStyles ser slik ut:
// let buttonStyle = [
//    Color.red
//    ...
//    ...
// ]
// index ser slik ut:
// let styles = [ buttonStyle ]
// Så er da tanken at man kan skrive dotnet tool FssGenerate (or whatever).
// Så leses det ut fra styles hvilken styling vi ønsker å ha med.
// Dette sendes inn i en Fss funksjon som genererer CSSen og klassenavnet.
// Det lages 2 filer i et nytt prosjekt (kan appendes dersom prosjektet finnes fra før) (tenker det kan finnes ei config fil som lar en definere dette litt)
// styles.fs:
// let buttonStyle = "theButtonClassName"
// index.css
// .theButtonClassName {
//    color: red;
//    ...
// }
// Så må man importere dette prosjektet inn i prosjektet hvor button komponenten er og legge til index.css fila inn i index.html fila si.
// Det er sånn jeg tenker at det kan fungere.
// Et problem jeg ser for meg da, er jo at all koden man definerer i buttonStyles.fs må ligge inne i det første prosjektet, selv om de egentlig ikke skal kompileres. De skal bare mates til en Fss funksjon et sted.
// Så det vil øke den endelige bundle sizen?
// Evt...kan man inkludere de men ikke kompilere, går det ann?

// Les inn konfigurasjonsfil
// Basert på config fil så kan vi finne .fss.fs filene

open System.Reflection
open Fss

let fss styleName styles = styleName, styles

let button = fss "button" [
    Color.blue
]

// I container.fss.fs
let container = fss "container" [
    BackgroundColor.orangeRed
]

// I index.fs
let styles = [
    button
    container
]

// Det produserer
let css =
    styles
    |> List.map snd
    |> List.map createFss
// Css string
let cssString =
    css
    |> List.map snd
    |> String.concat ""
// F# fil
let fsharpNames =
    styles
    |> List.map fst
    
let fsharpFile =
    css
    |> List.map fst
    |> List.zip fsharpNames
    |> List.map (fun (name, className) -> $"let {name} = \"{className}\"")
    |> String.concat "\n"
    
printfn "CSS: %A" cssString
printfn "F#: %A" fsharpFile

// TODO: Man burde kunne bestemme HVOR man ønsker å dumpe ut CSS fila
// TODO: Man burde kunne bestemme HVOR man ønsker å dumpe ut F# prosjektet


open System.IO

type Config = 
    { Source: string
      Destination: string
      ModuleName: string }

let createLibrary path code =
    if not (Directory.Exists(path)) then
        Directory.CreateDirectory(path) |> ignore
       
    let fsprojPath = Path.Combine(path, $"{path}.fsproj")
    File.WriteAllText(fsprojPath, 
        "<Project Sdk=\"Microsoft.NET.Sdk\">\n  <PropertyGroup>\n    <TargetFramework>netstandard2.0</TargetFramework>\n  </PropertyGroup>\n  <ItemGroup>\n    <Compile Include=\"" + path + ".fs\" />\n  </ItemGroup>\n</Project>")

    let fsPath = Path.Combine(path, $"{path}.fs")
    File.WriteAllText(fsPath, $"module {path}\n{code}")
    
let createCssFile path css =
    let filePath = Path.Combine(path, "index.css")
    File.WriteAllText(filePath, css)
    
    
// [<EntryPoint>]
// let main (args: string[]) =
//     try
//         match args with
//         | [| "generate"   |] -> ()
//         | _ -> printfn "Unknown args %A" args
//         0
//     with ex ->
//         printfn "%A" ex
//         1
    
createLibrary "styles" fsharpFile
createCssFile "styles" cssString
