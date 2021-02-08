namespace Fss

open Fss.Units
open Fss.Units.Percent

[<RequireQualifiedAccess>]
module ClipPathType =
    type Geometry =
        | MarginBox
        | BorderBox
        | PaddingBox
        | ContentBox
        | FillBox
        | StrokeBox
        | ViewBox
        interface IClipPath

    type Inset =
        | All of ILengthPercentage
        | HorizontalVertical of ILengthPercentage * ILengthPercentage
        | TopHorizontalBottom of ILengthPercentage * ILengthPercentage * ILengthPercentage
        | TopRightBottomLeft of ILengthPercentage * ILengthPercentage * ILengthPercentage * ILengthPercentage
        interface IClipPath
    type Round =
        | Round of Inset * ILengthPercentage list
        interface IClipPath

    type Point = Percent * Percent
    type Polygon =
        | Polygon of Point list
        interface IClipPath

    type Url = Url of string
    type Path = Path of string


[<AutoOpen>]
module ClipPath =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    let private stringifyClipPath (clipPath: IClipPath) =
        let stringifyInset =
            function
                | ClipPathType.All a -> LengthPercentage.value a
                | ClipPathType.HorizontalVertical (h, v) ->
                    sprintf "%s %s"
                        (LengthPercentage.value h)
                        (LengthPercentage.value v)
                | ClipPathType.TopHorizontalBottom (t, h, b) ->
                    sprintf "%s %s %s"
                        (LengthPercentage.value t)
                        (LengthPercentage.value h)
                        (LengthPercentage.value b)
                | ClipPathType.TopRightBottomLeft (t, r, b, l) ->
                    sprintf "%s %s %s %s"
                        (LengthPercentage.value t)
                        (LengthPercentage.value r)
                        (LengthPercentage.value b)
                        (LengthPercentage.value l)
        let stringifyRound r = Utilities.Helpers.combineWs LengthPercentage.value r
        let stringifyPolygon p =
            let unboxPolygon (ClipPathType.Polygon p) = p
            unboxPolygon p
            |> Utilities.Helpers.combineComma (fun (x, y) ->
                sprintf "%s %s"
                    (LengthPercentage.value x)
                    (LengthPercentage.value y))

        match clipPath with
        | :? ClipPathType.Geometry as g -> Utilities.Helpers.duToKebab g
        | :? ClipPathType.Inset as i -> sprintf "inset(%s)" <| stringifyInset i
        | :? ClipPathType.Round as r ->
            let unboxRound (ClipPathType.Round (r, i)) = i, r
            let (r, i) = unboxRound r
            sprintf "inset(%s round %s)"
                (stringifyInset i)
                (stringifyRound r)
        | :? ClipPathType.Polygon as p ->
            sprintf "polygon(%s)" <| stringifyPolygon p
        | :? Global as g -> GlobalValue.global' g
        | :? None -> GlobalValue.none
        | _ -> "Unknown clip path"

    let private clipPathValue value = PropertyValue.cssValue Property.ClipPath value
    let private clipPathValue' value =
        value
        |> stringifyClipPath
        |> clipPathValue

    type ClipPath =
        static member Inset (inset: ILengthPercentage) =
            ClipPathType.Inset.All inset
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            ClipPathType.Inset.HorizontalVertical(horizontal, vertical)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage) =
            ClipPathType.Inset.TopHorizontalBottom(top, horizontal, bottom)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage) =
            ClipPathType.Inset.TopRightBottomLeft(top, right, bottom, left)
            |> clipPathValue'
        static member Inset (inset: ILengthPercentage, round: ILengthPercentage list) =
            ClipPathType.Round (ClipPathType.Inset.All inset, round)
            |> clipPathValue'
        static member Inset (horizontal: ILengthPercentage, vertical: ILengthPercentage, round: ILengthPercentage list) =
            ClipPathType.Round (ClipPathType.Inset.HorizontalVertical(horizontal, vertical), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage, round: ILengthPercentage list) =
            ClipPathType.Round (ClipPathType.Inset.TopHorizontalBottom(top, horizontal, bottom), round)
            |> clipPathValue'
        static member Inset (top: ILengthPercentage, right: ILengthPercentage, bottom: ILengthPercentage, left: ILengthPercentage, round: ILengthPercentage list) =
            ClipPathType.Round (ClipPathType.Inset.TopRightBottomLeft(top, right, bottom, left), round)
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
        static member Polygon (points: ClipPathType.Point list) =
            ClipPathType.Polygon points
            |> clipPathValue'

        static member MarginBox = ClipPathType.MarginBox |> clipPathValue'
        static member BorderBox = ClipPathType.BorderBox |> clipPathValue'
        static member PaddingBox = ClipPathType.PaddingBox |> clipPathValue'
        static member ContentBox = ClipPathType.ContentBox |> clipPathValue'
        static member FillBox = ClipPathType.FillBox |> clipPathValue'
        static member StrokeBox = ClipPathType.StrokeBox |> clipPathValue'
        static member ViewBox = ClipPathType.ViewBox |> clipPathValue'

        static member None = None |> clipPathValue'
        static member Inherit = Inherit |> clipPathValue'
        static member Initial = Initial |> clipPathValue'
        static member Unset = Unset |> clipPathValue'

    /// <summary>Resets all of an elements properties.</summary>
    /// <param name="all">
    ///     can be:
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    //let private All' (all: IAll) = all |> All.Value
