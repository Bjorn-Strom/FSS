namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Background =
     let tests =
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
                    [ BackgroundClip Background.Clip.BorderBox]
                    ["backgroundClip" ==> "border-box" ]

                test
                    "background clip to PaddingBox"
                    [ BackgroundClip Background.Clip.PaddingBox]
                    [ "backgroundClip" ==> "padding-box" ]

                test
                    "background clip to ContentBox"
                    [ BackgroundClip Background.Clip.ContentBox]
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