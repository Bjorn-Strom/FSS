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
    
    let testEqual (testName: string) (actual: string) (correct: string) =
        test testName <| fun _ ->
            Expect.equal actual correct
    
    let testCase (testName: string) (ruleList: Rule list) (correct: string) =
        let _, actual =  List.head <| snd (createFss ruleList)
        test testName <| fun _ ->
            Expect.equal actual correct
            
    let testSelectorCase (testName: string) (ruleList: Rule list) (correct: string) =
        let className, css =
            snd (createFss ruleList)
            |> List.rev
            |> List.head
        test testName <| fun _ ->
            Expect.equal $"{className} {css}" correct
            
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
        let (_, actual) = createFontFace "" ruleList
        test testName <| fun _ ->
            Expect.equal actual correct