namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Feliz.Fss

module Feliz =
    let tests =
        let animationSample =
            keyframes
                [
                    frame 0 [ style.backgroundColor.red ]
                    frame 100 [ style.backgroundColor.blue]
                ]
        testList "Feliz"
            [
                test
                    "Animation name"
                    [ style.animationName' animationSample ]
                    [ "animationName" ==> "animation-1oejj34" ]
                test
                    "Animation duration"
                    [ style.animationDuration' (sec 10.0) ]
                    [ "animationDuration" ==> "10.00s" ]
                test
                    "Animation timing function ease"
                    [ style.animationTimingFunction.Ease ]
                    ["animationTimingFunction" ==> "ease"]
                test
                    "Animation timing function cubic bezier"
                    [ style.animationTimingFunction.CubicBezier (0.0, 0.47, 0.32, 1.97) ]
                    ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                test
                    "Animation delay sec"
                    [ style.animationDelay' (sec 10.0) ]
                    ["animationDelay" ==> "10.00s"]
                test
                    "Animation iteration count infininte"
                    [ style.animationIterationCount.Infinite ]
                    ["animationIterationCount" ==> "infinite"]
                test
                    "Animation direction normal"
                    [ style.animationDirection.Normal ]
                    ["animationDirection" ==> "normal"]
                test
                    "Animation fill mode backwards"
                    [ style.animationFillMode.Backwards ]
                    ["animationFillMode" ==> "backwards"]
                test
                    "Animation play state running"
                    [ style.animationPlayState.Running ]
                    ["animationPlayState" ==> "running"]
                test
                    "Custom styles"
                    [ style.custom "text-decoration" "none"]
                    ["text-decoration" ==> "none"]
                test
                    "Background color"
                    [ style.backgroundColor.red ]
                    [ "backgroundColor" ==> "#ff0000" ]
                test
                    "Background origin"
                    [ style.backgroundOrigin.BorderBox ]
                    [ "backgroundOrigin" ==> "border-box" ]
                test
                    "Background repeat"
                    [ style.backgroundRepeat.Repeat ]
                    [ "backgroundRepeat" ==> "repeat" ]
                test
                    "Background size"
                    [ style.backgroundSize.Cover ]
                    [ "backgroundSize" ==> "cover" ]
                test
                    "Background attachment"
                    [ style.backgroundAttachment.Scroll ]
                    [ "backgroundAttachment" ==> "scroll" ]
                test
                    "Background image"
                    [ style.backgroundImage.Url "urlTest" ]
                    [ "backgroundImage" ==> "url(urlTest)" ]
                test
                    "Background position"
                    [ style.backgroundPosition.Bottom ]
                    [ "backgroundPosition" ==> "bottom" ]
                test
                    "Background blend mode"
                    [ style.backgroundBlendMode.Color ]
                    [ "backgroundBlendMode" ==> "color" ]
                test
                    "Isolation"
                    [ style.isolation.Unset ]
                    [ "isolation" ==> "unset" ]
                test
                    "Box decoration break"
                    [ style.boxDecorationBreak.Clone ]
                    [ "boxDecorationBreak" ==> "clone" ]
                test
                    "Color"
                    [ style.color.gainsboro]
                    [ "color" ==> "#dcdcdc" ]
                test
                    "Color"
                    [ style.color' (CssColor.red)]
                    [ "color" ==> "#ff0000" ]



                test
                    "Font synthesis weight"
                    [ style.fontSynthesis.Weight ]
                    [ "fontSynthesis" ==> "weight" ]
                test
                    "Font language override string"
                    [ style.fontLanguageOverride.Value "ENG" ]
                    [ "fontLanguageOverride" ==> "\"ENG\""]
                test
                    "Font kerning normal"
                    [ style.fontKerning.Normal]
                    [ "fontKerning" ==> "normal" ]
                test
                    "Font size XX-Small"
                    [ style.fontSize.XxSmall ]
                    [ "fontSize" ==> "xx-small" ]
                test
                    "Font stretch normal"
                    [ style.fontStretch.Normal ]
                    [ "fontStretch" ==> "normal" ]
                test
                    "Font style oblique -90"
                    [ style.fontStyle.Oblique (deg -90.0)]
                    [ "fontStyle" ==> "oblique -90.00deg"]
                test
                    "Font weight bold"
                    [ style.fontWeight.Bold ]
                    [ "fontWeight" ==> "bold"]
                test
                    "Line height normal"
                    [ style.lineHeight.Normal ]
                    [ "lineHeight" ==> "normal" ]
              //  test
              //      "Line height value"
              //      [ style.lineHeight' (CssFloat 2.5) ]
              //      [ "lineHeight" ==> "2.5" ]
                test
                    "Line break loose"
                    [ style.lineBreak.Loose ]
                    [ "lineBreak" ==> "loose" ]
                test
                    "Letter spacing px"
                    [ style.letterSpacing' (px 10) ]
                    [ "letterSpacing" ==> "10px" ]
                test
                     "Font family serif"
                     [ style.fontFamily.Serif ]
                     [ "fontFamily" ==> "serif" ]
              //  test
              //      "Font families"
              //      [ style.fontFamily.Values ([ FontFamily.Serif; FontTypes.Monospace ]) ]
              //      [ "fontFamily" ==> "serif, monospace" ]
              //  test
              //      "font feature setting On"
              //      [ style.fontFeatureSetting.Liga FontTypes.On ]
              //      [ "fontFeatureSettings" ==> "\"liga\" On" ]
                test
                    "Font variant numeric ordinal"
                    [ style.fontVariantNumeric.Ordinal]
                    ["fontVariantNumeric" ==> "ordinal"]
                test
                    "Font variant caps small caps"
                    [ style.fontVariantCaps.SmallCaps]
                    ["fontVariantCaps" ==> "small-caps"]
                test
                    "Font variant east asian ruby"
                    [ style.fontVariantEastAsian.Ruby]
                    ["fontVariantEastAsian" ==> "ruby"]
                test
                    "Font variant ligatures normal"
                    [ style.fontVariantLigatures.Normal]
                    ["fontVariantLigatures" ==> "normal"]
                test
                    "Font variant position super"
                    [ style.fontVariantPosition.Super ]
                    ["fontVariantPosition" ==> "super"]
                test
                    "Word spacing normal"
                    [style.wordSpacing.Normal]
                    ["wordSpacing" ==> "normal"]
                test
                    "Word spacing px"
                    [style.wordSpacing' (px 3 )]
                    ["wordSpacing" ==> "3px"]
                test
                    "Word break word break"
                    [style.wordBreak.WordBreak]
                    ["wordBreak" ==> "word-break"]
                test
                     "Text decoration none"
                     [style.textDecoration.None]
                     ["textDecoration" ==> "none"]
                test
                     "Text emphasis inherit"
                     [ style.textEmphasis.Inherit ]
                     ["textEmphasis" ==> "inherit"]
                test
                     "Text align left"
                     [ style.textAlign.Left ]
                     ["textAlign" ==> "left"]
                test
                     "Text align last center"
                     [ style.textAlignLast.Center ]
                     ["textAlignLast" ==> "center"]
                test
                     "Text decoration color red"
                     [style.textDecorationColor.red]
                     ["textDecorationColor" ==> "#ff0000"]
                test
                     "Text decoration line underline"
                     [style.textDecorationLine.Underline]
                     ["textDecorationLine" ==> "underline"]
               // test
               //      "Text decorations multiple"
               //      [style.textDecorationLine.Value(TextTypes.Overline, TextTypes.Underline, TextTypes.LineThrough)]
               //      ["textDecorationLine" ==> "overline underline line-through"]
                test
                     "Text decoration skip objects"
                     [style.textDecorationSkip.Objects]
                     ["textDecorationSkip" ==> "objects"]
 //               test
 //                    "Text decoration skip multiple - leading spaces and trailing spaces"
 //                    [TextDecorationSkip.Value(TextTypes.LeadingSpaces, TextTypes.TrailingSpaces)]
 //                    ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]
                test
                     "Text decoration skip All"
                     [style.textDecorationSkipInk.All]
                     ["textDecorationSkipInk" ==> "all"]
                test
                     "Text decoration style solid"
                     [style.textDecorationStyle.Solid]
                     ["textDecorationStyle" ==> "solid"]
                test
                     "Text decoration thickness auto"
                     [ style.textDecorationThickness.Auto ]
                     [ "textDecorationThickness" ==> "auto" ]
                test
                     "Text decoration thickness px"
                     [ style.textDecorationThickness' (px 3) ]
                     ["textDecorationThickness" ==> "3px" ]
                test
                     "Text emphasis color hex"
                     [ style.textEmphasisColor.Hex "#555" ]
                     ["textEmphasisColor" ==> "#555"]
//                test
//                     "Text emphasis position left under"
//                     [ TextEmphasisPosition.Value (TextTypes.EmphasisPosition.Left, TextTypes.EmphasisPosition.Under) ]
//                     ["textEmphasisPosition" ==> "left under"]
//                test
//                     "Text Emphasis Style x"
//                     [style.textEmphasisStyle' (CssString "x")]
//                     ["textEmphasisStyle" ==> "'x'"]
                test
                     "Text Emphasis Style filled"
                     [style.textEmphasisStyle.Filled ]
                     ["textEmphasisStyle" ==> "filled"]
//                test
//                     "Text shadow single"
//                     [ style.textShadows [ TextShadow.ColorXYBlur (px 1, px 1, px 2, CssColor.black) ] ]
//                     ["textShadow" ==> "#000000 1px 1px 2px"]
                test
                     "Text underline offset auto"
                     [ style.textUnderlineOffset.Auto ]
                     ["textUnderlineOffset" ==> "auto"]
                test
                     "Text underline offset em"
                     [ style.textUnderlineOffset' (em 3.0) ]
                     ["textUnderlineOffset" ==> "3.0em"]
                test
                     "Text underline position from-font"
                     [ style.textUnderlinePosition.FromFont ]
                     ["textUnderlinePosition" ==> "from-font"]
                test
                     "Text indent mm"
                     [ style.textIndent' (mm 3.0) ]
                     ["textIndent" ==> "3.0mm"]
                test
                     "Text overflow clip"
                     [ style.textOverflow.Clip ]
                     ["textOverflow" ==> "clip"]
                test
                     "Quotes none"
                     [ style.quotes.None ]
                     ["quotes" ==> "none"]
                test
                     "Hyphens Manual"
                     [ style.hyphens.Manual ]
                     ["hyphens" ==> "manual"]
                test
                     "TextSizeAdjust percent"
                     [ style.textSizeAdjust' (pct 80) ]
                     ["textSizeAdjust" ==> "80%"]
                test
                     "TextSizeAdjust Auto"
                     [ style.textSizeAdjust.Auto ]
                     ["textSizeAdjust" ==> "auto"]
                test
                     "TabSize px"
                     [ style.tabSize' (px 10) ]
                     ["tabSize" ==> "10px"]
                test
                     "TextOrientation Mixed"
                     [ style.textOrientation.Mixed ]
                     ["textOrientation" ==> "mixed"]
                test
                     "TextJustify inter-character"
                     [ style.textJustify.InterCharacter ]
                     ["textJustify" ==> "inter-character"]
                test
                     "WhiteSpace nowrap"
                     [ style.whiteSpace.NoWrap ]
                     ["whiteSpace" ==> "no-wrap"]
                test
                     "UserSelect text"
                     [ style.userSelect.Text ]
                     ["userSelect" ==> "text"]
                test
                    "Transform none"
                    [ style.transform.None ]
                    [ "transform" ==> "none" ]
                test
                    "Transform matrix"
                    [ style.transforms[ Transform.Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0) ] ]
                    [ "transform" ==> "matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0)" ]
                test
                    "Transform multiple"
                    [ style.transforms [ Transform.Translate3D(px 30, px 30, px 0); Transform.RotateZ(deg -179.) ] ]
                    ["transform" ==> "translate3d(30px, 30px, 0px) rotateZ(-179.00deg)"]
                test
                    "Transform origin px"
                    [ style.transformOrigin' (px 2) ]
                    [ "transformOrigin" ==> "2px" ]
                test
                    "Transform origin position"
                    [ style.transformOrigin.Bottom ]
                    [ "transformOrigin" ==> "bottom" ]
                test
                    "Transform style flat"
                    [ style.transformStyle.Flat ]
                    [ "transformStyle" ==> "flat" ]
                test
                    "List style None"
                    [ style.listStyle.None ]
                    [ "listStyle" ==> "none" ]
                test
                    "List style image url"
                    [ style.listStyleImage.Url "foofoo.jpg" ]
                    [ "listStyleImage" ==> "url('foofoo.jpg')" ]
                test
                    "List style position inside"
                    [ style.listStylePosition.Inside]
                    [ "listStylePosition" ==> "inside" ]
                test
                    "List style type Disc"
                    [ style.listStyleType.Disc ]
                    [ "listStyleType" ==> "disc" ]
            //    test
            //        "List style type string"
            //        [ style.listStyleType' (CssString "-") ]
            //        [ "listStyleType" ==> "'-'" ]
            //    test
            //        "List style type custom"
            //        [ ListStyleType' sampleCounterStyle ]
            //        [ "listStyleType" ==> (counterValue sampleCounterStyle) ]
                test
                    "Column Width px"
                    [style.columnWidth' (px 60)]
                    ["columnWidth" ==> "60px"]
                test
                    "Column balance"
                    [style.columnFill.Balance]
                    ["columnFill" ==> "balance"]
                test
                    "Column gap normal"
                    [style.columnGap.Normal]
                    ["columnGap" ==> "normal"]
                test
                    "Column span all"
                    [style.columnSpan.All]
                    ["columnSpan" ==> "all"]
                test
                    "Columns Inherit"
                    [style.columns.Inherit]
                    ["columns" ==> "inherit"]
                test
                    "Column rule Inherit"
                    [style.columnRule.Inherit]
                    ["columnRule" ==> "inherit"]
                test
                    "Column rule width thin"
                    [style.columnRuleWidth.Thin]
                    ["columnRuleWidth" ==> "thin"]
                test
                    "Column rule style hidden"
                    [ style.columnRuleStyle.Hidden ]
                    [ "columnRuleStyle" ==> "hidden" ]
                test
                    "Column rule color red"
                    [ style.columnRuleColor.red ]
                    [ "columnRuleColor" ==> "#ff0000" ]
              //  test
              //      "Column count number"
              //      [style.columnCount' (CssInt 3)]
              //      ["columnCount" ==> "3"]
                test
                    "Column count auto"
                    [style.columnCount.Auto]
                    ["columnCount" ==> "auto"]
                test
                    "Border initial"
                    [ style.border.Initial ]
                    [ "border" ==> "initial" ]
                test
                    "Borderstyle hidden"
                    [ style.borderStyle.Hidden ]
                    [ "borderStyle" ==> "hidden" ]
             //   test
              //      "Borderstyle multiple"
              //      [ style.borderStyle.Value(BorderType.Inset, BorderType.Outset, BorderType.Ridge, BorderType.Groove) ]
              //      [ "borderStyle" ==> "inset outset ridge groove" ]
                test
                    "Border radius px"
                    [ style.borderRadius' (px 10)]
                    [ "borderRadius" ==> "10px" ]
                test
                    "Border top left radius px"
                    [ style.borderTopLeftRadius' (px 10)]
                    ["borderTopLeftRadius" ==> "10px"]
                test
                    "Border bottom left radius"
                    [ style.borderBottomLeftRadius' (px 10)]
                    ["borderBottomLeftRadius" ==> "10px"]
                test
                    "Border radius top left initial"
                    [ style.borderTopLeftRadius.Initial ]
                    ["borderTopLeftRadius" ==> "initial"]
                test
                    "Border bottom left radius unset"
                    [ style.borderBottomLeftRadius.Unset ]
                    ["borderBottomLeftRadius" ==> "unset"]
                test
                    "Border bottom right radius initial"
                    [ style.borderBottomRightRadius.Initial ]
                    ["borderBottomRightRadius" ==> "initial"]
                test
                    "Border width px"
                    [ style.borderWidth' (px 40) ]
                    [ "borderWidth" ==> "40px" ]
                test
                    "Border left width px"
                    [ style.borderLeftWidth' (px 40) ]
                    ["borderLeftWidth" ==> "40px"]
                test
                    "Border right width cm"
                    [ style.borderRightWidth' (cm 40.0) ]
                    ["borderRightWidth" ==> "40.0cm"]
                test
                    "Border color red"
                    [ style.borderColor.red ]
                    [ "borderColor" ==> "#ff0000" ]
                test
                    "Border colors multiple"
                    [ style.borderColor.Value (CssColor.red, CssColor.green, CssColor.blue, CssColor.white) ]
                    [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]
                test
                    "Border top color rgb"
                    [ style.borderTopColor.Rgb 255 0 0 ]
                    ["borderTopColor" ==> "rgb(255, 0, 0)"]
                test
                    "Border right color green"
                    [ style.borderRightColor.green ]
                    ["borderRightColor" ==> "#008000"]
                test
                    "Border bottom color"
                    [ style.borderBottomColor.blue ]
                    ["borderBottomColor" ==> "#0000ff"]
                test
                    "Border left color"
                    [ style.borderLeftColor.white ]
                    ["borderLeftColor" ==> "#ffffff"]
                test
                    "Border collapse collapse"
                    [ style.borderCollapse.Collapse ]
                    [ "borderCollapse" ==> "collapse" ]
                test
                    "Border spacing px"
                    [ style.borderSpacing' (px 2) ]
                    [ "borderSpacing" ==> "2px" ]
                test
                    "Border image source none"
                    [ style.borderImageSource.None]
                    [ "borderImageSource" ==> "none" ]
                test
                    "Border image source url"
                    [ style.borderImageSource.Url "image.jpg" ]
                    [ "borderImageSource" ==> "url(image.jpg)" ]
                test
                    "Border image width rem"
                    [ style.borderImageWidth' (rem 1.) ]
                    [ "borderImageWidth" ==> "1.0rem" ]
                test
                    "Border image repeat stretch"
                    [ style.borderImageRepeat.Stretch ]
                    [ "borderImageRepeat" ==> "stretch" ]
                test
                    "Border image slice percent"
                    [ style.borderImageSlice' (pct 30) ]
                    [ "borderImageSlice" ==> "30%" ]
                test
                    "Border image outset rem"
                    [ style.borderImageOutset' (rem 1.) ]
                    [ "borderImageOutset" ==> "1.0rem" ]
                test
                    "Transition inherit"
                    [style.transition.Inherit]
                    ["transition" ==> "inherit"]
                test
                    "Transition duration sec"
                    [style.transitionDuration' (sec 6.0) ]
                    ["transitionDuration" ==> "6.00s"]
            //    test
             //       "Transition duration multiple"
              //      [style.transitionDuration.Value transitionDurations ]
               //     ["transitionDuration" ==> "10.00s, 100.00ms, initial, inherit"]
                test
                    "Transition delay sec"
                    [style.transitionDelay' (sec 6.0) ]
                    ["transitionDelay" ==> "6.00s"]
                test
                    "Transition property"
                    [style.transitionProperty.BackgroundColor]
                    ["transitionProperty" ==> "background-color"]
                test
                    "Transition timing function ease"
                    [ style.transitionTimingFunction.Ease ]
                    ["transitionTimingFunction" ==> "ease"]
                test
                    "Display inline"
                    [ style.display.Inline ]
                    ["display" ==> "inline"]
                test
                    "Margin top px"
                    [ style.marginTop' (px 10)]
                    ["marginTop" ==> "10px"]
                test
                    "Margin right px"
                    [ style.marginRight' (px 10)]
                    ["marginRight" ==> "10px"]
                test
                    "Margin bottom px"
                    [ style.marginBottom' (px 10)]
                    ["marginBottom" ==> "10px"]
                test
                    "Margin left px"
                    [ style.marginLeft' (px 10)]
                    ["marginLeft" ==> "10px"]
                test
                    "Margin px"
                    [ style.margin' (px 10)]
                    [ "margin" ==> "10px" ]
                test
                    "Margin inline start 5%"
                    [ style.marginInlineStart' <| pct 5]
                    [ "marginInlineStart" ==> "5%" ]
                test
                    "Margin inline end 5%"
                    [ style.marginInlineEnd' <| pct 5]
                    [ "marginInlineEnd" ==> "5%" ]
                test
                    "Margin block start 5%"
                    [ style.marginBlockStart' <| pct 5]
                    [ "marginBlockStart" ==> "5%" ]
                test
                    "Margin block end 5%"
                    [ style.marginBlockEnd' <| pct 5]
                    [ "marginBlockEnd" ==> "5%" ]
                test
                    "Padding top px"
                    [ style.paddingTop' (px 10)]
                    ["paddingTop" ==> "10px"]
                test
                    "Padding right px"
                    [ style.paddingRight' (px 10)]
                    ["paddingRight" ==> "10px"]
                test
                    "Padding bottom px"
                    [ style.paddingBottom' (px 10)]
                    ["paddingBottom" ==> "10px"]
                test
                    "Padding left px"
                    [ style.paddingLeft' (px 10)]
                    ["paddingLeft" ==> "10px"]
                test
                    "Padding px"
                    [ style.padding' (px 10)]
                    [ "padding" ==> "10px" ]
                test
                    "Padding inline start 5%"
                    [ style.paddingInlineStart' <| pct 5]
                    [ "paddingInlineStart" ==> "5%" ]
                test
                    "Padding inline end 5%"
                    [ style.paddingInlineEnd' <| pct 5]
                    [ "paddingInlineEnd" ==> "5%" ]
                test
                    "Padding block start 5%"
                    [ style.paddingBlockStart' <| pct 5]
                    [ "paddingBlockStart" ==> "5%" ]
                test
                    "Padding block end 5%"
                    [ style.paddingBlockEnd' <| pct 5]
                    [ "paddingBlockEnd" ==> "5%" ]
           //     test
            //        "Resize Value"
             //       [style.resize' (ResizeType.Block)]
              //      ["resize" ==> "block"]
                test
                    "Resize Both"
                    [style.resize.Both]
                    ["resize" ==> "both"]
                test
                    "Width px"
                    [ style.width' (px 100) ]
                    ["width" ==> "100px"]
                test
                    "Width max content"
                    [ style.width.MaxContent ]
                    ["width" ==> "max-content"]
                test
                    "Height px"
                    [ style.height' (px 100) ]
                    ["height" ==> "100px"]
                test
                    "Height max content"
                    [ style.height.MaxContent ]
                    ["height" ==> "max-content"]
                test
                    "Max width px"
                    [ style.maxWidth' (px 100) ]
                    ["maxWidth" ==> "100px"]
                test
                    "Max height px"
                    [ style.maxHeight' (px 100) ]
                    ["maxHeight" ==> "100px"]
                test
                    "Paint order normal"
                    [style.paintOrder.Normal]
                    ["paintOrder" ==> "normal"]
//                test
 //                   "Paint order stroke fill"
  //                  [PaintOrder.Value(PaintOrderTypes.Stroke, PaintOrderTypes.Fill)]
   //                 ["paintOrder" ==> "stroke fill"]
                test
                    "Visibility hidden"
                    [ style.visibility.Hidden]
                    ["visibility" ==> "hidden"]
                test
                    "Opacity 1"
                    [ style.opacity' 1.0 ]
                    ["opacity" ==> "1"]
                test
                    "Overflow-X visible"
                    [style.overflowX.Visible]
                    ["overflowX" ==> "visible"]
                test
                    "OverflowY visible"
                    [style.overflowY.Visible]
                    ["overflowY" ==> "visible"]
//                test
 //                   "Overflow scroll Scroll"
  //                  [Overflow.Value (OverflowType.Scroll, OverflowType.Scroll)]
   //                 ["overflow" ==> "scroll scroll"]
                test
                    "OverflowWrap break-word"
                    [style.overflowWrap.BreakWord]
                    ["overflowWrap" ==> "break-word"]


























            ]