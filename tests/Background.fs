namespace FSSTests

open Fable.AST.Fable
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
                    [ BackgroundImage.url "image.png" ]
                    [ "backgroundImage" ==> "url(image.png)" ]
                test
                    "background as linear gradient"
                    [ BackgroundImage.linearGradient (deg 45., [ FssTypes.Color.red, pct 0; FssTypes.Color.blue, pct 100 ])]
                    ["backgroundImage" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.ClosestSide, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.ClosestCorner, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle closest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.FarthestSide, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Circle, FssTypes.Image.FarthestCorner, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(circle farthest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.ClosestSide, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse closest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.ClosestCorner, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse closest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.FarthestSide, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse farthest-side at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(FssTypes.Image.Ellipse, FssTypes.Image.FarthestCorner, pct 50, pct 50, [ FssTypes.Color.hex "e66465", pct 0; FssTypes.Color.hex "9198e5", pct 100 ])]
                    [ "backgroundImage" ==> "radial-gradient(ellipse farthest-corner at 50% 50%, #e66465 0%, #9198e5 100%)"]
                test
                    "background as conic gradient"
                    [BackgroundImage.conicGradient(deg 0., pct 50, pct 50, [ FssTypes.Color.red, deg 0.; FssTypes.Color.orange, deg 90.; FssTypes.Color.yellow, deg 180.; FssTypes.Color.green, deg 270.; FssTypes.Color.blue, deg 360.; ])]
                    [ "backgroundImage" ==> "conic-Gradient(from 0.00deg at 50% 50%, #ff0000 0.00deg, #ffa500 90.00deg, #ffff00 180.00deg, #008000 270.00deg, #0000ff 360.00deg)"]
                test
                    "background as conic gradient"
                    [BackgroundImage.conicGradient(rad 3.1416, pct 10, pct 50, [ hex "#e66465", deg 0.; hex "#9198e5", deg 360. ])]
                    [ "backgroundImage" ==> "conic-Gradient(from 3.1416rad at 10% 50%, #e66465 0.00deg, #9198e5 360.00deg)"]
                test
                    "background as repeating conic gradient"
                    [ BackgroundImage.repeatingConicGradient(deg 0., pct 50, pct 50, [ FssTypes.Color.white, pct 0; FssTypes.Color.white, pct 25; FssTypes.Color.black, pct 25; FssTypes.Color.black, pct 50; ]) ]
                    [ "backgroundImage" ==> "repeating-conic-Gradient(from 0.00deg at 50% 50%, #ffffff 0%, #ffffff 25%, #000000 25%, #000000 50%)"]
                test
                    "background position to top"
                    [ BackgroundPosition.top ]
                    [ "backgroundPosition" ==> "top"]
                test
                    "background position to bottom"
                    [ BackgroundPosition.bottom]
                    [ "backgroundPosition" ==> "bottom" ]
                test
                    "background position to left"
                    [ BackgroundPosition.left]
                    [ "backgroundPosition" ==> "left" ]
                test
                    "background position to right"
                    [ BackgroundPosition.right]
                    [ "backgroundPosition" ==> "right" ]
                test
                    "background position to center"
                    [ BackgroundPosition.center]
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
                    [ BackgroundPosition.initial]
                    [ "backgroundPosition" ==> "initial" ]
                test
                    "background position to inherit"
                    [ BackgroundPosition.inherit']
                    [ "backgroundPosition" ==> "inherit" ]
                test
                    "background position to unset"
                    [ BackgroundPosition.unset]
                    [ "backgroundPosition" ==> "unset" ]
                test
                    "background origin to border-box"
                    [ BackgroundOrigin.borderBox]
                    [ "backgroundOrigin" ==> "border-box" ]
                test
                    "background origin to padding-box"
                    [ BackgroundOrigin.paddingBox]
                    [ "backgroundOrigin" ==> "padding-box" ]
                test
                    "background origin to content-box"
                    [ BackgroundOrigin.contentBox]
                    ["backgroundOrigin" ==> "content-box"]
                test
                    "background origin to inherit"
                    [ BackgroundOrigin.inherit' ]
                    ["backgroundOrigin" ==> "inherit"]
                test
                    "background origin to initial"
                    [ BackgroundOrigin.initial ]
                    ["backgroundOrigin" ==> "initial"]
                test
                    "background origin to unset"
                    [ BackgroundOrigin.unset ]
                    ["backgroundOrigin" ==> "unset"]
                test
                    "background clip to text"
                    [ BackgroundClip.text]
                    [ "backgroundClip" ==> "text" ]
                test
                    "background clip to BorderBox"
                    [ BackgroundClip.borderBox ]
                    ["backgroundClip" ==> "border-box" ]
                test
                    "background clip to PaddingBox"
                    [ BackgroundClip.paddingBox]
                    [ "backgroundClip" ==> "padding-box" ]
                test
                    "background clip to ContentBox"
                    [ BackgroundClip.contentBox]
                    ["backgroundClip" ==> "content-box" ]
                test
                    "background clip to inherit"
                    [ BackgroundClip.inherit' ]
                    ["backgroundClip" ==> "inherit" ]
                test
                    "background clip to Initial"
                    [ BackgroundClip.initial]
                    [ "backgroundClip" ==> "initial" ]
                test
                    "background clip to Unset"
                    [ BackgroundClip.unset ]
                    [ "backgroundClip" ==> "unset" ]
                test
                    "background repeat repeat-x"
                    [ BackgroundRepeat.repeatX ]
                    [ "backgroundRepeat" ==> "repeat-x" ]
                test
                    "background repeat repeat-y"
                    [ BackgroundRepeat.repeatY ]
                    [ "backgroundRepeat" ==> "repeat-y" ]
                test
                    "background repeat repeat"
                    [ BackgroundRepeat.repeat]
                    [ "backgroundRepeat" ==> "repeat" ]
                test
                    "background repeat space"
                    [ BackgroundRepeat.space]
                    [ "backgroundRepeat" ==> "space" ]
                test
                    "background repeat round"
                    [ BackgroundRepeat.round]
                    [ "backgroundRepeat" ==> "round" ]
                test
                    "background repeat no repeat"
                    [ BackgroundRepeat.noRepeat]
                    [ "backgroundRepeat" ==> "no-repeat" ]
                test
                    "background repeat to inherit"
                    [ BackgroundRepeat.inherit' ]
                    [ "backgroundRepeat" ==> "inherit" ]
                test
                    "background repeat to Initial"
                    [ BackgroundRepeat.initial]
                    [ "backgroundRepeat" ==> "initial" ]
                test
                    "background repeat to Unset"
                    [ BackgroundRepeat.unset ]
                    [ "backgroundRepeat" ==> "unset" ]
                test
                    "background repeats horizontal and vertical - repeat space"
                    [ BackgroundRepeat.value(FssTypes.Background.Repeat, FssTypes.Background.Space) ]
                    [ "backgroundRepeat" ==> "repeat space" ]
                test
                    "background size cover"
                    [ BackgroundSize.cover]
                    [ "backgroundSize" ==> "cover"]
                test
                    "background size contain"
                    [ BackgroundSize.contain]
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
                    [ BackgroundSize.auto ]
                    [ "backgroundSize" ==> "auto"]
                test
                    "background attachment scroll"
                    [ BackgroundAttachment.scroll]
                    [ "backgroundAttachment" ==> "scroll" ]
                test
                    "background attachment fixed"
                    [ BackgroundAttachment.fixed']
                    [ "backgroundAttachment" ==> "fixed" ]
                test
                    "background attachment local"
                    [ BackgroundAttachment.local]
                    [ "backgroundAttachment" ==> "local" ]
                test
                    "background attachment inherit"
                    [ BackgroundAttachment.inherit' ]
                    [ "backgroundAttachment" ==> "inherit" ]
                test
                    "background attachment initial"
                    [ BackgroundAttachment.initial ]
                    [ "backgroundAttachment" ==> "initial" ]
                test
                    "background attachment unset"
                    [ BackgroundAttachment.unset ]
                    [ "backgroundAttachment" ==> "unset" ]
                test
                    "Background blend mode Multiply"
                    [ BackgroundBlendMode.multiply]
                    ["backgroundBlendMode" ==> "multiply"]
                test
                    "Background blend mode Screen"
                    [ BackgroundBlendMode.screen]
                    ["backgroundBlendMode" ==> "screen"]
                test
                    "Background blend mode Overlay"
                    [ BackgroundBlendMode.overlay]
                    ["backgroundBlendMode" ==> "overlay"]
                test
                    "Background blend mode Darken"
                    [ BackgroundBlendMode.darken]
                    ["backgroundBlendMode" ==> "darken"]
                test
                    "Background blend mode Lighten"
                    [ BackgroundBlendMode.lighten]
                    ["backgroundBlendMode" ==> "lighten"]
                test
                    "Background blend mode ColorDodge"
                    [ BackgroundBlendMode.colorDodge]
                    ["backgroundBlendMode" ==> "color-dodge"]
                test
                    "Background blend mode ColorBurn"
                    [ BackgroundBlendMode.colorBurn]
                    ["backgroundBlendMode" ==> "color-burn"]
                test
                    "Background blend mode HardLight"
                    [ BackgroundBlendMode.hardLight]
                    ["backgroundBlendMode" ==> "hard-light"]
                test
                    "Background blend mode SoftLight"
                    [ BackgroundBlendMode.softLight]
                    ["backgroundBlendMode" ==> "soft-light"]
                test
                    "Background blend mode Difference"
                    [ BackgroundBlendMode.difference]
                    ["backgroundBlendMode" ==> "difference"]
                test
                    "Background blend mode Exclusion"
                    [ BackgroundBlendMode.exclusion]
                    ["backgroundBlendMode" ==> "exclusion"]
                test
                    "Background blend mode Hue"
                    [ BackgroundBlendMode.hue]
                    ["backgroundBlendMode" ==> "hue"]
                test
                    "Background blend mode Saturation"
                    [ BackgroundBlendMode.saturation]
                    ["backgroundBlendMode" ==> "saturation"]
                test
                    "Background blend mode Color"
                    [ BackgroundBlendMode.color]
                    ["backgroundBlendMode" ==> "color"]
                test
                    "Background blend mode Luminosity"
                    [ BackgroundBlendMode.luminosity]
                    ["backgroundBlendMode" ==> "luminosity"]
                test
                    "background blend mode multiple"
                    [ BackgroundBlendMode.values [ FssTypes.Background.Hue; FssTypes.Background.Saturation; FssTypes.Background.Exclusion ] ]
                    [ "backgroundBlendMode" ==> "hue, saturation, exclusion" ]
                test
                    "background blend mode normal"
                    [ BackgroundBlendMode.normal ]
                    [ "backgroundBlendMode" ==> "normal" ]
                test
                    "background blend mode inherit"
                    [ BackgroundBlendMode.inherit' ]
                    [ "backgroundBlendMode" ==> "inherit" ]
                test
                    "background blend mode initial"
                    [ BackgroundBlendMode.initial ]
                    [ "backgroundBlendMode" ==> "initial" ]
                test
                    "background blend mode unset"
                    [ BackgroundBlendMode.unset ]
                    [ "backgroundBlendMode" ==> "unset" ]
                test
                    "isolation isolate"
                    [ Isolation.isolate ]
                    [ "isolation" ==> "isolate" ]
                test
                    "isolation normal"
                    [ Isolation.auto ]
                    [ "isolation" ==> "auto" ]
                test
                    "isolation inherit"
                    [ Isolation.inherit' ]
                    [ "isolation" ==> "inherit" ]
                test
                    "isolation initial"
                    [ Isolation.initial ]
                    [ "isolation" ==> "initial" ]
                test
                    "isolation unset"
                    [ Isolation.unset ]
                    [ "isolation" ==> "unset" ]
                test
                    "boxDecorationBreak clone"
                    [ BoxDecorationBreak.clone ]
                    [ "boxDecorationBreak" ==> "clone" ]
                test
                    "boxDecorationBreak slice"
                    [ BoxDecorationBreak.slice ]
                    [ "boxDecorationBreak" ==> "slice" ]
                test
                    "boxDecorationBreak inherit"
                    [ BoxDecorationBreak.inherit' ]
                    [ "boxDecorationBreak" ==> "inherit" ]
                test
                    "boxDecorationBreak initial"
                    [ BoxDecorationBreak.initial ]
                    [ "boxDecorationBreak" ==> "initial" ]
                test
                    "boxDecorationBreak unset"
                    [ BoxDecorationBreak.unset ]
                    [ "boxDecorationBreak" ==> "unset" ]
            ]