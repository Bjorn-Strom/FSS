namespace FSSTests

open Fss
open Fss.Types
open Fet

module CustomPropertyTests =
    let tests =
        testList "CustomProperty"
            [
                test "Property with color syntax" <| fun _ ->
                    let actual = createProperty "--my-color" CustomProperty.Color false "red"
                    Expect.equal actual "@property --my-color{syntax:\"<color>\";inherits:false;initial-value:red;}"

                test "Property with length syntax and inherits" <| fun _ ->
                    let actual = createProperty "--spacing" CustomProperty.Length true "0px"
                    Expect.equal actual "@property --spacing{syntax:\"<length>\";inherits:true;initial-value:0px;}"

                test "Property with number syntax" <| fun _ ->
                    let actual = createProperty "--opacity" CustomProperty.Number false "1"
                    Expect.equal actual "@property --opacity{syntax:\"<number>\";inherits:false;initial-value:1;}"

                test "Property with percentage syntax" <| fun _ ->
                    let actual = createProperty "--progress" CustomProperty.Percentage false "0%"
                    Expect.equal actual "@property --progress{syntax:\"<percentage>\";inherits:false;initial-value:0%;}"

                test "Property with any syntax" <| fun _ ->
                    let actual = createProperty "--theme" CustomProperty.Any true "light"
                    Expect.equal actual "@property --theme{syntax:\"*\";inherits:true;initial-value:light;}"

                test "Property with length-percentage syntax" <| fun _ ->
                    let actual = createProperty "--size" CustomProperty.LengthPercentage false "100%"
                    Expect.equal actual "@property --size{syntax:\"<length-percentage>\";inherits:false;initial-value:100%;}"

                test "Property with custom syntax" <| fun _ ->
                    let actual = createProperty "--my-val" (CustomProperty.Custom "<color>+") false "red"
                    Expect.equal actual "@property --my-val{syntax:\"<color>+\";inherits:false;initial-value:red;}"

                test "Property with angle syntax" <| fun _ ->
                    let actual = createProperty "--rotation" CustomProperty.Angle false "0deg"
                    Expect.equal actual "@property --rotation{syntax:\"<angle>\";inherits:false;initial-value:0deg;}"
            ]
