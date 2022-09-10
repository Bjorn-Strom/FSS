## Global styles

You can use global styles by using the `global'` function.
This function accepts the same parameters as the `fss` function,
the main difference being that these styles are meant to be applied globally.

What `Fss.Core` returns from its `createGlobal` function is styles with the `*` classname.
What the helper libraries like `Fss.Fable` does is inject these into the dom, thus creating global styles.

```fsharp
global' [
    // Make all links be red
    Link [ Color.red ]
    // Use a selector to target all html elements and make them border box
    ! (Selector.tag Fss.Types.Html.All) [ BoxSizing.borderBox ]
    // Use a selector to target the body element and set the background color to black
    ! (Selector.tag Fss.Types.Html.Body) [ BackgroundColor.black ]
]
```
