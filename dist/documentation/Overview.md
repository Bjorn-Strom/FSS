## Overview

Fss is a dependency free statically typed CSS library that compiles to dotnet.
Provides a hassle free and type safe way to write your CSS.
If your styling is incorrectly written it won't compile.

## Structure 🏢
The workhorse for Fss is `Fss.Engine` which generates the CSS.
It produces classnames and the corresponding CSS.
The engine is written in F# and is dependency free, so it compiles anywhere F# compiles.
In other words, it works both with Fable and Dotnet.

In addition to `Fss.Engine` there exists framework specific libraries as well which aims to make using
Fss more ergonomic. Currently there exists libraries for
Fable, Feliz and Giraffe. If you want to do something different or make your own framework library
then the engine is it for you!

Check out the framework libraries for specifics on how they work.
