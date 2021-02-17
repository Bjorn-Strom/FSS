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
                    "Font synthesis none"
                    [ FontSynthesis.None ]
                    [ "fontSynthesis" ==> "none" ]
                test
                    "Font synthesis weight"
                    [ FontSynthesis.Weight ]
                    [ "fontSynthesis" ==> "weight" ]
                test
                    "Font synthesis style"
                    [ FontSynthesis.Style ]
                    [ "fontSynthesis" ==> "style" ]
                test
                    "Font synthesis weight style"
                    [ FontSynthesis.WeightStyle ]
                    [ "fontSynthesis" ==> "weight style" ]
                test
                    "Font language override string"
                    [ FontLanguageOverride.Value "ENG" ]
                    [ "fontLanguageOverride" ==> "\"ENG\""]
                test
                    "Font language override inherit"
                    [ FontLanguageOverride.Inherit ]
                    [ "fontLanguageOverride" ==> "inherit" ]
                test
                    "Font language override initial"
                    [ FontLanguageOverride.Initial ]
                    [ "fontLanguageOverride" ==> "initial" ]
                test
                    "Font language override unset"
                    [ FontLanguageOverride.Unset ]
                    [ "fontLanguageOverride" ==> "unset" ]
                test
                    "Font kerning none"
                    [ FontKerning.None ]
                    [ "fontKerning" ==> "none" ]
                test
                    "Font kerning auto"
                    [ FontKerning.Auto ]
                    [ "fontKerning" ==> "auto" ]
                test
                    "Font kerning normal"
                    [ FontKerning.Normal ]
                    [ "fontKerning" ==> "normal" ]
                test
                    "Font size XX-Small"
                    [ FontSize.XxSmall ]
                    [ "fontSize" ==> "xx-small" ]
                test
                    "Font size X-Small"
                    [ FontSize.XSmall ]
                    [ "fontSize" ==> "x-small" ]
                test
                    "Font size small"
                    [ FontSize.Small ]
                    [ "fontSize" ==> "small" ]
                test
                    "Font size medium"
                    [ FontSize.Medium ]
                    [ "fontSize" ==> "medium" ]
                test
                    "Font size large"
                    [ FontSize.Large ]
                    [ "fontSize" ==> "large" ]
                test
                    "Font size x-large"
                    [ FontSize.XLarge ]
                    [ "fontSize" ==> "x-large" ]
                test
                    "Font size xx-large"
                    [ FontSize.XxLarge ]
                    [ "fontSize" ==> "xx-large" ]
                test
                    "Font size xxx-large"
                    [ FontSize.XxxLarge ]
                    [ "fontSize" ==> "xxx-large" ]
                test
                    "Font size smaller"
                    [ FontSize.Smaller ]
                    [ "fontSize" ==> "smaller" ]
                test
                    "Font size larger"
                    [ FontSize.Larger ]
                    [ "fontSize" ==> "larger" ]
                test
                    "Font size pixels"
                    [ FontSize' (px 18) ]
                    [ "fontSize" ==> "18px" ]
                test
                    "Font size em"
                    [ FontSize' (em 0.8) ]
                    [ "fontSize" ==> "0.8em" ]
                test
                    "Font size percentage"
                    [ FontSize' (pct 80) ]
                    [ "fontSize" ==> "80%" ]
                test
                    "Font size inherit"
                    [ FontSize.Inherit ]
                    [ "fontSize" ==> "inherit" ]
                test
                    "Font size initial"
                    [ FontSize.Initial ]
                    [ "fontSize" ==> "initial" ]
                test
                    "Font size unset"
                    [ FontSize.Unset ]
                    [ "fontSize" ==> "unset" ]
                test
                    "Font stretch normal"
                    [ FontStretch.Normal ]
                    [ "fontStretch" ==> "normal" ]
                test
                    "Font stretch ultra-condensed"
                    [ FontStretch.UltraCondensed ]
                    [ "fontStretch" ==> "ultra-condensed" ]
                test
                     "Font stretch extra-condensed"
                    [ FontStretch.ExtraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                test
                    "Font stretch extra-condensed"
                    [ FontStretch.ExtraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                test
                    "Font stretch condensed"
                    [ FontStretch.Condensed ]
                    [ "fontStretch" ==> "condensed" ]
                test
                    "Font stretch semi-condensed"
                    [ FontStretch.SemiCondensed ]
                    [ "fontStretch" ==> "semi-condensed" ]
                test
                    "Font stretch expanded"
                    [ FontStretch.Expanded]
                    [ "fontStretch" ==> "expanded" ]
                test
                    "Font stretch extra-expanded"
                    [ FontStretch.ExtraExpanded]
                    [ "fontStretch" ==> "extra-expanded" ]
                test
                    "Font stretch ultra-expanded"
                    [ FontStretch.UltraExpanded]
                    [ "fontStretch" ==> "ultra-expanded" ]
                test
                    "Font stretch percent"
                    [ FontStretch' (pct 200) ]
                    [ "fontStretch" ==> "200%" ]
                test
                    "Font stretch inherit"
                    [ FontStretch.Inherit ]
                    [ "fontStretch" ==> "inherit" ]
                test
                    "Font stretch initial"
                    [ FontStretch.Initial ]
                    [ "fontStretch" ==> "initial" ]
                test
                    "Font stretch unset"
                    [ FontStretch.Unset ]
                    [ "fontStretch" ==> "unset" ]
                test
                    "Font style normal"
                    [ FontStyle.Normal]
                    [ "fontStyle" ==> "normal"]
                test
                    "Font style italic"
                    [ FontStyle.Italic]
                    [ "fontStyle" ==> "italic"]
                test
                    "Font style oblicque 90"
                    [ FontStyle.Oblique (deg 90.0)]
                    [ "fontStyle" ==> "oblique 90.00deg"]
                test
                    "Font style oblique -90"
                    [ FontStyle.Oblique (deg -90.0)]
                    [ "fontStyle" ==> "oblique -90.00deg"]
                test
                    "Font style inherit"
                    [ FontStyle.Inherit ]
                    [ "fontStyle" ==> "inherit" ]
                test
                    "Font style initial"
                    [ FontStyle.Initial ]
                    [ "fontStyle" ==> "initial" ]
                test
                    "Font style unset"
                    [ FontStyle.Unset ]
                    [ "fontStyle" ==> "unset" ]
                test
                    "Font weight normal"
                    [ FontWeight.Normal ]
                    [ "fontWeight" ==> "normal"]
                test
                    "Font weight bold"
                    [ FontWeight.Bold ]
                    [ "fontWeight" ==> "bold"]
                test
                    "Font weight lighter"
                    [ FontWeight.Lighter ]
                    [ "fontWeight" ==> "lighter"]
                test
                    "Font weight bolder"
                    [ FontWeight.Bolder ]
                    [ "fontWeight" ==> "bolder"]
                test
                    "Font weight value"
                    [ FontWeight' (CssInt 500) ]
                    [ "fontWeight" ==> "500"]
                test
                    "Font weight inherit"
                    [ FontWeight.Inherit ]
                    [ "fontWeight" ==> "inherit"]
                test
                    "Font weight initial"
                    [ FontWeight.Initial ]
                    [ "fontWeight" ==> "initial"]
                test
                    "Font weight unset"
                    [ FontWeight.Unset ]
                    [ "fontWeight" ==> "unset"]
                test
                    "Line height normal"
                    [ LineHeight.Normal ]
                    [ "lineHeight" ==> "normal" ]
                test
                    "Line height value"
                    [ LineHeight' (CssFloat 2.5) ]
                    [ "lineHeight" ==> "2.5" ]
                test
                    "Line height em"
                    [ LineHeight' (em 3.0) ]
                    [ "lineHeight" ==> "3.0em" ]
                test
                    "Line height pixel"
                    [ LineHeight' (px 3) ]
                    [ "lineHeight" ==> "3px" ]
                test
                    "Line height percent"
                    [ LineHeight' (pct 34) ]
                    [ "lineHeight" ==> "34%" ]
                test
                    "Line height initial"
                    [ LineHeight.Initial ]
                    [ "lineHeight" ==> "initial" ]
                test
                    "Line height inherit"
                    [ LineHeight.Inherit ]
                    [ "lineHeight" ==> "inherit" ]
                test
                    "Line height unset"
                    [ LineHeight.Unset ]
                    [ "lineHeight" ==> "unset" ]
                test
                    "Line break loose"
                    [ LineBreak.Loose ]
                    [ "lineBreak" ==> "loose" ]
                test
                    "Line break strict"
                    [ LineBreak.Strict ]
                    [ "lineBreak" ==> "strict" ]
                test
                    "Line break anywhere"
                    [ LineBreak.Anywhere ]
                    [ "lineBreak" ==> "anywhere" ]
                test
                    "Line break normal"
                    [ LineBreak.Normal ]
                    [ "lineBreak" ==> "normal" ]
                test
                    "Line break auto"
                    [ LineBreak.Auto ]
                    [ "lineBreak" ==> "auto" ]
                test
                    "Line break initial"
                    [ LineBreak.Initial ]
                    [ "lineBreak" ==> "initial" ]
                test
                    "Line break inherit"
                    [ LineBreak.Inherit ]
                    [ "lineBreak" ==> "inherit" ]
                test
                    "Line break unset"
                    [ LineBreak.Unset ]
                    [ "lineBreak" ==> "unset" ]
                test
                    "Letter spacing px"
                    [ LetterSpacing' (px 10) ]
                    [ "letterSpacing" ==> "10px" ]
                test
                    "Letter spacing initial"
                    [ LetterSpacing.Initial ]
                    [ "letterSpacing" ==> "initial" ]
                test
                    "Letter spacing inherit"
                    [ LetterSpacing.Inherit ]
                    [ "letterSpacing" ==> "inherit" ]
                test
                    "Letter spacing unset"
                    [ LetterSpacing.Unset ]
                    [ "letterSpacing" ==> "unset" ]
                test
                    "Letter spacing normal"
                    [ LetterSpacing.Normal ]
                    [ "letterSpacing" ==> "normal" ]
                test
                     "Font family serif"
                     [ FontFamily.Serif ]
                     [ "fontFamily" ==> "serif" ]
                test
                     "Font family sans-serif"
                     [ FontFamily.SansSerif ]
                     [ "fontFamily" ==> "sans-serif" ]
                test
                     "Font family monospace"
                     [ FontFamily.Monospace ]
                     [ "fontFamily" ==> "monospace" ]
                test
                     "Font family cursive"
                     [ FontFamily.Cursive ]
                     [ "fontFamily" ==> "cursive" ]
                test
                     "Font family arial"
                     [ FontFamily.Custom "arial" ]
                     [ "fontFamily" ==> "arial" ]
                test
                     "Font family initial"
                     [ FontFamily.Initial ]
                     [ "fontFamily" ==> "initial" ]
                test
                     "Font family inherit"
                     [ FontFamily.Inherit ]
                     [ "fontFamily" ==> "inherit" ]
                test
                     "Font family unset"
                     [ FontFamily.Unset ]
                     [ "fontFamily" ==> "unset" ]
                test
                    "Font families"
                    [ FontFamily.Values ([ FontTypes.Serif; FontTypes.Monospace ]) ]
                    [ "fontFamily" ==> "serif, monospace" ]
                test
                    "font feature setting On"
                    [ FontFeatureSetting.Liga FontTypes.On ]
                    [ "fontFeatureSettings" ==> "\"liga\" On" ]
                test
                    "font feature setting Off"
                    [ FontFeatureSetting.Liga FontTypes.Off ]
                    [ "fontFeatureSettings" ==> "\"liga\" Off" ]
                test
                    "font feature setting initial"
                    [ FontFeatureSetting.Initial ]
                    [ "fontFeatureSettings" ==> "initial" ]
                test
                    "font feature setting inherit"
                    [ FontFeatureSetting.Inherit ]
                    [ "fontFeatureSettings" ==> "inherit" ]
                test
                    "font feature setting unset"
                    [ FontFeatureSetting.Unset ]
                    [ "fontFeatureSettings" ==> "unset" ]
                test
                    "Font variant numeric normal"
                    [ FontVariantNumeric.Normal]
                    ["fontVariantNumeric" ==> "normal"]
                test
                    "Font variant numeric ordinal"
                    [ FontVariantNumeric.Ordinal]
                    ["fontVariantNumeric" ==> "ordinal"]
                test
                    "Font variant numeric slashed zero"
                    [ FontVariantNumeric.SlashedZero]
                    ["fontVariantNumeric" ==> "slashed-zero"]
                test
                    "Font variant numeric lining nums"
                    [ FontVariantNumeric.LiningNums]
                    ["fontVariantNumeric" ==> "lining-nums"]
                test
                    "Font variant numeric old style nums"
                    [ FontVariantNumeric.OldstyleNums]
                    ["fontVariantNumeric" ==> "oldstyle-nums"]
                test
                    "Font variant numeric tabular nums"
                    [ FontVariantNumeric.TabularNums]
                    ["fontVariantNumeric" ==> "tabular-nums"]
                test
                    "Font variant numeric diagonal fractions"
                    [ FontVariantNumeric.DiagonalFractions]
                    ["fontVariantNumeric" ==> "diagonal-fractions"]
                test
                    "Font variant numeric stacked fractions"
                    [ FontVariantNumeric.StackedFractions]
                    ["fontVariantNumeric" ==> "stacked-fractions"]
                test
                    "Font variant numeric inherit"
                    [ FontVariantNumeric.Inherit ]
                    [ "fontVariantNumeric" ==> "inherit" ]
                test
                    "Font variant numeric initial"
                    [ FontVariantNumeric.Initial]
                    [ "fontVariantNumeric" ==> "initial" ]
                test
                    "Font variant numeric unset"
                    [ FontVariantNumeric.Unset ]
                    [ "fontVariantNumeric" ==> "unset" ]
                test
                    "Font variant caps normal"
                    [ FontVariantCaps.Normal]
                    ["fontVariantCaps" ==> "normal"]
                test
                    "Font variant caps small caps"
                    [ FontVariantCaps.SmallCaps]
                    ["fontVariantCaps" ==> "small-caps"]
                test
                    "Font variant caps  all small caps"
                    [ FontVariantCaps.AllSmallCaps]
                    ["fontVariantCaps" ==> "all-small-caps"]
                test
                    "Font variant caps petite caps"
                    [ FontVariantCaps.PetiteCaps]
                    ["fontVariantCaps" ==> "petite-caps"]
                test
                    "Font variant caps all petite caps"
                    [ FontVariantCaps.AllPetiteCaps]
                    ["fontVariantCaps" ==> "all-petite-caps"]
                test
                    "Font variant caps unicase"
                    [ FontVariantCaps.Unicase]
                    ["fontVariantCaps" ==> "unicase"]
                test
                    "Font variant caps titling caps"
                    [ FontVariantCaps.TitlingCaps]
                    ["fontVariantCaps" ==> "titling-caps"]
                test
                    "Font variant caps initial"
                    [ FontVariantCaps.Initial ]
                    [ "fontVariantCaps" ==> "initial"]
                test
                    "Font variant caps inherit"
                    [ FontVariantCaps.Inherit ]
                    ["fontVariantCaps" ==> "inherit"]
                test
                    "Font variant caps unset"
                    [ FontVariantCaps.Unset ]
                    ["fontVariantCaps" ==> "unset" ]
                test
                    "Font variant east asian normal"
                    [ FontVariantEastAsian.Normal]
                    ["fontVariantEastAsian" ==> "normal"]
                test
                    "Font variant east asian ruby"
                    [ FontVariantEastAsian.Ruby]
                    ["fontVariantEastAsian" ==> "ruby"]
                test
                    "Font variant east asian  jis78"
                    [ FontVariantEastAsian.Jis78]
                    ["fontVariantEastAsian" ==> "jis78"]
                test
                    "Font variant east asian jis83"
                    [ FontVariantEastAsian.Jis83]
                    ["fontVariantEastAsian" ==> "jis83"]
                test
                    "Font variant east asian jis90"
                    [ FontVariantEastAsian.Jis90]
                    ["fontVariantEastAsian" ==> "jis90"]
                test
                    "Font variant east asian jis04"
                    [ FontVariantEastAsian.Jis04]
                    ["fontVariantEastAsian" ==> "jis04"]
                test
                    "Font variant east asian simplified"
                    [ FontVariantEastAsian.Simplified]
                    ["fontVariantEastAsian" ==> "simplified"]
                test
                    "Font variant east asian traditional"
                    [ FontVariantEastAsian.Traditional]
                    ["fontVariantEastAsian" ==> "traditional"]
                test
                    "Font variant east asian full width"
                    [ FontVariantEastAsian.FullWidth]
                    ["fontVariantEastAsian" ==> "full-width"]
                test
                    "Font variant east asian  proportional widt"
                    [ FontVariantEastAsian.ProportionalWidth]
                    ["fontVariantEastAsian" ==> "proportional-width"]
                test
                    "Font variant ligatures normal"
                    [ FontVariantLigatures.Normal]
                    ["fontVariantLigatures" ==> "normal"]
                test
                    "Font variant ligatures none"
                    [ FontVariantLigatures.None]
                    ["fontVariantLigatures" ==> "none"]
                test
                    "Font variant ligatures common"
                    [ FontVariantLigatures.CommonLigatures]
                    ["fontVariantLigatures" ==> "common-ligatures"]
                test
                    "Font variant ligatures no common"
                    [ FontVariantLigatures.NoCommonLigatures]
                    ["fontVariantLigatures" ==> "no-common-ligatures"]
                test
                    "Font variant ligatures discretionary"
                    [ FontVariantLigatures.DiscretionaryLigatures]
                    ["fontVariantLigatures" ==> "discretionary-ligatures"]
                test
                    "Font variant ligatures no discretionary"
                    [ FontVariantLigatures.NoDiscretionaryLigatures]
                    ["fontVariantLigatures" ==> "no-discretionary-ligatures"]
                test
                    "Font variant ligatures historical"
                    [ FontVariantLigatures.HistoricalLigatures]
                    ["fontVariantLigatures" ==> "historical-ligatures"]
                test
                    "Font variant ligatures no historical"
                    [ FontVariantLigatures.NoHistoricalLigatures]
                    ["fontVariantLigatures" ==> "no-historical-ligatures"]
                test
                    "Font variant ligatures contextual"
                    [ FontVariantLigatures.Contextual]
                    ["fontVariantLigatures" ==> "contextual"]
                test
                    "Font variant ligatures no contextual"
                    [ FontVariantLigatures.NoContextual]
                    ["fontVariantLigatures" ==> "no-contextual"]
                test
                    "Font variant ligatures no initial"
                    [ FontVariantLigatures.Initial ]
                    ["fontVariantLigatures" ==> "initial"]
                test
                    "Font variant ligatures inherit"
                    [ FontVariantLigatures.Inherit]
                    ["fontVariantLigatures" ==> "inherit"]
                test
                    "Font variant ligatures no unset"
                    [ FontVariantLigatures.Unset]
                    ["fontVariantLigatures" ==> "unset"]
                test
                    "Font variant position super"
                    [ FontVariantPosition.Super ]
                    ["fontVariantPosition" ==> "super"]
                test
                    "Font variant position sub"
                    [ FontVariantPosition.Sub]
                    ["fontVariantPosition" ==> "sub"]
                test
                    "Font variant position unset"
                    [ FontVariantPosition.Unset]
                    ["fontVariantPosition" ==> "unset"]
                test
                    "Font variant position initial"
                    [ FontVariantPosition.Initial ]
                    ["fontVariantPosition" ==> "initial"]
                test
                    "Font variant position inherit"
                    [ FontVariantPosition.Inherit]
                    ["fontVariantPosition" ==> "inherit"]
                test
                    "Font variant position no unset"
                    [ FontVariantPosition.Unset]
                    ["fontVariantPosition" ==> "unset"]
        ]