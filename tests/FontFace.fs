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
                    "src: url(someFontUrl);"
                testFontCase
                    "Single source with format"
                    [ FontFace.Src.woff2 "someFontUrl" ]
                    "src: url(someFontUrl) format('woff2');"
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
                    "src: url(url1), url(url2), url(url3), url(url4);"
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
                    "src: url(url1) format('woff2'), url(url2) format('woff'), url(url3) format('truetype'), url(url4) format('svg');"
                testFontCase
                    "Display auto"
                    [ FontFace.FontDisplay.auto ]
                    "font-display: auto;"
                testFontCase
                    "Display block"
                    [ FontFace.FontDisplay.block ]
                    "font-display: block;"
                testFontCase
                    "Display swap"
                    [ FontFace.FontDisplay.swap ]
                    "font-display: swap;"
                testFontCase
                    "Display fallback"
                    [ FontFace.FontDisplay.fallback ]
                    "font-display: fallback;"
                testFontCase
                    "Display optional"
                    [ FontFace.FontDisplay.optional ]
                    "font-display: optional;"
                testFontCase
                    "Font style normal"
                    [ FontFace.FontStyle.normal ]
                    "font-style: normal;"
                testFontCase
                    "Font style italic"
                    [ FontFace.FontStyle.italic ]
                    "font-style: italic;"
                testFontCase
                    "Font style oblique"
                    [ FontFace.FontStyle.oblique ]
                    "font-style: oblique;"
                testFontCase
                    "Font style oblique angle"
                    [ FontFace.FontStyle.obliqueAngle (deg 90.) ]
                    "font-style: oblique 90deg;"
                testFontCase
                    "Font style oblique angle range"
                    [ FontFace.FontStyle.obliqueAngleRange (deg 90, deg 50) ]
                    "font-style: oblique 90deg 50deg;"
                testFontCase
                    "Font stretch Semi Condensed"
                    [ FontFace.FontStretch.semiCondensed ]
                    "font-stretch: semi-condensed;" 
                testFontCase
                    "Font stretch extra Condensed"
                    [ FontFace.FontStretch.extraCondensed ]
                    "font-stretch: extra-condensed;" 
                testFontCase
                    "Font stretch Condensed"
                    [ FontFace.FontStretch.condensed ]
                    "font-stretch: condensed;" 
                testFontCase
                    "Font stretch ultra Condensed"
                    [ FontFace.FontStretch.ultraCondensed ]
                    "font-stretch: ultra-condensed;" 
                testFontCase
                    "Font stretch Semi expanded"
                    [ FontFace.FontStretch.semiExpanded ]
                    "font-stretch: semi-expanded;" 
                testFontCase
                    "Font stretch ultra expanded"
                    [ FontFace.FontStretch.ultraExpanded ]
                    "font-stretch: ultra-expanded;" 
                testFontCase
                    "Font stretch extra expanded"
                    [ FontFace.FontStretch.extraExpanded ]
                    "font-stretch: extra-expanded;" 
                testFontCase
                    "Font stretch expanded"
                    [ FontFace.FontStretch.expanded ]
                    "font-stretch: expanded;" 
                testFontCase
                    "Font stretch normal"
                    [ FontFace.FontStretch.normal ]
                    "font-stretch: normal;" 
                testFontCase
                    "Font stretch percent"
                    [ FontFace.FontStretch.value (pct 10)]
                    "font-stretch: 10%;" 
                testFontCase
                    "Font stretch percent multiple"
                    [ FontFace.FontStretch.value [pct 10; pct 20; pct 30] ]
                    "font-stretch: 10% 20% 30%;" 
                testFontCase
                    "Font weight int"
                    [FontFace.FontWeight.value 400]
                    "font-weight: 400;"
                testFontCase
                    "Font size adjust"
                    [ FontFace.SizeAdjust.value <| pct 50 ]
                    "size-adjust: 50%;" 
                testFontCase
                    "Unicode range single"
                    [ FontFace.UnicodeRange.value "U+26" ]
                    "unicode-range: U+26;" 
                testFontCase
                    "Unicode range single"
                    [ FontFace.UnicodeRange.value "U+0-7F" ]
                    "unicode-range: U+0-7F;" 
                testFontCase
                    "Unicode range code point range"
                    [ FontFace.UnicodeRange.value "U+0025-00FF" ]
                    "unicode-range: U+0025-00FF;" 
                testFontCase
                    "Unicode range wildcard range"
                    [ FontFace.UnicodeRange.value "U+4??" ]
                    "unicode-range: U+4??;" 
                testFontCase
                    "Unicode range multiple"
                    [ FontFace.UnicodeRange.value [ "U+0025-00FF"; "U+4??" ] ]
                    "unicode-range: U+0025-00FF, U+4??;" 
                testFontCase
                    "Linegap override normal"
                    [ FontFace.LineGapOverride.normal ]
                    "line-gap-override: normal;" 
                testFontCase
                    "Linegap override percent"
                    [ FontFace.LineGapOverride.value <| pct 90 ]
                    "line-gap-override: 90%;"
                testFontCase
                    "Variation settings"
                    [ FontFace.FontVariationSettings.value ("wght", 400) ]
                    "font-variation-settings: 'wght' 400;" 
                testFontCase
                    "Variation settings"
                    [ FontFace.FontVariationSettings.value [ "wght", 400.; "wdth", 300. ] ]
                    "font-variation-settings: 'wght' 400, 'wdth' 300;"
                testFontCase
                    "Ascent override"
                    [ FontFace.AscentOverride.normal ]
                    "ascent-override: normal;"
                testFontCase
                    "Ascent override"
                    [ FontFace.AscentOverride.value <| pct 40]
                    "ascent-override: 40%;"
                testFontCase
                    "Descent override"
                    [ FontFace.DescentOverride.normal ]
                    "descent-override: normal;"
                testFontCase
                    "Descent override"
                    [ FontFace.DescentOverride.value <| pct 40]
                    "descent-override: 40%;"
                testFontCase
                    "Fontface fontname ident"
                    [ FontFace.FontFamily.ident "FontName" ]
                    "font-family: FontName;" 
                testFontCase
                    "Fontface fontname string"
                    [ FontFace.FontFamily.string "font family" ]
                    "font-family: \"font family\";"


            ]