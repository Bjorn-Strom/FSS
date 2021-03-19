namespace Fss

open FssTypes
open FssTypes.Units

[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: IClipPath) =
        let stringifyInset =
            function
                | ClipPath.All a -> LengthPercentage.value a
                | ClipPath.HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (LengthPercentage.value h)
                        (LengthPercentage.value v)
                | ClipPath.TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (LengthPercentage.value t)
                        (LengthPercentage.value h)
                        (LengthPercentage.value b)
                | ClipPath.TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (LengthPercentage.value t)
                        (LengthPercentage.value r)
                        (LengthPercentage.value b)
                        (LengthPercentage.value l)
        let stringifyRound r = Utilities.Helpers.combineWs LengthPercentage.value r
        let stringifyPolygon p =
            let unboxPolygon (ClipPath.Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (LengthPercentage.value x)
                    (LengthPercentage.value y))

        match clipPath with
        | :? ClipPath.Geometry as g -> Utilities.Helpers.duToKebab g
        | :? ClipPath.Inset as i -> sprintf "inset(%s)" <| stringifyInset i
        | :? ClipPath.Round as r ->
            let unboxRound (ClipPath.Round (r, i)) = i, r
            let (r, i) = unboxRound r
            sprintf "inset(%s round %s)"
                (stringifyInset i)
                (stringifyRound r)
        | :? ClipPath.Polygon as p ->
            sprintf "polygon(%s)" <| stringifyPolygon p
        | :? Global as g -> GlobalValue.global' g
        | :? None' -> GlobalValue.none
        | _ -> "Unknown clip path"

    let private clipPathValue value = PropertyValue.cssValue Property.ClipPath value
    let private clipPathValue' value =
        value
        |> stringifyClipPath
        |> clipPathValue

    type ClipPath =
        static member Inset (inset: ILengthPercentage) =
            ClipPath.Inset.All inset
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            ClipPath.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage) =
            ClipPath.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage) =
            ClipPath.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member Inset (inset: ILengthPercentage, round: ILengthPercentage list) =
            ClipPath.Round (ClipPath.Inset.All inset, round)
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage, round: ILengthPercentage list) =
            ClipPath.Round (ClipPath.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage, round: ILengthPercentage list) =
            ClipPath.Round (ClipPath.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage, round: ILengthPercentage list) =
            ClipPath.Round (ClipPath.Inset.TopRightBottomLeft(top, right, bottom, left), round)
            |> clipPathValue'
        static member Circle (radius: ILengthPercentage) =
            sprintf "circle(%s)"
                (LengthPercentage.value radius)
            |> clipPathValue
        static member CircleAt (radius: ILengthPercentage, x: ILengthPercentage, y: ILengthPercentage) =
            sprintf "circle(%s at %s %s)"
                (LengthPercentage.value radius)
                (LengthPercentage.value x)
                (LengthPercentage.value y)
            |> clipPathValue
        static member Ellipse (radius: ILengthPercentage) =
            sprintf "ellipse(%s)"
                (LengthPercentage.value radius)
            |> clipPathValue
        static member EllipseAt (radius: ILengthPercentage, x: ILengthPercentage, y: ILengthPercentage) =
            sprintf "ellipse(%s at %s %s)"
                (LengthPercentage.value radius)
                (LengthPercentage.value x)
                (LengthPercentage.value y)
            |> clipPathValue
        static member Url (url: string) =
            sprintf "url(%s)" url
            |> clipPathValue
        static member Path (path: string) =
            sprintf "path('%s')" path
            |> clipPathValue
        static member Polygon (points: ClipPath.Point list) =
            ClipPath.Polygon points
            |> clipPathValue'

        static member MarginBox = ClipPath.MarginBox |> clipPathValue'
        static member BorderBox = ClipPath.BorderBox |> clipPathValue'
        static member PaddingBox = ClipPath.PaddingBox |> clipPathValue'
        static member ContentBox = ClipPath.ContentBox |> clipPathValue'
        static member FillBox = ClipPath.FillBox |> clipPathValue'
        static member StrokeBox = ClipPath.StrokeBox |> clipPathValue'
        static member ViewBox = ClipPath.ViewBox |> clipPathValue'

        static member None = None' |> clipPathValue'
        static member Inherit = Inherit |> clipPathValue'
        static member Initial = Initial |> clipPathValue'
        static member Unset = Unset |> clipPathValue'