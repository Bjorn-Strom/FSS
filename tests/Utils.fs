namespace FSSTests

open Fss
open Fet
open Fss.FssTypes
open System

module Utils =
    let internal toLowerAndCombine (separator: string) (value: string) : string =
        value
        |> Seq.fold
            (fun acc element ->
                if Char.IsUpper(char element) && acc.Length = 0 then
                    acc + (string <| Char.ToLower(element))
                else if Char.IsUpper(char element) && acc.Length <> 0 then
                    sprintf "%s%s%s" acc separator (string <| Char.ToLower(element))
                else
                    acc + (string element))
            ""

    let internal toKebabCase (x: 'a) = x.ToString() |> toLowerAndCombine "-"
    let internal toSpacedCase (x: 'a) = x.ToString() |> toLowerAndCombine " "
    
    let internal stringifyFontFaceProperty (property: FontFaceRule) =
        let propertyName, propertyValue = property

        $"{toKebabCase <| propertyName.ToString()}: {propertyValue.StringifyFontFace()};"
        
    let test_fontFace (properties: FontFaceRule list) : FontName * FontFaceStyle =
        let fontName = "@font-face"
        let properties =
            List.map stringifyFontFaceProperty properties
            |> String.concat "\n"
        
        fontName, properties
    
    
    let testCase (testName: string) (ruleList: Rule list) (correct: string) =
        let _, actual =  List.head <| snd (createFss ruleList)
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testPseudoCase (testName: string) (ruleList: Rule list) (correct: string * string) =
        let actual =
            snd (createFss ruleList)
            |> List.tail
            |> List.head
        
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testCounterCase (testName: string) (ruleList: CounterRule list) (correct: string) =
        let (_, actual) = createCounterStyle ruleList
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testFontCase (testName: string) (ruleList: FontFaceRule list) (correct: string) =
        let (_, actual) = test_fontFace ruleList
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testMediaCase (testName: string) (featureList: Media.Feature list) (ruleList: Rule list) (correct: string) =
        let (media, actual) =
            snd (createFss [ Media.query featureList ruleList ])
            |> List.rev
            |> List.head
        test testName <| fun _ ->
            Expect.equal $"{media}{actual}" correct
            
    let testMediaForCase (testName: string) devices (featureList: Media.Feature list) (ruleList: Rule list) (correct: string) =
        let (media, actual) =
            snd (createFss [ Media.queryFor devices featureList ruleList ])
            |> List.rev
            |> List.head
        test testName <| fun _ ->
            Expect.equal $"{media}{actual}" correct
