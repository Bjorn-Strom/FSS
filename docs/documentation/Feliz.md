## Feliz

For a while I considered adding a Feliz specific syntax.
I made a proof of concept that looked like this:

```fsharp
Html.div [
    prop.fss [
        fss.backgroundColor.green
        fss.hover [
            fss.backgroundColor.red
            fss.color.white
        ]
    ]
]
```

I did however find that there isn't much to gain by doing this.
Fss already generates Css with classnames and can be used in a very straight forward way. I also felt it went against one of my goals of this project which was to have a system that is independent of any frontend framework and can be used in any way the user wants.

The equivalent styling in Feliz with normal Fss is:

```fsharp
Html.div [
    prop.className <| fss [
        BackgroundColor.green
        Hover [
            BackgroundColor.red
            Color.white
        ]
    ]
]
```

The syntax is not very different here and I personally prefer the latter Fss syntax as it's more similar to Css.
So that is what Fss will keep supporting going forward.
