## Fss.Giraffe

## Installation

```
# nuget
dotnet add package Fss-lib.Giraffe
```

## Usage

This library provides helper functions to make it easier to use Fss with [Giraffe view engine](https://github.com/giraffe-fsharp/Giraffe.ViewEngine).

The biggest difference when using Fss with Giraffe is that there is no automatic injection of styles into the dom.
That is because there is no reliable way of doing that with the view engine.

`Fss.Giraffe` provides these functions:

- `fss: Rule list -> string * XmlNode`
    - This is the function you want to use most of the time. Supply it
      with the CSS rules you want and it will create the CSS for you and return the classname and a style node.
      place this style node in the children list of `head` and then use the classname in your html element of choice. 

- `global': Rule list -> XmlNode`
    - Takes a list of rules and creates a style node you can insert in your dom to get global styling.

- `counterStyle: CounterRule list -> string * XmlNode`
    - Takes a list of counter rules, creates a counter and returns a counter name and style node.
      place this style node in the children list of `head` and then use the counter name in your html element of choice.

- `fontFace': FontFaceRule list -> string * XmlNode`
    - Takes a list of font face rules, creates a fontface and returns its name and style node.
      place this style node in the children list of `head` and then use the font face name in your html element of choice.
  
- `fontFaces': FontFaceRule list list -> string * XmlNode`
  - Takes a list with lists of font face rules, creates a fontface and returns its name and style node.
    place this style node in the children list of `head` and then use the font face name in your html element of choice.
   
- `keyframes': Keyframes list -> string`
    - Takes a list of keyframes rules, creates a keyframe, inserts it into the dom and returns the font name.
      This font name can then be used when creating other rules.

## Examples
Using `Fss.Giraffe` is as simple as:


```fsharp
let hoverClassName, hoverStyleNode =
    fss [
        Width.value (px 200)
        Height.value (px 200)
        BackgroundColor.green
        Hover [
            BackgroundColor.red
        ]
    ]

head []
    [
        hoverStyleNode
    ]
body []
    [
        div [ _class hoverClassName ] []
    ]
```
