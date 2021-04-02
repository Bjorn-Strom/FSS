namespace FSSTests

open Fable.Core.JsInterop
open Utils
open Fss
open Fet

module Background =
     let tests =
        testList "Background"
            [
                testCase
                    "background color"
                    [ BackgroundColor.red ]
                    [ "backgroundColor" ==> "#ff0000"]
                testCase
                    "Background Color Value"
                    [BackgroundColor' (rgb 1 2 3)]
                    ["backgroundColor"  ==> "rgb(1, 2, 3)"]
                testCase
                    "background image"
                    [ BackgroundImage.url "image.png" ]
                    [ "backgroundImage" ==> "url(image.png)" ]
                testCase
                    "background as linear gradient"
                    [ BackgroundImage.linearGradient (deg 45., [ FssTypes.Color.Color.red, pct 0; FssTypes.Color.Color.blue, pct 100 ])]
                    ["backgroundImage" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.ClosestSide, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.ClosestCorner, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.FarthestSide, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.FarthestCorner, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.ClosestSide, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse closest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.ClosestCorner, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse closest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.FarthestSide, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse farthest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.FarthestCorner, pct 50, pct 50, [ FssTypes.Color.Color.hex "e66465", pct 0; FssTypes.Color.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse farthest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                testCase
                    "background as conic gradient"
                    [BackgroundImage.conicGradient(deg 0., pct 50, pct 50, [ FssTypes.Color.Color.red, deg 0.; FssTypes.Color.Color.orange, deg 90.; FssTypes.Color.Color.yellow, deg 180.; FssTypes.Color.Color.green, deg 270.; FssTypes.Color.Color.blue, deg 360.; ])]
                    [ "backgroundImage" ==> "conic-Gradient(from 0.00deg at 50% 50%, #ff0000 0.00deg, #ffa500 90.00deg, #ffff00 180.00deg, #008000 270.00deg, #0000ff 360.00deg)"]
                testCase
                    "background as conic gradient"
                    [BackgroundImage.conicGradient(rad 3.1416, pct 10, pct 50, [ hex "#e66465", deg 0.; hex "#9198e5", deg 360. ])]
                    [ "backgroundImage" ==> "conic-Gradient(from 3.1416rad at 10% 50%, #e66465 0.00deg, #9198e5 360.00deg)"]
                testCase
                    "background as repeating conic gradient"
                    [ BackgroundImage.repeatingConicGradient(deg 0., pct 50, pct 50, [ FssTypes.Color.Color.white, pct 0; FssTypes.Color.Color.white, pct 25; FssTypes.Color.Color.black, pct 25; FssTypes.Color.Color.black, pct 50; ]) ]
                    [ "backgroundImage" ==> "repeating-conic-Gradient(from 0.00deg at 50% 50%, #ffffff 0%, #ffffff 25%, #000000 25%, #000000 50%)"]
                testCase
                    "background position to top"
                    [ BackgroundPosition.top ]
                    [ "backgroundPosition" ==> "top"]
                testCase
                    "background position to bottom"
                    [ BackgroundPosition.bottom]
                    [ "backgroundPosition" ==> "bottom" ]
                testCase
                    "background position to left"
                    [ BackgroundPosition.left]
                    [ "backgroundPosition" ==> "left" ]
                testCase
                    "background position to right"
                    [ BackgroundPosition.right]
                    [ "backgroundPosition" ==> "right" ]
                testCase
                    "background position to center"
                    [ BackgroundPosition.center]
                    [ "backgroundPosition" ==> "center" ]
                testCase
                    "background position with pixels"
                    [ BackgroundPosition' (px 50)]
                    [ "backgroundPosition" ==> "50px" ]
                testCase
                    "background position with percent"
                    [ BackgroundPosition' (pct 100)]
                    [ "backgroundPosition" ==> "100%" ]
                testCase
                    "background position to initial"
                    [ BackgroundPosition.initial]
                    [ "backgroundPosition" ==> "initial" ]
                testCase
                    "background position to inherit"
                    [ BackgroundPosition.inherit']
                    [ "backgroundPosition" ==> "inherit" ]
                testCase
                    "background position to unset"
                    [ BackgroundPosition.unset]
                    [ "backgroundPosition" ==> "unset" ]
                testCase
                    "background origin to border-box"
                    [ BackgroundOrigin.borderBox]
                    [ "backgroundOrigin" ==> "border-box" ]
                testCase
                    "background origin to padding-box"
                    [ BackgroundOrigin.paddingBox]
                    [ "backgroundOrigin" ==> "padding-box" ]
                testCase
                    "background origin to content-box"
                    [ BackgroundOrigin.contentBox]
                    ["backgroundOrigin" ==> "content-box"]
                testCase
                    "background origin to inherit"
                    [ BackgroundOrigin.inherit' ]
                    ["backgroundOrigin" ==> "inherit"]
                testCase
                    "background origin to initial"
                    [ BackgroundOrigin.initial ]
                    ["backgroundOrigin" ==> "initial"]
                testCase
                    "background origin to unset"
                    [ BackgroundOrigin.unset ]
                    ["backgroundOrigin" ==> "unset"]
                testCase
                    "background clip to text"
                    [ BackgroundClip.text]
                    [ "backgroundClip" ==> "text" ]
                testCase
                    "background clip to BorderBox"
                    [ BackgroundClip.borderBox ]
                    ["backgroundClip" ==> "border-box" ]
                testCase
                    "background clip to PaddingBox"
                    [ BackgroundClip.paddingBox]
                    [ "backgroundClip" ==> "padding-box" ]
                testCase
                    "background clip to ContentBox"
                    [ BackgroundClip.contentBox]
                    ["backgroundClip" ==> "content-box" ]
                testCase
                    "background clip to inherit"
                    [ BackgroundClip.inherit' ]
                    ["backgroundClip" ==> "inherit" ]
                testCase
                    "background clip to Initial"
                    [ BackgroundClip.initial]
                    [ "backgroundClip" ==> "initial" ]
                testCase
                    "background clip to Unset"
                    [ BackgroundClip.unset ]
                    [ "backgroundClip" ==> "unset" ]
                testCase
                    "background repeat repeat-x"
                    [ BackgroundRepeat.repeatX ]
                    [ "backgroundRepeat" ==> "repeat-x" ]
                testCase
                    "background repeat repeat-y"
                    [ BackgroundRepeat.repeatY ]
                    [ "backgroundRepeat" ==> "repeat-y" ]
                testCase
                    "background repeat repeat"
                    [ BackgroundRepeat.repeat]
                    [ "backgroundRepeat" ==> "repeat" ]
                testCase
                    "background repeat space"
                    [ BackgroundRepeat.space]
                    [ "backgroundRepeat" ==> "space" ]
                testCase
                    "background repeat round"
                    [ BackgroundRepeat.round]
                    [ "backgroundRepeat" ==> "round" ]
                testCase
                    "background repeat no repeat"
                    [ BackgroundRepeat.noRepeat]
                    [ "backgroundRepeat" ==> "no-repeat" ]
                testCase
                    "background repeat to inherit"
                    [ BackgroundRepeat.inherit' ]
                    [ "backgroundRepeat" ==> "inherit" ]
                testCase
                    "background repeat to Initial"
                    [ BackgroundRepeat.initial]
                    [ "backgroundRepeat" ==> "initial" ]
                testCase
                    "background repeat to Unset"
                    [ BackgroundRepeat.unset ]
                    [ "backgroundRepeat" ==> "unset" ]
                testCase
                    "background repeats horizontal and vertical - repeat space"
                    [ BackgroundRepeat.value(FssTypes.Background.Repeat, FssTypes.Background.Space) ]
                    [ "backgroundRepeat" ==> "repeat space" ]
                testCase
                    "background size cover"
                    [ BackgroundSize.cover]
                    [ "backgroundSize" ==> "cover"]
                testCase
                    "background size contain"
                    [ BackgroundSize.contain]
                    [ "backgroundSize" ==> "contain"]
                testCase
                    "background size percent"
                    [ BackgroundSize' (pct 100)]
                    [ "backgroundSize" ==> "100%"]
                testCase
                    "background size em"
                    [ BackgroundSize' (em 3.0)]
                    [ "backgroundSize" ==> "3.0em"]
                testCase
                    "background size px"
                    [ BackgroundSize' (px 10)]
                    [ "backgroundSize" ==> "10px"]
                testCase
                    "background size auto"
                    [ BackgroundSize.auto ]
                    [ "backgroundSize" ==> "auto"]
                testCase
                    "background attachment scroll"
                    [ BackgroundAttachment.scroll]
                    [ "backgroundAttachment" ==> "scroll" ]
                testCase
                    "background attachment fixed"
                    [ BackgroundAttachment.fixed']
                    [ "backgroundAttachment" ==> "fixed" ]
                testCase
                    "background attachment local"
                    [ BackgroundAttachment.local]
                    [ "backgroundAttachment" ==> "local" ]
                testCase
                    "background attachment inherit"
                    [ BackgroundAttachment.inherit' ]
                    [ "backgroundAttachment" ==> "inherit" ]
                testCase
                    "background attachment initial"
                    [ BackgroundAttachment.initial ]
                    [ "backgroundAttachment" ==> "initial" ]
                testCase
                    "background attachment unset"
                    [ BackgroundAttachment.unset ]
                    [ "backgroundAttachment" ==> "unset" ]
                testCase
                    "Background blend mode Multiply"
                    [ BackgroundBlendMode.multiply]
                    ["backgroundBlendMode" ==> "multiply"]
                testCase
                    "Background blend mode Screen"
                    [ BackgroundBlendMode.screen]
                    ["backgroundBlendMode" ==> "screen"]
                testCase
                    "Background blend mode Overlay"
                    [ BackgroundBlendMode.overlay]
                    ["backgroundBlendMode" ==> "overlay"]
                testCase
                    "Background blend mode Darken"
                    [ BackgroundBlendMode.darken]
                    ["backgroundBlendMode" ==> "darken"]
                testCase
                    "Background blend mode Lighten"
                    [ BackgroundBlendMode.lighten]
                    ["backgroundBlendMode" ==> "lighten"]
                testCase
                    "Background blend mode ColorDodge"
                    [ BackgroundBlendMode.colorDodge]
                    ["backgroundBlendMode" ==> "color-dodge"]
                testCase
                    "Background blend mode ColorBurn"
                    [ BackgroundBlendMode.colorBurn]
                    ["backgroundBlendMode" ==> "color-burn"]
                testCase
                    "Background blend mode HardLight"
                    [ BackgroundBlendMode.hardLight]
                    ["backgroundBlendMode" ==> "hard-light"]
                testCase
                    "Background blend mode SoftLight"
                    [ BackgroundBlendMode.softLight]
                    ["backgroundBlendMode" ==> "soft-light"]
                testCase
                    "Background blend mode Difference"
                    [ BackgroundBlendMode.difference]
                    ["backgroundBlendMode" ==> "difference"]
                testCase
                    "Background blend mode Exclusion"
                    [ BackgroundBlendMode.exclusion]
                    ["backgroundBlendMode" ==> "exclusion"]
                testCase
                    "Background blend mode Hue"
                    [ BackgroundBlendMode.hue]
                    ["backgroundBlendMode" ==> "hue"]
                testCase
                    "Background blend mode Saturation"
                    [ BackgroundBlendMode.saturation]
                    ["backgroundBlendMode" ==> "saturation"]
                testCase
                    "Background blend mode Color"
                    [ BackgroundBlendMode.color]
                    ["backgroundBlendMode" ==> "color"]
                testCase
                    "Background blend mode Luminosity"
                    [ BackgroundBlendMode.luminosity]
                    ["backgroundBlendMode" ==> "luminosity"]
                testCase
                    "background blend mode multiple"
                    [ BackgroundBlendMode.values [ FssTypes.Background.Hue; FssTypes.Background.Saturation; FssTypes.Background.Exclusion ] ]
                    [ "backgroundBlendMode" ==> "hue, saturation, exclusion" ]
                testCase
                    "background blend mode normal"
                    [ BackgroundBlendMode.normal ]
                    [ "backgroundBlendMode" ==> "normal" ]
                testCase
                    "background blend mode inherit"
                    [ BackgroundBlendMode.inherit' ]
                    [ "backgroundBlendMode" ==> "inherit" ]
                testCase
                    "background blend mode initial"
                    [ BackgroundBlendMode.initial ]
                    [ "backgroundBlendMode" ==> "initial" ]
                testCase
                    "background blend mode unset"
                    [ BackgroundBlendMode.unset ]
                    [ "backgroundBlendMode" ==> "unset" ]
                testCase
                    "isolation isolate"
                    [ Isolation.isolate ]
                    [ "isolation" ==> "isolate" ]
                testCase
                    "isolation normal"
                    [ Isolation.auto ]
                    [ "isolation" ==> "auto" ]
                testCase
                    "isolation inherit"
                    [ Isolation.inherit' ]
                    [ "isolation" ==> "inherit" ]
                testCase
                    "isolation initial"
                    [ Isolation.initial ]
                    [ "isolation" ==> "initial" ]
                testCase
                    "isolation unset"
                    [ Isolation.unset ]
                    [ "isolation" ==> "unset" ]
                testCase
                    "boxDecorationBreak clone"
                    [ BoxDecorationBreak.clone ]
                    [ "boxDecorationBreak" ==> "clone" ]
                testCase
                    "boxDecorationBreak slice"
                    [ BoxDecorationBreak.slice ]
                    [ "boxDecorationBreak" ==> "slice" ]
                testCase
                    "boxDecorationBreak inherit"
                    [ BoxDecorationBreak.inherit' ]
                    [ "boxDecorationBreak" ==> "inherit" ]
                testCase
                    "boxDecorationBreak initial"
                    [ BoxDecorationBreak.initial ]
                    [ "boxDecorationBreak" ==> "initial" ]
                testCase
                    "boxDecorationBreak unset"
                    [ BoxDecorationBreak.unset ]
                    [ "boxDecorationBreak" ==> "unset" ]
            ]