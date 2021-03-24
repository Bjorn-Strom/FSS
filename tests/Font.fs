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
                    [ FontSynthesis.none ]
                    [ "fontSynthesis" ==> "none" ]
                test
                    "Font synthesis weight"
                    [ FontSynthesis.weight ]
                    [ "fontSynthesis" ==> "weight" ]
                test
                    "Font synthesis style"
                    [ FontSynthesis.style ]
                    [ "fontSynthesis" ==> "style" ]
                test
                    "Font synthesis weight style"
                    [ FontSynthesis.weightStyle ]
                    [ "fontSynthesis" ==> "weight style" ]
                test
                    "Font language override string"
                    [ FontLanguageOverride.value "ENG" ]
                    [ "fontLanguageOverride" ==> "\"ENG\""]
                test
                    "Font language override inherit"
                    [ FontLanguageOverride.inherit' ]
                    [ "fontLanguageOverride" ==> "inherit" ]
                test
                    "Font language override initial"
                    [ FontLanguageOverride.initial ]
                    [ "fontLanguageOverride" ==> "initial" ]
                test
                    "Font language override unset"
                    [ FontLanguageOverride.unset ]
                    [ "fontLanguageOverride" ==> "unset" ]
                test
                    "Font kerning none"
                    [ FontKerning.none ]
                    [ "fontKerning" ==> "none" ]
                test
                    "Font kerning auto"
                    [ FontKerning.auto ]
                    [ "fontKerning" ==> "auto" ]
                test
                    "Font kerning normal"
                    [ FontKerning.normal ]
                    [ "fontKerning" ==> "normal" ]
                test
                    "Font size XX-Small"
                    [ FontSize.xxSmall ]
                    [ "fontSize" ==> "xx-small" ]
                test
                    "Font size X-Small"
                    [ FontSize.xSmall ]
                    [ "fontSize" ==> "x-small" ]
                test
                    "Font size small"
                    [ FontSize.small ]
                    [ "fontSize" ==> "small" ]
                test
                    "Font size medium"
                    [ FontSize.medium ]
                    [ "fontSize" ==> "medium" ]
                test
                    "Font size large"
                    [ FontSize.large ]
                    [ "fontSize" ==> "large" ]
                test
                    "Font size x-large"
                    [ FontSize.xLarge ]
                    [ "fontSize" ==> "x-large" ]
                test
                    "Font size xx-large"
                    [ FontSize.xxLarge ]
                    [ "fontSize" ==> "xx-large" ]
                test
                    "Font size xxx-large"
                    [ FontSize.xxxLarge ]
                    [ "fontSize" ==> "xxx-large" ]
                test
                    "Font size smaller"
                    [ FontSize.smaller ]
                    [ "fontSize" ==> "smaller" ]
                test
                    "Font size larger"
                    [ FontSize.larger ]
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
                    [ FontSize.inherit' ]
                    [ "fontSize" ==> "inherit" ]
                test
                    "Font size initial"
                    [ FontSize.initial ]
                    [ "fontSize" ==> "initial" ]
                test
                    "Font size unset"
                    [ FontSize.unset ]
                    [ "fontSize" ==> "unset" ]
                test
                    "Font stretch normal"
                    [ FontStretch.normal ]
                    [ "fontStretch" ==> "normal" ]
                test
                    "Font stretch ultra-condensed"
                    [ FontStretch.ultraCondensed ]
                    [ "fontStretch" ==> "ultra-condensed" ]
                test
                     "Font stretch extra-condensed"
                    [ FontStretch.extraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                test
                    "Font stretch extra-condensed"
                    [ FontStretch.extraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                test
                    "Font stretch condensed"
                    [ FontStretch.condensed ]
                    [ "fontStretch" ==> "condensed" ]
                test
                    "Font stretch semi-condensed"
                    [ FontStretch.semiCondensed ]
                    [ "fontStretch" ==> "semi-condensed" ]
                test
                    "Font stretch expanded"
                    [ FontStretch.expanded]
                    [ "fontStretch" ==> "expanded" ]
                test
                    "Font stretch extra-expanded"
                    [ FontStretch.extraExpanded]
                    [ "fontStretch" ==> "extra-expanded" ]
                test
                    "Font stretch ultra-expanded"
                    [ FontStretch.ultraExpanded]
                    [ "fontStretch" ==> "ultra-expanded" ]
                test
                    "Font stretch percent"
                    [ FontStretch' (pct 200) ]
                    [ "fontStretch" ==> "200%" ]
                test
                    "Font stretch inherit"
                    [ FontStretch.inherit' ]
                    [ "fontStretch" ==> "inherit" ]
                test
                    "Font stretch initial"
                    [ FontStretch.initial ]
                    [ "fontStretch" ==> "initial" ]
                test
                    "Font stretch unset"
                    [ FontStretch.unset ]
                    [ "fontStretch" ==> "unset" ]
                test
                    "Font style normal"
                    [ FontStyle.normal]
                    [ "fontStyle" ==> "normal"]
                test
                    "Font style italic"
                    [ FontStyle.italic]
                    [ "fontStyle" ==> "italic"]
                test
                    "Font style oblicque 90"
                    [ FontStyle.oblique (deg 90.0)]
                    [ "fontStyle" ==> "oblique 90.00deg"]
                test
                    "Font style oblique -90"
                    [ FontStyle.oblique (deg -90.0)]
                    [ "fontStyle" ==> "oblique -90.00deg"]
                test
                    "Font style inherit"
                    [ FontStyle.inherit' ]
                    [ "fontStyle" ==> "inherit" ]
                test
                    "Font style initial"
                    [ FontStyle.initial ]
                    [ "fontStyle" ==> "initial" ]
                test
                    "Font style unset"
                    [ FontStyle.unset ]
                    [ "fontStyle" ==> "unset" ]
                test
                    "Font weight normal"
                    [ FontWeight.normal ]
                    [ "fontWeight" ==> "normal"]
                test
                    "Font weight bold"
                    [ FontWeight.bold ]
                    [ "fontWeight" ==> "bold"]
                test
                    "Font weight lighter"
                    [ FontWeight.lighter ]
                    [ "fontWeight" ==> "lighter"]
                test
                    "Font weight bolder"
                    [ FontWeight.bolder ]
                    [ "fontWeight" ==> "bolder"]
                test
                    "Font weight value"
                    [ FontWeight' (FssTypes.CssInt 500) ]
                    [ "fontWeight" ==> "500"]
                test
                    "Font weight inherit"
                    [ FontWeight.inherit' ]
                    [ "fontWeight" ==> "inherit"]
                test
                    "Font weight initial"
                    [ FontWeight.initial ]
                    [ "fontWeight" ==> "initial"]
                test
                    "Font weight unset"
                    [ FontWeight.unset ]
                    [ "fontWeight" ==> "unset"]
                test
                    "Line height normal"
                    [ LineHeight.normal ]
                    [ "lineHeight" ==> "normal" ]
                test
                    "Line height value"
                    [ LineHeight' (FssTypes.CssFloat 2.5) ]
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
                    [ LineHeight.initial ]
                    [ "lineHeight" ==> "initial" ]
                test
                    "Line height inherit"
                    [ LineHeight.inherit' ]
                    [ "lineHeight" ==> "inherit" ]
                test
                    "Line height unset"
                    [ LineHeight.unset ]
                    [ "lineHeight" ==> "unset" ]
                test
                    "Line break loose"
                    [ LineBreak.loose ]
                    [ "lineBreak" ==> "loose" ]
                test
                    "Line break strict"
                    [ LineBreak.strict ]
                    [ "lineBreak" ==> "strict" ]
                test
                    "Line break anywhere"
                    [ LineBreak.anywhere ]
                    [ "lineBreak" ==> "anywhere" ]
                test
                    "Line break normal"
                    [ LineBreak.normal ]
                    [ "lineBreak" ==> "normal" ]
                test
                    "Line break auto"
                    [ LineBreak.auto ]
                    [ "lineBreak" ==> "auto" ]
                test
                    "Line break initial"
                    [ LineBreak.initial ]
                    [ "lineBreak" ==> "initial" ]
                test
                    "Line break inherit"
                    [ LineBreak.inherit' ]
                    [ "lineBreak" ==> "inherit" ]
                test
                    "Line break unset"
                    [ LineBreak.unset ]
                    [ "lineBreak" ==> "unset" ]
                test
                    "Letter spacing px"
                    [ LetterSpacing' (px 10) ]
                    [ "letterSpacing" ==> "10px" ]
                test
                    "Letter spacing initial"
                    [ LetterSpacing.initial ]
                    [ "letterSpacing" ==> "initial" ]
                test
                    "Letter spacing inherit"
                    [ LetterSpacing.inherit' ]
                    [ "letterSpacing" ==> "inherit" ]
                test
                    "Letter spacing unset"
                    [ LetterSpacing.unset ]
                    [ "letterSpacing" ==> "unset" ]
                test
                    "Letter spacing normal"
                    [ LetterSpacing.normal ]
                    [ "letterSpacing" ==> "normal" ]
                test
                     "Font family serif"
                     [ FontFamily.serif ]
                     [ "fontFamily" ==> "serif" ]
                test
                     "Font family sans-serif"
                     [ FontFamily.sansSerif ]
                     [ "fontFamily" ==> "sans-serif" ]
                test
                     "Font family monospace"
                     [ FontFamily.monospace ]
                     [ "fontFamily" ==> "monospace" ]
                test
                     "Font family cursive"
                     [ FontFamily.cursive ]
                     [ "fontFamily" ==> "cursive" ]
                test
                     "Font family arial"
                     [ FontFamily.custom "arial" ]
                     [ "fontFamily" ==> "arial" ]
                test
                     "Font family initial"
                     [ FontFamily.initial ]
                     [ "fontFamily" ==> "initial" ]
                test
                     "Font family inherit"
                     [ FontFamily.inherit' ]
                     [ "fontFamily" ==> "inherit" ]
                test
                     "Font family unset"
                     [ FontFamily.unset ]
                     [ "fontFamily" ==> "unset" ]
                test
                    "Font families"
                    [ FontFamily.values ([ FssTypes.Font.Serif; FssTypes.Font.Monospace ]) ]
                    [ "fontFamily" ==> "serif, monospace" ]
                test
                    "font feature setting On"
                    [ FontFeatureSetting.liga FssTypes.Font.On ]
                    [ "fontFeatureSettings" ==> "\"liga\" On" ]
                test
                    "font feature setting Off"
                    [ FontFeatureSetting.liga FssTypes.Font.Off ]
                    [ "fontFeatureSettings" ==> "\"liga\" Off" ]
                test
                    "font feature setting initial"
                    [ FontFeatureSetting.initial ]
                    [ "fontFeatureSettings" ==> "initial" ]
                test
                    "font feature setting inherit"
                    [ FontFeatureSetting.inherit' ]
                    [ "fontFeatureSettings" ==> "inherit" ]
                test
                    "font feature setting unset"
                    [ FontFeatureSetting.unset ]
                    [ "fontFeatureSettings" ==> "unset" ]
                test
                    "Font variant numeric normal"
                    [ FontVariantNumeric.normal]
                    ["fontVariantNumeric" ==> "normal"]
                test
                    "Font variant numeric ordinal"
                    [ FontVariantNumeric.ordinal]
                    ["fontVariantNumeric" ==> "ordinal"]
                test
                    "Font variant numeric slashed zero"
                    [ FontVariantNumeric.slashedZero]
                    ["fontVariantNumeric" ==> "slashed-zero"]
                test
                    "Font variant numeric lining nums"
                    [ FontVariantNumeric.liningNums]
                    ["fontVariantNumeric" ==> "lining-nums"]
                test
                    "Font variant numeric old style nums"
                    [ FontVariantNumeric.oldstyleNums]
                    ["fontVariantNumeric" ==> "oldstyle-nums"]
                test
                    "Font variant numeric tabular nums"
                    [ FontVariantNumeric.tabularNums]
                    ["fontVariantNumeric" ==> "tabular-nums"]
                test
                    "Font variant numeric diagonal fractions"
                    [ FontVariantNumeric.diagonalFractions]
                    ["fontVariantNumeric" ==> "diagonal-fractions"]
                test
                    "Font variant numeric stacked fractions"
                    [ FontVariantNumeric.stackedFractions]
                    ["fontVariantNumeric" ==> "stacked-fractions"]
                test
                    "Font variant numeric inherit"
                    [ FontVariantNumeric.inherit' ]
                    [ "fontVariantNumeric" ==> "inherit" ]
                test
                    "Font variant numeric initial"
                    [ FontVariantNumeric.initial]
                    [ "fontVariantNumeric" ==> "initial" ]
                test
                    "Font variant numeric unset"
                    [ FontVariantNumeric.unset ]
                    [ "fontVariantNumeric" ==> "unset" ]
                test
                    "Font variant caps normal"
                    [ FontVariantCaps.normal]
                    ["fontVariantCaps" ==> "normal"]
                test
                    "Font variant caps small caps"
                    [ FontVariantCaps.smallCaps]
                    ["fontVariantCaps" ==> "small-caps"]
                test
                    "Font variant caps  all small caps"
                    [ FontVariantCaps.allSmallCaps]
                    ["fontVariantCaps" ==> "all-small-caps"]
                test
                    "Font variant caps petite caps"
                    [ FontVariantCaps.petiteCaps]
                    ["fontVariantCaps" ==> "petite-caps"]
                test
                    "Font variant caps all petite caps"
                    [ FontVariantCaps.allPetiteCaps]
                    ["fontVariantCaps" ==> "all-petite-caps"]
                test
                    "Font variant caps unicase"
                    [ FontVariantCaps.unicase]
                    ["fontVariantCaps" ==> "unicase"]
                test
                    "Font variant caps titling caps"
                    [ FontVariantCaps.titlingCaps]
                    ["fontVariantCaps" ==> "titling-caps"]
                test
                    "Font variant caps initial"
                    [ FontVariantCaps.initial ]
                    [ "fontVariantCaps" ==> "initial"]
                test
                    "Font variant caps inherit"
                    [ FontVariantCaps.inherit' ]
                    ["fontVariantCaps" ==> "inherit"]
                test
                    "Font variant caps unset"
                    [ FontVariantCaps.unset ]
                    ["fontVariantCaps" ==> "unset" ]
                test
                    "Font variant east asian normal"
                    [ FontVariantEastAsian.normal]
                    ["fontVariantEastAsian" ==> "normal"]
                test
                    "Font variant east asian ruby"
                    [ FontVariantEastAsian.ruby]
                    ["fontVariantEastAsian" ==> "ruby"]
                test
                    "Font variant east asian  jis78"
                    [ FontVariantEastAsian.jis78]
                    ["fontVariantEastAsian" ==> "jis78"]
                test
                    "Font variant east asian jis83"
                    [ FontVariantEastAsian.jis83]
                    ["fontVariantEastAsian" ==> "jis83"]
                test
                    "Font variant east asian jis90"
                    [ FontVariantEastAsian.jis90]
                    ["fontVariantEastAsian" ==> "jis90"]
                test
                    "Font variant east asian jis04"
                    [ FontVariantEastAsian.jis04]
                    ["fontVariantEastAsian" ==> "jis04"]
                test
                    "Font variant east asian simplified"
                    [ FontVariantEastAsian.simplified]
                    ["fontVariantEastAsian" ==> "simplified"]
                test
                    "Font variant east asian traditional"
                    [ FontVariantEastAsian.traditional]
                    ["fontVariantEastAsian" ==> "traditional"]
                test
                    "Font variant east asian full width"
                    [ FontVariantEastAsian.fullWidth]
                    ["fontVariantEastAsian" ==> "full-width"]
                test
                    "Font variant east asian  proportional widt"
                    [ FontVariantEastAsian.proportionalWidth]
                    ["fontVariantEastAsian" ==> "proportional-width"]
                test
                    "Font variant ligatures normal"
                    [ FontVariantLigatures.normal]
                    ["fontVariantLigatures" ==> "normal"]
                test
                    "Font variant ligatures none"
                    [ FontVariantLigatures.none]
                    ["fontVariantLigatures" ==> "none"]
                test
                    "Font variant ligatures common"
                    [ FontVariantLigatures.commonLigatures]
                    ["fontVariantLigatures" ==> "common-ligatures"]
                test
                    "Font variant ligatures no common"
                    [ FontVariantLigatures.noCommonLigatures]
                    ["fontVariantLigatures" ==> "no-common-ligatures"]
                test
                    "Font variant ligatures discretionary"
                    [ FontVariantLigatures.discretionaryLigatures]
                    ["fontVariantLigatures" ==> "discretionary-ligatures"]
                test
                    "Font variant ligatures no discretionary"
                    [ FontVariantLigatures.noDiscretionaryLigatures]
                    ["fontVariantLigatures" ==> "no-discretionary-ligatures"]
                test
                    "Font variant ligatures historical"
                    [ FontVariantLigatures.historicalLigatures]
                    ["fontVariantLigatures" ==> "historical-ligatures"]
                test
                    "Font variant ligatures no historical"
                    [ FontVariantLigatures.noHistoricalLigatures]
                    ["fontVariantLigatures" ==> "no-historical-ligatures"]
                test
                    "Font variant ligatures contextual"
                    [ FontVariantLigatures.contextual]
                    ["fontVariantLigatures" ==> "contextual"]
                test
                    "Font variant ligatures no contextual"
                    [ FontVariantLigatures.noContextual]
                    ["fontVariantLigatures" ==> "no-contextual"]
                test
                    "Font variant ligatures no initial"
                    [ FontVariantLigatures.initial ]
                    ["fontVariantLigatures" ==> "initial"]
                test
                    "Font variant ligatures inherit"
                    [ FontVariantLigatures.inherit']
                    ["fontVariantLigatures" ==> "inherit"]
                test
                    "Font variant ligatures no unset"
                    [ FontVariantLigatures.unset]
                    ["fontVariantLigatures" ==> "unset"]
                test
                    "Font variant position super"
                    [ FontVariantPosition.super ]
                    ["fontVariantPosition" ==> "super"]
                test
                    "Font variant position sub"
                    [ FontVariantPosition.sub]
                    ["fontVariantPosition" ==> "sub"]
                test
                    "Font variant position unset"
                    [ FontVariantPosition.unset]
                    ["fontVariantPosition" ==> "unset"]
                test
                    "Font variant position initial"
                    [ FontVariantPosition.initial ]
                    ["fontVariantPosition" ==> "initial"]
                test
                    "Font variant position inherit"
                    [ FontVariantPosition.inherit']
                    ["fontVariantPosition" ==> "inherit"]
                test
                    "Font variant position no unset"
                    [ FontVariantPosition.unset]
                    ["fontVariantPosition" ==> "unset"]
        ]