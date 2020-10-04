namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Font =
    let tests =
        testList "Fonts"
            [
                test
                    "Font size XX-Small"
                    [ FontSize Font.XxSmall ]
                    [ "fontSize" ==> "xx-small" ]

                test
                    "Font size X-Small"
                    [ FontSize Font.XSmall ]
                    [ "fontSize" ==> "x-small" ]

                test
                    "Font size small"
                    [ FontSize Font.Small ]
                    [ "fontSize" ==> "small" ]

                test
                    "Font size medium"
                    [ FontSize Font.Medium ]
                    [ "fontSize" ==> "medium" ]

                test
                    "Font size large"
                    [ FontSize Font.Large ]
                    [ "fontSize" ==> "large" ]

                test
                    "Font size x-large"
                    [ FontSize Font.XLarge ]
                    [ "fontSize" ==> "x-large" ]

                test
                    "Font size xx-large"
                    [ FontSize Font.XxLarge ]
                    [ "fontSize" ==> "xx-large" ]

                test
                    "Font size xxx-large"
                    [ FontSize Font.XxxLarge ]
                    [ "fontSize" ==> "xxx-large" ]

                test
                    "Font size smaller"
                    [ FontSize Font.Smaller ]
                    [ "fontSize" ==> "smaller" ]

                test
                    "Font size larger"
                    [ FontSize Font.Larger ]
                    [ "fontSize" ==> "larger" ]

                test
                    "Font size pixels"
                    [ FontSize (px 18) ]
                    [ "fontSize" ==> "18px" ]

                test
                    "Font size em"
                    [ FontSize (em 0.8) ]
                    [ "fontSize" ==> "0.8em" ]

                test
                    "Font size percentage"
                    [ FontSize (pct 80) ]
                    [ "fontSize" ==> "80%" ]

                test
                    "Font size inherit"
                    [ FontSize Inherit ]
                    [ "fontSize" ==> "inherit" ]

                test
                    "Font size initial"
                    [ FontSize Initial ]
                    [ "fontSize" ==> "initial" ]

                test
                    "Font size unset"
                    [ FontSize Unset ]
                    [ "fontSize" ==> "unset" ]

                test
                    "Font stretch normal"
                    [ FontStretch Font.Stretch.Normal ]
                    [ "fontStretch" ==> "normal" ]

                test
                    "Font stretch ultra-condensed"
                    [ FontStretch Font.Stretch.UltraCondensed ]
                    [ "fontStretch" ==> "ultra-condensed" ]

                test
                     "Font stretch extra-condensed"
                    [ FontStretch Font.Stretch.ExtraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]

                test "Font stretch extra-condensed"
                    [ FontStretch Font.Stretch.ExtraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]

                test "Font stretch condensed"
                    [ FontStretch Font.Stretch.Condensed ]
                    [ "fontStretch" ==> "condensed" ]

                test "Font stretch semi-condensed"
                    [ FontStretch Font.Stretch.SemiCondensed ]
                    [ "fontStretch" ==> "semi-condensed" ]

                test "Font stretch expanded"
                    [ FontStretch Font.Stretch.Expanded]
                    [ "fontStretch" ==> "expanded" ]

                test "Font stretch extra-expanded"
                    [ FontStretch Font.Stretch.ExtraExpanded]
                    [ "fontStretch" ==> "extra-expanded" ]

                test "Font stretch ultra-expanded"
                    [ FontStretch Font.Stretch.UltraExpanded]
                    [ "fontStretch" ==> "ultra-expanded" ]

                test "Font stretch percent"
                    [ FontStretch (pct 200) ]
                    [ "fontStretch" ==> "200%" ]

                test "Font stretch inherit"
                    [ FontStretch Inherit ]
                    [ "fontStretch" ==> "inherit" ]

                test "Font stretch initial"
                    [ FontStretch Initial ]
                    [ "fontStretch" ==> "initial" ]

                test "Font stretch unset"
                    [ FontStretch Unset ]
                    [ "fontStretch" ==> "unset" ]

                test
                    "Font style normal"
                    [ FontStyle Font.Normal]
                    [ "fontStyle" ==> "normal"]

                test
                    "Font style italic"
                    [ FontStyle Font.Italic]
                    [ "fontStyle" ==> "italic"]

                test
                    "Font style oblicque 90"
                    [ FontStyle (Font.Oblique (deg 90.0))]
                    [ "fontStyle" ==> "oblique 90.00deg"]

                test
                    "Font style oblique -90"
                    [ FontStyle (Font.Oblique (deg -90.0))]
                    [ "fontStyle" ==> "oblique -90.00deg"]

                test
                    "Font style inherit"
                    [ FontStyle Inherit ]
                    [ "fontStyle" ==> "inherit" ]

                test
                    "Font style initial"
                    [ FontStyle Initial ]
                    [ "fontStyle" ==> "initial" ]

                test
                    "Font style unset"
                    [ FontStyle Unset ]
                    [ "fontStyle" ==> "unset" ]

                test
                    "Font weight normal"
                    [ FontWeight Font.Weight.Normal ]
                    [ "fontWeight" ==> "normal"]

                test
                    "Font weight bold"
                    [ FontWeight Font.Weight.Bold ]
                    [ "fontWeight" ==> "bold"]

                test
                    "Font weight lighter"
                    [ FontWeight Font.Weight.Lighter ]
                    [ "fontWeight" ==> "lighter"]

                test
                    "Font weight bolder"
                    [ FontWeight Font.Weight.Bolder ]
                    [ "fontWeight" ==> "bolder"]

                test
                    "Font weight value"
                    [ FontWeight (Font.Weight.Value 500) ]
                    [ "fontWeight" ==> "500"]

                test
                    "Font weight inherit"
                    [ FontWeight Inherit ]
                    [ "fontWeight" ==> "inherit"]

                test
                    "Font weight initial"
                    [ FontWeight Initial ]
                    [ "fontWeight" ==> "initial"]

                test
                    "Font weight unset"
                    [ FontWeight Unset ]
                    [ "fontWeight" ==> "unset"]

                test
                    "Line height normal"
                    [ LineHeight Font.LineHeight.Normal ]
                    [ "lineHeight" ==> "normal" ]

                test
                    "Line height value"
                    [ LineHeight (Font.LineHeight.Value 2.5) ]
                    [ "lineHeight" ==> "2.5" ]

                test
                    "Line height em"
                    [ LineHeight (em 3.0) ]
                    [ "lineHeight" ==> "3.0em" ]

                test
                    "Line height pixel"
                    [ LineHeight (px 3) ]
                    [ "lineHeight" ==> "3px" ]

                test
                    "Line height percent"
                    [ LineHeight (pct 34) ]
                    [ "lineHeight" ==> "34%" ]

                test
                    "Line height initial"
                    [ LineHeight Initial ]
                    [ "lineHeight" ==> "initial" ]

                test
                    "Line height inherit"
                    [ LineHeight Inherit ]
                    [ "lineHeight" ==> "inherit" ]

                test
                    "Line height unset"
                    [ LineHeight Unset ]
                    [ "lineHeight" ==> "unset" ]

                test
                     "Font family serif"
                     [ FontFamily Font.Serif ]
                     [ "fontFamily" ==> "serif" ]

                test
                     "Font family sans-serif"
                     [ FontFamily Font.SansSerif ]
                     [ "fontFamily" ==> "sans-serif" ]

                test
                     "Font family monospace"
                     [ FontFamily Font.Monospace ]
                     [ "fontFamily" ==> "monospace" ]

                test
                     "Font family cursive"
                     [ FontFamily Font.Cursive ]
                     [ "fontFamily" ==> "cursive" ]

                test
                     "Font family arial"
                     [ FontFamily (Font.Custom "arial") ]
                     [ "fontFamily" ==> "arial" ]

                test
                     "Font family initial"
                     [ FontFamily Initial ]
                     [ "fontFamily" ==> "initial" ]

                test
                     "Font family inherit"
                     [ FontFamily Inherit ]
                     [ "fontFamily" ==> "inherit" ]

                test
                     "Font family unset"
                     [ FontFamily Unset ]
                     [ "fontFamily" ==> "unset" ]

                test
                    "Font families"
                    [ FontFamilies [ Font.Serif; Font.Monospace ] ]
                    [ "fontFamily" ==> "serif, monospace" ]

                test
                    "font feature setting On"
                    [ FontFeatureSetting (Font.Liga Font.On) ]
                    [ "fontFeatureSettings" ==> "\"liga\" On" ]

                test
                    "font feature setting Off"
                    [ FontFeatureSetting (Font.Liga Font.Off) ]
                    [ "fontFeatureSettings" ==> "\"liga\" Off" ]

                test
                    "font feature setting initial"
                    [ FontFeatureSetting Initial ]
                    [ "fontFeatureSettings" ==> "initial" ]

                test
                    "font feature setting inherit"
                    [ FontFeatureSetting Inherit ]
                    [ "fontFeatureSettings" ==> "inherit" ]

                test
                    "font feature setting unset"
                    [ FontFeatureSetting Unset ]
                    [ "fontFeatureSettings" ==> "unset" ]

                test
                    "font feature setting multiple on"
                    [
                        FontFeatureSettings
                            [
                                Font.Smcp Font.On
                                Font.Onum Font.On
                            ]
                    ]
                    [ "fontFeatureSettings" ==> "\"smcp\" On, \"onum\" On" ]

                test
                    "font feature setting multiple off"
                    [
                        FontFeatureSettings
                            [
                                Font.Smcp Font.Off
                                Font.Onum Font.Off
                            ]
                        ]
                    [ "fontFeatureSettings" ==> "\"smcp\" Off, \"onum\" Off" ]


                test
                    "Font variant numeric normal"
                    [ FontVariantNumeric Font.VariantNumeric.Normal]
                    ["fontVariantNumeric" ==> "normal"]

                test
                    "Font variant numeric ordinal"
                    [ FontVariantNumeric Font.VariantNumeric.Ordinal]
                    ["fontVariantNumeric" ==> "ordinal"]

                test
                    "Font variant numeric slashed zero"
                    [ FontVariantNumeric Font.VariantNumeric.SlashedZero]
                    ["fontVariantNumeric" ==> "slashed-zero"]

                test
                    "Font variant numeric lining nums"
                    [ FontVariantNumeric Font.VariantNumeric.LiningNums]
                    ["fontVariantNumeric" ==> "lining-nums"]

                test
                    "Font variant numeric old style nums"
                    [ FontVariantNumeric Font.VariantNumeric.OldstyleNums]
                    ["fontVariantNumeric" ==> "oldstyle-nums"]

                test
                    "Font variant numeric tabular nums"
                    [ FontVariantNumeric Font.VariantNumeric.TabularNums]
                    ["fontVariantNumeric" ==> "tabular-nums"]

                test
                    "Font variant numeric diagonal fractions"
                    [ FontVariantNumeric Font.VariantNumeric.DiagonalFractions]
                    ["fontVariantNumeric" ==> "diagonal-fractions"]

                test
                    "Font variant numeric stacked fractions"
                    [ FontVariantNumeric Font.VariantNumeric.StackedFractions]
                    ["fontVariantNumeric" ==> "stacked-fractions"]

                test
                    "Font variant numerics multiple"
                    [
                        FontVariantNumerics
                            [
                                Font.VariantNumeric.OldstyleNums
                                Font.VariantNumeric.StackedFractions
                            ]
                    ]
                    ["fontVariantNumeric" ==> "oldstyle-nums stacked-fractions"]

                test
                    "Font variant numeric inherit"
                    [ FontVariantNumeric Inherit ]
                    [ "fontVariantNumeric" ==> "inherit" ]

                test
                    "Font variant numeric initial"
                    [ FontVariantNumeric Initial]
                    [ "fontVariantNumeric" ==> "initial" ]

                test
                    "Font variant numeric unset"
                    [ FontVariantNumeric Unset ]
                    [ "fontVariantNumeric" ==> "unset" ]

                test
                    "Font variant caps normal"
                    [ FontVariantCaps Font.VariantCaps.Normal]
                    ["fontVariantCaps" ==> "normal"]

                test
                    "Font variant caps small caps"
                    [ FontVariantCaps Font.VariantCaps.SmallCaps]
                    ["fontVariantCaps" ==> "small-caps"]

                test
                    "Font variant caps  all small caps"
                    [ FontVariantCaps Font.VariantCaps.AllSmallCaps]
                    ["fontVariantCaps" ==> "all-small-caps"]

                test
                    "Font variant caps petite caps"
                    [ FontVariantCaps Font.VariantCaps.PetiteCaps]
                    ["fontVariantCaps" ==> "petite-caps"]

                test
                    "Font variant caps all petite caps"
                    [ FontVariantCaps Font.VariantCaps.AllPetiteCaps]
                    ["fontVariantCaps" ==> "all-petite-caps"]

                test
                    "Font variant caps unicase"
                    [ FontVariantCaps Font.VariantCaps.Unicase]
                    ["fontVariantCaps" ==> "unicase"]

                test
                    "Font variant caps titling caps"
                    [ FontVariantCaps Font.VariantCaps.TitlingCaps]
                    ["fontVariantCaps" ==> "titling-caps"]

                test
                    "Font variant caps initial"
                    [ FontVariantCaps Initial ]
                    [ "fontVariantCaps" ==> "initial"]

                test
                    "Font variant caps inherit"
                    [ FontVariantCaps Inherit ]
                    ["fontVariantCaps" ==> "inherit"]

                test
                    "Font variant caps unset"
                    [ FontVariantCaps Unset ]
                    ["fontVariantCaps" ==> "unset" ]

                test
                    "Font variant east asian normal"
                    [ FontVariantEastAsian Font.VariantEastAsian.Normal]
                    ["fontVariantEastAsian" ==> "normal"]

                test
                    "Font variant east asian ruby"
                    [ FontVariantEastAsian Font.Ruby]
                    ["fontVariantEastAsian" ==> "ruby"]

                test
                    "Font variant east asian  jis78"
                    [ FontVariantEastAsian Font.Jis78]
                    ["fontVariantEastAsian" ==> "jis78"]

                test
                    "Font variant east asian jis83"
                    [ FontVariantEastAsian Font.Jis83]
                    ["fontVariantEastAsian" ==> "jis83"]

                test
                    "Font variant east asian jis90"
                    [ FontVariantEastAsian Font.Jis90]
                    ["fontVariantEastAsian" ==> "jis90"]

                test
                    "Font variant east asian jis04"
                    [ FontVariantEastAsian Font.Jis04]
                    ["fontVariantEastAsian" ==> "jis04"]

                test
                    "Font variant east asian simplified"
                    [ FontVariantEastAsian Font.Simplified]
                    ["fontVariantEastAsian" ==> "simplified"]

                test
                    "Font variant east asian traditional"
                    [ FontVariantEastAsian Font.Traditional]
                    ["fontVariantEastAsian" ==> "traditional"]

                test
                    "Font variant east asian full width"
                    [ FontVariantEastAsian Font.FullWidth]
                    ["fontVariantEastAsian" ==> "full-width"]

                test
                    "Font variant east asian  proportional widt"
                    [ FontVariantEastAsian Font.ProportionalWidth]
                    ["fontVariantEastAsian" ==> "proportional-width"]

                test
                    "Font variant east asian multiple"
                    [
                        FontVariantEastAsians
                            [
                                Font.Ruby
                                Font.FullWidth
                                Font.Jis83
                            ]
                    ]
                    ["fontVariantEastAsian" ==> "ruby full-width jis83"]

                test
                    "Font variant ligatures normal"
                    [ FontVariantLigatures Font.VariantLigatures.Normal]
                    ["fontVariantLigatures" ==> "normal"]

                test
                    "Font variant ligatures none"
                    [ FontVariantLigatures None]
                    ["fontVariantLigatures" ==> "none"]

                test
                    "Font variant ligatures common"
                    [ FontVariantLigatures Font.CommonLigatures]
                    ["fontVariantLigatures" ==> "common-ligatures"]

                test
                    "Font variant ligatures no common"
                    [ FontVariantLigatures Font.NoCommonLigatures]
                    ["fontVariantLigatures" ==> "no-common-ligatures"]

                test
                    "Font variant ligatures discretionary"
                    [ FontVariantLigatures Font.DiscretionaryLigatures]
                    ["fontVariantLigatures" ==> "discretionary-ligatures"]

                test
                    "Font variant ligatures no discretionary"
                    [ FontVariantLigatures Font.NoDiscretionaryLigatures]
                    ["fontVariantLigatures" ==> "no-discretionary-ligatures"]

                test
                    "Font variant ligatures historical"
                    [ FontVariantLigatures Font.HistoricalLigatures]
                    ["fontVariantLigatures" ==> "historical-ligatures"]

                test
                    "Font variant ligatures no historical"
                    [ FontVariantLigatures Font.NoHistoricalLigatures]
                    ["fontVariantLigatures" ==> "no-historical-ligatures"]

                test
                    "Font variant ligatures contextual"
                    [ FontVariantLigatures Font.Contextual]
                    ["fontVariantLigatures" ==> "contextual"]

                test
                    "Font variant ligatures no contextual"
                    [ FontVariantLigatures Font.NoContextual]
                    ["fontVariantLigatures" ==> "no-contextual"]

                test
                    "Font variant ligatures no initial"
                    [ FontVariantLigatures Initial ]
                    ["fontVariantLigatures" ==> "initial"]

                test
                    "Font variant ligatures inherit"
                    [ FontVariantLigatures Inherit]
                    ["fontVariantLigatures" ==> "inherit"]

                test
                    "Font variant ligatures no unset"
                    [ FontVariantLigatures Unset]
                    ["fontVariantLigatures" ==> "unset"]
        ]