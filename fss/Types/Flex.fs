namespace Fss

namespace Fss.Types
    [<RequireQualifiedAccess>]
    module Flex =
        type AlignContent =
            | Start
            | End
            | FlexStart
            | FlexEnd
            | Center
            | Baseline
            | FirstBaseline
            | LastBaseline
            | Stretch
            | Safe
            | Unsafe
            | SpaceBetween
            | SpaceAround
            | SpaceEvenly
            interface IAlignContent

        type AlignItems =
            | Start
            | End
            | FlexStart
            | FlexEnd
            | Center
            | Baseline
            | FirstBaseline
            | LastBaseline
            | Stretch
            | Safe
            | Unsafe
            | SelfStart
            | SelfEnd
            interface IAlignItems

        type AlignSelf =
            | Start
            | End
            | FlexStart
            | FlexEnd
            | Center
            | Baseline
            | FirstBaseline
            | LastBaseline
            | Stretch
            | Safe
            | Unsafe
            | SelfStart
            | SelfEnd
            interface IAlignSelf

        type JustifyContent =
            | Start
            | End
            | FlexStart
            | FlexEnd
            | Center
            | Baseline
            | FirstBaseline
            | LastBaseline
            | Stretch
            | Safe
            | Unsafe
            | SpaceBetween
            | SpaceAround
            | SpaceEvenly
            | Left
            | Right
            interface IJustifyContent

        type JustifyItems =
            | Start
            | End
            | FlexStart
            | FlexEnd
            | Center
            | Baseline
            | FirstBaseline
            | LastBaseline
            | Stretch
            | Safe
            | Unsafe
            | Left
            | Right
            | SelfStart
            | SelfEnd
            | Legacy
            interface IJustifyItems

        type JustifySelf =
            | Start
            | End
            | FlexStart
            | FlexEnd
            | Center
            | Baseline
            | FirstBaseline
            | LastBaseline
            | Stretch
            | Safe
            | Unsafe
            | SelfStart
            | SelfEnd
            interface IJustifySelf

        type Wrap =
            | NoWrap
            | Wrap
            | WrapReverse
            interface IFlexWrap

        type Direction =
            | Row
            | RowReverse
            | Column
            | ColumnReverse
            interface IFlexDirection

        type Basis =
            | Fill
            | MaxContent
            | MinContent
            | FitContent
            | Content
            interface IFlexBasis

