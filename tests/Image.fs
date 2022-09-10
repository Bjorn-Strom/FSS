namespace FSSTests

open Fet
open Utils
open Fss

module ImageTests =
     let tests =
        testList "Image"
            [
                testCase
                    "Object fit fill"
                    [ ObjectFit.fill ]
                    "{object-fit:fill;}"
                testCase
                    "Object fit contain"
                    [ ObjectFit.contain ]
                    "{object-fit:contain;}"
                testCase
                    "Object fit cover"
                    [ ObjectFit.cover ]
                    "{object-fit:cover;}"
                testCase
                    "Object fit scaleDown"
                    [ ObjectFit.scaleDown ]
                    "{object-fit:scale-down;}"
                testCase
                    "Object fit none"
                    [ ObjectFit.none ]
                    "{object-fit:none;}"
                testCase
                    "ObjectPosition pixels"
                    [ ObjectPosition.value (px 10, px 10)]
                    "{object-position:10px 10px;}"
                testCase
                    "ObjectPosition percent"
                    [ ObjectPosition.value (pct 50, pct 50)]
                    "{object-position:50% 50%;}"
                testCase
                    "ObjectPosition percent and pixels"
                    [ ObjectPosition.value (pct 50, px 50)]
                    "{object-position:50% 50px;}"
                testCase
                    "ObjectPosition inherit"
                    [ ObjectPosition.inherit']
                    "{object-position:inherit;}"
                testCase
                    "ObjectPosition initial"
                    [ ObjectPosition.initial]
                    "{object-position:initial;}"
                testCase
                    "ObjectPosition unset"
                    [ ObjectPosition.unset ]
                    "{object-position:unset;}"
                testCase
                    "ObjectPosition revert"
                    [ ObjectPosition.revert ]
                    "{object-position:revert;}"
                testCase
                    "ImageRendering auto"
                    [ ImageRendering.auto]
                    "{image-rendering:auto;}"
                testCase
                    "ImageRendering crispEdges"
                    [ ImageRendering.crispEdges]
                    "{image-rendering:crisp-edges;}"
                testCase
                    "ImageRendering pixelated"
                    [ ImageRendering.pixelated ]
                    "{image-rendering:pixelated;}"
                testCase
                    "ImageRendering inherit"
                    [ ImageRendering.inherit']
                    "{image-rendering:inherit;}"
                testCase
                    "ImageRendering initial"
                    [ ImageRendering.initial]
                    "{image-rendering:initial;}"
                testCase
                    "ImageRendering unset"
                    [ ImageRendering.unset ]
                    "{image-rendering:unset;}"
                testCase
                    "ImageRendering revert"
                    [ ImageRendering.revert ]
                    "{image-rendering:revert;}"
            ]
