open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

[<MemoryDiagnoser>]
type Bench() =
    [<Benchmark>]
    member _.Foo() = ""

[<EntryPoint>]
let main _ =
    BenchmarkRunner.Run<Bench>() |> ignore
    0
