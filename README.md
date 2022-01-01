
<p align="center">
    <img src="https://github.com/Bjorn-Strom/FSS/raw/master/logo.png" width="150px" />
    <h1 align="center">Fss</h1>
</p>

[![Build Status](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Fbjorn-strom%2FFSS%2Fbadge&style=for-the-badge)](https://actions-badge.atrox.dev/bjorn-strom/FSS/goto) ![Tests](https://img.shields.io/badge/TESTS-2573-9cf?style=for-the-badge) ![Nuget](https://img.shields.io/nuget/v/fss-lib?style=for-the-badge&logo=nuget) ![Nuget](https://img.shields.io/nuget/dt/fss-lib?style=for-the-badge&logo=nuget) [![GitHub license](https://img.shields.io/github/license/Bjorn-Strom/FSS?style=for-the-badge)](https://github.com/Bjorn-Strom/FSS/blob/master/LICENSE.md)

A statically typed CSS library for Dotnet with no dependencies.
Have CSS as a first class citizen in your F# projects.

## [Documentation 📖](https://bjorn-strom.github.io/FSS/)

## Structure
The workhorse for Fss is `Fss.Engine`. This is what generates all the CSS.
All it does is spit out classnames and the corresponding CSS so it might not be the library you want to work with.
Other framework specific libraries have been made on top of this.
For example to Fable, Feliz and Giraffe. So if you are using any of these frameworks one of those libraries is a safe bet.

## Motivation 🤔

While you have some good alternatives with F# such as:
- [Fulma](https://fulma.github.io/Fulma/)
- [TypedCssClasses](https://github.com/zanaptak/TypedCssClasses) a type provider if you want to write CSS or SCSS
- Or some kind of webpack configuration if you want to use CSS or SCSS directly.

Ultimately you will find what you like best and whatever suits your needs.

Even with all these options there is, to my knowledge, no one solution that works in any Dotnet project.
This is what Fss aims to solve.

The primary goal of this project is to have an easy way to write type-safe discoverable styling with F# that supports most of the CSS spec.
It was also important to me that it works independently of any other frameworks and would work anywhere you can run F# code.
Therefore you can use Fss with Fable, Giraffe or any other solution you can think of.

Major goals of Fss
- I did not want to reinvent the wheel - it should be easy to use if you already know CSS.
- Writing CSS in F# to be discoverable, strongly typed, and the IDE to help out as much as possible.
- It is important to support pseudo-classes and elements as well as animations, counters and combinators.
- Have a system in place and use that to create framework specific libraries.

Download one nuget package and you are ready to go!

## Examples 🤓
Quick fable example here, check the documentation for more information.
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

You can also check out this sample repo: [samples](https://github.com/Bjorn-Strom/elmish-fss-template).

## Features 🛠
- Discoverable, use the IDE to help you write the styling
- Trying to support a big part of the CSS spec
- Works independently of any HTML framework.
- All the benefits of having your styling in your language as a first class citizen

## Installation 💾
Install the Nuget package you need.
If you are using Fable or Feliz then you probably want `Fss.Fable` or `Fss.Feliz`.
If you are using Giraffe then you probably want `Fss.Giraffe`.
Doing something custom or extending Fss? Then you probably want `Fss.Engine`.

To install `Fss` you need to install the nuget package.
```
# nuget
dotnet add package Fss-lib

# paket
paket add Fss-lib --project ./project/path
```

## Contribution 🔨
Noticed a bug or a missing feature?
Maybe you are missing a framework specific library?
Feel free to make an issue or a PR!
Any and all contributions are welcome.




