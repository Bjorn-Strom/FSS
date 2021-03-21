namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open FssTypes
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
                    [ BackgroundImage.LinearGradient (deg 45., [ CssColor.red, pct 0; CssColor.blue, pct 100 ])]
                    ["backgroundImage" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Circle, Image.ClosestSide, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Circle, Image.ClosestCorner, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Circle, Image.FarthestSide, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Circle, Image.FarthestCorner, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Ellipse, Image.ClosestSide, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse closest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Ellipse, Image.ClosestCorner, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse closest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Ellipse, Image.FarthestSide, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse farthest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.RadialGradient(Image.Ellipse, Image.FarthestCorner, pct 50, pct 50, [ CssColor.Hex "e66465", pct 0; CssColor.Hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse farthest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as conic gradient"
                    [BackgroundImage.ConicGradient(deg 0., pct 50, pct 50, [ CssColor.red, deg 0.; CssColor.orange, deg 90.; CssColor.yellow, deg 180.; CssColor.green, deg 270.; CssColor.blue, deg 360.; ])]
                    [ "backgroundImage" ==> "conic-Gradient(from 0.00deg at 50% 50%, #ff0000 0.00deg, #ffa500 90.00deg, #ffff00 180.00deg, #008000 270.00deg, #0000ff 360.00deg)"]
                test
                    "background as conic gradient"
                    [BackgroundImage.ConicGradient(rad 3.1416, pct 10, pct 50, [ hex "#e66465", deg 0.; hex "#9198e5", deg 360. ])]
                    [ "backgroundImage" ==> "conic-Gradient(from 3.1416rad at 10% 50%, #e66465 0.00deg, #9198e5 360.00deg)"]
                test
                    "background as repeating conic gradient"
                    [ BackgroundImage.RepeatingConicGradient(deg 0., pct 50, pct 50, [ CssColor.white, pct 0; CssColor.white, pct 25; CssColor.black, pct 25; CssColor.black, pct 50; ]) ]
                    [ "backgroundImage" ==> "repeating-conic-Gradient(from 0.00deg at 50% 50%, #ffffff 0%, #ffffff 25%, #000000 25%, #000000 50%)"]
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
                    [ BackgroundRepeat.Value(Repeat, Space) ]
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
                test
                    "Background blend mode Multiply"
                    [ BackgroundBlendMode.Multiply]
                    ["backgroundBlendMode" ==> "multiply"]
                test
                    "Background blend mode Screen"
                    [ BackgroundBlendMode.Screen]
                    ["backgroundBlendMode" ==> "screen"]
                test
                    "Background blend mode Overlay"
                    [ BackgroundBlendMode.Overlay]
                    ["backgroundBlendMode" ==> "overlay"]
                test
                    "Background blend mode Darken"
                    [ BackgroundBlendMode.Darken]
                    ["backgroundBlendMode" ==> "darken"]
                test
                    "Background blend mode Lighten"
                    [ BackgroundBlendMode.Lighten]
                    ["backgroundBlendMode" ==> "lighten"]
                test
                    "Background blend mode ColorDodge"
                    [ BackgroundBlendMode.ColorDodge]
                    ["backgroundBlendMode" ==> "color-dodge"]
                test
                    "Background blend mode ColorBurn"
                    [ BackgroundBlendMode.ColorBurn]
                    ["backgroundBlendMode" ==> "color-burn"]
                test
                    "Background blend mode HardLight"
                    [ BackgroundBlendMode.HardLight]
                    ["backgroundBlendMode" ==> "hard-light"]
                test
                    "Background blend mode SoftLight"
                    [ BackgroundBlendMode.SoftLight]
                    ["backgroundBlendMode" ==> "soft-light"]
                test
                    "Background blend mode Difference"
                    [ BackgroundBlendMode.Difference]
                    ["backgroundBlendMode" ==> "difference"]
                test
                    "Background blend mode Exclusion"
                    [ BackgroundBlendMode.Exclusion]
                    ["backgroundBlendMode" ==> "exclusion"]
                test
                    "Background blend mode Hue"
                    [ BackgroundBlendMode.Hue]
                    ["backgroundBlendMode" ==> "hue"]
                test
                    "Background blend mode Saturation"
                    [ BackgroundBlendMode.Saturation]
                    ["backgroundBlendMode" ==> "saturation"]
                test
                    "Background blend mode Color"
                    [ BackgroundBlendMode.Color]
                    ["backgroundBlendMode" ==> "color"]
                test
                    "Background blend mode Luminosity"
                    [ BackgroundBlendMode.Luminosity]
                    ["backgroundBlendMode" ==> "luminosity"]
                test
                    "background blend mode multiple"
                    [ BackgroundBlendMode.Values [ Hue; Saturation; Exclusion ] ]
                    [ "backgroundBlendMode" ==> "hue, saturation, exclusion" ]
                test
                    "background blend mode normal"
                    [ BackgroundBlendMode.Normal ]
                    [ "backgroundBlendMode" ==> "normal" ]
                test
                    "background blend mode inherit"
                    [ BackgroundBlendMode.Inherit ]
                    [ "backgroundBlendMode" ==> "inherit" ]
                test
                    "background blend mode initial"
                    [ BackgroundBlendMode.Initial ]
                    [ "backgroundBlendMode" ==> "initial" ]
                test
                    "background blend mode unset"
                    [ BackgroundBlendMode.Unset ]
                    [ "backgroundBlendMode" ==> "unset" ]
                test
                    "isolation isolate"
                    [ Isolation.Isolate ]
                    [ "isolation" ==> "isolate" ]
                test
                    "isolation normal"
                    [ Isolation.Auto ]
                    [ "isolation" ==> "auto" ]
                test
                    "isolation inherit"
                    [ Isolation.Inherit ]
                    [ "isolation" ==> "inherit" ]
                test
                    "isolation initial"
                    [ Isolation.Initial ]
                    [ "isolation" ==> "initial" ]
                test
                    "isolation unset"
                    [ Isolation.Unset ]
                    [ "isolation" ==> "unset" ]
                test
                    "boxDecorationBreak clone"
                    [ BoxDecorationBreak.Clone ]
                    [ "boxDecorationBreak" ==> "clone" ]
                test
                    "boxDecorationBreak slice"
                    [ BoxDecorationBreak.Slice ]
                    [ "boxDecorationBreak" ==> "slice" ]
                test
                    "boxDecorationBreak inherit"
                    [ BoxDecorationBreak.Inherit ]
                    [ "boxDecorationBreak" ==> "inherit" ]
                test
                    "boxDecorationBreak initial"
                    [ BoxDecorationBreak.Initial ]
                    [ "boxDecorationBreak" ==> "initial" ]
                test
                    "boxDecorationBreak unset"
                    [ BoxDecorationBreak.Unset ]
                    [ "boxDecorationBreak" ==> "unset" ]
            ]