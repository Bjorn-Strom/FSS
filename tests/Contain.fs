namespace FSSTests

open Fet
open Utils
open Fss

module ContainTests =
    let tests =
        testList "Contain"
            [
                testCase
                    "contain none"
                    [ Contain.none ]
                    "{contain:none;}"
                testCase
                    "contain strict"
                    [ Contain.strict ]
                    "{contain:strict;}"
                testCase
                    "contain content"
                    [ Contain.content ]
                    "{contain:content;}"
                testCase
                    "contain size"
                    [ Contain.size ]
                    "{contain:size;}"
                testCase
                    "contain inline-size"
                    [ Contain.inlineSize ]
                    "{contain:inline-size;}"
                testCase
                    "contain layout"
                    [ Contain.layout ]
                    "{contain:layout;}"
                testCase
                    "contain style"
                    [ Contain.style ]
                    "{contain:style;}"
                testCase
                    "contain paint"
                    [ Contain.paint ]
                    "{contain:paint;}"
                testCase
                    "contain combined"
                    [ Contain.value [ "layout"; "paint" ] ]
                    "{contain:layout paint;}"
                testCase
                    "contain inherit"
                    [ Contain.inherit' ]
                    "{contain:inherit;}"
                testCase
                    "contain initial"
                    [ Contain.initial ]
                    "{contain:initial;}"
                testCase
                    "contain unset"
                    [ Contain.unset ]
                    "{contain:unset;}"
                testCase
                    "contain revert"
                    [ Contain.revert ]
                    "{contain:revert;}"
                // ContentVisibility
                testCase
                    "content-visibility visible"
                    [ ContentVisibility.visible ]
                    "{content-visibility:visible;}"
                testCase
                    "content-visibility auto"
                    [ ContentVisibility.auto ]
                    "{content-visibility:auto;}"
                testCase
                    "content-visibility hidden"
                    [ ContentVisibility.hidden ]
                    "{content-visibility:hidden;}"
                testCase
                    "content-visibility inherit"
                    [ ContentVisibility.inherit' ]
                    "{content-visibility:inherit;}"
                testCase
                    "content-visibility initial"
                    [ ContentVisibility.initial ]
                    "{content-visibility:initial;}"
                testCase
                    "content-visibility unset"
                    [ ContentVisibility.unset ]
                    "{content-visibility:unset;}"
                testCase
                    "content-visibility revert"
                    [ ContentVisibility.revert ]
                    "{content-visibility:revert;}"
            ]
