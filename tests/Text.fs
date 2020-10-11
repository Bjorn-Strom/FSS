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
                    "Text align left"
                    [ TextAlign Text.Left ]
                    ["textAlign" ==> "left"]

                test
                    "Text align right"
                    [ TextAlign Text.Right ]
                    ["textAlign" ==> "right"]

                test
                    "Text align center"
                    [ TextAlign Text.Center ]
                    ["textAlign" ==> "center"]

                test
                    "Text align justify"
                    [ TextAlign Text.Justify ]
                    ["textAlign" ==> "justify"]

                test
                    "Text align justify all"
                    [ TextAlign Text.JustifyAll ]
                    ["textAlign" ==> "justify-all"]

                test
                    "Text align start"
                    [ TextAlign Text.Start ]
                    ["textAlign" ==> "start"]

                test
                    "Text align end"
                    [ TextAlign Text.End ]
                    ["textAlign" ==> "end"]

                test
                    "Text align match-parent"
                    [ TextAlign Text.MatchParent ]
                    ["textAlign" ==> "match-parent"]

                test
                    "Text align inherit"
                    [ TextAlign Inherit ]
                    ["textAlign" ==> "inherit"]

                test
                    "Text align initial"
                    [ TextAlign Initial ]
                    ["textAlign" ==> "initial"]

                test
                    "Text align unset"
                    [ TextAlign Unset ]
                    ["textAlign" ==> "unset"]
                
                test
                    "Text decoration color red"
                    [TextDecorationColor Color.red]
                    ["textDecorationColor" ==> "#ff0000"]

                test
                    "Text decoration color hex"
                    [TextDecorationColor (hex "00ff00") ]
                    ["textDecorationColor" ==> "#00ff00" ]

                test
                    "Text decoration color rgba"
                    [TextDecorationColor (rgba 255 128 128 0.5) ]
                    ["textDecorationColor" ==> "rgba(255, 128, 128, 0.500000)"]

                test
                    "Text decoration color transparent"
                    [TextDecorationColor Color.transparent]
                    ["textDecorationColor" ==> "rgba(0, 0, 0, 0.000000)"]

                test
                    "Text decoration color inherit"
                    [TextDecorationColor Inherit]
                    ["textDecorationColor" ==> "inherit"]

                test
                    "Text decoration color initial"
                    [TextDecorationColor Initial]
                    ["textDecorationColor" ==> "initial"]

                test
                    "Text decoration color unset"
                    [TextDecorationColor Unset]
                    ["textDecorationColor" ==> "unset"]
                    

                test
                    "Text decoration line none"
                    [TextDecorationLine None]
                    ["textDecorationLine" ==> "none"]

                test
                    "Text decoration line underline"
                    [TextDecorationLine Text.Underline]
                    ["textDecorationLine" ==> "underline"]

                test
                    "Text decoration line overline"
                    [TextDecorationLine Text.Overline]
                    ["textDecorationLine" ==> "overline"]

                test
                    "Text decoration line line-through"
                    [TextDecorationLine Text.LineThrough]
                    ["textDecorationLine" ==> "line-through"]

                test
                    "Text decoration line blink"
                    [TextDecorationLine Text.Blink]
                    ["textDecorationLine" ==> "blink"]

                test
                    "Text decoration line inherit"
                    [ TextDecorationLine Inherit ]
                    ["textDecorationLine" ==> "inherit"]

                test
                    "Text decoration line initial"
                    [ TextDecorationLine Initial ]
                    ["textDecorationLine" ==> "initial"]

                test
                    "Text decoration line unset"
                    [ TextDecorationLine Unset ]
                    ["textDecorationLine" ==> "unset"]

                test
                    "Text decorations multiple"
                    [TextDecorationLines [None; Text.Underline; Inherit; Unset; Text.Blink]]
                    ["textDecorationLine" ==> "none underline inherit unset blink"]

                test
                    "Text decoration skip none"
                    [TextDecorationSkip None]
                    ["textDecorationSkip" ==> "none"]

                test
                    "Text decoration skip objects"
                    [TextDecorationSkip Text.Objects]
                    ["textDecorationSkip" ==> "objects"]

                test
                    "Text decoration skip spaces"
                    [TextDecorationSkip Text.Spaces]
                    ["textDecorationSkip" ==> "spaces"]

                test
                    "Text decoration skip edges"
                    [TextDecorationSkip Text.Edges]
                    ["textDecorationSkip" ==> "edges"]

                test
                    "Text decoration skip box-decoration"
                    [TextDecorationSkip Text.BoxDecoration]
                    ["textDecorationSkip" ==> "box-decoration"]

                test
                    "Text decoration skip multiple - objects and spaces"
                    [TextDecorationSkips [ Text.Objects; Text.Spaces] ]
                    ["textDecorationSkip" ==> "objects spaces"]

                test
                    "Text decoration skip multiple - leading spaces and trailing spaces"
                    [TextDecorationSkips [Text.LeadingSpaces; Text.TrailingSpaces ]]
                    ["textDecorationSkip" ==> "leading-spaces trailing-spaces"]

                test
                    "Text decoration skip multiple - objects edges box-decoration"
                    [TextDecorationSkips [Text.Objects; Text.Edges; Text.BoxDecoration ]]
                    ["textDecorationSkip" ==> "objects edges box-decoration"]

                test
                    "Text decoration skip inherit"
                    [TextDecorationSkip Inherit]
                    ["textDecorationSkip" ==> "inherit"]

                test
                    "Text decoration skip initial"
                    [TextDecorationSkip Initial]
                    ["textDecorationSkip" ==> "initial"]

                test
                    "Text decoration skip unset"
                    [TextDecorationSkip Unset]
                    ["textDecorationSkip" ==> "unset"]

                test
                    "Text decoration skip unset"
                    [TextDecorationSkipInk Auto]
                    ["textDecorationSkipInk" ==> "auto"]

                test
                    "Text decoration skip All"
                    [TextDecorationSkipInk Text.DecorationSkipInk.All]
                    ["textDecorationSkipInk" ==> "all"]

                test
                    "Text decoration skip none"
                    [TextDecorationSkipInk None]
                    ["textDecorationSkipInk" ==> "none"]

                test
                    "Text decoration skipink inherit"
                    [TextDecorationSkipInk Inherit]
                    ["textDecorationSkipInk" ==> "inherit"]

                test
                    "Text decoration skipink unset"
                    [TextDecorationSkipInk Unset]
                    ["textDecorationSkipInk" ==> "unset"]

                test
                    "Text decoration skipink initial"
                    [TextDecorationSkipInk Initial]
                    ["textDecorationSkipInk" ==> "initial"]   
                
                test
                    "Text decoration style solid"
                    [TextDecorationStyle Text.Solid]
                    ["textDecorationStyle" ==> "solid"]

                test
                    "Text decoration style double"
                    [TextDecorationStyle Text.Double]
                    ["textDecorationStyle" ==> "double"]

                test
                    "Text decoration style dotted"
                    [TextDecorationStyle Text.Dotted]
                    ["textDecorationStyle" ==> "dotted"]

                test
                    "Text decoration style dashed"
                    [TextDecorationStyle Text.Dashed]
                    ["textDecorationStyle" ==> "dashed"]

                test
                    "Text decoration style wavy"
                    [TextDecorationStyle Text.Wavy]
                    ["textDecorationStyle" ==> "wavy"]

                test
                    "Text decoration style inherit"
                    [TextDecorationStyle Inherit]
                    ["textDecorationStyle" ==> "inherit"]

                test
                    "Text decoration style initial"
                    [TextDecorationStyle Initial]
                    ["textDecorationStyle" ==> "initial"]

                test
                    "Text decoration style unset"
                    [TextDecorationStyle Unset]
                    ["textDecorationStyle" ==> "unset"]
                
                test
                    "Text decoration thickness auto"
                    [ TextDecorationThickness Auto ]
                    [ "textDecorationThickness" ==> "auto" ]

                test
                    "Text decoration thickness from font"
                    [ TextDecorationThickness Text.FromFont ]
                    ["textDecorationThickness" ==> "from-font" ]

                test
                    "Text decoration thickness em"
                    [ TextDecorationThickness (em 0.1) ]
                    ["textDecorationThickness" ==> "0.1em" ]

                test
                    "Text decoration thickness px"
                    [ TextDecorationThickness (px 3) ]
                    ["textDecorationThickness" ==> "3px" ]

                test
                    "Text decoration thickness percent"
                    [ TextDecorationThickness (pct 10) ]
                    ["textDecorationThickness" ==> "10%" ]

                test
                    "Text decoration thickness inherit"
                    [ TextDecorationThickness Inherit ]
                    ["textDecorationThickness" ==> "inherit" ]

                test
                    "Text decoration thickness initial"
                    [ TextDecorationThickness Initial ]
                    ["textDecorationThickness" ==> "initial" ]

                test
                    "Text decoration thickness unset"
                    [ TextDecorationThickness Unset ]
                    ["textDecorationThickness" ==> "unset" ]

                test
                    "Text emphasis color hex"
                    [ TextEmphasisColor (hex "#555") ]
                    ["textEmphasisColor" ==> "#555"]
                    
                test
                    "Text emphasis color color name"
                    [ TextEmphasisColor Color.blue ]
                    ["textEmphasisColor" ==> "#0000ff"]
                    
                test
                    "Text emphasis color rgba"
                    [ TextEmphasisColor (rgba 90 200 160 0.8) ]
                    ["textEmphasisColor" ==> "rgba(90, 200, 160, 0.800000)"]
                    
                test
                    "Text emphasis color transparent"
                    [ TextEmphasisColor Color.transparent ]
                    ["textEmphasisColor" ==> "rgba(0, 0, 0, 0.000000)"]
                    
                test
                    "Text emphasis color inherit"
                    [ TextEmphasisColor Inherit ]
                    ["textEmphasisColor" ==> "inherit"]
                    
                test
                    "Text emphasis color Initial"
                    [ TextEmphasisColor Initial ]
                    ["textEmphasisColor" ==> "initial"]
                    
                test
                    "Text emphasis color unset"
                    [ TextEmphasisColor Unset ]
                    ["textEmphasisColor" ==> "unset"]
                    
                test
                    "Text emphasis position over right"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Over, Text.Position.Right)) ]
                    ["textEmphasisPosition" ==> "over right"]
                    
                test
                    "Text emphasis position over left"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Over, Text.Position.Left)) ]
                    ["textEmphasisPosition" ==> "over left"]
                    
                test
                    "Text emphasis position under right"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Under, Text.Position.Right)) ]
                    ["textEmphasisPosition" ==> "under right"]
                    
                test
                    "Text emphasis position under left"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Under, Text.Position.Left)) ]
                    ["textEmphasisPosition" ==> "under left"]
                    
                test
                    "Text emphasis position left over"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Left, Text.Position.Over)) ]
                    ["textEmphasisPosition" ==> "left over"]
                    
                test
                    "Text emphasis position right under"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Right, Text.Position.Under)) ]
                    ["textEmphasisPosition" ==> "right under"]
                    
                test
                    "Text emphasis position left under"
                    [ TextEmphasisPosition (Text.EmphasisPosition(Text.Position.Left, Text.Position.Under)) ]
                    ["textEmphasisPosition" ==> "left under"]
                    
                test
                    "Text emphasis position inherit"
                    [ TextEmphasisPosition Inherit ]
                    ["textEmphasisPosition" ==> "inherit"]
                    
                test
                    "Text emphasis position Initial"
                    [ TextEmphasisPosition Initial ]
                    ["textEmphasisPosition" ==> "initial"]
                    
                test
                    "Text emphasis position unset"
                    [ TextEmphasisPosition Unset ]
                    ["textEmphasisPosition" ==> "unset"]
                
                test
                    "Text Emphasis Style x"
                    [TextEmphasisStyle (Text.StringValue "x")]
                    ["textEmphasisStyle" ==> "'x'"]
                    
                test
                    "Text Emphasis Style *"
                    [TextEmphasisStyle (Text.StringValue "*")]
                    ["textEmphasisStyle" ==> "'*'"]
                    
                test
                    "Text Emphasis Style filled"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.Filled)]
                    ["textEmphasisStyle" ==> "filled"]
                    
                test
                    "Text Emphasis Style open"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.Open)]
                    ["textEmphasisStyle" ==> "open"]
            
                test
                    "Text Emphasis Style circle"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.Circle)]
                    ["textEmphasisStyle" ==> "circle"]
                    
                test
                    "Text Emphasis Style double circle"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.DoubleCircle)]
                    ["textEmphasisStyle" ==> "double-circle"]
            
                test
                    "Text Emphasis Style triangle"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.Triangle)]
                    ["textEmphasisStyle" ==> "triangle"]
            
                test
                    "Text Emphasis Style filled sesame"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.FilledSesame)]
                    ["textEmphasisStyle" ==> "filled sesame"]
                    
                test
                    "Text Emphasis Style open sesame"
                    [TextEmphasisStyle (Text.KeywordValue Text.Keyword.OpenSesame)]
                    ["textEmphasisStyle" ==> "open sesame"]
                
                test
                    "Text emphasis style inherit"
                    [ TextEmphasisStyle Inherit ]
                    ["textEmphasisStyle" ==> "inherit"]
                    
                test
                    "Text emphasis style Initial"
                    [ TextEmphasisStyle Initial ]
                    ["textEmphasisStyle" ==> "initial"]
                    
                test
                    "Text emphasis style unset"
                    [ TextEmphasisStyle Unset ]
                    ["textEmphasisStyle" ==> "unset"]

                test
                    "Text shadow single"
                    [ TextShadow (Text.Shadow(px 1, px 1, px 2, Color.black)) ]
                    ["textShadow" ==> "1px 1px 2px #000000"]
                    
                test
                    "Text shadow multiple"
                    [ TextShadows
                          [
                            Text.Shadow(px 1, px 1, px 2, Color.black)
                            Text.Shadow(px 10, px -10, px 20, Color.red)
                          ]
                    ]
                    ["textShadow" ==> "1px 1px 2px #000000, 10px -10px 20px #ff0000"]
                    
                test
                    "Text shadow style inherit"
                    [ TextShadow Inherit ]
                    ["textShadow" ==> "inherit"]
                    
                test
                    "Text shadow style Initial"
                    [ TextShadow Initial ]
                    ["textShadow" ==> "initial"]
                    
                test
                    "Text shadow style unset"
                    [ TextShadow Unset ]
                    ["textShadow" ==> "unset"]
                    
                test
                    "Text underline offset auto"
                    [ TextUnderlineOffset Auto ]
                    ["textUnderlineOffset" ==> "auto"]
                    
                test
                    "Text underline offset em"
                    [ TextUnderlineOffset (em 3.0) ]
                    ["textUnderlineOffset" ==> "3.0em"]
                    
                test
                    "Text underline offset px"
                    [ TextUnderlineOffset (px 10) ]
                    ["textUnderlineOffset" ==> "10px"]
                    
                test
                    "Text underline offset percent"
                    [ TextUnderlineOffset (pct 10) ]
                    ["textUnderlineOffset" ==> "10%"]
                    
                test
                    "Text underline offset inherit"
                    [ TextUnderlineOffset Inherit ]
                    ["textUnderlineOffset" ==> "inherit"]
                    
                test
                    "Text underline offset Initial"
                    [ TextUnderlineOffset Initial ]
                    ["textUnderlineOffset" ==> "initial"]
                    
                test
                    "Text underline offset unset"
                    [ TextUnderlineOffset Unset ]
                    ["textUnderlineOffset" ==> "unset"]
                       
                test
                    "Text underline position from-font"
                    [ TextUnderlinePosition Text.UnderlinePosition.FromFont ]
                    ["textUnderlinePosition" ==> "from-font"]
                    
                test
                    "Text underline position Under"
                    [ TextUnderlinePosition Text.UnderlinePosition.Under ]
                    ["textUnderlinePosition" ==> "under"]
                    
                test
                    "Text underline position left"
                    [ TextUnderlinePosition Text.UnderlinePosition.Left ]
                    ["textUnderlinePosition" ==> "left"]          
                    
                test
                    "Text underline position right"
                    [ TextUnderlinePosition Text.UnderlinePosition.Right ]
                    ["textUnderlinePosition" ==> "right"]     
                    
                test
                    "Text underline position auto-pos"
                    [ TextUnderlinePosition Text.AutoPos ]
                    ["textUnderlinePosition" ==> "auto-pos"]
                    
                test
                    "Text underline position above"
                    [ TextUnderlinePosition Text.UnderlinePosition.Above ]
                    ["textUnderlinePosition" ==> "above"]
                    
                test
                    "Text underline position below"
                    [ TextUnderlinePosition Text.UnderlinePosition.Below ]
                    ["textUnderlinePosition" ==> "below"]
                    
                test
                    "Text underline positions under left"
                    [ TextUnderlinePositions (Text.UnderlinePosition.Under, Text.UnderlinePosition.Left) ]
                    ["textUnderlinePosition" ==> "under left"]
                    
                test
                    "Text underline positions right under"
                    [ TextUnderlinePositions (Text.UnderlinePosition.Right, Text.UnderlinePosition.Under) ]
                    ["textUnderlinePosition" ==> "right under"]
                    
                test
                    "Text underline position auto"
                    [ TextUnderlinePosition Auto ]
                    ["textUnderlinePosition" ==> "auto"]     
                    
                test
                    "Text underline position inherit"
                    [ TextUnderlinePosition Inherit ]
                    ["textUnderlinePosition" ==> "inherit"]
                    
                test
                    "Text underline position Initial"
                    [ TextUnderlinePosition Initial ]
                    ["textUnderlinePosition" ==> "initial"]
                    
                test
                    "Text underline position unset"
                    [ TextUnderlinePosition Unset ]
                    ["textUnderlinePosition" ==> "unset"]
                    
                test
                    "Text indent mm"
                    [ TextIndent (mm 3.0) ]
                    ["textIndent" ==> "3.0mm"]
                    
                test
                    "Text indent px"
                    [ TextIndent (px 40) ]
                    ["textIndent" ==> "40px"]
                    
                test
                    "Text indent percent"
                    [ TextIndent (pct 15) ]
                    ["textIndent" ==> "15%"]
                
                test
                    "Text indent hanging"
                    [ TextIndents [ em 5.0; Text.Hanging; ] ]
                    ["textIndent" ==> "5.0em hanging"]
                    
                test
                    "Text indent each line"
                    [ TextIndents [ em 5.0; Text.EachLine; ] ]
                    ["textIndent" ==> "5.0em each-line"]
                    
                test
                    "Text indent hanging each line"
                    [ TextIndents [ em 5.0; Text.Hanging; Text.EachLine ] ]
                    ["textIndent" ==> "5.0em hanging each-line"]
                    
                test
                    "Text indent inherit"
                    [ TextIndent Inherit ]
                    ["textIndent" ==> "inherit"]
                    
                test
                    "Text indent Initial"
                    [ TextIndent Initial ]
                    ["textIndent" ==> "initial"]
                    
                test
                    "Text indent unset"
                    [ TextIndent Unset ]
                    ["textIndent" ==> "unset"]
                    
                test
                    "Text overflow clip"
                    [ TextOverflow Text.Clip ]
                    ["textOverflow" ==> "clip"]
                    
                test
                    "Text overflow ellipsis"
                    [ TextOverflow Text.Ellipsis ]
                    ["textOverflow" ==> "ellipsis"]
                    
                test
                    "Text overflow -"
                    [ TextOverflow (Text.String "-") ]
                    ["textOverflow" ==> "\"-\""]
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                test
                    "Quotes none"
                    [ Quotes None ]
                    ["quotes" ==> "none"]
                    
                test
                    "Quotes Auto"
                    [ Quotes Auto ]
                    ["quotes" ==> "auto"]
                    
                test
                    "Quotes strings"
                    [ Quotes (Quotes.String("<<", ">>")) ]
                    ["quotes" ==> "\"<<\" \">>\""]
                    
                test
                    "Quotes inherit"
                    [ Quotes Inherit ]
                    ["quotes" ==> "inherit"]
                    
                test
                    "Quotes Initial"
                    [ Quotes Initial ]
                    ["quotes" ==> "initial"]
                    
                test
                    "Quotes unset"
                    [ Quotes Unset ]
                    ["quotes" ==> "unset"]
            ]