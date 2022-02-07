## Basic usage

The basic idea behind Fss which is also true for all its framework libraries is a simple one.
Create a list of CssRules and send them into a function. This function returns classnames and CSS.

The main difference between [Fss.Core](LINK) and the framework libraries is that the core library consists of the "low-level" functions that make this work, and the framework libraries are there to make using the system easier for a specific framework.
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

`important: CssRule -> CssRule`

The important function takes a css property and marks it as important.

`combine: string list -> (string * bool) list -> string`

An implementation of JavaScripts `classNames` or Emotions `cx`.
The function takes a list of classnames to apply and a list of classnames/predicate tuples to optionally apply.

## Shorthands

I don't like shorthands so I haven't included them. In general I feel they make CSS more complicated than it needs to be.
However as this project creates CSS and interacts with it, it has to deal with some of its shortcoming, like shorthands.

Therefore the shorthands that are included are limited to ones where using `inherit`, `initial`, `unset` or `none` is natural. Like text-decoration.
For example resetting `text-decoration` would be  really annoying without it - having to go through each property resetting it manually.

However if shorthands is something you really want to use, you can use the custom escape hatch to write them up in string.
The escape hatch is a function that takes two strings, a key and a value and attempts to make Css with it.
For example if I want to set border with shorthand I can write:

```fsharp
fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)"]
```

<example/>
