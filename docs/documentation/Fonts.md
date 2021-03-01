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
    fontFaces  "DroidSerif "
        [
            [
                FontFace.Source <| UrlFormat ( "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf ", FontFace.Truetype)
                FontFace.Weight FontTypes.Bold
                FontFace.Style Normal
            ]
            [
                FontFace.Source <| UrlFormat ( \https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf \, FontFace.Truetype)
                FontFace.Weight Normal
                FontFace.Style Normal
            ]
        ]
let modernaFont =
    fontFace "moderna "
        [
            FontFace.Sources
                [
                    UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2 ", FontFace.Woff2)
                    UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff ", FontFace.Woff)
                    UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FontFace.Truetype)
                    UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FontFace.Svg)
                ]
            FontFace.Weight Normal
            FontFace.Style Normal
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