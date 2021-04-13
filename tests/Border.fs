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
                    "BorderTopStyle hidden"
                    [ BorderTopStyle.hidden ]
                    [ "borderTopStyle" ==> "hidden" ]
                testCase
                    "BorderTopStyle dotted"
                    [ BorderTopStyle.dotted ]
                    [ "borderTopStyle" ==> "dotted" ]
                testCase
                    "BorderTopStyle dashed"
                    [ BorderTopStyle.dashed ]
                    [ "borderTopStyle" ==> "dashed" ]
                testCase
                    "BorderTopStyle solid"
                    [ BorderTopStyle.solid ]
                    [ "borderTopStyle" ==> "solid" ]
                testCase
                    "BorderTopStyle double"
                    [ BorderTopStyle.double ]
                    [ "borderTopStyle" ==> "double" ]
                testCase
                    "BorderTopStyle groove"
                    [ BorderTopStyle.groove ]
                    [ "borderTopStyle" ==> "groove" ]
                testCase
                    "BorderTopStyle ridge"
                    [ BorderTopStyle.ridge ]
                    [ "borderTopStyle" ==> "ridge" ]
                testCase
                    "BorderTopStyle inset"
                    [ BorderTopStyle.inset ]
                    [ "borderTopStyle" ==> "inset" ]
                testCase
                    "BorderTopStyle outset"
                    [ BorderTopStyle.outset ]
                    [ "borderTopStyle" ==> "outset" ]
                testCase
                    "BorderTopStyle none"
                    [ BorderTopStyle.none ]
                    [ "borderTopStyle" ==> "none" ]
                testCase
                    "BorderTopStyle initial"
                    [ BorderTopStyle.initial ]
                    [ "borderTopStyle" ==> "initial" ]
                testCase
                    "BorderTopStyle inherit"
                    [ BorderTopStyle.inherit' ]
                    [ "borderTopStyle" ==> "inherit" ]
                testCase
                    "BorderTopStyle unset"
                    [ BorderTopStyle.unset ]
                    [ "borderTopStyle" ==> "unset" ]
                testCase
                    "BorderRightStyle hidden"
                    [ BorderRightStyle.hidden ]
                    [ "borderRightStyle" ==> "hidden" ]
                testCase
                    "BorderRightStyle dotted"
                    [ BorderRightStyle.dotted ]
                    [ "borderRightStyle" ==> "dotted" ]
                testCase
                    "BorderRightStyle dashed"
                    [ BorderRightStyle.dashed ]
                    [ "borderRightStyle" ==> "dashed" ]
                testCase
                    "BorderRightStyle solid"
                    [ BorderRightStyle.solid ]
                    [ "borderRightStyle" ==> "solid" ]
                testCase
                    "BorderRightStyle double"
                    [ BorderRightStyle.double ]
                    [ "borderRightStyle" ==> "double" ]
                testCase
                    "BorderRightStyle groove"
                    [ BorderRightStyle.groove ]
                    [ "borderRightStyle" ==> "groove" ]
                testCase
                    "BorderRightStyle ridge"
                    [ BorderRightStyle.ridge ]
                    [ "borderRightStyle" ==> "ridge" ]
                testCase
                    "BorderRightStyle inset"
                    [ BorderRightStyle.inset ]
                    [ "borderRightStyle" ==> "inset" ]
                testCase
                    "BorderRightStyle outset"
                    [ BorderRightStyle.outset ]
                    [ "borderRightStyle" ==> "outset" ]
                testCase
                    "BorderRightStyle none"
                    [ BorderRightStyle.none ]
                    [ "borderRightStyle" ==> "none" ]
                testCase
                    "BorderRightStyle initial"
                    [ BorderRightStyle.initial ]
                    [ "borderRightStyle" ==> "initial" ]
                testCase
                    "BorderRightStyle inherit"
                    [ BorderRightStyle.inherit' ]
                    [ "borderRightStyle" ==> "inherit" ]
                testCase
                    "BorderRightStyle unset"
                    [ BorderRightStyle.unset ]
                    [ "borderRightStyle" ==> "unset" ]
                testCase
                    "BorderBottomStyle hidden"
                    [ BorderBottomStyle.hidden ]
                    [ "borderBottomStyle" ==> "hidden" ]
                testCase
                    "BorderBottomStyle dotted"
                    [ BorderBottomStyle.dotted ]
                    [ "borderBottomStyle" ==> "dotted" ]
                testCase
                    "BorderBottomStyle dashed"
                    [ BorderBottomStyle.dashed ]
                    [ "borderBottomStyle" ==> "dashed" ]
                testCase
                    "BorderBottomStyle solid"
                    [ BorderBottomStyle.solid ]
                    [ "borderBottomStyle" ==> "solid" ]
                testCase
                    "BorderBottomStyle double"
                    [ BorderBottomStyle.double ]
                    [ "borderBottomStyle" ==> "double" ]
                testCase
                    "BorderBottomStyle groove"
                    [ BorderBottomStyle.groove ]
                    [ "borderBottomStyle" ==> "groove" ]
                testCase
                    "BorderBottomStyle ridge"
                    [ BorderBottomStyle.ridge ]
                    [ "borderBottomStyle" ==> "ridge" ]
                testCase
                    "BorderBottomStyle inset"
                    [ BorderBottomStyle.inset ]
                    [ "borderBottomStyle" ==> "inset" ]
                testCase
                    "BorderBottomStyle outset"
                    [ BorderBottomStyle.outset ]
                    [ "borderBottomStyle" ==> "outset" ]
                testCase
                    "BorderBottomStyle none"
                    [ BorderBottomStyle.none ]
                    [ "borderBottomStyle" ==> "none" ]
                testCase
                    "BorderBottomStyle initial"
                    [ BorderBottomStyle.initial ]
                    [ "borderBottomStyle" ==> "initial" ]
                testCase
                    "BorderBottomStyle inherit"
                    [ BorderBottomStyle.inherit' ]
                    [ "borderBottomStyle" ==> "inherit" ]
                testCase
                    "BorderBottomStyle unset"
                    [ BorderBottomStyle.unset ]
                    [ "borderBottomStyle" ==> "unset" ]
                testCase
                    "BorderLeftStyle hidden"
                    [ BorderLeftStyle.hidden ]
                    [ "borderLeftStyle" ==> "hidden" ]
                testCase
                    "BorderLeftStyle dotted"
                    [ BorderLeftStyle.dotted ]
                    [ "borderLeftStyle" ==> "dotted" ]
                testCase
                    "BorderLeftStyle dashed"
                    [ BorderLeftStyle.dashed ]
                    [ "borderLeftStyle" ==> "dashed" ]
                testCase
                    "BorderLeftStyle solid"
                    [ BorderLeftStyle.solid ]
                    [ "borderLeftStyle" ==> "solid" ]
                testCase
                    "BorderLeftStyle double"
                    [ BorderLeftStyle.double ]
                    [ "borderLeftStyle" ==> "double" ]
                testCase
                    "BorderLeftStyle groove"
                    [ BorderLeftStyle.groove ]
                    [ "borderLeftStyle" ==> "groove" ]
                testCase
                    "BorderLeftStyle ridge"
                    [ BorderLeftStyle.ridge ]
                    [ "borderLeftStyle" ==> "ridge" ]
                testCase
                    "BorderLeftStyle inset"
                    [ BorderLeftStyle.inset ]
                    [ "borderLeftStyle" ==> "inset" ]
                testCase
                    "BorderLeftStyle outset"
                    [ BorderLeftStyle.outset ]
                    [ "borderLeftStyle" ==> "outset" ]
                testCase
                    "BorderLeftStyle none"
                    [ BorderLeftStyle.none ]
                    [ "borderLeftStyle" ==> "none" ]
                testCase
                    "BorderLeftStyle initial"
                    [ BorderLeftStyle.initial ]
                    [ "borderLeftStyle" ==> "initial" ]
                testCase
                    "BorderLeftStyle inherit"
                    [ BorderLeftStyle.inherit' ]
                    [ "borderLeftStyle" ==> "inherit" ]
                testCase
                    "BorderLeftStyle unset"
                    [ BorderLeftStyle.unset ]
                    [ "borderLeftStyle" ==> "unset" ]
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
                    "Border top width px"
                    [ BorderTopWidth' (px 40) ]
                    [ "borderTopWidth" ==> "40px" ]
                testCase
                    "Border top width thin"
                    [ BorderTopWidth.thin ]
                    [ "borderTopWidth" ==> "thin" ]
                testCase
                    "Border top width medium"
                    [ BorderTopWidth.medium ]
                    [ "borderTopWidth" ==> "medium" ]
                testCase
                    "Border top width thick"
                    [ BorderTopWidth.thick ]
                    [ "borderTopWidth" ==> "thick" ]
                testCase
                    "Border top width initial"
                    [ BorderTopWidth.initial ]
                    [ "borderTopWidth" ==> "initial" ]
                testCase
                    "Border top width inherit"
                    [ BorderTopWidth.inherit' ]
                    [ "borderTopWidth" ==> "inherit" ]
                testCase
                    "Border top width unset"
                    [ BorderTopWidth.unset ]
                    [ "borderTopWidth" ==> "unset" ]
                testCase
                    "Border right width px"
                    [ BorderRightWidth' (px 40) ]
                    [ "borderRightWidth" ==> "40px" ]
                testCase
                    "Border right width thin"
                    [ BorderRightWidth.thin ]
                    [ "borderRightWidth" ==> "thin" ]
                testCase
                    "Border right width medium"
                    [ BorderRightWidth.medium ]
                    [ "borderRightWidth" ==> "medium" ]
                testCase
                    "Border right width thick"
                    [ BorderRightWidth.thick ]
                    [ "borderRightWidth" ==> "thick" ]
                testCase
                    "Border right width initial"
                    [ BorderRightWidth.initial ]
                    [ "borderRightWidth" ==> "initial" ]
                testCase
                    "Border right width inherit"
                    [ BorderRightWidth.inherit' ]
                    [ "borderRightWidth" ==> "inherit" ]
                testCase
                    "Border right width unset"
                    [ BorderRightWidth.unset ]
                    [ "borderRightWidth" ==> "unset" ]
                testCase
                    "Border bottom width px"
                    [ BorderBottomWidth' (px 40) ]
                    [ "borderBottomWidth" ==> "40px" ]
                testCase
                    "Border bottom width thin"
                    [ BorderBottomWidth.thin ]
                    [ "borderBottomWidth" ==> "thin" ]
                testCase
                    "Border bottom width medium"
                    [ BorderBottomWidth.medium ]
                    [ "borderBottomWidth" ==> "medium" ]
                testCase
                    "Border bottom width thick"
                    [ BorderBottomWidth.thick ]
                    [ "borderBottomWidth" ==> "thick" ]
                testCase
                    "Border bottom width initial"
                    [ BorderBottomWidth.initial ]
                    [ "borderBottomWidth" ==> "initial" ]
                testCase
                    "Border bottom width inherit"
                    [ BorderBottomWidth.inherit' ]
                    [ "borderBottomWidth" ==> "inherit" ]
                testCase
                    "Border bottom width unset"
                    [ BorderBottomWidth.unset ]
                    [ "borderBottomWidth" ==> "unset" ]
                testCase
                    "Border left width px"
                    [ BorderLeftWidth' (px 40) ]
                    [ "borderLeftWidth" ==> "40px" ]
                testCase
                    "Border left width thin"
                    [ BorderLeftWidth.thin ]
                    [ "borderLeftWidth" ==> "thin" ]
                testCase
                    "Border left width medium"
                    [ BorderLeftWidth.medium ]
                    [ "borderLeftWidth" ==> "medium" ]
                testCase
                    "Border left width thick"
                    [ BorderLeftWidth.thick ]
                    [ "borderLeftWidth" ==> "thick" ]
                testCase
                    "Border left width initial"
                    [ BorderLeftWidth.initial ]
                    [ "borderLeftWidth" ==> "initial" ]
                testCase
                    "Border left width inherit"
                    [ BorderLeftWidth.inherit' ]
                    [ "borderLeftWidth" ==> "inherit" ]
                testCase
                    "Border left width unset"
                    [ BorderLeftWidth.unset ]
                    [ "borderLeftWidth" ==> "unset" ]
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
                    [ BorderColor.value (FssTypes.Color.Color.red, FssTypes.Color.Color.green, FssTypes.Color.Color.blue, FssTypes.Color.Color.white) ]
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
                    [ BorderImageSource.linearGradient((deg 45., [ FssTypes.Color.Color.red, pct 0; FssTypes.Color.Color.blue, pct 100 ])) ]
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