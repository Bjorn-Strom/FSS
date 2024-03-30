<p align="center">
    <img src="https://github.com/Bjorn-Strom/FSS/raw/master/logo.png" width="150px" />
    <h1 align="center">Fss</h1>
</p>

[![Build Status](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Fbjorn-strom%2FFSS%2Fbadge&style=for-the-badge)](https://actions-badge.atrox.dev/bjorn-strom/FSS/goto) ![Tests](https://img.shields.io/badge/TESTS-2692-9cf?style=for-the-badge) [![GitHub license](https://img.shields.io/github/license/Bjorn-Strom/FSS?style=for-the-badge)](https://github.com/Bjorn-Strom/FSS/blob/master/LICENSE.md)

Fss is a dependency free CSS library for dotnet that provides statically typed styling for your projects and aims to
cover a huge part of the CSS spec.

It gives you CSS as a first class citizen in your projects and was made to be predictable and easy to use.

Fss gives you the option to generate styles at runtime or to generate static CSS files.

## [Documentation 📖](https://bjorn-strom.github.io/FSS/)

## Examples 🤓

Quick Elmish example here, check the documentation for more information.

```fsharp
let buttonStyle =
    fss
        [
            BackgroundColor.hex "44c767"
            BorderRadius.value (px 30)
            BorderWidth.value (px 1)
            BorderStyle.solid
            BorderColor.hex "18ab29"
            Display.inlineBlock
            Cursor.pointer
            FontSize.value (px 17)
            Hover
                [
                    BackgroundColor.hex "5cbf2a"
                ]
        ]
button [ ClassName buttonStyle ] [ str "Click me" ]
```

You can also check out this sample repo: [samples](https://github.com/Bjorn-Strom/Fss-Samples).

## Installation 💾

Install the Nuget package you need. If you are using Fable or Feliz then you probably want `Fss.Fable` or `Fss.Feliz`.
If you are using Giraffe then you probably want `Fss.Giraffe`, and if you are using `Falco` then you probably want `Fss.Falco`. Doing something custom or extending Fss? Then you
probably want `Fss.Core`.

| Package                                                        | NuGet                                                                                   | Downloads                                                                                |
|----------------------------------------------------------------|-----------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------|
| [Fss.Core ](https://www.nuget.org/packages/Fss-lib.Core/)      | ![Nuget](https://img.shields.io/nuget/v/fss-lib.core?style=for-the-badge&logo=nuget)    | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.core?style=for-the-badge&logo=nuget)    |
| [Fss.Fable](https://www.nuget.org/packages/Fss-lib.Fable/)     | ![Nuget](https://img.shields.io/nuget/v/fss-lib.fable?style=for-the-badge&logo=nuget)   | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.fable?style=for-the-badge&logo=nuget)   |
| [Fss.Feliz](https://www.nuget.org/packages/Fss-lib-feliz/)     | ![Nuget](https://img.shields.io/nuget/v/fss-lib.feliz?style=for-the-badge&logo=nuget)   | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.feliz?style=for-the-badge&logo=nuget)   |
| [Fss.Giraffe](https://www.nuget.org/packages/Fss-lib.Giraffe/) | ![Nuget](https://img.shields.io/nuget/v/fss-lib.giraffe?style=for-the-badge&logo=nuget) | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.giraffe?style=for-the-badge&logo=nuget) |
| [Fss.Falco](https://www.nuget.org/packages/Fss-lib.Falco/)     | ![Nuget](https://img.shields.io/nuget/v/fss-lib.falco?style=for-the-badge&logo=nuget)   | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.falco?style=for-the-badge&logo=nuget)   |
| [Fss.Static](https://www.nuget.org/packages/Fss-lib.Static/)   | ![Nuget](https://img.shields.io/nuget/v/fss-lib.static?style=for-the-badge&logo=nuget)  | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.static?style=for-the-badge&logo=nuget)  |
| [Fss.Builder](https://www.nuget.org/packages/Fss-lib.Builder/) | ![Nuget](https://img.shields.io/nuget/v/fss-lib.builder?style=for-the-badge&logo=nuget) | ![Nuget](https://img.shields.io/nuget/dt/fss-lib.builder?style=for-the-badge&logo=nuget) |

To install `Fss` you need to install the nuget package.

```
# nuget
dotnet add package Fss-lib.<YourLibraryOfChoice>
// For example
dotnet add package Fss-lib.Fable
```

## Motivation 🏁

When it comes to styling in F# you do have some good alternatives for styling:

- [Fulma](https://fulma.github.io/Fulma/), an F# wrapper on [Bulma](https://bulma.io/)
- [TypedCssClasses](https://github.com/zanaptak/TypedCssClasses), a type provider if you want to write CSS or SCSS
- Or some kind of webpack configuration if you want to use CSS or SCSS directly.

There is however no good solution to writing CSS purely in F#, CSS-in-Fs if you will, and this library aims to do just
that. If you wish to write your own CSS and you are using dotnet, Fss is the best solution for just that.

The primary goal of this project is to have an easy way to write type-safe discoverable styling with F# that supports
most of the CSS spec. It was also important to me that it works independently of any other frameworks and would work
anywhere you can run F# code. Therefore you can use Fss with Fable, Giraffe or any other solution you can think of.

Major goals of Fss

- I did not want to reinvent the wheel - it should be easy to use if you already know CSS.
- Writing CSS in F# should be discoverable, strongly typed, and the IDE to help out as much as possible.
- It is important to support pseudo-classes and elements as well as animations, counters and combinators.
- Have a system in place and use that to create framework specific libraries.
- Boilerplate free, just download one nuget package and you are ready to go!

## Features 🛠

- IDE discoverability. Have the IDE help you write the styling as you go.
- Static types, have statically typed CSS. Compilation will fail if you have written invalid CSS (With no guarantees it
  looks good, that is on you!)
- Works independently of any HTML framework.
- Compiles anywhere F# compiles, so it works effortlessly with Dotnet or Fable.
- Server side rendering for free.
- All the benefits of having your styling in your language as a first class citizen.
- Covers a large part of the CSS spec.
- Framework specific helper libraries.

See the [Documentation](https://bjorn-strom.github.io/FSS/) for more information

## Who is it for? 😎

Fss is intended for developers who want to write their own CSS using F#. If you have an existing stylesheet Fss does
nothing for you, (unless you want to rewrite it), in that case you might want to check
out [TypedCssClasses](https://github.com/zanaptak/TypedCssClasses). If you do not want to write your own CSS but you
want to have some prebuilt stylesheet then something like [Fulma](https://fulma.github.io/Fulma/) might be what you are
looking for. IF however you wish to write your own CSS in a type safe way, then Fss is what you want to use.

## Contribution 🔨

The best way to contribute to Fss is to use it! 😎 The more it is used the more tested it gets. If you do find any
missing or bugged CSS properties, or maybe you are missing a framework library, feel free make an issue or PR. If you
have some cool samples or examples feel free to to contribute to the documentation. In short, any and all contributions
are very welcome.
