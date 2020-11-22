namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss
open Fss.Keyframes

module FontFace =
    let tests =
        testList "FontFace"
            [
                testFontFace
                    ""
                    [
                        FontFace.Sources
                            [
                                FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2", FontFace.Woff2)
                                FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff", FontFace.Woff)
                                FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf", FontFace.Truetype)
                                FontFace.Url ("https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg", FontFace.Svg)
                            ]
                        FontFace.Weight Normal
                        FontFace.Style Normal
                    ]
                    []
            ]
