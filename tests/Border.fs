namespace FSSTests

open Fet
open Utils
open Fss

module BorderTests =
     let tests =
        testList "Border"
            [
                testCase
                    "Border initial"
                    [ Border.initial ]
                    "{border:initial;}"
                testCase
                    "Border inherit"
                    [ Border.inherit' ]
                    "{border:inherit;}"
                testCase
                    "Border unset"
                    [ Border.unset ]
                    "{border:unset;}"
                testCase
                    "Border revert"
                    [ Border.revert ]
                    "{border:revert;}"
                testCase
                    "Border none"
                    [ Border.none ]
                    "{border:none;}"
                testCase
                    "Border-style hidden"
                    [ BorderStyle.hidden ]
                    "{border-style:hidden;}"
                testCase
                    "Border-style dotted"
                    [ BorderStyle.dotted ]
                    "{border-style:dotted;}"
                testCase
                    "Border-style dashed"
                    [ BorderStyle.dashed ]
                    "{border-style:dashed;}"
                testCase
                    "Border-style solid"
                    [ BorderStyle.solid ]
                    "{border-style:solid;}"
                testCase
                    "Border-style double"
                    [ BorderStyle.double ]
                    "{border-style:double;}"
                testCase
                    "Border-style groove"
                    [ BorderStyle.groove ]
                    "{border-style:groove;}"
                testCase
                    "Border-style ridge"
                    [ BorderStyle.ridge ]
                    "{border-style:ridge;}"
                testCase
                    "Border-style inset"
                    [ BorderStyle.inset ]
                    "{border-style:inset;}"
                testCase
                    "Border-style outset"
                    [ BorderStyle.outset ]
                    "{border-style:outset;}"
                testCase
                    "Border-style multiple"
                    [ BorderStyle.value(Fss.Types.Border.Style.Inset, Fss.Types.Border.Style.Outset, Fss.Types.Border.Style.Ridge, Fss.Types.Border.Style.Groove) ]
                    "{border-style:inset outset ridge groove;}"
                testCase
                    "Border-style none"
                    [ BorderStyle.none ]
                    "{border-style:none;}"
                testCase
                    "Border-style initial"
                    [ BorderStyle.initial ]
                    "{border-style:initial;}"
                testCase
                    "Border-style inherit"
                    [ BorderStyle.inherit' ]
                    "{border-style:inherit;}"
                testCase
                    "Border-style unset"
                    [ BorderStyle.unset ]
                    "{border-style:unset;}"
                testCase
                    "Border-style revert"
                    [ BorderStyle.revert ]
                    "{border-style:revert;}"
                testCase
                    "Border-top-style hidden"
                    [ BorderTopStyle.hidden ]
                    "{border-top-style:hidden;}"
                testCase
                    "Border-top-style dotted"
                    [ BorderTopStyle.dotted ]
                    "{border-top-style:dotted;}"
                testCase
                    "Border-top-style dashed"
                    [ BorderTopStyle.dashed ]
                    "{border-top-style:dashed;}"
                testCase
                    "Border-top-style solid"
                    [ BorderTopStyle.solid ]
                    "{border-top-style:solid;}"
                testCase
                    "Border-top-style double"
                    [ BorderTopStyle.double ]
                    "{border-top-style:double;}"
                testCase
                    "Border-top-style groove"
                    [ BorderTopStyle.groove ]
                    "{border-top-style:groove;}"
                testCase
                    "Border-top-style ridge"
                    [ BorderTopStyle.ridge ]
                    "{border-top-style:ridge;}"
                testCase
                    "Border-top-style inset"
                    [ BorderTopStyle.inset ]
                    "{border-top-style:inset;}"
                testCase
                    "Border-top-style outset"
                    [ BorderTopStyle.outset ]
                    "{border-top-style:outset;}"
                testCase
                    "Border-top-style none"
                    [ BorderTopStyle.none ]
                    "{border-top-style:none;}"
                testCase
                    "Border-top-style initial"
                    [ BorderTopStyle.initial ]
                    "{border-top-style:initial;}"
                testCase
                    "Border-top-style inherit"
                    [ BorderTopStyle.inherit' ]
                    "{border-top-style:inherit;}"
                testCase
                    "Border-top-style unset"
                    [ BorderTopStyle.unset ]
                    "{border-top-style:unset;}"
                testCase
                    "Border-top-style revert"
                    [ BorderTopStyle.revert ]
                    "{border-top-style:revert;}"
                testCase
                    "Border-right-style hidden"
                    [ BorderRightStyle.hidden ]
                    "{border-right-style:hidden;}"
                testCase
                    "Border-right-style dotted"
                    [ BorderRightStyle.dotted ]
                    "{border-right-style:dotted;}"
                testCase
                    "Border-right-style dashed"
                    [ BorderRightStyle.dashed ]
                    "{border-right-style:dashed;}"
                testCase
                    "Border-right-style solid"
                    [ BorderRightStyle.solid ]
                    "{border-right-style:solid;}"
                testCase
                    "Border-right-style double"
                    [ BorderRightStyle.double ]
                    "{border-right-style:double;}"
                testCase
                    "Border-right-style groove"
                    [ BorderRightStyle.groove ]
                    "{border-right-style:groove;}"
                testCase
                    "Border-right-style ridge"
                    [ BorderRightStyle.ridge ]
                    "{border-right-style:ridge;}"
                testCase
                    "Border-right-style inset"
                    [ BorderRightStyle.inset ]
                    "{border-right-style:inset;}"
                testCase
                    "Border-right-style outset"
                    [ BorderRightStyle.outset ]
                    "{border-right-style:outset;}"
                testCase
                    "Border-right-style none"
                    [ BorderRightStyle.none ]
                    "{border-right-style:none;}"
                testCase
                    "Border-right-style initial"
                    [ BorderRightStyle.initial ]
                    "{border-right-style:initial;}"
                testCase
                    "Border-right-style inherit"
                    [ BorderRightStyle.inherit' ]
                    "{border-right-style:inherit;}"
                testCase
                    "Border-right-style unset"
                    [ BorderRightStyle.unset ]
                    "{border-right-style:unset;}"
                testCase
                    "Border-right-style revert"
                    [ BorderRightStyle.revert ]
                    "{border-right-style:revert;}"
                testCase
                    "Border-bottom-style hidden"
                    [ BorderBottomStyle.hidden ]
                    "{border-bottom-style:hidden;}"
                testCase
                    "Border-bottom-style dotted"
                    [ BorderBottomStyle.dotted ]
                    "{border-bottom-style:dotted;}"
                testCase
                    "Border-bottom-style dashed"
                    [ BorderBottomStyle.dashed ]
                    "{border-bottom-style:dashed;}"
                testCase
                    "Border-bottom-style solid"
                    [ BorderBottomStyle.solid ]
                    "{border-bottom-style:solid;}"
                testCase
                    "Border-bottom-style double"
                    [ BorderBottomStyle.double ]
                    "{border-bottom-style:double;}"
                testCase
                    "Border-bottom-style groove"
                    [ BorderBottomStyle.groove ]
                    "{border-bottom-style:groove;}"
                testCase
                    "Border-bottom-style ridge"
                    [ BorderBottomStyle.ridge ]
                    "{border-bottom-style:ridge;}"
                testCase
                    "Border-bottom-style inset"
                    [ BorderBottomStyle.inset ]
                    "{border-bottom-style:inset;}"
                testCase
                    "Border-bottom-style outset"
                    [ BorderBottomStyle.outset ]
                    "{border-bottom-style:outset;}"
                testCase
                    "Border-bottom-style none"
                    [ BorderBottomStyle.none ]
                    "{border-bottom-style:none;}"
                testCase
                    "Border-bottom-style initial"
                    [ BorderBottomStyle.initial ]
                    "{border-bottom-style:initial;}"
                testCase
                    "Border-bottom-style inherit"
                    [ BorderBottomStyle.inherit' ]
                    "{border-bottom-style:inherit;}"
                testCase
                    "Border-bottom-style unset"
                    [ BorderBottomStyle.unset ]
                    "{border-bottom-style:unset;}"
                testCase
                    "Border-bottom-style revert"
                    [ BorderBottomStyle.revert ]
                    "{border-bottom-style:revert;}"
                testCase
                    "Border-left-style hidden"
                    [ BorderLeftStyle.hidden ]
                    "{border-left-style:hidden;}"
                testCase
                    "Border-left-style dotted"
                    [ BorderLeftStyle.dotted ]
                    "{border-left-style:dotted;}"
                testCase
                    "Border-left-style dashed"
                    [ BorderLeftStyle.dashed ]
                    "{border-left-style:dashed;}"
                testCase
                    "Border-left-style solid"
                    [ BorderLeftStyle.solid ]
                    "{border-left-style:solid;}"
                testCase
                    "Border-left-style double"
                    [ BorderLeftStyle.double ]
                    "{border-left-style:double;}"
                testCase
                    "Border-left-style groove"
                    [ BorderLeftStyle.groove ]
                    "{border-left-style:groove;}"
                testCase
                    "Border-left-style ridge"
                    [ BorderLeftStyle.ridge ]
                    "{border-left-style:ridge;}"
                testCase
                    "Border-left-style inset"
                    [ BorderLeftStyle.inset ]
                    "{border-left-style:inset;}"
                testCase
                    "Border-left-style outset"
                    [ BorderLeftStyle.outset ]
                    "{border-left-style:outset;}"
                testCase
                    "Border-left-style none"
                    [ BorderLeftStyle.none ]
                    "{border-left-style:none;}"
                testCase
                    "Border-left-style initial"
                    [ BorderLeftStyle.initial ]
                    "{border-left-style:initial;}"
                testCase
                    "Border-left-style inherit"
                    [ BorderLeftStyle.inherit' ]
                    "{border-left-style:inherit;}"
                testCase
                    "Border-left-style unset"
                    [ BorderLeftStyle.unset ]
                    "{border-left-style:unset;}"
                testCase
                    "Border-left-style revert"
                    [ BorderLeftStyle.revert ]
                    "{border-left-style:revert;}"
                testCase
                    "Border radius px"
                    [ BorderRadius.value (px 10)]
                    "{border-radius:10px;}"
                testCase
                    "Border radius percent"
                    [ BorderRadius.value (pct 50)]
                    "{border-radius:50%;}"
                testCase
                    "Border top left radius px"
                    [ BorderTopLeftRadius.value (px 10)]
                    "{border-top-left-radius:10px;}"
                testCase
                    "Border top right radius px"
                    [ BorderTopRightRadius.value (px 10)]
                    "{border-top-right-radius:10px;}"
                testCase
                    "Border bottom left radius"
                    [ BorderBottomLeftRadius.value (px 10)]
                    "{border-bottom-left-radius:10px;}"
                testCase
                    "Border bottom right radius px"
                    [ BorderBottomRightRadius.value (px 10)]
                    "{border-bottom-right-radius:10px;}"
                testCase
                    "Border radius multiple px"
                    [ BorderRadius.value (px 10, px 20, px 30, px 40) ]
                    "{border-radius:10px 20px 30px 40px;}"
                testCase
                    "Border radius top left initial"
                    [ BorderTopLeftRadius.initial ]
                    "{border-top-left-radius:initial;}"
                testCase
                    "Border radius top right inherit"
                    [ BorderTopRightRadius.inherit' ]
                    "{border-top-right-radius:inherit;}"
                testCase
                    "Border bottom left radius unset"
                    [ BorderBottomLeftRadius.unset ]
                    "{border-bottom-left-radius:unset;}"
                testCase
                    "Border bottom left radius revert"
                    [ BorderBottomLeftRadius.revert ]
                    "{border-bottom-left-radius:revert;}"
                testCase
                    "Border bottom right radius initial"
                    [ BorderBottomRightRadius.initial ]
                    "{border-bottom-right-radius:initial;}"
                testCase
                    "Border radius inherit"
                    [ BorderRadius.inherit' ]
                    "{border-radius:inherit;}"
                testCase
                    "Border radius inherit"
                    [ BorderRadius.inherit' ]
                    "{border-radius:inherit;}"
                testCase
                    "Border radius unset"
                    [ BorderRadius.unset ]
                    "{border-radius:unset;}"
                testCase
                    "Border radius revert"
                    [ BorderRadius.revert ]
                    "{border-radius:revert;}"
                testCase
                    "Border width px"
                    [ BorderWidth.value (px 40) ]
                    "{border-width:40px;}"
                testCase
                    "Border width thin"
                    [ BorderWidth.thin ]
                    "{border-width:thin;}"
                testCase
                    "Border width medium"
                    [ BorderWidth.medium ]
                    "{border-width:medium;}"
                testCase
                    "Border width thick"
                    [ BorderWidth.thick ]
                    "{border-width:thick;}"
                testCase
                    "Border width initial"
                    [ BorderWidth.initial ]
                    "{border-width:initial;}"
                testCase
                    "Border width inherit"
                    [ BorderWidth.inherit' ]
                    "{border-width:inherit;}"
                testCase
                    "Border width unset"
                    [ BorderWidth.unset ]
                    "{border-width:unset;}"
                testCase
                    "Border width revert"
                    [ BorderWidth.revert ]
                    "{border-width:revert;}"
                testCase
                    "Border widths combination"
                    [ BorderWidth.value (px 1, px 20, em 3.0, rem 4.5) ]
                    "{border-width:1px 20px 3em 4.5rem;}"
                testCase
                    "Border top width px"
                    [ BorderTopWidth.value (px 40) ]
                    "{border-top-width:40px;}"
                testCase
                    "Border top width thin"
                    [ BorderTopWidth.thin ]
                    "{border-top-width:thin;}"
                testCase
                    "Border top width medium"
                    [ BorderTopWidth.medium ]
                    "{border-top-width:medium;}"
                testCase
                    "Border top width thick"
                    [ BorderTopWidth.thick ]
                    "{border-top-width:thick;}"
                testCase
                    "Border top width initial"
                    [ BorderTopWidth.initial ]
                    "{border-top-width:initial;}"
                testCase
                    "Border top width inherit"
                    [ BorderTopWidth.inherit' ]
                    "{border-top-width:inherit;}"
                testCase
                    "Border top width unset"
                    [ BorderTopWidth.unset ]
                    "{border-top-width:unset;}"
                testCase
                    "Border top width revert"
                    [ BorderTopWidth.revert ]
                    "{border-top-width:revert;}"
                testCase
                    "Border right width px"
                    [ BorderRightWidth.value (px 40) ]
                    "{border-right-width:40px;}"
                testCase
                    "Border right width thin"
                    [ BorderRightWidth.thin ]
                    "{border-right-width:thin;}"
                testCase
                    "Border right width medium"
                    [ BorderRightWidth.medium ]
                    "{border-right-width:medium;}"
                testCase
                    "Border right width thick"
                    [ BorderRightWidth.thick ]
                    "{border-right-width:thick;}"
                testCase
                    "Border right width initial"
                    [ BorderRightWidth.initial ]
                    "{border-right-width:initial;}"
                testCase
                    "Border right width inherit"
                    [ BorderRightWidth.inherit' ]
                    "{border-right-width:inherit;}"
                testCase
                    "Border right width unset"
                    [ BorderRightWidth.unset ]
                    "{border-right-width:unset;}"
                testCase
                    "Border right width revert"
                    [ BorderRightWidth.revert ]
                    "{border-right-width:revert;}"
                testCase
                    "Border bottom width px"
                    [ BorderBottomWidth.value (px 40) ]
                    "{border-bottom-width:40px;}"
                testCase
                    "Border bottom width thin"
                    [ BorderBottomWidth.thin ]
                    "{border-bottom-width:thin;}"
                testCase
                    "Border bottom width medium"
                    [ BorderBottomWidth.medium ]
                    "{border-bottom-width:medium;}"
                testCase
                    "Border bottom width thick"
                    [ BorderBottomWidth.thick ]
                    "{border-bottom-width:thick;}"
                testCase
                    "Border bottom width initial"
                    [ BorderBottomWidth.initial ]
                    "{border-bottom-width:initial;}"
                testCase
                    "Border bottom width inherit"
                    [ BorderBottomWidth.inherit' ]
                    "{border-bottom-width:inherit;}"
                testCase
                    "Border bottom width unset"
                    [ BorderBottomWidth.unset ]
                    "{border-bottom-width:unset;}"
                testCase
                    "Border bottom width revert"
                    [ BorderBottomWidth.revert ]
                    "{border-bottom-width:revert;}"
                testCase
                    "Border left width px"
                    [ BorderLeftWidth.value (px 40) ]
                    "{border-left-width:40px;}"
                testCase
                    "Border left width thin"
                    [ BorderLeftWidth.thin ]
                    "{border-left-width:thin;}"
                testCase
                    "Border left width medium"
                    [ BorderLeftWidth.medium ]
                    "{border-left-width:medium;}"
                testCase
                    "Border left width thick"
                    [ BorderLeftWidth.thick ]
                    "{border-left-width:thick;}"
                testCase
                    "Border left width initial"
                    [ BorderLeftWidth.initial ]
                    "{border-left-width:initial;}"
                testCase
                    "Border left width inherit"
                    [ BorderLeftWidth.inherit' ]
                    "{border-left-width:inherit;}"
                testCase
                    "Border left width unset"
                    [ BorderLeftWidth.unset ]
                    "{border-left-width:unset;}"
                testCase
                    "Border left width revert"
                    [ BorderLeftWidth.revert ]
                    "{border-left-width:revert;}"
                testCase
                    "Border color red"
                    [ BorderColor.red ]
                    "{border-color:red;}"
                testCase
                    "Border color initial"
                    [ BorderColor.initial ]
                    "{border-color:initial;}"
                testCase
                    "Border color inherit"
                    [ BorderColor.inherit' ]
                    "{border-color:inherit;}"
                testCase
                    "Border color unset"
                    [ BorderColor.unset ]
                    "{border-color:unset;}"
                testCase
                    "Border color revert"
                    [ BorderColor.revert ]
                    "{border-color:revert;}"
                testCase
                    "Border colors multiple"
                    [ BorderColor.value (Fss.Types.Color.Red, Fss.Types.Color.Green, Fss.Types.Color.Blue, Fss.Types.Color.White) ]
                    "{border-color:red green blue white;}"
                testCase
                    "Border top color rgb"
                    [ BorderTopColor.rgb 255 0 0 ]
                    "{border-top-color:rgb(255,0,0);}"
                testCase
                    "Border right color green"
                    [ BorderRightColor.green ]
                    "{border-right-color:green;}"
                testCase
                    "Border bottom color"
                    [ BorderBottomColor.blue ]
                    "{border-bottom-color:blue;}"
                testCase
                    "Border left color"
                    [ BorderLeftColor.white ]
                    "{border-left-color:white;}"
                testCase
                    "Border collapse collapse"
                    [ BorderCollapse.collapse ]
                    "{border-collapse:collapse;}"
                testCase
                    "Border collapse separate"
                    [ BorderCollapse.separate ]
                    "{border-collapse:separate;}"
                testCase
                    "Border collapse initial"
                    [ BorderCollapse.initial ]
                    "{border-collapse:initial;}"
                testCase
                    "Border collapse inherit"
                    [ BorderCollapse.inherit' ]
                    "{border-collapse:inherit;}"
                testCase
                    "Border collapse unset"
                    [ BorderCollapse.unset ]
                    "{border-collapse:unset;}"
                testCase
                    "Border collapse revert"
                    [ BorderCollapse.revert ]
                    "{border-collapse:revert;}"
                testCase
                    "Border spacing px"
                    [ BorderSpacing.value (px 2) ]
                    "{border-spacing:2px;}"
                testCase
                    "Border spacing px"
                    [ BorderSpacing.value (px 2, px 3) ]
                    "{border-spacing:2px 3px;}"
                testCase
                    "Border spacing initial"
                    [ BorderSpacing.initial ]
                    "{border-spacing:initial;}"
                testCase
                    "Border spacing inherit"
                    [ BorderSpacing.inherit' ]
                    "{border-spacing:inherit;}"
                testCase
                    "Border spacing unset"
                    [ BorderSpacing.unset ]
                    "{border-spacing:unset;}"
                testCase
                    "Border spacing revert"
                    [ BorderSpacing.revert ]
                    "{border-spacing:revert;}"
                testCase
                    "Border image source none"
                    [ BorderImageSource.none ]
                    "{border-image-source:none;}"
                testCase
                    "Border image source url"
                    [ BorderImageSource.url "image.jpg" ]
                    "{border-image-source:url(image.jpg);}"
                testCase
                    "Border image source linear gradient"
                    [ BorderImageSource.linearGradient((deg 45, [ Fss.Types.Color.Red, pct 0; Fss.Types.Color.Blue, pct 100 ])) ]
                    "{border-image-source:linear-gradient(45deg,red 0%,blue 100%);}"
                testCase
                    "Border image source inherit"
                    [ BorderImageSource.inherit' ]
                    "{border-image-source:inherit;}"
                testCase
                    "Border image source initial"
                    [ BorderImageSource.initial ]
                    "{border-image-source:initial;}"
                testCase
                    "Border image source unset"
                    [ BorderImageSource.unset ]
                    "{border-image-source:unset;}"
                testCase
                    "Border image width auto"
                    [ BorderImageWidth.auto ]
                    "{border-image-width:auto;}"
                testCase
                    "Border image width rem"
                    [ BorderImageWidth.value (rem 1) ]
                    "{border-image-width:1rem;}"
                testCase
                    "Border image width percent"
                    [ BorderImageWidth.value (pct 25) ]
                    "{border-image-width:25%;}"
                testCase
                    "Border image width value"
                    [ BorderImageWidth.value 3 ]
                    "{border-image-width:3;}"
                testCase
                    "Border image width vertical horizontal"
                    [ BorderImageWidth.value (em 2., em 3.) ]
                    "{border-image-width:2em 3em;}"
                testCase
                    "Border image width top horizontal bottom"
                    [ BorderImageWidth.value (pct 5, pct 15, pct 10) ]
                    "{border-image-width:5% 15% 10%;}"
                testCase
                    "Border image width top right bottom left"
                    [ BorderImageWidth.value (pct 5, em 2., pct 10, px 2) ]
                    "{border-image-width:5% 2em 10% 2px;}"
                testCase
                    "Border image width inherit"
                    [ BorderImageWidth.inherit' ]
                    "{border-image-width:inherit;}"
                testCase
                    "Border image width initial"
                    [ BorderImageWidth.initial ]
                    "{border-image-width:initial;}"
                testCase
                    "Border image width unset"
                    [ BorderImageWidth.unset ]
                    "{border-image-width:unset;}"
                testCase
                    "Border image width revert"
                    [ BorderImageWidth.revert ]
                    "{border-image-width:revert;}"
                testCase
                    "Border image repeat stretch"
                    [ BorderImageRepeat.stretch ]
                    "{border-image-repeat:stretch;}"
                testCase
                    "Border image repeat repeat"
                    [ BorderImageRepeat.repeat ]
                    "{border-image-repeat:repeat;}"
                testCase
                    "Border image repeat round"
                    [ BorderImageRepeat.round ]
                    "{border-image-repeat:round;}"
                testCase
                    "Border image repeat space"
                    [ BorderImageRepeat.space ]
                    "{border-image-repeat:space;}"
                testCase
                    "Border image repeat space"
                    [ BorderImageRepeat.value(Fss.Types.Border.ImageRepeat.Stretch, Fss.Types.Border.ImageRepeat.Repeat) ]
                    "{border-image-repeat:stretch repeat;}"
                testCase
                    "Border image repeat inherit"
                    [ BorderImageRepeat.inherit' ]
                    "{border-image-repeat:inherit;}"
                testCase
                    "Border image repeat initial"
                    [ BorderImageRepeat.initial ]
                    "{border-image-repeat:initial;}"
                testCase
                    "Border image repeat unset"
                    [ BorderImageRepeat.unset ]
                    "{border-image-repeat:unset;}"
                testCase
                    "Border image repeat revert"
                    [ BorderImageRepeat.revert ]
                    "{border-image-repeat:revert;}"
                testCase
                    "Border image slice percent"
                    [ BorderImageSlice.value (pct 30) ]
                    "{border-image-slice:30%;}"
                testCase
                    "Border image slice multiple percent"
                    [ BorderImageSlice.value (pct 10, pct 30) ]
                    "{border-image-slice:10% 30%;}"
                testCase
                    "Border image slice top horizontal bottom"
                    [ BorderImageSlice.value (px 30, pct 30, px 45) ]
                    "{border-image-slice:30px 30% 45px;}"
                testCase
                    "Border image slice inherit"
                    [ BorderImageSlice.inherit' ]
                    "{border-image-slice:inherit;}"
                testCase
                    "Border image slice initial"
                    [ BorderImageSlice.initial ]
                    "{border-image-slice:initial;}"
                testCase
                    "Border image slice unset"
                    [ BorderImageSlice.unset ]
                    "{border-image-slice:unset;}"
                testCase
                    "Border image slice revert"
                    [ BorderImageSlice.revert ]
                    "{border-image-slice:revert;}"
                testCase
                    "Border image outset rem"
                    [ BorderImageOutset.value (rem 1) ]
                    "{border-image-outset:1rem;}"
                testCase
                    "Border image outset value"
                    [ BorderImageOutset.value 1.5 ]
                    "{border-image-outset:1.5;}"
                testCase
                    "Border image outset vertical horizontal"
                    [ BorderImageOutset.value(1, 1.2) ]
                    "{border-image-outset:1 1.2;}"
                testCase
                    "Border image outset top right bottom left"
                    [ BorderImageOutset.value (px 7, px 12, px 14, px 5) ]
                    "{border-image-outset:7px 12px 14px 5px;}"
                testCase
                    "Border image outset inherit"
                    [ BorderImageOutset.inherit' ]
                    "{border-image-outset:inherit;}"
                testCase
                    "Border image outset initial"
                    [ BorderImageOutset.initial ]
                    "{border-image-outset:initial;}"
                testCase
                    "Border image outset unset"
                    [ BorderImageOutset.unset ]
                    "{border-image-outset:unset;}"
                testCase
                    "Border image outset revert"
                    [ BorderImageOutset.revert ]
                    "{border-image-outset:revert;}"
            ]
