namespace FSSTests

open Fss
open Fet
open Fss.Types
open System

module Utils =
    let collectedCss = ResizeArray<string>()

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
        collectedCss.Add(actual)
        test testName <| fun _ ->
            Expect.equal actual correct

    let testCase (testName: string) (ruleList: Rule list) (correct: string) =
        let _, fullCss = createFss ruleList
        collectedCss.Add(fullCss)
        let actual =
            fullCss.Split "{"
            |> Seq.tail
            |> Seq.head
            |> sprintf "{%s"

        test testName <| fun _ ->
            Expect.equal actual correct

    let testCounterCase (testName: string) (ruleList: CounterRule list) (correct: string) =
        let _, fullCss = createCounterStyle ruleList
        collectedCss.Add(sprintf "@counter-style %s" fullCss)
        let actual =
            fullCss.Split "{"
            |> Seq.tail
            |> Seq.head
            |> sprintf "{%s"
        test testName <| fun _ ->
            Expect.equal actual correct

    let testFontCase (testName: string) (ruleList: FontFaceRule list) (correct: string) =
        let _, actual = createFontFace "" ruleList
        collectedCss.Add(sprintf "@font-face %s" actual)
        test testName <| fun _ ->
            Expect.equal actual correct
