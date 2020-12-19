namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
[<AutoOpen>]
module Margin =
    let private marginToString (margin: IMargin) =
        match margin with
        | :? Units.Size.Size as s -> Units.Size.value s
        | :? Units.Percent.Percent as p -> Units.Percent.value p
        | :? Global as k -> GlobalValue.global' k
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown margin"

    let private marginValue value = PropertyValue.cssValue Property.Margin value
    let private marginValue' value =
        value
        |> marginToString
        |> marginValue

    type Margin =
        static member Value (width: IMargin) = width |> marginValue'

        static member Value (vertical: IMargin, horizontal: IMargin) =
            sprintf "%s %s"
                (marginToString vertical)
                (marginToString horizontal)
            |> marginValue
        static member Value (top: IMargin, auto: IMargin, bottom: IMargin) =
            sprintf "%s %s %s"
                (marginToString top)
                (marginToString auto)
                (marginToString bottom)
            |> marginValue
        static member Value (top: IMargin, right: IMargin, bottom: IMargin, left: IMargin) =
            sprintf "%s %s %s %s"
                (marginToString top)
                (marginToString right)
                (marginToString bottom)
                (marginToString left)
            |> marginValue
        static member Auto = Auto |> marginValue'
        static member Inherit = Inherit |> marginValue'
        static member Initial = Initial |> marginValue'
        static member Unset = Unset |> marginValue'

    let Margin' (margin: IMargin) = Margin.Value(margin)

    let private marginTopValue value = PropertyValue.cssValue Property.MarginTop value
    let private marginTopValue' value =
        value
        |> marginToString
        |> marginTopValue
    type MarginTop =
        static member Value (top: IMargin) = top |> marginTopValue'
        static member Auto = Auto |> marginTopValue'
        static member Inherit = Inherit |> marginTopValue'
        static member Initial = Initial |> marginTopValue'
        static member Unset = Unset |> marginTopValue'

    let MarginTop' (top: IMargin) = MarginTop.Value(top)

    let private marginRightValue value = PropertyValue.cssValue Property.MarginRight value
    let private marginRightValue' value =
        value
        |> marginToString
        |> marginRightValue
    type MarginRight =
        static member Value (right: IMargin) = right |> marginRightValue'
        static member Auto = Auto |> marginRightValue'
        static member Inherit = Inherit |> marginRightValue'
        static member Initial = Initial |> marginRightValue'
        static member Unset = Unset |> marginRightValue'
    let MarginRight' (right: IMargin) = MarginRight.Value(right)

    let private marginBottomValue value = PropertyValue.cssValue Property.MarginBottom value
    let private marginBottomValue' value =
        value
        |> marginToString
        |> marginBottomValue
    type MarginBottom =
        static member Value (bottom: IMargin) = bottom |> marginBottomValue'
        static member Auto = Auto |> marginBottomValue'
        static member Inherit = Inherit |> marginBottomValue'
        static member Initial = Initial |> marginBottomValue'
        static member Unset = Unset |> marginBottomValue'
    let MarginBottom' (bottom: IMargin) = MarginBottom.Value(bottom)

    let private marginLeftValue value = PropertyValue.cssValue Property.MarginLeft value
    let private marginLeftValue' value =
        value
        |> marginToString
        |> marginLeftValue
    type MarginLeft =
        static member Value (left: IMargin) = left |> marginLeftValue'
        static member Auto = Auto |> marginLeftValue'
        static member Inherit = Inherit |> marginLeftValue'
        static member Initial = Initial |> marginLeftValue'
        static member Unset = Unset |> marginLeftValue'

    let MarginLeft' (left: IMargin) = MarginLeft.Value(left)
