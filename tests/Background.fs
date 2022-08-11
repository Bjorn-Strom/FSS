namespace FSSTests

open Utils
open Fss
open Fet

module BackgroundTests =
     let tests =
        testList "Background"
            [
                testCase
                    "background color"
                    [ BackgroundColor.red ]
                    "{background-color:red;}"
                testCase
                    "Background Color Value"
                    [ BackgroundColor.value (rgb 1 2 3) ]
                    "{background-color:rgb(1,2,3);}"
                testCase
                    "background color to initial"
                    [ BackgroundColor.initial]
                    "{background-color:initial;}"
                testCase
                    "background color to inherit"
                    [ BackgroundColor.inherit']
                    "{background-color:inherit;}"
                testCase
                    "background color to unset"
                    [ BackgroundColor.unset]
                    "{background-color:unset;}"
                testCase
                    "background color to revert"
                    [ BackgroundColor.revert]
                    "{background-color:revert;}"
                testCase
                    "background image"
                    [ BackgroundImage.url "image.png" ]
                    "{background-image:url(image.png);}"
                testCase
                    "background as linear gradient"
                    [ BackgroundImage.linearGradient ((deg 45., [ Fss.Types.Color.Red, pct 0; Fss.Types.Color.Blue, pct 100 ])) ]
                    "{background-image:linear-gradient(45deg,red 0%,blue 100%);}"
                testCase
                    "background as linear gradients"
                    [ BackgroundImage.linearGradients [
                        deg 217, [ rgba 255 0 0 0.8, pct 0; rgba 255 0 0 0, pct 70 ]
                        deg 127, [ rgba 0 255 0 0.8, pct 0; rgba 0 255 0 0, pct 70 ]
                        deg 336, [ rgba 0 0 255 0.8, pct 0; rgba 0 0 255 0, pct 70 ]
                    ] ]
                    "{background-image:linear-gradient(217deg,rgba(255,0,0,0.8) 0%,rgba(255,0,0,0) 70%),linear-gradient(127deg,rgba(0,255,0,0.8) 0%,rgba(0,255,0,0) 70%),linear-gradient(336deg,rgba(0,0,255,0.8) 0%,rgba(0,0,255,0) 70%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.ClosestSide, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(circle closest-side at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.ClosestCorner, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(circle closest-corner at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.FarthestSide, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(circle farthest-side at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.FarthestCorner, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(circle farthest-corner at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.ClosestSide, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(ellipse closest-side at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.ClosestCorner, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(ellipse closest-corner at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.FarthestSide, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(ellipse farthest-side at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as circular radial gradient"
                    [ BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.FarthestCorner, pct 50, pct 50, [ hex "e66465", pct 0; hex "9198e5", pct 100 ])]
                    "{background-image:radial-gradient(ellipse farthest-corner at 50% 50%,#e66465 0%,#9198e5 100%);}"
                testCase
                    "background as conic gradient"
                    [BackgroundImage.conicGradient(deg 0., pct 50, pct 50, [ Fss.Types.Color.Red, deg 0.; Fss.Types.Color.Orange, deg 90.; Fss.Types.Color.Yellow, deg 180.; Fss.Types.Color.Green, deg 270.; Fss.Types.Color.Blue, deg 360.; ])]
                    "{background-image:conic-gradient(from 0deg at 50% 50%,red 0deg,orange 90deg,yellow 180deg,green 270deg,blue 360deg);}"
                testCase
                    "background as conic gradient"
                    [BackgroundImage.conicGradient(rad 3.1416, pct 10, pct 50, [ hex "#e66465", deg 0.; hex "#9198e5", deg 360. ])]
                    "{background-image:conic-gradient(from 3.1416rad at 10% 50%,#e66465 0deg,#9198e5 360deg);}"
                testCase
                    "background as repeating conic gradient"
                    [ BackgroundImage.repeatingConicGradient(deg 0., pct 50, pct 50, [ Fss.Types.Color.White, pct 0; Fss.Types.Color.White, pct 25; Fss.Types.Color.Black, pct 25; Fss.Types.Color.Black, pct 50; ]) ]
                    "{background-image:repeating-conic-gradient(from 0deg at 50% 50%,white 0%,white 25%,black 25%,black 50%);}"
                testCase
                    "background position to top"
                    [ BackgroundPosition.top ]
                    "{background-position:top;}"
                testCase
                    "background position to bottom"
                    [ BackgroundPosition.bottom]
                    "{background-position:bottom;}"
                testCase
                    "background position to left"
                    [ BackgroundPosition.left]
                    "{background-position:left;}"
                testCase
                    "background position to right"
                    [ BackgroundPosition.right]
                    "{background-position:right;}"
                testCase
                    "background position to center"
                    [ BackgroundPosition.center]
                    "{background-position:center;}"
                testCase
                    "background position with pixels"
                    [ BackgroundPosition.value (px 50)]
                    "{background-position:50px;}"
                testCase
                    "background position with percent"
                    [ BackgroundPosition.value (pct 100)]
                    "{background-position:100%;}"
                testCase
                    "background position to initial"
                    [ BackgroundPosition.initial]
                    "{background-position:initial;}"
                testCase
                    "background position to inherit"
                    [ BackgroundPosition.inherit']
                    "{background-position:inherit;}"
                testCase
                    "background position to unset"
                    [ BackgroundPosition.unset]
                    "{background-position:unset;}"
                testCase
                    "background origin to border-box"
                    [ BackgroundOrigin.borderBox]
                    "{background-origin:border-box;}"
                testCase
                    "background origin to padding-box"
                    [ BackgroundOrigin.paddingBox]
                    "{background-origin:padding-box;}"
                testCase
                    "background origin to content-box"
                    [ BackgroundOrigin.contentBox]
                    "{background-origin:content-box;}"
                testCase
                    "background origin to inherit"
                    [ BackgroundOrigin.inherit' ]
                    "{background-origin:inherit;}"
                testCase
                    "background origin to initial"
                    [ BackgroundOrigin.initial ]
                    "{background-origin:initial;}"
                testCase
                    "background origin to unset"
                    [ BackgroundOrigin.unset ]
                    "{background-origin:unset;}"
                testCase
                    "background origin to revert"
                    [ BackgroundOrigin.revert ]
                    "{background-origin:revert;}"
                testCase
                    "background clip to text"
                    [ BackgroundClip.text]
                    "{background-clip:text;}"
                testCase
                    "background clip to BorderBox"
                    [ BackgroundClip.borderBox ]
                    "{background-clip:border-box;}"
                testCase
                    "background clip to PaddingBox"
                    [ BackgroundClip.paddingBox]
                    "{background-clip:padding-box;}"
                testCase
                    "background clip to ContentBox"
                    [ BackgroundClip.contentBox]
                    "{background-clip:content-box;}"
                testCase
                    "background clip to inherit"
                    [ BackgroundClip.inherit' ]
                    "{background-clip:inherit;}"
                testCase
                    "background clip to Initial"
                    [ BackgroundClip.initial]
                    "{background-clip:initial;}"
                testCase
                    "background clip to Unset"
                    [ BackgroundClip.unset ]
                    "{background-clip:unset;}"
                testCase
                    "background clip to Revert"
                    [ BackgroundClip.revert ]
                    "{background-clip:revert;}"
                testCase
                    "background repeat repeat-x"
                    [ BackgroundRepeat.repeatX ]
                    "{background-repeat:repeat-x;}"
                testCase
                    "background repeat repeat-y"
                    [ BackgroundRepeat.repeatY ]
                    "{background-repeat:repeat-y;}"
                testCase
                    "background repeat repeat"
                    [ BackgroundRepeat.repeat]
                    "{background-repeat:repeat;}"
                testCase
                    "background repeat space"
                    [ BackgroundRepeat.space]
                    "{background-repeat:space;}"
                testCase
                    "background repeat round"
                    [ BackgroundRepeat.round]
                    "{background-repeat:round;}"
                testCase
                    "background repeat no repeat"
                    [ BackgroundRepeat.noRepeat]
                    "{background-repeat:no-repeat;}"
                testCase
                    "background repeat to inherit"
                    [ BackgroundRepeat.inherit' ]
                    "{background-repeat:inherit;}"
                testCase
                    "background repeat to Initial"
                    [ BackgroundRepeat.initial]
                    "{background-repeat:initial;}"
                testCase
                    "background repeat to Unset"
                    [ BackgroundRepeat.unset ]
                    "{background-repeat:unset;}"
                testCase
                    "background repeat to Revert"
                    [ BackgroundRepeat.revert ]
                    "{background-repeat:revert;}"
                testCase
                    "background repeats horizontal and vertical - repeat space"
                    [ BackgroundRepeat.value(Fss.Types.Background.Repeat, Fss.Types.Background.Space) ]
                    "{background-repeat:repeat space;}"
                testCase
                    "background size cover"
                    [ BackgroundSize.cover]
                    "{background-size:cover;}"
                testCase
                    "background size contain"
                    [ BackgroundSize.contain]
                    "{background-size:contain;}"
                testCase
                    "background size contain"
                    [ BackgroundSize.value Fss.Types.Background.Contain]
                    "{background-size:contain;}"
                testCase
                    "background size contain"
                    [ BackgroundSize.value [Fss.Types.Background.Size.Contain; Fss.Types.Background.Size.Cover ]]
                    "{background-size:contain, cover;}"
                testCase
                    "background size percent"
                    [ BackgroundSize.value (pct 100)]
                    "{background-size:100%;}"
                testCase
                    "background size em"
                    [ BackgroundSize.value (em 3.0)]
                    "{background-size:3em;}"
                testCase
                    "background size px"
                    [ BackgroundSize.value (px 10)]
                    "{background-size:10px;}"
                testCase
                    "background size auto"
                    [ BackgroundSize.auto ]
                    "{background-size:auto;}"
                testCase
                    "background size to inherit"
                    [ BackgroundSize.inherit' ]
                    "{background-size:inherit;}"
                testCase
                    "background size to Initial"
                    [ BackgroundSize.initial]
                    "{background-size:initial;}"
                testCase
                    "background size to Unset"
                    [ BackgroundSize.unset ]
                    "{background-size:unset;}"
                testCase
                    "background size to Revert"
                    [ BackgroundSize.revert ]
                    "{background-size:revert;}"
                testCase
                    "background attachment scroll"
                    [ BackgroundAttachment.scroll]
                    "{background-attachment:scroll;}"
                testCase
                    "background attachment fixed"
                    [ BackgroundAttachment.fixed']
                    "{background-attachment:fixed;}"
                testCase
                    "background attachment local"
                    [ BackgroundAttachment.local]
                    "{background-attachment:local;}"
                testCase
                    "background attachment inherit"
                    [ BackgroundAttachment.inherit' ]
                    "{background-attachment:inherit;}"
                testCase
                    "background attachment initial"
                    [ BackgroundAttachment.initial ]
                    "{background-attachment:initial;}"
                testCase
                    "background attachment unset"
                    [ BackgroundAttachment.unset ]
                    "{background-attachment:unset;}"
                testCase
                    "background attachment revert"
                    [ BackgroundAttachment.revert ]
                    "{background-attachment:revert;}"
                testCase
                    "Background blend mode Multiply"
                    [ BackgroundBlendMode.multiply]
                    "{background-blend-mode:multiply;}"
                testCase
                    "Background blend mode Screen"
                    [ BackgroundBlendMode.screen]
                    "{background-blend-mode:screen;}"
                testCase
                    "Background blend mode Overlay"
                    [ BackgroundBlendMode.overlay]
                    "{background-blend-mode:overlay;}"
                testCase
                    "Background blend mode Darken"
                    [ BackgroundBlendMode.darken]
                    "{background-blend-mode:darken;}"
                testCase
                    "Background blend mode Lighten"
                    [ BackgroundBlendMode.lighten]
                    "{background-blend-mode:lighten;}"
                testCase
                    "Background blend mode ColorDodge"
                    [ BackgroundBlendMode.colorDodge]
                    "{background-blend-mode:color-dodge;}"
                testCase
                    "Background blend mode ColorBurn"
                    [ BackgroundBlendMode.colorBurn]
                    "{background-blend-mode:color-burn;}"
                testCase
                    "Background blend mode HardLight"
                    [ BackgroundBlendMode.hardLight]
                    "{background-blend-mode:hard-light;}"
                testCase
                    "Background blend mode SoftLight"
                    [ BackgroundBlendMode.softLight]
                    "{background-blend-mode:soft-light;}"
                testCase
                    "Background blend mode Difference"
                    [ BackgroundBlendMode.difference]
                    "{background-blend-mode:difference;}"
                testCase
                    "Background blend mode Exclusion"
                    [ BackgroundBlendMode.exclusion]
                    "{background-blend-mode:exclusion;}"
                testCase
                    "Background blend mode Hue"
                    [ BackgroundBlendMode.hue]
                    "{background-blend-mode:hue;}"
                testCase
                    "Background blend mode Saturation"
                    [ BackgroundBlendMode.saturation]
                    "{background-blend-mode:saturation;}"
                testCase
                    "Background blend mode Color"
                    [ BackgroundBlendMode.color]
                    "{background-blend-mode:color;}"
                testCase
                    "Background blend mode Luminosity"
                    [ BackgroundBlendMode.luminosity]
                    "{background-blend-mode:luminosity;}"
                testCase
                    "background blend mode value"
                    [ BackgroundBlendMode.value Fss.Types.Background.Hue ]
                    "{background-blend-mode:hue;}"
                testCase
                    "background blend mode multiple"
                    [ BackgroundBlendMode.value [ Fss.Types.Background.Hue; Fss.Types.Background.Saturation; Fss.Types.Background.Exclusion ] ]
                    "{background-blend-mode:hue,saturation,exclusion;}"
                testCase
                    "background blend mode normal"
                    [ BackgroundBlendMode.normal ]
                    "{background-blend-mode:normal;}"
                testCase
                    "background blend mode inherit"
                    [ BackgroundBlendMode.inherit' ]
                    "{background-blend-mode:inherit;}"
                testCase
                    "background blend mode initial"
                    [ BackgroundBlendMode.initial ]
                    "{background-blend-mode:initial;}"
                testCase
                    "background blend mode unset"
                    [ BackgroundBlendMode.unset ]
                    "{background-blend-mode:unset;}"
                testCase
                    "background blend mode revert"
                    [ BackgroundBlendMode.revert ]
                    "{background-blend-mode:revert;}"
                testCase
                    "isolation isolate"
                    [ Isolation.isolate ]
                    "{isolation:isolate;}"
                testCase
                    "isolation normal"
                    [ Isolation.auto ]
                    "{isolation:auto;}"
                testCase
                    "isolation inherit"
                    [ Isolation.inherit' ]
                    "{isolation:inherit;}"
                testCase
                    "isolation initial"
                    [ Isolation.initial ]
                    "{isolation:initial;}"
                testCase
                    "isolation unset"
                    [ Isolation.unset ]
                    "{isolation:unset;}"
                testCase
                    "isolation revert"
                    [ Isolation.revert ]
                    "{isolation:revert;}"
                testCase
                    "box-decoration-break clone"
                    [ BoxDecorationBreak.clone ]
                    "{box-decoration-break:clone;}"
                testCase
                    "box-decoration-break slice"
                    [ BoxDecorationBreak.slice ]
                    "{box-decoration-break:slice;}"
                testCase
                    "box-decoration-break inherit"
                    [ BoxDecorationBreak.inherit' ]
                    "{box-decoration-break:inherit;}"
                testCase
                    "box-decoration-break initial"
                    [ BoxDecorationBreak.initial ]
                    "{box-decoration-break:initial;}"
                testCase
                    "box-decoration-break unset"
                    [ BoxDecorationBreak.unset ]
                    "{box-decoration-break:unset;}"
                testCase
                    "box-decoration-break revert"
                    [ BoxDecorationBreak.revert ]
                    "{box-decoration-break:revert;}"
            ]
