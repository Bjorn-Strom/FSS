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
                    [ BackgroundColor.red ]
                    [ "backgroundColor" ==> "#ff0000"]
                test
                    "Background Color Value"
                    [BackgroundColor' (rgb 1 2 3)]
                    ["backgroundColor"  ==> "rgb(1, 2, 3)"]
                test
                    "background image"
                    [ BackgroundImage.Url "image.png" ]
                    [ "backgroundImage" ==> "url(image.png)" ]
                test
                    "background as linear gradient"
                    [ BackgroundImage.LinearGradient (deg 45., CSSColor.red, CSSColor.blue)  ]
                    ["backgroundImage" ==> "linear-gradient(45.00deg, #ff0000, #0000ff)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Circle, hex "ffff00", hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle, #ffff00, #f06d06)"]
                test
                    "background as Ellipse radial gradient"
                    [ BackgroundImage.RadialGradient (Ellipse, CSSColor.yellow, CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside closest corner"
                    [ BackgroundImage.RadialGradient(Circle, ClosestCorner, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-corner, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside closest side"
                    [ BackgroundImage.RadialGradient(Circle, ClosestSide, CSSColor.yellow, CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-side, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside farthest corner"
                    [ BackgroundImage.RadialGradient(Circle, FarthestCorner, CSSColor.yellow, CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-corner, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside farthest side"
                    [ BackgroundImage.RadialGradient(Circle, FarthestSide, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-side, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside closest corner"
                    [ BackgroundImage.RadialGradient(Circle, ClosestCorner, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-corner, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside closest side"
                    [ BackgroundImage.RadialGradient(Circle, ClosestSide, CSSColor.yellow, CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-side, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside farthest corner"
                    [ BackgroundImage.RadialGradient(Circle, FarthestCorner, CSSColor.yellow, CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-corner, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circleside farthest side"
                    [ BackgroundImage.RadialGradient(Circle, FarthestSide, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-side, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at top"
                    [ BackgroundImage.RadialGradient(CircleAt AtTop, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at top, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at top right"
                    [ BackgroundImage.RadialGradient(CircleAt AtTopRight, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at top right, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at top left"
                    [ BackgroundImage.RadialGradient(CircleAt AtTopLeft, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at top left, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at top center"
                    [ BackgroundImage.RadialGradient(CircleAt AtTopCenter, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at top center, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at bottom"
                    [ BackgroundImage.RadialGradient(CircleAt AtBottom, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at bottom, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at bottom right"
                    [ BackgroundImage.RadialGradient(CircleAt AtBottomRight, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at bottom right, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at bottom left"
                    [ BackgroundImage.RadialGradient(CircleAt AtBottomLeft, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at bottom left, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at bottom center"
                    [ BackgroundImage.RadialGradient(CircleAt AtBottomCenter, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at bottom center, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at center"
                    [ BackgroundImage.RadialGradient(CircleAt AtCenter, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at center, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at center right"
                    [ BackgroundImage.RadialGradient(CircleAt AtCenterRight, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at center right, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at center left"
                    [ BackgroundImage.RadialGradient(CircleAt AtCenterLeft, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at center left, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Circle at center bottom"
                    [ BackgroundImage.RadialGradient(CircleAt AtCenterBottom, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(circle at center bottom, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at top"
                    [ BackgroundImage.RadialGradient(EllipseAt AtTop, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at top, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at top right"
                    [ BackgroundImage.RadialGradient(EllipseAt AtTopRight, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at top right, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at top left"
                    [ BackgroundImage.RadialGradient(EllipseAt AtTopLeft, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at top left, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at top center"
                    [ BackgroundImage.RadialGradient(EllipseAt AtTopCenter, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at top center, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at bottom"
                    [ BackgroundImage.RadialGradient(EllipseAt AtBottom, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at bottom, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at bottom right"
                    [ BackgroundImage.RadialGradient(EllipseAt AtBottomRight, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at bottom right, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at bottom left"
                    [ BackgroundImage.RadialGradient(EllipseAt AtBottomLeft, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at bottom left, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at bottom center"
                    [ BackgroundImage.RadialGradient(EllipseAt AtBottomCenter, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at bottom center, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at center"
                    [ BackgroundImage.RadialGradient(EllipseAt AtCenter, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at center, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at center right"
                    [ BackgroundImage.RadialGradient(EllipseAt AtCenterRight, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at center right, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at center left"
                    [ BackgroundImage.RadialGradient(EllipseAt AtCenterLeft, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at center left, #ffff00, #f06d06)"]
                test
                    "background as radial gradient Ellipse at center bottom"
                    [ BackgroundImage.RadialGradient(EllipseAt AtCenterBottom, CSSColor.Hex "ffff00", CSSColor.Hex "f06d06") ]
                    [ "backgroundImage" ==> "radial-gradient(ellipse at center bottom, #ffff00, #f06d06)"]
                test
                    "background position to top"
                    [ BackgroundPosition.Top ]
                    [ "backgroundPosition" ==> "top"]
                test
                    "background position to bottom"
                    [ BackgroundPosition.Bottom]
                    [ "backgroundPosition" ==> "bottom" ]
                test
                    "background position to left"
                    [ BackgroundPosition.Left]
                    [ "backgroundPosition" ==> "left" ]
                test
                    "background position to right"
                    [ BackgroundPosition.Right]
                    [ "backgroundPosition" ==> "right" ]
                test
                    "background position to center"
                    [ BackgroundPosition.Center]
                    [ "backgroundPosition" ==> "center" ]
                test
                    "background position with pixels"
                    [ BackgroundPosition' (px 50)]
                    [ "backgroundPosition" ==> "50px" ]
                test
                    "background position with percent"
                    [ BackgroundPosition' (pct 100)]
                    [ "backgroundPosition" ==> "100%" ]
                test
                    "background position to initial"
                    [ BackgroundPosition.Initial]
                    [ "backgroundPosition" ==> "initial" ]
                test
                    "background position to inherit"
                    [ BackgroundPosition.Inherit]
                    [ "backgroundPosition" ==> "inherit" ]
                test
                    "background position to unset"
                    [ BackgroundPosition.Unset]
                    [ "backgroundPosition" ==> "unset" ]
                test
                    "background origin to border-box"
                    [ BackgroundOrigin.BorderBox]
                    [ "backgroundOrigin" ==> "border-box" ]
                test
                    "background origin to padding-box"
                    [ BackgroundOrigin.PaddingBox]
                    [ "backgroundOrigin" ==> "padding-box" ]
                test
                    "background origin to content-box"
                    [ BackgroundOrigin.ContentBox]
                    ["backgroundOrigin" ==> "content-box"]
                test
                    "background origin to inherit"
                    [ BackgroundOrigin.Inherit ]
                    ["backgroundOrigin" ==> "inherit"]
                test
                    "background origin to initial"
                    [ BackgroundOrigin.Initial ]
                    ["backgroundOrigin" ==> "initial"]
                test
                    "background origin to unset"
                    [ BackgroundOrigin.Unset ]
                    ["backgroundOrigin" ==> "unset"]
                test
                    "background clip to text"
                    [ BackgroundClip.Text]
                    [ "backgroundClip" ==> "text" ]
                test
                    "background clip to BorderBox"
                    [ BackgroundClip.BorderBox ]
                    ["backgroundClip" ==> "border-box" ]
                test
                    "background clip to PaddingBox"
                    [ BackgroundClip.PaddingBox]
                    [ "backgroundClip" ==> "padding-box" ]
                test
                    "background clip to ContentBox"
                    [ BackgroundClip.ContentBox]
                    ["backgroundClip" ==> "content-box" ]
                test
                    "background clip to inherit"
                    [ BackgroundClip.Inherit ]
                    ["backgroundClip" ==> "inherit" ]
                test
                    "background clip to Initial"
                    [ BackgroundClip.Initial]
                    [ "backgroundClip" ==> "initial" ]
                test
                    "background clip to Unset"
                    [ BackgroundClip.Unset ]
                    [ "backgroundClip" ==> "unset" ]
                test
                    "background repeat repeat-x"
                    [ BackgroundRepeat.RepeatX ]
                    [ "backgroundRepeat" ==> "repeat-x" ]
                test
                    "background repeat repeat-y"
                    [ BackgroundRepeat.RepeatY ]
                    [ "backgroundRepeat" ==> "repeat-y" ]
                test
                    "background repeat repeat"
                    [ BackgroundRepeat.Repeat]
                    [ "backgroundRepeat" ==> "repeat" ]
                test
                    "background repeat space"
                    [ BackgroundRepeat.Space]
                    [ "backgroundRepeat" ==> "space" ]
                test
                    "background repeat round"
                    [ BackgroundRepeat.Round]
                    [ "backgroundRepeat" ==> "round" ]
                test
                    "background repeat no repeat"
                    [ BackgroundRepeat.NoRepeat]
                    [ "backgroundRepeat" ==> "no-repeat" ]
                test
                    "background repeat to inherit"
                    [ BackgroundRepeat.Inherit ]
                    [ "backgroundRepeat" ==> "inherit" ]
                test
                    "background repeat to Initial"
                    [ BackgroundRepeat.Initial]
                    [ "backgroundRepeat" ==> "initial" ]
                test
                    "background repeat to Unset"
                    [ BackgroundRepeat.Unset ]
                    [ "backgroundRepeat" ==> "unset" ]
                test
                    "background repeats horizontal and vertical - repeat space"
                    [ BackgroundRepeat.Value(BackgroundType.Repeat, BackgroundType.Space) ]
                    [ "backgroundRepeat" ==> "repeat space" ]
                test
                    "background size cover"
                    [ BackgroundSize.Cover]
                    [ "backgroundSize" ==> "cover"]
                test
                    "background size contain"
                    [ BackgroundSize.Contain]
                    [ "backgroundSize" ==> "contain"]
                test
                    "background size percent"
                    [ BackgroundSize' (pct 100)]
                    [ "backgroundSize" ==> "100%"]
                test
                    "background size em"
                    [ BackgroundSize' (em 3.0)]
                    [ "backgroundSize" ==> "3.0em"]
                test
                    "background size px"
                    [ BackgroundSize' (px 10)]
                    [ "backgroundSize" ==> "10px"]
                test
                    "background size auto"
                    [ BackgroundSize.Auto ]
                    [ "backgroundSize" ==> "auto"]
                test
                    "background attachment scroll"
                    [ BackgroundAttachment.Scroll]
                    [ "backgroundAttachment" ==> "scroll" ]
                test
                    "background attachment fixed"
                    [ BackgroundAttachment.Fixed]
                    [ "backgroundAttachment" ==> "fixed" ]
                test
                    "background attachment local"
                    [ BackgroundAttachment.Local]
                    [ "backgroundAttachment" ==> "local" ]
                test
                    "background attachment inherit"
                    [ BackgroundAttachment.Inherit ]
                    [ "backgroundAttachment" ==> "inherit" ]
                test
                    "background attachment initial"
                    [ BackgroundAttachment.Initial ]
                    [ "backgroundAttachment" ==> "initial" ]
                test
                    "background attachment unset"
                    [ BackgroundAttachment.Unset ]
                    [ "backgroundAttachment" ==> "unset" ]
            ]