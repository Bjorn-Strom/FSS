namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Border =
     let tests =
        testList "Border"
            [
                test
                    "Border initial"
                    [ Border.initial ]
                    [ "border" ==> "initial" ]
                test
                    "Border inherit"
                    [ Border.inherit' ]
                    [ "border" ==> "inherit" ]
                test
                    "Border unset"
                    [ Border.unset ]
                    [ "border" ==> "unset" ]
                test
                    "Border none"
                    [ Border.none ]
                    [ "border" ==> "none" ]
                test
                    "Borderstyle hidden"
                    [ BorderStyle.hidden ]
                    [ "borderStyle" ==> "hidden" ]
                test
                    "Borderstyle dotted"
                    [ BorderStyle.dotted ]
                    [ "borderStyle" ==> "dotted" ]
                test
                    "Borderstyle dashed"
                    [ BorderStyle.dashed ]
                    [ "borderStyle" ==> "dashed" ]
                test
                    "Borderstyle solid"
                    [ BorderStyle.solid ]
                    [ "borderStyle" ==> "solid" ]
                test
                    "Borderstyle double"
                    [ BorderStyle.double ]
                    [ "borderStyle" ==> "double" ]
                test
                    "Borderstyle groove"
                    [ BorderStyle.groove ]
                    [ "borderStyle" ==> "groove" ]
                test
                    "Borderstyle ridge"
                    [ BorderStyle.ridge ]
                    [ "borderStyle" ==> "ridge" ]
                test
                    "Borderstyle inset"
                    [ BorderStyle.inset ]
                    [ "borderStyle" ==> "inset" ]
                test
                    "Borderstyle outset"
                    [ BorderStyle.outset ]
                    [ "borderStyle" ==> "outset" ]
                test
                    "Borderstyle multiple"
                    [ BorderStyle.value(FssTypes.Border.Style.Inset, FssTypes.Border.Style.Outset, FssTypes.Border.Style.Ridge, FssTypes.Border.Style.Groove) ]
                    [ "borderStyle" ==> "inset outset ridge groove" ]
                test
                    "Borderstyle none"
                    [ BorderStyle.none ]
                    [ "borderStyle" ==> "none" ]
                test
                    "Borderstyle initial"
                    [ BorderStyle.initial ]
                    [ "borderStyle" ==> "initial" ]
                test
                    "Borderstyle inherit"
                    [ BorderStyle.inherit' ]
                    [ "borderStyle" ==> "inherit" ]
                test
                    "Borderstyle unset"
                    [ BorderStyle.unset ]
                    [ "borderStyle" ==> "unset" ]
                test
                    "Border radius px"
                    [ BorderRadius' (px 10)]
                    [ "borderRadius" ==> "10px" ]
                test
                    "Border radius percent"
                    [ BorderRadius' (pct 50)]
                    [ "borderRadius" ==> "50%" ]
                test
                    "Border top left radius px"
                    [ BorderTopLeftRadius' (px 10)]
                    ["borderTopLeftRadius" ==> "10px"]
                test
                    "Border top right radius px"
                    [ BorderTopRightRadius' (px 10)]
                    ["borderTopRightRadius" ==> "10px"]
                test
                    "Border bottom left radius"
                    [ BorderBottomLeftRadius' (px 10)]
                    ["borderBottomLeftRadius" ==> "10px"]
                test
                    "Border bottom right radius px"
                    [ BorderBottomRightRadius' (px 10)]
                    ["borderBottomRightRadius" ==> "10px"]
                test
                    "Border radius multiple px"
                    [ BorderRadius.value (px 10, px 20, px 30, px 40) ]
                    [ "borderRadius" ==> "10px 20px 30px 40px" ]
                test
                    "Border radius top left initial"
                    [ BorderTopLeftRadius.initial ]
                    ["borderTopLeftRadius" ==> "initial"]
                test
                    "Border radius top right inherit"
                    [ BorderTopRightRadius.inherit' ]
                    ["borderTopRightRadius" ==> "inherit"]
                test
                    "Border bottom left radius unset"
                    [ BorderBottomLeftRadius.unset ]
                    ["borderBottomLeftRadius" ==> "unset"]
                test
                    "Border bottom right radius initial"
                    [ BorderBottomRightRadius.initial ]
                    ["borderBottomRightRadius" ==> "initial"]
                test
                    "Border radius inherit"
                    [ BorderRadius.inherit' ]
                    ["borderRadius" ==> "inherit"]
                test
                    "Border radius inherit"
                    [ BorderRadius.inherit' ]
                    ["borderRadius" ==> "inherit"]
                test
                    "Border radius unset"
                    [ BorderRadius.unset ]
                    ["borderRadius" ==> "unset"]
                test
                    "Border width px"
                    [ BorderWidth' (px 40) ]
                    [ "borderWidth" ==> "40px" ]
                test
                    "Border width thin"
                    [ BorderWidth.thin ]
                    [ "borderWidth" ==> "thin" ]
                test
                    "Border width medium"
                    [ BorderWidth.medium ]
                    [ "borderWidth" ==> "medium" ]
                test
                    "Border width thick"
                    [ BorderWidth.thick ]
                    [ "borderWidth" ==> "thick" ]
                test
                    "Border width initial"
                    [ BorderWidth.initial ]
                    [ "borderWidth" ==> "initial" ]
                test
                    "Border width inherit"
                    [ BorderWidth.inherit' ]
                    [ "borderWidth" ==> "inherit" ]
                test
                    "Border width unset"
                    [ BorderWidth.unset ]
                    [ "borderWidth" ==> "unset" ]
                test
                    "Border widths combination"
                    [ BorderWidth.value (px 1, px 20, em 3.0, rem 4.5) ]
                    [ "borderWidth" ==> "1px 20px 3.0em 4.5rem" ]
                test
                    "Border left width px"
                    [ BorderLeftWidth' (px 40) ]
                    ["borderLeftWidth" ==> "40px"]
                test
                    "Border right width cm"
                    [ BorderRightWidth' (cm 40.0) ]
                    ["borderRightWidth" ==> "40.0cm"]
                test
                    "Border color red"
                    [ BorderColor.red ]
                    [ "borderColor" ==> "#ff0000" ]
                test
                    "Border color initial"
                    [ BorderColor.initial ]
                    [ "borderColor" ==> "initial" ]
                test
                    "Border color inherit"
                    [ BorderColor.inherit' ]
                    [ "borderColor" ==> "inherit" ]
                test
                    "Border color unset"
                    [ BorderColor.unset ]
                    [ "borderColor" ==> "unset" ]
                test
                    "Border colors multiple"
                    [ BorderColor.value (FssTypes.Color.red, FssTypes.Color.green, FssTypes.Color.blue, FssTypes.Color.white) ]
                    [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]
                test
                    "Border top color rgb"
                    [ BorderTopColor.rgb 255 0 0 ]
                    ["borderTopColor" ==> "rgb(255, 0, 0)"]
                test
                    "Border right color green"
                    [ BorderRightColor.green ]
                    ["borderRightColor" ==> "#008000"]
                test
                    "Border bottom color"
                    [ BorderBottomColor.blue ]
                    ["borderBottomColor" ==> "#0000ff"]
                test
                    "Border left color"
                    [ BorderLeftColor.white ]
                    ["borderLeftColor" ==> "#ffffff"]
                test
                    "Border collapse collapse"
                    [ BorderCollapse.collapse ]
                    [ "borderCollapse" ==> "collapse" ]
                test
                    "Border collapse separate"
                    [ BorderCollapse.separate ]
                    [ "borderCollapse" ==> "separate" ]
                test
                    "Border collapse initial"
                    [ BorderCollapse.initial ]
                    [ "borderCollapse" ==> "initial" ]
                test
                    "Border collapse inherit"
                    [ BorderCollapse.inherit' ]
                    [ "borderCollapse" ==> "inherit" ]
                test
                    "Border collapse unset"
                    [ BorderCollapse.unset ]
                    [ "borderCollapse" ==> "unset" ]
                test
                    "Border spacing px"
                    [ BorderSpacing' (px 2) ]
                    [ "borderSpacing" ==> "2px" ]
                test
                    "Border spacing px"
                    [ BorderSpacing.value (px 2, px 2) ]
                    [ "borderSpacing" ==> "2px 2px" ]
                test
                    "Border spacing initial"
                    [ BorderSpacing.initial ]
                    [ "borderSpacing" ==> "initial" ]
                test
                    "Border spacing inherit"
                    [ BorderSpacing.inherit' ]
                    [ "borderSpacing" ==> "inherit" ]
                test
                    "Border spacing unset"
                    [ BorderSpacing.unset ]
                    [ "borderSpacing" ==> "unset" ]
                test
                    "Border image source none"
                    [ BorderImageSource.none ]
                    [ "borderImageSource" ==> "none" ]
                test
                    "Border image source url"
                    [ BorderImageSource.url "image.jpg" ]
                    [ "borderImageSource" ==> "url(image.jpg)" ]
                test
                    "Border image source linear gradient"
                    [ BorderImageSource.linearGradient(deg 45., [ FssTypes.Color.red, pct 0; FssTypes.Color.blue, pct 100 ]) ]
                    [ "borderImageSource" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)" ]
                test
                    "Border image source inherit"
                    [ BorderImageSource.inherit' ]
                    [ "borderImageSource" ==> "inherit" ]
                test
                    "Border image source initial"
                    [ BorderImageSource.initial ]
                    [ "borderImageSource" ==> "initial" ]
                test
                    "Border image source unset"
                    [ BorderImageSource.unset ]
                    [ "borderImageSource" ==> "unset" ]
                test
                    "Border image width auto"
                    [ BorderImageWidth.auto ]
                    [ "borderImageWidth" ==> "auto" ]
                test
                    "Border image width rem"
                    [ BorderImageWidth' (rem 1.) ]
                    [ "borderImageWidth" ==> "1.0rem" ]
                test
                    "Border image width percent"
                    [ BorderImageWidth' (pct 25) ]
                    [ "borderImageWidth" ==> "25%" ]
                test
                    "Border image width value"
                    [ BorderImageWidth' (FssTypes.CssFloat 3.) ]
                    [ "borderImageWidth" ==> "3" ]
                test
                    "Border image width vertical horizontal"
                    [ BorderImageWidth.value (em 2., em 3.) ]
                    [ "borderImageWidth" ==> "2.0em 3.0em" ]
                test
                    "Border image width top horizontal bottom"
                    [ BorderImageWidth.value (pct 5, pct 15, pct 10) ]
                    [ "borderImageWidth" ==> "5% 15% 10%" ]
                test
                    "Border image width top right bottom left"
                    [ BorderImageWidth.value (pct 5, em 2., pct 10, px 2) ]
                    [ "borderImageWidth" ==> "5% 2.0em 10% 2px" ]
                test
                    "Border image width inherit"
                    [ BorderImageWidth.inherit' ]
                    [ "borderImageWidth" ==> "inherit" ]
                test
                    "Border image width initial"
                    [ BorderImageWidth.initial ]
                    [ "borderImageWidth" ==> "initial" ]
                test
                    "Border image width unset"
                    [ BorderImageWidth.unset ]
                    [ "borderImageWidth" ==> "unset" ]
                test
                    "Border image repeat stretch"
                    [ BorderImageRepeat.stretch ]
                    [ "borderImageRepeat" ==> "stretch" ]
                test
                    "Border image repeat repeat"
                    [ BorderImageRepeat.repeat ]
                    [ "borderImageRepeat" ==> "repeat" ]
                test
                    "Border image repeat round"
                    [ BorderImageRepeat.round ]
                    [ "borderImageRepeat" ==> "round" ]
                test
                    "Border image repeat space"
                    [ BorderImageRepeat.space ]
                    [ "borderImageRepeat" ==> "space" ]
                test
                    "Border image repeat space"
                    [ BorderImageRepeat.value(FssTypes.Border.ImageRepeat.Stretch, FssTypes.Border.ImageRepeat.Repeat) ]
                    [ "borderImageRepeat" ==> "stretch repeat" ]
                test
                    "Border image repeat inherit"
                    [ BorderImageRepeat.inherit' ]
                    [ "borderImageRepeat" ==> "inherit" ]
                test
                    "Border image repeat initial"
                    [ BorderImageRepeat.initial ]
                    [ "borderImageRepeat" ==> "initial" ]
                test
                    "Border image repeat unset"
                    [ BorderImageRepeat.unset ]
                    [ "borderImageRepeat" ==> "unset" ]
                test
                    "Border image slice percent"
                    [ BorderImageSlice' (pct 30) ]
                    [ "borderImageSlice" ==> "30%" ]
                test
                    "Border image slice multiple percent"
                    [ BorderImageSlice.value (pct 10, pct 30) ]
                    [ "borderImageSlice" ==> "10% 30%" ]
                test
                    "Border image slice top horizontal bottom"
                    [ BorderImageSlice.value (px 30, pct 30, px 45) ]
                    [ "borderImageSlice" ==> "30px 30% 45px" ]
                test
                    "Border image slice inherit"
                    [ BorderImageSlice.inherit' ]
                    [ "borderImageSlice" ==> "inherit" ]
                test
                    "Border image slice initial"
                    [ BorderImageSlice.initial ]
                    [ "borderImageSlice" ==> "initial" ]
                test
                    "Border image slice unset"
                    [ BorderImageSlice.unset ]
                    [ "borderImageSlice" ==> "unset" ]
                test
                    "Border image outset rem"
                    [ BorderImageOutset' (rem 1.) ]
                    [ "borderImageOutset" ==> "1.0rem" ]
                test
                    "Border image outset value"
                    [ BorderImageOutset' (FssTypes.Border.ImageOutset 1.5) ]
                    [ "borderImageOutset" ==> "1.5" ]
                test
                    "Border image outset vertical horizontal"
                    [ BorderImageOutset.value(FssTypes.Border.ImageOutset 1., FssTypes.Border.ImageOutset 1.2) ]
                    [ "borderImageOutset" ==> "1 1.2" ]
                test
                    "Border image outset top right bottom left"
                    [ BorderImageOutset.value (px 7, px 12, px 14, px 5) ]
                    [ "borderImageOutset" ==> "7px 12px 14px 5px" ]
                test
                    "Border image outset inherit"
                    [ BorderImageOutset.inherit' ]
                    [ "borderImageOutset" ==> "inherit" ]
                test
                    "Border image outset initial"
                    [ BorderImageOutset.initial ]
                    [ "borderImageOutset" ==> "initial" ]
                test
                    "Border image outset unset"
                    [ BorderImageOutset.unset ]
                    [ "borderImageOutset" ==> "unset" ]
            ]