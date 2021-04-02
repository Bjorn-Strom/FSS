namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Border =
     let tests =
        testList "Border"
            [
                testCase
                    "Border initial"
                    [ Border.initial ]
                    [ "border" ==> "initial" ]
                testCase
                    "Border inherit"
                    [ Border.inherit' ]
                    [ "border" ==> "inherit" ]
                testCase
                    "Border unset"
                    [ Border.unset ]
                    [ "border" ==> "unset" ]
                testCase
                    "Border none"
                    [ Border.none ]
                    [ "border" ==> "none" ]
                testCase
                    "Borderstyle hidden"
                    [ BorderStyle.hidden ]
                    [ "borderStyle" ==> "hidden" ]
                testCase
                    "Borderstyle dotted"
                    [ BorderStyle.dotted ]
                    [ "borderStyle" ==> "dotted" ]
                testCase
                    "Borderstyle dashed"
                    [ BorderStyle.dashed ]
                    [ "borderStyle" ==> "dashed" ]
                testCase
                    "Borderstyle solid"
                    [ BorderStyle.solid ]
                    [ "borderStyle" ==> "solid" ]
                testCase
                    "Borderstyle double"
                    [ BorderStyle.double ]
                    [ "borderStyle" ==> "double" ]
                testCase
                    "Borderstyle groove"
                    [ BorderStyle.groove ]
                    [ "borderStyle" ==> "groove" ]
                testCase
                    "Borderstyle ridge"
                    [ BorderStyle.ridge ]
                    [ "borderStyle" ==> "ridge" ]
                testCase
                    "Borderstyle inset"
                    [ BorderStyle.inset ]
                    [ "borderStyle" ==> "inset" ]
                testCase
                    "Borderstyle outset"
                    [ BorderStyle.outset ]
                    [ "borderStyle" ==> "outset" ]
                testCase
                    "Borderstyle multiple"
                    [ BorderStyle.value(FssTypes.Border.Style.Inset, FssTypes.Border.Style.Outset, FssTypes.Border.Style.Ridge, FssTypes.Border.Style.Groove) ]
                    [ "borderStyle" ==> "inset outset ridge groove" ]
                testCase
                    "Borderstyle none"
                    [ BorderStyle.none ]
                    [ "borderStyle" ==> "none" ]
                testCase
                    "Borderstyle initial"
                    [ BorderStyle.initial ]
                    [ "borderStyle" ==> "initial" ]
                testCase
                    "Borderstyle inherit"
                    [ BorderStyle.inherit' ]
                    [ "borderStyle" ==> "inherit" ]
                testCase
                    "Borderstyle unset"
                    [ BorderStyle.unset ]
                    [ "borderStyle" ==> "unset" ]
                testCase
                    "Border radius px"
                    [ BorderRadius' (px 10)]
                    [ "borderRadius" ==> "10px" ]
                testCase
                    "Border radius percent"
                    [ BorderRadius' (pct 50)]
                    [ "borderRadius" ==> "50%" ]
                testCase
                    "Border top left radius px"
                    [ BorderTopLeftRadius' (px 10)]
                    ["borderTopLeftRadius" ==> "10px"]
                testCase
                    "Border top right radius px"
                    [ BorderTopRightRadius' (px 10)]
                    ["borderTopRightRadius" ==> "10px"]
                testCase
                    "Border bottom left radius"
                    [ BorderBottomLeftRadius' (px 10)]
                    ["borderBottomLeftRadius" ==> "10px"]
                testCase
                    "Border bottom right radius px"
                    [ BorderBottomRightRadius' (px 10)]
                    ["borderBottomRightRadius" ==> "10px"]
                testCase
                    "Border radius multiple px"
                    [ BorderRadius.value (px 10, px 20, px 30, px 40) ]
                    [ "borderRadius" ==> "10px 20px 30px 40px" ]
                testCase
                    "Border radius top left initial"
                    [ BorderTopLeftRadius.initial ]
                    ["borderTopLeftRadius" ==> "initial"]
                testCase
                    "Border radius top right inherit"
                    [ BorderTopRightRadius.inherit' ]
                    ["borderTopRightRadius" ==> "inherit"]
                testCase
                    "Border bottom left radius unset"
                    [ BorderBottomLeftRadius.unset ]
                    ["borderBottomLeftRadius" ==> "unset"]
                testCase
                    "Border bottom right radius initial"
                    [ BorderBottomRightRadius.initial ]
                    ["borderBottomRightRadius" ==> "initial"]
                testCase
                    "Border radius inherit"
                    [ BorderRadius.inherit' ]
                    ["borderRadius" ==> "inherit"]
                testCase
                    "Border radius inherit"
                    [ BorderRadius.inherit' ]
                    ["borderRadius" ==> "inherit"]
                testCase
                    "Border radius unset"
                    [ BorderRadius.unset ]
                    ["borderRadius" ==> "unset"]
                testCase
                    "Border width px"
                    [ BorderWidth' (px 40) ]
                    [ "borderWidth" ==> "40px" ]
                testCase
                    "Border width thin"
                    [ BorderWidth.thin ]
                    [ "borderWidth" ==> "thin" ]
                testCase
                    "Border width medium"
                    [ BorderWidth.medium ]
                    [ "borderWidth" ==> "medium" ]
                testCase
                    "Border width thick"
                    [ BorderWidth.thick ]
                    [ "borderWidth" ==> "thick" ]
                testCase
                    "Border width initial"
                    [ BorderWidth.initial ]
                    [ "borderWidth" ==> "initial" ]
                testCase
                    "Border width inherit"
                    [ BorderWidth.inherit' ]
                    [ "borderWidth" ==> "inherit" ]
                testCase
                    "Border width unset"
                    [ BorderWidth.unset ]
                    [ "borderWidth" ==> "unset" ]
                testCase
                    "Border widths combination"
                    [ BorderWidth.value (px 1, px 20, em 3.0, rem 4.5) ]
                    [ "borderWidth" ==> "1px 20px 3.0em 4.5rem" ]
                testCase
                    "Border left width px"
                    [ BorderLeftWidth' (px 40) ]
                    ["borderLeftWidth" ==> "40px"]
                testCase
                    "Border right width cm"
                    [ BorderRightWidth' (cm 40.0) ]
                    ["borderRightWidth" ==> "40.0cm"]
                testCase
                    "Border color red"
                    [ BorderColor.red ]
                    [ "borderColor" ==> "#ff0000" ]
                testCase
                    "Border color initial"
                    [ BorderColor.initial ]
                    [ "borderColor" ==> "initial" ]
                testCase
                    "Border color inherit"
                    [ BorderColor.inherit' ]
                    [ "borderColor" ==> "inherit" ]
                testCase
                    "Border color unset"
                    [ BorderColor.unset ]
                    [ "borderColor" ==> "unset" ]
                testCase
                    "Border colors multiple"
                    [ BorderColor.value (FssTypes.Color.red, FssTypes.Color.green, FssTypes.Color.blue, FssTypes.Color.white) ]
                    [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]
                testCase
                    "Border top color rgb"
                    [ BorderTopColor.rgb 255 0 0 ]
                    ["borderTopColor" ==> "rgb(255, 0, 0)"]
                testCase
                    "Border right color green"
                    [ BorderRightColor.green ]
                    ["borderRightColor" ==> "#008000"]
                testCase
                    "Border bottom color"
                    [ BorderBottomColor.blue ]
                    ["borderBottomColor" ==> "#0000ff"]
                testCase
                    "Border left color"
                    [ BorderLeftColor.white ]
                    ["borderLeftColor" ==> "#ffffff"]
                testCase
                    "Border collapse collapse"
                    [ BorderCollapse.collapse ]
                    [ "borderCollapse" ==> "collapse" ]
                testCase
                    "Border collapse separate"
                    [ BorderCollapse.separate ]
                    [ "borderCollapse" ==> "separate" ]
                testCase
                    "Border collapse initial"
                    [ BorderCollapse.initial ]
                    [ "borderCollapse" ==> "initial" ]
                testCase
                    "Border collapse inherit"
                    [ BorderCollapse.inherit' ]
                    [ "borderCollapse" ==> "inherit" ]
                testCase
                    "Border collapse unset"
                    [ BorderCollapse.unset ]
                    [ "borderCollapse" ==> "unset" ]
                testCase
                    "Border spacing px"
                    [ BorderSpacing' (px 2) ]
                    [ "borderSpacing" ==> "2px" ]
                testCase
                    "Border spacing px"
                    [ BorderSpacing.value (px 2, px 2) ]
                    [ "borderSpacing" ==> "2px 2px" ]
                testCase
                    "Border spacing initial"
                    [ BorderSpacing.initial ]
                    [ "borderSpacing" ==> "initial" ]
                testCase
                    "Border spacing inherit"
                    [ BorderSpacing.inherit' ]
                    [ "borderSpacing" ==> "inherit" ]
                testCase
                    "Border spacing unset"
                    [ BorderSpacing.unset ]
                    [ "borderSpacing" ==> "unset" ]
                testCase
                    "Border image source none"
                    [ BorderImageSource.none ]
                    [ "borderImageSource" ==> "none" ]
                testCase
                    "Border image source url"
                    [ BorderImageSource.url "image.jpg" ]
                    [ "borderImageSource" ==> "url(image.jpg)" ]
                testCase
                    "Border image source linear gradient"
                    [ BorderImageSource.linearGradient(deg 45., [ FssTypes.Color.red, pct 0; FssTypes.Color.blue, pct 100 ]) ]
                    [ "borderImageSource" ==> "linear-gradient(45.00deg, #ff0000 0%, #0000ff 100%)" ]
                testCase
                    "Border image source inherit"
                    [ BorderImageSource.inherit' ]
                    [ "borderImageSource" ==> "inherit" ]
                testCase
                    "Border image source initial"
                    [ BorderImageSource.initial ]
                    [ "borderImageSource" ==> "initial" ]
                testCase
                    "Border image source unset"
                    [ BorderImageSource.unset ]
                    [ "borderImageSource" ==> "unset" ]
                testCase
                    "Border image width auto"
                    [ BorderImageWidth.auto ]
                    [ "borderImageWidth" ==> "auto" ]
                testCase
                    "Border image width rem"
                    [ BorderImageWidth' (rem 1.) ]
                    [ "borderImageWidth" ==> "1.0rem" ]
                testCase
                    "Border image width percent"
                    [ BorderImageWidth' (pct 25) ]
                    [ "borderImageWidth" ==> "25%" ]
                testCase
                    "Border image width value"
                    [ BorderImageWidth' (FssTypes.CssFloat 3.) ]
                    [ "borderImageWidth" ==> "3" ]
                testCase
                    "Border image width vertical horizontal"
                    [ BorderImageWidth.value (em 2., em 3.) ]
                    [ "borderImageWidth" ==> "2.0em 3.0em" ]
                testCase
                    "Border image width top horizontal bottom"
                    [ BorderImageWidth.value (pct 5, pct 15, pct 10) ]
                    [ "borderImageWidth" ==> "5% 15% 10%" ]
                testCase
                    "Border image width top right bottom left"
                    [ BorderImageWidth.value (pct 5, em 2., pct 10, px 2) ]
                    [ "borderImageWidth" ==> "5% 2.0em 10% 2px" ]
                testCase
                    "Border image width inherit"
                    [ BorderImageWidth.inherit' ]
                    [ "borderImageWidth" ==> "inherit" ]
                testCase
                    "Border image width initial"
                    [ BorderImageWidth.initial ]
                    [ "borderImageWidth" ==> "initial" ]
                testCase
                    "Border image width unset"
                    [ BorderImageWidth.unset ]
                    [ "borderImageWidth" ==> "unset" ]
                testCase
                    "Border image repeat stretch"
                    [ BorderImageRepeat.stretch ]
                    [ "borderImageRepeat" ==> "stretch" ]
                testCase
                    "Border image repeat repeat"
                    [ BorderImageRepeat.repeat ]
                    [ "borderImageRepeat" ==> "repeat" ]
                testCase
                    "Border image repeat round"
                    [ BorderImageRepeat.round ]
                    [ "borderImageRepeat" ==> "round" ]
                testCase
                    "Border image repeat space"
                    [ BorderImageRepeat.space ]
                    [ "borderImageRepeat" ==> "space" ]
                testCase
                    "Border image repeat space"
                    [ BorderImageRepeat.value(FssTypes.Border.ImageRepeat.Stretch, FssTypes.Border.ImageRepeat.Repeat) ]
                    [ "borderImageRepeat" ==> "stretch repeat" ]
                testCase
                    "Border image repeat inherit"
                    [ BorderImageRepeat.inherit' ]
                    [ "borderImageRepeat" ==> "inherit" ]
                testCase
                    "Border image repeat initial"
                    [ BorderImageRepeat.initial ]
                    [ "borderImageRepeat" ==> "initial" ]
                testCase
                    "Border image repeat unset"
                    [ BorderImageRepeat.unset ]
                    [ "borderImageRepeat" ==> "unset" ]
                testCase
                    "Border image slice percent"
                    [ BorderImageSlice' (pct 30) ]
                    [ "borderImageSlice" ==> "30%" ]
                testCase
                    "Border image slice multiple percent"
                    [ BorderImageSlice.value (pct 10, pct 30) ]
                    [ "borderImageSlice" ==> "10% 30%" ]
                testCase
                    "Border image slice top horizontal bottom"
                    [ BorderImageSlice.value (px 30, pct 30, px 45) ]
                    [ "borderImageSlice" ==> "30px 30% 45px" ]
                testCase
                    "Border image slice inherit"
                    [ BorderImageSlice.inherit' ]
                    [ "borderImageSlice" ==> "inherit" ]
                testCase
                    "Border image slice initial"
                    [ BorderImageSlice.initial ]
                    [ "borderImageSlice" ==> "initial" ]
                testCase
                    "Border image slice unset"
                    [ BorderImageSlice.unset ]
                    [ "borderImageSlice" ==> "unset" ]
                testCase
                    "Border image outset rem"
                    [ BorderImageOutset' (rem 1.) ]
                    [ "borderImageOutset" ==> "1.0rem" ]
                testCase
                    "Border image outset value"
                    [ BorderImageOutset' (FssTypes.Border.ImageOutset 1.5) ]
                    [ "borderImageOutset" ==> "1.5" ]
                testCase
                    "Border image outset vertical horizontal"
                    [ BorderImageOutset.value(FssTypes.Border.ImageOutset 1., FssTypes.Border.ImageOutset 1.2) ]
                    [ "borderImageOutset" ==> "1 1.2" ]
                testCase
                    "Border image outset top right bottom left"
                    [ BorderImageOutset.value (px 7, px 12, px 14, px 5) ]
                    [ "borderImageOutset" ==> "7px 12px 14px 5px" ]
                testCase
                    "Border image outset inherit"
                    [ BorderImageOutset.inherit' ]
                    [ "borderImageOutset" ==> "inherit" ]
                testCase
                    "Border image outset initial"
                    [ BorderImageOutset.initial ]
                    [ "borderImageOutset" ==> "initial" ]
                testCase
                    "Border image outset unset"
                    [ BorderImageOutset.unset ]
                    [ "borderImageOutset" ==> "unset" ]
            ]