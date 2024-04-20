## Fss.Static & Fss.Builder

## Philosophy

Fss was originally designed with a CSS-in-JS mindset: "Build the styles in the web-app the user is using it".
This system works really great when using Fable and Feliz or any type of JavaScript framework - but it starts having some issues if you want to use Giraffe or Falco.
Additionally, you might not require such dynamism. CSS is pretty powerful now and maybe you just want to create some static CSS files instead.

Previously, accomplishing this with Fss was not possible, which is why Fss.Static and Fss.Builder were developed.

I have been working on and off on this for a long time, because I was unable to make it work the way I wanted.
I had been using Vanilla-Extract and TypeScript for some time and I really liked using that, and I wanted something similar.

My requirements were:
- Write styles in F# and Fss.
- "Compile" these styles into CSS files.
- Do not require including any kind of Fss or extra tooling into my App project. The only thing you need to include here is the F# library with the CSS names.

## Configuration
Fss.Builder requires a json file with options.

- `FssSource` is the F# library file containing all the Fss styles you have defined
    - `Path` is the path to the directory of this library
    - `Name` is the name of this Library
    - `Namespace` is the namespace of where Fss.Builder should look for the style lists you want to "compile"
- `GeneratedProject` is an field, if this is omitted no F# library with styles is generated.
    - `Path` the path you want to output this generated F# library
    - `Name` name of the library you want to create
- `CssOutputPath` the path you want to output the final CSS files to.


If my project looks like this:
```
├── LibraryStyles      // A library containing all styles
│   ├── fonts.fs      
│   ├── buttons.fs     
│   ├── index.fs       // A file where all styles are exported from
├── WebApp
│   ├── wwwroot
├── Fss.json
```

My config file could look like this:
```
{
  "FssSource": {
      "Path": "LibraryStyles/",
      "Name": "Library",
      "Namespace": "index"
  },
  "GeneratedProject": {
    "Path": "GeneratedStyles",
    "Name": "StyleFile"
  },
  "CssOutputPath": "Path"
}
```

After building it should look like this:

```
├── LibraryStyles      // A library containing all styles
│   ├── fonts.fs      
│   ├── buttons.fs     
│   ├── index.fs       // A file where all styles are exported from
├── WebApp
│   ├── wwwroot
│   │   ├── fonts.css   // Css files generated based on lists in index.fs
│   │   ├── buttons.css
├── GeneratedStyles    // the project output taht should be referenced by webapp
│   ├── StyleFile.fs      
├── Fss.json
```

## Installation


#### Style library
- Create a F# library that will contain all your styles
- Add Fss-lib.Static to this
	```
	dotnet add package Fss-lib.Static
	```

#### Create Fss.json file
- Create a `Fss.json` file that matches the above configuration.

#### Install Fss.Builder
- This is used to "compile" your styles
```
dotnet new tool-manifest
dotnet tool install Fss-lib.Builder
```

With these steps done you are ready to build CSS files with Fss.

## Usage

1. Write your styles in the style library and add them to a list
2. Run Fss.Builder `dotnet Fss.Build`
    - you can speciy path with `-p <PATH>` or `--path <PATH>`
    - you can recompile the styles with `-w` or `--watch`
3. Include the output library project into your app
4. Start using the CSS files.

For a practical example of integration with Giraffe, please refer to [this](LINKY) sample.

## Css files
Css files are output based on lists you create in entry point of your styles library project.
In the [Giraffe](LINKY) sample it is defined like so:

index.fs
```fsharp
module Index // The namespace we are looking for

let styles = [
    globalBoxSizing 
    container
    header
    input
    fadeAnimation
    button
    indexCounter
    counter
    counterDone
]

let fonts = [
    droidSerifFont 
    modernaFont 
    droidSerif 
    droidSerifBold 
    moderna
]
```

Running Fss.Build on this will result in 2 css files. `styles.css` and `fonts.css`.

You are free to have as many or as few of these lists as you want.
If I only wanted 1 big CSS file named index.css I would this:

```fsharp
module Index // The namespace we are looking for

let index = [
    globalBoxSizing 
    container
    header
    input
    fadeAnimation
    button
    indexCounter
    counter
    counterDone
    droidSerifFont 
    modernaFont 
    droidSerif 
    droidSerifBold 
    moderna
]
```

You could also have conditionals here, if you wanted different files output depending on development or production or whatever.

