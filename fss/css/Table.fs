namespace Fss

module TableType =
    type CaptionSide =
        | Top
        | Bottom
        | Left
        | Right
        | TopOutside
        | BottomOutside
        interface ICaptionSide

[<AutoOpen>]
module Table =
    open TableType
    let private captionSideToString (captionSide: ICaptionSide) =
        let stringifySide =
            function
                | Top -> "top"
                | Bottom -> "bottom"
                | Left -> "left"
                | Right -> "right"
                | TopOutside -> "top-outside"
                | BottomOutside -> "bottom-outside"

        match captionSide with
        | :? CaptionSide as c -> stringifySide c
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown caption side"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/caption-side
    let private captionSideValue value = PropertyValue.cssValue Property.CaptionSide value
    let private captionSideValue' value =
        value
        |> captionSideToString
        |> captionSideValue

    type CaptionSide =
        static member Value (captionSide: ICaptionSide) = captionSide |> captionSideValue'
        static member Top = Top |> captionSideValue'
        static member Bottom = Bottom |> captionSideValue'
        static member Left = Left |> captionSideValue'
        static member Right = Right |> captionSideValue'
        static member TopOutside = TopOutside |> captionSideValue'
        static member BottomOutside = BottomOutside |> captionSideValue'
        static member Inherit = Inherit |> captionSideValue'
        static member Initial = Initial |> captionSideValue'
        static member Unset = Unset |> captionSideValue'

    let CaptionSide' captionSide = CaptionSide.Value captionSide