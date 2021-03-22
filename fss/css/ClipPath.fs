namespace Fss

[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: Types.IClipPath) =
        let stringifyInset =
            function
                | Types.ClipPath.All a -> Types.unitHelpers.lengthPercentageToString a
                | Types.ClipPath.HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (Types.unitHelpers.lengthPercentageToString h)
                        (Types.unitHelpers.lengthPercentageToString v)
                | Types.ClipPath.TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (Types.unitHelpers.lengthPercentageToString t)
                        (Types.unitHelpers.lengthPercentageToString h)
                        (Types.unitHelpers.lengthPercentageToString b)
                | Types.ClipPath.TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (Types.unitHelpers.lengthPercentageToString t)
                        (Types.unitHelpers.lengthPercentageToString r)
                        (Types.unitHelpers.lengthPercentageToString b)
                        (Types.unitHelpers.lengthPercentageToString l)
        let stringifyRound r = Utilities.Helpers.combineWs Types.unitHelpers.lengthPercentageToString r
        let stringifyPolygon p =
            let unboxPolygon (Types.ClipPath.Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (Types.unitHelpers.lengthPercentageToString x)
                    (Types.unitHelpers.lengthPercentageToString y))

        match clipPath with
        | :? Types.ClipPath.Geometry as g -> Utilities.Helpers.duToKebab g
        | :? Types.ClipPath.Inset as i -> sprintf "inset(%s)" <| stringifyInset i
        | :? Types.ClipPath.Round as r ->
            let unboxRound (Types.ClipPath.Round(r, i)) = i, r
            let (r, i) = unboxRound r
            sprintf "inset(%s round %s)"
                (stringifyInset i)
                (stringifyRound r)
        | :? Types.ClipPath.Polygon as p ->
            sprintf "polygon(%s)" <| stringifyPolygon p
        | :? Types.Keywords as k -> Types.masterTypeHelpers.keywordsToString k
        | :? Types.None' -> Types.masterTypeHelpers.none
        | _ -> "Unknown clip path"

    let private clipPathValue value = Types.propertyHelpers.cssValue Types.Property.ClipPath value
    let private clipPathValue' value =
        value
        |> stringifyClipPath
        |> clipPathValue

    type ClipPath =
        static member Inset (inset: Types.ILengthPercentage) =
            Types.ClipPath.Inset.All inset
            |> clipPathValue'
        static member Inset (horizontal: Types.ILengthPercentage, vertical: Types.ILengthPercentage) =
            Types.ClipPath.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, horizontal: Types.ILengthPercentage, bottom: Types.ILengthPercentage) =
            Types.ClipPath.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, right: Types.ILengthPercentage, bottom: Types.ILengthPercentage, left: Types.ILengthPercentage) =
            Types.ClipPath.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member Inset (inset: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.ClipPath.Round (Types.ClipPath.Inset.All inset, round)
            |> clipPathValue'
        static member Inset (horizontal: Types.ILengthPercentage, vertical: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.ClipPath.Round (Types.ClipPath.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, horizontal: Types.ILengthPercentage, bottom: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.ClipPath.Round (Types.ClipPath.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member Inset (top: Types.ILengthPercentage, right: Types.ILengthPercentage, bottom: Types.ILengthPercentage, left: Types.ILengthPercentage, round: Types.ILengthPercentage list) =
            Types.ClipPath.Round (Types.ClipPath.Inset.TopRightBottomLeft(top, right, bottom, left), round)
            |> clipPathValue'
        static member Circle (radius: Types.ILengthPercentage) =
            sprintf "circle(%s)"
                (Types.unitHelpers.lengthPercentageToString radius)
            |> clipPathValue
        static member CircleAt (radius: Types.ILengthPercentage, x: Types.ILengthPercentage, y: Types.ILengthPercentage) =
            sprintf "circle(%s at %s %s)"
                (Types.unitHelpers.lengthPercentageToString radius)
                (Types.unitHelpers.lengthPercentageToString x)
                (Types.unitHelpers.lengthPercentageToString y)
            |> clipPathValue
        static member Ellipse (radius: Types.ILengthPercentage) =
            sprintf "ellipse(%s)"
                (Types.unitHelpers.lengthPercentageToString radius)
            |> clipPathValue
        static member EllipseAt (radius: Types.ILengthPercentage, x: Types.ILengthPercentage, y: Types.ILengthPercentage) =
            sprintf "ellipse(%s at %s %s)"
                (Types.unitHelpers.lengthPercentageToString radius)
                (Types.unitHelpers.lengthPercentageToString x)
                (Types.unitHelpers.lengthPercentageToString y)
            |> clipPathValue
        static member Url (url: string) =
            sprintf "url(%s)" url
            |> clipPathValue
        static member Path (path: string) =
            sprintf "path('%s')" path
            |> clipPathValue
        static member Polygon (points: Types.ClipPath.Point list) =
            Types.ClipPath.Polygon points
            |> clipPathValue'

        static member MarginBox = Types.ClipPath.MarginBox |> clipPathValue'
        static member BorderBox = Types.ClipPath.BorderBox |> clipPathValue'
        static member PaddingBox = Types.ClipPath.PaddingBox |> clipPathValue'
        static member ContentBox = Types.ClipPath.ContentBox |> clipPathValue'
        static member FillBox = Types.ClipPath.FillBox |> clipPathValue'
        static member StrokeBox = Types.ClipPath.StrokeBox |> clipPathValue'
        static member ViewBox = Types.ClipPath.ViewBox |> clipPathValue'

        static member None = Types.None' |> clipPathValue'
        static member Inherit = Types.Inherit |> clipPathValue'
        static member Initial = Types.Initial |> clipPathValue'
        static member Unset = Types.Unset |> clipPathValue'