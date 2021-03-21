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
                    [TextDecoration.None]
                    ["textDecoration" ==> "none"]
                test
                    "Text emphasis none"
                    [TextEmphasis.None]
                    ["textEmphasis" ==> "none"]
                test
                    "Text emphasis inherit"
                    [ TextEmphasis.Inherit ]
                    ["textEmphasis" ==> "inherit"]
                test
                    "Text emphasis initial"
                    [ TextEmphasis.Initial ]
                    ["textEmphasis" ==> "initial"]
                test
                    "Text emphasis unset"
                    [ TextEmphasis.Unset ]
                    ["textEmphasis" ==> "unset"]
                test
                    "Text align left"
                    [ TextAlign.Left ]
                    ["textAlign" ==> "left"]
                test
                    "Text align right"
                    [ TextAlign.Right ]
                    ["textAlign" ==> "right"]
                test
                    "Text align center"
                    [ TextAlign.Center ]
                    ["textAlign" ==> "center"]
                test
                    "Text align justify"
                    [ TextAlign.Justify ]
                    ["textAlign" ==> "justify"]
                test
                    "Text align justify all"
                    [ TextAlign.JustifyAll ]
                    ["textAlign" ==> "justify-all"]
                test
                    "Text align start"
                    [ TextAlign.Start ]
                    ["textAlign" ==> "start"]
                test
                    "Text align end"
                    [ TextAlign.End ]
                    ["textAlign" ==> "end"]
                test
                    "Text align match-parent"
                    [ TextAlign.MatchParent ]
                    ["textAlign" ==> "match-parent"]
                test
                    "Text align inherit"
                    [ TextAlign.Inherit ]
                    ["textAlign" ==> "inherit"]
                test
                    "Text align initial"
                    [ TextAlign.Initial ]
                    ["textAlign" ==> "initial"]
                test
                    "Text align unset"
                    [ TextAlign.Unset ]
                    ["textAlign" ==> "unset"]
                test
                    "Text align last left"
                    [ TextAlignLast.Left ]
                    ["textAlignLast" ==> "left"]
                test
                    "Text align last right"
                    [ TextAlignLast.Right ]
                    ["textAlignLast" ==> "right"]
                test
                    "Text align last center"
                    [ TextAlignLast.Center ]
                    ["textAlignLast" ==> "center"]
                test
                    "Text align last justify"
                    [ TextAlignLast.Justify ]
                    ["textAlignLast" ==> "justify"]
                test
                    "Text align last start"
                    [ TextAlignLast.Start ]
                    ["textAlignLast" ==> "start"]
                test
                    "Text align last end"
                    [ TextAlignLast.End ]
                    ["textAlignLast" ==> "end"]
                test
                    "Text align last inherit"
                    [ TextAlignLast.Inherit ]
                    ["textAlignLast" ==> "inherit"]
                test
                    "Text align last initial"
                    [ TextAlignLast.Initial ]
                    ["textAlignLast" ==> "initial"]
                test
                    "Text align last unset"
                    [ TextAlignLast.Unset ]
                    ["textAlignLast" ==> "unset"]
                test
                    "Text decoration color red"
                    [TextDecorationColor.red]
                    ["textDecorationColor" ==> "#ff0000"]
                test
                    "Text decoration color hex"
                    [TextDecorationColor.Hex "00ff00" ]
                    ["textDecorationColor" ==> "#00ff00" ]
                test
                    "Text decoration color rgba"
                    [TextDecorationColor.Rgba 255 128 128 0.5 ]
                    ["textDecorationColor" ==> "rgba(255, 128, 128, 0.500000)"]
                test
                    "Text decoration color transparent"
                    [TextDecorationColor.transparent]
                    ["textDecorationColor" ==> "rgba(0, 0, 0, 0.000000)"]
                test
                    "Text decoration color inherit"
                    [TextDecorationColor.Inherit]
                    ["textDecorationColor" ==> "inherit"]
                test
                    "Text decoration color initial"
                    [TextDecorationColor.Initial]
                    ["textDecorationColor" ==> "initial"]
                test
                    "Text decoration color unset"
                    [TextDecorationColor.Unset]
                    ["textDecorationColor" ==> "unset"]
                test
                    "Text decoration line none"
                    [TextDecorationLine.None]
                    ["textDecorationLine" ==> "none"]
                test
                    "Text decoration line underline"
                    [TextDecorationLine.Underline]
                    ["textDecorationLine" ==> "underline"]
                test
                    "Text decoration line overline"
                    [TextDecorationLine.Overline]
                    ["textDecorationLine" ==> "overline"]
                test
                    "Text decoration line line-through"
                    [TextDecorationLine.LineThrough]
                    ["textDecorationLine" ==> "line-through"]
                test
                    "Text decoration line blink"
                    [TextDecorationLine.Blink]
                    ["textDecorationLine" ==> "blink"]
                test
                    "Text decoration line inherit"
                    [ TextDecorationLine.Inherit ]
                    ["textDecorationLine" ==> "inherit"]
                test
                    "Text decoration line initial"
                    [ TextDecorationLine.Initial ]
                    ["textDecorationLine" ==> "initial"]
                test
                    "Text decoration line unset"
                    [ TextDecorationLine.Unset ]
                    ["textDecorationLine" ==> "unset"]
                test
                    "Text decorations multiple"
                    [TextDecorationLine.Value(Types.Overline, Types.Underline, Types.LineThrough)]
                    ["textDecorationLine" ==> "overline underline line-through"]
                test
                    "Text decoration skip none"
                    [TextDecorationSkip.None]
                    ["textDecorationSkip" ==> "none"]
                test
                    "Text decoration skip objects"
                    [TextDecorationSkip.Objects]
                    ["textDecorationSkip" ==> "objects"]
                test
                    "Text decoration skip spaces"
                    [TextDecorationSkip.Spaces]
                    ["textDecorationSkip" ==> "spaces"]
                test
                    "Text decoration skip edges"
                    [TextDecorationSkip.Edges]
                    ["textDecorationSkip" ==> "edges"]
                test
                    "Text decoration skip box-decoration"
                    [TextDecorationSkip.BoxDecoration]
                    ["textDecorationSkip" ==> "box-decoration"]
                test
                    "Text decoration skip multiple - objects and spaces"
                    [TextDecorationSkip.Value(Types.Objects, Types.Spaces) ]
                    ["textDecorationSkip" ==> "objects spaces"]
                test
                    "Text decoration skip multiple - leading spaces and trailing spaces"
                    [TextDecorationSkip.Value(Types.LeadingSpaces, Types.TrailingSpaces)]
                    ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]
                test
                    "Text decoration skip multiple - objects edges box-decoration"
                    [TextDecorationSkip.Value(Types.Objects, Types.Edges, Types.BoxDecoration) ]
                    ["textDecorationSkip" ==> "objects edges box-decoration"]
                test
                    "Text decoration skip inherit"
                    [TextDecorationSkip.Inherit]
                    ["textDecorationSkip" ==> "inherit"]
                test
                    "Text decoration skip initial"
                    [TextDecorationSkip.Initial]
                    ["textDecorationSkip" ==> "initial"]
                test
                    "Text decoration skip unset"
                    [TextDecorationSkip.Unset]
                    ["textDecorationSkip" ==> "unset"]
                test
                    "Text decoration skip unset"
                    [TextDecorationSkipInk.Auto]
                    ["textDecorationSkipInk" ==> "auto"]
                test
                    "Text decoration skip All"
                    [TextDecorationSkipInk.All]
                    ["textDecorationSkipInk" ==> "all"]
                test
                    "Text decoration skip none"
                    [TextDecorationSkipInk.None]
                    ["textDecorationSkipInk" ==> "none"]
                test
                    "Text decoration skipink inherit"
                    [TextDecorationSkipInk.Inherit]
                    ["textDecorationSkipInk" ==> "inherit"]
                test
                    "Text decoration skipink unset"
                    [TextDecorationSkipInk.Unset]
                    ["textDecorationSkipInk" ==> "unset"]
                test
                    "Text decoration skipink initial"
                    [TextDecorationSkipInk.Initial]
                    ["textDecorationSkipInk" ==> "initial"]
                test
                    "Text decoration style solid"
                    [TextDecorationStyle.Solid]
                    ["textDecorationStyle" ==> "solid"]
                test
                    "Text decoration style double"
                    [TextDecorationStyle.Double]
                    ["textDecorationStyle" ==> "double"]
                test
                    "Text decoration style dotted"
                    [TextDecorationStyle.Dotted]
                    ["textDecorationStyle" ==> "dotted"]
                test
                    "Text decoration style dashed"
                    [TextDecorationStyle.Dashed]
                    ["textDecorationStyle" ==> "dashed"]
                test
                    "Text decoration style wavy"
                    [TextDecorationStyle.Wavy]
                    ["textDecorationStyle" ==> "wavy"]
                test
                    "Text decoration style inherit"
                    [TextDecorationStyle.Inherit]
                    ["textDecorationStyle" ==> "inherit"]
                test
                    "Text decoration style initial"
                    [TextDecorationStyle.Initial]
                    ["textDecorationStyle" ==> "initial"]
                test
                    "Text decoration style unset"
                    [TextDecorationStyle.Unset]
                    ["textDecorationStyle" ==> "unset"]
                test
                    "Text decoration thickness auto"
                    [ TextDecorationThickness.Auto ]
                    [ "textDecorationThickness" ==> "auto" ]
                test
                    "Text decoration thickness from font"
                    [ TextDecorationThickness.FromFont ]
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
                    [ TextDecorationThickness.Inherit ]
                    ["textDecorationThickness" ==> "inherit" ]
                test
                    "Text decoration thickness initial"
                    [ TextDecorationThickness.Initial ]
                    ["textDecorationThickness" ==> "initial" ]
                test
                    "Text decoration thickness unset"
                    [ TextDecorationThickness.Unset ]
                    ["textDecorationThickness" ==> "unset" ]
                test
                    "Text emphasis color hex"
                    [ TextEmphasisColor.Hex "#555" ]
                    ["textEmphasisColor" ==> "#555"]
                test
                    "Text emphasis color color name"
                    [ TextEmphasisColor.blue ]
                    ["textEmphasisColor" ==> "#0000ff"]
                test
                    "Text emphasis color rgba"
                    [ TextEmphasisColor.Rgba 90 200 160 0.8 ]
                    ["textEmphasisColor" ==> "rgba(90, 200, 160, 0.800000)"]
                test
                    "Text emphasis color transparent"
                    [ TextEmphasisColor.transparent ]
                    ["textEmphasisColor" ==> "rgba(0, 0, 0, 0.000000)"]
                test
                    "Text emphasis color inherit"
                    [ TextEmphasisColor.Inherit ]
                    ["textEmphasisColor" ==> "inherit"]
                test
                    "Text emphasis color Initial"
                    [ TextEmphasisColor.Initial ]
                    ["textEmphasisColor" ==> "initial"]
                test
                    "Text emphasis color unset"
                    [ TextEmphasisColor.Unset ]
                    ["textEmphasisColor" ==> "unset"]
                test
                    "Text emphasis position over right"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Over, Types.EmphasisPosition.Right) ]
                    ["textEmphasisPosition" ==> "over right"]
                test
                    "Text emphasis position over left"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Over, Types.EmphasisPosition.Left) ]
                    ["textEmphasisPosition" ==> "over left"]
                test
                    "Text emphasis position under right"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Under, Types.EmphasisPosition.Right) ]
                    ["textEmphasisPosition" ==> "under right"]
                test
                    "Text emphasis position under left"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Under, Types.EmphasisPosition.Left) ]
                    ["textEmphasisPosition" ==> "under left"]
                test
                    "Text emphasis position left over"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Left, Types.EmphasisPosition.Over) ]
                    ["textEmphasisPosition" ==> "left over"]
                test
                    "Text emphasis position right under"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Right, Types.EmphasisPosition.Under) ]
                    ["textEmphasisPosition" ==> "right under"]
                test
                    "Text emphasis position left under"
                    [ TextEmphasisPosition.Value (Types.EmphasisPosition.Left, Types.EmphasisPosition.Under) ]
                    ["textEmphasisPosition" ==> "left under"]
                test
                    "Text emphasis position inherit"
                    [ TextEmphasisPosition.Inherit ]
                    ["textEmphasisPosition" ==> "inherit"]
                test
                    "Text emphasis position Initial"
                    [ TextEmphasisPosition.Initial ]
                    ["textEmphasisPosition" ==> "initial"]
                test
                    "Text emphasis position unset"
                    [ TextEmphasisPosition.Unset ]
                    ["textEmphasisPosition" ==> "unset"]
                test
                    "Text Emphasis Style x"
                    [TextEmphasisStyle' (Types.CssString "x")]
                    ["textEmphasisStyle" ==> "'x'"]
                test
                    "Text Emphasis Style *"
                    [TextEmphasisStyle' (Types.CssString "*")]
                    ["textEmphasisStyle" ==> "'*'"]
                test
                    "Text Emphasis Style filled"
                    [TextEmphasisStyle.Filled ]
                    ["textEmphasisStyle" ==> "filled"]
                test
                    "Text Emphasis Style open"
                    [TextEmphasisStyle.Open]
                    ["textEmphasisStyle" ==> "open"]
                test
                    "Text Emphasis Style circle"
                    [TextEmphasisStyle.Circle]
                    ["textEmphasisStyle" ==> "circle"]
                test
                    "Text Emphasis Style double circle"
                    [TextEmphasisStyle.DoubleCircle]
                    ["textEmphasisStyle" ==> "double-circle"]
                test
                    "Text Emphasis Style triangle"
                    [TextEmphasisStyle.Triangle]
                    ["textEmphasisStyle" ==> "triangle"]
                test
                    "Text Emphasis Style filled sesame"
                    [TextEmphasisStyle.FilledSesame]
                    ["textEmphasisStyle" ==> "filled sesame"]
                test
                    "Text Emphasis Style open sesame"
                    [TextEmphasisStyle.OpenSesame]
                    ["textEmphasisStyle" ==> "open sesame"]
                test
                    "Text emphasis style inherit"
                    [ TextEmphasisStyle.Inherit ]
                    ["textEmphasisStyle" ==> "inherit"]
                test
                    "Text emphasis style Initial"
                    [ TextEmphasisStyle.Initial ]
                    ["textEmphasisStyle" ==> "initial"]
                test
                    "Text emphasis style unset"
                    [ TextEmphasisStyle.Unset ]
                    ["textEmphasisStyle" ==> "unset"]
                test
                    "Text shadow single"
                    [ TextShadows [ TextShadow.ColorXYBlur (px 1, px 1, px 2, Types.Color.black) ] ]
                    ["textShadow" ==> "#000000 1px 1px 2px"]
                test
                    "Text shadow multiple"
                    [ TextShadows
                          [ TextShadow.ColorXYBlur(px 1, px 1, px 2, Types.Color.black)
                            TextShadow.ColorXYBlur(px 10, px -10, px 20, Types.Color.red) ]
                    ]
                    ["textShadow" ==> "#000000 1px 1px 2px, #ff0000 10px -10px 20px"]
                test
                    "Text underline offset auto"
                    [ TextUnderlineOffset.Auto ]
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
                    [ TextUnderlineOffset.Inherit ]
                    ["textUnderlineOffset" ==> "inherit"]
                test
                    "Text underline offset Initial"
                    [ TextUnderlineOffset.Initial ]
                    ["textUnderlineOffset" ==> "initial"]
                test
                    "Text underline offset unset"
                    [ TextUnderlineOffset.Unset ]
                    ["textUnderlineOffset" ==> "unset"]
                test
                    "Text underline position from-font"
                    [ TextUnderlinePosition.FromFont ]
                    ["textUnderlinePosition" ==> "from-font"]
                test
                    "Text underline position Under"
                    [ TextUnderlinePosition.Under ]
                    ["textUnderlinePosition" ==> "under"]
                test
                    "Text underline position left"
                    [ TextUnderlinePosition.Left ]
                    ["textUnderlinePosition" ==> "left"]
                test
                    "Text underline position right"
                    [ TextUnderlinePosition.Right ]
                    ["textUnderlinePosition" ==> "right"]
                test
                    "Text underline position auto-pos"
                    [ TextUnderlinePosition.AutoPos ]
                    ["textUnderlinePosition" ==> "auto-pos"]
                test
                    "Text underline position above"
                    [ TextUnderlinePosition.Above ]
                    ["textUnderlinePosition" ==> "above"]
                test
                    "Text underline position below"
                    [ TextUnderlinePosition.Below ]
                    ["textUnderlinePosition" ==> "below"]
                test
                    "Text underline positions under left"
                    [ TextUnderlinePosition.Value (Types.UnderlinePosition.Under, Types.UnderlinePosition.Left) ]
                    ["textUnderlinePosition" ==> "under left"]
                test
                    "Text underline positions right under"
                    [ TextUnderlinePosition.Value (Types.UnderlinePosition.Right, Types.UnderlinePosition.Under) ]
                    ["textUnderlinePosition" ==> "right under"]
                test
                    "Text underline position auto"
                    [ TextUnderlinePosition.Auto ]
                    ["textUnderlinePosition" ==> "auto"]
                test
                    "Text underline position inherit"
                    [ TextUnderlinePosition.Inherit ]
                    ["textUnderlinePosition" ==> "inherit"]
                test
                    "Text underline position Initial"
                    [ TextUnderlinePosition.Initial ]
                    ["textUnderlinePosition" ==> "initial"]
                test
                    "Text underline position unset"
                    [ TextUnderlinePosition.Unset ]
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
                    [ TextIndent.Value (em 5.0, Types.Hanging;) ]
                    ["textIndent" ==> "5.0em hanging"]
                test
                    "Text indent each line"
                    [ TextIndent.Value (em 5.0, Types.EachLine;) ]
                    ["textIndent" ==> "5.0em each-line"]
                test
                    "Text indent hanging each line"
                    [ TextIndent.Value (em 5.0, Types.Hanging, Types.EachLine) ]
                    ["textIndent" ==> "5.0em hanging each-line"]
                test
                    "Text indent inherit"
                    [ TextIndent.Inherit ]
                    ["textIndent" ==> "inherit"]
                test
                    "Text indent Initial"
                    [ TextIndent.Initial ]
                    ["textIndent" ==> "initial"]
                test
                    "Text indent unset"
                    [ TextIndent.Unset ]
                    ["textIndent" ==> "unset"]
                test
                    "Text overflow clip"
                    [ TextOverflow.Clip ]
                    ["textOverflow" ==> "clip"]
                test
                    "Text overflow ellipsis"
                    [ TextOverflow.Ellipsis ]
                    ["textOverflow" ==> "ellipsis"]
                test
                    "Text overflow -"
                    [ TextOverflow' (Types.CssString "-") ]
                    ["textOverflow" ==> "\"-\""]
                test
                    "Quotes none"
                    [ Quotes.None ]
                    ["quotes" ==> "none"]
                test
                    "Quotes Auto"
                    [ Quotes.Auto ]
                    ["quotes" ==> "auto"]
                test
                    "Quotes strings"
                    [ Quotes.Value(Types.CssString "<<", Types.CssString ">>") ]
                    ["quotes" ==> "\"<<\" \">>\""]
                test
                    "Quotes multiple"
                    [ Quotes.Value [ Types.CssString "<<" :> Types.IQuotes, Types.CssString ">>" :> Types.IQuotes; Types.CssString "<" :> Types.IQuotes,  Types.CssString ">" :> Types.IQuotes] ]
                    ["quotes" ==> "\"<<\" \">>\" \"<\" \">\""]
                test
                    "Quotes inherit"
                    [ Quotes.Inherit ]
                    ["quotes" ==> "inherit"]
                test
                    "Quotes Initial"
                    [ Quotes.Initial ]
                    ["quotes" ==> "initial"]
                test
                    "Quotes unset"
                    [ Quotes.Unset ]
                    ["quotes" ==> "unset"]
                test
                    "Hyphens Manual"
                    [ Hyphens.Manual ]
                    ["hyphens" ==> "manual"]
                test
                    "Hyphens none"
                    [ Hyphens.None ]
                    ["hyphens" ==> "none"]
                test
                    "Hyphens Auto"
                    [ Hyphens.Auto ]
                    ["hyphens" ==> "auto"]
                test
                    "Hyphens inherit"
                    [ Hyphens.Inherit ]
                    ["hyphens" ==> "inherit"]
                test
                    "Hyphens Initial"
                    [ Hyphens.Initial ]
                    ["hyphens" ==> "initial"]
                test
                    "Hyphens unset"
                    [ Hyphens.Unset ]
                    ["hyphens" ==> "unset"]
                test
                    "TextSizeAdjust percent"
                    [ TextSizeAdjust' (pct 80) ]
                    ["textSizeAdjust" ==> "80%"]
                test
                    "TextSizeAdjust none"
                    [ TextSizeAdjust.None ]
                    ["textSizeAdjust" ==> "none"]
                test
                    "TextSizeAdjust Auto"
                    [ TextSizeAdjust.Auto ]
                    ["textSizeAdjust" ==> "auto"]
                test
                    "TextSizeAdjust inherit"
                    [ TextSizeAdjust.Inherit ]
                    ["textSizeAdjust" ==> "inherit"]
                test
                    "TextSizeAdjust Initial"
                    [ TextSizeAdjust.Initial ]
                    ["textSizeAdjust" ==> "initial"]
                test
                    "TextSizeAdjust unset"
                    [ TextSizeAdjust.Unset ]
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
                    [ TabSize' (Types.CssInt 4) ]
                    ["tabSize" ==> "4"]
                test
                    "TabSize inherit"
                    [ TabSize.Inherit ]
                    ["tabSize" ==> "inherit"]
                test
                    "TabSize Initial"
                    [ TabSize.Initial ]
                    ["tabSize" ==> "initial"]
                test
                    "TabSize unset"
                    [ TabSize.Unset ]
                    ["tabSize" ==> "unset"]
                test
                    "TextOrientation Mixed"
                    [ TextOrientation.Mixed ]
                    ["textOrientation" ==> "mixed"]
                test
                    "TextOrientation Upright"
                    [ TextOrientation.Upright ]
                    ["textOrientation" ==> "upright"]
                test
                    "TextOrientation sideways-right"
                    [ TextOrientation.SidewaysRight ]
                    ["textOrientation" ==> "sideways-right"]
                test
                    "TextOrientation Sideways"
                    [ TextOrientation.Sideways ]
                    ["textOrientation" ==> "sideways"]
                test
                    "TextOrientation use-glyph-orientation"
                    [ TextOrientation.UseGlyphOrientation ]
                    ["textOrientation" ==> "use-glyph-orientation"]
                test
                    "TextOrientation inherit"
                    [ TextOrientation.Inherit ]
                    ["textOrientation" ==> "inherit"]
                test
                    "TextOrientation Initial"
                    [ TextOrientation.Initial ]
                    ["textOrientation" ==> "initial"]
                test
                    "TextOrientation unset"
                    [ TextOrientation.Unset ]
                    ["textOrientation" ==> "unset"]
                test
                    "TextRendering optimize speed"
                    [ TextRendering.OptimizeSpeed ]
                    ["textRendering" ==> "optimize-speed"]
                test
                    "TextRendering optimize legibility"
                    [ TextRendering.OptimizeLegibility ]
                    ["textRendering" ==> "optimize-legibility"]
                test
                    "TextRendering geometric precision"
                    [ TextRendering.GeometricPrecision ]
                    ["textRendering" ==> "geometric-precision"]
                test
                    "TextRendering auto"
                    [ TextRendering.Auto ]
                    ["textRendering" ==> "auto"]
                test
                    "TextRendering inherit"
                    [ TextRendering.Inherit ]
                    ["textRendering" ==> "inherit"]
                test
                    "TextRendering Initial"
                    [ TextRendering.Initial ]
                    ["textRendering" ==> "initial"]
                test
                    "TextRendering unset"
                    [ TextRendering.Unset ]
                    ["textRendering" ==> "unset"]
                test
                    "TextJustify inter-character"
                    [ TextJustify.InterCharacter ]
                    ["textJustify" ==> "inter-character"]
                test
                    "TextJustify inter-word"
                    [ TextJustify.InterWord ]
                    ["textJustify" ==> "inter-word"]
                test
                    "TextJustify auto"
                    [ TextJustify.Auto ]
                    ["textJustify" ==> "auto"]
                test
                    "TextJustify none"
                    [ TextJustify.None ]
                    ["textJustify" ==> "none"]
                test
                    "WhiteSpace nowrap"
                    [ WhiteSpace.NoWrap ]
                    ["whiteSpace" ==> "no-wrap"]
                test
                    "WhiteSpace pre"
                    [ WhiteSpace.Pre ]
                    ["whiteSpace" ==> "pre"]
                test
                    "WhiteSpace pre-wrap"
                    [ WhiteSpace.PreWrap ]
                    ["whiteSpace" ==> "pre-wrap"]
                test
                    "WhiteSpace pre-line"
                    [ WhiteSpace.PreLine ]
                    ["whiteSpace" ==> "pre-line"]
                test
                    "WhiteSpace break-spaces"
                    [ WhiteSpace.BreakSpaces ]
                    ["whiteSpace" ==> "break-spaces"]
                test
                    "WhiteSpace normal"
                    [ WhiteSpace.Normal ]
                    ["whiteSpace" ==> "normal"]
                test
                    "WhiteSpace inherit"
                    [ WhiteSpace.Inherit ]
                    ["whiteSpace" ==> "inherit"]
                test
                    "WhiteSpace Initial"
                    [ WhiteSpace.Initial ]
                    ["whiteSpace" ==> "initial"]
                test
                    "WhiteSpace unset"
                    [ WhiteSpace.Unset ]
                    ["whiteSpace" ==> "unset"]
                test
                    "UserSelect text"
                    [ UserSelect.Text ]
                    ["userSelect" ==> "text"]
                test
                    "UserSelect Contain"
                    [ UserSelect.Contain ]
                    ["userSelect" ==> "contain"]
                test
                    "UserSelect all"
                    [ UserSelect.All ]
                    ["userSelect" ==> "all"]
                test
                    "UserSelect none"
                    [ UserSelect.None ]
                    ["userSelect" ==> "none"]
                test
                    "UserSelect auto"
                    [ UserSelect.Auto ]
                    ["userSelect" ==> "auto"]
                test
                    "UserSelect inherit"
                    [ UserSelect.Inherit ]
                    ["userSelect" ==> "inherit"]
                test
                    "UserSelect Initial"
                    [ UserSelect.Initial ]
                    ["userSelect" ==> "initial"]
                test
                    "UserSelect unset"
                    [ UserSelect.Unset ]
                    ["userSelect" ==> "unset"]
            ]