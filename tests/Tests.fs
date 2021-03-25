namespace FSSTests

open FSSTests
open Fable.Mocha

module Tests =
    let tests =
            testList "Fss Tests" [
                Mask.tests
                AspectRatio.tests
                MixBlendMode.tests
                Filter.tests
                Clear.tests
                ClipPath.tests
                Scroll.tests
                PointerEvents.tests
                Custom.tests
                BoxShadow.tests
                Counter.tests
                All.tests
                Typography.tests
                Appearance.tests
                Caret.tests
                Table.tests
                Column.tests
                Word.tests
                Resize.tests
                Grid.tests
                Keyframes.tests
                Media.tests
                Content.tests
                ListStyle.tests
                Cursor.tests
                Text.tests
                Transition.tests
                Transform.tests
                Animation.tests
                Padding.tests
                Margin.tests
                Visibility.tests
                Position.tests
                Perspective.tests
                Border.tests
                Font.tests
                Color.tests
                ContentSize.tests
                Display.tests
                Flex.tests
                Outline.tests
                Background.tests
            ]

    Mocha.runTests tests |> ignore

