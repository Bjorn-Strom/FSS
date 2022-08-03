// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open Fss

//[<MemoryDiagnoser>]
//type Bench() =
//    [<Benchmark>]
//    member _.Custom() =
//        createFss [
//            BackgroundColor.hex "44c767"
//            BorderRadius.value (px 30)
//            BorderWidth.value (px 1)
//            BorderStyle.solid
//            BorderColor.hex "18ab29"
//            Display.inlineBlock
//            Cursor.pointer
//            FontSize.value (px 17)
//        ]

[<EntryPoint>]
let main argv =
//    BenchmarkRunner.Run<Bench>() |> ignore
    createFss [
        BackgroundColor.hex "44c767"
        BorderRadius.value (px 30)
        BorderWidth.value (px 1)
        BorderStyle.solid
        BorderColor.hex "18ab29"
        Display.inlineBlock
        Cursor.pointer
        FontSize.value (px 17)
    ] |> ignore
    0 // return an integer exit code
