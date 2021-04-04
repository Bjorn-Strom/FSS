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

The equivalent styling in Feliz with Fss is:

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

The syntax is not very different here and I personally prefer the latter Fss syntax. So that it what Fss will be supporting going forward.