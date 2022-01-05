## Installation

Fss provides several libraries you can choose from:
- [Fss.Engine](LINK) is a dotnet library used to create CSS.
- [Fss.Fable](LINK) is built on Fss.Engine and Fable to give some convenience functions when using Fss with Fable.React.
- [Fss.Feliz](LINK) lets you write Fss with Feliz syntax. This is built on Fss.Fable.
- [Fss.Giraffe](LINK)  provides helper functions that makes it easier to work with [GiraffeViewEngine](LINK). Built atop `Fss.Engine`

Just install the nuget package you need and you are good to go.

You probably want to pick a framework specific library unless you are doing something special or your are using an unsupported framework.

To install `Fss` you need to install the nuget package.
```
# nuget
dotnet add package Fss.<YourLibraryOfChoice>
// For example
dotnet add package Fss.Fable
```