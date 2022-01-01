namespace FSSTests

open FSSTests
open Fet

module Tests =
    runTests [
        Border.tests
        ContentSize.tests
        Margin.tests
        Padding.tests
        Color.tests
        Background.tests
        Cursor.tests
        Grid.tests
        Display.tests
        Flex.tests
        Perspective.tests
        Text.tests
        Position.tests
        Resize.tests
        Transition.tests
        Visibility.tests
        ListStyle.tests
        Content.tests
        Column.tests
        Outline.tests
        PointerEvents.tests
        Caret.tests
        ClipPath.tests
        AspectRatio.tests
        Clear.tests
        Appearance.tests
        Typography.tests
        MixBlendMode.tests
        Filter.tests
        Custom.tests
        BoxShadow.tests
        All.tests
        Scroll.tests
        Table.tests
        Word.tests
        WillChange.tests
        Image.tests
        Mask.tests
        Svg.tests
        Counter.tests
        Animation.tests
        Font.tests
        Transform.tests
        Psuedo.tests
        FontFace.tests
        Composite.tests
        Media.tests
        Selector.tests
    ]

