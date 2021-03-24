namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Text =
    let tests =
        testList "Text"
            [
                test
                    "Text decoration none"
                    [TextDecoration.none]
                    ["textDecoration" ==> "none"]
                test
                    "Text emphasis none"
                    [TextEmphasis.none]
                    ["textEmphasis" ==> "none"]
                test
                    "Text emphasis inherit"
                    [ TextEmphasis.inherit' ]
                    ["textEmphasis" ==> "inherit"]
                test
                    "Text emphasis initial"
                    [ TextEmphasis.initial ]
                    ["textEmphasis" ==> "initial"]
                test
                    "Text emphasis unset"
                    [ TextEmphasis.unset ]
                    ["textEmphasis" ==> "unset"]
                test
                    "Text align left"
                    [ TextAlign.left ]
                    ["textAlign" ==> "left"]
                test
                    "Text align right"
                    [ TextAlign.right ]
                    ["textAlign" ==> "right"]
                test
                    "Text align center"
                    [ TextAlign.center ]
                    ["textAlign" ==> "center"]
                test
                    "Text align justify"
                    [ TextAlign.justify ]
                    ["textAlign" ==> "justify"]
                test
                    "Text align justify all"
                    [ TextAlign.justifyAll ]
                    ["textAlign" ==> "justify-all"]
                test
                    "Text align start"
                    [ TextAlign.start ]
                    ["textAlign" ==> "start"]
                test
                    "Text align end"
                    [ TextAlign.end' ]
                    ["textAlign" ==> "end"]
                test
                    "Text align match-parent"
                    [ TextAlign.matchParent ]
                    ["textAlign" ==> "match-parent"]
                test
                    "Text align inherit"
                    [ TextAlign.inherit' ]
                    ["textAlign" ==> "inherit"]
                test
                    "Text align initial"
                    [ TextAlign.initial ]
                    ["textAlign" ==> "initial"]
                test
                    "Text align unset"
                    [ TextAlign.unset ]
                    ["textAlign" ==> "unset"]
                test
                    "Text align last left"
                    [ TextAlignLast.left ]
                    ["textAlignLast" ==> "left"]
                test
                    "Text align last right"
                    [ TextAlignLast.right ]
                    ["textAlignLast" ==> "right"]
                test
                    "Text align last center"
                    [ TextAlignLast.center ]
                    ["textAlignLast" ==> "center"]
                test
                    "Text align last justify"
                    [ TextAlignLast.justify ]
                    ["textAlignLast" ==> "justify"]
                test
                    "Text align last start"
                    [ TextAlignLast.start ]
                    ["textAlignLast" ==> "start"]
                test
                    "Text align last end"
                    [ TextAlignLast.end' ]
                    ["textAlignLast" ==> "end"]
                test
                    "Text align last inherit"
                    [ TextAlignLast.inherit' ]
                    ["textAlignLast" ==> "inherit"]
                test
                    "Text align last initial"
                    [ TextAlignLast.initial ]
                    ["textAlignLast" ==> "initial"]
                test
                    "Text align last unset"
                    [ TextAlignLast.unset ]
                    ["textAlignLast" ==> "unset"]
                test
                    "Text decoration color red"
                    [TextDecorationColor.red]
                    ["textDecorationColor" ==> "#ff0000"]
                test
                    "Text decoration color hex"
                    [TextDecorationColor.hex "00ff00" ]
                    ["textDecorationColor" ==> "#00ff00" ]
                test
                    "Text decoration color rgba"
                    [TextDecorationColor.rgba 255 128 128 0.5 ]
                    ["textDecorationColor" ==> "rgba(255, 128, 128, 0.500000)"]
                test
                    "Text decoration color transparent"
                    [TextDecorationColor.transparent]
                    ["textDecorationColor" ==> "rgba(0, 0, 0, 0.000000)"]
                test
                    "Text decoration color inherit"
                    [TextDecorationColor.inherit']
                    ["textDecorationColor" ==> "inherit"]
                test
                    "Text decoration color initial"
                    [TextDecorationColor.initial]
                    ["textDecorationColor" ==> "initial"]
                test
                    "Text decoration color unset"
                    [TextDecorationColor.unset]
                    ["textDecorationColor" ==> "unset"]
                test
                    "Text decoration line none"
                    [TextDecorationLine.none]
                    ["textDecorationLine" ==> "none"]
                test
                    "Text decoration line underline"
                    [TextDecorationLine.underline]
                    ["textDecorationLine" ==> "underline"]
                test
                    "Text decoration line overline"
                    [TextDecorationLine.overline]
                    ["textDecorationLine" ==> "overline"]
                test
                    "Text decoration line line-through"
                    [TextDecorationLine.lineThrough]
                    ["textDecorationLine" ==> "line-through"]
                test
                    "Text decoration line blink"
                    [TextDecorationLine.blink]
                    ["textDecorationLine" ==> "blink"]
                test
                    "Text decoration line inherit"
                    [ TextDecorationLine.inherit' ]
                    ["textDecorationLine" ==> "inherit"]
                test
                    "Text decoration line initial"
                    [ TextDecorationLine.initial ]
                    ["textDecorationLine" ==> "initial"]
                test
                    "Text decoration line unset"
                    [ TextDecorationLine.unset ]
                    ["textDecorationLine" ==> "unset"]
                test
                    "Text decorations multiple"
                    [TextDecorationLine.value(FssTypes.Text.DecorationLine.Overline, FssTypes.Text.DecorationLine.Underline, FssTypes.Text.DecorationLine.LineThrough)]
                    ["textDecorationLine" ==> "overline underline line-through"]
                test
                    "Text decoration skip none"
                    [TextDecorationSkip.none]
                    ["textDecorationSkip" ==> "none"]
                test
                    "Text decoration skip objects"
                    [TextDecorationSkip.objects]
                    ["textDecorationSkip" ==> "objects"]
                test
                    "Text decoration skip spaces"
                    [TextDecorationSkip.spaces]
                    ["textDecorationSkip" ==> "spaces"]
                test
                    "Text decoration skip edges"
                    [TextDecorationSkip.edges]
                    ["textDecorationSkip" ==> "edges"]
                test
                    "Text decoration skip box-decoration"
                    [TextDecorationSkip.boxDecoration]
                    ["textDecorationSkip" ==> "box-decoration"]
                test
                    "Text decoration skip multiple - objects and spaces"
                    [TextDecorationSkip.value(FssTypes.Text.DecorationSkip.Objects, FssTypes.Text.DecorationSkip.Spaces) ]
                    ["textDecorationSkip" ==> "objects spaces"]
                test
                    "Text decoration skip multiple - leading spaces and trailing spaces"
                    [TextDecorationSkip.value(FssTypes.Text.DecorationSkip.LeadingSpaces, FssTypes.Text.DecorationSkip.TrailingSpaces)]
                    ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]
                test
                    "Text decoration skip multiple - objects edges box-decoration"
                    [TextDecorationSkip.value(FssTypes.Text.DecorationSkip.Objects, FssTypes.Text.DecorationSkip.Edges, FssTypes.Text.DecorationSkip.BoxDecoration) ]
                    ["textDecorationSkip" ==> "objects edges box-decoration"]
                test
                    "Text decoration skip inherit"
                    [TextDecorationSkip.inherit']
                    ["textDecorationSkip" ==> "inherit"]
                test
                    "Text decoration skip initial"
                    [TextDecorationSkip.initial]
                    ["textDecorationSkip" ==> "initial"]
                test
                    "Text decoration skip unset"
                    [TextDecorationSkip.unset]
                    ["textDecorationSkip" ==> "unset"]
                test
                    "Text decoration skip unset"
                    [TextDecorationSkipInk.auto]
                    ["textDecorationSkipInk" ==> "auto"]
                test
                    "Text decoration skip All"
                    [TextDecorationSkipInk.all]
                    ["textDecorationSkipInk" ==> "all"]
                test
                    "Text decoration skip none"
                    [TextDecorationSkipInk.none]
                    ["textDecorationSkipInk" ==> "none"]
                test
                    "Text decoration skipink inherit"
                    [TextDecorationSkipInk.inherit']
                    ["textDecorationSkipInk" ==> "inherit"]
                test
                    "Text decoration skipink unset"
                    [TextDecorationSkipInk.unset]
                    ["textDecorationSkipInk" ==> "unset"]
                test
                    "Text decoration skipink initial"
                    [TextDecorationSkipInk.initial]
                    ["textDecorationSkipInk" ==> "initial"]
                test
                    "Text decoration style solid"
                    [TextDecorationStyle.solid]
                    ["textDecorationStyle" ==> "solid"]
                test
                    "Text decoration style double"
                    [TextDecorationStyle.double]
                    ["textDecorationStyle" ==> "double"]
                test
                    "Text decoration style dotted"
                    [TextDecorationStyle.dotted]
                    ["textDecorationStyle" ==> "dotted"]
                test
                    "Text decoration style dashed"
                    [TextDecorationStyle.dashed]
                    ["textDecorationStyle" ==> "dashed"]
                test
                    "Text decoration style wavy"
                    [TextDecorationStyle.wavy]
                    ["textDecorationStyle" ==> "wavy"]
                test
                    "Text decoration style inherit"
                    [TextDecorationStyle.inherit']
                    ["textDecorationStyle" ==> "inherit"]
                test
                    "Text decoration style initial"
                    [TextDecorationStyle.initial]
                    ["textDecorationStyle" ==> "initial"]
                test
                    "Text decoration style unset"
                    [TextDecorationStyle.unset]
                    ["textDecorationStyle" ==> "unset"]
                test
                    "Text decoration thickness auto"
                    [ TextDecorationThickness.auto ]
                    [ "textDecorationThickness" ==> "auto" ]
                test
                    "Text decoration thickness from font"
                    [ TextDecorationThickness.fromFont ]
                    ["textDecorationThickness" ==> "from-font" ]
                test
                    "Text decoration thickness em"
                    [ TextDecorationThickness' (em 0.1) ]
                    ["textDecorationThickness" ==> "0.1em" ]
                test
                    "Text decoration thickness px"
                    [ TextDecorationThickness' (px 3) ]
                    ["textDecorationThickness" ==> "3px" ]
                test
                    "Text decoration thickness percent"
                    [ TextDecorationThickness' (pct 10) ]
                    ["textDecorationThickness" ==> "10%" ]
                test
                    "Text decoration thickness inherit"
                    [ TextDecorationThickness.inherit' ]
                    ["textDecorationThickness" ==> "inherit" ]
                test
                    "Text decoration thickness initial"
                    [ TextDecorationThickness.initial ]
                    ["textDecorationThickness" ==> "initial" ]
                test
                    "Text decoration thickness unset"
                    [ TextDecorationThickness.unset ]
                    ["textDecorationThickness" ==> "unset" ]
                test
                    "Text emphasis color hex"
                    [ TextEmphasisColor.hex "#555" ]
                    ["textEmphasisColor" ==> "#555"]
                test
                    "Text emphasis color color name"
                    [ TextEmphasisColor.blue ]
                    ["textEmphasisColor" ==> "#0000ff"]
                test
                    "Text emphasis color rgba"
                    [ TextEmphasisColor.rgba 90 200 160 0.8 ]
                    ["textEmphasisColor" ==> "rgba(90, 200, 160, 0.800000)"]
                test
                    "Text emphasis color transparent"
                    [ TextEmphasisColor.transparent ]
                    ["textEmphasisColor" ==> "rgba(0, 0, 0, 0.000000)"]
                test
                    "Text emphasis color inherit"
                    [ TextEmphasisColor.inherit' ]
                    ["textEmphasisColor" ==> "inherit"]
                test
                    "Text emphasis color Initial"
                    [ TextEmphasisColor.initial ]
                    ["textEmphasisColor" ==> "initial"]
                test
                    "Text emphasis color unset"
                    [ TextEmphasisColor.unset ]
                    ["textEmphasisColor" ==> "unset"]
                test
                    "Text emphasis position over right"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Over, FssTypes.Text.EmphasisPosition.Right) ]
                    ["textEmphasisPosition" ==> "over right"]
                test
                    "Text emphasis position over left"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Over, FssTypes.Text.EmphasisPosition.Left) ]
                    ["textEmphasisPosition" ==> "over left"]
                test
                    "Text emphasis position under right"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Under, FssTypes.Text.EmphasisPosition.Right) ]
                    ["textEmphasisPosition" ==> "under right"]
                test
                    "Text emphasis position under left"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Under, FssTypes.Text.EmphasisPosition.Left) ]
                    ["textEmphasisPosition" ==> "under left"]
                test
                    "Text emphasis position left over"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Left, FssTypes.Text.EmphasisPosition.Over) ]
                    ["textEmphasisPosition" ==> "left over"]
                test
                    "Text emphasis position right under"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Right, FssTypes.Text.EmphasisPosition.Under) ]
                    ["textEmphasisPosition" ==> "right under"]
                test
                    "Text emphasis position left under"
                    [ TextEmphasisPosition.value (FssTypes.Text.EmphasisPosition.Left, FssTypes.Text.EmphasisPosition.Under) ]
                    ["textEmphasisPosition" ==> "left under"]
                test
                    "Text emphasis position inherit"
                    [ TextEmphasisPosition.inherit' ]
                    ["textEmphasisPosition" ==> "inherit"]
                test
                    "Text emphasis position Initial"
                    [ TextEmphasisPosition.initial ]
                    ["textEmphasisPosition" ==> "initial"]
                test
                    "Text emphasis position unset"
                    [ TextEmphasisPosition.unset ]
                    ["textEmphasisPosition" ==> "unset"]
                test
                    "Text Emphasis Style x"
                    [TextEmphasisStyle' (FssTypes.CssString "x")]
                    ["textEmphasisStyle" ==> "'x'"]
                test
                    "Text Emphasis Style *"
                    [TextEmphasisStyle' (FssTypes.CssString "*")]
                    ["textEmphasisStyle" ==> "'*'"]
                test
                    "Text Emphasis Style filled"
                    [TextEmphasisStyle.filled ]
                    ["textEmphasisStyle" ==> "filled"]
                test
                    "Text Emphasis Style open"
                    [TextEmphasisStyle.open']
                    ["textEmphasisStyle" ==> "open"]
                test
                    "Text Emphasis Style circle"
                    [TextEmphasisStyle.circle]
                    ["textEmphasisStyle" ==> "circle"]
                test
                    "Text Emphasis Style double circle"
                    [TextEmphasisStyle.doubleCircle]
                    ["textEmphasisStyle" ==> "double-circle"]
                test
                    "Text Emphasis Style triangle"
                    [TextEmphasisStyle.triangle]
                    ["textEmphasisStyle" ==> "triangle"]
                test
                    "Text Emphasis Style filled sesame"
                    [TextEmphasisStyle.filledSesame]
                    ["textEmphasisStyle" ==> "filled sesame"]
                test
                    "Text Emphasis Style open sesame"
                    [TextEmphasisStyle.openSesame]
                    ["textEmphasisStyle" ==> "open sesame"]
                test
                    "Text emphasis style inherit"
                    [ TextEmphasisStyle.inherit' ]
                    ["textEmphasisStyle" ==> "inherit"]
                test
                    "Text emphasis style Initial"
                    [ TextEmphasisStyle.initial ]
                    ["textEmphasisStyle" ==> "initial"]
                test
                    "Text emphasis style unset"
                    [ TextEmphasisStyle.unset ]
                    ["textEmphasisStyle" ==> "unset"]
                test
                    "Text shadow single"
                    [ TextShadows [ TextShadow.colorXyBlur (px 1, px 1, px 2, FssTypes.Color.black) ] ]
                    ["textShadow" ==> "#000000 1px 1px 2px"]
                test
                    "Text shadow multiple"
                    [ TextShadows
                          [ TextShadow.colorXyBlur(px 1, px 1, px 2, FssTypes.Color.black)
                            TextShadow.colorXyBlur(px 10, px -10, px 20, FssTypes.Color.red) ]
                    ]
                    ["textShadow" ==> "#000000 1px 1px 2px, #ff0000 10px -10px 20px"]
                test
                    "Text underline offset auto"
                    [ TextUnderlineOffset.auto ]
                    ["textUnderlineOffset" ==> "auto"]
                test
                    "Text underline offset em"
                    [ TextUnderlineOffset' (em 3.0) ]
                    ["textUnderlineOffset" ==> "3.0em"]
                test
                    "Text underline offset px"
                    [ TextUnderlineOffset' (px 10) ]
                    ["textUnderlineOffset" ==> "10px"]
                test
                    "Text underline offset percent"
                    [ TextUnderlineOffset' (pct 10) ]
                    ["textUnderlineOffset" ==> "10%"]
                test
                    "Text underline offset inherit"
                    [ TextUnderlineOffset.inherit' ]
                    ["textUnderlineOffset" ==> "inherit"]
                test
                    "Text underline offset Initial"
                    [ TextUnderlineOffset.initial ]
                    ["textUnderlineOffset" ==> "initial"]
                test
                    "Text underline offset unset"
                    [ TextUnderlineOffset.unset ]
                    ["textUnderlineOffset" ==> "unset"]
                test
                    "Text underline position from-font"
                    [ TextUnderlinePosition.fromFont ]
                    ["textUnderlinePosition" ==> "from-font"]
                test
                    "Text underline position Under"
                    [ TextUnderlinePosition.under ]
                    ["textUnderlinePosition" ==> "under"]
                test
                    "Text underline position left"
                    [ TextUnderlinePosition.left ]
                    ["textUnderlinePosition" ==> "left"]
                test
                    "Text underline position right"
                    [ TextUnderlinePosition.right ]
                    ["textUnderlinePosition" ==> "right"]
                test
                    "Text underline position auto-pos"
                    [ TextUnderlinePosition.autoPos ]
                    ["textUnderlinePosition" ==> "auto-pos"]
                test
                    "Text underline position above"
                    [ TextUnderlinePosition.above ]
                    ["textUnderlinePosition" ==> "above"]
                test
                    "Text underline position below"
                    [ TextUnderlinePosition.below ]
                    ["textUnderlinePosition" ==> "below"]
                test
                    "Text underline positions under left"
                    [ TextUnderlinePosition.value (FssTypes.Text.UnderlinePosition.Under, FssTypes.Text.UnderlinePosition.Left) ]
                    ["textUnderlinePosition" ==> "under left"]
                test
                    "Text underline positions right under"
                    [ TextUnderlinePosition.value (FssTypes.Text.UnderlinePosition.Right, FssTypes.Text.UnderlinePosition.Under) ]
                    ["textUnderlinePosition" ==> "right under"]
                test
                    "Text underline position auto"
                    [ TextUnderlinePosition.auto ]
                    ["textUnderlinePosition" ==> "auto"]
                test
                    "Text underline position inherit"
                    [ TextUnderlinePosition.inherit' ]
                    ["textUnderlinePosition" ==> "inherit"]
                test
                    "Text underline position Initial"
                    [ TextUnderlinePosition.initial ]
                    ["textUnderlinePosition" ==> "initial"]
                test
                    "Text underline position unset"
                    [ TextUnderlinePosition.unset ]
                    ["textUnderlinePosition" ==> "unset"]
                test
                    "Text indent mm"
                    [ TextIndent' (mm 3.0) ]
                    ["textIndent" ==> "3.0mm"]
                test
                    "Text indent px"
                    [ TextIndent' (px 40) ]
                    ["textIndent" ==> "40px"]
                test
                    "Text indent percent"
                    [ TextIndent' (pct 15) ]
                    ["textIndent" ==> "15%"]
                test
                    "Text indent hanging"
                    [ TextIndent.value (em 5.0, FssTypes.Text.Hanging;) ]
                    ["textIndent" ==> "5.0em hanging"]
                test
                    "Text indent each line"
                    [ TextIndent.value (em 5.0, FssTypes.Text.EachLine;) ]
                    ["textIndent" ==> "5.0em each-line"]
                test
                    "Text indent hanging each line"
                    [ TextIndent.value (em 5.0, FssTypes.Text.Hanging, FssTypes.Text.EachLine) ]
                    ["textIndent" ==> "5.0em hanging each-line"]
                test
                    "Text indent inherit"
                    [ TextIndent.inherit' ]
                    ["textIndent" ==> "inherit"]
                test
                    "Text indent Initial"
                    [ TextIndent.initial ]
                    ["textIndent" ==> "initial"]
                test
                    "Text indent unset"
                    [ TextIndent.unset ]
                    ["textIndent" ==> "unset"]
                test
                    "Text overflow clip"
                    [ TextOverflow.clip ]
                    ["textOverflow" ==> "clip"]
                test
                    "Text overflow ellipsis"
                    [ TextOverflow.ellipsis ]
                    ["textOverflow" ==> "ellipsis"]
                test
                    "Text overflow -"
                    [ TextOverflow' (FssTypes.CssString "-") ]
                    ["textOverflow" ==> "\"-\""]
                test
                    "Quotes none"
                    [ Quotes.none ]
                    ["quotes" ==> "none"]
                test
                    "Quotes Auto"
                    [ Quotes.auto ]
                    ["quotes" ==> "auto"]
                test
                    "Quotes strings"
                    [ Quotes.value(FssTypes.CssString "<<", FssTypes.CssString ">>") ]
                    ["quotes" ==> "\"<<\" \">>\""]
                test
                    "Quotes multiple"
                    [ Quotes.value [ FssTypes.CssString "<<" :> FssTypes.IQuotes, FssTypes.CssString ">>" :> FssTypes.IQuotes; FssTypes.CssString "<" :> FssTypes.IQuotes,  FssTypes.CssString ">" :> FssTypes.IQuotes] ]
                    ["quotes" ==> "\"<<\" \">>\" \"<\" \">\""]
                test
                    "Quotes inherit"
                    [ Quotes.inherit' ]
                    ["quotes" ==> "inherit"]
                test
                    "Quotes Initial"
                    [ Quotes.initial ]
                    ["quotes" ==> "initial"]
                test
                    "Quotes unset"
                    [ Quotes.unset ]
                    ["quotes" ==> "unset"]
                test
                    "Hyphens Manual"
                    [ Hyphens.manual ]
                    ["hyphens" ==> "manual"]
                test
                    "Hyphens none"
                    [ Hyphens.none ]
                    ["hyphens" ==> "none"]
                test
                    "Hyphens Auto"
                    [ Hyphens.auto ]
                    ["hyphens" ==> "auto"]
                test
                    "Hyphens inherit"
                    [ Hyphens.inherit' ]
                    ["hyphens" ==> "inherit"]
                test
                    "Hyphens Initial"
                    [ Hyphens.initial ]
                    ["hyphens" ==> "initial"]
                test
                    "Hyphens unset"
                    [ Hyphens.unset ]
                    ["hyphens" ==> "unset"]
                test
                    "TextSizeAdjust percent"
                    [ TextSizeAdjust' (pct 80) ]
                    ["textSizeAdjust" ==> "80%"]
                test
                    "TextSizeAdjust none"
                    [ TextSizeAdjust.none ]
                    ["textSizeAdjust" ==> "none"]
                test
                    "TextSizeAdjust Auto"
                    [ TextSizeAdjust.auto ]
                    ["textSizeAdjust" ==> "auto"]
                test
                    "TextSizeAdjust inherit"
                    [ TextSizeAdjust.inherit' ]
                    ["textSizeAdjust" ==> "inherit"]
                test
                    "TextSizeAdjust Initial"
                    [ TextSizeAdjust.initial ]
                    ["textSizeAdjust" ==> "initial"]
                test
                    "TextSizeAdjust unset"
                    [ TextSizeAdjust.unset ]
                    ["textSizeAdjust" ==> "unset"]
                test
                    "TabSize px"
                    [ TabSize' (px 10) ]
                    ["tabSize" ==> "10px"]
                test
                    "TabSize em"
                    [ TabSize' (em 2.) ]
                    ["tabSize" ==> "2.0em"]
                test
                    "TabSize number"
                    [ TabSize' (FssTypes.CssInt 4) ]
                    ["tabSize" ==> "4"]
                test
                    "TabSize inherit"
                    [ TabSize.inherit' ]
                    ["tabSize" ==> "inherit"]
                test
                    "TabSize Initial"
                    [ TabSize.initial ]
                    ["tabSize" ==> "initial"]
                test
                    "TabSize unset"
                    [ TabSize.unset ]
                    ["tabSize" ==> "unset"]
                test
                    "TextOrientation Mixed"
                    [ TextOrientation.mixed ]
                    ["textOrientation" ==> "mixed"]
                test
                    "TextOrientation Upright"
                    [ TextOrientation.upright ]
                    ["textOrientation" ==> "upright"]
                test
                    "TextOrientation sideways-right"
                    [ TextOrientation.sidewaysRight ]
                    ["textOrientation" ==> "sideways-right"]
                test
                    "TextOrientation Sideways"
                    [ TextOrientation.sideways ]
                    ["textOrientation" ==> "sideways"]
                test
                    "TextOrientation use-glyph-orientation"
                    [ TextOrientation.useGlyphOrientation ]
                    ["textOrientation" ==> "use-glyph-orientation"]
                test
                    "TextOrientation inherit"
                    [ TextOrientation.inherit' ]
                    ["textOrientation" ==> "inherit"]
                test
                    "TextOrientation Initial"
                    [ TextOrientation.initial ]
                    ["textOrientation" ==> "initial"]
                test
                    "TextOrientation unset"
                    [ TextOrientation.unset ]
                    ["textOrientation" ==> "unset"]
                test
                    "TextRendering optimize speed"
                    [ TextRendering.optimizeSpeed ]
                    ["textRendering" ==> "optimize-speed"]
                test
                    "TextRendering optimize legibility"
                    [ TextRendering.optimizeLegibility ]
                    ["textRendering" ==> "optimize-legibility"]
                test
                    "TextRendering geometric precision"
                    [ TextRendering.geometricPrecision ]
                    ["textRendering" ==> "geometric-precision"]
                test
                    "TextRendering auto"
                    [ TextRendering.auto ]
                    ["textRendering" ==> "auto"]
                test
                    "TextRendering inherit"
                    [ TextRendering.inherit' ]
                    ["textRendering" ==> "inherit"]
                test
                    "TextRendering Initial"
                    [ TextRendering.initial ]
                    ["textRendering" ==> "initial"]
                test
                    "TextRendering unset"
                    [ TextRendering.unset ]
                    ["textRendering" ==> "unset"]
                test
                    "TextJustify inter-character"
                    [ TextJustify.interCharacter ]
                    ["textJustify" ==> "inter-character"]
                test
                    "TextJustify inter-word"
                    [ TextJustify.interWord ]
                    ["textJustify" ==> "inter-word"]
                test
                    "TextJustify auto"
                    [ TextJustify.auto ]
                    ["textJustify" ==> "auto"]
                test
                    "TextJustify none"
                    [ TextJustify.none ]
                    ["textJustify" ==> "none"]
                test
                    "WhiteSpace nowrap"
                    [ WhiteSpace.noWrap ]
                    ["whiteSpace" ==> "no-wrap"]
                test
                    "WhiteSpace pre"
                    [ WhiteSpace.pre ]
                    ["whiteSpace" ==> "pre"]
                test
                    "WhiteSpace pre-wrap"
                    [ WhiteSpace.preWrap ]
                    ["whiteSpace" ==> "pre-wrap"]
                test
                    "WhiteSpace pre-line"
                    [ WhiteSpace.preLine ]
                    ["whiteSpace" ==> "pre-line"]
                test
                    "WhiteSpace break-spaces"
                    [ WhiteSpace.breakSpaces ]
                    ["whiteSpace" ==> "break-spaces"]
                test
                    "WhiteSpace normal"
                    [ WhiteSpace.normal ]
                    ["whiteSpace" ==> "normal"]
                test
                    "WhiteSpace inherit"
                    [ WhiteSpace.inherit' ]
                    ["whiteSpace" ==> "inherit"]
                test
                    "WhiteSpace Initial"
                    [ WhiteSpace.initial ]
                    ["whiteSpace" ==> "initial"]
                test
                    "WhiteSpace unset"
                    [ WhiteSpace.unset ]
                    ["whiteSpace" ==> "unset"]
                test
                    "UserSelect text"
                    [ UserSelect.text ]
                    ["userSelect" ==> "text"]
                test
                    "UserSelect Contain"
                    [ UserSelect.contain ]
                    ["userSelect" ==> "contain"]
                test
                    "UserSelect all"
                    [ UserSelect.all ]
                    ["userSelect" ==> "all"]
                test
                    "UserSelect none"
                    [ UserSelect.none ]
                    ["userSelect" ==> "none"]
                test
                    "UserSelect auto"
                    [ UserSelect.auto ]
                    ["userSelect" ==> "auto"]
                test
                    "UserSelect inherit"
                    [ UserSelect.inherit' ]
                    ["userSelect" ==> "inherit"]
                test
                    "UserSelect Initial"
                    [ UserSelect.initial ]
                    ["userSelect" ==> "initial"]
                test
                    "UserSelect unset"
                    [ UserSelect.unset ]
                    ["userSelect" ==> "unset"]
            ]