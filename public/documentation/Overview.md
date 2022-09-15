## Overview

Fss is a dependency free statically typed CSS library that compiles to dotnet.
It provides a hassle free and type safe way to write your CSS.
If your styling is incorrectly written it won't compile. It is as simple as that.

## Structure
The workhorse for Fss is [Fss.Core](https://www.nuget.org/packages/Fss-lib.Core/), this library produces classnames and corresponding CSS.
The engine is written in F# and is dependency free, so it compiles anywhere F# compiles.
In other words, it works both with Fable and Dotnet.

In addition to [Fss.Core](https://www.nuget.org/packages/Fss-lib.Core/) there exists framework specific libraries which aim to make using
Fss more ergonomic. Currently there exists libraries for:
- [Fable](https://fable.io/)
- [Feliz](https://zaid-ajaj.github.io/Feliz/)
- [Giraffe](https://github.com/giraffe-fsharp/Giraffe)
- [Falco](https://github.com/pimbrouwers/Falco)

Check out the framework library documentation pages for specifics on how they work.
