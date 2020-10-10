namespace FSSTests

open FSSTests
open Fable.Mocha

module Tests =
    let tests =
            testList "Fss Tests" [
                ListStyle.tests
                PsuedoClasses.tests
                Cursor.tests
                Text.tests
                Descendant.tests
                Transition.tests
                Transform.tests
                Animation.tests
                Padding.tests
                Margin.tests
                Visibility.tests
                Position.tests
                Flex.tests
                Display.tests
                Perspective.tests
                ContentSize.tests
                Border.tests
                Font.tests
                Color.tests
                Background.tests
            ]

    Mocha.runTests tests |> ignore
