namespace FSSTests

open Fet
open Utils
open Fss

module FontTests =
    let tests =
        testList "Fonts"
            [
                testCase
                    "Font synthesis none"
                    [ FontSynthesis.none ]
                     "{ font-synthesis: none; }"
                testCase
                    "Font synthesis weight"
                    [ FontSynthesis.weight ]
                     "{ font-synthesis: weight; }"
                testCase
                    "Font synthesis style"
                    [ FontSynthesis.style ]
                     "{ font-synthesis: style; }"
                testCase
                    "Font synthesis smallcaps"
                    [ FontSynthesis.smallCaps ]
                     "{ font-synthesis: small-caps; }"
                testCase
                    "Font synthesis weight style"
                    [ FontSynthesis.value [ Fss.Types.Font.Weight; Fss.Types.Font.Style; Fss.Types.Font.Synthesis.SmallCaps  ] ]
                     "{ font-synthesis: weight style small-caps; }"
                testCase
                    "Font synthesis inherit"
                    [ FontSynthesis.inherit' ]
                     "{ font-synthesis: inherit; }"
                testCase
                    "Font synthesis initial"
                    [ FontSynthesis.initial ]
                     "{ font-synthesis: initial; }"
                testCase
                    "Font synthesis unset"
                    [ FontSynthesis.unset ]
                     "{ font-synthesis: unset; }"
                testCase
                    "Font synthesis revert"
                    [ FontSynthesis.revert ]
                     "{ font-synthesis: revert; }"
                testCase
                    "Font language override string"
                    [ FontLanguageOverride.value "ENG" ]
                     "{ font-language-override: \"ENG\"; }"
                testCase
                    "Font language override normal"
                    [ FontLanguageOverride.normal ]
                     "{ font-language-override: normal; }"
                testCase
                    "Font language override inherit"
                    [ FontLanguageOverride.inherit' ]
                     "{ font-language-override: inherit; }"
                testCase
                    "Font language override initial"
                    [ FontLanguageOverride.initial ]
                     "{ font-language-override: initial; }"
                testCase
                    "Font language override unset"
                    [ FontLanguageOverride.unset ]
                     "{ font-language-override: unset; }"
                testCase
                    "Font language override revert"
                    [ FontLanguageOverride.revert ]
                     "{ font-language-override: revert; }"
                testCase
                    "Font kerning none"
                    [ FontKerning.none ]
                     "{ font-kerning: none; }"
                testCase
                    "Font kerning auto"
                    [ FontKerning.auto ]
                     "{ font-kerning: auto; }"
                testCase
                    "Font kerning normal"
                    [ FontKerning.normal ]
                     "{ font-kerning: normal; }"
                testCase
                    "Font kerning inherit"
                    [ FontKerning.inherit' ]
                     "{ font-kerning: inherit; }"
                testCase
                    "Font kerning initial"
                    [ FontKerning.initial ]
                     "{ font-kerning: initial; }"
                testCase
                    "Font kerning unset"
                    [ FontKerning.unset ]
                     "{ font-kerning: unset; }"
                testCase
                    "Font kerning revert"
                    [ FontKerning.revert ]
                     "{ font-kerning: revert; }"
                testCase
                    "Font size XX-Small"
                    [ FontSize.xxSmall ]
                     "{ font-size: xx-small; }"
                testCase
                    "Font size X-Small"
                    [ FontSize.xSmall ]
                     "{ font-size: x-small; }"
                testCase
                    "Font size small"
                    [ FontSize.small ]
                     "{ font-size: small; }"
                testCase
                    "Font size medium"
                    [ FontSize.medium ]
                     "{ font-size: medium; }"
                testCase
                    "Font size large"
                    [ FontSize.large ]
                     "{ font-size: large; }"
                testCase
                    "Font size x-large"
                    [ FontSize.xLarge ]
                     "{ font-size: x-large; }"
                testCase
                    "Font size xx-large"
                    [ FontSize.xxLarge ]
                     "{ font-size: xx-large; }"
                testCase
                    "Font size xxx-large"
                    [ FontSize.xxxLarge ]
                     "{ font-size: xxx-large; }"
                testCase
                    "Font size smaller"
                    [ FontSize.smaller ]
                     "{ font-size: smaller; }"
                testCase
                    "Font size larger"
                    [ FontSize.larger ]
                     "{ font-size: larger; }"
                testCase
                    "Font size pixels"
                    [ FontSize.value (px 18) ]
                     "{ font-size: 18px; }"
                testCase
                    "Font size em"
                    [ FontSize.value (em 0.8) ]
                     "{ font-size: 0.8em; }"
                testCase
                    "Font size percentage"
                    [ FontSize.value (pct 80) ]
                     "{ font-size: 80%; }"
                testCase
                    "Font size inherit"
                    [ FontSize.inherit' ]
                     "{ font-size: inherit; }"
                testCase
                    "Font size initial"
                    [ FontSize.initial ]
                     "{ font-size: initial; }"
                testCase
                    "Font size unset"
                    [ FontSize.unset ]
                     "{ font-size: unset; }"
                testCase
                    "Font size revert"
                    [ FontSize.revert ]
                     "{ font-size: revert; }"
                testCase
                    "Font stretch normal"
                    [ FontStretch.normal ]
                     "{ font-stretch: normal; }"
                testCase
                    "Font stretch ultra-condensed"
                    [ FontStretch.ultraCondensed ]
                     "{ font-stretch: ultra-condensed; }"
                testCase
                     "Font stretch extra-condensed"
                    [ FontStretch.extraCondensed ]
                     "{ font-stretch: extra-condensed; }"
                testCase
                    "Font stretch extra-condensed"
                    [ FontStretch.extraCondensed ]
                     "{ font-stretch: extra-condensed; }"
                testCase
                    "Font stretch condensed"
                    [ FontStretch.condensed ]
                     "{ font-stretch: condensed; }"
                testCase
                    "Font stretch semi-condensed"
                    [ FontStretch.semiCondensed ]
                     "{ font-stretch: semi-condensed; }"
                testCase
                    "Font stretch expanded"
                    [ FontStretch.expanded]
                     "{ font-stretch: expanded; }"
                testCase
                    "Font stretch extra-expanded"
                    [ FontStretch.extraExpanded]
                     "{ font-stretch: extra-expanded; }"
                testCase
                    "Font stretch ultra-expanded"
                    [ FontStretch.ultraExpanded]
                     "{ font-stretch: ultra-expanded; }"
                testCase
                    "Font stretch percent"
                    [ FontStretch.value (pct 200) ]
                     "{ font-stretch: 200%; }"
                testCase
                    "Font stretch inherit"
                    [ FontStretch.inherit' ]
                     "{ font-stretch: inherit; }"
                testCase
                    "Font stretch initial"
                    [ FontStretch.initial ]
                     "{ font-stretch: initial; }"
                testCase
                    "Font stretch unset"
                    [ FontStretch.unset ]
                     "{ font-stretch: unset; }"
                testCase
                    "Font stretch revert"
                    [ FontStretch.revert ]
                     "{ font-stretch: revert; }"
                testCase
                    "Font style normal"
                    [ FontStyle.normal]
                     "{ font-style: normal; }"
                testCase
                    "Font style italic"
                    [ FontStyle.italic]
                     "{ font-style: italic; }"
                testCase
                    "Font style oblicque 90"
                    [ FontStyle.oblique (deg 90.0)]
                     "{ font-style: oblique 90deg; }"
                testCase
                    "Font style oblique -90"
                    [ FontStyle.oblique (deg -90.0)]
                     "{ font-style: oblique -90deg; }"
                testCase
                    "Font style inherit"
                    [ FontStyle.inherit' ]
                     "{ font-style: inherit; }"
                testCase
                    "Font style initial"
                    [ FontStyle.initial ]
                     "{ font-style: initial; }"
                testCase
                    "Font style unset"
                    [ FontStyle.unset ]
                     "{ font-style: unset; }"
                testCase
                    "Font style revert"
                    [ FontStyle.revert ]
                     "{ font-style: revert; }"
                testCase
                    "Font weight normal"
                    [ FontWeight.normal ]
                     "{ font-weight: normal; }"
                testCase
                    "Font weight bold"
                    [ FontWeight.bold ]
                     "{ font-weight: bold; }"
                testCase
                    "Font weight lighter"
                    [ FontWeight.lighter ]
                     "{ font-weight: lighter; }"
                testCase
                    "Font weight bolder"
                    [ FontWeight.bolder ]
                     "{ font-weight: bolder; }"
                testCase
                    "Font weight value"
                    [ FontWeight.value 500 ]
                     "{ font-weight: 500; }"
                testCase
                    "Font weight inherit"
                    [ FontWeight.inherit' ]
                     "{ font-weight: inherit; }"
                testCase
                    "Font weight initial"
                    [ FontWeight.initial ]
                     "{ font-weight: initial; }"
                testCase
                    "Font weight unset"
                    [ FontWeight.unset ]
                     "{ font-weight: unset; }"
                testCase
                    "Font weight revert"
                    [ FontWeight.revert ]
                     "{ font-weight: revert; }"
                testCase
                    "Line height normal"
                    [ LineHeight.normal ]
                     "{ line-height: normal; }"
                testCase
                    "Line height value"
                    [ LineHeight.value 2.5 ]
                     "{ line-height: 2.5; }"
                testCase
                    "Line height em"
                    [ LineHeight.value (em 3.0) ]
                     "{ line-height: 3em; }"
                testCase
                    "Line height pixel"
                    [ LineHeight.value (px 3) ]
                     "{ line-height: 3px; }"
                testCase
                    "Line height percent"
                    [ LineHeight.value (pct 34) ]
                     "{ line-height: 34%; }"
                testCase
                    "Line height initial"
                    [ LineHeight.initial ]
                     "{ line-height: initial; }"
                testCase
                    "Line height inherit"
                    [ LineHeight.inherit' ]
                     "{ line-height: inherit; }"
                testCase
                    "Line height unset"
                    [ LineHeight.unset ]
                     "{ line-height: unset; }"
                testCase
                    "Line height revert"
                    [ LineHeight.revert ]
                     "{ line-height: revert; }"
                testCase
                    "Line break loose"
                    [ LineBreak.loose ]
                     "{ line-break: loose; }"
                testCase
                    "Line break strict"
                    [ LineBreak.strict ]
                     "{ line-break: strict; }"
                testCase
                    "Line break anywhere"
                    [ LineBreak.anywhere ]
                     "{ line-break: anywhere; }"
                testCase
                    "Line break normal"
                    [ LineBreak.normal ]
                     "{ line-break: normal; }"
                testCase
                    "Line break auto"
                    [ LineBreak.auto ]
                     "{ line-break: auto; }"
                testCase
                    "Line break initial"
                    [ LineBreak.initial ]
                     "{ line-break: initial; }"
                testCase
                    "Line break inherit"
                    [ LineBreak.inherit' ]
                     "{ line-break: inherit; }"
                testCase
                    "Line break unset"
                    [ LineBreak.unset ]
                     "{ line-break: unset; }"
                testCase
                    "Line break revert"
                    [ LineBreak.revert ]
                     "{ line-break: revert; }"
                testCase
                    "Letter spacing px"
                    [ LetterSpacing.value (px 10) ]
                     "{ letter-spacing: 10px; }"
                testCase
                    "Letter spacing initial"
                    [ LetterSpacing.initial ]
                     "{ letter-spacing: initial; }"
                testCase
                    "Letter spacing inherit"
                    [ LetterSpacing.inherit' ]
                     "{ letter-spacing: inherit; }"
                testCase
                    "Letter spacing unset"
                    [ LetterSpacing.unset ]
                     "{ letter-spacing: unset; }"
                testCase
                    "Letter spacing revert"
                    [ LetterSpacing.revert ]
                     "{ letter-spacing: revert; }"
                testCase
                    "Letter spacing normal"
                    [ LetterSpacing.normal ]
                     "{ letter-spacing: normal; }"
                testCase
                     "Font family serif"
                     [ FontFamily.serif ]
                      "{ font-family: serif; }"
                testCase
                     "Font family sans-serif"
                     [ FontFamily.sansSerif ]
                      "{ font-family: sans-serif; }"
                testCase
                     "Font family monospace"
                     [ FontFamily.monospace ]
                      "{ font-family: monospace; }"
                testCase
                     "Font family cursive"
                     [ FontFamily.cursive ]
                      "{ font-family: cursive; }"
                testCase
                     "Font family arial"
                     [ FontFamily.value "arial" ]
                      "{ font-family: arial; }"
                testCase
                     "Font family initial"
                     [ FontFamily.initial ]
                      "{ font-family: initial; }"
                testCase
                     "Font family inherit"
                     [ FontFamily.inherit' ]
                      "{ font-family: inherit; }"
                testCase
                     "Font family unset"
                     [ FontFamily.unset ]
                      "{ font-family: unset; }"
                testCase
                    "Font families"
                    [ FontFamily.value [ Fss.Types.Font.Serif; Fss.Types.Font.Monospace ] ]
                     "{ font-family: serif, monospace; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.liga On ]
                     "{ font-feature-settings: \"liga\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.liga Off ]
                     "{ font-feature-settings: \"liga\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.dlig On ]
                     "{ font-feature-settings: \"dlig\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.dlig Off ]
                     "{ font-feature-settings: \"dlig\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.onum On ]
                     "{ font-feature-settings: \"onum\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.onum Off ]
                     "{ font-feature-settings: \"onum\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.lnum On ]
                     "{ font-feature-settings: \"lnum\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.lnum Off ]
                     "{ font-feature-settings: \"lnum\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.tnum On ]
                     "{ font-feature-settings: \"tnum\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.tnum Off ]
                     "{ font-feature-settings: \"tnum\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.zero On ]
                     "{ font-feature-settings: \"zero\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.zero Off ]
                     "{ font-feature-settings: \"zero\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.frac On ]
                     "{ font-feature-settings: \"frac\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.frac Off ]
                     "{ font-feature-settings: \"frac\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.sups On ]
                     "{ font-feature-settings: \"sups\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.sups Off ]
                     "{ font-feature-settings: \"sups\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.subs On ]
                     "{ font-feature-settings: \"subs\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.subs Off ]
                     "{ font-feature-settings: \"subs\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.smcp On ]
                     "{ font-feature-settings: \"smcp\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.smcp Off ]
                     "{ font-feature-settings: \"smcp\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.c2sc On ]
                     "{ font-feature-settings: \"c2sc\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.c2sc Off ]
                     "{ font-feature-settings: \"c2sc\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.case On ]
                     "{ font-feature-settings: \"case\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.case Off ]
                     "{ font-feature-settings: \"case\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.hlig On ]
                     "{ font-feature-settings: \"hlig\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.hlig Off ]
                     "{ font-feature-settings: \"hlig\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.calt On ]
                     "{ font-feature-settings: \"calt\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.calt Off ]
                     "{ font-feature-settings: \"calt\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.swsh On ]
                     "{ font-feature-settings: \"swsh\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.swsh Off ]
                     "{ font-feature-settings: \"swsh\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.hist On ]
                     "{ font-feature-settings: \"hist\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.hist Off ]
                     "{ font-feature-settings: \"hist\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.ss (1, On) ]
                     "{ font-feature-settings: \"ss01\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.ss (1, Off) ]
                     "{ font-feature-settings: \"ss01\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.kern On ]
                     "{ font-feature-settings: \"kern\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.kern Off ]
                     "{ font-feature-settings: \"kern\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.locl On ]
                     "{ font-feature-settings: \"locl\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.locl Off ]
                     "{ font-feature-settings: \"locl\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.rlig On ]
                     "{ font-feature-settings: \"rlig\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.rlig Off ]
                     "{ font-feature-settings: \"rlig\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.medi On ]
                     "{ font-feature-settings: \"medi\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.medi Off ]
                     "{ font-feature-settings: \"medi\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.init On ]
                     "{ font-feature-settings: \"init\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.init Off ]
                     "{ font-feature-settings: \"init\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.isol On ]
                     "{ font-feature-settings: \"isol\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.isol Off ]
                     "{ font-feature-settings: \"isol\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.fina On ]
                     "{ font-feature-settings: \"fina\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.mark Off ]
                     "{ font-feature-settings: \"mark\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.mark On ]
                     "{ font-feature-settings: \"mark\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.mkmk Off ]
                     "{ font-feature-settings: \"mkmk\" Off; }"
                testCase
                    "font feature setting On"
                    [ FontFeatureSettings.mkmk On ]
                     "{ font-feature-settings: \"mkmk\" On; }"
                testCase
                    "font feature setting Off"
                    [ FontFeatureSettings.fina Off ]
                     "{ font-feature-settings: \"fina\" Off; }"
                testCase
                    "font feature setting initial"
                    [ FontFeatureSettings.initial ]
                     "{ font-feature-settings: initial; }"
                testCase
                    "font feature setting inherit"
                    [ FontFeatureSettings.inherit' ]
                     "{ font-feature-settings: inherit; }"
                testCase
                    "font feature setting unset"
                    [ FontFeatureSettings.unset ]
                     "{ font-feature-settings: unset; }"
                testCase
                    "font feature setting revert"
                    [ FontFeatureSettings.revert ]
                     "{ font-feature-settings: revert; }"
                testCase
                    "Font variant numeric normal"
                    [ FontVariantNumeric.normal]
                    "{ font-variant-numeric: normal; }"
                testCase
                    "Font variant numeric ordinal"
                    [ FontVariantNumeric.ordinal]
                    "{ font-variant-numeric: ordinal; }"
                testCase
                    "Font variant numeric slashed zero"
                    [ FontVariantNumeric.slashedZero]
                    "{ font-variant-numeric: slashed-zero; }"
                testCase
                    "Font variant numeric lining nums"
                    [ FontVariantNumeric.liningNums]
                    "{ font-variant-numeric: lining-nums; }"
                testCase
                    "Font variant numeric old style nums"
                    [ FontVariantNumeric.oldstyleNums]
                    "{ font-variant-numeric: oldstyle-nums; }"
                testCase
                    "Font variant numeric tabular nums"
                    [ FontVariantNumeric.tabularNums]
                    "{ font-variant-numeric: tabular-nums; }"
                testCase
                    "Font variant numeric diagonal fractions"
                    [ FontVariantNumeric.diagonalFractions]
                    "{ font-variant-numeric: diagonal-fractions; }"
                testCase
                    "Font variant numeric stacked fractions"
                    [ FontVariantNumeric.stackedFractions]
                    "{ font-variant-numeric: stacked-fractions; }"
                testCase
                    "Font variant numeric inherit"
                    [ FontVariantNumeric.inherit' ]
                     "{ font-variant-numeric: inherit; }"
                testCase
                    "Font variant numeric initial"
                    [ FontVariantNumeric.initial]
                     "{ font-variant-numeric: initial; }"
                testCase
                    "Font variant numeric unset"
                    [ FontVariantNumeric.unset ]
                     "{ font-variant-numeric: unset; }"
                testCase
                    "Font variant numeric revert"
                    [ FontVariantNumeric.revert ]
                     "{ font-variant-numeric: revert; }"
                testCase
                    "Font variant caps normal"
                    [ FontVariantCaps.normal]
                    "{ font-variant-caps: normal; }"
                testCase
                    "Font variant caps small caps"
                    [ FontVariantCaps.smallCaps]
                    "{ font-variant-caps: small-caps; }"
                testCase
                    "Font variant caps  all small caps"
                    [ FontVariantCaps.allSmallCaps]
                    "{ font-variant-caps: all-small-caps; }"
                testCase
                    "Font variant caps petite caps"
                    [ FontVariantCaps.petiteCaps]
                    "{ font-variant-caps: petite-caps; }"
                testCase
                    "Font variant caps all petite caps"
                    [ FontVariantCaps.allPetiteCaps]
                    "{ font-variant-caps: all-petite-caps; }"
                testCase
                    "Font variant caps unicase"
                    [ FontVariantCaps.unicase]
                    "{ font-variant-caps: unicase; }"
                testCase
                    "Font variant caps titling caps"
                    [ FontVariantCaps.titlingCaps]
                    "{ font-variant-caps: titling-caps; }"
                testCase
                    "Font variant caps initial"
                    [ FontVariantCaps.initial ]
                     "{ font-variant-caps: initial; }"
                testCase
                    "Font variant caps inherit"
                    [ FontVariantCaps.inherit' ]
                    "{ font-variant-caps: inherit; }"
                testCase
                    "Font variant caps unset"
                    [ FontVariantCaps.unset ]
                    "{ font-variant-caps: unset; }"
                testCase
                    "Font variant caps revert"
                    [ FontVariantCaps.revert ]
                    "{ font-variant-caps: revert; }"
                testCase
                    "Font variant east asian normal"
                    [ FontVariantEastAsian.normal]
                    "{ font-variant-east-asian: normal; }"
                testCase
                    "Font variant east asian ruby"
                    [ FontVariantEastAsian.ruby]
                    "{ font-variant-east-asian: ruby; }"
                testCase
                    "Font variant east asian  jis78"
                    [ FontVariantEastAsian.jis78]
                    "{ font-variant-east-asian: jis78; }"
                testCase
                    "Font variant east asian jis83"
                    [ FontVariantEastAsian.jis83]
                    "{ font-variant-east-asian: jis83; }"
                testCase
                    "Font variant east asian jis90"
                    [ FontVariantEastAsian.jis90]
                    "{ font-variant-east-asian: jis90; }"
                testCase
                    "Font variant east asian jis04"
                    [ FontVariantEastAsian.jis04]
                    "{ font-variant-east-asian: jis04; }"
                testCase
                    "Font variant east asian simplified"
                    [ FontVariantEastAsian.simplified]
                    "{ font-variant-east-asian: simplified; }"
                testCase
                    "Font variant east asian traditional"
                    [ FontVariantEastAsian.traditional]
                    "{ font-variant-east-asian: traditional; }"
                testCase
                    "Font variant east asian full width"
                    [ FontVariantEastAsian.fullWidth]
                    "{ font-variant-east-asian: full-width; }"
                testCase
                    "Font variant east asian  proportional widt"
                    [ FontVariantEastAsian.proportionalWidth]
                    "{ font-variant-east-asian: proportional-width; }"
                testCase
                    "Font variant ligatures normal"
                    [ FontVariantLigatures.normal]
                    "{ font-variant-ligatures: normal; }"
                testCase
                    "Font variant ligatures none"
                    [ FontVariantLigatures.none]
                    "{ font-variant-ligatures: none; }"
                testCase
                    "Font variant ligatures common"
                    [ FontVariantLigatures.commonLigatures]
                    "{ font-variant-ligatures: common-ligatures; }"
                testCase
                    "Font variant ligatures no common"
                    [ FontVariantLigatures.noCommonLigatures]
                    "{ font-variant-ligatures: no-common-ligatures; }"
                testCase
                    "Font variant ligatures discretionary"
                    [ FontVariantLigatures.discretionaryLigatures]
                    "{ font-variant-ligatures: discretionary-ligatures; }"
                testCase
                    "Font variant ligatures no discretionary"
                    [ FontVariantLigatures.noDiscretionaryLigatures]
                    "{ font-variant-ligatures: no-discretionary-ligatures; }"
                testCase
                    "Font variant ligatures historical"
                    [ FontVariantLigatures.historicalLigatures]
                    "{ font-variant-ligatures: historical-ligatures; }"
                testCase
                    "Font variant ligatures no historical"
                    [ FontVariantLigatures.noHistoricalLigatures]
                    "{ font-variant-ligatures: no-historical-ligatures; }"
                testCase
                    "Font variant ligatures contextual"
                    [ FontVariantLigatures.contextual]
                    "{ font-variant-ligatures: contextual; }"
                testCase
                    "Font variant ligatures no contextual"
                    [ FontVariantLigatures.noContextual]
                    "{ font-variant-ligatures: no-contextual; }"
                testCase
                    "Font variant ligatures no initial"
                    [ FontVariantLigatures.initial ]
                    "{ font-variant-ligatures: initial; }"
                testCase
                    "Font variant ligatures inherit"
                    [ FontVariantLigatures.inherit']
                    "{ font-variant-ligatures: inherit; }"
                testCase
                    "Font variant ligatures no unset"
                    [ FontVariantLigatures.unset]
                    "{ font-variant-ligatures: unset; }"
                testCase
                    "Font variant ligatures no revert"
                    [ FontVariantLigatures.revert]
                    "{ font-variant-ligatures: revert; }"
                testCase
                    "Font variant position super"
                    [ FontVariantPosition.super ]
                    "{ font-variant-position: super; }"
                testCase
                    "Font variant position sub"
                    [ FontVariantPosition.sub]
                    "{ font-variant-position: sub; }"
                testCase
                    "Font variant position unset"
                    [ FontVariantPosition.unset]
                    "{ font-variant-position: unset; }"
                testCase
                    "Font variant position initial"
                    [ FontVariantPosition.initial ]
                    "{ font-variant-position: initial; }"
                testCase
                    "Font variant position inherit"
                    [ FontVariantPosition.inherit']
                    "{ font-variant-position: inherit; }"
                testCase
                    "Font variant position unset"
                    [ FontVariantPosition.unset]
                    "{ font-variant-position: unset; }"
                testCase
                    "Font variant position revert"
                    [ FontVariantPosition.revert]
                    "{ font-variant-position: revert; }"
        ]