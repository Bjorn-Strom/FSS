namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Fss.FssTypes
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
        let sampleCounter =
            counterStyle
                [
                    Counter.System.alphabetic
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
                    [ style.animationTimingFunction.ease ]
                    ["animationTimingFunction" ==> "ease"]
                test
                    "Animation timing function cubic bezier"
                    [ style.animationTimingFunction.cubicBezier (0.0, 0.47, 0.32, 1.97) ]
                    ["animationTimingFunction" ==> "cubic-bezier(0.00, 0.47, 0.32, 1.97)"]
                test
                    "Animation delay sec"
                    [ style.animationDelay' (sec 10.0) ]
                    ["animationDelay" ==> "10.00s"]
                test
                    "Animation iteration count infininte"
                    [ style.animationIterationCount.infinite ]
                    ["animationIterationCount" ==> "infinite"]
                test
                    "Animation direction normal"
                    [ style.animationDirection.normal ]
                    ["animationDirection" ==> "normal"]
                test
                    "Animation fill mode backwards"
                    [ style.animationFillMode.backwards ]
                    ["animationFillMode" ==> "backwards"]
                test
                    "Animation play state running"
                    [ style.animationPlayState.running ]
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
                    [ style.backgroundOrigin.borderBox ]
                    [ "backgroundOrigin" ==> "border-box" ]
                test
                    "Background repeat"
                    [ style.backgroundRepeat.repeat ]
                    [ "backgroundRepeat" ==> "repeat" ]
                test
                    "Background size"
                    [ style.backgroundSize.cover ]
                    [ "backgroundSize" ==> "cover" ]
                test
                    "Background attachment"
                    [ style.backgroundAttachment.scroll ]
                    [ "backgroundAttachment" ==> "scroll" ]
                test
                    "Background image"
                    [ style.backgroundImage.url "urlTest" ]
                    [ "backgroundImage" ==> "url(urlTest)" ]
                test
                    "Background position"
                    [ style.backgroundPosition.bottom ]
                    [ "backgroundPosition" ==> "bottom" ]
                test
                    "Background blend mode"
                    [ style.backgroundBlendMode.color ]
                    [ "backgroundBlendMode" ==> "color" ]
                test
                    "Isolation"
                    [ style.isolation.unset ]
                    [ "isolation" ==> "unset" ]
                test
                    "Box decoration break"
                    [ style.boxDecorationBreak.clone ]
                    [ "boxDecorationBreak" ==> "clone" ]
                test
                    "Color gainsboro"
                    [ style.color.gainsboro]
                    [ "color" ==> "#dcdcdc" ]
                test
                    "Color red"
                    [ style.color' (Color.red)]
                    [ "color" ==> "#ff0000" ]
                test
                    "Font synthesis weight"
                    [ style.fontSynthesis.weight ]
                    [ "fontSynthesis" ==> "weight" ]
                test
                    "Font language override string"
                    [ style.fontLanguageOverride.value "ENG" ]
                    [ "fontLanguageOverride" ==> "\"ENG\""]
                test
                    "Font kerning normal"
                    [ style.fontKerning.normal]
                    [ "fontKerning" ==> "normal" ]
                test
                    "Font size XX-Small"
                    [ style.fontSize.xxSmall ]
                    [ "fontSize" ==> "xx-small" ]
                test
                    "Font stretch normal"
                    [ style.fontStretch.normal ]
                    [ "fontStretch" ==> "normal" ]
                test
                    "Font style oblique -90"
                    [ style.fontStyle.oblique (deg -90.0)]
                    [ "fontStyle" ==> "oblique -90.00deg"]
                test
                    "Font weight bold"
                    [ style.fontWeight.bold ]
                    [ "fontWeight" ==> "bold"]
                test
                    "Line height normal"
                    [ style.lineHeight.normal ]
                    [ "lineHeight" ==> "normal" ]
                test
                    "Line height value"
                    [ style.lineHeight' (CssFloat 2.5) ]
                    [ "lineHeight" ==> "2.5" ]
                test
                    "Line break loose"
                    [ style.lineBreak.loose ]
                    [ "lineBreak" ==> "loose" ]
                test
                    "Letter spacing px"
                    [ style.letterSpacing' (px 10) ]
                    [ "letterSpacing" ==> "10px" ]
                test
                     "Font family serif"
                     [ style.fontFamily.serif ]
                     [ "fontFamily" ==> "serif" ]
                test
                    "Font families"
                    [ style.fontFamily.values ([ Font.Serif; Font.Monospace ]) ]
                    [ "fontFamily" ==> "serif, monospace" ]
                test
                    "font feature setting On"
                    [ style.fontFeatureSetting.liga Font.On ]
                    [ "fontFeatureSettings" ==> "\"liga\" On" ]
                test
                    "Font variant numeric ordinal"
                    [ style.fontVariantNumeric.ordinal]
                    ["fontVariantNumeric" ==> "ordinal"]
                test
                    "Font variant caps small caps"
                    [ style.fontVariantCaps.smallCaps]
                    ["fontVariantCaps" ==> "small-caps"]
                test
                    "Font variant east asian ruby"
                    [ style.fontVariantEastAsian.ruby]
                    ["fontVariantEastAsian" ==> "ruby"]
                test
                    "Font variant ligatures normal"
                    [ style.fontVariantLigatures.normal]
                    ["fontVariantLigatures" ==> "normal"]
                test
                    "Font variant position super"
                    [ style.fontVariantPosition.super ]
                    ["fontVariantPosition" ==> "super"]
                test
                    "Word spacing normal"
                    [style.wordSpacing.normal]
                    ["wordSpacing" ==> "normal"]
                test
                    "Word spacing px"
                    [style.wordSpacing' (px 3 )]
                    ["wordSpacing" ==> "3px"]
                test
                    "Word break word break"
                    [style.wordBreak.wordBreak]
                    ["wordBreak" ==> "word-break"]
                test
                     "Text decoration none"
                     [style.textDecoration.none]
                     ["textDecoration" ==> "none"]
                test
                     "Text emphasis inherit"
                     [ style.textEmphasis.inherit' ]
                     ["textEmphasis" ==> "inherit"]
                test
                     "Text align left"
                     [ style.textAlign.left ]
                     ["textAlign" ==> "left"]
                test
                     "Text align last center"
                     [ style.textAlignLast.center ]
                     ["textAlignLast" ==> "center"]
                test
                     "Text decoration color red"
                     [style.textDecorationColor.red]
                     ["textDecorationColor" ==> "#ff0000"]
                test
                     "Text decoration line underline"
                     [style.textDecorationLine.underline]
                     ["textDecorationLine" ==> "underline"]
                test
                     "Text decorations multiple"
                     [style.textDecorationLine.value(Text.Overline, Text.Underline, Text.LineThrough)]
                     ["textDecorationLine" ==> "overline underline line-through"]
                test
                     "Text decoration skip objects"
                     [style.textDecorationSkip.objects]
                     ["textDecorationSkip" ==> "objects"]
                test
                     "Text decoration skip multiple - leading spaces and trailing spaces"
                     [style.textDecorationSkip.value(Text.LeadingSpaces, Text.TrailingSpaces)]
                     ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]
                test
                     "Text decoration skip All"
                     [style.textDecorationSkipInk.all]
                     ["textDecorationSkipInk" ==> "all"]
                test
                     "Text decoration style solid"
                     [style.textDecorationStyle.solid]
                     ["textDecorationStyle" ==> "solid"]
                test
                     "Text decoration thickness auto"
                     [ style.textDecorationThickness.auto ]
                     [ "textDecorationThickness" ==> "auto" ]
                test
                     "Text decoration thickness px"
                     [ style.textDecorationThickness' (px 3) ]
                     ["textDecorationThickness" ==> "3px" ]
                test
                     "Text emphasis color hex"
                     [ style.textEmphasisColor.hex "#555" ]
                     ["textEmphasisColor" ==> "#555"]
                test
                     "Text emphasis position left under"
                     [ style.textEmphasisPosition.value (Text.EmphasisPosition.Left, Text.EmphasisPosition.Under) ]
                     ["textEmphasisPosition" ==> "left under"]
                test
                     "Text Emphasis Style x"
                     [style.textEmphasisStyle' (CssString "x")]
                     ["textEmphasisStyle" ==> "'x'"]
                test
                     "Text Emphasis Style filled"
                     [style.textEmphasisStyle.filled ]
                     ["textEmphasisStyle" ==> "filled"]
                test
                     "Text shadow single"
                     [ style.textShadows [ Text.ColorXYBlur (Color.black, px 1, px 1, px 2) ] ]
                     ["textShadow" ==> "#000000 1px 1px 2px"]
                test
                     "Text underline offset auto"
                     [ style.textUnderlineOffset.auto ]
                     ["textUnderlineOffset" ==> "auto"]
                test
                     "Text underline offset em"
                     [ style.textUnderlineOffset' (em 3.0) ]
                     ["textUnderlineOffset" ==> "3.0em"]
                test
                     "Text underline position from-font"
                     [ style.textUnderlinePosition.fromFont ]
                     ["textUnderlinePosition" ==> "from-font"]
                test
                     "Text indent mm"
                     [ style.textIndent' (mm 3.0) ]
                     ["textIndent" ==> "3.0mm"]
                test
                     "Text overflow clip"
                     [ style.textOverflow.clip ]
                     ["textOverflow" ==> "clip"]
                test
                     "Quotes none"
                     [ style.quotes.none ]
                     ["quotes" ==> "none"]
                test
                     "Hyphens Manual"
                     [ style.hyphens.manual ]
                     ["hyphens" ==> "manual"]
                test
                     "TextSizeAdjust percent"
                     [ style.textSizeAdjust' (pct 80) ]
                     ["textSizeAdjust" ==> "80%"]
                test
                     "TextSizeAdjust Auto"
                     [ style.textSizeAdjust.auto ]
                     ["textSizeAdjust" ==> "auto"]
                test
                     "TabSize px"
                     [ style.tabSize' (px 10) ]
                     ["tabSize" ==> "10px"]
                test
                     "TextOrientation Mixed"
                     [ style.textOrientation.mixed ]
                     ["textOrientation" ==> "mixed"]
                test
                     "TextJustify inter-character"
                     [ style.textJustify.interCharacter ]
                     ["textJustify" ==> "inter-character"]
                test
                     "WhiteSpace nowrap"
                     [ style.whiteSpace.noWrap ]
                     ["whiteSpace" ==> "no-wrap"]
                test
                     "UserSelect text"
                     [ style.userSelect.text ]
                     ["userSelect" ==> "text"]
                test
                    "Transform none"
                    [ style.transform.none ]
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
                    [ style.transformOrigin.bottom ]
                    [ "transformOrigin" ==> "bottom" ]
                test
                    "Transform style flat"
                    [ style.transformStyle.flat ]
                    [ "transformStyle" ==> "flat" ]
                test
                    "List style None"
                    [ style.listStyle.none ]
                    [ "listStyle" ==> "none" ]
                test
                    "List style image url"
                    [ style.listStyleImage.url "foofoo.jpg" ]
                    [ "listStyleImage" ==> "url('foofoo.jpg')" ]
                test
                    "List style position inside"
                    [ style.listStylePosition.inside]
                    [ "listStylePosition" ==> "inside" ]
                test
                    "List style type Disc"
                    [ style.listStyleType.disc ]
                    [ "listStyleType" ==> "disc" ]
                test
                    "List style type string"
                    [ style.listStyleType' (CssString "-") ]
                    [ "listStyleType" ==> "'-'" ]
                test
                    "List style type custom"
                    [ style.listStyleType' sampleCounter]
                    [ "listStyleType" ==> (counterStyleHelpers.counterStyleToString sampleCounter) ]
                test
                    "Column Width px"
                    [style.columnWidth' (px 60)]
                    ["columnWidth" ==> "60px"]
                test
                    "Column balance"
                    [style.columnFill.balance]
                    ["columnFill" ==> "balance"]
                test
                    "Column gap normal"
                    [style.columnGap.normal]
                    ["columnGap" ==> "normal"]
                test
                    "Column span all"
                    [style.columnSpan.all]
                    ["columnSpan" ==> "all"]
                test
                    "Columns Inherit"
                    [style.columns.inherit']
                    ["columns" ==> "inherit"]
                test
                    "Column rule Inherit"
                    [style.columnRule.inherit']
                    ["columnRule" ==> "inherit"]
                test
                    "Column rule width thin"
                    [style.columnRuleWidth.thin]
                    ["columnRuleWidth" ==> "thin"]
                test
                    "Column rule style hidden"
                    [ style.columnRuleStyle.hidden ]
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
                    [style.columnCount.auto]
                    ["columnCount" ==> "auto"]
                test
                    "Border initial"
                    [ style.border.initial ]
                    [ "border" ==> "initial" ]
                test
                    "Borderstyle hidden"
                    [ style.borderStyle.hidden ]
                    [ "borderStyle" ==> "hidden" ]
                test
                    "Borderstyle multiple"
                    [ style.borderStyle.value(Border.Inset, Border.Outset, Border.Ridge, Border.Groove) ]
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
                    [ style.borderTopLeftRadius.initial ]
                    ["borderTopLeftRadius" ==> "initial"]
                test
                    "Border bottom left radius unset"
                    [ style.borderBottomLeftRadius.unset ]
                    ["borderBottomLeftRadius" ==> "unset"]
                test
                    "Border bottom right radius initial"
                    [ style.borderBottomRightRadius.initial ]
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
                    [ style.borderColor.value (Color.red, Color.green, Color.blue, Color.white) ]
                    [ "borderColor" ==> "#ff0000 #008000 #0000ff #ffffff" ]
                test
                    "Border top color rgb"
                    [ style.borderTopColor.rgb 255 0 0 ]
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
                    [ style.borderCollapse.collapse ]
                    [ "borderCollapse" ==> "collapse" ]
                test
                    "Border spacing px"
                    [ style.borderSpacing' (px 2) ]
                    [ "borderSpacing" ==> "2px" ]
                test
                    "Border image source none"
                    [ style.borderImageSource.none]
                    [ "borderImageSource" ==> "none" ]
                test
                    "Border image source url"
                    [ style.borderImageSource.url "image.jpg" ]
                    [ "borderImageSource" ==> "url(image.jpg)" ]
                test
                    "Border image width rem"
                    [ style.borderImageWidth' (rem 1.) ]
                    [ "borderImageWidth" ==> "1.0rem" ]
                test
                    "Border image repeat stretch"
                    [ style.borderImageRepeat.stretch ]
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
                    [style.transition.inherit']
                    ["transition" ==> "inherit"]
                test
                    "Transition duration sec"
                    [style.transitionDuration' (sec 6.0) ]
                    ["transitionDuration" ==> "6.00s"]
                test
                    "Transition duration multiple"
                    [style.transitionDuration.value transitionDurations ]
                    ["transitionDuration" ==> "10.00s, 100.00ms, initial, inherit"]
                test
                    "Transition delay sec"
                    [style.transitionDelay' (sec 6.0) ]
                    ["transitionDelay" ==> "6.00s"]
                test
                    "Transition property"
                    [style.transitionProperty.backgroundColor]
                    ["transitionProperty" ==> "background-color"]
                test
                    "Transition timing function ease"
                    [ style.transitionTimingFunction.ease ]
                    ["transitionTimingFunction" ==> "ease"]
                test
                    "Display inline"
                    [ style.display.inline' ]
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
                    [style.resize.both]
                    ["resize" ==> "both"]
                test
                    "Width px"
                    [ style.width' (px 100) ]
                    ["width" ==> "100px"]
                test
                    "Width max content"
                    [ style.width.maxContent ]
                    ["width" ==> "max-content"]
                test
                    "Height px"
                    [ style.height' (px 100) ]
                    ["height" ==> "100px"]
                test
                    "Height max content"
                    [ style.height.maxContent ]
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
                    [style.paintOrder.normal]
                    ["paintOrder" ==> "normal"]
                test
                    "Paint order stroke fill"
                    [style.paintOrder.value(Visibility.PaintOrder.Stroke, Visibility.PaintOrder.Fill)]
                    ["paintOrder" ==> "stroke fill"]
                test
                    "Visibility hidden"
                    [ style.visibility.hidden]
                    ["visibility" ==> "hidden"]
                test
                    "Opacity 1"
                    [ style.opacity' 1.0 ]
                    ["opacity" ==> "1"]
                test
                    "Overflow-X visible"
                    [style.overflowX.visible]
                    ["overflowX" ==> "visible"]
                test
                    "OverflowY visible"
                    [style.overflowY.visible]
                    ["overflowY" ==> "visible"]
                test
                    "Overflow scroll Scroll"
                    [style.overflow.value (Overflow.Scroll, Overflow.Scroll)]
                    ["overflow" ==> "scroll scroll"]
                test
                    "OverflowWrap break-word"
                    [style.overflowWrap.breakWord]
                    ["overflowWrap" ==> "break-word"]
                test
                    "Direction rtl"
                    [ style.direction.ltr ]
                    ["direction" ==> "ltr"]
                test
                    "Box sizing border box "
                    [style.boxSizing.borderBox]
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
                    [ style.verticalAlign.baseline]
                    ["verticalAlign" ==> "baseline"]
                test
                    "Position static"
                    [ style.position.static']
                    ["position" ==> "static"]
                test
                    "Float left"
                    [ style.float.left]
                    ["float" ==> "left"]
                test
                    "WritingMode horizontal-tb"
                    [ style.writingMode.horizontalTb]
                    ["writingMode" ==> "horizontal-tb"]
                test
                    "BreakAfter avoid"
                    [style.breakAfter.avoid]
                    ["breakAfter" ==> "avoid"]
                test
                    "BreakBefore avoid"
                    [style.breakBefore.avoid]
                    ["breakBefore" ==> "avoid"]
                test
                    "BreakInside avoid-column"
                    [style.breakInside.avoidColumn]
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
                    [ style.backfaceVisibility.inherit']
                    [ "backfaceVisibility" ==> "inherit" ]
                test
                    "PointerEvents VisiblePainted"
                    [ style.pointerEvents.visiblePainted ]
                    ["pointerEvents" ==> "visiblePainted"]
                test
                    "Cursor Wait"
                    [style.cursor.wait]
                    [ "cursor" ==> "wait"]
                test
                    "Content image"
                    [ style.content.url "http://www.example.com/test.png" ]
                    [ "content" ==> "url(http://www.example.com/test.png)" ]
                test
                    "Content image with alt text"
                    [ style.content.url("http://www.example.com/test.png", "this is the alt text") ]
                    [ "content" ==> "url(http://www.example.com/test.png) / \"this is the alt text\"" ]
                test
                    "Content linear gradient"
                    [ style.content.linearGradient(deg 45.0, [hex "e66456", px 0; hex "9198e5", px 100]) ]
                    [ "content" ==> "linear-gradient(45.00deg, #e66456 0px, #9198e5 100px)" ]
                test
                   "Content counter"
                    [ style.content.counter sampleCounter]
                    [ "content" ==> sprintf "counter(%s)" (counterStyleHelpers.counterStyleToString sampleCounter) ]
                test
                    "Content counter2"
                    [ style.content.counters (sampleCounter, ListStyle.Type.UpperLatin) ]
                    [ "content" ==> sprintf "counters(%s, upper-latin)" (counterStyleHelpers.counterStyleToString  sampleCounter) ]
                test
                    "Caption side top"
                    [style.captionSide.top]
                    ["captionSide" ==> "top"]
                test
                    "Empty Cells show"
                    [style.emptyCells.show]
                    ["emptyCells" ==> "show"]
                test
                    "Table Layout fixed"
                    [style.tableLayout.fixed']
                    ["tableLayout" ==> "fixed"]
                test
                    "caret color hsl"
                    [ style.caretColor.hsl 255 0. 0. ]
                    ["caretColor" ==> "hsl(255, 0%, 0%)"]
                test
                    "caret color green"
                    [ style.caretColor.green ]
                    ["caretColor" ==> "#008000"]
                test
                    "Appearance square button"
                    [style.appearance.squareButton]
                    ["appearance" ==> "square-button"]
                test
                    "Orphans number"
                    [ style.orphans' (CssInt 2)]
                    [ "orphans" ==> "2" ]
                test
                    "Orphans inherit"
                    [ style.orphans.inherit']
                    [ "orphans" ==> "inherit" ]
                test
                    "Widows number"
                    [ style.widows' (CssInt 2)]
                    [ "widows" ==> "2" ]
                test
                    "Widows unset"
                    [ style.widows.unset ]
                    [ "widows" ==> "unset" ]
                test
                    "All inherit"
                    [ style.all.inherit']
                    [ "all" ==> "inherit" ]
                test
                    "Grid area"
                    [ style.gridArea' "foo" ]
                    ["gridArea" ==> "foo"]
                test
                    "Grid area"
                    [ style.gridArea.value (Grid.Ident "area1", Grid.Ident "area2") ]
                    ["gridArea" ==> "area1 / area2"]
                test
                    "Grid area initial"
                    [style.gridArea.initial]
                    ["gridArea" ==> "initial"]
                test
                    "Grid column ident and ident"
                    [ style.gridColumn.value(Grid.Ident "someStart", Grid.Ident "someEnd") ]
                    ["gridColumn" ==> "someStart / someEnd"]
                test
                    "Grid column unset"
                    [style.gridColumn.unset]
                    ["gridColumn" ==> "unset"]
                test
                    "Grid column start ident"
                    [style.gridColumnStart.ident "somegridarea"]
                    ["gridColumnStart" ==> "somegridarea"]
                test
                    "Grid column end value"
                    [style.gridColumnEnd' 1]
                    ["gridColumnEnd" ==> "1"]
                test
                    "Grid column end ident"
                    [style.gridColumnEnd.ident "somegridarea"]
                    ["gridColumnEnd" ==> "somegridarea"]
                test
                    "Grid row ident and ident"
                    [ style.gridRow.value (Grid.Ident "someStart", Grid.Ident "someEnd") ]
                    ["gridRow" ==> "someStart / someEnd"]
                test
                    "Grid row auto"
                    [style.gridRow.auto]
                    ["gridRow" ==> "auto"]
                test
                    "Grid row start value"
                    [style.gridRowStart' 1]
                    ["gridRowStart" ==> "1"]
                test
                    "Grid row start ident"
                    [style.gridRowStart.ident "somegridarea"]
                    ["gridRowStart" ==> "somegridarea"]
                test
                    "Grid row end value"
                    [style.gridRowEnd' 1 ]
                    ["gridRowEnd" ==> "1"]
                test
                    "Grid row end ident"
                    [style.gridRowEnd.ident "somegridarea"]
                    ["gridRowEnd" ==> "somegridarea"]
                test
                    "Grid gap px"
                    [style.gridGap' (px 10)]
                    ["gridGap" ==> "10px"]
                test
                    "Grid gap px and px"
                    [ style.gridGap.value (px 20, px 10) ]
                    ["gridGap" ==> "20px 10px"]
                test
                    "Row gap normal"
                    [style.gridRowGap.normal]
                    ["gridRowGap" ==> "normal"]
                test
                    "Row gap px"
                    [style.gridRowGap' (px 3)]
                    ["gridRowGap" ==> "3px"]
                test
                    "Column gap normal"
                    [style.gridColumnGap.normal]
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
                    [style.gridTemplateRows.minMax (px 100, fr 1.) ]
                    ["gridTemplateRows" ==> "minmax(100px, 1.00fr)"]
                test
                    "Grid template row px repeat px"
                    [style.gridTemplateRows.values [ px 200; Grid.Repeat.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateRows" ==> "200px repeat(auto-fill, 100px) 300px"]
                test
                    "Grid template column px"
                    [style.gridTemplateColumns' (px 100)]
                    ["gridTemplateColumns" ==> "100px"]
                test
                    "Grid template column masonry"
                    [style.gridTemplateColumns.masonry]
                    ["gridTemplateColumns" ==> "masonry"]
                test
                    "Grid template column repeat"
                    [style.gridTemplateColumns.repeat(3, px 200)]
                    ["gridTemplateColumns" ==> "repeat(3, 200px)"]
                test
                    "Grid template column px repeat px"
                    [style.gridTemplateColumns.values [px 200; Grid.Repeat.Repeat(Grid.AutoFill, px 100); px 300]]
                    ["gridTemplateColumns" ==> "200px repeat(auto-fill, 100px) 300px"]
                test
                    "Grid auto columns min content"
                    [style.gridAutoColumns.minContent]
                    ["gridAutoColumns" ==> "min-content"]
                test
                    "Grid auto columns multiple with pxs"
                    [ style.gridAutoColumns.values [px 100; px 150; px 390;] ]
                    ["gridAutoColumns" ==> "100px 150px 390px"]
                test
                    "Grid auto rows min content"
                    [style.gridAutoRows.minContent]
                    ["gridAutoRows" ==> "min-content"]
                test
                    "Grid auto rows fit content"
                    [style.gridAutoRows.fitContent(px 400) ]
                    ["gridAutoRows" ==> "fit-content(400px)"]
                test
                    "Grid auto flow rows"
                    [style.gridAutoFlow.row]
                    ["gridAutoFlow" ==> "row"]
                test
                    "Grid template areas None"
                    [style.gridTemplateAreas.none]
                    ["gridTemplateAreas" ==> "none"]
                test
                    "Grid template areas strings"
                    [style.gridTemplateAreas.value [ "a"; "b"  ] ]
                    ["gridTemplateAreas" ==> "\"a b\""]
                test
                    "Grid template areas multiple strings"
                    [style.gridTemplateAreas.value
                         [
                            [ "header";  "header";  "header";  "header" ]
                            [ "main";  "main";  ".";  "sidebar" ]
                            [ "footer";  "footer";  "footer";  "footer" ]
                        ]
                    ]
                    ["gridTemplateAreas" ==> "\"header header header header\" \"main main . sidebar\" \"footer footer footer footer\""]
                test
                    "Flex direction row"
                    [ style.flexDirection.row]
                    ["flexDirection" ==> "row"]
                test
                    "Flex wrap no-wrap"
                    [ style.flexWrap.noWrap]
                    ["flexWrap" ==> "no-wrap"]
                test
                    "Flex basis em"
                    [ style.flexBasis' (em 10.0)]
                    ["flexBasis" ==> "10.0em"]
                test
                    "Justify content start"
                    [ style.justifyContent.start]
                    ["justifyContent" ==> "start"]
                test
                    "Justify self normal"
                    [ style.justifySelf.normal ]
                    ["justifySelf" ==> "normal"]
                test
                    "Justify items end"
                    [ style.justifyItems.end']
                    ["justifyItems" ==> "end"]
                test
                    "Align self normal"
                    [ style.alignSelf.normal]
                    ["alignSelf" ==> "normal"]
                test
                    "Align items start"
                    [ style.alignItems.start]
                    ["alignItems" ==> "start"]
                test
                    "Align content start"
                    [ style.alignContent.start']
                    ["alignContent" ==> "start"]
                test
                    "Order value"
                    [ style.order' (CssInt 1) ]
                    ["order" ==> "1"]
                test
                    "Order inherit"
                    [ style.order.inherit']
                    ["order" ==> "inherit"]
                test
                    "Flex grow value"
                    [ style.flexGrow' (CssFloat 1.5) ]
                    ["flexGrow" ==> "1.5"]
                test
                    "FlexGrow inherit"
                    [ style.flexGrow.inherit']
                    ["flexGrow" ==> "inherit"]
                test
                    "FlexShrink value"
                    [ style.flexShrink' (CssFloat 1.5) ]
                    ["flexShrink" ==> "1.5"]
                test
                    "FlexShrink inherit"
                    [ style.flexShrink.inherit']
                    ["flexShrink" ==> "inherit"]
                test
                    "Outline offset px"
                    [ style.outlineOffset.value <| px 3 ]
                    [ "outlineOffset" ==> "3px" ]
                test
                    "Outline initial"
                    [ style.outline.initial ]
                    [ "outline" ==> "initial" ]
                test
                    "Outline width px"
                    [ style.outlineWidth' (px 40) ]
                    [ "outlineWidth" ==> "40px" ]
                test
                    "Outline width thin"
                    [ style.outlineWidth.thin ]
                    [ "outlineWidth" ==> "thin" ]
                test
                    "Outline style hidden"
                    [ style.outlineStyle.hidden ]
                    [ "outlineStyle" ==> "hidden" ]
                test
                    "Outline color hex"
                    [ style.outlineColor.hex "f92525"]
                    ["outlineColor" ==> "#f92525"]
                testMedia
                    "Media query with min width and min height"
                    [ Media.MinWidth (px 500); Media.MaxWidth (px 700) ]
                    [ style.backgroundColor.red ]
                    ("@media (min-width: 500px) and (max-width: 700px)" ==> "[backgroundColor,#ff0000]")
                testMedia
                    "Media query min height only"
                        [ Media.MinHeight (px 700) ]
                        [ style.backgroundColor.pink ]
                        ("@media (min-height: 700px)" ==> "[backgroundColor,#ffc0cb]")
                testMediaFor
                    "Media query for print"
                        (Media.Print)
                        []
                        [
                            style.marginTop' (px 200)
                            style.transforms
                                [
                                Transform.Rotate (deg 45.0)
                                    ]
                            style.backgroundColor.indianRed
                            ]
                    ("@media print " ==> "[marginTop,200px; transform,rotate(45.00deg); backgroundColor,#cd5c5c]")
                testMediaFor
                    "Media not all"
                        (Media.Not Media.Device.All)
                        [ Media.Feature.Color ]
                        [style.marginTop' (px 200) ]
                        ("@media not all and (color)" ==> "[marginTop,200px]")
                testMediaFor
                    "Media query only screen"
                    (Media.Only Media.Device.Screen)
                    [
                        Media.Feature.Color
                        Media.Feature.Pointer Media.Fine
                        Media.Feature.Scan Media.Interlace
                        Media.Feature.Grid true
                    ]
                    [
                        style.marginTop' (px 200)
                        style.transforms
                            [
                                Transform.Rotate (deg 45.0)
                            ]
                        style.backgroundColor.indianRed
                    ]
                    ("@media only screen and (color) and (pointer: fine) and (scan: interlace) and (grid: 1)"
                    ==>
                    "[marginTop,200px; transform,rotate(45.00deg); backgroundColor,#cd5c5c]")
                test
                    "BoxShadow color"
                    [
                        style.boxShadows
                            [
                                style.boxShadow.color(px 10, px 10, Color.blue)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px #0000ff" ]
                test
                    "BoxShadow blur color"
                    [
                        style.boxShadows
                            [
                                style.boxShadow.blurColor(px 10, px 10, em 1.5, Color.red)
                            ]
                    ]
                    [ "boxShadow" ==> "10px 10px 1.5em #ff0000" ]
                test
                    "BoxShadow blur spread color"
                    [
                        style.boxShadows
                            [
                                style.boxShadow.blurSpreadColor(px 1, px 100, vh 1.5, px 1, Color.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "1px 100px 1.5vh 1px #d2691e" ]
                test
                    "Multiple box shadows"
                   [
                        style.boxShadows
                            [
                                style.boxShadow.color(px 10, px 10, Color.blue)
                                style.boxShadow.blurColor(px 10, px 10, px 10, Color.blue)
                                style.boxShadow.blurSpreadColor(px 10, px 10, px 10, px 10, Color.blue)
                                style.boxShadow.color(px 3, px 3, Color.red)
                                style.boxShadow.blurColor(em -1., px 0, em 0.4, Color.olive)
                            ]
                    ]
                    ["boxShadow" ==> "10px 10px #0000ff, 10px 10px 10px #0000ff, 10px 10px 10px 10px #0000ff, 3px 3px #ff0000, -1.0em 0px 0.4em #808000"]
                test
                    "BoxShadow invert"
                    [
                        style.boxShadows
                            [
                                style.inset <| style.boxShadow.blurSpreadColor(px 1, px 100, vh 1.5, px 1, Color.chocolate)
                            ]
                    ]
                    [ "boxShadow" ==> "inset 1px 100px 1.5vh 1px #d2691e" ]
                test
                    "ScrollBehavior smooth"
                    [ style.scrollBehavior.smooth]
                    [ "scrollBehavior" ==> "smooth" ]
                test
                    "OverscrollBehaviorX contain"
                    [ style.overscrollBehaviorX.contain]
                    [ "overscrollBehaviorX" ==> "contain" ]
                test
                    "OverscrollBehaviorY contain"
                    [ style.overscrollBehaviorY.contain]
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
                    [style.clipPath.path "M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z"]
                    ["clipPath" ==> "path('M0.5,1 C0.5,1,0,0.7,0,0.3 A0.25,0.25,1,1,1,0.5,0.3 A0.25,0.25,1,1,1,1,0.3 C1,0.7,0.5,1,0.5,1 Z')"]
                test
                    "Clear initial"
                    [ style.clear.initial]
                    [ "clear" ==> "initial" ]
                test
                    "Filter Url"
                    [ style.filters [ Filter.Url "someFilter" ] ]
                    [ "filter" ==> "url(\"someFilter\")" ]
                test
                    "Filter drop shadow"
                    [ style.filters [ style.filter.dropShadow 16 16 20 Color.red (pct 5)  ] ]
                    [ "filter" ==> "drop-shadow(16px 16px 20px #ff0000) invert(5%)" ]
                test
                    "Filter unset"
                    [ style.filter.unset ]
                    [ "filter" ==> "unset" ]
                test
                    "BackdropFilter Url"
                    [ style.backdropFilters [ Filter.Url "someFilter" ] ]
                    [ "backdropFilter" ==> "url(\"someFilter\")" ]
                test
                    "BackdropFilter unset"
                    [ style.backdropFilter.unset ]
                    [ "backdropFilter" ==> "unset" ]
                test
                   "Mix blend mode HardLight"
                   [ style.mixBlendMode.hardLight]
                   ["mixBlendMode" ==> "hard-light"]
                test
                    "AspectRatio"
                    [ style.aspectRatio.value(16, 9) ]
                    [ "aspectRatio" ==> "16 / 9" ]
                test
                    "MaskClip content-box"
                    [ style.maskClip.contentBox]
                    [ "maskClip" ==> "content-box" ]
                test
                    "MaskComposite add"
                    [ style.maskComposite.add]
                    [ "maskComposite" ==> "add" ]
                test
                    "Mask image source url"
                    [ style.maskImage.url "image.jpg" ]
                    [ "maskImage" ==> "url(image.jpg)" ]
                test
                    "MaskOrigin margin-box"
                    [ style.maskOrigin.marginBox]
                    [ "maskOrigin" ==> "margin-box" ]
                test
                    "MaskPosition size"
                    [ style.maskPosition' (px 1) (rem 1.)]
                    [ "maskPosition" ==> "1px 1.0rem" ]
                test
                    "MaskPosition sizes"
                    [ style.maskPosition.value([px 1, rem 1.; px 10, px 100])]
                    [ "maskPosition" ==> "1px 1.0rem, 10px 100px" ]
                test
                    "MaskRepeat value"
                    [ style.maskRepeat.value(Mask.Repeat)]
                    [ "maskRepeat" ==> "repeat" ]
                test
                    "MaskRepeat multiple values"
                    [ style.maskRepeat.value([Mask.RepeatX, Mask.RepeatY; Mask.NoRepeat, Mask.Round])]
                    [ "maskRepeat" ==> "repeat-x repeat-y, no-repeat round" ]
                test
                    "MaskRepeat repeatX"
                    [ style.maskRepeat.repeatX]
                    [ "maskRepeat" ==> "repeat-x" ]
            ]