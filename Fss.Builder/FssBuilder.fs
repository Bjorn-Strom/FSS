﻿namespace Fss.Builder

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

    let root_path (path: string) =
        if Path.IsPathRooted path then
            path
        else
            Path.Combine(Directory.GetCurrentDirectory(), path)

    let FssSourceDecoder: Decoder<FssSource> =
        Decode.object (fun get -> {
            Path = get.Required.Field "Path" (Decode.string |> Decode.map root_path)
            Name = get.Required.Field "Name" Decode.string
            Namespace = get.Required.Field "Namespace" Decode.string
        })

    type GeneratedProject = {
        Path: string
        Name: string
    }

    let GeneratedProjectDecoder: Decoder<GeneratedProject> =
        Decode.object (fun get -> {
            Path = get.Required.Field "Path" (Decode.string |> Decode.map root_path)
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
            CssOutputPath = get.Required.Field "CssOutputPath" (Decode.string |> Decode.map root_path)
        })

    let compile_styles options: unit =
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

    let read_css_values options: Css List =
        if verbose then
            printfn $"Reading result of compilation from: {options.FssSource.Path}/build/{options.FssSource.Name}.dll"

        let assembly_path = $"{options.FssSource.Path}/build/{options.FssSource.Name}.dll"
        let assembly_bytes = File.ReadAllBytes assembly_path

        let assembly = Assembly.Load(assembly_bytes)

        let assembly_type = assembly.GetType(options.FssSource.Namespace)
        if assembly_type <> null then
            assembly_type.GetProperties()
            |> Array.map (fun property -> 
                {
                    Name = property.Name
                    Value = property.GetValue(null) :?> CssValue list
                })
            |> Array.toList
        else 
            [] 

    let css_values_to_css_string (css: Css) =
        css.Value
        |> List.map snd
        |> List.map snd
        |> String.concat ""
     
    let css_values_to_fsharp_variable_names (css: Css) =
        css.Name, css.Value 
                  |> List.map fst

    let css_values_to_css_names (css: Css) =
        css.Value
        |> List.map snd 
        |> List.map fst

    let combine_fsharp_and_css_names fsharp_names css_names =
        List.zip fsharp_names css_names
        |> List.filter (fun (fs_name, css_name) -> fs_name <> String.Empty && css_name <> String.Empty)

    let create_fsproj_file name path =
        let fsProjContent = $"""
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Library</OutputType>
            <TargetFramework>net8.0</TargetFramework>
          </PropertyGroup>

            <ItemGroup>
                <Compile Include="{name}.fs" />
            </ItemGroup>
        </Project>
        """
        File.WriteAllText(Path.Combine(path, $"{name}.fsproj"), fsProjContent)
            
    let create_fs_source_file name path (names: PreparedNames) =
        let names_string = 
            List.zip names.ModuleNames names.CombinedNames
            |> List.collect (fun (module_name, combined_names) -> 
                [
                    ""
                    $"module {module_name} ="
                    yield! (List.map (fun (fs_name, css_name) -> $"""    let {fs_name} = "{css_name}" """) combined_names)
                ]
            )
        let sourceContent = [
            $"namespace {name}"
            yield! names_string
            
        ]
        File.WriteAllText(Path.Combine(path, $"{name}.fs"), String.Join("\n", sourceContent))

    let create_library_project name path (names: PreparedNames) =
        if verbose then
            printfn $"Creating library: {name} in {path}"
        Directory.CreateDirectory(path) |> ignore
        create_fsproj_file name path
        create_fs_source_file name path names

    let create_css_files options css_strings =
        if verbose then
            printfn $"Outputting CSS files to: {options.CssOutputPath}"
        css_strings
        |> List.iter (fun (module_name, css_string) -> 
            if verbose then
                printfn $"Outputting CSS file: {module_name}.css"
            File.WriteAllText(Path.Combine(options.CssOutputPath, $"{module_name}.css"), css_string)
        ) 

    let read_options_file path  =
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
            Error $"An unexpected error has occured: {ex.Message}"


    let build (options: Options) =
        if verbose then
            printfn $"Generating CSS for project: {options.FssSource.Path}"
        compile_styles options

        let css = read_css_values options
        // Css string
        let css_strings =
            css
            |> List.map css_values_to_css_string

        // F# file
        let fsharp_names =
            css
            |> List.map css_values_to_fsharp_variable_names 

        let css_names = 
            css
            |> List.map css_values_to_css_names

        let names = 
            let fs_module_names = 
                List.map fst fsharp_names
            let fsharp_names = 
                List.map snd fsharp_names
            {
                ModuleNames = fs_module_names
                CombinedNames = 
                    List.zip fsharp_names css_names
                    |> List.map (fun (f, c) -> combine_fsharp_and_css_names f c)
            }

        if options.GeneratedProject.IsSome then
            create_library_project options.GeneratedProject.Value.Name options.GeneratedProject.Value.Path names

        let module_names_and_css_strings =
            List.zip names.ModuleNames css_strings
        create_css_files options module_names_and_css_strings
        if verbose then
            printfn "Css build complete"

module File_Watcher =
    let file_changed_handler (fsw: FileSystemWatcher) (options: Builder.Options) (e: FileSystemEventArgs) =
        try
            fsw.EnableRaisingEvents <- false
            printfn "File %s has changed" e.Name
            Builder.build options
        finally
            fsw.EnableRaisingEvents <- true
            printfn "Waiting for file change"


    let watch (options: Builder.Options) =
        let path = options.FssSource.Path
        let watcher = new FileSystemWatcher(path)

        watcher.Filter <- "*.fs"
        watcher.Changed.Add(file_changed_handler watcher options)
        watcher.Created.Add(file_changed_handler watcher options)
        watcher.Deleted.Add(file_changed_handler watcher options)
        watcher.EnableRaisingEvents <- true
        
module Command_Line =
    type Command_Line_Options = {
        Path: string
        Watch: bool
        Verbose: bool
        Quit: bool
    }

    let default_command_line_options = {
        Path = Builder.root_path "Fss.json"
        Watch = false
        Verbose = false
        Quit = false
    }

    let print_help () =
        printfn "Usage: dotnet Fss.Build [options]"
        printfn "Options:"
        printfn "  -h, --help       Display help"
        printfn "  -p, --path PATH  Specify the path to the configuration file"
        printfn "  -w, --watch      Watch for changes in the styles"
        printfn "  -v, --verbose   Verbose logging"
        printfn ""


    let parse_command_line args =
        let rec recurse args options =      
            match args with
            | [] -> options
            | "-h"::xs
            | "--help"::xs ->
                print_help ()
                let new_options = { options with Quit = true }
                recurse xs new_options
            | "-p"::xs
            | "--path"::xs ->
                match xs with
                | [] -> 
                    eprintfn "-p / --path needs a path argument"
                    recurse xs options
                | path::xss -> 
                    let new_options = { options with Path = Builder.root_path path}
                    recurse xss new_options
            | "-w"::xs
            | "--watch"::xs ->
                let new_options = { options with Watch = true }
                recurse xs new_options
            | "-v"::xs
            | "--verbose"::xs ->
                let new_options = { options with Verbose = true }
                recurse xs new_options
            | x::xs ->
                eprintfn "Option '%s' is unrecognized" x
                recurse xs options

        let args = Array.toList args
        recurse args default_command_line_options


module Main =
    [<EntryPoint>]
    let main args =
        let command_line_options = Command_Line.parse_command_line args

        if not command_line_options.Quit then
            let file_content = Builder.read_options_file command_line_options.Path

            match file_content with
            | Error e -> printfn "Error: %A" e
            | Ok file_content ->
                let options = 
                    file_content
                    |> Decode.fromString Builder.OptionsDecoder

                match options with
                | Ok options ->
                    Builder.verbose <- command_line_options.Verbose
                    if command_line_options.Watch then
                        File_Watcher.watch options

                        printfn $"Watching for changes in {options.FssSource.Path}"
                        printfn "Press any key to exit..."
                        Console.ReadKey() |> ignore
                    else
                        Builder.build options

                | Error e -> 
                    printfn "Error: %A" e
        0
