namespace Fss

[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: Types.IClipPath) =
        let stringifyInset =
            function
                | Types.All a -> Types.lengthPercentageToString a
                | Types.HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (Types.lengthPercentageToString h)
                        (Types.lengthPercentageToString v)
                | Types.TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (Types.lengthPercentageToString t)
                        (Types.lengthPercentageToString h)
                        (Types.lengthPercentageToString b)
                | Types.TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (Types.lengthPercentageToString t)
                        (Types.lengthPercentageToString r)
                        (Types.lengthPercentageToString b)
                        (Types.lengthPercentageToString l)
        let stringifyRound r = Utilities.Helpers.combineWs Types.lengthPercentageToString r
        let stringifyPolygon p =
            let unboxPolygon (Types.Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (Types.lengthPercentageToString x)
                    (Types.lengthPercentageToString y))

        match clipPath with
        | :? Types.Geometry as g -> Utilities.Helpers.duToKebab g
        | :? Types.Inset as i -> sprintf "inset(%s)" <| stringifyInset i
        | :? Types.Round as r ->
            let unboxRound (Types.Round(r, i)) = i, r
            let (r, i) = unboxRound r
            sprintf "inset(%s round %s)"
                (stringifyInset i)
                (stringifyRound r)
        | :? Types.Polygon as p ->
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
        static member Inset (inset: Types.ILengthPercentage) =
            Types.Inset.All inset
            |> clipPathValue'
        static member Inset (horizontal: Types.ILengthPercentage, vertical: Types.ILengthPercentage) =
            Types.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, horizontal: Types.ILengthPercentage, bottom: Types.ILengthPercentage) =
            Types.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, right: Types.ILengthPercentage, bottom: Types.ILengthPercentage, left: Types.ILengthPercentage) =
            Types.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member Inset (inset: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.Round (Types.Inset.All inset, round)
            |> clipPathValue'
        static member Inset (horizontal: Types.ILengthPercentage, vertical: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.Round (Types.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, horizontal: Types.ILengthPercentage, bottom: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.Round (Types.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, right: Types.ILengthPercentage, bottom: Types.ILengthPercentage, left: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.Round (Types.Inset.TopRightBottomLeft(top, right, bottom, left), round)
            |> clipPathValue'
        static member Circle (radius: Types.ILengthPercentage) =
            sprintf "circle(%s)"
                (Types.lengthPercentageToString radius)
            |> clipPathValue
        static member CircleAt (radius: Types.ILengthPercentage, x: Types.ILengthPercentage, y: Types.ILengthPercentage) =
            sprintf "circle(%s at %s %s)"
                (Types.lengthPercentageToString radius)
                (Types.lengthPercentageToString x)
                (Types.lengthPercentageToString y)
            |> clipPathValue
        static member Ellipse (radius: Types.ILengthPercentage) =
            sprintf "ellipse(%s)"
                (Types.lengthPercentageToString radius)
            |> clipPathValue
        static member EllipseAt (radius: Types.ILengthPercentage, x: Types.ILengthPercentage, y: Types.ILengthPercentage) =
            sprintf "ellipse(%s at %s %s)"
                (Types.lengthPercentageToString radius)
                (Types.lengthPercentageToString x)
                (Types.lengthPercentageToString y)
            |> clipPathValue
        static member Url (url: string) =
            sprintf "url(%s)" url
            |> clipPathValue
        static member Path (path: string) =
            sprintf "path('%s')" path
            |> clipPathValue
        static member Polygon (points: Types.Point list) =
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