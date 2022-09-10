## Fss.Fable

## Installation
```
# nuget
dotnet add package Fss-lib.Fable
```

## Usage

This library provides helper functions to make it easier to use Fss in 
any libraries built on Fable, like Fable.React.

`Fss.Fable` provides these functions:

- `fss: Rule list -> string`
    - This is the function you want to use most of the time. Supply it
    with the CSS rules you want and it will create the CSS for you and inject it into the dom.
    All you have to do is supply the classname the function returns to your html element.

- `global': Rule list -> unit`
  - Takes a list of rules and injects it as global styles.

- `counterStyle: CounterRule list -> string`
  - Takes a list of counter rules, creates a counter, inserts it into the dom and returns the counter name.
  This counter name can then be used when creating other rules.

- `fontFace': FontFaceRule list -> string`
    - Takes a list of fontface rules, creates a font, inserts it into the dom and returns the font name.
      This font name can then be used when creating other rules.
  
- `fontFaces': FontFaceRule list list -> string`
    - Takes a list with lists of fontface rules, creates a font, inserts it into the dom and returns the font name.
      This font name can then be used when creating other rules.
  
- `keyframes': Keyframes list -> string`
  - Takes a list of keyframes rules, creates a keyframe, inserts it into the dom and returns the font name.
    This font name can then be used when creating other rules.

## Examples
Using Fss.Fable is as simple as:

```fsharp
let hoverStyle =
    fss [
        Width.value (px 200)
        Height.value (px 200)
        BackgroundColor.green
        Hover [
            BackgroundColor.red
        ]
    ]

div [ ClassName hoverStyle ] []
```
