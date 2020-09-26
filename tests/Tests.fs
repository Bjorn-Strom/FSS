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
                ""
                [ FontFeatureSetting (Font.Liga Font.On) ]
                [ "fontFeatureSettings" ==> "\"liga\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Liga Font.Off) ]
                [ "fontFeatureSettings" ==> "\"liga\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Dlig Font.On) ]
                [ "fontFeatureSettings" ==> "\"dlig\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Dlig Font.Off) ]
                [ "fontFeatureSettings" ==> "\"dlig\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Onum Font.On) ]
                [ "fontFeatureSettings" ==> "\"onum\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Onum Font.Off) ]
                [ "fontFeatureSettings" ==> "\"onum\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Lnum Font.On) ]
                [ "fontFeatureSettings" ==> "\"lnum\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Lnum Font.Off) ]
                [ "fontFeatureSettings" ==> "\"lnum\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Tnum Font.On) ]
                [ "fontFeatureSettings" ==> "\"tnum\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Tnum Font.Off) ]
                [ "fontFeatureSettings" ==> "\"tnum\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Zero Font.On) ]
                [ "fontFeatureSettings" ==> "\"zero\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Zero Font.Off) ]
                [ "fontFeatureSettings" ==> "\"zero\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Frac Font.On) ]
                [ "fontFeatureSettings" ==> "\"frac\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Frac Font.Off) ]
                [ "fontFeatureSettings" ==> "\"frac\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Sups Font.On) ]
                [ "fontFeatureSettings" ==> "\"sups\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Sups Font.Off) ]
                [ "fontFeatureSettings" ==> "\"sups\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Subs Font.On) ]
                [ "fontFeatureSettings" ==> "\"subs\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Subs Font.Off) ]
                [ "fontFeatureSettings" ==> "\"subs\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Smcp Font.On) ]
                [ "fontFeatureSettings" ==> "\"smcp\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Smcp Font.Off) ]
                [ "fontFeatureSettings" ==> "\"smcp\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.C2sc Font.On) ]
                [ "fontFeatureSettings" ==> "\"c2sc\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.C2sc Font.Off) ]
                [ "fontFeatureSettings" ==> "\"c2sc\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Case Font.On) ]
                [ "fontFeatureSettings" ==> "\"case\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Case Font.Off) ]
                [ "fontFeatureSettings" ==> "\"case\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Hlig Font.On) ]
                [ "fontFeatureSettings" ==> "\"hlig\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Hlig Font.Off) ]
                [ "fontFeatureSettings" ==> "\"hlig\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Calt Font.On) ]
                [ "fontFeatureSettings" ==> "\"calt\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Calt Font.Off) ]
                [ "fontFeatureSettings" ==> "\"calt\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Swsh Font.On) ]
                [ "fontFeatureSettings" ==> "\"swsh\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Swsh Font.Off) ]
                [ "fontFeatureSettings" ==> "\"swsh\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Hist Font.On) ]
                [ "fontFeatureSettings" ==> "\"hist\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Hist Font.Off) ]
                [ "fontFeatureSettings" ==> "\"hist\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Ss (1, Font.On)) ]
                [ "fontFeatureSettings" ==> "\"ss01\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Ss (20, Font.Off)) ]
                [ "fontFeatureSettings" ==> "\"ss20\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Kern Font.On) ]
                [ "fontFeatureSettings" ==> "\"kern\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Kern Font.Off) ]
                [ "fontFeatureSettings" ==> "\"kern\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Locl Font.On) ]
                [ "fontFeatureSettings" ==> "\"locl\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Locl Font.Off) ]
                [ "fontFeatureSettings" ==> "\"locl\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Rlig Font.On) ]
                [ "fontFeatureSettings" ==> "\"rlig\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Rlig Font.Off) ]
                [ "fontFeatureSettings" ==> "\"rlig\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Medi Font.On) ]
                [ "fontFeatureSettings" ==> "\"medi\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Medi Font.Off) ]
                [ "fontFeatureSettings" ==> "\"medi\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Init Font.On) ]
                [ "fontFeatureSettings" ==> "\"init\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Init Font.Off) ]
                [ "fontFeatureSettings" ==> "\"init\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Isol Font.On) ]
                [ "fontFeatureSettings" ==> "\"isol\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Isol Font.Off) ]
                [ "fontFeatureSettings" ==> "\"isol\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Fina Font.On) ]
                [ "fontFeatureSettings" ==> "\"fina\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Fina Font.Off) ]
                [ "fontFeatureSettings" ==> "\"fina\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Mark Font.On) ]
                [ "fontFeatureSettings" ==> "\"mark\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Mark Font.Off) ]
                [ "fontFeatureSettings" ==> "\"mark\" Off" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Mkmk Font.On) ]
                [ "fontFeatureSettings" ==> "\"mkmk\" On" ]
                
            test
                ""
                [ FontFeatureSetting (Font.Mkmk Font.Off) ]
                [ "fontFeatureSettings" ==> "\"mkmk\" Off" ]
                    

            test
                ""
                [
                    FontFeatureSettings
                        [
                            Font.Smcp Font.On
                            Font.Onum Font.On
                        ]
                ]
                [ "fontFeatureSettings" ==> "\"smcp\" On, \"onum\" On" ]

            test
                ""
                [
                    FontFeatureSettings
                        [
                            Font.Smcp Font.Off
                            Font.Onum Font.Off
                        ]
                    ]
                [ "fontFeatureSettings" ==> "\"smcp\" Off, \"onum\" Off" ]
                
                
             
        ]

let tests =
        testList "Fss Tests" [
            fontTests 
            colorTests 
            backgroundTests
        ]
        
Mocha.runTests tests |> ignore



(*
                (fss [ FontVariantNumeric FontVariantNumeric.Normal] ), ["font-variant-numeric", "normal"]
                (fss [ FontVariantNumeric FontVariantNumeric.Ordinal] ), ["font-variant-numeric", "ordinal"]
                (fss [ FontVariantNumeric FontVariantNumeric.SlashedZero] ), ["font-variant-numeric", "slashed-zero"]
                (fss [ FontVariantNumeric FontVariantNumeric.LiningNums] ), ["font-variant-numeric", "lining-nums"]
                (fss [ FontVariantNumeric FontVariantNumeric.OldstyleNums] ), ["font-variant-numeric", "oldstyle-nums"]
                (fss [ FontVariantNumeric FontVariantNumeric.TabularNums] ), ["font-variant-numeric", "tabular-nums"]
                (fss [ FontVariantNumeric FontVariantNumeric.DiagonalFractions] ), ["font-variant-numeric", "diagonal-fractions"]
                (fss [ FontVariantNumeric FontVariantNumeric.StackedFractions] ), ["font-variant-numeric", "stacked-fractions"]
                (fss [ FontVariantNumerics
                    [
                        FontVariantNumeric.OldstyleNums
                        FontVariantNumeric.StackedFractions
                    ]] ), ["font-variant-numeric", "oldstyle-nums stacked-fractions"]

                (fss [ FontVariantCaps FontVariantCaps.Normal] ), ["font-variant-caps", "normal"]
                (fss [ FontVariantCaps FontVariantCaps.SmallCaps] ), ["font-variant-caps", "small-caps"]
                (fss [ FontVariantCaps FontVariantCaps.AllSmallCaps] ), ["font-variant-caps", "all-small-caps"]
                (fss [ FontVariantCaps FontVariantCaps.PetiteCaps] ), ["font-variant-caps", "petite-caps"]
                (fss [ FontVariantCaps FontVariantCaps.AllPetiteCaps] ), ["font-variant-caps", "all-petite-caps"]
                (fss [ FontVariantCaps FontVariantCaps.Unicase] ), ["font-variant-caps", "unicase"]
                (fss [ FontVariantCaps FontVariantCaps.TitlingCaps] ), ["font-variant-caps", "titling-caps"]

                (fss [ FontVariantEastAsian FontVariantEastAsian.Normal]), ["font-variant-east-asian", "normal"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Ruby]), ["font-variant-east-asian", "ruby"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Jis78]), ["font-variant-east-asian", "jis78"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Jis83]), ["font-variant-east-asian", "jis83"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Jis90]), ["font-variant-east-asian", "jis90"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Jis04]), ["font-variant-east-asian", "jis04"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Simplified]), ["font-variant-east-asian", "simplified"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.Traditional]), ["font-variant-east-asian", "traditional"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.FullWidth]), ["font-variant-east-asian", "full-width"]
                (fss [ FontVariantEastAsian FontVariantEastAsian.ProportionalWidth]), ["font-variant-east-asian", "proportional-width"]
                (fss [ FontVariantEastAsians
                    [
                        FontVariantEastAsian.Ruby
                        FontVariantEastAsian.FullWidth
                        FontVariantEastAsian.Jis83
                    ]]), ["font-variant-east-asian", "jis83 full-width ruby"]

                (fss [ FontVariantLigatures FontVariantLigatures.Normal]), ["font-variant-ligatures", "normal"]
                (fss [ FontVariantLigatures FontVariantLigatures.None]), ["font-variant-ligatures", "none"]
                (fss [ FontVariantLigatures FontVariantLigatures.CommonLigatures]), ["font-variant-ligatures", "common-ligatures"]
                (fss [ FontVariantLigatures FontVariantLigatures.NoCommonLigatures]), ["font-variant-ligatures", "no-common-ligatures"]
                (fss [ FontVariantLigatures FontVariantLigatures.DiscretionaryLigatures]), ["font-variant-ligatures", "discretionary-ligatures"]
                (fss [ FontVariantLigatures FontVariantLigatures.NoDiscretionaryLigatures]), ["font-variant-ligatures", "no-discretionary-ligatures"]
                (fss [ FontVariantLigatures FontVariantLigatures.HistoricalLigatures]), ["font-variant-ligatures", "historical-ligatures"]
                (fss [ FontVariantLigatures FontVariantLigatures.NoHistoricalLigatures]), ["font-variant-ligatures", "no-historical-ligatures"]
                (fss [ FontVariantLigatures FontVariantLigatures.Contextual]), ["font-variant-ligatures", "contextual"]
                (fss [ FontVariantLigatures FontVariantLigatures.NoContextual]), ["font-variant-ligatures", "no-contextual"]
            ]

        test "Border"
            [
                (fss [ BorderStyle Hidden ]),
                    [
                        "border-bottom-style", "hidden"
                        "border-left-style", "hidden"
                        "border-right-style", "hidden"
                        "border-top-style", "hidden"
                    ]

                (fss [ BorderStyle Dotted ]),
                    [
                        "border-bottom-style", "dotted"
                        "border-left-style", "dotted"
                        "border-right-style", "dotted"
                        "border-top-style", "dotted"
                    ]

                (fss [ BorderStyle Dashed ]),
                    [
                        "border-bottom-style", "dashed"
                        "border-left-style", "dashed"
                        "border-right-style", "dashed"
                        "border-top-style", "dashed"
                    ]

                (fss [ BorderStyle Solid ]),
                    [
                        "border-bottom-style", "solid"
                        "border-left-style", "solid"
                        "border-right-style", "solid"
                        "border-top-style", "solid"
                    ]

                (fss [ BorderStyle Double ]),
                    [
                        "border-bottom-style", "double"
                        "border-left-style", "double"
                        "border-right-style", "double"
                        "border-top-style", "double"
                    ]

                (fss [ BorderStyle Groove ]),
                    [
                        "border-bottom-style", "groove"
                        "border-left-style", "groove"
                        "border-right-style", "groove"
                        "border-top-style", "groove"
                    ]

                (fss [ BorderStyle Ridge ]),
                    [
                        "border-bottom-style", "ridge"
                        "border-left-style", "ridge"
                        "border-right-style", "ridge"
                        "border-top-style", "ridge"
                    ]

                (fss [ BorderStyle Inset ]),
                    [
                        "border-bottom-style", "inset"
                        "border-left-style", "inset"
                        "border-right-style", "inset"
                        "border-top-style", "inset"
                    ]

                (fss [ BorderStyle Outset ]),
                    [
                        "border-bottom-style", "outset"
                        "border-left-style", "outset"
                        "border-right-style", "outset"
                        "border-top-style", "outset"
                    ]

                (fss [ BorderStyles [Inset; Outset; Ridge; Groove] ]),
                    [
                        "border-bottom-style", "ridge"
                        "border-left-style", "groove"
                        "border-right-style", "outset"
                        "border-top-style", "inset"
                    ]

                (fss [ BorderStyle BorderStyle.None ]),
                    [
                        "border-bottom-style", "none"
                        "border-left-style", "none"
                        "border-right-style", "none"
                        "border-top-style", "none"
                    ]

                (fss [ BorderRadius (px 10)]),
                     [
                         "border-top-left-radius", "10px"
                         "border-top-right-radius", "10px"
                         "border-bottom-left-radius", "10px"
                         "border-bottom-right-radius", "10px"
                     ]

                (fss [ BorderRadius (pct 50)]),
                     [
                         "border-top-left-radius", "50%"
                         "border-top-right-radius", "50%"
                         "border-bottom-left-radius", "50%"
                         "border-bottom-right-radius", "50%"
                     ]

                (fss [ BorderTopLeftRadius (px 10)]), ["border-top-left-radius", "10px"]
                (fss [ BorderTopRightRadius (px 10)]), ["border-top-right-radius", "10px"]
                (fss [ BorderBottomLeftRadius (px 10)]), ["border-bottom-left-radius", "10px"]
                (fss [ BorderBottomRightRadius (px 10)]), ["border-bottom-right-radius", "10px"]

                (fss [ BorderRadiuses [px 10; px 20; px 30; px 40] ]),
                    [
                        "border-bottom-left-radius", "40px"
                        "border-bottom-right-radius", "30px"
                        "border-top-left-radius", "10px"
                        "border-top-right-radius", "20px"
                    ]

                (fss [ BorderStyle Solid; BorderWidth (px 40) ]),
                    [
                        "border-top-width", "40px"
                        "border-right-width", "40px"
                        "border-bottom-width", "40px"
                        "border-left-width", "40px"
                    ]

                (fss [ BorderStyle Solid; BorderWidths [px 10; px 20; px 30; px 40 ]]),
                    [
                        "border-top-width", "10px"
                        "border-right-width", "20px"
                        "border-bottom-width", "30px"
                        "border-left-width", "40px"
                    ]

                (fss [ BorderStyle Solid; BorderTopWidth Thin ]), ["border-top-width", "1px"]
                (fss [ BorderStyle Solid; BorderRightWidth Thick ]), ["border-right-width", "5px"]
                (fss [ BorderStyle Solid; BorderBottomWidth Medium ]), ["border-bottom-width", "3px"]
                (fss [ BorderStyle Solid; BorderLeftWidth (px 40) ]), ["border-left-width", "40px"]

                (fss [ BorderStyle Solid; BorderColor red ]),
                    [
                        "border-top-color", "rgb(255, 0, 0)"
                        "border-right-color", "rgb(255, 0, 0)"
                        "border-bottom-color", "rgb(255, 0, 0)"
                        "border-left-color", "rgb(255, 0, 0)"
                    ]

                (fss [ BorderStyle Solid; BorderColors [red; green; blue; white] ]),
                    [
                        "border-top-color", "rgb(255, 0, 0)"
                        "border-right-color", "rgb(0, 128, 0)"
                        "border-bottom-color", "rgb(0, 0, 255)"
                        "border-left-color", "rgb(255, 255, 255)"
                    ]

                (fss [ BorderStyle Solid; BorderTopColor red ]), ["border-top-color", "rgb(255, 0, 0)"]
                (fss [ BorderStyle Solid; BorderRightColor green ]), ["border-right-color", "rgb(0, 128, 0)"]
                (fss [ BorderStyle Solid; BorderBottomColor blue ]), ["border-bottom-color", "rgb(0, 0, 255)"]
                (fss [ BorderStyle Solid; BorderLeftColor white ]), ["border-left-color", "rgb(255, 255, 255)"]
            ]

        test "Width"
            [
                (fss [ Width (px 100) ]), ["width", "100px"]
                (fss [ Width MaxContent ]), ["width", "0px"]
                (fss [ Width MinContent ]), ["width", "0px"]
                (fss [ Width (FitContent(px 100)) ]), ["width", "400px"]
                (fss [ MinWidth (px 50) ]), ["min-width", "50px"]
                (fss [ MaxWidth (px 75) ]), ["max-width", "75px"]

                (fss [ Height (px 100) ]), ["height", "100px"]
                (fss [ Height MaxContent ]), ["height", "0px"]
                (fss [ Height MinContent ]), ["height", "0px"]
                (fss [ MinHeight (px 50) ]), ["min-height", "50px"]
                (fss [ MaxHeight (px 75) ]), ["max-height", "75px"]
            ]

        test "Perspective"
            [
                (fss [ CSSProperty.Perspective (px 100) ]), ["perspective", "100px"]
                //(fss [ CSSProperty.Perspective Inherit]), "perspective", "inherit"
                //(fss [ CSSProperty.Perspective Initial]), "perspective", "initial"
                //(fss [ CSSProperty.Perspective Unset]), "perspective", "unset"
            ]

        test "Flexbox"
            [
                (fss [ Display Inline]), ["display", "inline"]
                (fss [ Display InlineBlock]), ["display", "inline-block"]
                (fss [ Display Block]), ["display", "block"]
                (fss [ Display RunIn]), ["display", "block"]
                (fss [ Display Flex]), ["display", "flex"]
                (fss [ Display Grid]), ["display", "grid"]
                (fss [ Display FlowRoot]), ["display", "flow-root"]
                (fss [ Display Table]), ["display", "table"]
                (fss [ Display TableCell]), ["display", "table-cell"]
                (fss [ Display TableColumn]), ["display", "table-column"]
                (fss [ Display TableColumnGroup]), ["display", "table-column-group"]
                (fss [ Display TableHeaderGroup]), ["display", "table-header-group"]
                (fss [ Display TableRowGroup]), ["display", "table-row-group"]
                (fss [ Display TableFooterGroup]), ["display", "table-footer-group"]
                (fss [ Display TableRow]), ["display", "table-row"]
                (fss [ Display TableCaption]), ["display", "table-caption"]
                (fss [ Display Display.None]), ["display", "none"]

                (fss [ FlexDirection Row]), ["flex-direction", "row"]
                (fss [ FlexDirection Column]), ["flex-direction", "column"]

                (fss [ FlexWrap NoWrap]), ["flex-wrap", "nowrap"]
                (fss [ FlexWrap Wrap]), ["flex-wrap", "wrap"]
                (fss [ FlexWrap WrapReverse]), ["flex-wrap", "wrap-reverse"]

                (fss [ CSSProperty.FlexBasis (px 120)]), ["flex-basis", "120px"]

                (fss [ JustifyContent JustifyContent.FlexStart]), ["justify-content", "flex-start"]
                (fss [ JustifyContent JustifyContent.FlexEnd]), ["justify-content", "flex-end"]
                (fss [ JustifyContent JustifyContent.Center]), ["justify-content", "center"]
                (fss [ JustifyContent JustifyContent.SpaceBetween]), ["justify-content", "space-between"]
                (fss [ JustifyContent JustifyContent.SpaceAround]), ["justify-content", "space-around"]
                (fss [ JustifyContent JustifyContent.SpaceEvenly]), ["justify-content", "space-evenly"]

                (fss [ AlignSelf AlignSelf.Auto]), ["align-self", "auto"]
                (fss [ AlignSelf AlignSelf.FlexStart]), ["align-self", "flex-start"]
                (fss [ AlignSelf AlignSelf.FlexEnd]), ["align-self", "flex-end"]
                (fss [ AlignSelf AlignSelf.Center]), ["align-self", "center"]
                (fss [ AlignSelf AlignSelf.Baseline]), ["align-self", "baseline"]
                (fss [ AlignSelf AlignSelf.Stretch]), ["align-self", "stretch"]

                (fss [ AlignItems AlignItems.FlexStart]), ["align-items", "flex-start"]
                (fss [ AlignItems AlignItems.FlexEnd]), ["align-items", "flex-end"]
                (fss [ AlignItems AlignItems.Center]), ["align-items", "center"]
                (fss [ AlignItems AlignItems.Baseline]), ["align-items", "baseline"]
                (fss [ AlignItems AlignItems.Stretch]), ["align-items", "stretch"]

                (fss [ AlignContent FlexStart]), ["align-content", "flex-start"]
                (fss [ AlignContent FlexEnd]), ["align-content", "flex-end"]
                (fss [ AlignContent AlignContent.Center]), ["align-content", "center"]
                (fss [ AlignContent SpaceBetween]), ["align-content", "space-between"]
                (fss [ AlignContent SpaceAround]), ["align-content", "space-around"]
                (fss [ AlignContent Stretch]), ["align-content", "stretch"]

                (fss [ CSSProperty.Order (Order 1) ]), ["order", "1"]

                (fss [ FlexGrow (Grow 1) ]), ["flex-grow", "1"]

                (fss [ FlexShrink (Shrink 1) ]), ["flex-shrink", "1"]

                (fss [ VerticalAlign (VerticalAlign.Baseline)]), ["vertical-align", "baseline"]
                (fss [ VerticalAlign (VerticalAlign.Sub)]), ["vertical-align", "sub"]
                (fss [ VerticalAlign (VerticalAlign.Super)]), ["vertical-align", "super"]
                (fss [ VerticalAlign (VerticalAlign.TextTop)]), ["vertical-align", "text-top"]
                (fss [ VerticalAlign (VerticalAlign.TextBottom)]), ["vertical-align", "text-bottom"]
                (fss [ VerticalAlign (VerticalAlign.Middle)]), ["vertical-align", "middle"]
                (fss [ VerticalAlign (VerticalAlign.Top)]), ["vertical-align", "top"]
                (fss [ VerticalAlign (VerticalAlign.Bottom)]), ["vertical-align", "bottom"]
                (fss [ VerticalAlign (px 10)]), ["vertical-align", "10px"]
                (fss [ VerticalAlign (pct 100)]), ["vertical-align", "100%"]

                (fss [ Visibility Visibility.Hidden]), ["visibility", "hidden"]
                (fss [ Visibility Visibility.Collapse]), ["visibility", "collapse"]
                (fss [ Visibility Visibility.Visible]), ["visibility", "visible"]

                (fss [ Opacity (Opacity.Opacity 1.0)]), ["opacity", "1"]
                (fss [ Opacity (Opacity.Opacity 0.0)]), ["opacity", "0"]
                (fss [ Opacity (Opacity.Opacity 0.5)]), ["opacity", "0.5"]
                (fss [ Opacity (Opacity.Opacity -10.0)]), ["opacity", "0"]
                (fss [ Opacity (Opacity.Opacity 10.0)]), ["opacity", "1"]
                (fss [ Opacity (Opacity.Opacity 1.5)]), ["opacity", "1"]

                (fss [ Position Position.Static]), ["position", "static"]
                (fss [ Position Position.Relative]), ["position", "relative"]
                (fss [ Position Position.Absolute]), ["position", "absolute"]
                (fss [ Position Position.Sticky]), ["position", "sticky"]
                (fss [ Position Position.Fixed]), ["position", "fixed"]

            ]

        test "Margin"
            [
                (fss [ MarginTop (px 10)]), ["margin-top", "10px"]
                (fss [ MarginRight (px 10)]), ["margin-right", "10px"]
                (fss [ MarginBottom (px 10)]), ["margin-bottom", "10px"]
                (fss [ MarginLeft (px 10)]), ["margin-left", "10px"]

                (fss [ CSSProperty.Margin (px 10)]),
                    [
                        "margin-top", "10px"
                        "margin-right", "10px"
                        "margin-bottom", "10px"
                        "margin-left", "10px"
                    ]

                (fss [ CSSProperty.Margins [ px 10; px 20; px 30; px 40 ] ]),
                    [
                        "margin-top", "10px"
                        "margin-right", "20px"
                        "margin-bottom", "30px"
                        "margin-left", "40px"
                    ]
            ]

        test "Padding"
            [
                (fss [ PaddingTop (px 10)]), ["padding-top", "10px"]
                (fss [ PaddingRight (px 10)]), ["padding-right", "10px"]
                (fss [ PaddingBottom (px 10)]), ["padding-bottom", "10px"]
                (fss [ PaddingLeft (px 10)]), ["padding-left", "10px"]

                (fss [ Padding (px 10)]),
                    [
                        "padding-top", "10px"
                        "padding-right", "10px"
                        "padding-bottom", "10px"
                        "padding-left", "10px"
                    ]

                (fss [ Paddings [ px 10; px 20; px 30; px 40 ] ]),
                    [
                        "padding-top", "10px"
                        "padding-right", "20px"
                        "padding-bottom", "30px"
                        "padding-left", "40px"
                    ]
            ]

        test "Animation"
            [
                let animationSample = keyframes [ frame 0 [ BackgroundColor red]; frame 100 [ BackgroundColor blue] ]

                (fss [ AnimationName animationSample ]), ["animation-name", animationSample |> string]

                (fss [ AnimationDuration (sec 10.0) ]), ["animation-duration", "10s"]

                (fss [ AnimationTimingFunction Ease ]), ["animation-timing-function", "ease"]
                (fss [ AnimationTimingFunction EaseIn ]), ["animation-timing-function", "ease-in"]
                (fss [ AnimationTimingFunction EaseOut ]), ["animation-timing-function", "ease-out"]
                (fss [ AnimationTimingFunction EaseInOut ]), ["animation-timing-function", "ease-in-out"]
                (fss [ AnimationTimingFunction Linear ]), ["animation-timing-function", "linear"]
                (fss [ AnimationTimingFunction StepStart ]), ["animation-timing-function", "steps(1, start)"]
                (fss [ AnimationTimingFunction StepEnd ]), ["animation-timing-function", "steps(1)"]
                (fss [ AnimationTimingFunction <| CubicBezier(0.0, 0.47, 0.32, 1.97) ]), ["animation-timing-function", "cubic-bezier(0, 0.5, 0.3, 2)"]
                (fss [ AnimationTimingFunction (Step 5) ]), ["animation-timing-function", "steps(5)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpStart) ]), ["animation-timing-function", "steps(5, jump-start)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpEnd) ]), ["animation-timing-function", "steps(5)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpNone) ]), ["animation-timing-function", "steps(5, jump-none)"]
                (fss [ AnimationTimingFunction <| Steps(5, JumpBoth) ]), ["animation-timing-function", "steps(5, jump-both)"]
                (fss [ AnimationTimingFunction <| Steps(5, Start) ]), ["animation-timing-function", "steps(5, start)"]
                (fss [ AnimationTimingFunction <| Steps(5, End) ]), ["animation-timing-function", "steps(5)"]

                (fss [ AnimationDelay (sec 10.0) ]), ["animation-delay", "10s"]
                (fss [ AnimationDelays [sec 10.0; ms 500.0] ]), ["animation-delay", "10s, 0.5s"]

                (fss [ AnimationIterationCount Infinite ]), ["animation-iteration-count", "infinite"]
                (fss [ AnimationIterationCount (Value 5) ]), ["animation-iteration-count", "5"]
                (fss [ AnimationIterationCounts [Infinite; Value 5] ]), ["animation-iteration-count", "infinite, 5"]

                (fss [ AnimationDirection Normal ]), ["animation-direction", "normal"]
                (fss [ AnimationDirection Reverse ]), ["animation-direction", "reverse"]
                (fss [ AnimationDirection Alternate ]), ["animation-direction", "alternate"]
                (fss [ AnimationDirection AlternateReverse ]), ["animation-direction", "alternate-reverse"]

                (fss [ AnimationFillMode Forwards ]), ["animation-fill-mode", "forwards"]
                (fss [ AnimationFillMode Backwards ]), ["animation-fill-mode", "backwards"]
                (fss [ AnimationFillMode Both ]), ["animation-fill-mode", "both"]
                (fss [ AnimationFillMode FillMode.None ]), ["animation-fill-mode", "none"]

                (fss [ AnimationPlayState Running ]), ["animation-play-state", "running"]
                (fss [ AnimationPlayState Paused ]), ["animation-play-state", "paused"]
                (fss [ AnimationPlayStates [ Running; Paused] ]), ["animation-play-state", "running, paused"]

                (fss [
                    Animations
                        [
                            [animationSample; sec 10.0; Ease; ms 0.5; Infinite; Both; Alternate; Running]
                            [animationSample; sec 1.0; Linear; sec 10.0; IterationCount.Value 3; Both; Reverse; Paused]
                        ]
                ]),
                    [
                        "animation-name", (sprintf "%A, %A" animationSample animationSample)
                        "animation-duration", "10s, 1s"
                        "animation-timing-function", "ease, linear"
                        "animation-delay", "0.0005s, 10s"
                        "animation-delay", "0.0005s, 10s"
                        "animation-iteration-count", "infinite, 3"
                        "animation-fill-mode", "both, both"
                        "animation-direction", "alternate, reverse"
                        "animation-play-state", "running, paused"
                    ]

            ]

        test "Transform"
            [
                (fss [Transform (Matrix(0.1, 0.2, 0.3,0.4, 0.5, 0.6)) ]), ["transform", "matrix(0.1, 0.2, 0.3, 0.4, 0.5, 0.6)"]

                (fss [Transform (
                        Matrix3D(1, 0, 0, 0,
                                 0, 1, 0, 0,
                                 0, 0, 1, 0,
                                 -50.0, -100.0, 0.0, 1.1)
                    ) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, -50, -100, 0, 1.1)"]

                (fss [Transform (Perspective(px 300)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, -0.00333333, 0, 0, 0, 1)"]

                (fss [Transform (Rotate(deg 45.0)) ]), ["transform", "matrix(0.707107, 0.707107, -0.707107, 0.707107, 0, 0)"]
                (fss [Transform (Rotate3D(0.5, 1.5, 2.5, deg 45.0)) ]), ["transform", "matrix3d(0.715475, 0.622719, -0.316727, 0, -0.572509, 0.782422, 0.245049, 0, 0.40041, 0.0060028, 0.916316, 0, 0, 0, 0, 1)"]
                (fss [Transform (RotateX(deg 45.0)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1)"]
                (fss [Transform (RotateY(deg 45.0)) ]), ["transform", "matrix3d(0.707107, 0, -0.707107, 0, 0, 1, 0, 0, 0.707107, 0, 0.707107, 0, 0, 0, 0, 1)"]
                (fss [Transform (RotateZ(deg 45.0)) ]), ["transform", "matrix(0.707107, 0.707107, -0.707107, 0.707107, 0, 0)"]

                (fss [Transform (Translate(px 45)) ]), ["transform", "matrix(1, 0, 0, 1, 45, 0)"]
                (fss [Transform (Translate2(px 50, px 50)) ]), ["transform", "matrix(1, 0, 0, 1, 50, 50)"]
                (fss [Transform (Translate3D(px 50, px 50, px 50)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 50, 50, 50, 1)"]
                (fss [Transform (TranslateX(px 10)) ]), ["transform", "matrix(1, 0, 0, 1, 10, 0)"]
                (fss [Transform (TranslateY(px 20)) ]), ["transform", "matrix(1, 0, 0, 1, 0, 20)"]
                (fss [Transform (TranslateZ(px 20)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 20, 1)"]

                (fss [Transform (Scale 2.5) ]), ["transform", "matrix(2.5, 0, 0, 2.5, 0, 0)"]
                (fss [Transform (Scale2(2.5, 2.5)) ]), ["transform", "matrix(2.5, 0, 0, 2.5, 0, 0)"]
                (fss [Transform (Scale3D(2.5, 2.5, 2.5)) ]), ["transform", "matrix3d(2.5, 0, 0, 0, 0, 2.5, 0, 0, 0, 0, 2.5, 0, 0, 0, 0, 1)"]
                (fss [Transform (ScaleX(3.5)) ]), ["transform", "matrix(3.5, 0, 0, 1, 0, 0)"]
                (fss [Transform (ScaleY(4.5)) ]), ["transform", "matrix(1, 0, 0, 4.5, 0, 0)"]
                (fss [Transform (ScaleZ(5.5)) ]), ["transform", "matrix3d(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 5.5, 0, 0, 0, 0, 1)"]

                (fss [Transform (Skew (deg 45.0)) ]), ["transform", "matrix(1, 0, 1, 1, 0, 0)"]
                (fss [Transform (Skew2 (deg 45.0, deg 20.0)) ]), ["transform", "matrix(1, 0.36397, 1, 1, 0, 0)"]
                (fss [Transform (SkewX (deg 22.5)) ]), ["transform", "matrix(1, 0, 0.414214, 1, 0, 0)"]
                (fss [Transform (SkewY (deg 3.5)) ]), ["transform", "matrix(1, 0.0611626, 0, 1, 0, 0)"]

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
                (fss [ TextOverflow (TextOverflow.Custom "-") ]), ["text-overflow", "\"-\""]
            ]

    ]

Mocha.runTests CssTests |> ignore

Mocha.runTests tests |> ignore
*)
