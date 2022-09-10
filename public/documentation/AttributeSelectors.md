## Attribute Selectors

To quote [mdn](https://developer.mozilla.org/en-US/docs/Web/CSS/Attribute_selectors), "The CSS attribute selector matches elements based on the presence or value of a given attribute." 

For example you can target all div elements with a `title` attribute.
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

### [attr=value] - exactly

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

### [attr~=value] - Contains

Lets you match an element where value exactly matches those within a whitespace-separated list.

```fsharp
fss [
    MatchAttr.Contains (Attribute.title, "heading", [
         FontSize.value (px 28)
    ])
]
```

<example/>

### [attr|=value] - ValueOrContinuation

Matches elements in a hyphen separated list.

So if you want to match all languages beginning with en:

```fsharp
fss [
    MatchAttr.ValueOrContinuation (Attribute.Lang, "en", [
        Color.blue
    ])
]
```

<example/>

### [attr^=value] - Prefix

Matches an attribute that starts with a specific value.
In the following example we use it to style `http` and `https` links differently.

```fsharp
fss [
    MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Href, "http://", [
        BackgroundColor.red
    ])
    MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Href, "https://", [
        BackgroundColor.green
    ])
]
```

<example/>

### [attr$=value]  - Suffix
Matches an attribute that ends with a specific value.
In the following example we use it to style `.pdf` and `.txt` links differently.

```fsharp
fss [
    MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Href, ".pdf", [
        BackgroundColor.blue
    ])
    MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Href, ".txt", [
        BackgroundColor.green
    ])
]
```

<example/>

### [attr*=value] - AtLeastOne

Matches a value that contains at least one occurence of a specific value.

Say we want to match all these types of headings:
- `heading`
- `sub-heading`
- `sub-sub-heading`
Or something similar we could do:
```fsharp
MatchAttr.AtLeastOne (Attribute.Id, "heading", [
    TextDecorationLine.underline
    TextDecorationThickness.fromFont
])
```

<example/>

### Sensitivity 

Finally all `MatchAttr` functions can take in another parameter which specifies whether or not the matching is case sensitive:

```fsharp
MatchAttr.AtLeastOne (Attribute.Id, "heading", Fss.Types.Attribute.Sensitive, [
...
```

```fsharp
MatchAttr.AtLeastOne (Attribute.Id, "heading", Fss.Types.Attribute.Insensitive, [
...
```
