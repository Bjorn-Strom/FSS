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
   Shell.cleanDir "FssFeliz/bin"
   runTool "dotnet" "clean" __SOURCE_DIRECTORY__

let publish path =
    clean ()
    let apiKey = File.ReadAllText("secrets")
    printfn "Packing"
    runTool "dotnet" (sprintf "restore --no-cache %s" path) __SOURCE_DIRECTORY__
    runTool "dotnet" (sprintf "pack -c release %s" path) __SOURCE_DIRECTORY__
    printfn "Publishing"
    let path =
        Directory.GetFiles(sprintf "%s/bin/Release" path)
        |> Seq.head
        |> Path.GetFullPath

    printfn "Publishing to: %A" path

    //runTool "dotnet" (sprintf "nuget push %s -s nuget.org -k %s" path apiKey) __SOURCE_DIRECTORY__

Target.create "PublishFss" (fun _ ->
    publish "fss" )

Target.create "PublishFssFeliz" (fun _ ->
    publish "FssFeliz")


Target.runOrDefault ""