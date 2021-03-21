namespace Fss

namespace Fss.Types
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

    type FlexWrap =
        | NoWrap
        | Wrap
        | WrapReverse
        interface IFlexWrap

    type FlexDirection =
        | Row
        | RowReverse
        | Column
        | ColumnReverse
        interface IFlexDirection

    type FlexBasis =
        | Fill
        | MaxContent
        | MinContent
        | FitContent
        | Content
        interface IFlexBasis

