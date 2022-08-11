namespace FSSTests

open Fet
open Utils
open Fss

module TextTests =
    let tests =
        testList "Text"
            [
                testCase
                    "Text transform none"
                    [TextTransform.none]
                    "{text-transform:none;}"
                testCase
                    "Text transform capitalize"
                    [TextTransform.capitalize]
                    "{text-transform:capitalize;}"
                testCase
                    "Text transform uppercase"
                    [TextTransform.uppercase]
                    "{text-transform:uppercase;}"
                testCase
                    "Text transform lowercase"
                    [TextTransform.lowercase]
                    "{text-transform:lowercase;}"
                testCase
                    "Text transform full width"
                    [TextTransform.fullWidth]
                    "{text-transform:full-width;}"
                testCase
                    "Text transform full size kana"
                    [TextTransform.fullSizeKana]
                    "{text-transform:full-size-kana;}"
                testCase
                    "Text decoration none"
                    [TextDecoration.none]
                    "{text-decoration:none;}"
                testCase
                    "Text decoration inherit"
                    [TextDecoration.inherit']
                    "{text-decoration:inherit;}"
                testCase
                    "Text decoration initial"
                    [TextDecoration.initial]
                    "{text-decoration:initial;}"
                testCase
                    "Text decoration unset"
                    [TextDecoration.unset]
                    "{text-decoration:unset;}"
                testCase
                    "Text decoration revert"
                    [TextDecoration.revert]
                    "{text-decoration:revert;}"
                testCase
                    "Text emphasis none"
                    [TextEmphasis.none]
                    "{text-emphasis:none;}"
                testCase
                    "Text emphasis inherit"
                    [ TextEmphasis.inherit' ]
                    "{text-emphasis:inherit;}"
                testCase
                    "Text emphasis initial"
                    [ TextEmphasis.initial ]
                    "{text-emphasis:initial;}"
                testCase
                    "Text emphasis unset"
                    [ TextEmphasis.unset ]
                    "{text-emphasis:unset;}"
                testCase
                    "Text emphasis revert"
                    [ TextEmphasis.revert ]
                    "{text-emphasis:revert;}"
                testCase
                    "Text align left"
                    [ TextAlign.left ]
                    "{text-align:left;}"
                testCase
                    "Text align right"
                    [ TextAlign.right ]
                    "{text-align:right;}"
                testCase
                    "Text align center"
                    [ TextAlign.center ]
                    "{text-align:center;}"
                testCase
                    "Text align justify"
                    [ TextAlign.justify ]
                    "{text-align:justify;}"
                testCase
                    "Text align justify all"
                    [ TextAlign.justifyAll ]
                    "{text-align:justify-all;}"
                testCase
                    "Text align start"
                    [ TextAlign.start ]
                    "{text-align:start;}"
                testCase
                    "Text align end"
                    [ TextAlign.end' ]
                    "{text-align:end;}"
                testCase
                    "Text align match-parent"
                    [ TextAlign.matchParent ]
                    "{text-align:match-parent;}"
                testCase
                    "Text align inherit"
                    [ TextAlign.inherit' ]
                    "{text-align:inherit;}"
                testCase
                    "Text align initial"
                    [ TextAlign.initial ]
                    "{text-align:initial;}"
                testCase
                    "Text align unset"
                    [ TextAlign.unset ]
                    "{text-align:unset;}"
                testCase
                    "Text align revert"
                    [ TextAlign.revert ]
                    "{text-align:revert;}"
                testCase
                    "Text align last left"
                    [ TextAlignLast.left ]
                    "{text-align-last:left;}"
                testCase
                    "Text align last right"
                    [ TextAlignLast.right ]
                    "{text-align-last:right;}"
                testCase
                    "Text align last center"
                    [ TextAlignLast.center ]
                    "{text-align-last:center;}"
                testCase
                    "Text align last justify"
                    [ TextAlignLast.justify ]
                    "{text-align-last:justify;}"
                testCase
                    "Text align last start"
                    [ TextAlignLast.start ]
                    "{text-align-last:start;}"
                testCase
                    "Text align last end"
                    [ TextAlignLast.end' ]
                    "{text-align-last:end;}"
                testCase
                    "Text align last inherit"
                    [ TextAlignLast.inherit' ]
                    "{text-align-last:inherit;}"
                testCase
                    "Text align last initial"
                    [ TextAlignLast.initial ]
                    "{text-align-last:initial;}"
                testCase
                    "Text align last unset"
                    [ TextAlignLast.unset ]
                    "{text-align-last:unset;}"
                testCase
                    "Text align last revert"
                    [ TextAlignLast.revert ]
                    "{text-align-last:revert;}"
                testCase
                    "Text decoration color red"
                    [TextDecorationColor.red]
                    "{text-decoration-color:red;}"
                testCase
                    "Text decoration color hex"
                    [TextDecorationColor.hex "00ff00" ]
                    "{text-decoration-color:#00ff00;}"
                testCase
                    "Text decoration color rgba"
                    [TextDecorationColor.rgba 255 128 128 0.5 ]
                    "{text-decoration-color:rgba(255,128,128,0.5);}"
                testCase
                    "Text decoration color transparent"
                    [TextDecorationColor.transparent]
                    "{text-decoration-color:transparent;}"
                testCase
                    "Text decoration color inherit"
                    [TextDecorationColor.inherit']
                    "{text-decoration-color:inherit;}"
                testCase
                    "Text decoration color initial"
                    [TextDecorationColor.initial]
                    "{text-decoration-color:initial;}"
                testCase
                    "Text decoration color unset"
                    [TextDecorationColor.unset]
                    "{text-decoration-color:unset;}"
                testCase
                    "Text decoration color revert"
                    [TextDecorationColor.revert]
                    "{text-decoration-color:revert;}"
                testCase
                    "Text decoration line none"
                    [TextDecorationLine.none]
                    "{text-decoration-line:none;}"
                testCase
                    "Text decoration line underline"
                    [TextDecorationLine.underline]
                    "{text-decoration-line:underline;}"
                testCase
                    "Text decoration line overline"
                    [TextDecorationLine.overline]
                    "{text-decoration-line:overline;}"
                testCase
                    "Text decoration line line-through"
                    [TextDecorationLine.lineThrough]
                    "{text-decoration-line:line-through;}"
                testCase
                    "Text decoration line blink"
                    [TextDecorationLine.blink]
                    "{text-decoration-line:blink;}"
                testCase
                    "Text decoration line inherit"
                    [ TextDecorationLine.inherit' ]
                    "{text-decoration-line:inherit;}"
                testCase
                    "Text decoration line initial"
                    [ TextDecorationLine.initial ]
                    "{text-decoration-line:initial;}"
                testCase
                    "Text decoration line unset"
                    [ TextDecorationLine.unset ]
                    "{text-decoration-line:unset;}"
                testCase
                    "Text decorations multiple"
                    [TextDecorationLine.value [Fss.Types.Text.DecorationLine.Overline; Fss.Types.Text.DecorationLine.Underline; Fss.Types.Text.DecorationLine.LineThrough]]
                    "{text-decoration-line:overline underline line-through;}"
                testCase
                    "Text decoration skip none"
                    [TextDecorationSkip.none]
                    "{text-decoration-skip:none;}"
                testCase
                    "Text decoration skip objects"
                    [TextDecorationSkip.objects]
                    "{text-decoration-skip:objects;}"
                testCase
                    "Text decoration skip spaces"
                    [TextDecorationSkip.spaces]
                    "{text-decoration-skip:spaces;}"
                testCase
                    "Text decoration skip edges"
                    [TextDecorationSkip.edges]
                    "{text-decoration-skip:edges;}"
                testCase
                    "Text decoration skip box-decoration"
                    [TextDecorationSkip.boxDecoration]
                    "{text-decoration-skip:box-decoration;}"
                testCase
                    "Text decoration skip multiple - objects and spaces"
                    [TextDecorationSkip.value [Fss.Types.Text.DecorationSkip.Objects; Fss.Types.Text.DecorationSkip.Spaces] ]
                    "{text-decoration-skip:objects spaces;}"
                testCase
                    "Text decoration skip multiple - leading spaces and trailing spaces"
                    [TextDecorationSkip.value [Fss.Types.Text.DecorationSkip.LeadingSpaces; Fss.Types.Text.DecorationSkip.TrailingSpaces]]
                    "{text-decoration-skip:leading-spaces trailing-spaces;}"
                testCase
                    "Text decoration skip multiple - objects edges box-decoration"
                    [TextDecorationSkip.value [Fss.Types.Text.DecorationSkip.Objects; Fss.Types.Text.DecorationSkip.Edges; Fss.Types.Text.DecorationSkip.BoxDecoration] ]
                    "{text-decoration-skip:objects edges box-decoration;}"
                testCase
                    "Text decoration skip inherit"
                    [TextDecorationSkip.inherit']
                    "{text-decoration-skip:inherit;}"
                testCase
                    "Text decoration skip initial"
                    [TextDecorationSkip.initial]
                    "{text-decoration-skip:initial;}"
                testCase
                    "Text decoration skip unset"
                    [TextDecorationSkip.unset]
                    "{text-decoration-skip:unset;}"
                testCase
                    "Text decoration skip revert"
                    [TextDecorationSkip.revert]
                    "{text-decoration-skip:revert;}"
                testCase
                    "Text decoration skip unset"
                    [TextDecorationSkipInk.auto]
                    "{text-decoration-skip-ink:auto;}"
                testCase
                    "Text decoration skip All"
                    [TextDecorationSkipInk.all]
                    "{text-decoration-skip-ink:all;}"
                testCase
                    "Text decoration skip none"
                    [TextDecorationSkipInk.none]
                    "{text-decoration-skip-ink:none;}"
                testCase
                    "Text decoration skipink inherit"
                    [TextDecorationSkipInk.inherit']
                    "{text-decoration-skip-ink:inherit;}"
                testCase
                    "Text decoration skipink unset"
                    [TextDecorationSkipInk.unset]
                    "{text-decoration-skip-ink:unset;}"
                testCase
                    "Text decoration skipink initial"
                    [TextDecorationSkipInk.initial]
                    "{text-decoration-skip-ink:initial;}"
                testCase
                    "Text decoration skipink revert"
                    [TextDecorationSkipInk.revert]
                    "{text-decoration-skip-ink:revert;}"
                testCase
                    "Text decoration style solid"
                    [TextDecorationStyle.solid]
                    "{text-decoration-style:solid;}"
                testCase
                    "Text decoration style double"
                    [TextDecorationStyle.double]
                    "{text-decoration-style:double;}"
                testCase
                    "Text decoration style dotted"
                    [TextDecorationStyle.dotted]
                    "{text-decoration-style:dotted;}"
                testCase
                    "Text decoration style dashed"
                    [TextDecorationStyle.dashed]
                    "{text-decoration-style:dashed;}"
                testCase
                    "Text decoration style wavy"
                    [TextDecorationStyle.wavy]
                    "{text-decoration-style:wavy;}"
                testCase
                    "Text decoration style inherit"
                    [TextDecorationStyle.inherit']
                    "{text-decoration-style:inherit;}"
                testCase
                    "Text decoration style initial"
                    [TextDecorationStyle.initial]
                    "{text-decoration-style:initial;}"
                testCase
                    "Text decoration style unset"
                    [TextDecorationStyle.unset]
                    "{text-decoration-style:unset;}"
                testCase
                    "Text decoration style revert"
                    [TextDecorationStyle.revert]
                    "{text-decoration-style:revert;}"
                testCase
                    "Text decoration thickness auto"
                    [ TextDecorationThickness.auto ]
                     "{text-decoration-thickness:auto;}"
                testCase
                    "Text decoration thickness from font"
                    [ TextDecorationThickness.fromFont ]
                    "{text-decoration-thickness:from-font;}"
                testCase
                    "Text decoration thickness em"
                    [ TextDecorationThickness.value (em 0.1) ]
                    "{text-decoration-thickness:0.1em;}"
                testCase
                    "Text decoration thickness px"
                    [ TextDecorationThickness.value (px 3) ]
                    "{text-decoration-thickness:3px;}"
                testCase
                    "Text decoration thickness percent"
                    [ TextDecorationThickness.value (pct 10) ]
                    "{text-decoration-thickness:10%;}"
                testCase
                    "Text decoration thickness inherit"
                    [ TextDecorationThickness.inherit' ]
                    "{text-decoration-thickness:inherit;}"
                testCase
                    "Text decoration thickness initial"
                    [ TextDecorationThickness.initial ]
                    "{text-decoration-thickness:initial;}"
                testCase
                    "Text decoration thickness unset"
                    [ TextDecorationThickness.unset ]
                    "{text-decoration-thickness:unset;}"
                testCase
                    "Text decoration thickness revert"
                    [ TextDecorationThickness.revert ]
                    "{text-decoration-thickness:revert;}"
                testCase
                    "Text emphasis color hex"
                    [ TextEmphasisColor.hex "#555" ]
                    "{text-emphasis-color:#555;}"
                testCase
                    "Text emphasis color color name"
                    [ TextEmphasisColor.blue ]
                    "{text-emphasis-color:blue;}"
                testCase
                    "Text emphasis color rgba"
                    [ TextEmphasisColor.rgba 90 200 160 0.8 ]
                    "{text-emphasis-color:rgba(90,200,160,0.8);}"
                testCase
                    "Text emphasis color transparent"
                    [ TextEmphasisColor.transparent ]
                    "{text-emphasis-color:transparent;}"
                testCase
                    "Text emphasis color inherit"
                    [ TextEmphasisColor.inherit' ]
                    "{text-emphasis-color:inherit;}"
                testCase
                    "Text emphasis color Initial"
                    [ TextEmphasisColor.initial ]
                    "{text-emphasis-color:initial;}"
                testCase
                    "Text emphasis color unset"
                    [ TextEmphasisColor.unset ]
                    "{text-emphasis-color:unset;}"
                testCase
                    "Text emphasis color revert"
                    [ TextEmphasisColor.revert ]
                    "{text-emphasis-color:revert;}"
                testCase
                    "Text emphasis position over right"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Over, Fss.Types.Text.EmphasisPosition.Right) ]
                    "{text-emphasis-position:over right;}"
                testCase
                    "Text emphasis position over right"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Over, Fss.Types.Text.EmphasisPosition.Right) ]
                    "{text-emphasis-position:over right;}"
                testCase
                    "Text emphasis position over left"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Over, Fss.Types.Text.EmphasisPosition.Left) ]
                    "{text-emphasis-position:over left;}"
                testCase
                    "Text emphasis position under right"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Under, Fss.Types.Text.EmphasisPosition.Right) ]
                    "{text-emphasis-position:under right;}"
                testCase
                    "Text emphasis position under left"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Under, Fss.Types.Text.EmphasisPosition.Left) ]
                    "{text-emphasis-position:under left;}"
                testCase
                    "Text emphasis position left over"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Left, Fss.Types.Text.EmphasisPosition.Over) ]
                    "{text-emphasis-position:left over;}"
                testCase
                    "Text emphasis position right under"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Right, Fss.Types.Text.EmphasisPosition.Under) ]
                    "{text-emphasis-position:right under;}"
                testCase
                    "Text emphasis position left under"
                    [ TextEmphasisPosition.value (Fss.Types.Text.EmphasisPosition.Left, Fss.Types.Text.EmphasisPosition.Under) ]
                    "{text-emphasis-position:left under;}"
                testCase
                    "Text emphasis position inherit"
                    [ TextEmphasisPosition.inherit' ]
                    "{text-emphasis-position:inherit;}"
                testCase
                    "Text emphasis position Initial"
                    [ TextEmphasisPosition.initial ]
                    "{text-emphasis-position:initial;}"
                testCase
                    "Text emphasis position unset"
                    [ TextEmphasisPosition.unset ]
                    "{text-emphasis-position:unset;}"
                testCase
                    "Text emphasis position revert"
                    [ TextEmphasisPosition.revert ]
                    "{text-emphasis-position:revert;}"
                testCase
                    "Text Emphasis Style x"
                    [TextEmphasisStyle.value "x" ]
                    "{text-emphasis-style:'x';}"
                testCase
                    "Text Emphasis Style *"
                    [TextEmphasisStyle.value "*"]
                    "{text-emphasis-style:'*';}"
                testCase
                    "Text Emphasis Style filled"
                    [TextEmphasisStyle.filled ]
                    "{text-emphasis-style:filled;}"
                testCase
                    "Text Emphasis Style open"
                    [TextEmphasisStyle.open']
                    "{text-emphasis-style:open;}"
                testCase
                    "Text Emphasis Style circle"
                    [TextEmphasisStyle.circle]
                    "{text-emphasis-style:circle;}"
                testCase
                    "Text Emphasis Style double circle"
                    [TextEmphasisStyle.doubleCircle]
                    "{text-emphasis-style:double-circle;}"
                testCase
                    "Text Emphasis Style triangle"
                    [TextEmphasisStyle.triangle]
                    "{text-emphasis-style:triangle;}"
                testCase
                    "Text Emphasis Style filled sesame"
                    [TextEmphasisStyle.filledSesame]
                    "{text-emphasis-style:filled sesame;}"
                testCase
                    "Text Emphasis Style open sesame"
                    [TextEmphasisStyle.openSesame]
                    "{text-emphasis-style:open sesame;}"
                testCase
                    "Text emphasis style inherit"
                    [ TextEmphasisStyle.inherit' ]
                    "{text-emphasis-style:inherit;}"
                testCase
                    "Text emphasis style Initial"
                    [ TextEmphasisStyle.initial ]
                    "{text-emphasis-style:initial;}"
                testCase
                    "Text emphasis style unset"
                    [ TextEmphasisStyle.unset ]
                    "{text-emphasis-style:unset;}"
                testCase
                    "Text emphasis style revert"
                    [ TextEmphasisStyle.revert ]
                    "{text-emphasis-style:revert;}"
                testCase
                    "Text shadow single"
                    [ TextShadow.value (px 1, px 1, px 2, Fss.Types.Color.Black) ]
                    "{text-shadow:1px 1px 2px black;}"
                testCase
                    "Text shadow multiple"
                    [ TextShadow.value
                          [ (px 1, px 1, px 2, Fss.Types.Color.Color.Black)
                            (px 10, px -10, px 20, Fss.Types.Color.Color.Red)
                          ]
                    ]
                    "{text-shadow:1px 1px 2px black, 10px -10px 20px red;}"
                testCase
                    "Text shadow inherit"
                    [ TextShadow.inherit' ]
                    "{text-shadow:inherit;}"
                testCase
                    "Text shadow Initial"
                    [ TextShadow.initial ]
                    "{text-shadow:initial;}"
                testCase
                    "Text shadow unset"
                    [ TextShadow.unset ]
                    "{text-shadow:unset;}"
                testCase
                    "Text shadow revert"
                    [ TextShadow.revert ]
                    "{text-shadow:revert;}"
                testCase
                    "Text underline offset em"
                    [ TextUnderlineOffset.value (em 3.0) ]
                    "{text-underline-offset:3em;}"
                testCase
                    "Text underline offset px"
                    [ TextUnderlineOffset.value (px 10) ]
                    "{text-underline-offset:10px;}"
                testCase
                    "Text underline offset percent"
                    [ TextUnderlineOffset.value (pct 10) ]
                    "{text-underline-offset:10%;}"
                testCase
                    "Text underline offset auto"
                    [ TextUnderlineOffset.auto ]
                    "{text-underline-offset:auto;}"
                testCase
                    "Text underline offset inherit"
                    [ TextUnderlineOffset.inherit' ]
                    "{text-underline-offset:inherit;}"
                testCase
                    "Text underline offset Initial"
                    [ TextUnderlineOffset.initial ]
                    "{text-underline-offset:initial;}"
                testCase
                    "Text underline offset unset"
                    [ TextUnderlineOffset.unset ]
                    "{text-underline-offset:unset;}"
                testCase
                    "Text underline offset revert"
                    [ TextUnderlineOffset.revert ]
                    "{text-underline-offset:revert;}"
                testCase
                    "Text underline position from-font"
                    [ TextUnderlinePosition.fromFont ]
                    "{text-underline-position:from-font;}"
                testCase
                    "Text underline position Under"
                    [ TextUnderlinePosition.under ]
                    "{text-underline-position:under;}"
                testCase
                    "Text underline position left"
                    [ TextUnderlinePosition.left ]
                    "{text-underline-position:left;}"
                testCase
                    "Text underline position right"
                    [ TextUnderlinePosition.right ]
                    "{text-underline-position:right;}"
                testCase
                    "Text underline position auto-pos"
                    [ TextUnderlinePosition.autoPos ]
                    "{text-underline-position:auto-pos;}"
                testCase
                    "Text underline position above"
                    [ TextUnderlinePosition.above ]
                    "{text-underline-position:above;}"
                testCase
                    "Text underline position below"
                    [ TextUnderlinePosition.below ]
                    "{text-underline-position:below;}"
                testCase
                    "Text underline positions under left"
                    [ TextUnderlinePosition.value (Fss.Types.Text.UnderlinePosition.Under, Fss.Types.Text.UnderlinePosition.Left) ]
                    "{text-underline-position:under left;}"
                testCase
                    "Text underline positions right under"
                    [ TextUnderlinePosition.value (Fss.Types.Text.UnderlinePosition.Right, Fss.Types.Text.UnderlinePosition.Under) ]
                    "{text-underline-position:right under;}"
                testCase
                    "Text underline position auto"
                    [ TextUnderlinePosition.auto ]
                    "{text-underline-position:auto;}"
                testCase
                    "Text underline position inherit"
                    [ TextUnderlinePosition.inherit' ]
                    "{text-underline-position:inherit;}"
                testCase
                    "Text underline position Initial"
                    [ TextUnderlinePosition.initial ]
                    "{text-underline-position:initial;}"
                testCase
                    "Text underline position unset"
                    [ TextUnderlinePosition.unset ]
                    "{text-underline-position:unset;}"
                testCase
                    "Text underline position revert"
                    [ TextUnderlinePosition.revert ]
                    "{text-underline-position:revert;}"
                testCase
                    "Text indent mm"
                    [ TextIndent.value (mm 3.0) ]
                    "{text-indent:3mm;}"
                testCase
                    "Text indent px"
                    [ TextIndent.value (px 40) ]
                    "{text-indent:40px;}"
                testCase
                    "Text indent percent"
                    [ TextIndent.value (pct 15) ]
                    "{text-indent:15%;}"
                testCase
                    "Text indent hanging"
                    [ TextIndent.hanging (em 5) ]
                    "{text-indent:5em hanging;}"
                testCase
                    "Text indent each line"
                    [ TextIndent.eachLine (em 5) ]
                    "{text-indent:5em each-line;}"
                testCase
                    "Text indent hanging each line"
                    [ TextIndent.hangingEachLine (em 5) ]
                    "{text-indent:5em hanging each-line;}"
                testCase
                    "Text indent inherit"
                    [ TextIndent.inherit' ]
                    "{text-indent:inherit;}"
                testCase
                    "Text indent Initial"
                    [ TextIndent.initial ]
                    "{text-indent:initial;}"
                testCase
                    "Text indent unset"
                    [ TextIndent.unset ]
                    "{text-indent:unset;}"
                testCase
                    "Text indent unset"
                    [ TextIndent.unset ]
                    "{text-indent:unset;}"
                testCase
                    "Text overflow clip"
                    [ TextOverflow.clip ]
                    "{text-overflow:clip;}"
                testCase
                    "Text overflow ellipsis"
                    [ TextOverflow.ellipsis ]
                    "{text-overflow:ellipsis;}"
                testCase
                    "Text overflow -"
                    [ TextOverflow.value "-" ]
                    "{text-overflow:\"-\";}"
                testCase
                    "Text overflow inherit"
                    [ TextOverflow.inherit' ]
                    "{text-overflow:inherit;}"
                testCase
                    "Text overflow Initial"
                    [ TextOverflow.initial ]
                    "{text-overflow:initial;}"
                testCase
                    "Text overflow unset"
                    [ TextOverflow.unset ]
                    "{text-overflow:unset;}"
                testCase
                    "Text overflow revert"
                    [ TextOverflow.revert ]
                    "{text-overflow:revert;}"
                testCase
                    "Quotes none"
                    [ Quotes.none ]
                    "{quotes:none;}"
                testCase
                    "Quotes Auto"
                    [ Quotes.auto ]
                    "{quotes:auto;}"
                testCase
                    "Quotes strings"
                    [ Quotes.value ["<<"; ">>"] ]
                    "{quotes:\"<<\" \">>\";}"
                testCase
                    "Quotes multiple"
                    [ Quotes.value [ "<<"; ">>"; "<"; ">" ] ]
                    "{quotes:\"<<\" \">>\" \"<\" \">\";}"
                testCase
                    "Quotes inherit"
                    [ Quotes.inherit' ]
                    "{quotes:inherit;}"
                testCase
                    "Quotes Initial"
                    [ Quotes.initial ]
                    "{quotes:initial;}"
                testCase
                    "Quotes unset"
                    [ Quotes.unset ]
                    "{quotes:unset;}"
                testCase
                    "Hyphens Manual"
                    [ Hyphens.manual ]
                    "{hyphens:manual;}"
                testCase
                    "Hyphens none"
                    [ Hyphens.none ]
                    "{hyphens:none;}"
                testCase
                    "Hyphens Auto"
                    [ Hyphens.auto ]
                    "{hyphens:auto;}"
                testCase
                    "Hyphens inherit"
                    [ Hyphens.inherit' ]
                    "{hyphens:inherit;}"
                testCase
                    "Hyphens Initial"
                    [ Hyphens.initial ]
                    "{hyphens:initial;}"
                testCase
                    "Hyphens unset"
                    [ Hyphens.unset ]
                    "{hyphens:unset;}"
                testCase
                    "Hyphens revert"
                    [ Hyphens.revert ]
                    "{hyphens:revert;}"
                testCase
                    "TextSizeAdjust percent"
                    [ TextSizeAdjust.value (pct 80) ]
                    "{text-size-adjust:80%;}"
                testCase
                    "TextSizeAdjust none"
                    [ TextSizeAdjust.none ]
                    "{text-size-adjust:none;}"
                testCase
                    "TextSizeAdjust Auto"
                    [ TextSizeAdjust.auto ]
                    "{text-size-adjust:auto;}"
                testCase
                    "TextSizeAdjust inherit"
                    [ TextSizeAdjust.inherit' ]
                    "{text-size-adjust:inherit;}"
                testCase
                    "TextSizeAdjust Initial"
                    [ TextSizeAdjust.initial ]
                    "{text-size-adjust:initial;}"
                testCase
                    "TextSizeAdjust unset"
                    [ TextSizeAdjust.unset ]
                    "{text-size-adjust:unset;}"
                testCase
                    "TextSizeAdjust revert"
                    [ TextSizeAdjust.revert ]
                    "{text-size-adjust:revert;}"
                testCase
                    "TabSize px"
                    [ TabSize.value (px 10) ]
                    "{tab-size:10px;}"
                testCase
                    "TabSize em"
                    [ TabSize.value (em 2.) ]
                    "{tab-size:2em;}"
                testCase
                    "TabSize number"
                    [ TabSize.value 4 ]
                    "{tab-size:4;}"
                testCase
                    "TabSize inherit"
                    [ TabSize.inherit' ]
                    "{tab-size:inherit;}"
                testCase
                    "TabSize Initial"
                    [ TabSize.initial ]
                    "{tab-size:initial;}"
                testCase
                    "TabSize unset"
                    [ TabSize.unset ]
                    "{tab-size:unset;}"
                testCase
                    "TabSize revert"
                    [ TabSize.revert ]
                    "{tab-size:revert;}"
                testCase
                    "TextOrientation Mixed"
                    [ TextOrientation.mixed ]
                    "{text-orientation:mixed;}"
                testCase
                    "TextOrientation Upright"
                    [ TextOrientation.upright ]
                    "{text-orientation:upright;}"
                testCase
                    "TextOrientation sideways-right"
                    [ TextOrientation.sidewaysRight ]
                    "{text-orientation:sideways-right;}"
                testCase
                    "TextOrientation Sideways"
                    [ TextOrientation.sideways ]
                    "{text-orientation:sideways;}"
                testCase
                    "TextOrientation use-glyph-orientation"
                    [ TextOrientation.useGlyphOrientation ]
                    "{text-orientation:use-glyph-orientation;}"
                testCase
                    "TextOrientation inherit"
                    [ TextOrientation.inherit' ]
                    "{text-orientation:inherit;}"
                testCase
                    "TextOrientation Initial"
                    [ TextOrientation.initial ]
                    "{text-orientation:initial;}"
                testCase
                    "TextOrientation unset"
                    [ TextOrientation.unset ]
                    "{text-orientation:unset;}"
                testCase
                    "TextOrientation revert"
                    [ TextOrientation.revert ]
                    "{text-orientation:revert;}"
                testCase
                    "TextRendering optimize speed"
                    [ TextRendering.optimizeSpeed ]
                    "{text-rendering:optimize-speed;}"
                testCase
                    "TextRendering optimize legibility"
                    [ TextRendering.optimizeLegibility ]
                    "{text-rendering:optimize-legibility;}"
                testCase
                    "TextRendering geometric precision"
                    [ TextRendering.geometricPrecision ]
                    "{text-rendering:geometric-precision;}"
                testCase
                    "TextRendering auto"
                    [ TextRendering.auto ]
                    "{text-rendering:auto;}"
                testCase
                    "TextRendering inherit"
                    [ TextRendering.inherit' ]
                    "{text-rendering:inherit;}"
                testCase
                    "TextRendering Initial"
                    [ TextRendering.initial ]
                    "{text-rendering:initial;}"
                testCase
                    "TextRendering unset"
                    [ TextRendering.unset ]
                    "{text-rendering:unset;}"
                testCase
                    "TextRendering revert"
                    [ TextRendering.revert ]
                    "{text-rendering:revert;}"
                testCase
                    "TextJustify inter-character"
                    [ TextJustify.interCharacter ]
                    "{text-justify:inter-character;}"
                testCase
                    "TextJustify inter-word"
                    [ TextJustify.interWord ]
                    "{text-justify:inter-word;}"
                testCase
                    "TextJustify auto"
                    [ TextJustify.auto ]
                    "{text-justify:auto;}"
                testCase
                    "TextJustify none"
                    [ TextJustify.none ]
                    "{text-justify:none;}"
                testCase
                    "TextJustify inherit"
                    [ TextJustify.inherit' ]
                    "{text-justify:inherit;}"
                testCase
                    "TextJustify Initial"
                    [ TextJustify.initial ]
                    "{text-justify:initial;}"
                testCase
                    "TextJustify unset"
                    [ TextJustify.unset ]
                    "{text-justify:unset;}"
                testCase
                    "TextJustify revert"
                    [ TextJustify.revert ]
                    "{text-justify:revert;}"
                testCase
                    "WhiteSpace nowrap"
                    [ WhiteSpace.nowrap ]
                    "{white-space:nowrap;}"
                testCase
                    "WhiteSpace pre"
                    [ WhiteSpace.pre ]
                    "{white-space:pre;}"
                testCase
                    "WhiteSpace pre-wrap"
                    [ WhiteSpace.preWrap ]
                    "{white-space:pre-wrap;}"
                testCase
                    "WhiteSpace pre-line"
                    [ WhiteSpace.preLine ]
                    "{white-space:pre-line;}"
                testCase
                    "WhiteSpace break-spaces"
                    [ WhiteSpace.breakSpaces ]
                    "{white-space:break-spaces;}"
                testCase
                    "WhiteSpace normal"
                    [ WhiteSpace.normal ]
                    "{white-space:normal;}"
                testCase
                    "WhiteSpace inherit"
                    [ WhiteSpace.inherit' ]
                    "{white-space:inherit;}"
                testCase
                    "WhiteSpace Initial"
                    [ WhiteSpace.initial ]
                    "{white-space:initial;}"
                testCase
                    "WhiteSpace unset"
                    [ WhiteSpace.unset ]
                    "{white-space:unset;}"
                testCase
                    "UserSelect text"
                    [ UserSelect.text ]
                    "{user-select:text;}"
                testCase
                    "UserSelect Contain"
                    [ UserSelect.contain ]
                    "{user-select:contain;}"
                testCase
                    "UserSelect all"
                    [ UserSelect.all ]
                    "{user-select:all;}"
                testCase
                    "UserSelect element"
                    [ UserSelect.element ]
                    "{user-select:element;}"
                testCase
                    "UserSelect none"
                    [ UserSelect.none ]
                    "{user-select:none;}"
                testCase
                    "UserSelect auto"
                    [ UserSelect.auto ]
                    "{user-select:auto;}"
                testCase
                    "UserSelect inherit"
                    [ UserSelect.inherit' ]
                    "{user-select:inherit;}"
                testCase
                    "UserSelect Initial"
                    [ UserSelect.initial ]
                    "{user-select:initial;}"
                testCase
                    "UserSelect unset"
                    [ UserSelect.unset ]
                    "{user-select:unset;}"
                testCase
                    "UserSelect revert"
                    [ UserSelect.revert ]
                    "{user-select:revert;}"
                testCase
                    "HangingPunctuation first"
                    [ HangingPunctuation.first ]
                    "{hanging-punctuation:first;}"
                testCase
                    "HangingPunctuation last"
                    [ HangingPunctuation.last ]
                    "{hanging-punctuation:last;}"
                testCase
                    "HangingPunctuation ForceEnd"
                    [ HangingPunctuation.forceEnd ]
                    "{hanging-punctuation:force-end;}"
                testCase
                    "HangingPunctuation allowEnd"
                    [ HangingPunctuation.allowEnd ]
                    "{hanging-punctuation:allow-end;}"
                testCase
                    "HangingPunctuation first force-end"
                    [ HangingPunctuation.value [Fss.Types.Text.First; Fss.Types.Text.ForceEnd] ]
                    "{hanging-punctuation:first force-end;}"
                testCase
                    "HangingPunctuation first allow-end"
                    [ HangingPunctuation.value [Fss.Types.Text.First; Fss.Types.Text.AllowEnd]]
                    "{hanging-punctuation:first allow-end;}"
                testCase
                    "HangingPunctuation first last"
                    [ HangingPunctuation.value [Fss.Types.Text.First; Fss.Types.Text.Last] ]
                    "{hanging-punctuation:first last;}"
                testCase
                    "HangingPunctuation last force-end"
                    [ HangingPunctuation.value [Fss.Types.Text.Last; Fss.Types.Text.ForceEnd] ]
                    "{hanging-punctuation:last force-end;}"
                testCase
                    "HangingPunctuation last allow-end"
                    [ HangingPunctuation.value [Fss.Types.Text.Last; Fss.Types.Text.AllowEnd] ]
                    "{hanging-punctuation:last allow-end;}"
                testCase
                    "HangingPunctuation first force-end"
                    [ HangingPunctuation.value [Fss.Types.Text.First; Fss.Types.Text.ForceEnd; Fss.Types.Text.Last]]
                    "{hanging-punctuation:first force-end last;}"
                testCase
                    "HangingPunctuation last allow-end"
                    [ HangingPunctuation.value [Fss.Types.Text.First; Fss.Types.Text.AllowEnd; Fss.Types.Text.Last]]
                    "{hanging-punctuation:first allow-end last;}"
                testCase
                    "HangingPunctuation none"
                    [ HangingPunctuation.none ]
                    "{hanging-punctuation:none;}"
                testCase
                    "HangingPunctuation inherit"
                    [ HangingPunctuation.inherit' ]
                    "{hanging-punctuation:inherit;}"
                testCase
                    "HangingPunctuation Initial"
                    [ HangingPunctuation.initial ]
                    "{hanging-punctuation:initial;}"
                testCase
                    "HangingPunctuation unset"
                    [ HangingPunctuation.unset ]
                    "{hanging-punctuation:unset;}"
            ]
