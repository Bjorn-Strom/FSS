#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open System.IO

let platformTool tool winTool =
    let tool = if Environment.isUnix then tool else winTool
    match ProcessUtils.tryFindFileOnPath tool with
    | Some t -> t
    | _ ->
        let errorMsg = tool + " was not found in path. "
        failwith errorMsg

let runTool cmd args workingDir =
    let arguments = args |> String.split ' ' |> Arguments.OfArgs
    Command.RawCommand (cmd, arguments)
    |> CreateProcess.fromCommand
    |> CreateProcess.withWorkingDirectory workingDir
    |> CreateProcess.ensureExitCode
    |> Proc.run
    |> ignore

let clean () =
   printfn "Cleaning"
   Shell.cleanDir "fss/bin"
   runTool "dotnet" "clean" __SOURCE_DIRECTORY__

Target.create "Publish" (fun _ ->
    clean ()
    let appName = "fss-lib"
    let apiKey = File.ReadAllText("secrets")
    printfn "Packing"
    runTool "dotnet" "restore --no-cache fss" __SOURCE_DIRECTORY__
    runTool "dotnet" "pack -c release fss" __SOURCE_DIRECTORY__
    printfn "Publishing"
    let path =
        Directory.GetFiles("fss/bin/Release")
        |> Seq.head
        |> Path.GetFullPath

    runTool "dotnet" (sprintf "nuget push %s -s nuget.org -k %s" path apiKey) __SOURCE_DIRECTORY__
)

Target.runOrDefault ""