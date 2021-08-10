namespace FSSTests

open Fet
open Fable.Core.JsInterop
open Utils
open Fss

module FontFace =
     let tests =
        testList "Font face"
            [
                testCase
                    "Single source"
                    [ FontFace.source <| FssTypes.FontFace.UrlFormat ("someFontUrl", FssTypes.FontFace.Woff2) ]
                    [ "src" ==> "url('someFontUrl') format('woff2')" ]
                testCase
                    "Multiple sources"
                    [ FontFace.sources
                        [
                            FssTypes.FontFace.UrlFormat ("url1", FssTypes.FontFace.Woff2)
                            FssTypes.FontFace.UrlFormat ("url2", FssTypes.FontFace.Woff)
                            FssTypes.FontFace.UrlFormat ("url3", FssTypes.FontFace.Truetype)
                            FssTypes.FontFace.UrlFormat ("url4", FssTypes.FontFace.Svg)
                        ]
                    ]
                    [ "src" ==> "url('url1') format('woff2'), url('url2') format('woff'), url('url3') format('truetype'), url('url4') format('svg')" ]
                testCase
                    "Display auto"
                    [ FontFace.display FssTypes.Auto ]
                    [ "fontDisplay" ==> "auto"]
                testCase
                    "Display block"
                    [ FontFace.display FssTypes.Font.Display.Block ]
                    [ "fontDisplay" ==> "block"]
                testCase
                    "Display swap"
                    [ FontFace.display FssTypes.Font.Display.Swap ]
                    [ "fontDisplay" ==> "swap"]
                testCase
                    "Display fallback"
                    [ FontFace.display FssTypes.Font.Display.Fallback ]
                    [ "fontDisplay" ==> "fallback"]
                testCase
                    "Display optional"
                    [ FontFace.display FssTypes.Font.Display.Optional ]
                    [ "fontDisplay" ==> "optional"]

                testCase
                    "Font style normal"
                    [ FontFace.style FssTypes.Normal ]
                    [ "fontStyle" ==> "normal" ]
                testCase
                    "Font style inherit"
                    [ FontFace.style FssTypes.Inherit ]
                    [ "fontStyle" ==> "inherit" ]
                testCase
                    "Font style initial"
                    [ FontFace.style FssTypes.Initial ]
                    [ "fontStyle" ==> "initial" ]
                testCase
                    "Font style unset"
                    [ FontFace.style FssTypes.Unset ]
                    [ "fontStyle" ==> "unset" ]
                testCase
                    "Font style italic"
                    [ FontFace.style FssTypes.Font.Style.Italic ]
                    [ "fontStyle" ==> "italic" ]
                testCase
                    "Font style oblique"
                    [ FontFace.style (FssTypes.Font.Style.Oblique (deg 90.)) ]
                    [ "fontStyle" ==> "oblique 90.00deg" ]

                testCase
                    "Font stretch Semi Condensed"
                    [ FontFace.stretch FssTypes.Font.SemiCondensed ]
                    [ "fontStretch" ==> "semi-condensed" ]
                testCase
                    "Font stretch extra Condensed"
                    [ FontFace.stretch FssTypes.Font.ExtraCondensed ]
                    [ "fontStretch" ==> "extra-condensed" ]
                testCase
                    "Font stretch Condensed"
                    [ FontFace.stretch FssTypes.Font.Condensed ]
                    [ "fontStretch" ==> "condensed" ]
                testCase
                    "Font stretch ultra Condensed"
                    [ FontFace.stretch FssTypes.Font.UltraCondensed ]
                    [ "fontStretch" ==> "ultra-condensed" ]
                testCase
                    "Font stretch Semi expanded"
                    [ FontFace.stretch FssTypes.Font.SemiExpanded ]
                    [ "fontStretch" ==> "semi-expanded" ]
                testCase
                    "Font stretch ultra expanded"
                    [ FontFace.stretch FssTypes.Font.UltraExpanded ]
                    [ "fontStretch" ==> "ultra-expanded" ]
                testCase
                    "Font stretch extra expanded"
                    [ FontFace.stretch FssTypes.Font.ExtraExpanded ]
                    [ "fontStretch" ==> "extra-expanded" ]
                testCase
                    "Font stretch expanded"
                    [ FontFace.stretch FssTypes.Font.Expanded ]
                    [ "fontStretch" ==> "expanded" ]
                testCase
                    "Font stretch normal"
                    [ FontFace.stretch FssTypes.Normal ]
                    [ "fontStretch" ==> "normal" ]
                testCase
                    "Font stretch inherit"
                    [ FontFace.stretch FssTypes.Inherit ]
                    [ "fontStretch" ==> "inherit" ]
                testCase
                    "Font stretch initial"
                    [ FontFace.stretch FssTypes.Initial ]
                    [ "fontStretch" ==> "initial" ]
                testCase
                    "Font stretch unset"
                    [ FontFace.stretch FssTypes.Unset ]
                    [ "fontStretch" ==> "unset" ]
                testCase
                    "Font stretch percent"
                    [ FontFace.stretch <| pct 10]
                    [ "fontStretch" ==> "10%" ]

                testCase
                    "Font weight bold"
                    [FontFace.weight FssTypes.Font.Bold]
                    ["fontWeight" ==> "bold"]
                testCase
                    "Font weight bolder"
                    [FontFace.weight FssTypes.Font.Bolder]
                    ["fontWeight" ==> "bolder"]
                testCase
                    "Font weight Lighter"
                    [FontFace.weight FssTypes.Font.Lighter]
                    ["fontWeight" ==> "lighter"]
                testCase
                    "Font weight int"
                    [FontFace.weight <| FssTypes.CssInt 400]
                    ["fontWeight" ==> "400"]
                testCase
                    "Font weight inherit"
                    [ FontFace.weight FssTypes.Inherit ]
                    [ "fontWeight" ==> "inherit" ]
                testCase
                    "Font weight initial"
                    [ FontFace.weight FssTypes.Initial ]
                    [ "fontWeight" ==> "initial" ]
                testCase
                    "Font weight unset"
                    [ FontFace.weight FssTypes.Unset ]
                    [ "fontWeight" ==> "unset" ]
                testCase
                    "Font weight normal"
                    [ FontFace.weight FssTypes.Normal ]
                    [ "fontWeight" ==> "normal" ]
                testCase
                    "Font size adjust"
                    [ FontFace.sizeAdjust <| pct 50 ]
                    [ "sizeAdjust" ==> "50%" ]

                testCase
                    "Unicode range single"
                    [ FontFace.unicodeRange "U+26" ]
                    [ "unicodeRange" ==> "U+26" ]
                testCase
                    "Unicode range single"
                    [ FontFace.unicodeRange "U+0-7F" ]
                    [ "unicodeRange" ==> "U+0-7F" ]
                testCase
                    "Unicode range code point range"
                    [ FontFace.unicodeRange "U+0025-00FF" ]
                    [ "unicodeRange" ==> "U+0025-00FF" ]
                testCase
                    "Unicode range wildcard range"
                    [ FontFace.unicodeRange "U+4??" ]
                    [ "unicodeRange" ==> "U+4??" ]
                testCase
                    "Unicode range multiple"
                    [ FontFace.unicodeRanges [ "U+0025-00FF"; "U+4??" ] ]
                    [ "unicodeRange" ==> "U+0025-00FF, U+4??" ]
            ]