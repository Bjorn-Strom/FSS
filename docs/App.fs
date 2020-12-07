module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Fss

type Model = {
    FlexDirection: FlexType.FlexDirectionType
    FlexWrap: FlexType.FlexWrapType
    AlignContent: FlexType.AlignContentType
    BackgroundRepeat: BackgroundType.BackgroundRepeatType
    BRepeat: BorderType.BorderImageRepeatType * BorderType.BorderImageRepeatType option }
type Msg =
    | SetFlexDirection of FlexType.FlexDirectionType
    | SetFlexWrap of FlexType.FlexWrapType
    | SetAlignContent of FlexType.AlignContentType
    | SetBackgroundRepeat of BackgroundType.BackgroundRepeatType
    | SetBorderImagerRepeat of BorderType.BorderImageRepeatType * BorderType.BorderImageRepeatType option

let init() = {
    FlexDirection = FlexType.Row
    FlexWrap = FlexType.Wrap
    AlignContent = FlexType.Center
    BackgroundRepeat = BackgroundType.NoRepeat
    BRepeat = BorderType.Stretch, Option.None}

let update (msg: Msg) (model: Model): Model =
    match msg with
    | SetFlexDirection direction -> { model with FlexDirection = direction}
    | SetFlexWrap wrap -> { model with FlexWrap = wrap}
    | SetAlignContent content -> { model with AlignContent = content}
    | SetBackgroundRepeat repeat -> { model with BackgroundRepeat = repeat}
    | SetBorderImagerRepeat (r, r2) -> { model with BRepeat = r, r2}
let ColorExamples () =
    fragment []
        [
            h1 [] [ str "Color" ]
            p [] [ str "Tons of different ways to style color" ]
            p [ ClassName (fss [Color.deepPink]) ] [ str "Named colors like deeppink"]
            p [ ClassName (fss [Color.Rgb 255 0 0])] [ str "Or you can style it using an RGB function!"]
            p [ ClassName (fss [Color.Rgba 0 0 0 0.5])] [ str "We also support RGBA"]
            p [ ClassName (fss [Color.Hex "00ff00"])] [ str "or you can use HEX"]
            p [ ClassName (fss [Color.Hex "0000ff80"])] [ str "HEX can also be transparent"]
            p [ ClassName (fss [Color.Hsl 120 0.5 0.5])] [ str "Or just use HSL"]
            p [ ClassName (fss [Color.Hsla 120 0.5 0.5 0.5])] [ str "HSL can also be transparent"]
            p [ ClassName (fss [Color.Inherit]) ] [ str "Colors can be inherited"]
            p [ ClassName (fss [Color.Initial]) ] [ str "Colors can be initialed"]
            p [ ClassName (fss [Color.Revert]) ] [ str "Colors can be reverted"]
            p [ ClassName (fss [Color.Unset]) ] [ str "Colors can be unset"]
        ]

let BackgroundExamples model dispatch =
    fragment []
        [
            div []
                [
                    h2 [] [ str "Bakground" ]

                    div [ ClassName (fss [
                        BackgroundColor.green
                        Height' (px 20)
                        Width' (px 20)
                    ]) ] []

                    div [ ClassName (fss [
                        BackgroundRepeat.NoRepeat
                        BackgroundImage.Url "https://interactive-examples.mdn.mozilla.net/media/examples/lizard.png"
                        Height' (px 200)
                        Width' (px 200)
                    ]) ] []

                    div [ ClassName (fss [
                        BackgroundOrigin.ContentBox
                        //BackgroundImage.RadialGradient(CSSColor.crimson, CSSColor.skyBlue)
                        Height' (px 60)
                        Width' (px 60)
                    ]) ] []

                ]

            h3 [] [ str "And gradients!" ]

            div [ ClassName (fss [Display.Flex]) ]
                [
                    div [
                        ClassName (fss
                            [
                                Width' (px 200)
                                Height' (px 200)
                                //BackgroundImage.LinearGradient(CSSColor.red, CSSColor.blue)
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width' (px 200)
                                Height' (px 200)
                                //BackgroundImage.LinearGradient(ToRight, CSSColor.red, CSSColor.blue)
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width' (px 200)
                                Height' (px 200)
                                //BackgroundImage.RadialGradient(CSSColor.red, CSSColor.blue)
                            ])
                    ] []

                    div [
                        ClassName (fss
                            [
                                Width' (px 200)
                                Height' (px 200)
                                //BackgroundImage.RepeatingRadialGradient(CSSColor.blue, stop CSSColor.red (px 0) )
                            ])
                    ] []
                ]

            div [ ClassName (fss [Display.Flex]) ]
                [

                    div [
                        ClassName (fss
                            [
                                Width' (px 200)
                                Height' (px 200)
                                //BackgroundImage (Image.RepeatingRadialGradient [ hex "#e66465"; hex "9198e5"; pct 20 ] )
                            ])
                    ] []

                    div [
                            ClassName (fss
                                [
                                    Width' (px 200)
                                    Height' (px 200)
                                    //BackgroundImage.LinearGradient(ToBottom, CSSColor.red, hex "f06d06" )
                                ])
                        ] [ ]

                    div [
                            ClassName (fss
                                [
                                    Width' (px 200)
                                    Height' (px 200)
                                    //BackgroundImage.LinearGradient(deg 72.0, CSSColor.red, hex "f06d06")
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width' (px 200)
                                    Height' (px 200)
                                    //BackgroundImage.LinearGradient(ToRight, [CSSColor.red; hex "f06d06"; rgb 255 255 0; CSSColor.green])
                                ])
                        ] []
                ]

            div [ ClassName (fss [Display.Flex]) ]
                [

                    div [
                        ClassName (fss
                            [
                                Width' (px 200)
                                Height' (px 200)
                                //BackgroundImage.LinearGradient(ToRight, CSSColor.red, CSSColor.yellow, pct 10)
                            ])
                    ] []

                    div [
                            ClassName (fss
                                [
                                    Width' (px 200)
                                    Height' (px 200)
                                    //BackgroundImage (Image.LinearGradient [ Image.Right; hex "fffdc2"; hex "fffdc2"; pct 15; hex "d7f0a2"; pct 15; hex "d7f0a2"; pct 85; hex "fffdc2"; pct 85 ] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width' (px 200)
                                    Height' (px 200)
                                    //BackgroundImage (Image.RadialGradient [ Image.CircleAt [ Image.Top; Image.Right]; Color.yellow; hex "f06d06"] )
                                ])
                        ] []

                    div [
                            ClassName (fss
                                [
                                    Width' (px 200)
                                    Height' (px 200)
                                    //BackgroundImage (Image.RadialGradient [ Image.CircleAt [pct 100]; hex "333"; hex "333"; pct 50; hex "eee"; pct 75; hex "333"; pct 75] )
                                ])
                        ] []
                ]

            h3 [] [ str "And images!" ]
            div [
                ClassName (fss
                    [
                        Width' (px 200)
                        Height' (px 200)
                        BackgroundImage.Url "https://unsplash.it/200/200"
                    ])
            ] []

            let frameAnimation =
                keyframes
                    [
                        frame 0   [ BackgroundPosition.Values (px 0, px 0)]
                        frame 100 [ BackgroundPosition.Values (px -500, px 0)]
                    ]

            let frame =
                fss
                    [
                        Width' (px 50)
                        Height' (px 72)
                        BackgroundImage.Url "https://s.cdpn.io/79/sprite-steps.png"
                        AnimationName.Name frameAnimation
                        AnimationDuration' (sec 1.0)
                        AnimationTimingFunction.Step 10
                        AnimationIterationCount.Infinite
                    ]

            h3 [] [ str "Background images can be... fun?" ]
            div [ ClassName frame ] []

            let formStyle =
                fss
                    [
                        BorderStyle.Solid
                        BorderWidth' (px 1)
                        BorderColor.orangeRed
                        Margin' (px 20)
                    ]

            div [ ClassName (fss [ Display.Flex])]
                [

                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Background repeat" ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat BackgroundType.RepeatX)) ]
                                    str "Repeat-X"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat BackgroundType.RepeatY)) ]
                                    str "Repeat-Y"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat BackgroundType.Repeat)) ]
                                    str "Repeat"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat BackgroundType.Space)) ]
                                    str "Space"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat BackgroundType.Round)) ]
                                    str "Round"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBackgroundRepeat BackgroundType.NoRepeat)) ]
                                    str "NoRepeat"
                                ]
                        ]
                    ]
            div [ ClassName (fss
                    [
                        Width' (px 1025)
                        Height' (px 1025)
                        BackgroundImage.Url "https://interactive-examples.mdn.mozilla.net/media/examples/moon.jpg"
                        BackgroundRepeat' model.BackgroundRepeat
                    ])] []

                ]

let FontExamples () =
    fragment []
        [
            h1 [] [ str "fonts" ]
            h2 [] [ str "font-size"]
            p [ClassName (fss
                [
                    FontSize' (em 1.2)
                    FontFamily.SansSerif
                ])] [ str "1.2em sans serif" ]


            p [ClassName (fss
                [
                    FontStyle.Italic
                    FontVariantCaps.SmallCaps
                    FontWeight.Bold
                    FontSize' (px 16)
                    LineHeight' (px 2)
                    FontFamily.Cursive
            ])] [ str "italic small-caps bold 16px 2 line height cursive" ]



            h2 [] [ str "font-size"]
            p [ClassName (fss [FontSize.XxSmall])] [ str "Fonts can be xx-Small" ]
            p [ClassName (fss [FontSize.XSmall])] [ str "Fonts can be x-Small" ]
            p [ClassName (fss [FontSize.Small])] [ str "Fonts can be small" ]
            p [ClassName (fss [FontSize.Medium])] [ str "Fonts can be medium" ]
            p [ClassName (fss [FontSize.Large])] [ str "Fonts can be large" ]
            p [ClassName (fss [FontSize.XLarge])] [ str "Fonts can be x-large" ]
            p [ClassName (fss [FontSize.XxLarge])] [ str "Fonts can be xx-large" ]
            p [ClassName (fss [FontSize.XxxLarge])] [ str "Fonts can be xxx-large" ]
            p [ClassName (fss [FontSize.Smaller])] [ str "Fonts can be smaller" ]
            p [ClassName (fss [FontSize.Larger])] [ str "Fonts can be larger" ]

            p [ClassName (fss [FontSize' (px 28)])] [ str "Fonts can be set with pixels" ]
            p [ClassName (fss [FontSize' (pct 300)])] [ str "Fonts can be set with percent" ]
            p [ClassName (fss [FontSize' (em 2.5)])] [ str "Fonts can be set with ems" ]
            p [ClassName (fss [FontSize' (rem 3.0)])] [ str "Fonts can be set with rems" ]
            p [ClassName (fss [FontSize' (cm 3.3)])] [ str "Fonts can be set with cm" ]
            p [ClassName (fss [FontSize' (mm 33.3)])] [ str "Fonts can be set with mm" ]
            p [ClassName (fss [FontSize.Inherit])] [ str "Fonts can inherited" ]
            p [ClassName (fss [FontSize.Initial])] [ str "Fonts can initial" ]
            p [ClassName (fss [FontSize.Unset])] [ str "Fonts can unset" ]

            p [ ClassName (fss [FontFamily.Serif]) ] [ str "This font is serif!"]
            p [ ClassName (fss [FontFamily.SansSerif]) ] [ str "This font is sans-serif!"]
            p [ ClassName (fss [FontFamily.Monospace]) ] [ str "This font is monospace!"]
            p [ ClassName (fss [FontFamily.Cursive]) ] [ str "This font is cursive!"]
            p [ ClassName (fss
                    [
                        FontFamily.Values [ FontTypes.SansSerif; FontTypes.Custom "Helvetica" ]
                    ]) ] [ str "This should be helvetica sans-serif"]


            p [ ClassName (fss [FontStyle.Italic])]
                [
                    str "Italic"
                ]
            p [ ClassName (fss [FontStyle.Normal])]
                [
                    str "Normal"
                ]
            p [ ClassName (fss [ FontStyle.Oblique <| deg 90.0 ]) ]
                [
                    str "Oblique 90"
                ]
            p [ ClassName (fss [FontStyle.Oblique <| deg -90.0 ]) ]
                [
                    str "Oblique -90"
                ]

            p [ ClassName (fss [FontWeight.Bold ])]
                [
                    str "BOLD"
                ]

            p [ ClassName (fss [FontWeight' (CssInt 700) ])]
                [
                    str "BOLD"
                ]

            p [ ClassName (fss
                    [
                        Width' (px 150)
                        LineHeight.Normal
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width' (px 150)
                        LineHeight' (CssFloat 2.5)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width' (px 150)
                        LineHeight' (em 3.0)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width' (px 150)
                        LineHeight' (pct 150)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]

            p [ ClassName (fss
                    [
                        Width' (px 150)
                        LineHeight' (px 32)
                    ])]
                [
                    str """
                    Far out in the uncharted
                    backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun.
                    """
                ]
        ]

let FontFaceExamples () =
    let droidSerif =
        fontFaces "DroidSerif"
            [
                [
                    FontFace.Source <| UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf", FontFace.Truetype)
                    FontFace.Weight FontTypes.Bold
                    FontFace.Style Normal
                ]
                [
                    FontFace.Source <| UrlFormat ("https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf", FontFace.Truetype)
                    FontFace.Weight Normal
                    FontFace.Style Normal
                ]
            ]

    let moderna =
        fontFace "moderna"
            [
                FontFace.Sources
                    [
                        UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2", FontFace.Woff2)
                        UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff", FontFace.Woff)
                        UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FontFace.Truetype)
                        UrlFormat ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FontFace.Svg)
                    ]
                FontFace.Weight Normal
                FontFace.Style Normal
            ]

    let p1 =
        fss
            [
                FontFamily.Font droidSerif
            ]

    let p2 =
        fss
            [
                FontFamily.Font droidSerif
                FontWeight.Bold
            ]

    let p3 =
        fss
            [
                FontFamily.Font moderna
                FontWeight.Bold
            ]

    fragment []
        [
            h2 [] [ str "Font face examples" ]

            p [ ClassName p1 ]
                [
                    str "Why..."
                ]

            p [ ClassName p2 ]
                [
                    str "Hello there"
                ]

            p [ ClassName p3 ]
                [
                    str "Hello there"
                ]
        ]

let BorderExamples (model: Model) dispatch =
    fragment []
        [
            h1 [] [ str "borders"]
            h2 [] [ str "Set unique borders"]
            p [ ClassName (fss [BorderStyle.Solid ])] [ str "I have a solid border" ]
            p [ ClassName (fss [BorderStyle.Double ])] [ str "I have a double border"]
            p [ ClassName (fss [BorderStyle.Groove])] [ str "I have a groove border"]
            p [ ClassName (fss [BorderStyle.Inset])] [ str "I have an inset border"]
            p [ ClassName (fss [BorderStyle.Ridge])] [ str "I have a ridge border"]
            p [ ClassName (fss [BorderStyle.Dashed])] [ str "I have a dashed border"]
            p [ ClassName (fss [BorderStyle.Dotted])] [ str "I have a dotted border"]
            p [ ClassName (fss [BorderStyle.Outset])] [ str "I have an outset border"]
            p [ ClassName (fss [BorderStyle.Hidden])] [ str "I have a hidden border"]
            p [ ClassName (fss [BorderStyle.None])] [ str "I don't have a border"]
            p [ ClassName (fss [BorderStyle.Value(BorderType.Groove, BorderType.Dotted, BorderType.Solid, BorderType.Dashed)])] [ str "I have a mixed border"]
            p [] [ str "We can also apply only border width" ]
            p [ ClassName (fss
                    [
                        BorderWidth.Thin
                        BorderStyle.Solid
                    ])] [ str "I have a thin border" ]
            p [ ClassName (fss
                    [
                        BorderWidth' (px 3)
                        BorderStyle.Solid
                    ])] [ str "I have a 3px border" ]
            p [ ClassName (fss
                    [
                        BorderWidth.Value(px 3, px 4, px 5, px 6)
                        BorderStyle.Solid
                    ])] [ str "I have a mixed width border" ]
            p [ ClassName (fss [
                    BorderStyle.Double
                    BorderWidth.Thick
                    BorderColor.green
                ])] [ str "BorderStyles" ]
            p [ ClassName (fss
                    [
                        BorderStyle.Solid
                        BorderTopWidth' (px 10)
                    ])] [ str "top width" ]
            p [ ClassName (fss
                    [
                        BorderStyle.Solid
                        BorderRightWidth' (px 10)
                    ])] [ str "right width" ]
            p [ ClassName (fss
                    [
                        BorderStyle.Solid
                        BorderBottomWidth' (px 10)
                    ])] [ str "bottom width" ]
            p [ ClassName (fss
                    [
                        BorderStyle.Solid
                        BorderLeftWidth' (px 10)
                    ])] [ str "left width" ]
            p [ ClassName (fss
                    [
                        Color.white
                        BackgroundColor.purple
                        BorderRadius.Value(px 10, px (100 / 120))
                    ])] [ str "Border radius!"]
            p [ ClassName (fss
                    [
                        Color.yellowGreen
                        BackgroundColor.purple
                        BorderTopLeftRadius' (px 10)
                    ])] [ str "Top left Border radius!"]
            p [ ClassName (fss
                    [
                        BorderStyle.Solid
                        BorderWidth' (px 15)
                        BorderColor.Value(CSSColor.red, rgba 170 50 220 0.6, CSSColor.green)
                    ]
            )] [ str "Now in color!"]

            p [ ClassName (fss
                    [
                        BorderStyle.Dashed
                        BorderWidth' (px 15)
                        BorderTopWidth' (px 20)
                        BorderTopColor.deepPink
                        BorderBottomWidth' (px 1)
                        BorderLeftWidth' (px 10)
                        BorderRightWidth' (px 10)
                        BorderLeftColor.gold
                        BorderRightColor.rosyBrown
                    ]
            )] [ str "Now in color!"]

            let tableStyle =
                fss
                    [
                        Margin.Value (rem 2., Auto)
                        BorderStyle.Solid
                        BorderWidth' (px 1)
                        BorderColor.red
                        BorderCollapse.Separate
                        BorderSpacing' (rem 1.)
                        BackgroundColor.khaki
                    ]

            let theadStyle =
                fss
                    [
                        FontWeight.Value (CssInt 500)
                        BackgroundColor.white
                    ]

            let trStyle =
                fss
                    [
                        BackgroundColor.aquaMarine

                        ! Html.Th
                            [
                                BorderStyle.Solid
                                BorderWidth' (px 1)
                                BorderColor.red
                                BackgroundColor.goldenrod
                            ]
                    ]

            let tbodyStyle =
                fss
                    [
                        BackgroundColor.lime

                        ! Html.Tr
                            [
                                BackgroundColor.aquaMarine

                                NthChild Odd
                                    [
                                        BackgroundColor.gray
                                    ]
                            ]

                        ! Html.Td
                            [
                                BorderStyle.Solid
                                BorderWidth' (px 1)
                                BorderColor.red
                                Padding' (rem 1.0)
                            ]
                    ]

            table [ ClassName tableStyle ]
                [
                    thead [ ClassName theadStyle ]
                        [
                            tr [ ClassName trStyle ]
                                [
                                    th [] [ str "Heading" ]
                                    th [] [ str "Heading" ]
                                    th [] [ str "Heading" ]
                                ]
                        ]
                    tbody [ ClassName tbodyStyle ]
                        [
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                            tr []
                                [
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                  td [] [str "data" ]
                                ]
                        ]
                    ]

            h2 [] [ str "Border image" ]
            div  [
                ClassName (fss [
                    Width' (px 100)
                    Height' (px 100)
                    BorderWidth' (px 30)
                    BorderStyle.Solid
                    BorderImageSource.Url "https://interactive-examples.mdn.mozilla.net/media/examples/border-diamonds.png"
                    BorderImageWidth' (CssFloat 30.)
                ])
            ]
                []

            div [
                ClassName (fss [
                    Width' (rem 12.)
                    Height' (rem 12.)
                    MarginBottom' (rem 1.)
                    Padding' (rem 1.)
                    BorderWidth' (px 40)
                    BorderStyle.Solid
                    BorderImageSource.Url "https://mdn.mozillademos.org/files/4127/border.png"
                    BorderImageSlice' (BorderType.BorderImageSliceType.Value 27.)

                    let (first, optional) = model.BRepeat

                    match optional with
                        | Some b -> BorderImageRepeat.Value(first, b)
                        | Option.None -> BorderImageRepeat.Value first
                ])
            ]
                [
                    str "Pick something!"
                ]
            form [  ]
                [
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (BorderType.Stretch, Option.None))) ]
                            str "Stretch"
                        ]

                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (BorderType.Repeat, Option.None))) ]
                            str "Repeat"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (BorderType.Round, Option.None))) ]
                            str "Round"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (BorderType.Space, Option.None))) ]
                            str "Space"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (BorderType.Stretch, Some BorderType.Repeat))) ]
                            str "Stretch repeat"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetBorderImagerRepeat (BorderType.Space, Some BorderType.Round))) ]
                            str "Space round"
                        ]
                ]


            h2 [] [ str "Combining" ]
            let borderStuff =
                [
                    BorderWidth' (px 7)
                    BorderStyle.Solid
                ]

            let colorStuff =
                [
                    Color.orangeRed
                    yield! borderStuff
                    BackgroundColor.green
                    Height' (px 20)
                    Width' (px 200)
                ]

            let borderAndColorStyle = fss colorStuff

            div [ ClassName borderAndColorStyle ] [ str "I AM COOL?" ]
    ]

let MarginExamples () =
    fragment []
        [
            div [
                    ClassName
                        (fss
                            [
                                Width' (px 100)
                                Height' (px 100)
                                Color.orangeRed
                                BackgroundColor.rebeccaPurple
                                MarginRight' (px 50)
                                MarginLeft' (px 50)
                                MarginTop' (px 50)
                                MarginBottom' (px 50)
                            ])
                ]
                [ str "I have margin everywhere!" ]

            div [
                    ClassName
                        (fss
                            [
                                Width' (px 100)
                                Height' (px 100)
                                Color.orangeRed
                                BackgroundColor.rebeccaPurple
                                Margin.Value(px 100, px 50, px 200, px 150)
                            ])
                ]
                [ str "Me tooo!" ]
        ]

let PaddingExamples () =
    fragment []
        [
            div [
                    ClassName
                        (fss
                            [
                                Width' (px 100)
                                Height' (px 100)
                                Color.darkOrange
                                BackgroundColor.rebeccaPurple
                                PaddingRight' (px 50)
                                PaddingLeft' (px 50)
                                PaddingTop' (px 50)
                                PaddingBottom' (px 50)
                            ])
                ]
                [ str "I have padding everywhere!" ]

            div [
                    ClassName
                        (fss
                            [
                                Width' (px 100)
                                Height' (px 100)
                                Color.orangeRed
                                BackgroundColor.rebeccaPurple
                                Padding.Value (px 100, px 50, px 200, px 150)
                            ])
                ]
                [ str "Me tooo!" ]
        ]

let TransformExamples () =
    fragment []
        [
            h3 [] [ str "Transforms" ]
            div [
                ClassName
                    (fss
                        [
                            Width' (px 50)
                            Height' (px 50)
                            BackgroundColor.red
                            Transform.Skew(deg 30.0, deg 20.0)
                        ])
            ] []

            div [
                ClassName
                    (fss
                        [
                            Width' (px 50)
                            Height' (px 50)
                            BackgroundColor.orange
                            Transform.Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)
                        ])
            ] []

            div [
                ClassName
                    (fss
                        [
                            Width' (px 50)
                            Height' (px 50)
                            BackgroundColor.blue
                            Transform.Inherit
                        ])
            ] []

            let spinningAnimation =
                keyframes
                    [
                        frame 0 [ Transform.Rotate (deg 360.0) ]
                        frame 100 [ Transform.Rotate (deg 0.0) ]
                    ]

            let spinningCube =
                fss
                    [
                        Width' (px 100)
                        Height' (px 100)
                        BackgroundColor.orangeRed
                        AnimationName.Name spinningAnimation
                        AnimationDuration' (sec 2.0)
                        AnimationIterationCount.Infinite
                        AnimationTimingFunction.Linear

                    ]

            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Top, TransformType.Left) ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Top, TransformType.Center) ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Top, TransformType.Right) ]) )] []

            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Center, TransformType.Left) ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Center, TransformType.Center) ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Center, TransformType.Right) ]) )] []

            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Bottom, TransformType.Left) ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Bottom, TransformType.Center) ]) )] []
            div [ ClassName (sprintf "%s %s" spinningCube (fss [ TransformOrigin.Value (TransformType.Bottom, TransformType.Right) ]) )] []
        ]

let TransitionExamples () =
    let trigger =
        fss
            [
                Width' (px 200)
                Height' (px 200)
                BorderWidth' (px 20)
                BorderStyle.Solid
                BorderColor.Hex "ddd"
                Hover
                    [
                        ! Html.Div
                            [
                                Transform.Value
                                    [
                                        TransformType.Translate2(px 200, px 150) :> ITransform
                                        TransformType.Rotate(deg 20.0) :> ITransform
                                    ]
                            ]
                    ]

                ! Html.Div
                    [
                        Display.InlineBlock
                        BackgroundColor.pink
                        Width' (px 200)
                        Height' (px 200)
                        TransitionProperty.Transform
                        TransitionDuration' (ms 300.0)
                        TransitionTimingFunction.CubicBezier(0.0, 0.47, 0.32, 1.97)
                    ]
            ]

    fragment []
        [
            h2 [] [str "Transition shorthand"]
            let widthAndPosition =
                    [
                        Width' (pct 50)
                        Margin.Value (px 0, Auto, px 40)
                        Position.Relative
                        TransitionTimingFunction.EaseOut
                        TransitionDuration' (sec 0.5)
                    ]

            let shadow =
                [
                    Color.Hex "E39F81"
                    TextShadow.Value (px 1, px 1, px 1, hex "FFE3BD")
                    Hover
                        [
                            TextShadow.Value
                                [
                                    TextTypes.Shadow4(px 1, px 1, px 0, hex "FFE3BD")
                                    TextTypes.Shadow4(px 2, px 2, px 0, hex "FFE3BD")
                                    TextTypes.Shadow4(px 3, px 3, px 0, hex "FFE3BD")
                                    TextTypes.Shadow4(px 4, px 4, px 0, hex "FFE3BD")
                                    TextTypes.Shadow4(px 5, px 5, px 0, hex "FFE3BD")
                                ]
                        ]
                ] @ widthAndPosition
                |> fss

            let box =
                widthAndPosition @
                    [
                        BorderWidth' (px 5)
                        BorderStyle.Solid
                        BorderColor.transparent
                        Width' (px 200)
                        Height' (px 100)
                        Margin.Value (px 0, Auto)
                        Padding' (px 10)
                    ]

            let one =
                box @
                    [
                        BackgroundColor.Hex "B0CBC4"
                        Hover
                            [
                                BackgroundColor.Hex "F2EBD8"
                                BorderWidth' (px 5)
                                BorderStyle.Solid
                                BorderColor.Hex "B0CBC4"
                                BorderTopLeftRadius.Value (pct 100, px 20)
                                BorderBottomRightRadius.Value (pct 100, px 20)
                            ]
                    ] |> fss

            let box = box |> fss

            div [ ClassName shadow ]
                [
                    h2 [] [ str "Text-shadow" ]
                ]

            div [ ClassName one ]
                [
                    str "border-color, border-radius, background-color"
                ]

            h3 [] [str "Other transitions"]
            div [ ClassName trigger ]
                [
                    div [] []
                ]

            p [ClassName (fss [
                BackgroundColor.red
                TransitionProperty.BackgroundColor
                TransitionDuration' (sec 2.5)
                TransitionDelay' (sec 2.5)
                TransitionTimingFunction.Ease
                Hover
                    [
                        BackgroundColor.green
                    ]
            ])] [ str "I have a transition! Hover me!" ]
        ]

let TextExamples () =
    fragment []
        [
            let style =
                fss
                    [
                        Width' (px 200)
                        Height' (px 100)
                        TextAlign.Right
                    ]

            div [ ClassName style ]
                [
                    str "I am to the right"
                ]

            div [ ClassName (fss [ TextDecorationLine.Underline])] [str "Underline" ]
            div [ ClassName (fss [ TextDecorationLine.Overline])] [str "Overline" ]
            div [ ClassName (fss [ TextDecorationLine.LineThrough])] [str "Line-Through" ]
            div [ ClassName (fss [ TextDecorationLine.Value(TextTypes.Underline, TextTypes.Overline, TextTypes.LineThrough) ])] [str "This one has all three" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine.Value(TextTypes.Underline, TextTypes.Overline, TextTypes.LineThrough)
                        TextDecorationColor.orangeRed
                    ]
                )] [str "This one has all three and are red" ]


            div [ ClassName (fss
                    [
                        TextDecorationLine.Underline
                        TextDecorationColor.red
                        TextDecorationThickness.FromFont
                    ])] [str "Thickness from font" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine.Underline
                        TextDecorationColor.red
                        TextDecorationThickness.Auto
                    ])] [str "Thickness from auto" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine.Underline
                        TextDecorationColor.red
                        TextDecorationThickness' (pct 100)
                    ])] [str "Thickness from percent" ]

            div [ ClassName (fss
                    [
                        TextDecorationLine.Underline
                        TextDecorationColor.red
                        TextDecorationThickness' (px 1)
                    ])] [str "Thickness from pixels" ]

            div [ ClassName (fss [ TextDecorationLine.Underline; TextDecorationStyle.Solid])] [str "Solid" ]
            div [ ClassName (fss [ TextDecorationLine.Underline; TextDecorationStyle.Double])] [str "Double" ]
            div [ ClassName (fss [ TextDecorationLine.Underline; TextDecorationStyle.Dotted])] [str "Dotted" ]
            div [ ClassName (fss [ TextDecorationLine.Underline; TextDecorationStyle.Dashed])] [str "Dashed" ]
            div [ ClassName (fss [ TextDecorationLine.Underline; TextDecorationStyle.Wavy])] [str "Wavy" ]

            div [ ClassName (fss [ TextTransform.Capitalize ])] [str "capitalize" ]
            div [ ClassName (fss [ TextTransform.Uppercase ])] [str "uppercase" ]
            div [ ClassName (fss [ TextTransform.Lowercase ])] [str "LOWERCASE" ]
            div [ ClassName (fss [ TextTransform.None ])] [str "NoNE" ]
            div [ ClassName (fss [ TextTransform.FullWidth ])] [str "FullWidth" ]
            div [ ClassName (fss [ TextTransform.FullSizeKana ])] [str "FullSizeKana" ]

            div [ ClassName (fss [ Width' (px 200); TextIndent' (px 10)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width' (px 200); TextIndent' (pct 10)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width' (px 200); TextIndent' (pct -10)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width' (px 200); TextIndent.Value(pct 10, TextTypes.EachLine)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]
            div [ ClassName (fss [ Width' (px 200); TextIndent.Value(pct 10, TextTypes.Hanging)])] [str "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt."]

            let simple =
                fss
                    [
                        TextAlign.Center
                        FontWeight.Bold
                        FontSize' (px 80)
                        FontFamily.SansSerif
                        BackgroundColor.Hex "91877b"
                        TextShadow.Value (px 0, px 1, px 0, rgba 255 255  255 0.4)
                    ]

            h1 [ ClassName simple ] [ str "Monster Mash" ]

            let otto =
                fss
                    [
                        TextAlign.Center
                        FontWeight.Bold
                        FontSize' (px 80)
                        FontFamily.SansSerif
                        BackgroundColor.Hex "0e8dbc"
                        Color.white
                        Height' (px 100)
                        TextShadow.Value
                            [
                                TextTypes.Shadow4 (px 0, px  1, px 0, hex "ccc")
                                TextTypes.Shadow4 (px 0, px  2, px 0, hex "#c9c9c9")
                                TextTypes.Shadow4 (px 0, px  3, px 0,  hex "#bbb")
                                TextTypes.Shadow4 (px 0, px  4, px 0, hex "#b9b9b9")
                                TextTypes.Shadow4 (px 0, px  5, px 0, hex "#aaa")
                                TextTypes.Shadow4 (px 0, px  6, px 1, rgba 0 0 0 0.1)
                                TextTypes.Shadow4 (px 0, px  0, px 1, rgba 0 0 0 0.1)
                                TextTypes.Shadow4 (px 0, px  1, px 1, rgba 0 0 0 0.3)
                                TextTypes.Shadow4 (px 0, px  3, px 1, rgba 0 0 0 0.2)
                                TextTypes.Shadow4 (px 0, px  5, px 1, rgba 0 0 0 0.25)
                                TextTypes.Shadow4 (px 0, px 10, px 1, rgba 0 0 0 0.2)
                                TextTypes.Shadow4 (px 0, px 20, px 1, rgba 0 0 0 0.15)
                            ]
                    ]

            h1 [ ClassName otto ] [ str "Slippery Slime" ]

            let close =
                fss
                    [
                        TextAlign.Center
                        FontWeight.Bold
                        FontSize' (px 80)
                        FontFamily.SansSerif
                        BackgroundColor.Hex "3a50d9"
                        Color.Hex "e0eff2"
                        Height' (px 100)
                        TextShadow.Value
                            [
                                TextTypes.Shadow4 (px  -4, px 3, px 0, hex "#3a50d9")
                                TextTypes.Shadow4 (px -14, px 7, px 0, hex "#0a0e27")
                            ]
                    ]

            h1 [ ClassName close ] [ str "Mummy mummy" ]

            let printers =
                fss
                    [
                        TextAlign.Center
                        FontWeight.Bold
                        FontSize' (px 80)
                        FontFamily.SansSerif
                        BackgroundColor.Hex "edde9c"
                        Color.Hex "bc2e1e"
                        Height' (px 100)
                        TextShadow.Value
                            [
                                TextTypes.Shadow4 (px 0, px 1, px 0, hex "#378ab4")
                                TextTypes.Shadow4 (px 1, px 0, px 0, hex "#5dabcd")
                                TextTypes.Shadow4 (px 1, px 2, px 1, hex "#378ab4")
                                TextTypes.Shadow4 (px 2, px 1, px 1, hex "#5dabcd")
                                TextTypes.Shadow4 (px 2, px 3, px 2, hex "#378ab4")
                                TextTypes.Shadow4 (px 3, px 2, px 2, hex "#5dabcd")
                                TextTypes.Shadow4 (px 3, px 4, px 2, hex "#378ab4")
                                TextTypes.Shadow4 (px 4, px 3, px 3, hex "#5dabcd")
                                TextTypes.Shadow4 (px 4, px 5, px 3, hex "#378ab4")
                                TextTypes.Shadow4 (px 5, px 4, px 2, hex "#5dabcd")
                                TextTypes.Shadow4 (px 5, px 6, px 2, hex "#378ab4")
                                TextTypes.Shadow4 (px 6, px 5, px 2, hex "#5dabcd")
                                TextTypes.Shadow4 (px 6, px 7, px 1, hex "#378ab4")
                                TextTypes.Shadow4 (px 7, px 6, px 1, hex "#5dabcd")
                                TextTypes.Shadow4 (px 7, px 8, px 0, hex "#378ab4")
                                TextTypes.Shadow4 (px 8, px 7, px 0, hex "#5dabcd")
                            ]
                    ]

            h1 [ ClassName printers ] [ str "Skeleton crew" ]

            let vamp =
                fss
                    [
                        TextAlign.Center
                        FontWeight.Bold
                        FontSize' (px 80)
                        FontFamily.SansSerif
                        BackgroundColor.red
                        Color.Hex "92a5de"
                        Height' (px 100)
                        TextShadow.Value
                            [
                                TextTypes.Shadow4(px  0, px  0, px  0, rgb 137 156 213)
                                TextTypes.Shadow4(px  1, px  1, px  0, rgb 129 148 205)
                                TextTypes.Shadow4(px  2, px  2, px  0, rgb 120 139 196)
                                TextTypes.Shadow4(px  3, px  3, px  0, rgb 111 130 187)
                                TextTypes.Shadow4(px  4, px  4, px  0, rgb 103 122 179)
                                TextTypes.Shadow4(px  5, px  5, px  0, rgb 94  113 170)
                                TextTypes.Shadow4(px  6, px  6, px  0, rgb 85  104 161)
                                TextTypes.Shadow4(px  7, px  7, px  0, rgb 76   95 152)
                                TextTypes.Shadow4(px  8, px  8, px  0, rgb 68   87 144)
                                TextTypes.Shadow4(px  9, px  9, px  0, rgb 59   78 135)
                                TextTypes.Shadow4(px 10, px 10, px  0, rgb 50   69 126)
                                TextTypes.Shadow4(px 11, px 11, px  0, rgb 42   61 118)
                                TextTypes.Shadow4(px 12, px 12, px  0, rgb 33   52 109)
                                TextTypes.Shadow4(px 13, px 13, px  0, rgb 24   43 100)
                                TextTypes.Shadow4(px 14, px 14, px  0, rgb 15   34  91)
                                TextTypes.Shadow4(px 15, px 15, px  0, rgb 7    26  83)
                                TextTypes.Shadow4(px 16, px 16, px  0, rgb -2   17  74)
                                TextTypes.Shadow4(px 17, px 17, px  0, rgb -11   8  65)
                                TextTypes.Shadow4(px 18, px 18, px  0, rgb -19   0  57)
                                TextTypes.Shadow4(px 19, px 19, px  0, rgb -28  -9  48)
                                TextTypes.Shadow4(px 20, px 20, px  0, rgb -37 -18  39)
                                TextTypes.Shadow4(px 21, px 21, px 20, rgba 0    0   0 1.0)
                                TextTypes.Shadow4(px 21, px 21, px  1, rgba 0    0   0 0.5)
                                TextTypes.Shadow4(px  0, px  0, px 20, rgba 0    0   0 0.2)
                            ]
                    ]

            h1 [ ClassName vamp ] [ str "Vampire Diaries" ]
        ]

let AnimationExamples () =
    let bounceFrames =
        keyframes
            [
                frames [ 0; 20; 53; 80; 100 ]
                    [
                        Transform.Translate3D(px 0, px 0, px 0)
                        BackgroundColor.red
                    ]
                frames [40; 43]
                    [
                        Transform.Translate3D(px 0, px -30, px 0)
                        BackgroundColor.blue
                    ]
                frame 70
                    [
                        Transform.Translate3D(px 0, px -15, px 0)
                        BackgroundColor.green
                    ]
                frame 90
                    [
                        Transform.Translate3D(px 0, px -4, px 0)
                        BackgroundColor.orange
                    ]
        ]

    let bounceAnimation =
        fss
            [
                AnimationName.Name bounceFrames
                AnimationDuration' (sec 1.0)
                AnimationTimingFunction.EaseInOut
                AnimationIterationCount.Infinite
            ]
    let stretch =
        fss
            [
                Height' (px 250)
                Width' (px 250)
                MarginTop' (px 0)
                MarginBottom' (px 0)
                MarginLeft.Auto
                MarginRight.Auto
                BackgroundColor.red
                AnimationDuration' (sec 1.5)
                AnimationTimingFunction.EaseOut
                AnimationDelay' (sec 0.0)
                AnimationDirection.Alternate
                AnimationIterationCount.Infinite
                AnimationFillMode.None
                AnimationPlayState.Running
                AnimationName.Name (keyframes
                                       [
                                           frame 0
                                               [
                                                   Transform.Scale 0.3
                                                   BackgroundColor.red
                                                   BorderRadius.Value (pct 100)
                                               ]
                                           frame 50
                                               [
                                                   BackgroundColor.orange
                                               ]
                                           frame 100
                                               [
                                                    Transform.Scale 1.5
                                                    BackgroundColor.yellow
                                               ]
                                       ])
            ]

    let sizeFrames =
        keyframes
            [
                frame 0 [ FontSize' (pct 50) ]
                frame 50 [ FontSize' (pct 150) ]
                frame 100 [ FontSize' (pct 50) ]
            ]

    let spinnyFrames =
        keyframes
            [
                frame 0 [ Transform.Rotate(deg 0.0)]
                frame 100 [ Transform.Rotate(deg 360.0)]
            ]

    let sizeAnimation =
        fss
            [
                AnimationName.Name sizeFrames
                AnimationDuration' (sec 3.0)
                AnimationTimingFunction.EaseInOut
                AnimationIterationCount' (CssInt 3)
            ]

    let combinedAnimations =
        fss
            [
                AnimationName.Names [ bounceFrames; sizeFrames ]
                AnimationDuration.Values [ sec 1.0; sec 3.0 ]
                AnimationTimingFunction.Values [ TimingFunctionType.EaseInOut; TimingFunctionType.Ease ]
                AnimationIterationCount.Values [ CssInt 3; AnimationType.Infinite ]
            ]

    let spinnyMation =
        fss
            [
                Width' (px 200)
                Height' (px 200)
                BackgroundColor.orangeRed
                AnimationName.Name spinnyFrames
                AnimationDuration' (sec 5.0)
                AnimationIterationCount.Infinite
                AnimationTimingFunction.Linear
            ]
    let loader =
        keyframes
            [
                frame 0 [ Transform.Value [ TransformType.RotateX(deg 0.0) :> ITransform; TransformType.RotateY(deg 0.0) :> ITransform ] ]
                frame 50 [ Transform.Value [ TransformType.RotateX(deg 0.0) :> ITransform; TransformType.RotateY(deg 180.0) :> ITransform] ]
                frame 100 [ Transform.Value [ TransformType.RotateX(deg 180.0) :> ITransform; TransformType.RotateY(deg 180.0) :> ITransform ] ]
            ]

    let loaderParent =
        fss
            [
                Height' (px 200)
                Width' (px 200)
                Display.Flex
                JustifyContent.Center
                AlignItems.Center
                BackgroundColor.Hex "272727"
                Perspective' (px 200)
            ]

    let loaderContainer =
        fss
            [
                Width' (px 100)
                Height' (px 100)
                BorderRadius' (px 12)
                BackgroundColor.Hex "00dbde"
                AnimationName.Name loader
                AnimationDuration' (sec 2.0)
                AnimationTimingFunction.Linear
                AnimationIterationCount.Infinite
            ]

    fragment []
        [
            p [] [ str "Things can animate now!" ]
            div [ ClassName stretch ] []
            p [ClassName bounceAnimation] [str "Bouncing text"]
            p [ClassName sizeAnimation] [str "Weeeeeeeeee"]
            p [ClassName combinedAnimations] [str "COMBINED"]
            div [ ClassName spinnyMation ] []
            div [ ClassName loaderParent]
                [
                    div [ ClassName loaderContainer ] []
                ]
        ]
let FlexBoxExamples model dispatch =
    // Set display to None
    let foo =
        fss
            [
                Display.None
            ]

    // Test alignment
    let parent =
        fss
            [
                Display.Flex
                Height' (px 300)
                BackgroundColor.grey
            ]

    let child =
        fss
            [
                Width' (px 100)
                Height' (px 100)
                Margin.Auto
                BackgroundColor.lightCoral
            ]

    let alignment =
        div [ ClassName parent]
             [
                div [ ClassName child] []
             ]

    // Test Flex flow property
    let parent =
        fss
            [
                Display.Flex
                FlexDirection.Row
                FlexWrap.Wrap
                JustifyContent.SpaceAround
            ]

    let child =
        fss
            [
                BackgroundColor.tomato
                Width' (px 200)
                Height' (px 150)
                MarginTop' (px 10)
            ]

    let flow =
        div [ ClassName parent]
             [
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
                 div [ ClassName child] []
             ]

    // Flex Direction row
    let parent =
        fss
            [
                Display.Flex
                FlexDirection.Row
            ]

    let child =
        fss
            [
                BackgroundColor.tomato
                Width' (px 50)
                Height' (px 50)
                MarginLeft'  (px 10)
            ]


    let rows =
        div [ ClassName parent]
                [
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                ]

    // Flex Direction column
    let parent =
        fss
            [
                Display.Flex
                FlexDirection.Column
            ]

    let child =
        fss
            [
                BackgroundColor.tomato
                Width' (px 50)
                Height' (px 50)
                MarginTop' (px 10)
            ]

    let columns =
        div [ ClassName parent]
                [
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                    div [ ClassName child] []
                ]

    // Flex no wrap
    let parent =
        fss
            [
                Display.Flex
                Width' (em 40.0)
                FlexWrap.NoWrap
            ]

    let child =
        fss
            [
                BackgroundColor.Hex "#cee"
                Width' (em 15.0)
                Margin' (px 10)
            ]

    let noWrap =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex no wrap
    let parent =
        fss
            [
                Display.Flex
                Width' (em 40.0)
                FlexWrap.Wrap
            ]

    let child =
        fss
            [
                BackgroundColor.Hex "#cee"
                Width' (em 15.0)
                Margin' (px 10)
            ]

    let wrap =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex no wrap
    let parent =
        fss
            [
                Display.Flex
                Width' (em 40.0)
                FlexWrap.WrapReverse
            ]

    let child =
        fss
            [
                BackgroundColor.Hex "#cee"
                Width' (em 15.0)
                Margin' (px 10)
            ]

    let wrapReverse =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                ]

    // Flex flow
    let parent =
        fss
            [
                BackgroundColor.pink
                Margin.Value (px 48, Auto, px 0)
                Width' (px 600)
                Display.Flex
                FlexDirection' model.FlexDirection
                FlexWrap' model.FlexWrap
            ]

    let child =
        fss
            [
                BackgroundColor.black
                Color.white
                Margin' (px 6)
                Width' (px 120)
            ]

    let flexFlow =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                    div [ ClassName child] [ str "5" ]
                    div [ ClassName child] [ str "6" ]
                    div [ ClassName child] [ str "7" ]
                ]

    // AlignContent
    let parent =
        fss
            [
                BackgroundColor.Hex "ccc"
                Display.Flex
                FlexWrap.Wrap
                Width' (pct 100)
                Height' (em 20.0)
                AlignContent' model.AlignContent
            ]

    let child =
        fss
            [
                BackgroundColor.Hex "cee"
                Margin' (px 2)
                Width' (pct 18)
            ]

    let alignContent =
        div [ ClassName parent]
                [
                    div [ ClassName child] [ str "1" ]
                    div [ ClassName child] [ str "2" ]
                    div [ ClassName child] [ str "3" ]
                    div [ ClassName child] [ str "4" ]
                    div [ ClassName child] [ str "5" ]
                    div [ ClassName child] [ str "6" ]
                    div [ ClassName child] [ str "7" ]
                ]

    // Flex-basis & flex grow
    let parent =
        fss
            [
                BackgroundColor.Hex "ccc"
                Height' (px 100)
                Display.Flex
                FlexDirection.Row
                AlignItems.Center
            ]

    let child =
        fss
            [
                Margin.Value (px 0, px 10)
                BackgroundColor.white
                FlexBasis' (px 120)
                FlexGrow' (CssFloat 1.5)
                Height' (px 75)
            ]

    let child3 =
        fss
            [
                Margin.Value (px 0, px 10)
                BackgroundColor.white
                FlexBasis' (px 120)
                FlexGrow' (CssFloat 2.)
                Height' (px 75)
            ]

    let flexBasisGrow =
        div [ ClassName parent]
            [
                div [ ClassName child ] []
                div [ ClassName child ] []
                div [ ClassName child3 ] []
            ]

    // Flex-basis & flex shrink
    let parent =
        fss
            [
                BackgroundColor.Hex "ccc"
                Height' (px 100)
                Display.Flex
                FlexDirection.Row
                AlignItems.Center
            ]

    let child =
        fss
            [
                Margin.Value (px 0, px 10)
                BackgroundColor.white
                FlexBasis' (px 120)
                FlexGrow' (CssFloat 1.)
                Height' (px 75)
            ]

    let child3 =
        fss
            [
                Margin.Value (px 0, px 10)
                BackgroundColor.white
                FlexBasis' (px 120)
                FlexShrink' (CssFloat 2.)
                Height' (px 75)
            ]

    let flexBasisShrink =
        div [ ClassName parent]
            [
                div [ ClassName child ] []
                div [ ClassName child ] []
                div [ ClassName child3 ] []
            ]


    let formStyle =
        fss
            [
                BorderStyle.Solid
                BorderWidth' (px 1)
                BorderColor.orangeRed
                Margin' (px 20)
            ]

    fragment []
        [
            p [] [ str "I am aligend with flexbox" ]
            alignment
            p [] [ str "We are evenly distributed! Just try resizing" ]
            flow
            p [] [ str "Flex direction is row!" ]
            rows
            p [] [ str "Flex direction is columns!" ]
            columns
            p [] [ str "Flex wrap is no wrap!" ]
            noWrap
            p [] [ str "Flex wrap is wrap!" ]
            wrap
            p [] [ str "Flex wrap is wrapreverse!" ]
            wrapReverse
            p [] [ str "Flex flow" ]
            div [ ClassName (fss [ Display.Flex ]) ]
                [
                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Flex direction" ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection FlexType.Row)) ]
                                    str "row"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection FlexType.RowReverse)) ]
                                    str "row-reverse"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection FlexType.Column)) ]
                                    str "column"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexDirection FlexType.ColumnReverse)) ]
                                    str "column-reverse"
                                ]
                        ]
                    form [ ClassName formStyle ]
                        [
                            h3 [] [str "Flex wrap" ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap FlexType.NoWrap)) ]
                                    str "nowrap"
                                ]

                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap FlexType.Wrap)) ]
                                    str "wrap"
                                ]
                            div []
                                [
                                    input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetFlexWrap FlexType.WrapReverse)) ]
                                    str "wrap-reverse"
                                ]
                        ]
                ]
            flexFlow
            p [] [ str "Align content" ]
            form [ ClassName formStyle ]
                [
                    h3 [] [str "Align content" ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexType.FlexStart)) ]
                            str "FlexStart"
                        ]

                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexType.FlexEnd)) ]
                            str "FlexEnd"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexType.Center)) ]
                            str "Center"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexType.Stretch)) ]
                            str "Stretch(default)"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexType.SpaceBetween)) ]
                            str "SpaceBetween"
                        ]
                    div []
                        [
                            input [ Type "radio"; HTMLAttr.Name "row"; OnChange (fun _ -> dispatch (SetAlignContent FlexType.SpaceAround)) ]
                            str "SpaceAround"
                        ]
                ]
            alignContent
            p [] [str "Flex basis & grow" ]
            flexBasisGrow
            p [] [str "Flex basis & shrink" ]
            flexBasisShrink
        ]

let MediaQueryExamples () =
   let style =
        fss
            [
                Width' (px 200)
                Height' (px 200)
                BackgroundColor.blue
                MediaQuery
                    [ Media.MaxWidth (px 500); Media.MinWidth (px 200) ]
                    [ BackgroundColor.red ]

                MediaQuery
                    [ Media.MinHeight (px 700)]
                    [ BackgroundColor.pink]

                MediaQueryFor Media.Print
                    []
                    [
                        MarginTop' (px 200)
                        Transform.Rotate(deg 45.0)
                        BackgroundColor.red
                    ]

                MediaQuery
                    [ Media.Orientation Media.Landscape]
                    [ Color.green; FontSize.Value (px 28)]
            ]
   div [ ClassName style] [ str "foosball"]
let SelectorExamples () =
    fragment []
        [
            h2 [] [ str "Selectors" ]
            let descendant =
                fss
                    [
                        ! Html.P
                            [
                                BackgroundColor.red
                            ]
                    ]
            h3 [] [ str "Descendant" ]
            div [ ClassName descendant] [
                p [] [ str "Apple"]
                div [] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let child =
                fss
                    [
                        !> Html.P
                            [
                                BackgroundColor.green
                            ]
                    ]
            h3 [] [ str "Child" ]
            div [ ClassName child] [
                p [] [ str "Apple"]
                div [] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let adjacentSibling =
                fss
                    [
                        !+ Html.P
                            [
                                BackgroundColor.yellow
                            ]
                    ]
            h3 [] [ str "Adjacent Sibling" ]
            div [] [
                p [] [ str "Apple"]
                div [ ClassName adjacentSibling ] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let generalSibling =
                fss
                    [
                        !~ Html.P
                            [
                                BackgroundColor.orangeRed
                            ]
                    ]
            h3 [] [ str "General Sibling" ]
            div [] [
                p [] [ str "Apple"]
                div [ ClassName generalSibling ] [ p [] [str "An apple a day keeps the doctor away"]]
                p [] [ str "Banana"]
                p [] [ str "Cherry"]
            ]

            let composed =
                fss
                    [
                        ! Html.Div
                            [
                                !> Html.Div
                                    [
                                        !> Html.P
                                            [
                                                !+ Html.P
                                                    [
                                                        Color.purple
                                                        FontSize' (px 25)
                                                    ]
                                            ]
                                    ]

                            ]
                    ]

            h3 [] [ str "Composed" ]
            div [ ClassName composed ]
                [
                    div []
                        [
                            div []
                                [
                                    p [] [ str "Hi" ]
                                    // Skal bli lilla og 25 px
                                    p [] [ str "Hi" ]
                                ]
                        ]
                ]
        ]
let CursorExamples () =
    let testo (x: ICursor) =
       div
            [
                ClassName ( fss
                    [
                        Width' (px 100)
                        Height' (px 100)
                        BackgroundColor.blue
                        Cursor' x
                        BorderStyle.Solid
                        BorderWidth' (px 5)
                    ])
            ]
        []

    div [
        ClassName ( fss
                   [
                        Display.Flex
                        FlexDirection.Row
                        FlexWrap.Wrap
                   ])
        ]
        [
            h2 [] [ str "Cursors" ]
            testo (CursorTypes.Default)
            testo (CursorTypes.ContextMenu)
            testo (CursorTypes.Help)
            testo (CursorTypes.Pointer)
            testo (CursorTypes.Progress)
            testo (CursorTypes.Wait)
            testo (CursorTypes.Cell)
            testo (CursorTypes.Crosshair)
            testo (CursorTypes.Text)
            testo (CursorTypes.VerticalText)
            testo (CursorTypes.Alias)
            testo (CursorTypes.Copy)
            testo (CursorTypes.Move)
            testo (CursorTypes.NoDrop)
            testo (CursorTypes.NotAllowed)
            testo (CursorTypes.AllScroll)
            testo (CursorTypes.ColResize)
            testo (CursorTypes.RowResize)
            testo (CursorTypes.NResize)
            testo (CursorTypes.EResize)
            testo (CursorTypes.SResize)
            testo (CursorTypes.WResize)
            testo (CursorTypes.NsResize)
            testo (CursorTypes.EwResize)
            testo (CursorTypes.NeResize)
            testo (CursorTypes.NwResize)
            testo (CursorTypes.SeResize)
            testo (CursorTypes.SwResize)
            testo (CursorTypes.NeswResize)
            testo (CursorTypes.NwseResize)
        ]
let PsuedoClassExamples () =
    fragment []
        [
            h2 [] [ str "Psuedo selectors" ]

            let active =
                fss
                    [
                        Active
                            [
                                Width' (px 200)
                                Height' (px 200)
                            ]
                    ]

            div []
                [
                    str "Active"
                    button [ ClassName active  ] [ str "Activate!" ]
                ]

            let anyLink =
                fss
                    [
                        AnyLink
                            [
                                Color.orangeRed
                            ]
                    ]

            div []
                [
                    str "Any link"
                    br []
                    a [ ClassName anyLink; Href "#" ] [ str "This is a link!" ]
                ]

            str "Empty"
            let empty =
                fss
                    [
                        Width' (px 80)
                        Height' (px 80)
                        BackgroundColor.pink
                        Empty
                            [
                                BackgroundColor.lime
                            ]
                    ]

            div [ ClassName empty ] [ str "Not empty" ]
            div [ ClassName empty ] []
            div [ ClassName empty ] [ str "Not empty" ]

            let disabled =
                fss
                    [
                        BackgroundColor.red
                        Disabled
                            [
                                BackgroundColor.blue
                            ]
                    ]

            str "Disabled is blue"
            div []
                [
                    input [ ClassName disabled ]
                    input [ ClassName disabled; HTMLAttr.Disabled true]
                ]

            let checkedStyle =
                fss
                    [
                        Checked
                            [
                                Width' (px 100)
                                Height' (px 100)
                            ]
                    ]

            str "Checked"
            div []
                [
                    input [ ClassName checkedStyle; Type "checkbox"; HTMLAttr.Checked true ]
                    input [ ClassName checkedStyle; Type "checkbox" ]
                ]

            let enabled =
                fss
                    [
                        BackgroundColor.white
                        Enabled
                            [
                                BackgroundColor.red
                            ]
                    ]

            str "Enabled is blue"
            div []
                [
                    input [ ClassName enabled ]
                    input [ ClassName enabled; HTMLAttr.Disabled true ]
                ]

            let firstChild =
                fss
                    [
                        FirstChild
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "First child"
            div []
                [
                    p [ ClassName firstChild ] [ str "Orange" ]
                    p [ ClassName firstChild ] [ str "Not orange" ]
                    p [ ClassName firstChild ] [ str "Not orange" ]
                ]

            let firstOfType =
                fss
                    [
                        FirstOfType
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "First of type"
            div []
                [
                    p [ ClassName firstOfType ] [ str "Orange" ]
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    span [ ClassName firstOfType ] [ str "Orange" ]
                    span [ ClassName firstOfType ] [ str "Not orange" ]
                ]

            let focus =
                fss
                    [
                        Focus
                            [
                                BackgroundColor.red
                            ]
                    ]

            str "Focus"
            div [ ClassName (fss [Display.Flex; FlexDirection.Column; Width' (px 100)]) ]
                [
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                    input [ ClassName focus ]
                ]

            let visited =
                fss
                    [
                        Visited
                            [
                                Color.orangeRed
                            ]
                    ]

            str "Visited"
            div [ ClassName (fss [Display.Flex; FlexDirection.Column; Width' (px 100)]) ]
                [
                    a [ Href "#"; ClassName visited ] [ str "visited" ]
                    a [ Href "foo"; ClassName visited ] [ str "not visited" ]
                ]

            str "Invalid"

            let invalid =
                fss
                    [
                        Invalid
                            [
                                BackgroundColor.red
                            ]
                    ]


            div [ ClassName (fss [Display.Flex; FlexDirection.Column; Width' (px 100)]) ]
                [
                    input [ ClassName invalid ]
                    input [ ClassName invalid; HTMLAttr.Required true ]
                ]

            str "Last child"

            let LastChild =
                fss
                    [
                        LastChild
                            [
                                BackgroundColor.orange
                            ]
                    ]

            div []
                [
                    p [ ClassName LastChild ] [ str "Not orange" ]
                    p [ ClassName LastChild ] [ str "Not orange" ]
                    p [ ClassName LastChild ] [ str "Orange" ]
                ]

            let firstOfType =
                fss
                    [
                        LastOfType
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "First of type"
            div []
                [
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    p [ ClassName firstOfType ] [ str "Not orange" ]
                    span [ ClassName firstOfType ] [ str "Not orange" ]
                    span [ ClassName firstOfType ] [ str "Orange" ]
                    p [ ClassName firstOfType ] [ str "Orange" ]
                ]

            let link =
                fss
                    [
                        Link
                            [
                                Color.darkRed
                            ]
                    ]

            div []
                [
                    str "Link"
                    br []
                    a [ ClassName link; Href "notVisited" ] [ str "This is a link!" ]
                ]

            let nthChild =
                fss
                    [
                        NthChild (CssInt 2)
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "Nth child 2"
            div []
                [
                    p [ ClassName nthChild ] [ str "Not orange" ]
                    p [ ClassName nthChild ] [ str "Orange" ]
                    span [ ClassName nthChild ] [ str "Not orange" ]
                    span [ ClassName nthChild ] [ str "Not orange" ]
                    p [ ClassName nthChild ] [ str "Not orange" ]
                ]

            let nthLastChild =
                fss
                    [
                        NthLastChild  "2"
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "Nth last child 2"
            div []
                [
                    p [ ClassName nthLastChild ] [ str "Not orange" ]
                    p [ ClassName nthLastChild ] [ str "Not orange" ]
                    span [ ClassName nthLastChild ] [ str "Not orange" ]
                    span [ ClassName nthLastChild ] [ str "Orange" ]
                    p [ ClassName nthLastChild ] [ str "Not orange" ]
                ]

            let onlyChild =
                fss
                    [
                        OnlyChild
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "Only child"
            div []
                [
                    span [ ClassName onlyChild ] [ str "Orange" ]
                ]
            div []
                [
                    div [ ClassName onlyChild ] [ str "Not orange" ]
                    div [ ClassName onlyChild ] [ str "Not orange" ]
                ]


            let onlyOfType =
                fss
                    [
                        OnlyOfType
                            [
                                BackgroundColor.orange
                            ]
                    ]

            str "Only of type"
            div []
                [
                    span [ ClassName onlyOfType ] [ str "Orange" ]
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                ]
            div []
                [
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                    div [ ClassName onlyOfType ] [ str "Not orange" ]
                ]


            str "Target"
            let target =
                fss
                    [
                        Target [
                            BackgroundColor.darkBlue
                        ]
                    ]

            section [ Id "section2"; ClassName target ]
                [
                    h3 [] [ str "Foo" ]
                    p [] [ str "Foofoffoo" ]
                    a [ Href "#section2" ] [ str "Go to section 2" ]
                ]
        ]
let ListStyleExamples () =
    fragment []
        [
            let listStyleImage =
                fss
                    [
                        ListStyleImage.Url "https://mdn.mozillademos.org/files/11981/starsolid.gif"
                    ]

            ul [ ClassName listStyleImage ]
                [
                    li [] [ str "Item 1" ]
                    li [] [ str "Item 2" ]
                ]

            let inside =
                fss
                    [
                        ListStylePosition.Inside
                        ListStyleType.Square
                    ]

            let outside =
                fss
                    [
                        ListStylePosition.Outside
                        ListStyleType.Circle
                    ]

            let insideImage =
                fss
                    [
                        ListStylePosition.Inside
                        ListStyleImage.Url "https://mdn.mozillademos.org/files/11979/starsolid.gif"
                    ]

            ul [ ClassName inside ]
                [
                    str "List 1"
                    li [] [str "List Item 1-1" ]
                    li [] [str "List Item 1-2" ]
                    li [] [str "List Item 1-3" ]
                    li [] [str "List Item 1-4" ]
                ]
            ul [ ClassName outside ]
                [
                    str "List 2"
                    li [] [str "List Item 2-1" ]
                    li [] [str "List Item 2-2" ]
                    li [] [str "List Item 2-3" ]
                    li [] [str "List Item 2-4" ]
                ]
            ul [ ClassName insideImage ]
                [
                    str "List 3"
                    li [] [str "List Item 3-1" ]
                    li [] [str "List Item 3-2" ]
                    li [] [str "List Item 3-3" ]
                    li [] [str "List Item 3-4" ]
                ]
        ]

let CounterStyleExamples () =
     fragment []
                [
                    let someCounter =
                        counterStyle
                            [
                                System.Cyclic
                                Symbols.Strings [ "o"; "p" ]
                                Suffix.Value ". "
                            ]

                    let style =
                        fss
                            [
                                Label.Value "FOOOOOO"
                                ListStyleType' someCounter
                            ]

                    ul [ ClassName style ]
                        [
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                        ]

                    let fixedCounter =
                        counterStyle
                            [
                                System.Fixed ()
                                Symbols.Strings ["Ⓐ"; "Ⓑ"; "Ⓒ"; "Ⓓ"; "Ⓔ"; "Ⓕ"; "Ⓖ"; "Ⓗ"; "Ⓘ"; "Ⓙ"; "Ⓚ"; "Ⓛ"; "Ⓜ"; "Ⓝ"; "Ⓞ"; "Ⓟ"; "Ⓠ"; "Ⓡ"; "Ⓢ"; "Ⓣ"; "Ⓤ"; "Ⓥ"; "Ⓦ"; "Ⓧ"; "Ⓨ"; "Ⓩ"]
                                Suffix.Value " "
                            ]

                    let items =
                        fss
                            [
                                ListStyleType' fixedCounter
                            ]

                    ul [ ClassName items ]
                        [
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                        ]

                    let additive =
                        counterStyle
                            [
                                System.Additive
                                AdditiveSymbol' [(5, Symbol "V"); (4, Symbol "IV"); (1, Symbol "I")]
                            ]

                    let items = fss [ ListStyleType' additive ]

                    ul [ ClassName items ]
                        [
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                            li [] [ str "one" ]
                            li [] [ str "two" ]
                            li [] [ str "three" ]
                            li [] [ str "four" ]
                            li [] [ str "five" ]
                        ]


                ]
let PseudoElementExamples () =
    let required =
        fss
            [
                FontSize.Value (em 0.8)

                Before
                    [
                        Content.Value ""
                        Display.Block
                        Width' (px 10)
                        Height' (px 10)
                        BackgroundColor.red
                    ]

                After
                    [
                        Content.Value ""
                        Display.Block
                        Width' (px 10)
                        Height' (px 10)
                        BackgroundColor.blue
                    ]

            ]

    let tooltip =
        fss
            [
                FontSize' (px 25)
                Color.Hex "0bd"
                Display.Inline
                Position.Relative

                Hover
                    [
                        Before
                            [
                                BorderStyle.Solid
                                BorderWidth.Value(px 12, px 6, px 0, px 6)
                                BorderColor.Hex "444 transparent"
                                Content.Value ""
                                Left' (pct 45)
                                Bottom' (px 30)
                                Position.Absolute
                            ]

                        After
                            [
                                Display.Flex
                                JustifyContent.Center
                                BackgroundColor.Hex "444"
                                BorderRadius.Value (px 8)
                                Color.Hex "fff"
                                Content.Attribute(Attribute.Title)
                                Margin.Value (px -82, Auto, px 0, px 0)
                                FontSize' (px 16)
                                Padding' (px 13)
                                Width' (px 220)
                            ]
                    ]


            ]

    let firstLetter =
        fss
            [
                FirstLetter
                    [
                        FontSize' (pct 130)
                    ]
            ]

    let firstLine =
        fss
            [
                FirstLine
                    [
                        Color.red
                    ]
            ]

    let selection =
        fss
            [
                Selection
                    [
                        BackgroundColor.orangeRed
                    ]
            ]


    fragment []
        [
            p [] [str "It works"]

            div []
                [
                    label [ ClassName required ] [ str "Name" ]
                    input [ Type "text"; HTMLAttr.Required true ]
                    button [ HTMLAttr.Custom("data-tooltip", "Tooltip") ] [ str "Submit form" ]
                ]

            p [] [ str "Tooltip time" ]
            a [ Title "Hello from a tooltip!"; ClassName tooltip ] [ str "Tooltip here, hover!" ]

            p [] [ str "First letter" ]
            p [ ClassName firstLetter ] [ str "FOOBAR" ]

            p [] [ str "First line" ]
            p [ ClassName firstLine ]
                [
                    str "Styles will only be applied to the first line of this paragraph. After that, all text will be styled like normal. See what I mean?"
                ]

            p [] [ str "Selection" ]
            p [ ClassName selection ]
                [
                    str "Styles will only be applied to the first line of this paragraph. After that, all text will be styled like normal. See what I mean?"
                ]
        ]
let GridExamples () =
    div [ ClassName ( fss [ ! Html.All [ BackgroundColor.red ]  ]) ]
        [
            h2 [] [str "Grid examples"]

            h3 [] [str "Simple grid example"]
            let simpleContainer =
                fss
                    [
                        Display.Grid
                        GridTemplateRows.Repeat (3, px 150)
                        GridTemplateColumns.Repeat (3, fr 1.)
                        BackgroundColor.Hex "eee"
                        Width' (px 1000)
                        Margin.Value (px 20, Auto)
                        GridGap' (px 30)
                    ]

            let simpleItemTemplate =
                [
                    Padding' (px 20)
                    FontSize' (px 20)
                    FontFamily.SansSerif
                    Color.Hex "fff"
                ]

            let item1 =
                (simpleItemTemplate @
                [
                    BackgroundColor.orangeRed
                    GridRow.Value(GridPosition.Value 2, GridPosition.Value 2)
                    GridColumn.Value(GridPosition.Value 2, GridPosition.Value 3)
                ]) |> fss

            let item2 =
                simpleItemTemplate @
                [
                    BackgroundColor.yellowGreen
                    GridRow.Value(GridPosition.Value 1, GridPosition.Value 2)
                ] |> fss

            let item3 =
                simpleItemTemplate @
                [
                    BackgroundColor.blueViolet
                    GridRow.Value(GridPosition.Value 2, GridPosition.Value 3)
                    GridColumn.Value(GridPosition.Value 1, GridPosition.Value 2)
                ] |> fss

            let item4 =
                simpleItemTemplate @
                [
                    BackgroundColor.paleVioletred
                ] |> fss

            let item5 =
                simpleItemTemplate @
                [
                    BackgroundColor.royalBlue
                    GridRow.Value(GridPosition.Value 1, GridPosition.Value 2)
                    GridColumn.Value(GridPosition.Value 3, GridPosition.Value 4)
                ] |> fss

            let item6 =
                simpleItemTemplate @
                [
                    BackgroundColor.goldenrod
                    GridRow.Value(GridPosition.Value 1, GridPosition.Value 2)
                    GridColumn.Value(GridPosition.Value 2, GridPosition.Value 3)
                ] |> fss

            div [ ClassName simpleContainer ]
                [
                    div [ ClassName item1 ] [ str "1: Orange"]
                    div [ ClassName item2 ] [ str "2: Green"]
                    div [ ClassName item3 ] [ str "3: Violet"]
                    div [ ClassName item4 ] [ str "4: Pink"]
                    div [ ClassName item5 ] [ str "5: Blue"]
                    div [ ClassName item6 ] [ str "6: Brown"]
                ]


            let container =
                fss
                    [
                        BackgroundColor.Hex "eee"
                        Width' (px 1000)
                        Margin.Value (px 20, Auto)
                        Display.Grid
                        GridTemplateRows.Values [px 100; fr 1.; fr 2.; px 100]
                        GridTemplateColumns.Values [Repeat.Repeat(3, fr 1.); pct 20]
                        GridGap' (px 20)
                        Color.Hex "fff"
                        FontFamily.SansSerif
                    ]

            let headerStyle =
                fss
                    [
                        BackgroundColor.Hex "d62580"
                        GridRow.Value(GridPosition.Value 1, GridPosition.Value 2)
                        GridColumn.Value(GridPosition.Value 1, GridPosition.Value -1)
                    ]

            let smallBoxTemplate =
                [
                    BackgroundColor.Hex "d62580"
                    MinHeight' (px 100)
                ]

            let smallBoxOne =
                smallBoxTemplate @
                    [
                        GridRow.Value(GridPosition.Value 2, GridPosition.Value 3)
                        GridColumn.Value(GridPosition.Value 1, GridPosition.Value 2)
                    ] |> fss

            let smallBoxTwo =
                smallBoxTemplate @
                    [
                        GridRow.Value(GridPosition.Value 2, GridPosition.Value 3)
                        GridColumn.Value(GridPosition.Value 2, GridPosition.Value 3)
                    ] |> fss

            let smallBoxThree =
                smallBoxTemplate @
                    [
                        GridRow.Value(GridPosition.Value 2, GridPosition.Value 3)
                        GridColumn.Value(GridPosition.Value 3, GridPosition.Value 4)
                    ] |> fss


            let asideStyle =
                fss
                    [
                        BackgroundColor.Hex "d62580"
                        GridRow.Value(GridPosition.Value 2, GridPosition.Value 2)
                        GridColumn.Value(GridPosition.Value 4, GridPosition.Value 5)
                    ]

            let articleStyle =
                fss
                    [
                        BackgroundColor.Hex "d62580"
                        GridRow.Value(GridPosition.Value 3, GridPosition.Value 4)
                        GridColumn.Value(GridPosition.Value 1, GridPosition.Value 3)
                        MinHeight.Value (px 200)
                    ]

            let footerStyle =
                fss
                    [
                        BackgroundColor.Hex "d62580"
                        GridRow.Value(GridPosition.Value 4, GridPosition.Value 5)
                        GridColumn.Value(GridPosition.Value 1, GridPosition.Value -1)
                    ]

            h3 [] [ str "More complex grid" ]
            div [ ClassName container ]
              [
                header [ ClassName headerStyle ][ str "Header" ]
                div [ ClassName smallBoxOne ]
                    [ str "Small box 1" ]
                div [ ClassName smallBoxTwo ]
                    [ str "Small box 2" ]
                div [ ClassName smallBoxThree ]
                    [ str "Small box 3" ]
                aside [ ClassName asideStyle ]
                    [ str "Sidebar" ]
                article [ ClassName articleStyle ]
                    [ str "Main content" ]
                footer [ ClassName footerStyle ]
                    [str "Footer"]
            ]
        ]

let ResizeExample () =
    fragment []
        [
            let style = fss [ Resize.Both; BackgroundColor.red; Overflow.Auto ]
            div [ClassName style]
                [
                    str "Hello there!"
                ]
        ]


let render (model: Model) (dispatch: Msg -> unit) =
    div []
        [
            //BackgroundExamples model dispatch
            //ColorExamples ()
            //FontExamples ()
            //FontFaceExamples ()
            //BorderExamples model dispatch
            //MarginExamples ()
            //PaddingExamples ()
            //TransformExamples ()
            //TransitionExamples ()
            //TextExamples ()
            AnimationExamples ()
            //FlexBoxExamples model dispatch
            //MediaQueryExamples ()
            //SelectorExamples ()
            //CursorExamples ()
            //ListStyleExamples ()
            //GridExamples ()
            //CounterStyleExamples ()
            //PseudoElementExamples ()
            //PsuedoClassExamples ()
            ResizeExample()
        ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run