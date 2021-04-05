namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Text =
    let tests =
        testList "Text"
            [
                testCase
                    "Text decoration none"
                    [TextDecoration.none]
                    ["textDecoration" ==> "none"]
                testCase
                    "Text emphasis none"
                    [TextEmphasis.none]
                    ["textEmphasis" ==> "none"]
                testCase
                    "Text emphasis inherit"
                    [ TextEmphasis.inherit' ]
                    ["textEmphasis" ==> "inherit"]
                testCase
                    "Text emphasis initial"
                    [ TextEmphasis.initial ]
                    ["textEmphasis" ==> "initial"]
                testCase
                    "Text emphasis unset"
                    [ TextEmphasis.unset ]
                    ["textEmphasis" ==> "unset"]
                testCase
                    "Text align left"
                    [ TextAlign.left ]
                    ["textAlign" ==> "left"]
                testCase
                    "Text align right"
                    [ TextAlign.right ]
                    ["textAlign" ==> "right"]
                testCase
                    "Text align center"
                    [ TextAlign.center ]
                    ["textAlign" ==> "center"]
                testCase
                    "Text align justify"
                    [ TextAlign.justify ]
                    ["textAlign" ==> "justify"]
                testCase
                    "Text align justify all"
                    [ TextAlign.justifyAll ]
                    ["textAlign" ==> "justify-all"]
                testCase
                    "Text align start"
                    [ TextAlign.start ]
                    ["textAlign" ==> "start"]
                testCase
                    "Text align end"
                    [ TextAlign.end' ]
                    ["textAlign" ==> "end"]
                testCase
                    "Text align match-parent"
                    [ TextAlign.matchParent ]
                    ["textAlign" ==> "match-parent"]
                testCase
                    "Text align inherit"
                    [ TextAlign.inherit' ]
                    ["textAlign" ==> "inherit"]
                testCase
                    "Text align initial"
                    [ TextAlign.initial ]
                    ["textAlign" ==> "initial"]
                testCase
                    "Text align unset"
                    [ TextAlign.unset ]
                    ["textAlign" ==> "unset"]
                testCase
                    "Text align last left"
                    [ TextAlignLast.left ]
                    ["textAlignLast" ==> "left"]
                testCase
                    "Text align last right"
                    [ TextAlignLast.right ]
                    ["textAlignLast" ==> "right"]
                testCase
                    "Text align last center"
                    [ TextAlignLast.center ]
                    ["textAlignLast" ==> "center"]
                testCase
                    "Text align last justify"
                    [ TextAlignLast.justify ]
                    ["textAlignLast" ==> "justify"]
                testCase
                    "Text align last start"
                    [ TextAlignLast.start ]
                    ["textAlignLast" ==> "start"]
                testCase
                    "Text align last end"
                    [ TextAlignLast.end' ]
                    ["textAlignLast" ==> "end"]
                testCase
                    "Text align last inherit"
                    [ TextAlignLast.inherit' ]
                    ["textAlignLast" ==> "inherit"]
                testCase
                    "Text align last initial"
                    [ TextAlignLast.initial ]
                    ["textAlignLast" ==> "initial"]
                testCase
                    "Text align last unset"
                    [ TextAlignLast.unset ]
                    ["textAlignLast" ==> "unset"]
                testCase
                    "Text decoration color red"
                    [TextDecorationColor.red]
                    ["textDecorationColor" ==> "#ff0000"]
                testCase
                    "Text decoration color hex"
                    [TextDecorationColor.hex "00ff00" ]
                    ["textDecorationColor" ==> "#00ff00" ]
                testCase
                    "Text decoration color rgba"
                    [TextDecorationColor.rgba 255 128 128 0.5 ]
                    ["textDecorationColor" ==> "rgba(255, 128, 128, 0.500000)"]
                testCase
                    "Text decoration color transparent"
                    [TextDecorationColor.transparent]
                    ["textDecorationColor" ==> "rgba(0, 0, 0, 0.000000)"]
                testCase
                    "Text decoration color inherit"
                    [TextDecorationColor.inherit']
                    ["textDecorationColor" ==> "inherit"]
                testCase
                    "Text decoration color initial"
                    [TextDecorationColor.initial]
                    ["textDecorationColor" ==> "initial"]
                testCase
                    "Text decoration color unset"
                    [TextDecorationColor.unset]
                    ["textDecorationColor" ==> "unset"]
                testCase
                    "Text decoration line none"
                    [TextDecorationLine.none]
                    ["textDecorationLine" ==> "none"]
                testCase
                    "Text decoration line underline"
                    [TextDecorationLine.underline]
                    ["textDecorationLine" ==> "underline"]
                testCase
                    "Text decoration line overline"
                    [TextDecorationLine.overline]
                    ["textDecorationLine" ==> "overline"]
                testCase
                    "Text decoration line line-through"
                    [TextDecorationLine.lineThrough]
                    ["textDecorationLine" ==> "line-through"]
                testCase
                    "Text decoration line blink"
                    [TextDecorationLine.blink]
                    ["textDecorationLine" ==> "blink"]
                testCase
                    "Text decoration line inherit"
                    [ TextDecorationLine.inherit' ]
                    ["textDecorationLine" ==> "inherit"]
                testCase
                    "Text decoration line initial"
                    [ TextDecorationLine.initial ]
                    ["textDecorationLine" ==> "initial"]
                testCase
                    "Text decoration line unset"
                    [ TextDecorationLine.unset ]
                    ["textDecorationLine" ==> "unset"]
                testCase
                    "Text decorations multiple"
                    [TextDecorationLine.value(FssTypes.Text.DecorationLine.Overline, FssTypes.Text.DecorationLine.Underline, FssTypes.Text.DecorationLine.LineThrough)]
                    ["textDecorationLine" ==> "overline underline line-through"]
                testCase
                    "Text decoration skip none"
                    [TextDecorationSkip.none]
                    ["textDecorationSkip" ==> "none"]
                testCase
                    "Text decoration skip objects"
                    [TextDecorationSkip.objects]
                    ["textDecorationSkip" ==> "objects"]
                testCase
                    "Text decoration skip spaces"
                    [TextDecorationSkip.spaces]
                    ["textDecorationSkip" ==> "spaces"]
                testCase
                    "Text decoration skip edges"
                    [TextDecorationSkip.edges]
                    ["textDecorationSkip" ==> "edges"]
                testCase
                    "Text decoration skip box-decoration"
                    [TextDecorationSkip.boxDecoration]
                    ["textDecorationSkip" ==> "box-decoration"]
                testCase
                    "Text decoration skip multiple - objects and spaces"
                    [TextDecorationSkip.value(FssTypes.Text.DecorationSkip.Objects, FssTypes.Text.DecorationSkip.Spaces) ]
                    ["textDecorationSkip" ==> "objects spaces"]
                testCase
                    "Text decoration skip multiple - leading spaces and trailing spaces"
                    [TextDecorationSkip.value(FssTypes.Text.DecorationSkip.LeadingSpaces, FssTypes.Text.DecorationSkip.TrailingSpaces)]
                    ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]
                testCase
                    "Text decoration skip multiple - objects edges box-decoration"
                    [TextDecorationSkip.value(FssTypes.Text.DecorationSkip.Objects, FssTypes.Text.DecorationSkip.Edges, FssTypes.Text.DecorationSkip.BoxDecoration) ]
                    ["textDecorationSkip" ==> "objects edges box-decoration"]
                testCase
                    "Text decoration skip inherit"
                    [TextDecorationSkip.inherit']
                    ["textDecorationSkip" ==> "inherit"]
                testCase
                    "Text decoration skip initial"
                    [TextDecorationSkip.initial]
                    ["textDecorationSkip" ==> "initial"]
                testCase
                    "Text decoration skip unset"
                    [TextDecorationSkip.unset]
                    ["textDecorationSkip" ==> "unset"]
                testCase
                    "Text decoration skip unset"
                    [TextDecorationSkipInk.auto]
                    ["textDecorationSkipInk" ==> "auto"]
                testCase
                    "Text decoration skip All"
                    [TextDecorationSkipInk.all]
                    ["textDecorationSkipInk" ==> "all"]
                testCase
                    "Text decoration skip none"
                    [TextDecorationSkipInk.none]
                    ["textDecorationSkipInk" ==> "none"]
                testCase
                    "Text decoration skipink inherit"
                    [TextDecorationSkipInk.inherit']
                    ["textDecorationSkipInk" ==> "inherit"]
                testCase
                    "Text decoration skipink unset"
                    [TextDecorationSkipInk.unset]
                    ["textDecorationSkipInk" ==> "unset"]
                testCase
                    "Text decoration skipink initial"
                    [TextDecorationSkipInk.initial]
                    ["textDecorationSkipInk" ==> "initial"]
                testCase
                    "Text decoration style solid"
                    [TextDecorationStyle.solid]
                    ["textDecorationStyle" ==> "solid"]
                testCase
                    "Text decoration style double"
                    [TextDecorationStyle.double]
                    ["textDecorationStyle" ==> "double"]
                testCase
                    "Text decoration style dotted"
                    [TextDecorationStyle.dotted]
                    ["textDecorationStyle" ==> "dotted"]
                testCase
                    "Text decoration style dashed"
                    [TextDecorationStyle.dashed]
                    ["textDecorationStyle" ==> "dashed"]
                testCase
                    "Text decoration style wavy"
                    [TextDecorationStyle.wavy]
                    ["textDecorationStyle" ==> "wavy"]
                testCase
                    "Text decoration style inherit"
                    [TextDecorationStyle.inherit']
                    ["textDecorationStyle" ==> "inherit"]
                testCase
                    "Text decoration style initial"
                    [TextDecorationStyle.initial]
                    ["textDecorationStyle" ==> "initial"]
                testCase
                    "Text decoration style unset"
                    [TextDecorationStyle.unset]
                    ["textDecorationStyle" ==> "unset"]
                testCase
                    "Text decoration thickness auto"
                    [ TextDecorationThickness.auto ]
                    [ "textDecorationThickness" ==> "auto" ]
                testCase
                    "Text decoration thickness from font"
                    [ TextDecorationThickness.fromFont ]
                    ["textDecorationThickness" ==> "from-font" ]
                testCase
                    "Text decoration thickness em"
                    [ TextDecorationThickness' (em 0.1) ]
                    ["textDecorationThickness" ==> "0.1em" ]
                testCase
                    "Text decoration thickness px"
                    [ TextDecorationThickness' (px 3) ]
                    ["textDecorationThickness" ==> "3px" ]
                testCase
                    "Text decoration thickness percent"
                    [ TextDecorationThickness' (pct 10) ]
                    ["textDecorationThickness" ==> "10%" ]
                testCase
                    "Text decoration thickness inherit"
                    [ TextDecorationThickness.inherit' ]
                    ["textDecorationThickness" ==> "inherit" ]
                testCase
                    "Text decoration thickness initial"
                    [ TextDecorationThickness.initial ]
                    ["textDecorationThickness" ==> "initial" ]
                testCase
                    "Text decoration thickness unset"
                    [ TextDecorationThickness.unset ]
                    ["textDecorationThickness" ==> "unset" ]
                testCase
                    "Text emphasis color hex"
                    [ TextEmphasisColor.hex "#555" ]
                    ["textEmphasisColor" ==> "#555"]
                testCase
                    "Text emphasis color color name"
                    [ TextEmphasisColor.blue ]
                    ["textEmphasisColor" ==> "#0000ff"]
                testCase
                    "Text emphasis color rgba"
                    [ TextEmphasisColor.rgba 90 200 160 0.8 ]
                    ["textEmphasisColor" ==> "rgba(90, 200, 160, 0.800000)"]
                testCase
                    "Text emphasis color transparent"
                    [ TextEmphasisColor.transparent ]
                    ["textEmphasisColor" ==> "rgba(0, 0, 0, 0.000000)"]
                testCase
                    "Text emphasis color inherit"
                    [ TextEmphasisColor.inherit' ]
                    ["textEmphasisColor" ==> "inherit"]
                testCase
                    "Text emphasis color Initial"
                    [ TextEmphasisColor.initial ]
                    ["textEmphasisColor" ==> "initial"]
                testCase
                    "Text emphasis color unset"
                    [ TextEmphasisColor.unset ]
                    ["textEmphasisColor" ==> "unset"]
                testCase
                    "Text emphasis position over right"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Over, FssTypes.Text.EmphasisPosition.Right) ]
                    ["textEmphasisPosition" ==> "over right"]
                testCase
                    "Text emphasis position over left"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Over, FssTypes.Text.EmphasisPosition.Left) ]
                    ["textEmphasisPosition" ==> "over left"]
                testCase
                    "Text emphasis position under right"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Under, FssTypes.Text.EmphasisPosition.Right) ]
                    ["textEmphasisPosition" ==> "under right"]
                testCase
                    "Text emphasis position under left"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Under, FssTypes.Text.EmphasisPosition.Left) ]
                    ["textEmphasisPosition" ==> "under left"]
                testCase
                    "Text emphasis position left over"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Left, FssTypes.Text.EmphasisPosition.Over) ]
                    ["textEmphasisPosition" ==> "left over"]
                testCase
                    "Text emphasis position right under"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Right, FssTypes.Text.EmphasisPosition.Under) ]
                    ["textEmphasisPosition" ==> "right under"]
                testCase
                    "Text emphasis position left under"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Left, FssTypes.Text.EmphasisPosition.Under) ]
                    ["textEmphasisPosition" ==> "left under"]
                testCase
                    "Text emphasis position inherit"
                    [ TextEmphasisPosition.inherit' ]
                    ["textEmphasisPosition" ==> "inherit"]
                testCase
                    "Text emphasis position Initial"
                    [ TextEmphasisPosition.initial ]
                    ["textEmphasisPosition" ==> "initial"]
                testCase
                    "Text emphasis position unset"
                    [ TextEmphasisPosition.unset ]
                    ["textEmphasisPosition" ==> "unset"]
                testCase
                    "Text Emphasis Style x"
                    [TextEmphasisStyle' (FssTypes.CssString "x")]
                    ["textEmphasisStyle" ==> "'x'"]
                testCase
                    "Text Emphasis Style *"
                    [TextEmphasisStyle' (FssTypes.CssString "*")]
                    ["textEmphasisStyle" ==> "'*'"]
                testCase
                    "Text Emphasis Style filled"
                    [TextEmphasisStyle.filled ]
                    ["textEmphasisStyle" ==> "filled"]
                testCase
                    "Text Emphasis Style open"
                    [TextEmphasisStyle.open']
                    ["textEmphasisStyle" ==> "open"]
                testCase
                    "Text Emphasis Style circle"
                    [TextEmphasisStyle.circle]
                    ["textEmphasisStyle" ==> "circle"]
                testCase
                    "Text Emphasis Style double circle"
                    [TextEmphasisStyle.doubleCircle]
                    ["textEmphasisStyle" ==> "double-circle"]
                testCase
                    "Text Emphasis Style triangle"
                    [TextEmphasisStyle.triangle]
                    ["textEmphasisStyle" ==> "triangle"]
                testCase
                    "Text Emphasis Style filled sesame"
                    [TextEmphasisStyle.filledSesame]
                    ["textEmphasisStyle" ==> "filled sesame"]
                testCase
                    "Text Emphasis Style open sesame"
                    [TextEmphasisStyle.openSesame]
                    ["textEmphasisStyle" ==> "open sesame"]
                testCase
                    "Text emphasis style inherit"
                    [ TextEmphasisStyle.inherit' ]
                    ["textEmphasisStyle" ==> "inherit"]
                testCase
                    "Text emphasis style Initial"
                    [ TextEmphasisStyle.initial ]
                    ["textEmphasisStyle" ==> "initial"]
                testCase
                    "Text emphasis style unset"
                    [ TextEmphasisStyle.unset ]
                    ["textEmphasisStyle" ==> "unset"]
                testCase
                    "Text shadow single"
                    [ TextShadows [ TextShadow.colorXyBlur (px 1, px 1, px 2, FssTypes.Color.Color.black) ] ]
                    ["textShadow" ==> "#000000 1px 1px 2px"]
                testCase
                    "Text shadow multiple"
                    [ TextShadows
                          [ TextShadow.colorXyBlur(px 1, px 1, px 2, FssTypes.Color.Color.black)
                            TextShadow.colorXyBlur(px 10, px -10, px 20, FssTypes.Color.Color.red) ]
                    ]
                    ["textShadow" ==> "#000000 1px 1px 2px, #ff0000 10px -10px 20px"]
                testCase
                    "Text underline offset auto"
                    [ TextUnderlineOffset.auto ]
                    ["textUnderlineOffset" ==> "auto"]
                testCase
                    "Text underline offset em"
                    [ TextUnderlineOffset' (em 3.0) ]
                    ["textUnderlineOffset" ==> "3.0em"]
                testCase
                    "Text underline offset px"
                    [ TextUnderlineOffset' (px 10) ]
                    ["textUnderlineOffset" ==> "10px"]
                testCase
                    "Text underline offset percent"
                    [ TextUnderlineOffset' (pct 10) ]
                    ["textUnderlineOffset" ==> "10%"]
                testCase
                    "Text underline offset inherit"
                    [ TextUnderlineOffset.inherit' ]
                    ["textUnderlineOffset" ==> "inherit"]
                testCase
                    "Text underline offset Initial"
                    [ TextUnderlineOffset.initial ]
                    ["textUnderlineOffset" ==> "initial"]
                testCase
                    "Text underline offset unset"
                    [ TextUnderlineOffset.unset ]
                    ["textUnderlineOffset" ==> "unset"]
                testCase
                    "Text underline position from-font"
                    [ TextUnderlinePosition.fromFont ]
                    ["textUnderlinePosition" ==> "from-font"]
                testCase
                    "Text underline position Under"
                    [ TextUnderlinePosition.under ]
                    ["textUnderlinePosition" ==> "under"]
                testCase
                    "Text underline position left"
                    [ TextUnderlinePosition.left ]
                    ["textUnderlinePosition" ==> "left"]
                testCase
                    "Text underline position right"
                    [ TextUnderlinePosition.right ]
                    ["textUnderlinePosition" ==> "right"]
                testCase
                    "Text underline position auto-pos"
                    [ TextUnderlinePosition.autoPos ]
                    ["textUnderlinePosition" ==> "auto-pos"]
                testCase
                    "Text underline position above"
                    [ TextUnderlinePosition.above ]
                    ["textUnderlinePosition" ==> "above"]
                testCase
                    "Text underline position below"
                    [ TextUnderlinePosition.below ]
                    ["textUnderlinePosition" ==> "below"]
                testCase
                    "Text underline positions under left"
                    [ TextUnderlinePosition.value (FssTypes.Text.UnderlinePosition.Under, FssTypes.Text.UnderlinePosition.Left) ]
                    ["textUnderlinePosition" ==> "under left"]
                testCase
                    "Text underline positions right under"
                    [ TextUnderlinePosition.value (FssTypes.Text.UnderlinePosition.Right, FssTypes.Text.UnderlinePosition.Under) ]
                    ["textUnderlinePosition" ==> "right under"]
                testCase
                    "Text underline position auto"
                    [ TextUnderlinePosition.auto ]
                    ["textUnderlinePosition" ==> "auto"]
                testCase
                    "Text underline position inherit"
                    [ TextUnderlinePosition.inherit' ]
                    ["textUnderlinePosition" ==> "inherit"]
                testCase
                    "Text underline position Initial"
                    [ TextUnderlinePosition.initial ]
                    ["textUnderlinePosition" ==> "initial"]
                testCase
                    "Text underline position unset"
                    [ TextUnderlinePosition.unset ]
                    ["textUnderlinePosition" ==> "unset"]
                testCase
                    "Text indent mm"
                    [ TextIndent' (mm 3.0) ]
                    ["textIndent" ==> "3.0mm"]
                testCase
                    "Text indent px"
                    [ TextIndent' (px 40) ]
                    ["textIndent" ==> "40px"]
                testCase
                    "Text indent percent"
                    [ TextIndent' (pct 15) ]
                    ["textIndent" ==> "15%"]
                testCase
                    "Text indent hanging"
                    [ TextIndent.value (em 5.0, FssTypes.Text.Hanging;) ]
                    ["textIndent" ==> "5.0em hanging"]
                testCase
                    "Text indent each line"
                    [ TextIndent.value (em 5.0, FssTypes.Text.EachLine;) ]
                    ["textIndent" ==> "5.0em each-line"]
                testCase
                    "Text indent hanging each line"
                    [ TextIndent.value (em 5.0, FssTypes.Text.Hanging, FssTypes.Text.EachLine) ]
                    ["textIndent" ==> "5.0em hanging each-line"]
                testCase
                    "Text indent inherit"
                    [ TextIndent.inherit' ]
                    ["textIndent" ==> "inherit"]
                testCase
                    "Text indent Initial"
                    [ TextIndent.initial ]
                    ["textIndent" ==> "initial"]
                testCase
                    "Text indent unset"
                    [ TextIndent.unset ]
                    ["textIndent" ==> "unset"]
                testCase
                    "Text overflow clip"
                    [ TextOverflow.clip ]
                    ["textOverflow" ==> "clip"]
                testCase
                    "Text overflow ellipsis"
                    [ TextOverflow.ellipsis ]
                    ["textOverflow" ==> "ellipsis"]
                testCase
                    "Text overflow -"
                    [ TextOverflow' (FssTypes.CssString "-") ]
                    ["textOverflow" ==> "\"-\""]
                testCase
                    "Quotes none"
                    [ Quotes.none ]
                    ["quotes" ==> "none"]
                testCase
                    "Quotes Auto"
                    [ Quotes.auto ]
                    ["quotes" ==> "auto"]
                testCase
                    "Quotes strings"
                    [ Quotes.value(FssTypes.CssString "<<", FssTypes.CssString ">>") ]
                    ["quotes" ==> "\"<<\" \">>\""]
                testCase
                    "Quotes multiple"
                    [ Quotes.value [ FssTypes.CssString "<<" :> FssTypes.IQuotes, FssTypes.CssString ">>" :> FssTypes.IQuotes; FssTypes.CssString "<" :> FssTypes.IQuotes,  FssTypes.CssString ">" :> FssTypes.IQuotes] ]
                    ["quotes" ==> "\"<<\" \">>\" \"<\" \">\""]
                testCase
                    "Quotes inherit"
                    [ Quotes.inherit' ]
                    ["quotes" ==> "inherit"]
                testCase
                    "Quotes Initial"
                    [ Quotes.initial ]
                    ["quotes" ==> "initial"]
                testCase
                    "Quotes unset"
                    [ Quotes.unset ]
                    ["quotes" ==> "unset"]
                testCase
                    "Hyphens Manual"
                    [ Hyphens.manual ]
                    ["hyphens" ==> "manual"]
                testCase
                    "Hyphens none"
                    [ Hyphens.none ]
                    ["hyphens" ==> "none"]
                testCase
                    "Hyphens Auto"
                    [ Hyphens.auto ]
                    ["hyphens" ==> "auto"]
                testCase
                    "Hyphens inherit"
                    [ Hyphens.inherit' ]
                    ["hyphens" ==> "inherit"]
                testCase
                    "Hyphens Initial"
                    [ Hyphens.initial ]
                    ["hyphens" ==> "initial"]
                testCase
                    "Hyphens unset"
                    [ Hyphens.unset ]
                    ["hyphens" ==> "unset"]
                testCase
                    "TextSizeAdjust percent"
                    [ TextSizeAdjust' (pct 80) ]
                    ["textSizeAdjust" ==> "80%"]
                testCase
                    "TextSizeAdjust none"
                    [ TextSizeAdjust.none ]
                    ["textSizeAdjust" ==> "none"]
                testCase
                    "TextSizeAdjust Auto"
                    [ TextSizeAdjust.auto ]
                    ["textSizeAdjust" ==> "auto"]
                testCase
                    "TextSizeAdjust inherit"
                    [ TextSizeAdjust.inherit' ]
                    ["textSizeAdjust" ==> "inherit"]
                testCase
                    "TextSizeAdjust Initial"
                    [ TextSizeAdjust.initial ]
                    ["textSizeAdjust" ==> "initial"]
                testCase
                    "TextSizeAdjust unset"
                    [ TextSizeAdjust.unset ]
                    ["textSizeAdjust" ==> "unset"]
                testCase
                    "TabSize px"
                    [ TabSize' (px 10) ]
                    ["tabSize" ==> "10px"]
                testCase
                    "TabSize em"
                    [ TabSize' (em 2.) ]
                    ["tabSize" ==> "2.0em"]
                testCase
                    "TabSize number"
                    [ TabSize' (FssTypes.CssInt 4) ]
                    ["tabSize" ==> "4"]
                testCase
                    "TabSize inherit"
                    [ TabSize.inherit' ]
                    ["tabSize" ==> "inherit"]
                testCase
                    "TabSize Initial"
                    [ TabSize.initial ]
                    ["tabSize" ==> "initial"]
                testCase
                    "TabSize unset"
                    [ TabSize.unset ]
                    ["tabSize" ==> "unset"]
                testCase
                    "TextOrientation Mixed"
                    [ TextOrientation.mixed ]
                    ["textOrientation" ==> "mixed"]
                testCase
                    "TextOrientation Upright"
                    [ TextOrientation.upright ]
                    ["textOrientation" ==> "upright"]
                testCase
                    "TextOrientation sideways-right"
                    [ TextOrientation.sidewaysRight ]
                    ["textOrientation" ==> "sideways-right"]
                testCase
                    "TextOrientation Sideways"
                    [ TextOrientation.sideways ]
                    ["textOrientation" ==> "sideways"]
                testCase
                    "TextOrientation use-glyph-orientation"
                    [ TextOrientation.useGlyphOrientation ]
                    ["textOrientation" ==> "use-glyph-orientation"]
                testCase
                    "TextOrientation inherit"
                    [ TextOrientation.inherit' ]
                    ["textOrientation" ==> "inherit"]
                testCase
                    "TextOrientation Initial"
                    [ TextOrientation.initial ]
                    ["textOrientation" ==> "initial"]
                testCase
                    "TextOrientation unset"
                    [ TextOrientation.unset ]
                    ["textOrientation" ==> "unset"]
                testCase
                    "TextRendering optimize speed"
                    [ TextRendering.optimizeSpeed ]
                    ["textRendering" ==> "optimize-speed"]
                testCase
                    "TextRendering optimize legibility"
                    [ TextRendering.optimizeLegibility ]
                    ["textRendering" ==> "optimize-legibility"]
                testCase
                    "TextRendering geometric precision"
                    [ TextRendering.geometricPrecision ]
                    ["textRendering" ==> "geometric-precision"]
                testCase
                    "TextRendering auto"
                    [ TextRendering.auto ]
                    ["textRendering" ==> "auto"]
                testCase
                    "TextRendering inherit"
                    [ TextRendering.inherit' ]
                    ["textRendering" ==> "inherit"]
                testCase
                    "TextRendering Initial"
                    [ TextRendering.initial ]
                    ["textRendering" ==> "initial"]
                testCase
                    "TextRendering unset"
                    [ TextRendering.unset ]
                    ["textRendering" ==> "unset"]
                testCase
                    "TextJustify inter-character"
                    [ TextJustify.interCharacter ]
                    ["textJustify" ==> "inter-character"]
                testCase
                    "TextJustify inter-word"
                    [ TextJustify.interWord ]
                    ["textJustify" ==> "inter-word"]
                testCase
                    "TextJustify auto"
                    [ TextJustify.auto ]
                    ["textJustify" ==> "auto"]
                testCase
                    "TextJustify none"
                    [ TextJustify.none ]
                    ["textJustify" ==> "none"]
                testCase
                    "WhiteSpace nowrap"
                    [ WhiteSpace.noWrap ]
                    ["whiteSpace" ==> "no-wrap"]
                testCase
                    "WhiteSpace pre"
                    [ WhiteSpace.pre ]
                    ["whiteSpace" ==> "pre"]
                testCase
                    "WhiteSpace pre-wrap"
                    [ WhiteSpace.preWrap ]
                    ["whiteSpace" ==> "pre-wrap"]
                testCase
                    "WhiteSpace pre-line"
                    [ WhiteSpace.preLine ]
                    ["whiteSpace" ==> "pre-line"]
                testCase
                    "WhiteSpace break-spaces"
                    [ WhiteSpace.breakSpaces ]
                    ["whiteSpace" ==> "break-spaces"]
                testCase
                    "WhiteSpace normal"
                    [ WhiteSpace.normal ]
                    ["whiteSpace" ==> "normal"]
                testCase
                    "WhiteSpace inherit"
                    [ WhiteSpace.inherit' ]
                    ["whiteSpace" ==> "inherit"]
                testCase
                    "WhiteSpace Initial"
                    [ WhiteSpace.initial ]
                    ["whiteSpace" ==> "initial"]
                testCase
                    "WhiteSpace unset"
                    [ WhiteSpace.unset ]
                    ["whiteSpace" ==> "unset"]
                testCase
                    "UserSelect text"
                    [ UserSelect.text ]
                    ["userSelect" ==> "text"]
                testCase
                    "UserSelect Contain"
                    [ UserSelect.contain ]
                    ["userSelect" ==> "contain"]
                testCase
                    "UserSelect all"
                    [ UserSelect.all ]
                    ["userSelect" ==> "all"]
                testCase
                    "UserSelect none"
                    [ UserSelect.none ]
                    ["userSelect" ==> "none"]
                testCase
                    "UserSelect auto"
                    [ UserSelect.auto ]
                    ["userSelect" ==> "auto"]
                testCase
                    "UserSelect inherit"
                    [ UserSelect.inherit' ]
                    ["userSelect" ==> "inherit"]
                testCase
                    "UserSelect Initial"
                    [ UserSelect.initial ]
                    ["userSelect" ==> "initial"]
                testCase
                    "UserSelect unset"
                    [ UserSelect.unset ]
                    ["userSelect" ==> "unset"]
                testCase
                    "HangingPunctuation first"
                    [ HangingPunctuation.first ]
                    ["hangingPunctuation" ==> "first"]
                testCase
                    "HangingPunctuation last"
                    [ HangingPunctuation.last ]
                    ["hangingPunctuation" ==> "last"]
                testCase
                    "HangingPunctuation ForceEnd"
                    [ HangingPunctuation.forceEnd ]
                    ["hangingPunctuation" ==> "force-end"]
                testCase
                    "HangingPunctuation allowEnd"
                    [ HangingPunctuation.allowEnd ]
                    ["hangingPunctuation" ==> "allow-end"]
                testCase
                    "HangingPunctuation first force-end"
                    [ HangingPunctuation.value(FssTypes.Text.First, FssTypes.Text.ForceEnd)]
                    ["hangingPunctuation" ==> "first force-end"]
                testCase
                    "HangingPunctuation first allow-end"
                    [ HangingPunctuation.value(FssTypes.Text.First, FssTypes.Text.AllowEnd)]
                    ["hangingPunctuation" ==> "first allow-end"]
                testCase
                    "HangingPunctuation first last"
                    [ HangingPunctuation.value(FssTypes.Text.First, FssTypes.Text.Last)]
                    ["hangingPunctuation" ==> "first last"]
                testCase
                    "HangingPunctuation last force-end"
                    [ HangingPunctuation.value(FssTypes.Text.Last, FssTypes.Text.ForceEnd)]
                    ["hangingPunctuation" ==> "last force-end"]
                testCase
                    "HangingPunctuation last allow-end"
                    [ HangingPunctuation.value(FssTypes.Text.Last, FssTypes.Text.AllowEnd)]
                    ["hangingPunctuation" ==> "last allow-end"]
                testCase
                    "HangingPunctuation first force-end"
                    [ HangingPunctuation.value(FssTypes.Text.First, FssTypes.Text.ForceEnd, FssTypes.Text.Last)]
                    ["hangingPunctuation" ==> "first force-end last"]
                testCase
                    "HangingPunctuation last allow-end"
                    [ HangingPunctuation.value(FssTypes.Text.First, FssTypes.Text.AllowEnd, FssTypes.Text.Last)]
                    ["hangingPunctuation" ==> "first allow-end last"]
                testCase
                    "HangingPunctuation none"
                    [ HangingPunctuation.none ]
                    ["hangingPunctuation" ==> "none"]
                testCase
                    "HangingPunctuation inherit"
                    [ HangingPunctuation.inherit' ]
                    ["hangingPunctuation" ==> "inherit"]
                testCase
                    "HangingPunctuation Initial"
                    [ HangingPunctuation.initial ]
                    ["hangingPunctuation" ==> "initial"]
                testCase
                    "HangingPunctuation unset"
                    [ HangingPunctuation.unset ]
                    ["hangingPunctuation" ==> "unset"]
            ]