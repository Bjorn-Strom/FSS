namespace Fss

open FssTypes
open Types.Units

[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: IClipPath) =
        let stringifyInset =
            function
                | All a -> LengthPercentage.lengthPercentageToString a
                | HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (LengthPercentage.lengthPercentageToString h)
                        (LengthPercentage.lengthPercentageToString v)
                | TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (LengthPercentage.lengthPercentageToString t)
                        (LengthPercentage.lengthPercentageToString h)
                        (LengthPercentage.lengthPercentageToString b)
                | TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (LengthPercentage.lengthPercentageToString t)
                        (LengthPercentage.lengthPercentageToString r)
                        (LengthPercentage.lengthPercentageToString b)
                        (LengthPercentage.lengthPercentageToString l)
        let stringifyRound r = Utilities.Helpers.combineWs LengthPercentage.lengthPercentageToString r
        let stringifyPolygon p =
            let unboxPolygon (Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (LengthPercentage.lengthPercentageToString x)
                    (LengthPercentage.lengthPercentageToString y))

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
        | :? Types.Keywords as k -> Types.keywordsToString k
        | :? Types.None' -> Types.none
        | _ -> "Unknown clip path"

    let private clipPathValue value = Types.cssValue Types.Property.ClipPath value
    let private clipPathValue' value =
        value
        |> stringifyClipPath
        |> clipPathValue

    type ClipPath =
        static member Inset (inset: ILengthPercentage) =
            Types.Inset.All inset
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            Types.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage) =
            Types.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage) =
            Types.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member Inset (inset: ILengthPercentage, round: ILengthPercentage list) =
            Types.Round (Types.Inset.All inset, round)
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage, round: ILengthPercentage list) =
            Types.Round (Types.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage, round: ILengthPercentage list) =
            Types.Round (Types.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage, round: ILengthPercentage list) =
            Types.Round (Types.Inset.TopRightBottomLeft(top, right, bottom, left), round)
            |> clipPathValue'
        static member Circle (radius: ILengthPercentage) =
            sprintf "circle(%s)"
                (LengthPercentage.lengthPercentageToString radius)
            |> clipPathValue
        static member CircleAt (radius: ILengthPercentage, x: ILengthPercentage, y: ILengthPercentage) =
            sprintf "circle(%s at %s %s)"
                (LengthPercentage.lengthPercentageToString radius)
                (LengthPercentage.lengthPercentageToString x)
                (LengthPercentage.lengthPercentageToString y)
            |> clipPathValue
        static member Ellipse (radius: ILengthPercentage) =
            sprintf "ellipse(%s)"
                (LengthPercentage.lengthPercentageToString radius)
            |> clipPathValue
        static member EllipseAt (radius: ILengthPercentage, x: ILengthPercentage, y: ILengthPercentage) =
            sprintf "ellipse(%s at %s %s)"
                (LengthPercentage.lengthPercentageToString radius)
                (LengthPercentage.lengthPercentageToString x)
                (LengthPercentage.lengthPercentageToString y)
            |> clipPathValue
        static member Url (url: string) =
            sprintf "url(%s)" url
            |> clipPathValue
        static member Path (path: string) =
            sprintf "path('%s')" path
            |> clipPathValue
        static member Polygon (points: Point list) =
            Types.Polygon points
            |> clipPathValue'

        static member MarginBox = Types.MarginBox |> clipPathValue'
        static member BorderBox = Types.BorderBox |> clipPathValue'
        static member PaddingBox = Types.PaddingBox |> clipPathValue'
        static member ContentBox = Types.ContentBox |> clipPathValue'
        static member FillBox = Types.FillBox |> clipPathValue'
        static member StrokeBox = Types.StrokeBox |> clipPathValue'
        static member ViewBox = Types.ViewBox |> clipPathValue'

        static member None = Types.None' |> clipPathValue'
        static member Inherit = Types.Inherit |> clipPathValue'
        static member Initial = Types.Initial |> clipPathValue'
        static member Unset = Types.Unset |> clipPathValue'