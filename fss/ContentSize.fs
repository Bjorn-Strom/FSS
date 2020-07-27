namespace Fss

open Units.Size
open Types
open Global

// https://developer.mozilla.org/en-US/docs/Web/CSS/width
// https://developer.mozilla.org/en-US/docs/Web/CSS/height
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/min-height
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
// https://developer.mozilla.org/en-US/docs/Web/CSS/max-height
module ContentSize =
    type ContentSize =
        | MaxContent
        | MinContent
        | FitContent of Size
        interface IContentSize

    let private contentSizeValue (v: ContentSize): string =
        match v with
            | MaxContent -> "max-content"
            | MinContent -> "min-content"
            | FitContent s -> sprintf "fit-content(%s)" (Units.Size.value s)

    let value (v: IContentSize): string =
        match v with
            | :? Global as g -> Global.value g
            | :? Size as s -> Units.Size.value s
            | :? ContentSize as c -> contentSizeValue c