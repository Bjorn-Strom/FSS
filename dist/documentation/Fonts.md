## Import

For importing fonts from google fonts for example, use link syntax within `<head>`

```
<head>
    ...
    ...
    ...
    <link href="https://fonts.googleapis.com/css?family=Nunito|Raleway|Amatic+SC" rel="stylesheet">
</head>
```

```fsharp
let amaticStyle =
    fss [ Label "Amatic Style"
          FontFamily.value "Amatic SC"
          FontSize.value (px 24) ]
```

<example/>

## Font Face

```fsharp
let droidSerifFont =
    fontFaces
        "DroidSerif"
        [ [ FontFace.Src.truetype("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf")
            FontFace.FontWeight.bold
            FontFace.FontStyle.normal ]
          [ FontFace.Src.truetype("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf")
            FontFace.FontWeight.normal
            FontFace.FontStyle.normal ] ]

let modernaFont =
    fontFace
        "moderna"
        [ FontFace.Src.sources
              [ FssTypes.FontFace.Woff2 "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2"
                FssTypes.FontFace.Woff "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff"
                FssTypes.FontFace.Truetype "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf"
                FssTypes.FontFace.Svg "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg" ]
          FontFace.FontWeight.normal
          FontFace.FontStyle.normal ]

let droidSerif =
    fss [ Label "Droid Serif"
          FontFamily.value droidSerifFont ]

let droidSerifBold =
    fss [ Label "Droid Serif Bold"
          FontFamily.value droidSerifFont
          FontWeight.bold ]

let moderna =
    fss [ Label "Moderna"
          FontFamily.value modernaFont ]
```

<example/>
