namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module Font =
    let tests =
        testList "Fonts"
            [
                testCase
                    "Font synthesis none"
                    [ FontSynthesis.none ]
                    [ "fontSynthesis" ==> "none" ]
                testCase
                    "Font synthesis weight"
                    [ FontSynthesis.weight ]
                    [ "fontSynthesis" ==> "weight" ]
                testCase
                    "Font synthesis style"
                    [ FontSynthesis.style ]
                    [ "fontSynthesis" ==> "style" ]
                testCase
                    "Font synthesis weight style"
                    [ FontSynthesis.weightStyle ]
                    [ "fontSynthesis" ==> "weight style" ]
                testCase
                    "Font language override string"
                    [ FontLanguageOverride.value "ENG" ]
                    [ "fontLanguageOverride" ==> "\"ENG\""]
                testCase
                    "Font language override inherit"
                    [ FontLanguageOverride.inherit' ]
                    [ "fontLanguageOverride" ==> "inherit" ]
                testCase
                    "Font language override initial"
                    [ FontLanguageOverride.initial ]
                    [ "fontLanguageOverride" ==> "initial" ]
                testCase
                    "Font language override unset"
                    [ FontLanguageOverride.unset ]
                    [ "fontLanguageOverride" ==> "unset" ]
                testCase
                    "Font kerning none"
                    [ FontKerning.none ]
                    [ "fontKerning" ==> "none" ]
                testCase
                    "Font kerning auto"
                    [ FontKerning.auto ]
                    [ "fontKerning" ==> "auto" ]
                testCase
                    "Font kerning normal"
                    [ FontKerning.normal ]
                    [ "fontKerning" ==> "normal" ]
                testCase
                    "Font size XX-Small"
                    [ FontSize.xxSmall ]
                    [ "fontSize" ==> "xx-small" ]
                testCase
                    "Font size X-Small"
                    [ FontSize.xSmall ]
                    [ "fontSize" ==> "x-small" ]
                testCase
                    "Font size small"
                    [ FontSize.small ]
                    [ "fontSize" ==> "small" ]
                testCase
                    "Font size medium"
                    [ FontSize.medium ]
                    [ "fontSize" ==> "medium" ]
                testCase
                    "Font size large"
                    [ FontSize.large ]
                    [ "fontSize" ==> "large" ]
                testCase
                    "Font size x-large"
                    [ FontSize.xLarge ]
                    [ "fontSize" ==> "x-large" ]
                testCase
                    "Font size xx-large"
                    [ FontSize.xxLarge ]
                    [ "fontSize" ==> "xx-large" ]
                testCase
                    "Font size xxx-large"
                    [ FontSize.xxxLarge ]
                    [ "fontSize" ==> "xxx-large" ]
                testCase
                    "Font size smaller"
                    [ FontSize.smaller ]
                    [ "fontSize" ==> "smaller" ]
                testCase
                    "Font size larger"
                    [ FontSize.larger ]
                    [ "fontSize" ==> "larger" ]
                testCase
                    "Font size pixels"
                    [ FontSize' (px 18) ]
                    [ "fontSize" ==> "18px" ]
                testCase
                    "Font size em"
                    [ FontSize' (em 0.8) ]
                    [ "fontSize" ==> "0.8em" ]
                testCase
                    "Font size percentage"
                    [ FontSize' (pct 80) ]
                    [ "fontSize" ==> "80%" ]
                testCase
                    "Font size inherit"
                    [ FontSize.inherit' ]
                    [ "fontSize" ==> "inherit" ]
                testCase
                    "Font size initial"
                    [ FontSize.initial ]
                    [ "fontSize" ==> "initial" ]
                testCase
                    "Font size unset"
                    [ FontSize.unset ]
                    [ "fontSize" ==> "unset" ]
                testCase
                    "Font stretch normal"
                    [ FontStretch.normal ]
                    [ "fontStretch" ==> "normal" ]
                testCase
                    "Font stretch ultra-condensed"
                    [ FontStretch.ultraCondensed ]
                    [ "fontStretch" ==> "ultra-condensed" ]
                testCase
                     "Font stretch extra-condensed"
                    [ FontStretch.extraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                testCase
                    "Font stretch extra-condensed"
                    [ FontStretch.extraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                testCase
                    "Font stretch condensed"
                    [ FontStretch.condensed ]
                    [ "fontStretch" ==> "condensed" ]
                testCase
                    "Font stretch semi-condensed"
                    [ FontStretch.semiCondensed ]
                    [ "fontStretch" ==> "semi-condensed" ]
                testCase
                    "Font stretch expanded"
                    [ FontStretch.expanded]
                    [ "fontStretch" ==> "expanded" ]
                testCase
                    "Font stretch extra-expanded"
                    [ FontStretch.extraExpanded]
                    [ "fontStretch" ==> "extra-expanded" ]
                testCase
                    "Font stretch ultra-expanded"
                    [ FontStretch.ultraExpanded]
                    [ "fontStretch" ==> "ultra-expanded" ]
                testCase
                    "Font stretch percent"
                    [ FontStretch' (pct 200) ]
                    [ "fontStretch" ==> "200%" ]
                testCase
                    "Font stretch inherit"
                    [ FontStretch.inherit' ]
                    [ "fontStretch" ==> "inherit" ]
                testCase
                    "Font stretch initial"
                    [ FontStretch.initial ]
                    [ "fontStretch" ==> "initial" ]
                testCase
                    "Font stretch unset"
                    [ FontStretch.unset ]
                    [ "fontStretch" ==> "unset" ]
                testCase
                    "Font style normal"
                    [ FontStyle.normal]
                    [ "fontStyle" ==> "normal"]
                testCase
                    "Font style italic"
                    [ FontStyle.italic]
                    [ "fontStyle" ==> "italic"]
                testCase
                    "Font style oblicque 90"
                    [ FontStyle.oblique (deg 90.0)]
                    [ "fontStyle" ==> "oblique 90.00deg"]
                testCase
                    "Font style oblique -90"
                    [ FontStyle.oblique (deg -90.0)]
                    [ "fontStyle" ==> "oblique -90.00deg"]
                testCase
                    "Font style inherit"
                    [ FontStyle.inherit' ]
                    [ "fontStyle" ==> "inherit" ]
                testCase
                    "Font style initial"
                    [ FontStyle.initial ]
                    [ "fontStyle" ==> "initial" ]
                testCase
                    "Font style unset"
                    [ FontStyle.unset ]
                    [ "fontStyle" ==> "unset" ]
                testCase
                    "Font weight normal"
                    [ FontWeight.normal ]
                    [ "fontWeight" ==> "normal"]
                testCase
                    "Font weight bold"
                    [ FontWeight.bold ]
                    [ "fontWeight" ==> "bold"]
                testCase
                    "Font weight lighter"
                    [ FontWeight.lighter ]
                    [ "fontWeight" ==> "lighter"]
                testCase
                    "Font weight bolder"
                    [ FontWeight.bolder ]
                    [ "fontWeight" ==> "bolder"]
                testCase
                    "Font weight value"
                    [ FontWeight' (FssTypes.CssInt 500) ]
                    [ "fontWeight" ==> "500"]
                testCase
                    "Font weight inherit"
                    [ FontWeight.inherit' ]
                    [ "fontWeight" ==> "inherit"]
                testCase
                    "Font weight initial"
                    [ FontWeight.initial ]
                    [ "fontWeight" ==> "initial"]
                testCase
                    "Font weight unset"
                    [ FontWeight.unset ]
                    [ "fontWeight" ==> "unset"]
                testCase
                    "Line height normal"
                    [ LineHeight.normal ]
                    [ "lineHeight" ==> "normal" ]
                testCase
                    "Line height value"
                    [ LineHeight' (FssTypes.CssFloat 2.5) ]
                    [ "lineHeight" ==> "2.5" ]
                testCase
                    "Line height em"
                    [ LineHeight' (em 3.0) ]
                    [ "lineHeight" ==> "3.0em" ]
                testCase
                    "Line height pixel"
                    [ LineHeight' (px 3) ]
                    [ "lineHeight" ==> "3px" ]
                testCase
                    "Line height percent"
                    [ LineHeight' (pct 34) ]
                    [ "lineHeight" ==> "34%" ]
                testCase
                    "Line height initial"
                    [ LineHeight.initial ]
                    [ "lineHeight" ==> "initial" ]
                testCase
                    "Line height inherit"
                    [ LineHeight.inherit' ]
                    [ "lineHeight" ==> "inherit" ]
                testCase
                    "Line height unset"
                    [ LineHeight.unset ]
                    [ "lineHeight" ==> "unset" ]
                testCase
                    "Line break loose"
                    [ LineBreak.loose ]
                    [ "lineBreak" ==> "loose" ]
                testCase
                    "Line break strict"
                    [ LineBreak.strict ]
                    [ "lineBreak" ==> "strict" ]
                testCase
                    "Line break anywhere"
                    [ LineBreak.anywhere ]
                    [ "lineBreak" ==> "anywhere" ]
                testCase
                    "Line break normal"
                    [ LineBreak.normal ]
                    [ "lineBreak" ==> "normal" ]
                testCase
                    "Line break auto"
                    [ LineBreak.auto ]
                    [ "lineBreak" ==> "auto" ]
                testCase
                    "Line break initial"
                    [ LineBreak.initial ]
                    [ "lineBreak" ==> "initial" ]
                testCase
                    "Line break inherit"
                    [ LineBreak.inherit' ]
                    [ "lineBreak" ==> "inherit" ]
                testCase
                    "Line break unset"
                    [ LineBreak.unset ]
                    [ "lineBreak" ==> "unset" ]
                testCase
                    "Letter spacing px"
                    [ LetterSpacing' (px 10) ]
                    [ "letterSpacing" ==> "10px" ]
                testCase
                    "Letter spacing initial"
                    [ LetterSpacing.initial ]
                    [ "letterSpacing" ==> "initial" ]
                testCase
                    "Letter spacing inherit"
                    [ LetterSpacing.inherit' ]
                    [ "letterSpacing" ==> "inherit" ]
                testCase
                    "Letter spacing unset"
                    [ LetterSpacing.unset ]
                    [ "letterSpacing" ==> "unset" ]
                testCase
                    "Letter spacing normal"
                    [ LetterSpacing.normal ]
                    [ "letterSpacing" ==> "normal" ]
                testCase
                     "Font family serif"
                     [ FontFamily.serif ]
                     [ "fontFamily" ==> "serif" ]
                testCase
                     "Font family sans-serif"
                     [ FontFamily.sansSerif ]
                     [ "fontFamily" ==> "sans-serif" ]
                testCase
                     "Font family monospace"
                     [ FontFamily.monospace ]
                     [ "fontFamily" ==> "monospace" ]
                testCase
                     "Font family cursive"
                     [ FontFamily.cursive ]
                     [ "fontFamily" ==> "cursive" ]
                testCase
                     "Font family arial"
                     [ FontFamily.custom "arial" ]
                     [ "fontFamily" ==> "arial" ]
                testCase
                     "Font family initial"
                     [ FontFamily.initial ]
                     [ "fontFamily" ==> "initial" ]
                testCase
                     "Font family inherit"
                     [ FontFamily.inherit' ]
                     [ "fontFamily" ==> "inherit" ]
                testCase
                     "Font family unset"
                     [ FontFamily.unset ]
                     [ "fontFamily" ==> "unset" ]
                testCase
                    "Font families"
                    [ FontFamily.values ([ FssTypes.Font.Serif; FssTypes.Font.Monospace ]) ]
                    [ "fontFamily" ==> "serif, monospace" ]
                testCase
                    "font feature setting On"
                    [ FontFeatureSetting.liga FssTypes.Font.On ]
                    [ "fontFeatureSettings" ==> "\"liga\" On" ]
                testCase
                    "font feature setting Off"
                    [ FontFeatureSetting.liga FssTypes.Font.Off ]
                    [ "fontFeatureSettings" ==> "\"liga\" Off" ]
                testCase
                    "font feature setting initial"
                    [ FontFeatureSetting.initial ]
                    [ "fontFeatureSettings" ==> "initial" ]
                testCase
                    "font feature setting inherit"
                    [ FontFeatureSetting.inherit' ]
                    [ "fontFeatureSettings" ==> "inherit" ]
                testCase
                    "font feature setting unset"
                    [ FontFeatureSetting.unset ]
                    [ "fontFeatureSettings" ==> "unset" ]
                testCase
                    "Font variant numeric normal"
                    [ FontVariantNumeric.normal]
                    ["fontVariantNumeric" ==> "normal"]
                testCase
                    "Font variant numeric ordinal"
                    [ FontVariantNumeric.ordinal]
                    ["fontVariantNumeric" ==> "ordinal"]
                testCase
                    "Font variant numeric slashed zero"
                    [ FontVariantNumeric.slashedZero]
                    ["fontVariantNumeric" ==> "slashed-zero"]
                testCase
                    "Font variant numeric lining nums"
                    [ FontVariantNumeric.liningNums]
                    ["fontVariantNumeric" ==> "lining-nums"]
                testCase
                    "Font variant numeric old style nums"
                    [ FontVariantNumeric.oldstyleNums]
                    ["fontVariantNumeric" ==> "oldstyle-nums"]
                testCase
                    "Font variant numeric tabular nums"
                    [ FontVariantNumeric.tabularNums]
                    ["fontVariantNumeric" ==> "tabular-nums"]
                testCase
                    "Font variant numeric diagonal fractions"
                    [ FontVariantNumeric.diagonalFractions]
                    ["fontVariantNumeric" ==> "diagonal-fractions"]
                testCase
                    "Font variant numeric stacked fractions"
                    [ FontVariantNumeric.stackedFractions]
                    ["fontVariantNumeric" ==> "stacked-fractions"]
                testCase
                    "Font variant numeric inherit"
                    [ FontVariantNumeric.inherit' ]
                    [ "fontVariantNumeric" ==> "inherit" ]
                testCase
                    "Font variant numeric initial"
                    [ FontVariantNumeric.initial]
                    [ "fontVariantNumeric" ==> "initial" ]
                testCase
                    "Font variant numeric unset"
                    [ FontVariantNumeric.unset ]
                    [ "fontVariantNumeric" ==> "unset" ]
                testCase
                    "Font variant caps normal"
                    [ FontVariantCaps.normal]
                    ["fontVariantCaps" ==> "normal"]
                testCase
                    "Font variant caps small caps"
                    [ FontVariantCaps.smallCaps]
                    ["fontVariantCaps" ==> "small-caps"]
                testCase
                    "Font variant caps  all small caps"
                    [ FontVariantCaps.allSmallCaps]
                    ["fontVariantCaps" ==> "all-small-caps"]
                testCase
                    "Font variant caps petite caps"
                    [ FontVariantCaps.petiteCaps]
                    ["fontVariantCaps" ==> "petite-caps"]
                testCase
                    "Font variant caps all petite caps"
                    [ FontVariantCaps.allPetiteCaps]
                    ["fontVariantCaps" ==> "all-petite-caps"]
                testCase
                    "Font variant caps unicase"
                    [ FontVariantCaps.unicase]
                    ["fontVariantCaps" ==> "unicase"]
                testCase
                    "Font variant caps titling caps"
                    [ FontVariantCaps.titlingCaps]
                    ["fontVariantCaps" ==> "titling-caps"]
                testCase
                    "Font variant caps initial"
                    [ FontVariantCaps.initial ]
                    [ "fontVariantCaps" ==> "initial"]
                testCase
                    "Font variant caps inherit"
                    [ FontVariantCaps.inherit' ]
                    ["fontVariantCaps" ==> "inherit"]
                testCase
                    "Font variant caps unset"
                    [ FontVariantCaps.unset ]
                    ["fontVariantCaps" ==> "unset" ]
                testCase
                    "Font variant east asian normal"
                    [ FontVariantEastAsian.normal]
                    ["fontVariantEastAsian" ==> "normal"]
                testCase
                    "Font variant east asian ruby"
                    [ FontVariantEastAsian.ruby]
                    ["fontVariantEastAsian" ==> "ruby"]
                testCase
                    "Font variant east asian  jis78"
                    [ FontVariantEastAsian.jis78]
                    ["fontVariantEastAsian" ==> "jis78"]
                testCase
                    "Font variant east asian jis83"
                    [ FontVariantEastAsian.jis83]
                    ["fontVariantEastAsian" ==> "jis83"]
                testCase
                    "Font variant east asian jis90"
                    [ FontVariantEastAsian.jis90]
                    ["fontVariantEastAsian" ==> "jis90"]
                testCase
                    "Font variant east asian jis04"
                    [ FontVariantEastAsian.jis04]
                    ["fontVariantEastAsian" ==> "jis04"]
                testCase
                    "Font variant east asian simplified"
                    [ FontVariantEastAsian.simplified]
                    ["fontVariantEastAsian" ==> "simplified"]
                testCase
                    "Font variant east asian traditional"
                    [ FontVariantEastAsian.traditional]
                    ["fontVariantEastAsian" ==> "traditional"]
                testCase
                    "Font variant east asian full width"
                    [ FontVariantEastAsian.fullWidth]
                    ["fontVariantEastAsian" ==> "full-width"]
                testCase
                    "Font variant east asian  proportional widt"
                    [ FontVariantEastAsian.proportionalWidth]
                    ["fontVariantEastAsian" ==> "proportional-width"]
                testCase
                    "Font variant ligatures normal"
                    [ FontVariantLigatures.normal]
                    ["fontVariantLigatures" ==> "normal"]
                testCase
                    "Font variant ligatures none"
                    [ FontVariantLigatures.none]
                    ["fontVariantLigatures" ==> "none"]
                testCase
                    "Font variant ligatures common"
                    [ FontVariantLigatures.commonLigatures]
                    ["fontVariantLigatures" ==> "common-ligatures"]
                testCase
                    "Font variant ligatures no common"
                    [ FontVariantLigatures.noCommonLigatures]
                    ["fontVariantLigatures" ==> "no-common-ligatures"]
                testCase
                    "Font variant ligatures discretionary"
                    [ FontVariantLigatures.discretionaryLigatures]
                    ["fontVariantLigatures" ==> "discretionary-ligatures"]
                testCase
                    "Font variant ligatures no discretionary"
                    [ FontVariantLigatures.noDiscretionaryLigatures]
                    ["fontVariantLigatures" ==> "no-discretionary-ligatures"]
                testCase
                    "Font variant ligatures historical"
                    [ FontVariantLigatures.historicalLigatures]
                    ["fontVariantLigatures" ==> "historical-ligatures"]
                testCase
                    "Font variant ligatures no historical"
                    [ FontVariantLigatures.noHistoricalLigatures]
                    ["fontVariantLigatures" ==> "no-historical-ligatures"]
                testCase
                    "Font variant ligatures contextual"
                    [ FontVariantLigatures.contextual]
                    ["fontVariantLigatures" ==> "contextual"]
                testCase
                    "Font variant ligatures no contextual"
                    [ FontVariantLigatures.noContextual]
                    ["fontVariantLigatures" ==> "no-contextual"]
                testCase
                    "Font variant ligatures no initial"
                    [ FontVariantLigatures.initial ]
                    ["fontVariantLigatures" ==> "initial"]
                testCase
                    "Font variant ligatures inherit"
                    [ FontVariantLigatures.inherit']
                    ["fontVariantLigatures" ==> "inherit"]
                testCase
                    "Font variant ligatures no unset"
                    [ FontVariantLigatures.unset]
                    ["fontVariantLigatures" ==> "unset"]
                testCase
                    "Font variant position super"
                    [ FontVariantPosition.super ]
                    ["fontVariantPosition" ==> "super"]
                testCase
                    "Font variant position sub"
                    [ FontVariantPosition.sub]
                    ["fontVariantPosition" ==> "sub"]
                testCase
                    "Font variant position unset"
                    [ FontVariantPosition.unset]
                    ["fontVariantPosition" ==> "unset"]
                testCase
                    "Font variant position initial"
                    [ FontVariantPosition.initial ]
                    ["fontVariantPosition" ==> "initial"]
                testCase
                    "Font variant position inherit"
                    [ FontVariantPosition.inherit']
                    ["fontVariantPosition" ==> "inherit"]
                testCase
                    "Font variant position no unset"
                    [ FontVariantPosition.unset]
                    ["fontVariantPosition" ==> "unset"]
        ]