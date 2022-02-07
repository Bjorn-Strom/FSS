namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module ClipPath =
    type Geometry =
        | MarginBox
        | BorderBox
        | PaddingBox
        | ContentBox
        | FillBox
        | StrokeBox
        | ViewBox
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

    type Inset =
        | All of ILengthPercentage
        | HorizontalVertical of ILengthPercentage * ILengthPercentage
        | TopHorizontalBottom of ILengthPercentage * ILengthPercentage * ILengthPercentage
        | TopRightBottomLeft of ILengthPercentage * ILengthPercentage * ILengthPercentage * ILengthPercentage
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | All length -> $"inset({lengthPercentageString length})"
                | HorizontalVertical (a, b) -> $"inset({lengthPercentageString a} {lengthPercentageString b})"
                | TopHorizontalBottom (a, b, c) ->
                    $"inset({lengthPercentageString a} {lengthPercentageString b} {lengthPercentageString c})"
                | TopRightBottomLeft (a, b, c, d) ->
                    $"inset({lengthPercentageString a} {lengthPercentageString b} {lengthPercentageString c} {lengthPercentageString d})"

    type Round =
        | Round of Inset * ILengthPercentage list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Round (inset, lengths) ->
                    let inset =
                        (stringifyICssValue inset).Replace(")", "")

                    let lengths =
                        lengths
                        |> List.map (fun x -> lengthPercentageString x)
                        |> String.concat " "

                    $"{inset} round {lengths})"

    type Point = Percent * Percent

    type Polygon =
        | Polygon of Point list
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Polygon ps ->
                    let polygons =
                        ps
                        |> List.map (fun (x, y) -> $"{lengthPercentageString x} {lengthPercentageString y}")
                        |> String.concat ", "

                    $"polygon({polygons})"

    type Circle =
        | Circle of ILengthPercentage
        | CircleAt of ILengthPercentage * ILengthPercentage * ILengthPercentage
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Circle c -> $"circle({lengthPercentageString c})"
                | CircleAt (size, x, y) ->
                    $"circle({lengthPercentageString size} at {lengthPercentageString x} {lengthPercentageString y})"

    type Ellipse =
        | Ellipse of ILengthPercentage
        | EllipseAt of ILengthPercentage * ILengthPercentage * ILengthPercentage
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Ellipse e -> $"ellipse({lengthPercentageString e})"
                | EllipseAt (size, x, y) ->
                    $"ellipse({lengthPercentageString size} at {lengthPercentageString x} {lengthPercentageString y})"


[<RequireQualifiedAccess>]
module ClipPathClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/clip-path
    type ClipPath(property) =
        inherit CssRuleWithNone(property)
        member this.url(url: string) = (property, Url url) |> Rule
        member this.path(path: string) = (property, Path path) |> Rule
        member this.inset(inset: ILengthPercentage) = (property, ClipPath.All inset) |> Rule

        member this.inset(horizontal: ILengthPercentage, vertical: ILengthPercentage) =
            (property, ClipPath.HorizontalVertical(horizontal, vertical))
            |> Rule

        member this.inset(top: ILengthPercentage, horizontal: ILengthPercentage, bottom: ILengthPercentage) =
            (property, ClipPath.TopHorizontalBottom(top, horizontal, bottom))
            |> Rule

        member this.inset
            (
                top: ILengthPercentage,
                right: ILengthPercentage,
                bottom: ILengthPercentage,
                left: ILengthPercentage
            ) =
            (property, ClipPath.TopRightBottomLeft(top, right, bottom, left))
            |> Rule

        member this.inset(inset: ILengthPercentage, round: ILengthPercentage list) =
            (property, ClipPath.Round(ClipPath.All inset, round)) |> Rule

        member this.inset
            (
                horizontal: ILengthPercentage,
                vertical: ILengthPercentage,
                round: ILengthPercentage list
            ) =
            (property, ClipPath.Round(ClipPath.HorizontalVertical(horizontal, vertical), round))
            |> Rule

        member this.inset
            (
                top: ILengthPercentage,
                horizontal: ILengthPercentage,
                bottom: ILengthPercentage,
                round: ILengthPercentage list
            ) =
            (property, ClipPath.Round(ClipPath.TopHorizontalBottom(top, horizontal, bottom), round))
            |> Rule

        member this.inset
            (
                top: ILengthPercentage,
                right: ILengthPercentage,
                bottom: ILengthPercentage,
                left: ILengthPercentage,
                round: ILengthPercentage list
            ) =
            (property, ClipPath.Round(ClipPath.TopRightBottomLeft(top, right, bottom, left), round))
            |> Rule

        member this.circle(circle: ILengthPercentage) = (property, ClipPath.Circle circle) |> Rule

        member this.circleAt(circle: ILengthPercentage, x: ILengthPercentage, y: ILengthPercentage) =
            (property, ClipPath.CircleAt(circle, x, y)) |> Rule

        member this.ellipse(ellipse: ILengthPercentage) = (property, ClipPath.Ellipse ellipse) |> Rule

        member this.ellipseAt(ellipse: ILengthPercentage, x: ILengthPercentage, y: ILengthPercentage) =
            (property, ClipPath.EllipseAt(ellipse, x, y)) |> Rule

        member this.polygon(points: ClipPath.Point list) = (property, ClipPath.Polygon points) |> Rule

        member this.marginBox = (property, ClipPath.MarginBox) |> Rule
        member this.borderBox = (property, ClipPath.BorderBox) |> Rule
        member this.paddingBox = (property, ClipPath.PaddingBox) |> Rule
        member this.contentBox = (property, ClipPath.ContentBox) |> Rule
        member this.fillBox = (property, ClipPath.FillBox) |> Rule
        member this.strokeBox = (property, ClipPath.StrokeBox) |> Rule
        member this.viewBox = (property, ClipPath.ViewBox) |> Rule
