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
    fss
        [
            FontFamily.Custom "Amatic SC"
            FontSize' (px 24)
        ]
p [ ClassName amaticStyle ] [str """This font is Amatic SC, some nice text this huh?"""]
```


## Font Face

```fsharp
let droidSerifFont =
    fontFaces "DroidSerif"
        [
            [
                FontFace.source <| FssTypes.FontFace.UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf", FssTypes.FontFace.Truetype)
                FontFace.weight FssTypes.Font.Bold
                FontFace.style FssTypes.Normal
            ]
            [
                FontFace.source <| FssTypes.FontFace.UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf", FssTypes.FontFace.Truetype)
                FontFace.weight FssTypes.Normal
                FontFace.style FssTypes.Normal
            ]
        ]
let modernaFont =
    fontFace "moderna"
        [
            FontFace.sources
                [
                    FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2", FssTypes.FontFace.Woff2)
                    FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff", FssTypes.FontFace.Woff)
                    FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FssTypes.FontFace.Truetype)
                    FssTypes.FontFace.UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FssTypes.FontFace.Svg)
                ]
            FontFace.weight FssTypes.Normal
            FontFace.style FssTypes.Normal
        ]
let droidSerif = fss [ FontFamily.Font droidSerifFont ]
let droidSerifBold =
    fss
        [
            FontFamily.Font droidSerifFont
            FontWeight.Bold
        ]
let moderna = fss [ FontFamily.Font modernaFont ]
p [ ClassName droidSerif ] [ str "Droid serif" ]
p [ ClassName droidSerifBold ] [ str  "Droid serif bold" ]
p [ ClassName moderna] [ str "Moderna" ]
```