## Fss.Static & Fss.Builder


## Philosophy

Fss was originally designed with a CSS-in-JS mindset. Build the styles in the web-app the user is using it.
This system works really great when using Fable and Feliz or any type of JavaScript framework - but it starts having some issues if you want to use Giraffe or Falco.
Additionally, you might not require such dynamism. CSS is pretty powerful now and maybe you just want to create some static CSS files instead.

Previously, accomplishing this with Fss was not possible, which is why Fss.Static and Fss.Builder were developed.

I have been working on and off on this for a long time, because I was unable to make it work the way I wanted.
I had been using Vanilla-Extract and TypeScript for some time and I really liked using that, and I wanted something similar.

My requirements were:
- Write styles in F# and Fss.
- "Compile" these styles into CSS files.
- Do not require including any kind of Fss or extra tooling into my App solution. The only thing you need to include here is the F# library with the CSS names.

## Configuration
Fss.Builder requires a json file with options.
```
{
  "FssSource": {
      "Path": "Path",
      "Name": "Name",
      "Namespace": "Name"
  },
  "GeneratedProject": {
    "Path": "Path",
    "Name": "Name"
  },
  "CssOutputPath": "Path"
}
```

- `FssSource` is the F# library file containing all the Fss styles you have defined
    - `Path` is the path to the directory of this library
    - `Name` is the name of this Library
    - `Namespace` is the namespace of where Fss.Builder should look for the style lists you want to "compile"
- `GeneratedProject` is an optional field, if this is omitted no F# library with styles is generated.
    - `Path` the path you want to output this generated F# library
    - `Name` name of the library you want to create
- `CssOutputPath` the path you want to output the final CSS files to.

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
2. Run Fss.Builder `dotnet Fss.Builder Fss.json`
3. Include the output library project into your app
4. Start using the CSS files.

For a practical example of integration with Giraffe, please refer to this sample.

You can also look at this for a Falco, HTMX and Fss.Static example.
