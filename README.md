
<p align="center">
    <img src="https://github.com/Bjorn-Strom/FSS/raw/master/logo.png" width="150px" />
    <h1 align="center">Fss</h1>
</p>

![AppVeyor](https://img.shields.io/appveyor/build/bjorn-strom/FSS?style=for-the-badge&logo=appveyor) ![Tests](https://img.shields.io/badge/TESTS-2117-9cf?style=for-the-badge) ![Nuget](https://img.shields.io/nuget/v/fss-lib?style=for-the-badge&logo=nuget) ![Nuget](https://img.shields.io/nuget/dt/fss-lib?style=for-the-badge&logo=nuget) [![GitHub license](https://img.shields.io/github/license/Bjorn-Strom/FSS?style=for-the-badge)](https://github.com/Bjorn-Strom/FSS/blob/master/LICENSE.md)

An opinionated styling library for F#.
Have CSS as a first class citizen in your F# projects.

Built atop the fantastic [Emotion-js](https://github.com/emotion-js/emotion) library and uses that for all CSS generation.

I have also written an article on the project you can read [here](https://blogg.bekk.no/introducing-fss-cff9fdd300a1)

## [Documentation 📖](https://bjorn-strom.github.io/FSS/)

## Examples 🤓
Quick example here, check the documentation for more information.
```fsharp
let buttonStyle =
    fss
        [
            BackgroundColor.hex "44c767"
            BorderRadius' (px 30)
            BorderWidth' (px 1)
            BorderStyle.solid
            BorderColor.hex "18ab29"
            Display.inlineBlock
            Cursor.pointer
            FontSize' (px 17)
            Hover
                [
                    BackgroundColor.hex "5cbf2a"
                ]
        ]
button [ ClassName buttonStyle ] [ str "Click me" ]
```

## Motivation 🤔
While you have some good alternatives with F# such as:
- [Fulma](https://fulma.github.io/Fulma/)
- [TypedCssClasses](https://github.com/zanaptak/TypedCssClasses) a type provider if you want to write CSS or SCSS
- Or some kind of webpack configuration if you want to use CSS or SCSS directly.

Ultimately you will find what you like best and whatever suits your needs, I find that writing CSS is annoying.
It is not discoverable, not type-safe and requires some setup.

The primary goal of this project is to avoid all of that and have an easy way to write type-safe discoverable styling with F# that supports most of the CSS spec.

3 major goals of Fss
- I did not want to reinvent the wheel - it should be easy to use if you already know CSS.
- Writing CSS in F# to be discoverable, strongly typed, and the IDE to help out as much as possible.
- It is important to support pseudo-classes and elements as well as animations, counters and combinators.

Download one nuget package and one npm package and you are ready to go.

## Features 🛠
- Uses Emotion-js to generate the CSS and therefore gets some of its amazing features for free
- Discoverable, use the IDE to help you write the styling
- Trying to support a big part of the CSS spec
- Works independently of Fable.React and Feliz and thus works with both (and without them)
- All the benefits of having your styling in your language as a first class citizen

## Installation 💾
To install `Fss` you need to install the nuget package.
```
# nuget
dotnet add package Fss-lib

# paket
paket add Fss-lib --project ./project/path
```

And you need to install [Emotion-js](https://github.com/emotion-js/emotion).
Fss uses version 11 or greater.
```
# npm
npm i @emotion/css

# yarn
yarn add @emotion/css
```


You can also check out this template [repo](https://github.com/Bjorn-Strom/elmish-fss-template).




