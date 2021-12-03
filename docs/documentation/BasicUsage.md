## Basic usage

The main function this library supplies is `fss`.
It takes a list of CSS properties and returns a string.
This string is the classname you can give to your html tag.

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
In this case you can fallback on the `.Value` function, which every CSS property has and is how the library works behind the scenes.
Here is an example of that.

```fsharp
let myDecorationColor = FssTypes.Color.Color.white
fss [ TextDecorationColor.value myDecorationColor ]
```

As this is something you might want to do quite a bit there exists a shorthand which is `TextDecorationColor'`.
```fsharp
let myDecorationColor = FssTypes.Color.Color.white
fss [ TextDecorationColor' myDecorationColor ]
```

The `.value` function is particularly useful when you wish to apply a function to a property. Like pixel, size, or percent, that does not exist as a member on the property you are trying to style.

## Global styles

You can use global styles by using the `global'` function.
This function accepts the same parameters as the `fss` function,
the main difference being that these styles are applied globally.

```fsharp
! FssTypes.Html.All [ BoxSizing.borderBox ]
```

## Useful functions

`important: CssProperty -> CssProperty`

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
The escape hatch is a function that takes two string, a key and a value and attempts to make Css with it.
For example if I want to set border with shorthand I can write:

```fsharp
fss [ Custom "border" "4mm ridge rgba(170, 50, 220, .6)"]
```
</example>
