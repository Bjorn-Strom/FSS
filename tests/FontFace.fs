namespace FSSTests

open Fet
open Utils
open Fss

module FontFace =
     let tests =
        testList "Font face"
            [
                testFontCase
                    "Single source"
                    [ FontFace.Src.url "someFontUrl" ]
                    "{ font-family: \"\";src: url(someFontUrl); }"
                testFontCase
                    "Single source with format"
                    [ FontFace.Src.woff2 "someFontUrl" ]
                    "{ font-family: \"\";src: url(someFontUrl) format('woff2'); }"
                testFontCase
                    "Multiple sources"
                    [ FontFace.Src.sources
                        [
                            "url1"
                            "url2"
                            "url3"
                            "url4"
                        ]
                    ]
                    "{ font-family: \"\";src: url(url1), url(url2), url(url3), url(url4); }"
                testFontCase
                    "Multiple sources"
                    [ FontFace.Src.sources
                        [
                            FssTypes.FontFace.Woff2 "url1"
                            FssTypes.FontFace.Woff "url2"
                            FssTypes.FontFace.Truetype "url3"
                            FssTypes.FontFace.Svg "url4"
                        ]
                    ]
                    "{ font-family: \"\";src: url(url1) format('woff2'), url(url2) format('woff'), url(url3) format('truetype'), url(url4) format('svg'); }"
                testFontCase
                    "Display auto"
                    [ FontFace.FontDisplay.auto ]
                    "{ font-family: \"\";font-display: auto; }"
                testFontCase
                    "Display block"
                    [ FontFace.FontDisplay.block ]
                    "{ font-family: \"\";font-display: block; }"
                testFontCase
                    "Display swap"
                    [ FontFace.FontDisplay.swap ]
                    "{ font-family: \"\";font-display: swap; }"
                testFontCase
                    "Display fallback"
                    [ FontFace.FontDisplay.fallback ]
                    "{ font-family: \"\";font-display: fallback; }"
                testFontCase
                    "Display optional"
                    [ FontFace.FontDisplay.optional ]
                    "{ font-family: \"\";font-display: optional; }"
                testFontCase
                    "Font style normal"
                    [ FontFace.FontStyle.normal ]
                    "{ font-family: \"\";font-style: normal; }"
                testFontCase
                    "Font style italic"
                    [ FontFace.FontStyle.italic ]
                    "{ font-family: \"\";font-style: italic; }"
                testFontCase
                    "Font style oblique"
                    [ FontFace.FontStyle.oblique ]
                    "{ font-family: \"\";font-style: oblique; }"
                testFontCase
                    "Font style oblique angle"
                    [ FontFace.FontStyle.obliqueAngle (deg 90.) ]
                    "{ font-family: \"\";font-style: oblique 90deg; }"
                testFontCase
                    "Font style oblique angle range"
                    [ FontFace.FontStyle.obliqueAngleRange (deg 90, deg 50) ]
                    "{ font-family: \"\";font-style: oblique 90deg 50deg; }"
                testFontCase
                    "Font stretch Semi Condensed"
                    [ FontFace.FontStretch.semiCondensed ]
                    "{ font-family: \"\";font-stretch: semi-condensed; }" 
                testFontCase
                    "Font stretch extra Condensed"
                    [ FontFace.FontStretch.extraCondensed ]
                    "{ font-family: \"\";font-stretch: extra-condensed; }" 
                testFontCase
                    "Font stretch Condensed"
                    [ FontFace.FontStretch.condensed ]
                    "{ font-family: \"\";font-stretch: condensed; }" 
                testFontCase
                    "Font stretch ultra Condensed"
                    [ FontFace.FontStretch.ultraCondensed ]
                    "{ font-family: \"\";font-stretch: ultra-condensed; }" 
                testFontCase
                    "Font stretch Semi expanded"
                    [ FontFace.FontStretch.semiExpanded ]
                    "{ font-family: \"\";font-stretch: semi-expanded; }" 
                testFontCase
                    "Font stretch ultra expanded"
                    [ FontFace.FontStretch.ultraExpanded ]
                    "{ font-family: \"\";font-stretch: ultra-expanded; }" 
                testFontCase
                    "Font stretch extra expanded"
                    [ FontFace.FontStretch.extraExpanded ]
                    "{ font-family: \"\";font-stretch: extra-expanded; }" 
                testFontCase
                    "Font stretch expanded"
                    [ FontFace.FontStretch.expanded ]
                    "{ font-family: \"\";font-stretch: expanded; }" 
                testFontCase
                    "Font stretch normal"
                    [ FontFace.FontStretch.normal ]
                    "{ font-family: \"\";font-stretch: normal; }" 
                testFontCase
                    "Font stretch percent"
                    [ FontFace.FontStretch.value (pct 10)]
                    "{ font-family: \"\";font-stretch: 10%; }" 
                testFontCase
                    "Font stretch percent multiple"
                    [ FontFace.FontStretch.value [pct 10; pct 20; pct 30] ]
                    "{ font-family: \"\";font-stretch: 10% 20% 30%; }" 
                testFontCase
                    "Font weight int"
                    [FontFace.FontWeight.value 400]
                    "{ font-family: \"\";font-weight: 400; }"
                testFontCase
                    "Font size adjust"
                    [ FontFace.SizeAdjust.value <| pct 50 ]
                    "{ font-family: \"\";size-adjust: 50%; }" 
                testFontCase
                    "Unicode range single"
                    [ FontFace.UnicodeRange.value "U+26" ]
                    "{ font-family: \"\";unicode-range: U+26; }" 
                testFontCase
                    "Unicode range single"
                    [ FontFace.UnicodeRange.value "U+0-7F" ]
                    "{ font-family: \"\";unicode-range: U+0-7F; }" 
                testFontCase
                    "Unicode range code point range"
                    [ FontFace.UnicodeRange.value "U+0025-00FF" ]
                    "{ font-family: \"\";unicode-range: U+0025-00FF; }" 
                testFontCase
                    "Unicode range wildcard range"
                    [ FontFace.UnicodeRange.value "U+4??" ]
                    "{ font-family: \"\";unicode-range: U+4??; }" 
                testFontCase
                    "Unicode range multiple"
                    [ FontFace.UnicodeRange.value [ "U+0025-00FF"; "U+4??" ] ]
                    "{ font-family: \"\";unicode-range: U+0025-00FF, U+4??; }" 
                testFontCase
                    "Linegap override normal"
                    [ FontFace.LineGapOverride.normal ]
                    "{ font-family: \"\";line-gap-override: normal; }" 
                testFontCase
                    "Linegap override percent"
                    [ FontFace.LineGapOverride.value <| pct 90 ]
                    "{ font-family: \"\";line-gap-override: 90%; }"
                testFontCase
                    "Variation settings"
                    [ FontFace.FontVariationSettings.value ("wght", 400) ]
                    "{ font-family: \"\";font-variation-settings: 'wght' 400; }" 
                testFontCase
                    "Variation settings"
                    [ FontFace.FontVariationSettings.value [ "wght", 400.; "wdth", 300. ] ]
                    "{ font-family: \"\";font-variation-settings: 'wght' 400, 'wdth' 300; }"
                testFontCase
                    "Ascent override"
                    [ FontFace.AscentOverride.normal ]
                    "{ font-family: \"\";ascent-override: normal; }"
                testFontCase
                    "Ascent override"
                    [ FontFace.AscentOverride.value <| pct 40]
                    "{ font-family: \"\";ascent-override: 40%; }"
                testFontCase
                    "Descent override"
                    [ FontFace.DescentOverride.normal ]
                    "{ font-family: \"\";descent-override: normal; }"
                testFontCase
                    "Descent override"
                    [ FontFace.DescentOverride.value <| pct 40]
                    "{ font-family: \"\";descent-override: 40%; }"
                testFontCase
                    "Fontface fontname ident"
                    [ FontFace.FontFamily.ident "FontName" ]
                    "{ font-family: \"\";font-family: FontName; }" 
                testFontCase
                    "Fontface fontname string"
                    [ FontFace.FontFamily.string "font family" ]
                    "{ font-family: \"\";font-family: \"font family\"; }"


            ]