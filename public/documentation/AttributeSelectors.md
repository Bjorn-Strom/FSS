## Attribute Selectors

To quote [mdn](https://developer.mozilla.org/en-US/docs/Web/CSS/Attribute_selectors), "The CSS attribute selector matches elements based on the presence or value of a given attribute." 

So you can target all div elements with a `title` attribute.
I really recommend you go read the MDN link above and then see how this can be done in Fss.

### [attr]
Selects attributes with the name of `attr`

The following CSS block
```css
[title] {
    background-color: red;
}
```

Can be written like so in Fss

```fsharp
fss [
    Attr.Has (Attribute.title, [
        BackgroundColor.red
    ])
]
```

<example/>

### [attr=value]

Allows you to specify the **exact** value of an attribute.
```css
[title="heading"] {
    text-decoration-line: underline;
}
```

Can be written like so in Fss

```fsharp
fss [
    MatchAttr.Exactly (Attribute.title, "heading", [
         TextDecorationLine.underline
    ])
]
```

<example/>

### [attr~=value]

### [attr^=value]

### [attr$=value]

### [attr*=value]

### Sensitivity 
