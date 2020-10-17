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
                    [ BorderStyle Border.Hidden ]
                    [
                        "borderStyle" ==> "hidden"
                    ]

                test
                    "Borderstyle dotted"
                    [ BorderStyle Border.Dotted ]
                    [
                        "borderStyle" ==> "dotted"
                    ]

                test
                    "Borderstyle dashed"
                    [ BorderStyle Border.Dashed ]
                    [
                        "borderStyle" ==> "dashed"
                    ]

                test
                    "Borderstyle solid"
                    [ BorderStyle Border.Solid ]
                    [
                        "borderStyle" ==> "solid"
                    ]

                test
                    "Borderstyle double"
                    [ BorderStyle Border.Double ]
                    [
                        "borderStyle" ==> "double"
                    ]

                test
                    "Borderstyle groove"
                    [ BorderStyle Border.Groove ]
                    [
                        "borderStyle" ==> "groove"
                    ]

                test
                    "Borderstyle ridge"
                    [ BorderStyle Border.Ridge ]
                    [
                        "borderStyle" ==> "ridge"
                    ]

                test
                    "Borderstyle inset"
                    [ BorderStyle Border.Inset ]
                    [
                        "borderStyle" ==> "inset"
                    ]

                test
                    "Borderstyle outset"
                    [ BorderStyle Border.Outset ]
                    [
                        "borderStyle" ==> "outset"
                    ]

                test
                    "Borderstyle multiple"
                    [ BorderStyles [Border.Inset; Border.Outset; Border.Ridge; Border.Groove] ]
                    [
                        "borderStyle" ==> "inset outset ridge groove"
                    ]

                test
                    "Borderstyle none"
                    [ BorderStyle None ]
                    [
                        "borderStyle" ==> "none"
                    ]

                test
                    "Borderstyle initial"
                    [ BorderStyle Initial ]
                    [
                        "borderStyle" ==> "initial"
                    ]

                test
                    "Borderstyle inherit"
                    [ BorderStyle Inherit ]
                    [
                        "borderStyle" ==> "inherit"
                    ]

                test
                    "Borderstyle unset"
                    [ BorderStyle Unset ]
                    [
                        "borderStyle" ==> "unset"
                    ]

                test
                    "Border radius px"
                    [ BorderRadius (px 10)]
                         [
                             "borderRadius" ==> "10px"
                         ]

                test
                    "Border radius percent"
                    [ BorderRadius (pct 50)]
                         [
                             "borderRadius" ==> "50%"
                         ]

                test
                    "Border top left radius px"
                    [ BorderTopLeftRadius (px 10)]
                    ["borderTopLeftRadius" ==> "10px"]

                test
                    "Border top right radius px"
                    [ BorderTopRightRadius (px 10)]
                    ["borderTopRightRadius" ==> "10px"]

                test
                    "Border bottom left radius"
                    [ BorderBottomLeftRadius (px 10)]
                    ["borderBottomLeftRadius" ==> "10px"]

                test
                    "Border bottom right radius px"
                    [ BorderBottomRightRadius (px 10)]
                    ["borderBottomRightRadius" ==> "10px"]

                test
                    "Border radius multiple px"
                    [ BorderRadiuses [px 10; px 20; px 30; px 40] ]
                        [
                            "borderRadius" ==> "10px 20px 30px 40px"
                        ]

                test
                    "Border radius top left initial"
                    [ BorderTopLeftRadius Initial ]
                    ["borderTopLeftRadius" ==> "initial"]

                test
                    "Border radius top right inherit"
                    [ BorderTopRightRadius Inherit ]
                    ["borderTopRightRadius" ==> "inherit"]

                test
                    "Border bottom left radius unset"
                    [ BorderBottomLeftRadius Unset ]
                    ["borderBottomLeftRadius" ==> "unset"]

                test
                    "Border bottom right radius initial"
                    [ BorderBottomRightRadius Initial ]
                    ["borderBottomRightRadius" ==> "initial"]

                test
                    "Border radius inherit"
                    [ BorderRadius Inherit ]
                    ["borderRadius" ==> "inherit"]

                test
                    "Border radius inherit"
                    [ BorderRadius Inherit ]
                    ["borderRadius" ==> "inherit"]

                test
                    "Border radius unset"
                    [ BorderRadius Unset ]
                    ["borderRadius" ==> "unset"]

                test
                    "Border width px"
                    [ BorderWidth (px 40) ]
                    [ "borderWidth" ==> "40px" ]

                test
                    "Border width thin"
                    [ BorderWidth Border.Thin ]
                    [ "borderWidth" ==> "thin" ]

                test
                    "Border width medium"
                    [ BorderWidth Border.Medium ]
                    [ "borderWidth" ==> "medium" ]

                test
                    "Border width thick"
                    [ BorderWidth Border.Thick ]
                    [ "borderWidth" ==> "thick" ]

                test
                    "Border width initial"
                    [ BorderWidth Initial ]
                    [ "borderWidth" ==> "initial" ]

                test
                    "Border width inherit"
                    [ BorderWidth Inherit ]
                    [ "borderWidth" ==> "inherit" ]

                test
                    "Border width unset"
                    [ BorderWidth Unset ]
                    [ "borderWidth" ==> "unset" ]

                test
                    "Border widths combination"
                    [ BorderWidths [Border.Thin; px 20; em 3.0; rem 4.5 ]]
                    [ "borderWidth" ==> "thin 20px 3.0em 4.5rem" ]

                test
                    "Border left width px"
                    [ BorderLeftWidth (px 40) ]
                    ["borderLeftWidth" ==> "40px"]

                test
                    "Border right width cm"
                    [ BorderRightWidth (cm 40.0) ]
                    ["borderRightWidth" ==> "40.0cm"]

                test
                    "Border color red"
                    [ BorderColor Color.red ]
                    [ "borderColor" ==> "#ff0000" ]

                test
                    "Border color initial"
                    [ BorderColor Initial ]
                    [ "borderColor" ==> "initial" ]

                test
                    "Border color inherit"
                    [ BorderColor Inherit ]
                    [ "borderColor" ==> "inherit" ]

                test
                    "Border color unset"
                    [ BorderColor Unset ]
                    [ "borderColor" ==> "unset" ]

                test
                    "Border colors multiple"
                    [ BorderColors [ Color.red; Color.green; Color.blue; Color.white] ]
                    [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]

                test
                    "Border top color rgb"
                    [ BorderTopColor (rgb 255 0 0) ]
                    ["borderTopColor" ==> "rgb(255, 0, 0)"]

                test
                    "Border right color green"
                    [ BorderRightColor Color.green ]
                    ["borderRightColor" ==> "#008000"]

                test
                    "Border bottom color"
                    [ BorderBottomColor Color.blue ]
                    ["borderBottomColor" ==> "#0000ff"]

                test
                    "Border left color"
                    [ BorderLeftColor Color.white ]
                    ["borderLeftColor" ==> "#ffffff"]


                test
                    "Border collapse collapse"
                    [ BorderCollapse Border.Collapse ]
                    [ "borderCollapse" ==> "collapse" ]

                test
                    "Border collapse separate"
                    [ BorderCollapse Border.Separate ]
                    [ "borderCollapse" ==> "separate" ]

                test
                    "Border collapse initial"
                    [ BorderCollapse Initial ]
                    [ "borderCollapse" ==> "initial" ]

                test
                    "Border collapse inherit"
                    [ BorderCollapse Inherit ]
                    [ "borderCollapse" ==> "inherit" ]

                test
                    "Border collapse unset"
                    [ BorderCollapse Unset ]
                    [ "borderCollapse" ==> "unset" ]

                test
                    "Border spacing px"
                    [ BorderSpacing (px 2) ]
                    [ "borderSpacing" ==> "2px" ]

                test
                    "Border spacing px"
                    [ BorderSpacing2 (px 2, px 2) ]
                    [ "borderSpacing" ==> "2px 2px" ]

                test
                    "Border spacing initial"
                    [ BorderSpacing Initial ]
                    [ "borderSpacing" ==> "initial" ]

                test
                    "Border spacing inherit"
                    [ BorderSpacing Inherit ]
                    [ "borderSpacing" ==> "inherit" ]

                test
                    "Border spacing unset"
                    [ BorderSpacing Unset ]
                    [ "borderSpacing" ==> "unset" ]
                    
                test
                    "Border image source none"
                    [ BorderImageSource None ]
                    [ "borderImageSource" ==> "none" ]
                    
                test
                    "Border image source url"
                    [ BorderImageSource (Image.Url "image.jpg") ]
                    [ "borderImageSource" ==> "url(image.jpg)" ]
                    
                test
                    "Border image source linear gradient"
                    [ BorderImageSource (Image.LinearGradient [ Image.Top; Color.red; Color.yellow ]) ]
                    [ "borderImageSource" ==> "linear-gradient(to top, #ff0000, #ffff00)" ]
                    
                test
                    "Border image source inherit"
                    [ BorderImageSource Inherit ]
                    [ "borderImageSource" ==> "inherit" ]
                    
                test
                    "Border image source initial"
                    [ BorderImageSource Initial ]
                    [ "borderImageSource" ==> "initial" ]
                    
                test
                    "Border image source unset"
                    [ BorderImageSource Unset ]
                    [ "borderImageSource" ==> "unset" ]
                    
                test
                    "Border image width auto"
                    [ BorderImageWidth Auto ]
                    [ "borderImageWidth" ==> "auto" ]
                    
                test
                    "Border image width rem"
                    [ BorderImageWidth (rem 1.) ]
                    [ "borderImageWidth" ==> "1.0rem" ]
                    
                test
                    "Border image width percent"
                    [ BorderImageWidth (pct 25) ]
                    [ "borderImageWidth" ==> "25%" ]
                    
                test
                    "Border image width percent"
                    [ BorderImageWidth (Border.Value 3) ]
                    [ "borderImageWidth" ==> "3" ]
                    
                test
                    "Border image width vertical horizontal"
                    [ BorderImageWidths [em 2.; em 3.] ]
                    [ "borderImageWidth" ==> "2.0em 3.0em" ]
                    
                test
                    "Border image width top horizontal bottom"
                    [ BorderImageWidths [pct 5; pct 15; pct 10] ]
                    [ "borderImageWidth" ==> "5% 15% 10%" ]
                    
                test
                    "Border image width top right bottom left"
                    [ BorderImageWidths [pct 5; em 2.; pct 10; Auto] ]
                    [ "borderImageWidth" ==> "5% 2.0em 10% auto" ]
                    
                test
                    "Border image width inherit"
                    [ BorderImageWidth Inherit ]
                    [ "borderImageWidth" ==> "inherit" ]
                    
                test
                    "Border image width initial"
                    [ BorderImageWidth Initial ]
                    [ "borderImageWidth" ==> "initial" ]
                    
                test
                    "Border image width unset"
                    [ BorderImageWidth Unset ]
                    [ "borderImageWidth" ==> "unset" ]
            ]