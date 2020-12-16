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
                    "Borderstyle hidden"
                    [ BorderStyle.Hidden ]
                    [ "borderStyle" ==> "hidden" ]
                test
                    "Borderstyle dotted"
                    [ BorderStyle.Dotted ]
                    [ "borderStyle" ==> "dotted" ]
                test
                    "Borderstyle dashed"
                    [ BorderStyle.Dashed ]
                    [ "borderStyle" ==> "dashed" ]
                test
                    "Borderstyle solid"
                    [ BorderStyle.Solid ]
                    [ "borderStyle" ==> "solid" ]
                test
                    "Borderstyle double"
                    [ BorderStyle.Double ]
                    [ "borderStyle" ==> "double" ]
                test
                    "Borderstyle groove"
                    [ BorderStyle.Groove ]
                    [ "borderStyle" ==> "groove" ]
                test
                    "Borderstyle ridge"
                    [ BorderStyle.Ridge ]
                    [ "borderStyle" ==> "ridge" ]
                test
                    "Borderstyle inset"
                    [ BorderStyle.Inset ]
                    [ "borderStyle" ==> "inset" ]
                test
                    "Borderstyle outset"
                    [ BorderStyle.Outset ]
                    [ "borderStyle" ==> "outset" ]
                test
                    "Borderstyle multiple"
                    [ BorderStyle.Value(BorderType.Inset, BorderType.Outset, BorderType.Ridge, BorderType.Groove) ]
                    [ "borderStyle" ==> "inset outset ridge groove" ]
                test
                    "Borderstyle none"
                    [ BorderStyle.None ]
                    [ "borderStyle" ==> "none" ]
                test
                    "Borderstyle initial"
                    [ BorderStyle.Initial ]
                    [ "borderStyle" ==> "initial" ]
                test
                    "Borderstyle inherit"
                    [ BorderStyle.Inherit ]
                    [ "borderStyle" ==> "inherit" ]
                test
                    "Borderstyle unset"
                    [ BorderStyle.Unset ]
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
                    [ BorderRadius.Value (px 10, px 20, px 30, px 40) ]
                    [ "borderRadius" ==> "10px 20px 30px 40px" ]
                test
                    "Border radius top left initial"
                    [ BorderTopLeftRadius.Initial ]
                    ["borderTopLeftRadius" ==> "initial"]
                test
                    "Border radius top right inherit"
                    [ BorderTopRightRadius.Inherit ]
                    ["borderTopRightRadius" ==> "inherit"]
                test
                    "Border bottom left radius unset"
                    [ BorderBottomLeftRadius.Unset ]
                    ["borderBottomLeftRadius" ==> "unset"]
                test
                    "Border bottom right radius initial"
                    [ BorderBottomRightRadius.Initial ]
                    ["borderBottomRightRadius" ==> "initial"]
                test
                    "Border radius inherit"
                    [ BorderRadius.Inherit ]
                    ["borderRadius" ==> "inherit"]
                test
                    "Border radius inherit"
                    [ BorderRadius.Inherit ]
                    ["borderRadius" ==> "inherit"]
                test
                    "Border radius unset"
                    [ BorderRadius.Unset ]
                    ["borderRadius" ==> "unset"]
                test
                    "Border width px"
                    [ BorderWidth' (px 40) ]
                    [ "borderWidth" ==> "40px" ]
                test
                    "Border width thin"
                    [ BorderWidth.Thin ]
                    [ "borderWidth" ==> "thin" ]
                test
                    "Border width medium"
                    [ BorderWidth.Medium ]
                    [ "borderWidth" ==> "medium" ]
                test
                    "Border width thick"
                    [ BorderWidth.Thick ]
                    [ "borderWidth" ==> "thick" ]
                test
                    "Border width initial"
                    [ BorderWidth.Initial ]
                    [ "borderWidth" ==> "initial" ]
                test
                    "Border width inherit"
                    [ BorderWidth.Inherit ]
                    [ "borderWidth" ==> "inherit" ]
                test
                    "Border width unset"
                    [ BorderWidth.Unset ]
                    [ "borderWidth" ==> "unset" ]
                test
                    "Border widths combination"
                    [ BorderWidth.Value (px 1, px 20, em 3.0, rem 4.5) ]
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
                    [ BorderColor.Initial ]
                    [ "borderColor" ==> "initial" ]
                test
                    "Border color inherit"
                    [ BorderColor.Inherit ]
                    [ "borderColor" ==> "inherit" ]
                test
                    "Border color unset"
                    [ BorderColor.Unset ]
                    [ "borderColor" ==> "unset" ]
                test
                    "Border colors multiple"
                    [ BorderColor.Value (CSSColor.red, CSSColor.green, CSSColor.blue, CSSColor.white) ]
                    [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]
                test
                    "Border top color rgb"
                    [ BorderTopColor.Rgb 255 0 0 ]
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
                    [ BorderCollapse.Collapse ]
                    [ "borderCollapse" ==> "collapse" ]
                test
                    "Border collapse separate"
                    [ BorderCollapse.Separate ]
                    [ "borderCollapse" ==> "separate" ]
                test
                    "Border collapse initial"
                    [ BorderCollapse.Initial ]
                    [ "borderCollapse" ==> "initial" ]
                test
                    "Border collapse inherit"
                    [ BorderCollapse.Inherit ]
                    [ "borderCollapse" ==> "inherit" ]
                test
                    "Border collapse unset"
                    [ BorderCollapse.Unset ]
                    [ "borderCollapse" ==> "unset" ]
                test
                    "Border spacing px"
                    [ BorderSpacing' (px 2) ]
                    [ "borderSpacing" ==> "2px" ]
                test
                    "Border spacing px"
                    [ BorderSpacing.Value (px 2, px 2) ]
                    [ "borderSpacing" ==> "2px 2px" ]
                test
                    "Border spacing initial"
                    [ BorderSpacing.Initial ]
                    [ "borderSpacing" ==> "initial" ]
                test
                    "Border spacing inherit"
                    [ BorderSpacing.Inherit ]
                    [ "borderSpacing" ==> "inherit" ]
                test
                    "Border spacing unset"
                    [ BorderSpacing.Unset ]
                    [ "borderSpacing" ==> "unset" ]
                test
                    "Border image source none"
                    [ BorderImageSource.None ]
                    [ "borderImageSource" ==> "none" ]
                test
                    "Border image source url"
                    [ BorderImageSource.Url "image.jpg" ]
                    [ "borderImageSource" ==> "url(image.jpg)" ]
               // test
               //     "Border image source linear gradient"
               //     [ BorderImageSource.LinearGradient(ToTop, CSSColor.red, CSSColor.yellow) ]
               //     [ "borderImageSource" ==> "linear-gradient(to top, #ff0000, #ffff00)" ]
                test
                    "Border image source inherit"
                    [ BorderImageSource.Inherit ]
                    [ "borderImageSource" ==> "inherit" ]
                test
                    "Border image source initial"
                    [ BorderImageSource.Initial ]
                    [ "borderImageSource" ==> "initial" ]
                test
                    "Border image source unset"
                    [ BorderImageSource.Unset ]
                    [ "borderImageSource" ==> "unset" ]
                test
                    "Border image width auto"
                    [ BorderImageWidth.Auto ]
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
                    [ BorderImageWidth' (CssFloat 3.) ]
                    [ "borderImageWidth" ==> "3" ]
                test
                    "Border image width vertical horizontal"
                    [ BorderImageWidth.Value (em 2., em 3.) ]
                    [ "borderImageWidth" ==> "2.0em 3.0em" ]
                test
                    "Border image width top horizontal bottom"
                    [ BorderImageWidth.Value (pct 5, pct 15, pct 10) ]
                    [ "borderImageWidth" ==> "5% 15% 10%" ]
                test
                    "Border image width top right bottom left"
                    [ BorderImageWidth.Value (pct 5, em 2., pct 10, px 2) ]
                    [ "borderImageWidth" ==> "5% 2.0em 10% 2px" ]
                test
                    "Border image width inherit"
                    [ BorderImageWidth.Inherit ]
                    [ "borderImageWidth" ==> "inherit" ]
                test
                    "Border image width initial"
                    [ BorderImageWidth.Initial ]
                    [ "borderImageWidth" ==> "initial" ]
                test
                    "Border image width unset"
                    [ BorderImageWidth.Unset ]
                    [ "borderImageWidth" ==> "unset" ]
                test
                    "Border image repeat stretch"
                    [ BorderImageRepeat.Stretch ]
                    [ "borderImageRepeat" ==> "stretch" ]
                test
                    "Border image repeat repeat"
                    [ BorderImageRepeat.Repeat ]
                    [ "borderImageRepeat" ==> "repeat" ]
                test
                    "Border image repeat round"
                    [ BorderImageRepeat.Round ]
                    [ "borderImageRepeat" ==> "round" ]
                test
                    "Border image repeat space"
                    [ BorderImageRepeat.Space ]
                    [ "borderImageRepeat" ==> "space" ]
                test
                    "Border image repeat space"
                    [ BorderImageRepeat.Value(BorderType.Stretch, BorderType.Repeat) ]
                    [ "borderImageRepeat" ==> "stretch repeat" ]
                test
                    "Border image repeat inherit"
                    [ BorderImageRepeat.Inherit ]
                    [ "borderImageRepeat" ==> "inherit" ]
                test
                    "Border image repeat initial"
                    [ BorderImageRepeat.Initial ]
                    [ "borderImageRepeat" ==> "initial" ]
                test
                    "Border image repeat unset"
                    [ BorderImageRepeat.Unset ]
                    [ "borderImageRepeat" ==> "unset" ]
                test
                    "Border image slice percent"
                    [ BorderImageSlice' (pct 30) ]
                    [ "borderImageSlice" ==> "30%" ]
                test
                    "Border image slice multiple percent"
                    [ BorderImageSlice.Value (pct 10, pct 30) ]
                    [ "borderImageSlice" ==> "10% 30%" ]
                test
                    "Border image slice top horizontal bottom"
                    [ BorderImageSlice.Value (px 30, pct 30, px 45) ]
                    [ "borderImageSlice" ==> "30px 30% 45px" ]
                test
                    "Border image slice inherit"
                    [ BorderImageSlice.Inherit ]
                    [ "borderImageSlice" ==> "inherit" ]
                test
                    "Border image slice initial"
                    [ BorderImageSlice.Initial ]
                    [ "borderImageSlice" ==> "initial" ]
                test
                    "Border image slice unset"
                    [ BorderImageSlice.Unset ]
                    [ "borderImageSlice" ==> "unset" ]
                test
                    "Border image outset rem"
                    [ BorderImageOutset' (rem 1.) ]
                    [ "borderImageOutset" ==> "1.0rem" ]
                test
                    "Border image outset value"
                    [ BorderImageOutset' (BorderType.BorderImageOutset 1.5) ]
                    [ "borderImageOutset" ==> "1.5" ]
                test
                    "Border image outset vertical horizontal"
                    [ BorderImageOutset.Value(BorderType.BorderImageOutset 1., BorderType.BorderImageOutset 1.2) ]
                    [ "borderImageOutset" ==> "1 1.2" ]
                test
                    "Border image outset top right bottom left"
                    [ BorderImageOutset.Value (px 7, px 12, px 14, px 5) ]
                    [ "borderImageOutset" ==> "7px 12px 14px 5px" ]
                test
                    "Border image outset inherit"
                    [ BorderImageOutset.Inherit ]
                    [ "borderImageOutset" ==> "inherit" ]
                test
                    "Border image outset initial"
                    [ BorderImageOutset.Initial ]
                    [ "borderImageOutset" ==> "initial" ]
                test
                    "Border image outset unset"
                    [ BorderImageOutset.Unset ]
                    [ "borderImageOutset" ==> "unset" ]
            ]