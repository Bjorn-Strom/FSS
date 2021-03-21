namespace Fss

open FssTypes
open FssTypes.Units

[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: IClipPath) =
        let stringifyInset =
            function
                | All a -> LengthPercentage.value a
                | HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (LengthPercentage.value h)
                        (LengthPercentage.value v)
                | TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (LengthPercentage.value t)
                        (LengthPercentage.value h)
                        (LengthPercentage.value b)
                | TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (LengthPercentage.value t)
                        (LengthPercentage.value r)
                        (LengthPercentage.value b)
                        (LengthPercentage.value l)
        let stringifyRound r = Utilities.Helpers.combineWs LengthPercentage.value r
        let stringifyPolygon p =
            let unboxPolygon (Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (LengthPercentage.value x)
                    (LengthPercentage.value y))

        match clipPath with
        | :? Geometry as g -> Utilities.Helpers.duToKebab g
        | :? Inset as i -> sprintf "inset(%s)" <| stringifyInset i
        | :? Round as r ->
            let unboxRound (Round(r, i)) = i, r
            let (r, i) = unboxRound r
            sprintf "inset(%s round %s)"
                (stringifyInset i)
                (stringifyRound r)
        | :? Polygon as p ->
            sprintf "polygon(%s)" <| stringifyPolygon p
        | :? Global as g -> global' g
        | :? None' -> none
        | _ -> "Unknown clip path"

    let private clipPathValue value = PropertyValue.cssValue Property.ClipPath value
    let private clipPathValue' value =
        value
        |> stringifyClipPath
        |> clipPathValue

    type ClipPath =
        static member Inset (inset: ILengthPercentage) =
            FssTypes.Inset.All inset
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            FssTypes.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage) =
            FssTypes.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage) =
            FssTypes.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member Inset (inset: ILengthPercentage, round: ILengthPercentage list) =
            FssTypes.Round (FssTypes.Inset.All inset, round)
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage, round: ILengthPercentage list) =
            FssTypes.Round (FssTypes.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage, round: ILengthPercentage list) =
            FssTypes.Round (FssTypes.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage, round: ILengthPercentage list) =
            FssTypes.Round (FssTypes.Inset.TopRightBottomLeft(top, right, bottom, left), round)
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
        static member Polygon (points: Point list) =
            FssTypes.Polygon points
            |> clipPathValue'

        static member MarginBox = FssTypes.MarginBox |> clipPathValue'
        static member BorderBox = FssTypes.BorderBox |> clipPathValue'
        static member PaddingBox = FssTypes.PaddingBox |> clipPathValue'
        static member ContentBox = FssTypes.ContentBox |> clipPathValue'
        static member FillBox = FssTypes.FillBox |> clipPathValue'
        static member StrokeBox = FssTypes.StrokeBox |> clipPathValue'
        static member ViewBox = FssTypes.ViewBox |> clipPathValue'

        static member None = None' |> clipPathValue'
        static member Inherit = Inherit |> clipPathValue'
        static member Initial = Initial |> clipPathValue'
        static member Unset = Unset |> clipPathValue'