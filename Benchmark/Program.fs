// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.Text
open Fss
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
//
[<MemoryDiagnoser>]
type Bench() =


    [<Benchmark>]
    member _.Interpolation() = $"{10}"
    [<Benchmark>]
    member _.Sprintf() = sprintf "%i" 10
    [<Benchmark>]
    member _.InterpolationWithType() = $"%i{10}"
    [<Benchmark>]
    member _.Concatinate() = "" + (string 10)
    [<Benchmark>]
    member _.InterpolationLonger() = $"{10}{20}{3.0}"
    [<Benchmark>]
    member _.SprintfLonger() = sprintf "%i%i%f" 10 20 3.0
    [<Benchmark>]
    member _.InterpolationWithTypeLonger() = $"%i{10}%i{20}%f{3.0}"
    [<Benchmark>]
    member _.ConcatinateLonger() = (string 10) + (string 20) + (string 3.0)
    [<Benchmark>]
    member _.StringBuilder() =
        let sb = StringBuilder()
        sb.Append 10 |> ignore
        sb.Append 20 |> ignore
        sb.Append 3.0 |> ignore
        sb.ToString()

//    let name = None
//    let rules =
//        [
//            BackgroundColor.hex "44c767"
//            BorderRadius.value (px 30)
//            BorderWidth.value (px 1)
//            BorderStyle.solid
//            BorderColor.hex "18ab29"
//            Display.inlineBlock
//            Cursor.pointer
//            FontSize.value (px 17)
//        ]
//    [<Benchmark>]
//    member _.FssVersion() =
//        match name with
//        | Some n -> n
//        | _ ->
//        let fullCssString =
//            rules
//            |> List.map (fun (x, y) -> $"{Fss.Types.MasterTypeHelpers.stringifyICssValue x}-{Fss.Types.MasterTypeHelpers.stringifyICssValue y}")
//            |> String.concat ";"
//
//        $"css{Fss.Utilities.FNV_1A.hash fullCssString}"
//    [<Benchmark>]
//    member _.Strinbuilder() =
//        let fullCssString =
//            match name with
//            | Some _ -> ""
//            | _ ->
//                let sb = StringBuilder()
//                rules
//                |> List.fold (fun (acc: StringBuilder) (x, y) ->
//                    let x = Fss.Types.MasterTypeHelpers.stringifyICssValue x
//                    let y = Fss.Types.MasterTypeHelpers.stringifyICssValue y
//                    acc.AppendFormat("{0}-{1}", x, y)) sb
//                |> ignore
//                sb.ToString()
//
//        $"css{Fss.Utilities.FNV_1A.hash fullCssString}"






//    let hashValue = "#xxxxxx"
//    let nonhashValue = "xxxxxx"
//    [<Benchmark>]
//    member _.HashedStartsWithStringBuilder() =
//        if hashValue.StartsWith "#" then
//            hashValue
//        else
//            let sb = StringBuilder()
//            sb.AppendFormat("#{0}", hashValue) |> ignore
//            sb.ToString()
//
//
//    [<Benchmark>]
//    member _.HashedStartsWithInterpolation() =
//        if hashValue.StartsWith "#" then
//            hashValue
//        else
//            $"#{hashValue}"
//
//
//    [<Benchmark>]
//    member _.HashedStartsWithSprintf() =
//        if hashValue.StartsWith "#" then
//            hashValue
//        else
//            sprintf "#%s" hashValue
//
//    [<Benchmark>]
//    member _.HashedIndexedStringBuilder() =
//        if hashValue.StartsWith "#" then
//            hashValue
//        else
//            let sb = StringBuilder()
//            sb.AppendFormat("#{0}", hashValue) |> ignore
//            sb.ToString()
//
//    [<Benchmark>]
//    member _.HashedIndexedStartsWithInterpolation() =
//        if hashValue[0] = '#' then
//            hashValue
//        else
//            $"#{hashValue}"
//
//
//    [<Benchmark>]
//    member _.HashedIndexedSprintf() =
//        if hashValue[0] = '#' then
//            hashValue
//        else
//            sprintf "#%s" hashValue
//
//    [<Benchmark>]
//    member _.NonhashedStartsWithStringBuilder() =
//        if nonhashValue.StartsWith "#" then
//            nonhashValue
//        else
//            let sb = StringBuilder()
//            sb.AppendFormat("#{0}", nonhashValue) |> ignore
//            sb.ToString()
//
//
//    [<Benchmark>]
//    member _.NonhashedStartsWithInterpolation() =
//        if nonhashValue.StartsWith "#" then
//            nonhashValue
//        else
//            $"#{nonhashValue}"
//
//
//    [<Benchmark>]
//    member _.NonhashedStartsWithSprintf() =
//        if nonhashValue.StartsWith "#" then
//            nonhashValue
//        else
//            sprintf "#%s" nonhashValue
//
//    [<Benchmark>]
//    member _.NonhashedIndexedStringBuilder() =
//        if nonhashValue[0] = '#' then
//            nonhashValue
//        else
//            let sb = StringBuilder()
//            sb.AppendFormat("#{0}", nonhashValue) |> ignore
//            sb.ToString()
//
//    [<Benchmark>]
//    member _.NonhashedIndexedStartsWithInterpolation() =
//        if nonhashValue[0] = '#' then
//            nonhashValue
//        else
//            $"#{nonhashValue}"
//
//    [<Benchmark>]
//    member _.NonhashedIndexedSprintf() =
//        if nonhashValue[0] = '#' then
//            nonhashValue
//        else
//            sprintf "#%s" nonhashValue
//
//    [<Benchmark>]
//    member _.FssOne() =
//        Fss.Types.colorHelpers.hex nonhashValue
//
//    [<Benchmark>]
//    member _.FssCopyIndexedWithStringBuilder () =
//        if nonhashValue[0] = '#' then
//            nonhashValue
//        else
//            let sb = StringBuilder()
//            sb.AppendFormat("#{0}", nonhashValue) |> ignore
//            sb.ToString()
//        |> Fss.Types.Color.Hex
//


[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<Bench>() |> ignore
//    let foo =
//    createFss [
//        BackgroundColor.hex "44c767"
//        BorderRadius.value (px 30)
//        BorderWidth.value (px 1)
//        BorderStyle.solid
//        BorderColor.hex "18ab29"
//        Display.inlineBlock
//        Cursor.pointer
//        FontSize.value (px 17)
//    ] |> ignore
//    printfn "%A" foo
    0 // return an integer exit code
