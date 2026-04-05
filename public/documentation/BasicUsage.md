## Basic usage

The basic idea behind Fss which is also true for all its framework libraries is a simple one.
Create a list of CssRules and send them into a function. This function returns classnames and CSS.

The main difference between [Fss.Core](https://www.nuget.org/packages/Fss-lib.Core/) and the framework libraries is that the core library consists of the "low-level" functions that make this work, and the framework libraries are there to make using the system easier for a specific framework, like injecting the CSS into the DOM.
But the concept is still the same: lists of CssRules.

## Styling

Simply write the CSS you want in PascalCase and dot yourself into the method you want.
What is available are the typical options the property might provide.

For example if you want:
```
text-decoration-color: white
```
then you write
```
TextDecorationColor.white
```

This works in nearly all cases and is the idiomatic way to write most things.
However you sometimes also want to have the “right hand side” as a variable or parameter.
In this case you can fallback on the `.value` function, which every CSS property has and is how the library works behind the scenes.
Here is an example of that.

```fsharp
let myDecorationColor = Fss.Types.Color.Color.white
fss [ TextDecorationColor.value myDecorationColor ]
```

The `.value` function is particularly useful when you wish to apply a function to a property. Like pixel, size, or percent, that does not exist as a member on the property you are trying to style.

## Useful functions

### important

`important: CssRule -> CssRule`

The important function takes a css property and marks it as important.

For example:
```fsharp
fss [
    important Color.red
]
```
Will produce: `{color:red !important;}`

### combine

`combine: string list -> (string * bool) list -> string`

An implementation of JavaScripts `classNames` or Emotions `cx`.
The function takes a list of classnames to apply and a list of classnames/predicate tuples to optionally apply.

For example:
```fsharp
combine ["classnameA"] [ "classnameToCombine", true; "classnameToIgnore", false ]
```
Will produce: `classnameA classNameToCombine`

The boolean values could be replaced with a predicate of some kind.

A somewhat contrived example:
```fsharp
let modalOpenStyles = fss []
let modalClosedStyles = fss []
let commonModalStyles = fss []
let modalStyles = combine [commonModalStyles] 
    [ modalOpenStyles, isModalOpen
      modalClosedStyles, !isModalOpen ]
```

### fssWithClassname
Creates an Fss block with a specified name.
The normal `Fss` function generates a classname for you which is a hash of the CSS properties you provide.
That is what you would normally use.
Sometimes however it is useful to be able to provide your own classname - especially when working with an independent stylesheet.

This function exists in all Fss libraries.
For specific examples and function signatures check the documentation page of the library you are using.

## Shorthands

FSS supports CSS shorthands using F# optional parameters. This lets you set multiple related properties in one call while only specifying the values you need.

```fsharp
fss [ Border.value(px 2, Border.Style.Solid, hex "008000") ]
// border: 2px solid #008000;

fss [ Outline.value(style = Outline.Style.Dashed) ]
// outline: dashed;

fss [ Font.value(px 16, "Arial", style = Font.Style.Italic) ]
// font: italic 16px Arial;
```

See the [Shorthands](#/page/shorthands) page for the full list and detailed usage.

For anything FSS doesn't support directly, you can use the custom escape hatch which takes two strings, a key and a value:

```fsharp
fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)"]
```

<example/>
