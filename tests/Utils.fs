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

        $"{toKebabCase <| propertyName.ToString()}: {propertyValue.Stringify()};"
        
    let test_fontFace (properties: FontFaceRule list) : FontName * FontFaceStyle =
        let fontName = "@font-face"
        let properties =
            List.map stringifyFontFaceProperty properties
            |> String.concat "\n"
        
        fontName, properties
    
    
    let testCase (testName: string) (ruleList: Rule list) (correct: string) =
        let _, actual =  List.head <| fss ruleList
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testPseudoCase (testName: string) (ruleList: Rule list) (correct: string) =
        let _, actual =
            fss ruleList
            |> List.tail
            |> List.head
        
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testCounterCase (testName: string) (ruleList: CounterRule list) (correct: string) =
        let (_, actual) = counterStyle ruleList
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testFontCase (testName: string) (ruleList: FontFaceRule list) (correct: string) =
        let (_, actual) = test_fontFace ruleList
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testMediaCase (testName: string) (featureList: Media.Feature list) (ruleList: Rule list) (correct: string) =
        let x = List.head <| fss [ Media.query featureList ruleList ]
        printfn "X: %A" x
        let actual = ""
        printfn "actual: %A" actual
        test testName <| fun _ ->
            Expect.equal actual correct

    (*
    let testMedia (testName: string) (featureList: FssTypes.Media.Feature list) (attributeList: FssTypes.CssRule list) (correct: (string * obj)) =
        test testName <| fun _ ->
            let actual = mediaFeature featureList |> sprintf "@media %s" ==> (attributeList |> List.map FssTypes.masterTypeHelpers.CssValue)

            Expect.equal (actual.ToString()) (correct.ToString())

    let testMediaFor (testName: string) device (featureList: FssTypes.Media.Feature list) (attributeList: FssTypes.CssRule list) (correct: (string * obj)) =
        test testName <| fun _ ->
            let ``and`` = if List.isEmpty featureList then " " else " and "
            let actual = sprintf "@media %s%s%s" (deviceLabel device) ``and`` (mediaFeature featureList)  ==> (attributeList |> List.map FssTypes.masterTypeHelpers.CssValue)

            Expect.equal (actual.ToString()) (correct.ToString())

    let testNested (testName: string) (attributeList: FssTypes.CssRule list) (correct: (string * obj) list) =
        test testName <| fun _ ->
            let actual =
                attributeList
                |> List.map FssTypes.masterTypeHelpers.CssValue
                |> List.map (fun (x, y) ->
                    let properY: string =
                        y :?> FssTypes.CssRule list
                        |> List.map FssTypes.masterTypeHelpers.CssValue
                        |> List.map (fun x -> $"{x}")
                        |> String.concat ","
                    x ==> properY)

            Expect.equal actual correct

    let testString (testName: string) (actual: string) (expected: string) =
        test testName <| fun () ->
            Expect.equal actual expected

    let testKeyframes (testName: string) (actual: Keyframes.KeyframeAttribute list) (expected: string list) =
        let actual =
            actual
            |> Keyframes.createAnimationRecord
            |> List.map (fun (key, value) ->
                      sprintf "%s %A" key (Fable.Core.JS.JSON.stringify(value)
                              .Replace("\\", "")
                              .Replace("\"","")
                              .Replace("{", "")
                              .Replace("}", "")
                              .Replace(":", ", ")))

        test testName <| fun _ ->
            Expect.equal actual expected
            *)