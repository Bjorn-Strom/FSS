namespace Fss

module ResizeType =
    type Resize =
        | Both
        | Horizontal
        | Vertical
        | Block
        | Inline
        interface IResize

[<AutoOpen>]
module Resize =
    open ResizeType

    let private resizeToString (resize: IResize) =
        let stringifyResize =
            function
                | Both -> "both"
                | Horizontal -> "horizontal"
                | Vertical -> "vertical"
                | Block -> "block"
                | Inline -> "inline"

        match resize with
        | :? Resize as r -> stringifyResize r
        | :? None -> GlobalValue.none
        | :? Keywords as k -> GlobalValue.keywords k
        | _ -> "Unknown resize value"

    let private resizeValue value = PropertyValue.cssValue Property.Resize value
    let private resizeValue' value =
        value
        |> resizeToString
        |> resizeValue

    type Resize =
        static member Value (resize: IResize) = resize |> resizeValue'
        static member Both = Both |> resizeValue'
        static member Horizontal = Horizontal |> resizeValue'
        static member Vertical = Vertical |> resizeValue'
        static member Block = Block |> resizeValue'
        static member Inline = Inline |> resizeValue'
        static member None = None |> resizeValue'
        static member Initial = Initial |> resizeValue'
        static member Inherit = Inherit |> resizeValue'
        static member Unset = Unset |> resizeValue'

    let Resize' (resize: IResize) = Resize.Value resize