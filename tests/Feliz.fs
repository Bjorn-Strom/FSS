namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open FssTypes
open Feliz.Fss

module Feliz =
    let tests =
        let animationSample =
            keyframes
                [
                    frame 0 [ style.backgroundColor.red ]
                    frame 100 [ style.backgroundColor.blue]
                ]
        let sampleCounter =
            counterStyle
                [
                    Counter.System.Alphabetic
                ]
        let transitionDurations: ITransitionDuration list = [sec 10.0; ms 100.0; Initial; Inherit]

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
                test
                    "Line height value"
                    [ style.lineHeight' <| CssFloat 2.5 ]
                    [ "lineHeight" ==> "2.5" ]
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
                test
                    "Font families"
                    [ style.fontFamily.Values ([ Font.Serif; Font.Monospace ]) ]
                    [ "fontFamily" ==> "serif, monospace" ]
                test
                    "font feature setting On"
                    [ style.fontFeatureSetting.Liga Font.On ]
                    [ "fontFeatureSettings" ==> "\"liga\" On" ]
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
                test
                     "Text decorations multiple"
                     [style.textDecorationLine.Value(Text.Overline, Text.Underline, Text.LineThrough)]
                     ["textDecorationLine" ==> "overline underline line-through"]
                test
                     "Text decoration skip objects"
                     [style.textDecorationSkip.Objects]
                     ["textDecorationSkip" ==> "objects"]
                test
                     "Text decoration skip multiple - leading spaces and trailing spaces"
                     [style.textDecorationSkip.Value(Text.LeadingSpaces, Text.TrailingSpaces)]
                     ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]
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
                test
                     "Text emphasis position left under"
                     [ style.textEmphasisPosition.Value (Text.EmphasisPosition.Left, Text.EmphasisPosition.Under) ]
                     ["textEmphasisPosition" ==> "left under"]
                test
                     "Text Emphasis Style x"
                     [style.textEmphasisStyle' (CssString "x")]
                     ["textEmphasisStyle" ==> "'x'"]
                test
                     "Text Emphasis Style filled"
                     [style.textEmphasisStyle.Filled ]
                     ["textEmphasisStyle" ==> "filled"]
                test
                     "Text shadow single"
                     [ style.textShadows [ Text.ColorXYBlur (CssColor.black, px 1, px 1, px 2) ] ]
                     ["textShadow" ==> "#000000 1px 1px 2px"]
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
                test
                    "List style type string"
                    [ style.listStyleType' (CssString "-") ]
                    [ "listStyleType" ==> "'-'" ]
                test
                    "List style type custom"
                    [ style.listStyleType' sampleCounter]
                    [ "listStyleType" ==> (Counter.counterValue sampleCounter) ]
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
                test
                    "Column count number"
                    [style.columnCount' (CssInt 3)]
                    ["columnCount" ==> "3"]
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
                test
                    "Borderstyle multiple"
                    [ style.borderStyle.Value(Border.Inset, Border.Outset, Border.Ridge, Border.Groove) ]
                    [ "borderStyle" ==> "inset outset ridge groove" ]
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
                test
                    "Transition duration multiple"
                    [style.transitionDuration.Value transitionDurations ]
                    ["transitionDuration" ==> "10.00s, 100.00ms, initial, inherit"]
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
                test
                    "Resize Value"
                    [style.resize' (Resize.Block)]
                    ["resize" ==> "block"]
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
                test
                    "Overflow scroll Scroll"
                    [style.overflow.Value (Overflow.Scroll, Overflow.Scroll)]
                    ["overflow" ==> "scroll scroll"]
                test
                    "OverflowWrap break-word"
                    [style.overflowWrap.BreakWord]
                    ["overflowWrap" ==> "break-word"]
                test
                    "Direction rtl"
                    [ style.direction.Ltr ]
                    ["direction" ==> "ltr"]
                test
                    "Box sizing border box "
                    [style.boxSizing.BorderBox]
                    ["boxSizing" ==> "border-box"]
                test
                    "Left px"
                    [ style.left' (px 3) ]
                    [ "left" ==> "3px" ]
                test
                    "Right px"
                    [ style.right' (px 3) ]
                    [ "right" ==> "3px" ]
                test
                    "Bottom px"
                    [ style.bottom' (px 3) ]
                    [ "bottom" ==> "3px" ]
                test
                    "Top px"
                    [ style.top' (px 3) ]
                    [ "top" ==> "3px" ]
                test
                    "Vertical align baseline"
                    [ style.verticalAlign.Baseline]
                    ["verticalAlign" ==> "baseline"]
                test
                    "Position static"
                    [ style.position.Static]
                    ["position" ==> "static"]
                test
                    "Float left"
                    [ style.float.Left]
                    ["float" ==> "left"]
                test
                    "WritingMode horizontal-tb"
                    [ style.writingMode.HorizontalTb]
                    ["writingMode" ==> "horizontal-tb"]
                test
                    "BreakAfter avoid"
                    [style.breakAfter.Avoid]
                    ["breakAfter" ==> "avoid"]
                test
                    "BreakBefore avoid"
                    [style.breakBefore.Avoid]
                    ["breakBefore" ==> "avoid"]
                test
                    "BreakInside avoid-column"
                    [style.breakInside.AvoidColumn]
                    ["breakInside" ==> "avoid-column"]
                test
                    "Perspective px"
                    [ style.perspective' (px 100) ]
                    ["perspective" ==> "100px"]
                test
                    "Perspective x"
                    [ style.perspectiveOrigin' <| pct 100 ]
                    ["perspectiveOrigin" ==> "100%"]
                test
                    "BackfaceVisibility inherit"
                    [ style.backfaceVisibility.Inherit]
                    [ "backfaceVisibility" ==> "inherit" ]
                test
                    "PointerEvents VisiblePainted"
                    [ style.pointerEvents.VisiblePainted ]
                    ["pointerEvents" ==> "visiblePainted"]
                test
                    "Cursor Wait"
                    [style.cursor.Wait]
                    [ "cursor" ==> "wait"]
                test
                    "Content image"
                    [ style.content.Url "http://www.example.com/test.png" ]
                    [ "content" ==> "url(http://www.example.com/test.png)" ]
                test
                    "Content image with alt text"
                    [ style.content.Url("http://www.example.com/test.png", "this is the alt text") ]
                    [ "content" ==> "url(http://www.example.com/test.png) / \"this is the alt text\"" ]
                test
                    "Content linear gradient"
                    [ style.content.LinearGradient(deg 45.0, [hex "e66456", px 0; hex "9198e5", px 100]) ]
                    [ "content" ==> "linear-gradient(45.00deg, #e66456 0px, #9198e5 100px)" ]
                test
                   "Content counter"
                    [ style.content.Counter sampleCounter]
                    [ "content" ==> sprintf "counter(%s)" (Counter.counterValue sampleCounter) ]
                test
                    "Content counter2"
                    [ style.content.Counters (sampleCounter, ListStyleType.UpperLatin) ]
                    [ "content" ==> sprintf "counters(%s, upper-latin)" (Counter.counterValue sampleCounter) ]
                test
                    "Caption side top"
                    [style.captionSide.Top]
                    ["captionSide" ==> "top"]
                test
                    "Empty Cells show"
                    [style.emptyCells.Show]
                    ["emptyCells" ==> "show"]
                test
                    "Table Layout fixed"
                    [style.tableLayout.Fixed]
                    ["tableLayout" ==> "fixed"]
                test
                    "caret color hsl"
                    [ style.caretColor.Hsl 255 0. 0. ]
                    ["caretColor" ==> "hsl(255, 0%, 0%)"]
                test
                    "caret color green"
                    [ style.caretColor.green ]
                    ["caretColor" ==> "#008000"]
                test
                    "Appearance square button"
                    [style.appearance.SquareButton]
                    ["appearance" ==> "square-button"]
                test
                    "Orphans number"
                    [ style.orphans' (CssInt 2)]
                    [ "orphans" ==> "2" ]
                test
                    "Orphans inherit"
                    [ style.orphans.Inherit]
                    [ "orphans" ==> "inherit" ]
                test
                    "Widows number"
                    [ style.widows' (CssInt 2)]
                    [ "widows" ==> "2" ]
                test
                    "Widows unset"
                    [ style.widows.Unset ]
                    [ "widows" ==> "unset" ]
                test
                    "All inherit"
                    [ style.all.Inherit]
                    [ "all" ==> "inherit" ]
                test
                    "Grid area"
                    [ style.gridArea' "foo" ]
                    ["gridArea" ==> "foo"]
                test
                    "Grid area"
                    [ style.gridArea.Value (Grid.Ident "area1", Grid.Ident "area2") ]
                    ["gridArea" ==> "area1 / area2"]
                test
                    "Grid area initial"
                    [style.gridArea.Initial]
                    ["gridArea" ==> "initial"]
                test
                    "Grid column ident and ident"
                    [ style.gridColumn.Value(Grid.Ident "someStart", Grid.Ident "someEnd") ]
                    ["gridColumn" ==> "someStart / someEnd"]
                test
                    "Grid column unset"
                    [style.gridColumn.Unset]
                    ["gridColumn" ==> "unset"]
                test
                    "Grid column start ident"
                    [style.gridColumnStart.Ident "somegridarea"]
                    ["gridColumnStart" ==> "somegridarea"]
                test
                    "Grid column end value"
                    [style.gridColumnEnd' 1]
                    ["gridColumnEnd" ==> "1"]
                test
                    "Grid column end ident"
                    [style.gridColumnEnd.Ident "somegridarea"]
                    ["gridColumnEnd" ==> "somegridarea"]
                test
                    "Grid row ident and ident"
                    [ style.gridRow.Value (Grid.Ident "someStart", Grid.Ident "someEnd") ]
                    ["gridRow" ==> "someStart / someEnd"]
                test
                    "Grid row auto"
                    [style.gridRow.Auto]
                    ["gridRow" ==> "auto"]
                test
                    "Grid row start value"
                    [style.gridRowStart' 1]
                    ["gridRowStart" ==> "1"]
                test
                    "Grid row start ident"
                    [style.gridRowStart.Ident "somegridarea"]
                    ["gridRowStart" ==> "somegridarea"]
                test
                    "Grid row end value"
                    [style.gridRowEnd' 1 ]
                    ["gridRowEnd" ==> "1"]
                test
                    "Grid row end ident"
                    [style.gridRowEnd.Ident "somegridarea"]
                    ["gridRowEnd" ==> "somegridarea"]
                test
                    "Grid gap px"
                    [style.gridGap' (px 10)]
                    ["gridGap" ==> "10px"]
                test
                    "Grid gap px and px"
                    [ style.gridGap.Value (px 20, px 10) ]
                    ["gridGap" ==> "20px 10px"]
                test
                    "Row gap normal"
                    [style.gridRowGap.Normal]
                    ["gridRowGap" ==> "normal"]
                test
                    "Row gap px"
                    [style.gridRowGap' (px 3)]
                    ["gridRowGap" ==> "3px"]
                test
                    "Column gap normal"
                    [style.gridColumnGap.Normal]
                    ["gridColumnGap" ==> "normal"]
                test
                    "Column gap px"
                    [style.gridColumnGap' (px 3)]
                    ["gridColumnGap" ==> "3px"]
                test
                    "Grid template row px"
                    [style.gridTemplateRows' (px 100)]
                    ["gridTemplateRows" ==> "100px"]
                test
                    "Grid template row minmax"
                    [style.gridTemplateRows.MinMax (px 100, fr 1.) ]
                    ["gridTemplateRows" ==> "minmax(100px, 1.00fr)"]
                test
                    "Grid template row px repeat px"
                    [style.gridTemplateRows.Values [ px 200; style.repeat.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateRows" ==> "200px repeat(auto-fill, 100px) 300px"]
                test
                    "Grid template column px"
                    [style.gridTemplateColumns' (px 100)]
                    ["gridTemplateColumns" ==> "100px"]
                test
                    "Grid template column masonry"
                    [style.gridTemplateColumns.Masonry]
                    ["gridTemplateColumns" ==> "masonry"]
                test
                    "Grid template column repeat"
                    [style.gridTemplateColumns.Repeat(3, px 200)]
                    ["gridTemplateColumns" ==> "repeat(3, 200px)"]
                test
                    "Grid template column px repeat px"
                    [style.gridTemplateColumns.Values [px 200; style.repeat.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateColumns" ==> "200px repeat(auto-fill, 100px) 300px"]
                test
                    "Grid auto columns min content"
                    [style.gridAutoColumns.MinContent]
                    ["gridAutoColumns" ==> "min-content"]
                test
                    "Grid auto columns multiple with pxs"
                    [ style.gridAutoColumns.Values [px 100; px 150; px 390;] ]
                    ["gridAutoColumns" ==> "100px 150px 390px"]
                test
                    "Grid auto rows min content"
                    [style.gridAutoRows.MinContent]
                    ["gridAutoRows" ==> "min-content"]
                test
                    "Grid auto rows fit content"
                    [style.gridAutoRows.FitContent(px 400) ]
                    ["gridAutoRows" ==> "fit-content(400px)"]
                test
                    "Grid auto flow rows"
                    [style.gridAutoFlow.Row]
                    ["gridAutoFlow" ==> "row"]
                test
                    "Grid template areas None"
                    [style.gridTemplateAreas.None]
                    ["gridTemplateAreas" ==> "none"]
                test
                    "Grid template areas strings"
                    [style.gridTemplateAreas.Value [ "a"; "b"  ] ]
                    ["gridTemplateAreas" ==> "\"a b\""]
                test
                    "Grid template areas multiple strings"
                    [style.gridTemplateAreas.Value
                         [
                            [ "header";  "header";  "header";  "header" ]
                            [ "main";  "main";  ".";  "sidebar" ]
                            [ "footer";  "footer";  "footer";  "footer" ]
                        ]
                    ]
                    ["gridTemplateAreas" ==> "\"header header header header\" \"main main . sidebar\" \"footer footer footer footer\""]
                test
                    "Flex direction row"
                    [ style.flexDirection.Row]
                    ["flexDirection" ==> "row"]
                test
                    "Flex wrap no-wrap"
                    [ style.flexWrap.NoWrap]
                    ["flexWrap" ==> "no-wrap"]
                test
                    "Flex basis em"
                    [ style.flexBasis' (em 10.0)]
                    ["flexBasis" ==> "10.0em"]
                test
                    "Justify content start"
                    [ style.justifyContent.Start]
                    ["justifyContent" ==> "start"]
                test
                    "Justify self normal"
                    [ style.justifySelf.Normal ]
                    ["justifySelf" ==> "normal"]
                test
                    "Justify items end"
                    [ style.justifyItems.End]
                    ["justifyItems" ==> "end"]
                test
                    "Align self normal"
                    [ style.alignSelf.Normal]
                    ["alignSelf" ==> "normal"]
                test
                    "Align items start"
                    [ style.alignItems.Start]
                    ["alignItems" ==> "start"]
                test
                    "Align content start"
                    [ style.alignContent.Start]
                    ["alignContent" ==> "start"]
                test
                    "Order value"
                    [ style.order' (CssInt 1) ]
                    ["order" ==> "1"]
                test
                    "Order inherit"
                    [ style.order.Inherit]
                    ["order" ==> "inherit"]
                test
                    "Flex grow value"
                    [ style.flexGrow' (CssFloat 1.5) ]
                    ["flexGrow" ==> "1.5"]
                test
                    "FlexGrow inherit"
                    [ style.flexGrow.Inherit]
                    ["flexGrow" ==> "inherit"]
                test
                    "FlexShrink value"
                    [ style.flexShrink' (CssFloat 1.5) ]
                    ["flexShrink" ==> "1.5"]
                test
                    "FlexShrink inherit"
                    [ style.flexShrink.Inherit]
                    ["flexShrink" ==> "inherit"]
                test
                    "Outline offset px"
                    [ style.outlineOffset.Value <| px 3 ]
                    [ "outlineOffset" ==> "3px" ]
                test
                    "Outline initial"
                    [ style.outline.Initial ]
                    [ "outline" ==> "initial" ]
                test
                    "Outline width px"
                    [ style.outlineWidth' (px 40) ]
                    [ "outlineWidth" ==> "40px" ]
                test
                    "Outline width thin"
                    [ style.outlineWidth.Thin ]
                    [ "outlineWidth" ==> "thin" ]
                test
                    "Outline style hidden"
                    [ style.outlineStyle.Hidden ]
                    [ "outlineStyle" ==> "hidden" ]
                test
                    "Outline color hex"
                    [ style.outlineColor.Hex "f92525"]
                    ["outlineColor" ==> "#f92525"]
                testNested
                    "Media query with min width and min height"
                    [
                        MediaQuery
                            [ Media.MinWidth (px 500); Media.MaxWidth (px 700) ]
                            [ style.backgroundColor.red ]
                    ]
                    ["@media (min-width: 500px) and (max-width: 700px)" ==> "backgroundColor,#ff0000"]
                testNested
                    "Media query min height only"
                    [
                        MediaQuery
                            [ Media.MinHeight (px 700) ]
                            [ style.backgroundColor.pink ]
                    ]
                    ["@media (min-height: 700px)" ==> "backgroundColor,#ffc0cb"]
                testNested
                    "Media query for print"
                    [
                        MediaQueryFor Media.Print []
                            [
                                style.marginTop' (px 200)
                                style.transforms
                                    [
                                        Transform.Rotate (deg 45.0)
                                    ]
                                style.backgroundColor.indianRed
                            ]
                    ]
                    ["@media print " ==> "marginTop,200px,transform,rotate(45.00deg),backgroundColor,#cd5c5c"]
                testNested
                    "Media not all"
                    [
                        MediaQueryFor (Media.Not Media.All) [ Media.Color ] [ style.marginTop' (px 200) ]
                    ]
                    ["@media not all and (color)" ==> "marginTop,200px"]
                testNested
                    "Media query only screen"
                    [
                        MediaQueryFor (Media.Only Media.Screen)
                            [
                                Media.Color
                                Media.Pointer Media.Fine
                                Media.Scan Media.Interlace
                                Media.Grid true
                            ]
                            [
                                style.marginTop' (px 200)
                                style.transforms
                                    [
                                        Transform.Rotate (deg 45.0)
                                    ]
                                style.backgroundColor.indianRed
                            ]
                    ]
                    [
                        "@media only screen and (color) and (pointer: fine) and (scan: interlace) and (grid: 1)"
                        ==>
                        "marginTop,200px,transform,rotate(45.00deg),backgroundColor,#cd5c5c"
                    ]
                test
                    "BoxShadow color"
                    [
                        style.boxShadows
                            [
                                style.boxShadow.Color(px 10, px 10, CssColor.blue)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px #0000ff" ]
                test
                    "BoxShadow blur color"
                    [
                        style.boxShadows
                            [
                                style.boxShadow.BlurColor(px 10, px 10, em 1.5, CssColor.red)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px 1.5em #ff0000" ]
                test
                    "BoxShadow blur spread color"
                    [
                        style.boxShadows
                            [
                                style.boxShadow.BlurSpreadColor(px 1, px 100, vh 1.5, px 1, CssColor.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "1px 100px 1.5vh 1px #d2691e" ]
                test
                    "Multiple box shadows"
                   [
                        style.boxShadows
                            [
                                style.boxShadow.Color(px 10, px 10, CssColor.blue)
                                style.boxShadow.BlurColor(px 10, px 10, px 10, CssColor.blue)
                                style.boxShadow.BlurSpreadColor(px 10, px 10, px 10, px 10, CssColor.blue)
                                style.boxShadow.Color(px 3, px 3, CssColor.red)
                                style.boxShadow.BlurColor(em -1., px 0, em 0.4, CssColor.olive)
                            ]
                    ]
                    ["boxShadow" ==> "10px 10px #0000ff, 10px 10px 10px #0000ff, 10px 10px 10px 10px #0000ff, 3px 3px #ff0000, -1.0em 0px 0.4em #808000"]
                test
                    "BoxShadow invert"
                    [
                        style.boxShadows
                            [
                                style.inset <| style.boxShadow.BlurSpreadColor(px 1, px 100, vh 1.5, px 1, CssColor.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "inset 1px 100px 1.5vh 1px #d2691e" ]
                test
                    "ScrollBehavior smooth"
                    [ style.scrollBehavior.Smooth]
                    [ "scrollBehavior" ==> "smooth" ]
                test
                    "OverscrollBehaviorX contain"
                    [ style.overscrollBehaviorX.Contain]
                    [ "overscrollBehaviorX" ==> "contain" ]
                test
                    "OverscrollBehaviorY contain"
                    [ style.overscrollBehaviorY.Contain]
                    [ "overscrollBehaviorY" ==> "contain" ]
                test
                    "ScrollPadding top px"
                    [ style.scrollPaddingTop' (px 10)]
                    ["scrollPaddingTop" ==> "10px"]
                test
                    "ScrollPadding right px"
                    [ style.scrollPaddingRight' (px 10)]
                    ["scrollPaddingRight" ==> "10px"]
                test
                    "ScrollPadding bottom px"
                    [ style.scrollPaddingBottom' (px 10)]
                    ["scrollPaddingBottom" ==> "10px"]
                test
                    "ScrollPadding left px"
                    [ style.scrollPaddingLeft' (px 10)]
                    ["scrollPaddingLeft" ==> "10px"]
                test
                    "ScrollPadding px"
                    [ style.scrollPadding' (px 10)]
                    [ "scrollPadding" ==> "10px" ]
                test
                    "ScrollMargin top px"
                    [ style.scrollMarginTop' (px 10)]
                    ["scrollMarginTop" ==> "10px"]
                test
                    "ScrollMargin right px"
                    [ style.scrollMarginRight' (px 10)]
                    ["scrollMarginRight" ==> "10px"]
                test
                    "ScrollMargin bottom px"
                    [ style.scrollMarginBottom' (px 10)]
                    ["scrollMarginBottom" ==> "10px"]
                test
                    "ScrollMargin left px"
                    [ style.scrollMarginLeft' (px 10)]
                    ["scrollMarginLeft" ==> "10px"]
                test
                    "ScrollMargin px"
                    [ style.scrollMargin' (px 10)]
                    [ "scrollMargin" ==> "10px" ]
                test
                    "Clip path path"
                    [style.clipPath.Path "M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z"]
                    ["clipPath" ==> "path('M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z')"]
                test
                    "Clear initial"
                    [ style.clear.Initial]
                    [ "clear" ==> "initial" ]
                test
                    "Filter Url"
                    [ style.filters [ Filter.Url "someFilter" ] ]
                    [ "filter" ==> "url(\"someFilter\")" ]
                test
                    "Filter drop shadow"
                    [ style.filters [ Filter.DropShadow 16 16 20 CssColor.red (pct 5)  ] ]
                    [ "filter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "Filter unset"
                    [ style.filter.Unset ]
                    [ "filter" ==> "unset" ]
                test
                    "BackdropFilter Url"
                    [ style.backdropFilters [ Filter.Url "someFilter" ] ]
                    [ "backdropFilter" ==> "url(\"someFilter\")" ]
                test
                    "BackdropFilter unset"
                    [ style.backdropFilter.Unset ]
                    [ "backdropFilter" ==> "unset" ]
                test
                      "Mix blend mode HardLight"
                      [ style.mixBlendMode.HardLight]
                      ["mixBlendMode" ==> "hard-light"]
                test
                    "AspectRatio"
                    [ style.aspectRatio.Value(16, 9) ]
                    [ "aspectRatio" ==> "16 / 9" ]
                test
                    "MaskClip content-box"
                    [ style.maskClip.ContentBox]
                    [ "maskClip" ==> "content-box" ]
                test
                    "MaskComposite add"
                    [ style.maskComposite.Add]
                    [ "maskComposite" ==> "add" ]
                test
                    "Mask image source url"
                    [ style.maskImage.Url "image.jpg" ]
                    [ "maskImage" ==> "url(image.jpg)" ]
                test
                    "MaskOrigin margin-box"
                    [ style.maskOrigin.MarginBox]
                    [ "maskOrigin" ==> "margin-box" ]
                test
                    "MaskPosition size"
                    [ style.maskPosition' (px 1) (rem 1.)]
                    [ "maskPosition" ==> "1px 1.0rem" ]
                test
                    "MaskPosition sizes"
                    [ style.maskPosition.Value([px 1, rem 1.; px 10, px 100])]
                    [ "maskPosition" ==> "1px 1.0rem, 10px 100px" ]
                test
                    "MaskRepeat value"
                    [ style.maskRepeat.Value(Mask.Repeat)]
                    [ "maskRepeat" ==> "repeat" ]
                test
                    "MaskRepeat multiple values"
                    [ style.maskRepeat.Value([Mask.RepeatX, Mask.RepeatY; Mask.NoRepeat, Mask.Round])]
                    [ "maskRepeat" ==> "repeat-x repeat-y, no-repeat round" ]
                test
                    "MaskRepeat repeatX"
                    [ style.maskRepeat.RepeatX]
                    [ "maskRepeat" ==> "repeat-x" ]
            ]