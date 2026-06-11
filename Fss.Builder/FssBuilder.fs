namespace Fss.Builder

open Fli
open System
open System.IO
open Thoth.Json.Net
open System.Reflection

open Fss.Static

module Builder =
    type Css = {
        Name: string
        Value: CssValue list
    }

    type PreparedNames = {
        ModuleNames: string list
        CombinedNames: (string * string) list list
    }

    type FssSource = {
        Path: string
        Name: string
        Namespace: string
    }

    let mutable verbose = false

    let rootPath (path: string) =
        if Path.IsPathRooted path then
            path
        else
            Path.Combine(Directory.GetCurrentDirectory(), path)

    let FssSourceDecoder: Decoder<FssSource> =
        Decode.object (fun get -> {
            Path = get.Required.Field "Path" (Decode.string |> Decode.map rootPath)
            Name = get.Required.Field "Name" Decode.string
            Namespace = get.Required.Field "Namespace" Decode.string
        })

    type GeneratedProject = {
        Path: string
        Name: string
    }

    let GeneratedProjectDecoder: Decoder<GeneratedProject> =
        Decode.object (fun get -> {
            Path = get.Required.Field "Path" (Decode.string |> Decode.map rootPath)
            Name = get.Required.Field "Name" Decode.string
        })

    type Options = {
        FssSource: FssSource
        GeneratedProject: GeneratedProject option
        CssOutputPath: string
    }


    let OptionsDecoder: Decoder<Options> =
        Decode.object (fun get -> {
            FssSource = get.Required.Field "FssSource" FssSourceDecoder
            GeneratedProject = get.Optional.Field "GeneratedProject" GeneratedProjectDecoder
            CssOutputPath = get.Required.Field "CssOutputPath" (Decode.string |> Decode.map rootPath)
        })

    let compileStyles options: unit =
        let command =
            cli {
                Exec "dotnet"
                Arguments [| "build"; "-c"; "Release"; "-o"; "./build"|]
                WorkingDirectory options.FssSource.Path
            }
            |> Command.execute


        if (Output.toExitCode command) <> 0 then
            printfn "Error when compiling styles:"
            printfn "%A" command.Text.Value

    let readCssValues options: Css list =
        if verbose then
            printfn $"Reading result of compilation from: {options.FssSource.Path}/build/{options.FssSource.Name}.dll"

        let assemblyPath = $"{options.FssSource.Path}/build/{options.FssSource.Name}.dll"
        let assemblyBytes = File.ReadAllBytes assemblyPath

        let assembly = Assembly.Load(assemblyBytes)

        let assemblyType = assembly.GetType(options.FssSource.Namespace)
        if assemblyType <> null then
            assemblyType.GetProperties()
            |> Array.filter (fun property -> typeof<CssValue list>.IsAssignableFrom property.PropertyType)
            |> Array.map (fun property ->
                {
                    Name = property.Name
                    Value = property.GetValue(null) :?> CssValue list
                })
            |> Array.toList
        else
            []

    let cssValuesToCssString (css: Css) =
        css.Value
        |> List.map snd
        |> List.map snd
        |> String.concat ""

    let cssValuesToFsharpVariableNames (css: Css) =
        css.Name, css.Value
                  |> List.map fst

    let cssValuesToCssNames (css: Css) =
        css.Value
        |> List.map snd
        |> List.map fst

    let combineFsharpAndCssNames fsharpNames cssNames =
        List.zip fsharpNames cssNames
        |> List.filter (fun (fsharpName, cssName) -> fsharpName <> String.Empty && cssName <> String.Empty)

    let createFsprojFile name path =
        let fsProjContent = $"""
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Library</OutputType>
            <TargetFramework>netstandard2.0</TargetFramework>
          </PropertyGroup>

            <ItemGroup>
                <Compile Include="{name}.fs" />
            </ItemGroup>
        </Project>
        """
        File.WriteAllText(Path.Combine(path, $"{name}.fsproj"), fsProjContent)

    let createFsSourceFile name path (names: PreparedNames) =
        let namesString =
            List.zip names.ModuleNames names.CombinedNames
            |> List.collect (fun (moduleName, combinedNames) ->
                [
                    ""
                    $"module {moduleName} ="
                    yield! (List.map (fun (fsharpName, cssName) -> $"""    let {fsharpName} = "{cssName}" """) combinedNames)
                ]
            )
        let sourceContent = [
            $"namespace {name}"
            yield! namesString

        ]
        File.WriteAllText(Path.Combine(path, $"{name}.fs"), String.Join("\n", sourceContent))

    let createLibraryProject name path (names: PreparedNames) =
        if verbose then
            printfn $"Creating library: {name} in {path}"
        Directory.CreateDirectory(path) |> ignore
        createFsprojFile name path
        createFsSourceFile name path names

    let createCssFiles options cssStrings =
        if verbose then
            printfn $"Outputting CSS files to: {options.CssOutputPath}"
        cssStrings
        |> List.iter (fun (moduleName, cssString: string) ->
            if verbose then
                printfn $"Outputting CSS file: {moduleName}.css"
            File.WriteAllText(Path.Combine(options.CssOutputPath, $"{moduleName}.css"), cssString)
        )

    let readOptionsFile path  =
        try
            if verbose then
                printfn $"Attempting to read settings from: {path}"
            let content = File.ReadAllText path
            Ok content
        with
        | :? System.IO.DirectoryNotFoundException as ex ->
            Error $"Directory not found: {ex.Message}"
        | :? System.IO.FileNotFoundException as ex ->
            Error $"File not found: {ex.Message}"
        | :? System.IO.PathTooLongException as ex ->
            Error $"Path too long found: {ex.Message}"
        | :? System.IO.IOException as ex ->
            Error $"IO exception: {ex.Message}"
        | ex ->
            Error $"An unexpected error has occurred: {ex.Message}"


    let build (options: Options) =
        if verbose then
            printfn $"Generating CSS for project: {options.FssSource.Path}"
        compileStyles options

        let css = readCssValues options
        // Css string
        let cssStrings =
            css
            |> List.map cssValuesToCssString

        // F# file
        let fsharpNames =
            css
            |> List.map cssValuesToFsharpVariableNames

        let cssNames =
            css
            |> List.map cssValuesToCssNames

        let names =
            let fsharpModuleNames =
                List.map fst fsharpNames
            let fsharpNames =
                List.map snd fsharpNames
            {
                ModuleNames = fsharpModuleNames
                CombinedNames =
                    List.zip fsharpNames cssNames
                    |> List.map (fun (fsharpName, cssName) -> combineFsharpAndCssNames fsharpName cssName)
            }

        if options.GeneratedProject.IsSome then
            createLibraryProject options.GeneratedProject.Value.Name options.GeneratedProject.Value.Path names

        let moduleNamesAndCssStrings =
            List.zip names.ModuleNames cssStrings
        createCssFiles options moduleNamesAndCssStrings
        if verbose then
            printfn "Css build complete"

module FileWatcher =
    let fileChangedHandler (watcher: FileSystemWatcher) (options: Builder.Options) (e: FileSystemEventArgs) =
        try
            watcher.EnableRaisingEvents <- false
            printfn "File %s has changed" e.Name
            Builder.build options
        finally
            watcher.EnableRaisingEvents <- true
            printfn "Waiting for file change"


    let watch (options: Builder.Options) =
        let path = options.FssSource.Path
        let watcher = new FileSystemWatcher(path)

        watcher.Filter <- "*.fs"
        watcher.Changed.Add(fileChangedHandler watcher options)
        watcher.Created.Add(fileChangedHandler watcher options)
        watcher.Deleted.Add(fileChangedHandler watcher options)
        watcher.EnableRaisingEvents <- true

module CommandLine =
    type CommandLineOptions = {
        Path: string
        Watch: bool
        Verbose: bool
        Quit: bool
    }

    let defaultCommandLineOptions = {
        Path = Builder.rootPath "Fss.json"
        Watch = false
        Verbose = false
        Quit = false
    }

    let printHelp () =
        printfn "Usage: dotnet Fss.Build [options]"
        printfn "Options:"
        printfn "  -h, --help       Display help"
        printfn "  -p, --path PATH  Specify the path to the configuration file"
        printfn "  -w, --watch      Watch for changes in the styles"
        printfn "  -v, --verbose   Verbose logging"
        printfn ""


    let parseCommandLine args =
        let rec recurse args options =
            match args with
            | [] -> options
            | "-h"::xs
            | "--help"::xs ->
                printHelp ()
                let newOptions = { options with Quit = true }
                recurse xs newOptions
            | "-p"::xs
            | "--path"::xs ->
                match xs with
                | [] ->
                    eprintfn "-p / --path needs a path argument"
                    recurse xs options
                | path::xss ->
                    let newOptions = { options with Path = Builder.rootPath path}
                    recurse xss newOptions
            | "-w"::xs
            | "--watch"::xs ->
                let newOptions = { options with Watch = true }
                recurse xs newOptions
            | "-v"::xs
            | "--verbose"::xs ->
                let newOptions = { options with Verbose = true }
                recurse xs newOptions
            | x::xs ->
                eprintfn "Option '%s' is unrecognized" x
                recurse xs options

        let args = Array.toList args
        recurse args defaultCommandLineOptions


module Main =
    [<EntryPoint>]
    let main args =
        let commandLineOptions = CommandLine.parseCommandLine args

        if not commandLineOptions.Quit then
            let fileContent = Builder.readOptionsFile commandLineOptions.Path

            match fileContent with
            | Error e -> printfn "Error: %A" e
            | Ok fileContent ->
                let options =
                    fileContent
                    |> Decode.fromString Builder.OptionsDecoder

                match options with
                | Ok options ->
                    Builder.verbose <- commandLineOptions.Verbose
                    if commandLineOptions.Watch then
                        FileWatcher.watch options

                        printfn $"Watching for changes in {options.FssSource.Path}"
                        printfn "Press any key to exit..."
                        Console.ReadKey() |> ignore
                    else
                        Builder.build options

                | Error e ->
                    printfn "Error: %A" e
        0
