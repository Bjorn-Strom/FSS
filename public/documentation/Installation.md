## Installation

Fss provides several libraries you can choose from:
- [Fss.Core](https://www.nuget.org/packages/Fss-lib.Core/) is a dotnet library used to create CSS.
- [Fss.Fable](https://www.nuget.org/packages/Fss-lib.Fable/) is built on Fss.Core and Fable to give some convenience functions when using Fss with Fable.React.
- [Fss.Feliz](https://www.nuget.org/packages/Fss-lib.Feliz/) lets you write Fss with Feliz syntax. This is built on Fss.Fable.
- [Fss.Giraffe](https://www.nuget.org/packages/Fss-lib.Giraffe/)  provides helper functions that makes it easier to work with [GiraffeViewEngine](https://github.com/giraffe-fsharp/Giraffe.ViewEngine). Built atop `Fss.Core`
- [Fss.Falco](https://www.nuget.org/packages/Fss-lib.Falco/)  provides helper functions that makes it easier to work with [Falco Markup](https://github.com/pimbrouwers/Falco.Markup). Built atop `Fss.Core`

Just install the nuget package you need and you are good to go.

You probably want to pick a framework specific library unless you are doing something special or your are using an unsupported framework.

To install `Fss` you need to install the nuget package.
```
# nuget
dotnet add package Fss-lib.<YourLibraryOfChoice>
// For example
dotnet add package Fss-lib.Fable
```