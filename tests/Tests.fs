module Tests

open Fable.Mocha
open Fable.Core.JsInterop

open Fss

let test (testName: string) (attributeList: CSSProperty list) (correct: (string * obj) list) =
    testCase testName <| fun _ ->
        let actual = attributeList |> createCSSRecord
        Expect.equal actual correct testName

let backgroundTests =
    testList "Background"
        [
            test
                "background color"
                [ BackgroundColor Color.red ]
                [ "backgroundColor" ==> "#ff0000"]

            test
                "background image"
                [ BackgroundImage (Background.Url "image.png") ]
                [ "backgroundImage" ==> "url(image.png)" ]

            test
                "background as linear gradient"
                [ BackgroundImage (Background.LinearGradient [ Color.red; Color.blue; deg 45.0; px 10 ] ) ]
                ["backgroundImage" ==> "linear-gradient(45.00deg, #ff0000, #0000ff 10px)"]

            test
                "background as circular radial gradient"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06"; Background.Circle ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle, #ffff00, #f06d06)"]

            test
                "background as ellipse radial gradient"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06"; Background.Ellipse ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse, #ffff00, #f06d06)"]

            test
                "background as radial gradient circleside closest corner"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleSide Background.ClosestCorner ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle closest-corner, #ffff00, #f06d06)"]

            test
                "background as radial gradient circleside closest side"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleSide Background.ClosestSide ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle closest-side, #ffff00, #f06d06)"]

            test
                "background as radial gradient circleside farthest corner"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleSide Background.FarthestCorner ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle farthest-corner, #ffff00, #f06d06)"]

            test
                "background as radial gradient circleside farthest side"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleSide Background.FarthestSide ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle farthest-side, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse-side closest corner"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseSide Background.ClosestCorner ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse closest-corner, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse-side closest side"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseSide Background.ClosestSide ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse closest-side, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse-side farthest corner"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseSide Background.FarthestCorner ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse farthest-corner, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse-side farthest side"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseSide Background.FarthestSide ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse farthest-side, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at top"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Top ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at top, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at top right"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Top; Background.Right ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at top right, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at top left"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Top; Background.Left ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at top left, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at top center"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Top; Background.Center ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at top center, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at bottom"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Bottom ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at bottom, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at bottom right"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Bottom; Background.Right ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at bottom right, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at bottom left"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Bottom; Background.Left ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at bottom left, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at bottom center"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Bottom; Background.Center ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at bottom center, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at center"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Center ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at center, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at center right"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Center; Background.Right ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at center right, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at center left"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Center; Background.Left ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at center left, #ffff00, #f06d06)"]

            test
                "background as radial gradient circle at center bottom"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.CircleAt [ Background.Center; Background.Bottom ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(circle at center bottom, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at top"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Top ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at top, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at top right"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Top; Background.Right ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at top right, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at top left"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Top; Background.Left ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at top left, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at top center"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Top; Background.Center ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at top center, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at bottom"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Bottom ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at bottom, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at bottom right"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Bottom; Background.Right ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at bottom right, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at bottom left"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Bottom; Background.Left ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at bottom left, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at bottom center"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Bottom; Background.Center ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at bottom center, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at center"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Center ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at center, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at center right"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Center; Background.Right ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at center right, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at center left"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Center; Background.Left ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at center left, #ffff00, #f06d06)"]

            test
                "background as radial gradient ellipse at center bottom"
                [ BackgroundImage ( Background.RadialGradient [ Color.yellow; hex "f06d06";  Background.EllipseAt [ Background.Center; Background.Bottom ] ] ) ]
                [ "backgroundImage" ==> "radial-gradient(ellipse at center bottom, #ffff00, #f06d06)"]

            test
                "background position to top"
                [ BackgroundPosition Background.Top ]
                [ "backgroundPosition" ==> "top"]

            test
                "background position to bottom"
                [ BackgroundPosition Background.Bottom]
                [ "backgroundPosition" ==> "bottom" ]

            test
                "background position to left"
                [ BackgroundPosition Background.Left]
                [ "backgroundPosition" ==> "left" ]

            test
                "background position to right"
                [ BackgroundPosition Background.Right]
                [ "backgroundPosition" ==> "right" ]

            test
                "background position to center"
                [ BackgroundPosition Background.Center]
                [ "backgroundPosition" ==> "center" ]

            test
                "background position with pixels"
                [ BackgroundPosition (px 50)]
                [ "backgroundPosition" ==> "50px" ]

            test
                "background position with percent"
                [ BackgroundPosition (pct 100)]
                [ "backgroundPosition" ==> "100%" ]

            test
                "background position to initial"
                [ BackgroundPosition Initial]
                [ "backgroundPosition" ==> "initial" ]

            test
                "background position to inherit"
                [ BackgroundPosition Inherit]
                [ "backgroundPosition" ==> "inherit" ]

            test
                "background position to unset"
                [ BackgroundPosition Unset]
                [ "backgroundPosition" ==> "unset" ]

            test
                "background positions"
                [ BackgroundPositions [ Background.Bottom; px 10; Background.Right; px 20 ] ]
                [ "backgroundPosition" ==> "bottom 10px right 20px" ]

            test
                "background origin to border-box"
                [ BackgroundOrigin Background.BorderBox]
                [ "backgroundOrigin" ==> "border-box" ]

            test
                "background origin to padding-box"
                [ BackgroundOrigin Background.PaddingBox]
                [ "backgroundOrigin" ==> "padding-box" ]

            test
                "background origin to content-box"
                [ BackgroundOrigin Background.ContentBox]
                ["backgroundOrigin" ==> "content-box"]

            test
                "background origin to inherit"
                [ BackgroundOrigin Inherit ]
                ["backgroundOrigin" ==> "inherit"]

            test
                "background origin to initial"
                [ BackgroundOrigin Initial ]
                ["backgroundOrigin" ==> "initial"]

            test
                "background origin to unset"
                [ BackgroundOrigin Unset ]
                ["backgroundOrigin" ==> "unset"]

            test
                "background clip to text"
                [ BackgroundClip Background.Text]
                [ "backgroundClip" ==> "text" ]

            test
                "background clip to BorderBox"
                [ BackgroundClip Background.BackgroundClip.BorderBox]
                ["backgroundClip" ==> "border-box" ]

            test
                "background clip to PaddingBox"
                [ BackgroundClip Background.BackgroundClip.PaddingBox]
                [ "backgroundClip" ==> "padding-box" ]

            test
                "background clip to ContentBox"
                [ BackgroundClip Background.BackgroundClip.ContentBox]
                ["backgroundClip" ==> "content-box" ]

            test
                "background clip to inherit"
                [ BackgroundClip Inherit ]
                ["backgroundClip" ==> "inherit" ]

            test
                "background clip to Initial"
                [ BackgroundClip Initial]
                [ "backgroundClip" ==> "initial" ]

            test
                "background clip to Unset"
                [ BackgroundClip Unset ]
                [ "backgroundClip" ==> "unset" ]

            test
                "background repeat repeat-x"
                [ BackgroundRepeat Background.RepeatX ]
                [ "backgroundRepeat" ==> "repeat-x" ]

            test
                "background repeat repeat-y"
                [ BackgroundRepeat Background.RepeatY ]
                [ "backgroundRepeat" ==> "repeat-y" ]

            test
                "background repeat repeat"
                [ BackgroundRepeat Background.Repeat]
                [ "backgroundRepeat" ==> "repeat" ]

            test
                "background repeat space"
                [ BackgroundRepeat Background.Space]
                [ "backgroundRepeat" ==> "space" ]

            test
                "background repeat round"
                [ BackgroundRepeat Background.Round]
                [ "backgroundRepeat" ==> "round" ]

            test
                "background repeat no repeat"
                [ BackgroundRepeat Background.NoRepeat]
                [ "backgroundRepeat" ==> "no-repeat" ]

            test
                "background repeat to inherit"
                [ BackgroundRepeat Inherit ]
                [ "backgroundRepeat" ==> "inherit" ]

            test
                "background repeat to Initial"
                [ BackgroundRepeat Initial]
                [ "backgroundRepeat" ==> "initial" ]

            test
                "background repeat to Unset"
                [ BackgroundRepeat Unset ]
                [ "backgroundRepeat" ==> "unset" ]

            test
                "background repeats horizontal and vertical - repeat space"
                [ BackgroundRepeats [ Background.Repeat; Background.Space ]]
                [ "backgroundRepeat" ==> "repeat space" ]

            test
                "background size cover"
                [ BackgroundSize Background.Cover]
                [ "backgroundSize" ==> "cover"]

            test
                "background size contain"
                [ BackgroundSize Background.Contain]
                [ "backgroundSize" ==> "contain"]

            test
                "background size percent"
                [ BackgroundSize (pct 100)]
                [ "backgroundSize" ==> "100%"]

            test
                "background size em"
                [ BackgroundSize (em 3.0)]
                [ "backgroundSize" ==> "3.0em"]

            test
                "background size px"
                [ BackgroundSize (px 10)]
                [ "backgroundSize" ==> "10px"]

            test
                "background size auto"
                [ BackgroundSize Auto ]
                [ "backgroundSize" ==> "auto"]

            test
                "background sizes auto auto"
                [ BackgroundSizes [ Auto; Auto ] ]
                [ "backgroundSize" ==> "auto auto" ]

            test
                "background sizes percent"
                [ BackgroundSizes [ pct 50; pct 25 ] ]
                [ "backgroundSize" ==> "50% 25%" ]

            test
                "background sizes auto and contain"
                [ BackgroundSizes [ Auto; Background.Contain] ]
                [ "backgroundSize" ==> "auto contain" ]

            test
                "background attachment scroll"
                [ BackgroundAttachment Background.Scroll]
                [ "backgroundAttachment" ==> "scroll" ]

            test
                "background attachment fixed"
                [ BackgroundAttachment Background.Fixed]
                [ "backgroundAttachment" ==> "fixed" ]

            test
                "background attachment local"
                [ BackgroundAttachment Background.Local]
                [ "backgroundAttachment" ==> "local" ]

            test
                "background attachment inherit"
                [ BackgroundAttachment Inherit ]
                [ "backgroundAttachment" ==> "inherit" ]

            test
                "background attachment initial"
                [ BackgroundAttachment Initial ]
                [ "backgroundAttachment" ==> "initial" ]

            test
                "background attachment unset"
                [ BackgroundAttachment Unset ]
                [ "backgroundAttachment" ==> "unset" ]
        ]
let colorTests =
    testList "Colors"
            [
                test
                    "Color named color"
                    [ Color Color.aliceBlue ]
                    [ "color" ==> "#f0f8ff"]

                test
                    "Color RGB"
                    [ Color (rgb 255 0 0) ]
                    ["color" ==> "rgb(255, 0, 0)"]

                test
                    "Color RBGA"
                    [ Color (rgba 255 0 0  0.5) ]
                    ["color" ==> "rgba(255, 0, 0, 0.500000)"]

                test
                    "Color HEX no #"
                    [ Color (hex "ff0000") ]
                    ["color" ==> "#ff0000"]

                test
                    "Color HEX with alpha"
                    [ Color (hex "#ff000080") ]
                    ["color" ==> "#ff000080"]

                test
                    "Color HSL"
                    [ Color (hsl 120 1.0 0.5) ]
                    ["color" ==> "hsl(120, 100%, 50%)"]

                test
                    "Color HSLA"
                    [ Color (hsla 120 1.0 0.5 0.5) ]
                    ["color" ==> "hsla(120, 100%, 50%, 50%)"]

                test
                    "Color Inherit"
                    [ Color Inherit ]
                    ["color" ==> "inherit"]

                test
                    "Color Initial"
                    [ Color Initial ]
                    ["color" ==> "initial"]

                test
                    "Color Unset"
                    [ Color Unset ]
                    ["color" ==> "unset"]
            ]

let fontTests =
    testList "Fonts"
        [
            test
                "Font size XX-Small"
                [ FontSize Font.XxSmall ]
                [ "fontSize" ==> "xx-small" ]

            test
                "Font size X-Small"
                [ FontSize Font.XSmall ]
                [ "fontSize" ==> "x-small" ]

            test
                "Font size small"
                [ FontSize Font.Small ]
                [ "fontSize" ==> "small" ]

            test
                "Font size medium"
                [ FontSize Font.Medium ]
                [ "fontSize" ==> "medium" ]

            test
                "Font size large"
                [ FontSize Font.Large ]
                [ "fontSize" ==> "large" ]

            test
                "Font size x-large"
                [ FontSize Font.XLarge ]
                [ "fontSize" ==> "x-large" ]

            test
                "Font size xx-large"
                [ FontSize Font.XxLarge ]
                [ "fontSize" ==> "xx-large" ]

            test
                "Font size xxx-large"
                [ FontSize Font.XxxLarge ]
                [ "fontSize" ==> "xxx-large" ]

            test
                "Font size smaller"
                [ FontSize Font.Smaller ]
                [ "fontSize" ==> "smaller" ]

            test
                "Font size larger"
                [ FontSize Font.Larger ]
                [ "fontSize" ==> "larger" ]

            test
                "Font size pixels"
                [ FontSize (px 18) ]
                [ "fontSize" ==> "18px" ]

            test
                "Font size em"
                [ FontSize (em 0.8) ]
                [ "fontSize" ==> "0.8em" ]

            test
                "Font size percentage"
                [ FontSize (pct 80) ]
                [ "fontSize" ==> "80%" ]

            test
                "Font size inherit"
                [ FontSize Inherit ]
                [ "fontSize" ==> "inherit" ]

            test
                "Font size initial"
                [ FontSize Initial ]
                [ "fontSize" ==> "initial" ]

            test
                "Font size unset"
                [ FontSize Unset ]
                [ "fontSize" ==> "unset" ]

            test
                "Font stretch normal"
                [ FontStretch Font.FontStretch.Normal ]
                [ "fontStretch" ==> "normal" ]

            test
                "Font stretch ultra-condensed"
                [ FontStretch Font.FontStretch.UltraCondensed ]
                [ "fontStretch" ==> "ultra-condensed" ]

            test
                 "Font stretch extra-condensed"
                [ FontStretch Font.FontStretch.ExtraCondensed ]
                [ "fontStretch" ==> "extra-condensed" ]

            test "Font stretch extra-condensed"
                [ FontStretch Font.FontStretch.ExtraCondensed ]
                [ "fontStretch" ==> "extra-condensed" ]

            test "Font stretch condensed"
                [ FontStretch Font.FontStretch.Condensed ]
                [ "fontStretch" ==> "condensed" ]

            test "Font stretch semi-condensed"
                [ FontStretch Font.FontStretch.SemiCondensed ]
                [ "fontStretch" ==> "semi-condensed" ]

            test "Font stretch expanded"
                [ FontStretch Font.FontStretch.Expanded]
                [ "fontStretch" ==> "expanded" ]

            test "Font stretch extra-expanded"
                [ FontStretch Font.FontStretch.ExtraExpanded]
                [ "fontStretch" ==> "extra-expanded" ]

            test "Font stretch ultra-expanded"
                [ FontStretch Font.FontStretch.UltraExpanded]
                [ "fontStretch" ==> "ultra-expanded" ]

            test "Font stretch percent"
                [ FontStretch (pct 200) ]
                [ "fontStretch" ==> "200%" ]

            test "Font stretch inherit"
                [ FontStretch Inherit ]
                [ "fontStretch" ==> "inherit" ]

            test "Font stretch initial"
                [ FontStretch Initial ]
                [ "fontStretch" ==> "initial" ]

            test "Font stretch unset"
                [ FontStretch Unset ]
                [ "fontStretch" ==> "unset" ]

            test
                "Font style normal"
                [ FontStyle Font.Normal]
                [ "fontStyle" ==> "normal"]

            test
                "Font style italic"
                [ FontStyle Font.Italic]
                [ "fontStyle" ==> "italic"]

            test
                "Font style oblicque 90"
                [ FontStyle (Font.Oblique (deg 90.0))]
                [ "fontStyle" ==> "oblique 90.00deg"]

            test
                "Font style oblique -90"
                [ FontStyle (Font.Oblique (deg -90.0))]
                [ "fontStyle" ==> "oblique -90.00deg"]

            test
                "Font style inherit"
                [ FontStyle Inherit ]
                [ "fontStyle" ==> "inherit" ]

            test
                "Font style initial"
                [ FontStyle Initial ]
                [ "fontStyle" ==> "initial" ]

            test
                "Font style unset"
                [ FontStyle Unset ]
                [ "fontStyle" ==> "unset" ]

            test
                "Font weight normal"
                [ FontWeight Font.FontWeight.Normal ]
                [ "fontWeight" ==> "normal"]

            test
                "Font weight bold"
                [ FontWeight Font.FontWeight.Bold ]
                [ "fontWeight" ==> "bold"]

            test
                "Font weight lighter"
                [ FontWeight Font.FontWeight.Lighter ]
                [ "fontWeight" ==> "lighter"]

            test
                "Font weight bolder"
                [ FontWeight Font.FontWeight.Bolder ]
                [ "fontWeight" ==> "bolder"]

            test
                "Font weight value"
                [ FontWeight (Font.FontWeight.Value 500) ]
                [ "fontWeight" ==> "500"]

            test
                "Font weight inherit"
                [ FontWeight Inherit ]
                [ "fontWeight" ==> "inherit"]

            test
                "Font weight initial"
                [ FontWeight Initial ]
                [ "fontWeight" ==> "initial"]

            test
                "Font weight unset"
                [ FontWeight Unset ]
                [ "fontWeight" ==> "unset"]

            test
                "Line height normal"
                [ LineHeight Font.LineHeight.Normal ]
                [ "lineHeight" ==> "normal" ]

            test
                "Line height value"
                [ LineHeight (Font.LineHeight.Value 2.5) ]
                [ "lineHeight" ==> "2.5" ]

            test
                "Line height em"
                [ LineHeight (em 3.0) ]
                [ "lineHeight" ==> "3.0em" ]

            test
                "Line height pixel"
                [ LineHeight (px 3) ]
                [ "lineHeight" ==> "3px" ]

            test
                "Line height percent"
                [ LineHeight (pct 34) ]
                [ "lineHeight" ==> "34%" ]

            test
                "Line height initial"
                [ LineHeight Initial ]
                [ "lineHeight" ==> "initial" ]

            test
                "Line height inherit"
                [ LineHeight Inherit ]
                [ "lineHeight" ==> "inherit" ]

            test
                "Line height unset"
                [ LineHeight Unset ]
                [ "lineHeight" ==> "unset" ]

            test
                 "Font family serif"
                 [ FontFamily Font.Serif ]
                 [ "fontFamily" ==> "serif" ]

            test
                 "Font family sans-serif"
                 [ FontFamily Font.SansSerif ]
                 [ "fontFamily" ==> "sans-serif" ]

            test
                 "Font family monospace"
                 [ FontFamily Font.Monospace ]
                 [ "fontFamily" ==> "monospace" ]

            test
                 "Font family cursive"
                 [ FontFamily Font.Cursive ]
                 [ "fontFamily" ==> "cursive" ]

            test
                 "Font family arial"
                 [ FontFamily (Font.Custom "arial") ]
                 [ "fontFamily" ==> "arial" ]

            test
                 "Font family initial"
                 [ FontFamily Initial ]
                 [ "fontFamily" ==> "initial" ]

            test
                 "Font family inherit"
                 [ FontFamily Inherit ]
                 [ "fontFamily" ==> "inherit" ]

            test
                 "Font family unset"
                 [ FontFamily Unset ]
                 [ "fontFamily" ==> "unset" ]

            test
                "Font families"
                [ FontFamilies [ Font.Serif; Font.Monospace ] ]
                [ "fontFamily" ==> "serif, monospace" ]

            test
                "font feature setting On"
                [ FontFeatureSetting (Font.Liga Font.On) ]
                [ "fontFeatureSettings" ==> "\"liga\" On" ]

            test
                "font feature setting Off"
                [ FontFeatureSetting (Font.Liga Font.Off) ]
                [ "fontFeatureSettings" ==> "\"liga\" Off" ]

            test
                "font feature setting initial"
                [ FontFeatureSetting Initial ]
                [ "fontFeatureSettings" ==> "initial" ]

            test
                "font feature setting inherit"
                [ FontFeatureSetting Inherit ]
                [ "fontFeatureSettings" ==> "inherit" ]

            test
                "font feature setting unset"
                [ FontFeatureSetting Unset ]
                [ "fontFeatureSettings" ==> "unset" ]

            test
                "font feature setting multiple on"
                [
                    FontFeatureSettings
                        [
                            Font.Smcp Font.On
                            Font.Onum Font.On
                        ]
                ]
                [ "fontFeatureSettings" ==> "\"smcp\" On, \"onum\" On" ]

            test
                "font feature setting multiple off"
                [
                    FontFeatureSettings
                        [
                            Font.Smcp Font.Off
                            Font.Onum Font.Off
                        ]
                    ]
                [ "fontFeatureSettings" ==> "\"smcp\" Off, \"onum\" Off" ]


            test
                "Font variant numeric normal"
                [ FontVariantNumeric Font.FontVariantNumeric.Normal]
                ["fontVariantNumeric" ==> "normal"]

            test
                "Font variant numeric ordinal"
                [ FontVariantNumeric Font.FontVariantNumeric.Ordinal]
                ["fontVariantNumeric" ==> "ordinal"]

            test
                "Font variant numeric slashed zero"
                [ FontVariantNumeric Font.FontVariantNumeric.SlashedZero]
                ["fontVariantNumeric" ==> "slashed-zero"]

            test
                "Font variant numeric lining nums"
                [ FontVariantNumeric Font.FontVariantNumeric.LiningNums]
                ["fontVariantNumeric" ==> "lining-nums"]

            test
                "Font variant numeric old style nums"
                [ FontVariantNumeric Font.FontVariantNumeric.OldstyleNums]
                ["fontVariantNumeric" ==> "oldstyle-nums"]

            test
                "Font variant numeric tabular nums"
                [ FontVariantNumeric Font.FontVariantNumeric.TabularNums]
                ["fontVariantNumeric" ==> "tabular-nums"]

            test
                "Font variant numeric diagonal fractions"
                [ FontVariantNumeric Font.FontVariantNumeric.DiagonalFractions]
                ["fontVariantNumeric" ==> "diagonal-fractions"]

            test
                "Font variant numeric stacked fractions"
                [ FontVariantNumeric Font.FontVariantNumeric.StackedFractions]
                ["fontVariantNumeric" ==> "stacked-fractions"]

            test
                "Font variant numerics multiple"
                [
                    FontVariantNumerics
                        [
                            Font.FontVariantNumeric.OldstyleNums
                            Font.FontVariantNumeric.StackedFractions
                        ]
                ]
                ["fontVariantNumeric" ==> "oldstyle-nums stacked-fractions"]

            test
                "Font variant numeric inherit"
                [ FontVariantNumeric Inherit ]
                [ "fontVariantNumeric" ==> "inherit" ]

            test
                "Font variant numeric initial"
                [ FontVariantNumeric Initial]
                [ "fontVariantNumeric" ==> "initial" ]

            test
                "Font variant numeric unset"
                [ FontVariantNumeric Unset ]
                [ "fontVariantNumeric" ==> "unset" ]

            test
                "Font variant caps normal"
                [ FontVariantCaps Font.FontVariantCaps.Normal]
                ["fontVariantCaps" ==> "normal"]

            test
                "Font variant caps small caps"
                [ FontVariantCaps Font.FontVariantCaps.SmallCaps]
                ["fontVariantCaps" ==> "small-caps"]

            test
                "Font variant caps  all small caps"
                [ FontVariantCaps Font.FontVariantCaps.AllSmallCaps]
                ["fontVariantCaps" ==> "all-small-caps"]

            test
                "Font variant caps petite caps"
                [ FontVariantCaps Font.FontVariantCaps.PetiteCaps]
                ["fontVariantCaps" ==> "petite-caps"]

            test
                "Font variant caps all petite caps"
                [ FontVariantCaps Font.FontVariantCaps.AllPetiteCaps]
                ["fontVariantCaps" ==> "all-petite-caps"]

            test
                "Font variant caps unicase"
                [ FontVariantCaps Font.FontVariantCaps.Unicase]
                ["fontVariantCaps" ==> "unicase"]

            test
                "Font variant caps titling caps"
                [ FontVariantCaps Font.FontVariantCaps.TitlingCaps]
                ["fontVariantCaps" ==> "titling-caps"]

            test
                "Font variant caps initial"
                [ FontVariantCaps Initial ]
                [ "fontVariantCaps" ==> "initial"]

            test
                "Font variant caps inherit"
                [ FontVariantCaps Inherit ]
                ["fontVariantCaps" ==> "inherit"]

            test
                "Font variant caps unset"
                [ FontVariantCaps Unset ]
                ["fontVariantCaps" ==> "unset" ]

            test
                "Font variant east asian normal"
                [ FontVariantEastAsian Font.FontVariantEastAsian.Normal]
                ["fontVariantEastAsian" ==> "normal"]

            test
                "Font variant east asian ruby"
                [ FontVariantEastAsian Font.Ruby]
                ["fontVariantEastAsian" ==> "ruby"]

            test
                "Font variant east asian  jis78"
                [ FontVariantEastAsian Font.Jis78]
                ["fontVariantEastAsian" ==> "jis78"]

            test
                "Font variant east asian jis83"
                [ FontVariantEastAsian Font.Jis83]
                ["fontVariantEastAsian" ==> "jis83"]

            test
                "Font variant east asian jis90"
                [ FontVariantEastAsian Font.Jis90]
                ["fontVariantEastAsian" ==> "jis90"]

            test
                "Font variant east asian jis04"
                [ FontVariantEastAsian Font.Jis04]
                ["fontVariantEastAsian" ==> "jis04"]

            test
                "Font variant east asian simplified"
                [ FontVariantEastAsian Font.Simplified]
                ["fontVariantEastAsian" ==> "simplified"]

            test
                "Font variant east asian traditional"
                [ FontVariantEastAsian Font.Traditional]
                ["fontVariantEastAsian" ==> "traditional"]

            test
                "Font variant east asian full width"
                [ FontVariantEastAsian Font.FullWidth]
                ["fontVariantEastAsian" ==> "full-width"]

            test
                "Font variant east asian  proportional widt"
                [ FontVariantEastAsian Font.ProportionalWidth]
                ["fontVariantEastAsian" ==> "proportional-width"]

            test
                "Font variant east asian multiple"
                [
                    FontVariantEastAsians
                        [
                            Font.Ruby
                            Font.FullWidth
                            Font.Jis83
                        ]
                ]
                ["fontVariantEastAsian" ==> "ruby full-width jis83"]

            test
                "Font variant ligatures normal"
                [ FontVariantLigatures Font.FontVariantLigatures.Normal]
                ["fontVariantLigatures" ==> "normal"]

            test
                "Font variant ligatures none"
                [ FontVariantLigatures Font.None]
                ["fontVariantLigatures" ==> "none"]

            test
                "Font variant ligatures common"
                [ FontVariantLigatures Font.CommonLigatures]
                ["fontVariantLigatures" ==> "common-ligatures"]

            test
                "Font variant ligatures no common"
                [ FontVariantLigatures Font.NoCommonLigatures]
                ["fontVariantLigatures" ==> "no-common-ligatures"]

            test
                "Font variant ligatures discretionary"
                [ FontVariantLigatures Font.DiscretionaryLigatures]
                ["fontVariantLigatures" ==> "discretionary-ligatures"]

            test
                "Font variant ligatures no discretionary"
                [ FontVariantLigatures Font.NoDiscretionaryLigatures]
                ["fontVariantLigatures" ==> "no-discretionary-ligatures"]

            test
                "Font variant ligatures historical"
                [ FontVariantLigatures Font.HistoricalLigatures]
                ["fontVariantLigatures" ==> "historical-ligatures"]

            test
                "Font variant ligatures no historical"
                [ FontVariantLigatures Font.NoHistoricalLigatures]
                ["fontVariantLigatures" ==> "no-historical-ligatures"]

            test
                "Font variant ligatures contextual"
                [ FontVariantLigatures Font.Contextual]
                ["fontVariantLigatures" ==> "contextual"]

            test
                "Font variant ligatures no contextual"
                [ FontVariantLigatures Font.NoContextual]
                ["fontVariantLigatures" ==> "no-contextual"]

            test
                "Font variant ligatures no initial"
                [ FontVariantLigatures Initial ]
                ["fontVariantLigatures" ==> "initial"]

            test
                "Font variant ligatures inherit"
                [ FontVariantLigatures Inherit]
                ["fontVariantLigatures" ==> "inherit"]

            test
                "Font variant ligatures no unset"
                [ FontVariantLigatures Unset]
                ["fontVariantLigatures" ==> "unset"]
    ]

let borderTests =
    testList "Border"
        [
            test
                "Borderstyle hidden"
                [ BorderStyle Border.Hidden ]
                [
                    "borderStyle" ==> "hidden"
                ]

            test
                "Borderstyle dotted"
                [ BorderStyle Border.Dotted ]
                [
                    "borderStyle" ==> "dotted"
                ]

            test
                "Borderstyle dashed"
                [ BorderStyle Border.Dashed ]
                [
                    "borderStyle" ==> "dashed"
                ]

            test
                "Borderstyle solid"
                [ BorderStyle Border.Solid ]
                [
                    "borderStyle" ==> "solid"
                ]

            test
                "Borderstyle double"
                [ BorderStyle Border.Double ]
                [
                    "borderStyle" ==> "double"
                ]

            test
                "Borderstyle groove"
                [ BorderStyle Border.Groove ]
                [
                    "borderStyle" ==> "groove"
                ]

            test
                "Borderstyle ridge"
                [ BorderStyle Border.Ridge ]
                [
                    "borderStyle" ==> "ridge"
                ]

            test
                "Borderstyle inset"
                [ BorderStyle Border.Inset ]
                [
                    "borderStyle" ==> "inset"
                ]

            test
                "Borderstyle outset"
                [ BorderStyle Border.Outset ]
                [
                    "borderStyle" ==> "outset"
                ]

            test
                "Borderstyle multiple"
                [ BorderStyles [Border.Inset; Border.Outset; Border.Ridge; Border.Groove] ]
                [
                    "borderStyle" ==> "inset outset ridge groove"
                ]

            test
                "Borderstyle none"
                [ BorderStyle Border.None ]
                [
                    "borderStyle" ==> "none"
                ]

            test
                "Borderstyle initial"
                [ BorderStyle Initial ]
                [
                    "borderStyle" ==> "initial"
                ]

            test
                "Borderstyle inherit"
                [ BorderStyle Inherit ]
                [
                    "borderStyle" ==> "inherit"
                ]

            test
                "Borderstyle unset"
                [ BorderStyle Unset ]
                [
                    "borderStyle" ==> "unset"
                ]

            test
                "Border radius px"
                [ BorderRadius (px 10)]
                     [
                         "borderRadius" ==> "10px"
                     ]

            test
                "Border radius percent"
                [ BorderRadius (pct 50)]
                     [
                         "borderRadius" ==> "50%"
                     ]

            test
                "Border top left radius px"
                [ BorderTopLeftRadius (px 10)]
                ["borderTopLeftRadius" ==> "10px"]

            test
                "Border top right radius px"
                [ BorderTopRightRadius (px 10)]
                ["borderTopRightRadius" ==> "10px"]

            test
                "Border bottom left radius"
                [ BorderBottomLeftRadius (px 10)]
                ["borderBottomLeftRadius" ==> "10px"]

            test
                "Border bottom right radius px"
                [ BorderBottomRightRadius (px 10)]
                ["borderBottomRightRadius" ==> "10px"]

            test
                "Border radius multiple px"
                [ BorderRadiuses [px 10; px 20; px 30; px 40] ]
                    [
                        "borderRadius" ==> "10px 20px 30px 40px"
                    ]

            test
                "Border radius top left initial"
                [ BorderTopLeftRadius Initial ]
                ["borderTopLeftRadius" ==> "initial"]

            test
                "Border radius top right inherit"
                [ BorderTopRightRadius Inherit ]
                ["borderTopRightRadius" ==> "inherit"]

            test
                "Border bottom left radius unset"
                [ BorderBottomLeftRadius Unset ]
                ["borderBottomLeftRadius" ==> "unset"]

            test
                "Border bottom right radius initial"
                [ BorderBottomRightRadius Initial ]
                ["borderBottomRightRadius" ==> "initial"]

            test
                "Border radius inherit"
                [ BorderRadius Inherit ]
                ["borderRadius" ==> "inherit"]

            test
                "Border radius inherit"
                [ BorderRadius Inherit ]
                ["borderRadius" ==> "inherit"]

            test
                "Border radius unset"
                [ BorderRadius Unset ]
                ["borderRadius" ==> "unset"]
















            test
                "Border width px"
                [ BorderWidth (px 40) ]
                [ "borderWidth" ==> "40px" ]

            test
                "Border width thin"
                [ BorderWidth Border.Thin ]
                [ "borderWidth" ==> "thin" ]

            test
                "Border width medium"
                [ BorderWidth Border.Medium ]
                [ "borderWidth" ==> "medium" ]

            test
                "Border width thick"
                [ BorderWidth Border.Thick ]
                [ "borderWidth" ==> "thick" ]

            test
                "Border width initial"
                [ BorderWidth Initial ]
                [ "borderWidth" ==> "initial" ]

            test
                "Border width inherit"
                [ BorderWidth Inherit ]
                [ "borderWidth" ==> "inherit" ]

            test
                "Border width unset"
                [ BorderWidth Unset ]
                [ "borderWidth" ==> "unset" ]

            test
                "Border widths combination"
                [ BorderWidths [Border.Thin; px 20; em 3.0; rem 4.5 ]]
                [ "borderWidth" ==> "thin 20px 3.0em 4.5rem" ]

            test
                "Border left width px"
                [ BorderLeftWidth (px 40) ]
                ["borderLeftWidth" ==> "40px"]

            test
                "Border right width cm"
                [ BorderRightWidth (cm 40.0) ]
                ["borderRightWidth" ==> "40.0cm"]

            test
                "Border color red"
                [ BorderColor Color.red ]
                [ "borderColor" ==> "#ff0000" ]

            test
                "Border color initial"
                [ BorderColor Initial ]
                [ "borderColor" ==> "initial" ]

            test
                "Border color inherit"
                [ BorderColor Inherit ]
                [ "borderColor" ==> "inherit" ]

            test
                "Border color unset"
                [ BorderColor Unset ]
                [ "borderColor" ==> "unset" ]

            test
                "Border colors multiple"
                [ BorderColors [ Color.red; Color.green; Color.blue; Color.white] ]
                [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]

            test
                "Border top color rgb"
                [ BorderTopColor (rgb 255 0 0) ]
                ["borderTopColor" ==> "rgb(255, 0, 0)"]

            test
                "Border right color green"
                [ BorderRightColor Color.green ]
                ["borderRightColor" ==> "#008000"]

            test
                "Border bottom color"
                [ BorderBottomColor Color.blue ]
                ["borderBottomColor" ==> "#0000ff"]

            test
                "Border left color"
                [ BorderLeftColor Color.white ]
                ["borderLeftColor" ==> "#ffffff"]

        ]

let contentSizeTests =
    testList "Content size"
        [
            test
                "Width px"
                [ Width (px 100) ]
                ["width" ==> "100px"]

            test
                "Width percent"
                [ Width (pct 25) ]
                ["width" ==> "25%"]


            test
                "Width max content"
                [ Width ContentSize.MaxContent ]
                ["width" ==> "max-content"]

            test
                "Width min content"
                [ Width ContentSize.MinContent ]
                ["width" ==> "min-content"]

            test
                "Width fit content"
                [ Width (ContentSize.FitContent(px 100)) ]
                ["width" ==> "fit-content(100px)"]

            test
                "Width auto"
                [ Width Auto ]
                ["width" ==> "auto"]

            test
                "Width initial"
                [ Width Initial ]
                ["width" ==> "initial"]

            test
                "Width inherit"
                [ Width Inherit ]
                ["width" ==> "inherit"]

            test
                "Width unset"
                [ Width Unset ]
                ["width" ==> "unset"]

            test
                "Height px"
                [ Height (px 100) ]
                ["height" ==> "100px"]

            test
                "Height percent"
                [ Height (pct 25) ]
                ["height" ==> "25%"]


            test
                "Height max content"
                [ Height ContentSize.MaxContent ]
                ["height" ==> "max-content"]

            test
                "Height min content"
                [ Height ContentSize.MinContent ]
                ["height" ==> "min-content"]

            test
                "Height fit content"
                [ Height (ContentSize.FitContent(px 100)) ]
                ["height" ==> "fit-content(100px)"]

            test
                "Height auto"
                [ Height Auto ]
                ["height" ==> "auto"]

            test
                "Height initial"
                [ Height Initial ]
                ["height" ==> "initial"]

            test
                "Height inherit"
                [ Height Inherit ]
                ["height" ==> "inherit"]

            test
                "Height unset"
                [ Height Unset ]
                ["height" ==> "unset"]
        ]

let perspectiveTests =
    testList "Perspective"
        [
            test
                "Perspective px"
                [ Perspective (px 100) ]
                ["perspective" ==> "100px"]

            test
                "Perspective em"
                [ Perspective (em 3.5) ]
                ["perspective" ==> "3.5em"]

            test
                "Perspective none"
                [ Perspective Perspective.None ]
                ["perspective" ==> "none"]

            test
                "Perspective inherit"
                [ Perspective Inherit]
                [ "perspective" ==> "inherit" ]

            test
                "Perspective initial"
                [ Perspective Initial]
                ["perspective" ==> "initial" ]

            test
                "Perspective unset"
                [ Perspective Unset]
                ["perspective" ==> "unset"]
        ]

let displayTests =
    testList "Display"
        [
                test
                    "Display inline"
                    [ Display Display.Inline]
                    ["display" ==> "inline"]

                test
                    "Display inline-block"
                    [ Display Display.InlineBlock]
                    ["display" ==> "inline-block"]

                test
                    "Display block"
                    [ Display Display.Block]
                    ["display" ==> "block"]

                test
                    "Display run-in"
                    [ Display Display.RunIn]
                    ["display" ==> "run-in"]

                test
                    "Display flex"
                    [ Display Display.Flex]
                    ["display" ==> "flex"]

                test
                    "Display grid"
                    [ Display Display.Grid]
                    ["display" ==> "grid"]

                test
                    "Display flow-root"
                    [ Display Display.FlowRoot]
                    ["display" ==> "flow-root"]

                test
                    "Display table"
                    [ Display Display.Table]
                    ["display" ==> "table"]

                test
                    "Display table-cell"
                    [ Display Display.TableCell]
                    ["display" ==> "table-cell"]

                test
                    "Display table-column"
                    [ Display Display.TableColumn]
                    ["display" ==> "table-column"]

                test
                    "Display table-column-group"
                    [ Display Display.TableColumnGroup]
                    ["display" ==> "table-column-group"]

                test
                    "Display table-header-group"
                    [ Display Display.TableHeaderGroup]
                    ["display" ==> "table-header-group"]

                test
                    "Display table row group"
                    [ Display Display.TableRowGroup]
                    ["display" ==> "table-row-group"]

                test
                    "table footer group"
                    [ Display Display.TableFooterGroup]
                    ["display" ==> "table-footer-group"]

                test
                    "Display table row"
                    [ Display Display.TableRow]
                    ["display" ==> "table-row"]

                test
                    "Display table-caption"
                    [ Display Display.TableCaption]
                    ["display" ==> "table-caption"]

                test
                    "Display none"
                    [ Display Display.None]
                    ["display" ==> "none"]
        ]

let flexTests =
    testList "Flex"
        [
            test
                "Flex direction row"
                [ FlexDirection Flex.Row]
                ["flexDirection" ==> "row"]

            test
                "Flex direction row-reverse"
                [ FlexDirection Flex.RowReverse]
                ["flexDirection" ==> "row-reverse"]

            test
                "Flex direction column"
                [ FlexDirection Flex.Column]
                ["flexDirection" ==> "column"]

            test
                "Flex direction column-reverse"
                [ FlexDirection Flex.ColumnReverse]
                ["flexDirection" ==> "column-reverse"]

            test
                "Flex direction inherit"
                [ FlexDirection Inherit]
                ["flexDirection" ==> "inherit"]

            test
                "Flex direction initial"
                [ FlexDirection Initial]
                ["flexDirection" ==> "initial"]

            test
                "Flex direction unset"
                [ FlexDirection Unset]
                ["flexDirection" ==> "unset"]


            test
                "Flex wrap no-wrap"
                [ FlexWrap Flex.NoWrap]
                ["flexWrap" ==> "no-wrap"]

            test
                "Flex wrap wrap"
                [ FlexWrap Flex.Wrap]
                ["flexWrap" ==> "wrap"]

            test
                "Flex wrap wrap-reverse"
                [ FlexWrap Flex.WrapReverse]
                ["flexWrap" ==> "wrap-reverse"]

            test
                "Flex wrap inherit"
                [ FlexWrap Inherit]
                ["flexWrap" ==> "inherit"]

            test
                "Flex wrap initial"
                [ FlexWrap Initial]
                ["flexWrap" ==> "initial"]

            test
                "Flex wrap unset"
                [ FlexWrap Unset]
                ["flexWrap" ==> "unset"]

            test
                "Flex basis em"
                [ FlexBasis (em 10.0)]
                ["flexBasis" ==> "10.0em"]

            test
                "Flex basis px"
                [ FlexBasis (px 100)]
                ["flexBasis" ==> "100px"]

            test
                "Flex basis auto"
                [ FlexBasis Auto]
                ["flexBasis" ==> "auto"]

            test
                "Flex basis fill"
                [ FlexBasis Flex.Fill ]
                ["flexBasis" ==> "fill"]

            test
                "Flex basis max-content"
                [ FlexBasis Flex.MaxContent]
                ["flexBasis" ==> "max-content"]

            test
                "Flex basis min-content"
                [ FlexBasis Flex.MinContent]
                ["flexBasis" ==> "min-content"]

            test
                "Flex basis fit-content"
                [ FlexBasis Flex.FitContent]
                ["flexBasis" ==> "fit-content"]

            test
                "Flex basis content"
                [ FlexBasis Flex.Content]
                ["flexBasis" ==> "content"]

            test
                "Justify content start"
                [ JustifyContent Flex.Start]
                ["justifyContent" ==> "start"]

            test
                "Justify content end"
                [ JustifyContent Flex.End]
                ["justifyContent" ==> "end"]

            test
                "Justify content flex start"
                [ JustifyContent Flex.FlexStart]
                ["justifyContent" ==> "flex-start"]

            test
                "Justify content flex end"
                [ JustifyContent Flex.FlexEnd]
                ["justifyContent" ==> "flex-end"]

            test
                "Justify content center"
                [ JustifyContent Flex.Center]
                ["justifyContent" ==> "center"]

            test
                "Justify content left"
                [ JustifyContent Flex.Left]
                ["justifyContent" ==> "left"]

            test
                "Justify content right"
                [ JustifyContent Flex.Right]
                ["justifyContent" ==> "right"]

            test
                "Justify content normal"
                [ JustifyContent Flex.Normal]
                ["justifyContent" ==> "normal"]

            test
                "Justify content baseline"
                [ JustifyContent Flex.Baseline]
                ["justifyContent" ==> "baseline"]

            test
                "Justify content space between"
                [ JustifyContent Flex.SpaceBetween]
                ["justifyContent" ==> "space-between"]

            test
                "Justify content space around"
                [ JustifyContent Flex.SpaceAround]
                ["justifyContent" ==> "space-around"]

            test
                "Justify content space evenly"
                [ JustifyContent Flex.SpaceEvenly]
                ["justifyContent" ==> "space-evenly"]

            test
                "Justify content right"
                [ JustifyContent Flex.Right]
                ["justifyContent" ==> "right"]

            test
                "Justify content safe"
                [ JustifyContent Flex.Safe]
                ["justifyContent" ==> "safe"]

            test
                "Justify content unsafe"
                [ JustifyContent Flex.Unsafe]
                ["justifyContent" ==> "unsafe"]

            test
                "Justify content inherit"
                [ JustifyContent Inherit]
                ["justifyContent" ==> "inherit"]

            test
                "Justify content initial"
                [ JustifyContent Initial]
                ["justifyContent" ==> "initial"]

            test
                "Justify content unset"
                [ JustifyContent Unset]
                ["justifyContent" ==> "unset"]

            test
                "Align self normal"
                [ AlignSelf Flex.AlignSelf.Normal]
                ["alignSelf" ==> "normal"]

            test
                "Align self flex start"
                [ AlignSelf Flex.AlignSelf.SelfStart]
                ["alignSelf" ==> "self-start"]

            test
                "Align self flex end"
                [ AlignSelf Flex.AlignSelf.SelfEnd]
                ["alignSelf" ==> "self-end"]

            test
                "Align self flex start"
                [ AlignSelf Flex.AlignSelf.FlexStart]
                ["alignSelf" ==> "flex-start"]

            test
                "Align self flex end"
                [ AlignSelf Flex.AlignSelf.FlexEnd]
                ["alignSelf" ==> "flex-end"]

            test
                "Align self center"
                [ AlignSelf Flex.AlignSelf.Center]
                ["alignSelf" ==> "center"]

            test
                "Align self baseline"
                [ AlignSelf Flex.AlignSelf.Baseline]
                ["alignSelf" ==> "baseline"]

            test
                "Align self stretch"
                [ AlignSelf Flex.AlignSelf.Stretch]
                ["alignSelf" ==> "stretch"]

            test
                "Align self safe"
                [ AlignSelf Flex.AlignSelf.Safe]
                ["alignSelf" ==> "safe"]

            test
                "Align self unsafe"
                [ AlignSelf Flex.AlignSelf.Unsafe]
                ["alignSelf" ==> "unsafe"]

            test
                "Align self inherit"
                [ AlignSelf Inherit]
                ["alignSelf" ==> "inherit"]

            test
                "Align self initial"
                [ AlignSelf Initial]
                ["alignSelf" ==> "initial"]

            test
                "Align self unset"
                [ AlignSelf Unset]
                ["alignSelf" ==> "unset"]

            test
                "Align items start"
                [ AlignItems Flex.AlignItems.Start]
                ["alignItems" ==> "start"]

            test
                "Align items end"
                [ AlignItems Flex.AlignItems.End]
                ["alignItems" ==> "end"]

            test
                "Align items flex start"
                [ AlignItems Flex.AlignItems.FlexStart]
                ["alignItems" ==> "flex-start"]

            test
                "Align items flex end"
                [ AlignItems Flex.AlignItems.FlexEnd]
                ["alignItems" ==> "flex-end"]

            test
                "Align items center"
                [ AlignItems Flex.AlignItems.Center]
                ["alignItems" ==> "center"]

            test
                "Align items left"
                [ AlignItems Flex.AlignItems.Left]
                ["alignItems" ==> "left"]

            test
                "Align items right"
                [ AlignItems Flex.AlignItems.Right]
                ["alignItems" ==> "right"]

            test
                "Align items normal"
                [ AlignItems Flex.AlignItems.Normal]
                ["alignItems" ==> "normal"]

            test
                "Align items baseline"
                [ AlignItems Flex.AlignItems.Baseline]
                ["alignItems" ==> "baseline"]

            test
                "Align items space between"
                [ AlignItems Flex.AlignItems.SpaceBetween]
                ["alignItems" ==> "space-between"]

            test
                "Align items space around"
                [ AlignItems Flex.AlignItems.SpaceAround]
                ["alignItems" ==> "space-around"]

            test
                "Align items space evenly"
                [ AlignItems Flex.AlignItems.SpaceEvenly]
                ["alignItems" ==> "space-evenly"]

            test
                "Align items right"
                [ AlignItems Flex.AlignItems.Right]
                ["alignItems" ==> "right"]

            test
                "Align items safe"
                [ AlignItems Flex.AlignItems.Safe]
                ["alignItems" ==> "safe"]

            test
                "Align items unsafe"
                [ AlignItems Flex.AlignItems.Unsafe]
                ["alignItems" ==> "unsafe"]

            test
                "Align items inherit"
                [ AlignItems Inherit]
                ["alignItems" ==> "inherit"]

            test
                "Align items initial"
                [ AlignItems Initial]
                ["alignItems" ==> "initial"]

            test
                "Align items unset"
                [ AlignItems Unset]
                ["alignItems" ==> "unset"]




            test
                "Align content start"
                [ AlignContent Flex.AlignContent.Start]
                ["alignContent" ==> "start"]

            test
                "Align content end"
                [ AlignContent Flex.AlignContent.End]
                ["alignContent" ==> "end"]

            test
                "Align content flex start"
                [ AlignContent Flex.AlignContent.FlexStart]
                ["alignContent" ==> "flex-start"]

            test
                "Align content flex end"
                [ AlignContent Flex.AlignContent.FlexEnd]
                ["alignContent" ==> "flex-end"]

            test
                "Align content center"
                [ AlignContent Flex.AlignContent.Center]
                ["alignContent" ==> "center"]

            test
                "Align content left"
                [ AlignContent Flex.AlignContent.Left]
                ["alignContent" ==> "left"]

            test
                "Align content right"
                [ AlignContent Flex.AlignContent.Right]
                ["alignContent" ==> "right"]

            test
                "Align content normal"
                [ AlignContent Flex.AlignContent.Normal]
                ["alignContent" ==> "normal"]

            test
                "Align content baseline"
                [ AlignContent Flex.AlignContent.Baseline]
                ["alignContent" ==> "baseline"]

            test
                "Align content space between"
                [ AlignContent Flex.AlignContent.SpaceBetween]
                ["alignContent" ==> "space-between"]

            test
                "Align content space around"
                [ AlignContent Flex.AlignContent.SpaceAround]
                ["alignContent" ==> "space-around"]

            test
                "Align content space evenly"
                [ AlignContent Flex.AlignContent.SpaceEvenly]
                ["alignContent" ==> "space-evenly"]

            test
                "Align content right"
                [ AlignContent Flex.AlignContent.Right]
                ["alignContent" ==> "right"]

            test
                "Align content safe"
                [ AlignContent Flex.AlignContent.Safe]
                ["alignContent" ==> "safe"]

            test
                "Align content unsafe"
                [ AlignContent Flex.AlignContent.Unsafe]
                ["alignContent" ==> "unsafe"]

            test
                "Align content inherit"
                [ AlignContent Inherit]
                ["alignContent" ==> "inherit"]

            test
                "Align content initial"
                [ AlignContent Initial]
                ["alignContent" ==> "initial"]

            test
                "Align content unset"
                [ AlignContent Unset]
                ["alignContent" ==> "unset"]

            test
                "Order value"
                [ Order (Flex.Order 1) ]
                ["order" ==> "1"]

            test
                "Order inherit"
                [ Order Inherit]
                ["order" ==> "inherit"]

            test
                "Order initial"
                [ Order Initial]
                ["order" ==> "initial"]

            test
                "Order unset"
                [ Order Unset]
                ["order" ==> "unset"]

            test
                "Flex grow value"
                [ FlexGrow (Flex.Grow 1.5) ]
                ["flexGrow" ==> "1.5"]

            test
                "FlexGrow inherit"
                [ FlexGrow Inherit]
                ["flexGrow" ==> "inherit"]

            test
                "FlexGrow initial"
                [ FlexGrow Initial]
                ["flexGrow" ==> "initial"]

            test
                "FlexGrow unset"
                [ FlexGrow Unset]
                ["flexGrow" ==> "unset"]

            test
                "FlexShrink value"
                [ FlexShrink (Flex.Shrink 1.5) ]
                ["flexShrink" ==> "1.5"]

            test
                "FlexShrink inherit"
                [ FlexShrink Inherit]
                ["flexShrink" ==> "inherit"]

            test
                "FlexShrink initial"
                [ FlexShrink Initial]
                ["flexShrink" ==> "initial"]

            test
                "FlexShrink unset"
                [ FlexShrink Unset]
                ["flexShrink" ==> "unset"]
        ]

let positionTests =
    testList "Position"
        [
                test
                    "Vertical align baseline"
                    [ VerticalAlign (VerticalAlign.Baseline)]
                    ["verticalAlign" ==> "baseline"]

                test
                    "Vertical align sub"
                    [ VerticalAlign (VerticalAlign.Sub)]
                    ["verticalAlign" ==> "sub"]

                test
                    "Vertical align super"
                    [ VerticalAlign (VerticalAlign.Super)]
                    ["verticalAlign" ==> "super"]

                test
                    "Vertical align text top"
                    [ VerticalAlign (VerticalAlign.TextTop)]
                    ["verticalAlign" ==> "text-top"]

                test
                    "Vertical align text bottom"
                    [ VerticalAlign (VerticalAlign.TextBottom)]
                    ["verticalAlign" ==> "text-bottom"]

                test
                    "Vertical align middle"
                    [ VerticalAlign (VerticalAlign.Middle)]
                    ["verticalAlign" ==> "middle"]

                test
                    "Vertical align top"
                    [ VerticalAlign (VerticalAlign.Top)]
                    ["verticalAlign" ==> "top"]

                test
                    "Vertical align bottom"
                    [ VerticalAlign (VerticalAlign.Bottom)]
                    ["verticalAlign" ==> "bottom"]

                test
                    "Vertical align px"
                    [ VerticalAlign (px 10)]
                    ["verticalAlign" ==> "10px"]

                test
                    "Vertical align percent"
                    [ VerticalAlign (pct 100)]
                    ["verticalAlign" ==> "100%"]

                test
                    "Vertical align  inherit"
                    [ VerticalAlign Inherit ]
                    ["verticalAlign" ==> "inherit"]

                test
                    "Vertical align initial"
                    [ VerticalAlign Initial ]
                    ["verticalAlign" ==> "initial"]

                test
                    "Vertical align unset"
                    [ VerticalAlign Unset ]
                    ["verticalAlign" ==> "unset"]

                test
                    "Position static"
                    [ Position Position.Static]
                    ["position" ==> "static"]

                test
                    "Position relative"
                    [ Position Position.Relative]
                    ["position" ==> "relative"]

                test
                    "Position absolute"
                    [ Position Position.Absolute]
                    ["position" ==> "absolute"]

                test
                    "Position sticky"
                    [ Position Position.Sticky]
                    ["position" ==> "sticky"]

                test
                    "Position fixed"
                    [ Position Position.Fixed]
                    ["position" ==> "fixed"]
        ]

let visibilityTests =
    testList "Visibility" [
            test
                "Visibility hidden"
                [ Visibility Visibility.Hidden]
                ["visibility" ==> "hidden"]

            test
                "Visibility collapse"
                [ Visibility Visibility.Collapse]
                ["visibility" ==> "collapse"]

            test
                "Visibility visible"
                [ Visibility Visibility.Visible]
                ["visibility" ==> "visible"]

            test
                "Opacity 1"
                [ Opacity (Opacity.Opacity 1.0) ]
                ["opacity" ==> "1"]

            test
                "Opacity 0"
                [ Opacity (Opacity.Opacity 0.0)]
                ["opacity" ==> "0"]

            test
                "Opacity 50%"
                [ Opacity (Opacity.Opacity 0.5)]
                ["opacity" ==> "0.5"]

            test
                "Opacity -10 should be 0"
                [ Opacity (Opacity.Opacity -10.0)]
                ["opacity" ==> "0"]

            test
                "Opacity 10 should be 1"
                [ Opacity (Opacity.Opacity 10.0)]
                ["opacity" ==> "1"]

            test
                "Opacity 1.5 should be 1"
                [ Opacity (Opacity.Opacity 1.5)]
                ["opacity" ==> "1"]
    ]

let marginTests =
    testList "Margin"
        [
                test
                    "Margin top px"
                    [ MarginTop (px 10)]
                    ["marginTop" ==> "10px"]

                test
                    "Margin right px"
                    [ MarginRight (px 10)]
                    ["marginRight" ==> "10px"]

                test
                    "Margin bottom px"
                    [ MarginBottom (px 10)]
                    ["marginBottom" ==> "10px"]

                test
                    "Margin left px"
                    [ MarginLeft (px 10)]
                    ["marginLeft" ==> "10px"]

                test
                    "Margin px"
                    [ Margin (px 10)]
                    [ "margin" ==> "10px" ]

                test
                    "Margin pct"
                    [ Margin (pct 10)]
                    [ "margin" ==> "10%" ]

                test
                    "Margin em"
                    [ Margin (em 10.0)]
                    [ "margin" ==> "10.0em" ]

                test
                    "Margin auto"
                    [ Margin Auto]
                    [ "margin" ==> "auto" ]

                test
                    "Margin inherit"
                    [ Margin Inherit]
                    [ "margin" ==> "inherit" ]

                test
                    "Margin initial"
                    [ Margin Initial]
                    [ "margin" ==> "initial" ]

                test
                    "Margin unset"
                    [ Margin Unset ]
                    [ "margin" ==> "unset" ]

                test
                    "Margins multiple"
                    [ Margins [ px 10; px 20; px 30; px 40 ] ]
                    [ "margin" ==> "10px 20px 30px 40px" ]
        ]

let paddingTests =
    testList "Padding"
        [
                test
                    "Padding top px"
                    [ PaddingTop (px 10)]
                    ["paddingTop" ==> "10px"]

                test
                    "Padding right px"
                    [ PaddingRight (px 10)]
                    ["paddingRight" ==> "10px"]

                test
                    "Padding bottom px"
                    [ PaddingBottom (px 10)]
                    ["paddingBottom" ==> "10px"]

                test
                    "Padding left px"
                    [ PaddingLeft (px 10)]
                    ["paddingLeft" ==> "10px"]

                test
                    "Padding px"
                    [ Padding (px 10)]
                    [ "padding" ==> "10px" ]

                test
                    "Padding pct"
                    [ Padding (pct 10)]
                    [ "padding" ==> "10%" ]

                test
                    "Padding em"
                    [ Padding (em 10.0)]
                    [ "padding" ==> "10.0em" ]

                test
                    "Padding auto"
                    [ Padding Auto]
                    [ "padding" ==> "auto" ]

                test
                    "Padding inherit"
                    [ Padding Inherit]
                    [ "padding" ==> "inherit" ]

                test
                    "Padding initial"
                    [ Padding Initial]
                    [ "padding" ==> "initial" ]

                test
                    "Padding unset"
                    [ Padding Unset ]
                    [ "padding" ==> "unset" ]

                test
                    "Paddings multiple"
                    [ Paddings [ px 10; px 20; px 30; px 40 ] ]
                    [ "padding" ==> "10px 20px 30px 40px" ]
        ]

let animationTests =
    let animationSample = keyframes [ frame 0 [ BackgroundColor Color.red ]; frame 100 [ BackgroundColor Color.blue ] ]

    testList "Animation"
        [
            test
                "Animation name"
                [ AnimationName animationSample ]
                [ "animationName" ==> animationSample ]

            test
                "Animation name inherit"
                [ AnimationName Inherit ]
                [ "animationName" ==> "inherit" ]

            test
                "Animation name"
                [ AnimationName Initial ]
                [ "animationName" ==> "initial" ]

            test
                "Animation name"
                [ AnimationName Unset ]
                [ "animationName" ==> "unset" ]

            test
                "Animation duration"
                [ AnimationDuration (sec 10.0) ]
                [ "animationDuration" ==> "10.00s" ]

            test
                "Animation duration seconds"
                [ AnimationDuration (sec 10.0) ]
                [ "animationDuration" ==> "10.00s" ]

            test
                "Animation duration milliseconds"
                [ AnimationDuration (ms 10.0) ]
                [ "animationDuration" ==> "10.00ms" ]

            test
                "Animation duration multiple"
                [ AnimationDurations [ sec 10.0; ms 500.0 ] ]
                [ "animationDuration" ==> "10.00s, 500.00ms" ]

            test
                "Animation timing function ease"
                [ AnimationTimingFunction Animation.Ease ]
                ["animationTimingFunction" ==> "ease"]

            test
                "Animation timing function ease in"
                [ AnimationTimingFunction Animation.EaseIn ]
                ["animationTimingFunction" ==> "ease-in"]

            test
                "Animation timing function ease out"
                [ AnimationTimingFunction Animation.EaseOut ]
                ["animationTimingFunction" ==> "ease-out"]

            test
                "Animation timing function ease in out"
                [ AnimationTimingFunction Animation.EaseInOut ]
                ["animationTimingFunction" ==> "ease-in-out"]

            test
                "Animation timing function linear"
                [ AnimationTimingFunction Animation.Linear ]
                ["animationTimingFunction" ==> "linear"]

            test
                "Animation timing function step start"
                [ AnimationTimingFunction Animation.StepStart ]
                ["animationTimingFunction" ==> "step-start"]

            test
                "Animation timing function step end"
                [ AnimationTimingFunction Animation.StepEnd ]
                ["animationTimingFunction" ==> "step-end"]

            test
                "Animation timing function cubic bezier"
                [ AnimationTimingFunction (Animation.CubicBezier(0.0, 0.47, 0.32, 1.97)) ]
                ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]

            test
                "Animation timing function  step"
                [ AnimationTimingFunction (Animation.Step 5) ]
                ["animationTimingFunction" ==> "steps(5)"]

            test
                "Animation timing function  step jump start"
                [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpStart)) ]
                ["animationTimingFunction" ==> "steps(5, jump-start)"]

            test
                "Animation timing function step jump end"
                [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpEnd)) ]
                ["animationTimingFunction" ==> "steps(5, jump-end)"]

            test
                "Animation timing function step jump none"
                [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpNone)) ]
                ["animationTimingFunction" ==> "steps(5, jump-none)"]

            test
                "Animation timing function step jump both"
                [ AnimationTimingFunction (Animation.Steps(5, Animation.JumpBoth)) ]
                ["animationTimingFunction" ==> "steps(5, jump-both)"]

            test
                "Animation timing function step start"
                [ AnimationTimingFunction (Animation.Steps(5, Animation.Start)) ]
                ["animationTimingFunction" ==> "steps(5, start)"]

            test
                "Animation timing function step end"
                [ AnimationTimingFunction (Animation.Steps(5, Animation.End)) ]
                ["animationTimingFunction" ==> "steps(5, end)"]

            test
                "Animation timing function inherit"
                [ AnimationTimingFunction Inherit ]
                ["animationTimingFunction" ==> "inherit"]

            test
                "Animation timing function initial"
                [ AnimationTimingFunction Initial ]
                ["animationTimingFunction" ==> "initial"]

            test
                "Animation timing function unset"
                [ AnimationTimingFunction Unset ]
                ["animationTimingFunction" ==> "unset"]

            test
                "Animation delay sec"
                [ AnimationDelay (sec 10.0) ]
                ["animationDelay" ==> "10.00s"]
            test
                "Animation delay multiple"
                [ AnimationDelays [sec 10.0; ms 500.0] ]
                ["animationDelay" ==> "10.00s, 500.00ms"]

            test
                "Animation iteration count infininte"
                [ AnimationIterationCount Animation.Infinite ]
                ["animationIterationCount" ==> "infinite"]

            test
                "Animation iteration count value"
                [ AnimationIterationCount (Animation.Value 5) ]
                ["animationIterationCount" ==> "5"]

            test
                "Animation iteration count multiple"
                [ AnimationIterationCounts [Animation.Infinite; Animation.Value 5] ]
                ["animationIterationCount" ==> "infinite, 5"]

            test
                "Animation direction normal"
                [ AnimationDirection Animation.Normal ]
                ["animationDirection" ==> "normal"]

            test
                "Animation direction reverse"
                [ AnimationDirection Animation.Reverse ]
                ["animationDirection" ==> "reverse"]

            test
                "Animation direction alternate"
                [ AnimationDirection Animation.Alternate ]
                ["animationDirection" ==> "alternate"]

            test
                "Animation direction alternate reverse"
                [ AnimationDirection Animation.AlternateReverse ]
                ["animationDirection" ==> "alternate-reverse"]

            test
                "Animation direction inherit"
                [ AnimationDirection Inherit ]
                ["animationDirection" ==> "inherit"]

            test
                "Animation direction initial"
                [ AnimationDirection Initial ]
                ["animationDirection" ==> "initial"]

            test
                "Animation direction unset"
                [ AnimationDirection Unset ]
                ["animationDirection" ==> "unset"]

            test
                "Animation fill mode forwards"
                [ AnimationFillMode Animation.Forwards ]
                ["animationFillMode" ==> "forwards"]

            test
                "Animation fill mode backwards"
                [ AnimationFillMode Animation.Backwards ]
                ["animationFillMode" ==> "backwards"]

            test
                "Animation fill mode both"
                [ AnimationFillMode Animation.Both ]
                ["animationFillMode" ==> "both"]

            test
                "Animation fill mode none"
                [ AnimationFillMode Animation.None ]
                ["animationFillMode" ==> "none"]

            test
                "Animation fill mode multiple"
                [ AnimationFillModes [ Animation.Forwards; Animation.Backwards ]]
                ["animationFillMode" ==> "forwards, backwards"]

            test
                "Animation play state running"
                [ AnimationPlayState Animation.Running ]
                ["animationPlayState" ==> "running"]

            test
                "Animation play state paused"
                [ AnimationPlayState Animation.Paused ]
                ["animationPlayState"  ==> "paused"]

            test
                "Animation play state"
                [ AnimationPlayStates [ Animation.Running; Animation.Paused] ]
                ["animationPlayState"==> "running, paused"]

            test
                "Animation play state inherit"
                [ AnimationPlayState Inherit ]
                ["animationPlayState" ==> "inherit"]

            test
                "Animation play state initial"
                [ AnimationPlayState Initial ]
                ["animationPlayState"  ==> "initial"]

            test
                "Animation play state unset"
                [ AnimationPlayState Unset ]
                ["animationPlayState" ==> "unset"]

        ]

let transformTests =
    testList "transform"
        [
            test
                "Transform none"
                [ Transform Transform.None ]
                [ "transform" ==> "none" ]

            test
                "Transform matrix"
                [ Transform (Transform.Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)) ]
                [ "transform" ==> "matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)" ]

            test
                "Transform matrix3d"
                [ Transform (Transform.Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0., 0., 0., 1.)) ]
                [ "transform" ==> "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0.0, 0.0, 0.0, 1.0)" ]

            test
                "Transform perspective"
                [ Transform (Transform.Perspective(px 17)) ]
                [ "transform" ==> "perspective(17px)" ]

            test
                "Transform rotate"
                [ Transform (Transform.Rotate(turn 0.5)) ]
                [ "transform" ==> "rotate(0.50turn)" ]

            test
                "Transform rotate3d"
                [ Transform (Transform.Rotate3D(1.0, 2.0, 3.0, (deg 10.0))) ]
                [ "transform" ==> "rotate3d(1.0, 2.0, 3.0, 10.00deg)" ]

            test
                "Transform rotate x"
                [ Transform (Transform.RotateX(deg 10.0)) ]
                [ "transform" ==> "rotateX(10.00deg)" ]

            test
                "Transform rotate y"
                [ Transform (Transform.RotateY(grad 360.0)) ]
                [ "transform" ==> "rotateY(360.00grad)" ]

            test
                "Transform rotate y"
                [ Transform (Transform.RotateZ(rad 1.5)) ]
                [ "transform" ==> "rotateZ(1.5000rad)" ]

            test
                "Transform translate"
                [ Transform (Transform.Translate(px 12)) ]
                [ "transform" ==> "translate(12px)" ]

            test
                "Transform translate2"
                [ Transform (Transform.Translate2((px 12), (pct 50))) ]
                [ "transform" ==> "translate(12px, 50%)" ]

            test
                "Transform translate3d"
                [ Transform (Transform.Translate3D((px 12), (pct 50), (em 3.0))) ]
                [ "transform" ==> "translate3d(12px, 50%, 3.0em)" ]

            test
                "Transform translate x"
                [ Transform (Transform.TranslateX(px 10)) ]
                [ "transform" ==> "translateX(10px)" ]

            test
                "Transform translate y"
                [ Transform (Transform.TranslateY(em 3.0)) ]
                [ "transform" ==> "translateY(3.0em)" ]

            test
                "Transform translate z"
                [ Transform (Transform.TranslateZ(rem 3.0)) ]
                [ "transform" ==> "translateZ(3.0rem)" ]

            test
                "Transform scale"
                [ Transform (Transform.Scale(0.5)) ]
                [ "transform" ==> "scale(0.50)" ]

            test
                "Transform scale2"
                [ Transform (Transform.Scale2(0.5, 0.5)) ]
                [ "transform" ==> "scale(0.50, 0.50)" ]

            test
                "Transform translate3d"
                [ Transform (Transform.Scale3D(0.1, 0.2, 0.3)) ]
                [ "transform" ==> "scale3d(0.10, 0.20, 0.30)" ]

            test
                "Transform scale x"
                [ Transform (Transform.ScaleX(0.9)) ]
                [ "transform" ==> "scaleX(0.90)" ]

            test
                "Transform scale y"
                [ Transform (Transform.ScaleY(2.3)) ]
                [ "transform" ==> "scaleY(2.30)" ]

            test
                "Transform scale z"
                [ Transform (Transform.ScaleZ(3.4)) ]
                [ "transform" ==> "scaleZ(3.40)" ]

            test
                "Transform skew"
                [ Transform (Transform.Skew(deg 270.)) ]
                [ "transform" ==> "skew(270.00deg)" ]

            test
                "Transform scale2"
                [ Transform (Transform.Skew2((turn 0.5), (deg 10.0))) ]
                [ "transform" ==> "skew(0.50turn, 10.00deg)" ]

            test
                "Transform skew x"
                [ Transform (Transform.SkewX(rad 9.)) ]
                [ "transform" ==> "skewX(9.0000rad)" ]

            test
                "Transform skew y"
                [ Transform (Transform.SkewY(deg 50.0)) ]
                [ "transform" ==> "skewY(50.00deg)" ]


            test
                "Transform inherit"
                [ Transform Inherit ]
                [ "transform" ==> "inherit" ]

            test
                "Transform initial"
                [ Transform Initial ]
                [ "transform" ==> "initial" ]

            test
                "Transform unset"
                [ Transform Unset ]
                [ "transform" ==> "unset" ]
        ]

let tests =
        testList "Fss Tests" [
            transformTests
            animationTests
            paddingTests
            marginTests
            visibilityTests
            positionTests
            flexTests
            displayTests
            perspectiveTests
            contentSizeTests
            borderTests
            fontTests
            colorTests
            backgroundTests
        ]

Mocha.runTests tests |> ignore

(*
test "Transform"
    [
        (fss [TransformOrigin [ TransformOrigin.Left ]]), ["transform-origin", "0px 0px"]
        (fss [TransformOrigin [ TransformOrigin.Center ]]), ["transform-origin", "200px 0px"]
        (fss [TransformOrigin [ TransformOrigin.Right ]]), ["transform-origin", "400px 0px"]
        (fss [TransformOrigin [ TransformOrigin.Top ]]), ["transform-origin", "200px 0px"]
        (fss [TransformOrigin [ TransformOrigin.Bottom ]]), ["transform-origin", "200px 0px"]

        (fss [TransformOrigin [ TransformOrigin.Top; TransformOrigin.Left ]]), ["transform-origin", "0px 0px"]
        (fss [TransformOrigin [ TransformOrigin.Top; TransformOrigin.Left; px 100 ]]), ["transform-origin", "0px 0px 100px"]

        (fss [TransformOrigin [ px 100 ]]), ["transform-origin", "100px 0px"]
        (fss [TransformOrigin [ pct 50 ]]), ["transform-origin", "200px 0px"]
    ]

test "Transition"
    [
        (fss [ Transition (Transition1(backgroundColor, (sec 10.0))) ]),
            [
                "transition-property", "background-color"
                "transition-duration", "10s"
            ]

        (fss [ Transition (Transition2(backgroundColor, (sec 10.0), Ease)) ]),
            [
                "transition-property", "background-color"
                "transition-duration", "10s"
                "transition-timing-function", "ease"
            ]

        (fss [ Transition (Transition3(backgroundColor, (sec 10.0), Ease, sec 2.0)) ]),
            [
                "transition-property", "background-color"
                "transition-duration", "10s"
                "transition-timing-function", "ease"
                "transition-delay", "2s"
            ]

        (fss
            [
                Transitions
                    [
                        Transition1(backgroundColor, (sec 10.0))
                        Transition2(color, (sec 20.0), EaseInOut)
                        Transition3(width, (sec 30.0), EaseOut, (sec 20.0))
                    ]
            ]),
            [
                "transition-property", "background-color, color, width"
                "transition-duration", "10s, 20s, 30s"
                "transition-timing-function", "ease, ease-in-out, ease-out"
                "transition-delay", "0s, 0s, 20s"
            ]

        (fss [ TransitionDelay (sec 5.0)]), ["transition-delay", "5s"]

        (fss [ TransitionDuration (sec 5.0)]), ["transition-duration", "5s"]

        (fss [ TransitionProperty Property.Width]), ["transition-property", "width"]

        (fss [ TransitionTimingFunction EaseInOut]), ["transition-timing-function", "ease-in-out"]
    ]

testCase "Descendants" <| fun _ ->

    let style =
        fss
            [
                ! P
                    [
                        BackgroundColor red
                    ]
            ]

    RTL.render(
        fragment []
            [
                div [ ClassName style] [
                    p [ Id "p1" ] [ str "Apple"]
                    div [] [ p [ Id "p2" ] [str "An apple a day keeps the doctor away"]]
                    p [ Id "p3" ] [ str "Banana"]
                    p [ Id "p4" ] [ str "Cherry"]
                ]
            ]) |> ignore

    let p1 = getComputedCssById("p1")
    let p2 = getComputedCssById("p2")
    let p3 = getComputedCssById("p3")
    let p4 = getComputedCssById("p4")
    Expect.equal (getValue p1 "background-color") "rgb(255, 0, 0)" "Descendant selector"
    Expect.equal (getValue p2 "background-color") "rgb(255, 0, 0)" "Descendant selector"
    Expect.equal (getValue p3 "background-color") "rgb(255, 0, 0)" "Descendant selector"
    Expect.equal (getValue p4 "background-color") "rgb(255, 0, 0)" "Descendant selector"
    RTL.cleanup()

testCase "Child" <| fun _ ->

    let style =
        fss
            [
                !> P
                    [
                        BackgroundColor green
                    ]
            ]

    RTL.render(
        fragment []
            [
                div [ ClassName style] [
                    p [ Id "p1" ] [ str "Apple"]
                    div [] [ p [] [str "An apple a day keeps the doctor away"]]
                    p [ Id "p2" ] [ str "Banana"]
                    p [ Id "p3" ] [ str "Cherry"]
                ]
            ]) |> ignore

    let p1 = getComputedCssById("p1")
    let p2 = getComputedCssById("p2")
    let p3 = getComputedCssById("p3")
    Expect.equal (getValue p1 "background-color") "rgb(0, 128, 0)" "Child selector"
    Expect.equal (getValue p2 "background-color") "rgb(0, 128, 0)" "Child selector"
    Expect.equal (getValue p3 "background-color") "rgb(0, 128, 0)" "Child selector"
    RTL.cleanup()

testCase "Adjacent sibling" <| fun _ ->

    let style =
        fss
            [
                !> P
                    [
                        BackgroundColor green
                    ]
            ]

    RTL.render(
        fragment []
            [
                div [ ClassName style] [
                    p [ ] [ str "Apple"]
                    div [] [ p [] [str "An apple a day keeps the doctor away"]]
                    p [ Id "p1" ] [ str "Banana"]
                    p [ ] [ str "Cherry"]
                ]
            ]) |> ignore

    let p1 = getComputedCssById("p1")
    Expect.equal (getValue p1 "background-color") "rgb(0, 128, 0)" "Adjacent sibling selector"
    RTL.cleanup()

testCase "General sibling" <| fun _ ->
    let style =
        fss
            [
                !~ P
                    [
                        BackgroundColor green
                    ]
            ]

    RTL.render(
        fragment []
            [
                div [] [
                    p [] [ str "Apple"]
                    div [ ClassName style ] [ p [] [str "An apple a day keeps the doctor away"]]
                    p [ Id "p1" ] [ str "Banana"]
                    p [ Id "p2" ] [ str "Cherry"]
                ]
            ]) |> ignore

    let p1 = getComputedCssById("p1")
    let p2 = getComputedCssById("p2")
    Expect.equal (getValue p1 "background-color") "rgb(0, 128, 0)" "General sibling selector"
    Expect.equal (getValue p2 "background-color") "rgb(0, 128, 0)" "General sibling selector"
    RTL.cleanup()

testCase "Composed selector" <| fun _ ->
    let style =
        fss
            [
                ! Div
                    [
                        !> Div
                            [
                                !> P
                                    [
                                        !+ P
                                            [
                                                Color purple
                                                FontSize (px 25)
                                            ]
                                    ]
                            ]

                    ]
            ]

    RTL.render(
        fragment []
            [
                div [ ClassName style ]
                     [
                         div []
                             [
                                 div []
                                     [
                                         p [] [ str "Hi" ]
                                         p [ Id "p1"] [ str "Hi" ]
                                     ]
                             ]
                     ]
            ]) |> ignore

    let p1 = getComputedCssById("p1")
    Expect.equal (getValue p1 "color") "rgb(128, 0, 128)" "Composed selectors"
    Expect.equal (getValue p1 "font-size") "25px" "Composed selectors"
    RTL.cleanup()

test "Text"
    [
        (fss [ TextAlign TextAlign.Left ]), ["text-align", "left"]
        (fss [ TextAlign TextAlign.Right ]), ["text-align", "right"]
        (fss [ TextAlign TextAlign.Center ]), ["text-align", "center"]
        (fss [ TextAlign TextAlign.Justify ]), ["text-align", "justify"]
        (fss [ TextAlign TextAlign.JustifyAll ]), ["text-align", "start"]
        (fss [ TextAlign TextAlign.Start ]), ["text-align", "start"]
        (fss [ TextAlign TextAlign.End ]), ["text-align", "end"]
        (fss [ TextAlign TextAlign.MatchParent ]), ["text-align", "left"]

        (fss [ TextDecorationLine Underline ]), ["text-decoration", "underline rgb(0, 0, 0)"]
        (fss [ TextDecorationLine Overline ]), ["text-decoration", "overline rgb(0, 0, 0)"]
        (fss [ TextDecorationLine LineThrough ]), ["text-decoration", "line-through rgb(0, 0, 0)"]
        (fss [ TextDecorationLines [Underline; Overline; LineThrough] ]), ["text-decoration", "underline overline line-through rgb(0, 0, 0)"]

        (fss [ TextDecorationColor orangeRed; TextDecorationLines [Underline; Overline; LineThrough] ]), ["text-decoration", "underline overline line-through rgb(255, 69, 0)"]

        (fss [ TextDecorationThickness Auto  ]), ["text-decoration-thickness", "auto"]
        (fss [ TextDecorationThickness FromFont  ]), ["text-decoration-thickness", "from-font"]
        (fss [ TextDecorationThickness (pct 30)  ]), ["text-decoration-thickness", "30%"]
        (fss [ TextDecorationThickness (px 150)  ]), ["text-decoration-thickness", "150px"]

        (fss [ TextDecorationThickness (px 150)  ]), ["text-decoration-thickness", "150px"]

        (fss [ TextDecorationLine Underline; TextDecorationStyle TextDecorationStyle.Solid]), ["text-decoration-style", "solid"]
        (fss [ TextDecorationLine Underline; TextDecorationStyle TextDecorationStyle.Double]), ["text-decoration-style", "double"]
        (fss [ TextDecorationLine Underline; TextDecorationStyle TextDecorationStyle.Dotted]), ["text-decoration-style", "dotted"]
        (fss [ TextDecorationLine Underline; TextDecorationStyle TextDecorationStyle.Dashed]), ["text-decoration-style", "dashed"]
        (fss [ TextDecorationLine Underline; TextDecorationStyle TextDecorationStyle.Wavy]), ["text-decoration-style", "wavy"]

        (fss [ TextDecorationSkipInk TextDecorationSkipInk.All ]), ["text-decoration-skip-ink", "all"]
        (fss [ TextDecorationSkipInk TextDecorationSkipInk.Auto ]), ["text-decoration-skip-ink", "auto"]
        (fss [ TextDecorationSkipInk TextDecorationSkipInk.None ]), ["text-decoration-skip-ink", "none"]

        (fss [ TextTransform Capitalize ]), ["text-transform", "capitalize"]
        (fss [ TextTransform Uppercase ]), ["text-transform", "uppercase"]
        (fss [ TextTransform Lowercase ]), ["text-transform", "lowercase"]
        (fss [ TextTransform TextTransform.None ]), ["text-transform", "none"]
        (fss [ TextTransform FullWidth ]), ["text-transform", "none"]
        (fss [ TextTransform FullSizeKana ]), ["text-transform", "none"]

        (fss [ TextIndent (px 10) ]), ["text-indent", "10px"]
        (fss [ TextIndent (pct 100) ]), ["text-indent", "100%"]
        // These are not supported?
        // (fss [ TextIndents [px 10; (TextIndent.EachLine)] ]), ["text-indent", "each-line"]
        // (fss [ TextIndents [px 10; (TextIndent.Hanging)] ]), ["text-indent", "hanging"]

        (fss [ Functions.TextShadow (px 10) (px 5) (px 15) red ]), ["text-shadow", "rgb(255, 0, 0) 10px 5px 15px"]
        (fss [ Functions.TextShadows
            [
                px  -4, px 3, px 0, hex "#3a50d9"
                px -14, px 7, px 0, hex "#0a0e27"
            ]]), ["text-shadow", "rgb(58, 80, 217) -4px 3px 0px, rgb(10, 14, 39) -14px 7px 0px"]

        (fss [ TextOverflow TextOverflow.Clip ]), ["text-overflow", "clip"]
        (fss [ TextOverflow TextOverflow.Ellipsis ]), ["text-overflow", "ellipsis"]
        (fss [ TextOverflow (TextOverflow.Custom "-") ]), ["text-overflow", "\"-\" "]
    ]

]

Mocha.runTests CssTests |> ignore

Mocha.runTests tests |> ignore
*)
