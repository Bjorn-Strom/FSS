namespace Fss

[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: FssTypes.IClipPath) =
        let stringifyInset =
            function
                | FssTypes.ClipPath.All a -> FssTypes.unitHelpers.lengthPercentageToString a
                | FssTypes.ClipPath.HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (FssTypes.unitHelpers.lengthPercentageToString h)
                        (FssTypes.unitHelpers.lengthPercentageToString v)
                | FssTypes.ClipPath.TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (FssTypes.unitHelpers.lengthPercentageToString t)
                        (FssTypes.unitHelpers.lengthPercentageToString h)
                        (FssTypes.unitHelpers.lengthPercentageToString b)
                | FssTypes.ClipPath.TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (FssTypes.unitHelpers.lengthPercentageToString t)
                        (FssTypes.unitHelpers.lengthPercentageToString r)
                        (FssTypes.unitHelpers.lengthPercentageToString b)
                        (FssTypes.unitHelpers.lengthPercentageToString l)
        let stringifyRound r = Utilities.Helpers.combineWs FssTypes.unitHelpers.lengthPercentageToString r
        let stringifyPolygon p =
            let unboxPolygon (FssTypes.ClipPath.Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (FssTypes.unitHelpers.lengthPercentageToString x)
                    (FssTypes.unitHelpers.lengthPercentageToString y))

        match clipPath with
        | :? FssTypes.ClipPath.Geometry as g -> Utilities.Helpers.duToKebab g
        | :? FssTypes.ClipPath.Inset as i -> sprintf "inset(%s)" <| stringifyInset i
        | :? FssTypes.ClipPath.Round as r ->
            let unboxRound (FssTypes.ClipPath.Round(r, i)) = i, r
            let (r, i) = unboxRound r
            sprintf "inset(%s round %s)"
                (stringifyInset i)
                (stringifyRound r)
        | :? FssTypes.ClipPath.Polygon as p ->
            sprintf "polygon(%s)" <| stringifyPolygon p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown clip path"

    let private clipPathValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.ClipPath value
    let private clipPathValue' value =
        value
        |> stringifyClipPath
        |> clipPathValue

    type ClipPath =
        static member inset (inset: FssTypes.ILengthPercentage) =
            FssTypes.ClipPath.Inset.All inset
            |> clipPathValue'
        static member inset (horizontal: FssTypes.ILengthPercentage, vertical: FssTypes.ILengthPercentage) =
            FssTypes.ClipPath.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member inset (top: FssTypes.ILengthPercentage, horizontal: FssTypes.ILengthPercentage, bottom: FssTypes.ILengthPercentage) =
            FssTypes.ClipPath.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member inset (top: FssTypes.ILengthPercentage, right: FssTypes.ILengthPercentage, bottom: FssTypes.ILengthPercentage, left: FssTypes.ILengthPercentage) =
            FssTypes.ClipPath.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member inset (inset: FssTypes.ILengthPercentage, round: FssTypes.ILengthPercentage list) =
            FssTypes.ClipPath.Round (FssTypes.ClipPath.Inset.All inset, round)
            |> clipPathValue'
        static member inset (horizontal: FssTypes.ILengthPercentage, vertical: FssTypes.ILengthPercentage, round: FssTypes.ILengthPercentage list) =
            FssTypes.ClipPath.Round (FssTypes.ClipPath.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member inset (top: FssTypes.ILengthPercentage, horizontal: FssTypes.ILengthPercentage, bottom: FssTypes.ILengthPercentage, round: FssTypes.ILengthPercentage list) =
            FssTypes.ClipPath.Round (FssTypes.ClipPath.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member inset (top: FssTypes.ILengthPercentage, right: FssTypes.ILengthPercentage, bottom: FssTypes.ILengthPercentage, left: FssTypes.ILengthPercentage, round: FssTypes.ILengthPercentage list) =
            FssTypes.ClipPath.Round (FssTypes.ClipPath.Inset.TopRightBottomLeft(top, right, bottom, left), round)
            |> clipPathValue'
        static member circle (radius: FssTypes.ILengthPercentage) =
            sprintf "circle(%s)"
                (FssTypes.unitHelpers.lengthPercentageToString radius)
            |> clipPathValue
        static member circleAt (radius: FssTypes.ILengthPercentage, x: FssTypes.ILengthPercentage, y: FssTypes.ILengthPercentage) =
            sprintf "circle(%s at %s %s)"
                (FssTypes.unitHelpers.lengthPercentageToString radius)
                (FssTypes.unitHelpers.lengthPercentageToString x)
                (FssTypes.unitHelpers.lengthPercentageToString y)
            |> clipPathValue
        static member ellipse (radius: FssTypes.ILengthPercentage) =
            sprintf "ellipse(%s)"
                (FssTypes.unitHelpers.lengthPercentageToString radius)
            |> clipPathValue
        static member ellipseAt (radius: FssTypes.ILengthPercentage, x: FssTypes.ILengthPercentage, y: FssTypes.ILengthPercentage) =
            sprintf "ellipse(%s at %s %s)"
                (FssTypes.unitHelpers.lengthPercentageToString radius)
                (FssTypes.unitHelpers.lengthPercentageToString x)
                (FssTypes.unitHelpers.lengthPercentageToString y)
            |> clipPathValue
        static member url (url: string) =
            sprintf "url(%s)" url
            |> clipPathValue
        static member path (path: string) =
            sprintf "path('%s')" path
            |> clipPathValue
        static member polygon (points: FssTypes.ClipPath.Point list) =
            FssTypes.ClipPath.Polygon points
            |> clipPathValue'

        static member marginBox = FssTypes.ClipPath.MarginBox |> clipPathValue'
        static member borderBox = FssTypes.ClipPath.BorderBox |> clipPathValue'
        static member paddingBox = FssTypes.ClipPath.PaddingBox |> clipPathValue'
        static member contentBox = FssTypes.ClipPath.ContentBox |> clipPathValue'
        static member fillBox = FssTypes.ClipPath.FillBox |> clipPathValue'
        static member strokeBox = FssTypes.ClipPath.StrokeBox |> clipPathValue'
        static member viewBox = FssTypes.ClipPath.ViewBox |> clipPathValue'

        static member none = FssTypes.None' |> clipPathValue'
        static member inherit' = FssTypes.Inherit |> clipPathValue'
        static member initial = FssTypes.Initial |> clipPathValue'
        static member unset = FssTypes.Unset |> clipPathValue'